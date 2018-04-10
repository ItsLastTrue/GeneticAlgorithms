using CL.KSAF.Entities;
using CL.KSAF.Helpers;
using CL.KSAF.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CL.KSAF.Creators
{
    public sealed class SelectionManager
    {
        /// <summary>
        /// Шлубина хранения логов.
        /// </summary>
        public const int LoggingDepthHistory = 20;



        /// <summary>
        /// Настройки алгоритма которые нельзя редактировать. Создаются на старте.
        /// </summary>
        public readonly SelectionConfig SelectionConfig;

        /// <summary>
        /// Текущий статус селекции (все данные на вывод).
        /// </summary>
        public readonly SelectionStatus Status;
        public readonly Arguments Arguments;

        /// <summary>
        /// Правильный размер популяции (пользователь мог ввести неверное число).
        /// </summary>
        public readonly int PopulationSize;

        /// <summary>
        /// Коллекция внешних зависимостей для активации действий при наступлении ожидаемых событий.
        /// </summary>
        private readonly List<ISelectionLifeCycle> _populationLifeCycles;
        
        /// <summary>
        /// Класс создания новых популяций.
        /// </summary>
        private readonly PopulationCreator _populationCreator;

        public SelectionManager(int populationSize, Arguments arguments, bool isConvolutionMode,
            SelectionConfig selectionConfig, params ISelectionLifeCycle[] selectionLifeCycles)
        {
            PopulationSize = ParityHlp.ToEven(populationSize);
            Arguments = arguments;
            SelectionConfig = selectionConfig;

            var selectionStatusBuilder = new SelectionStatusBuilder(SelectionConfig);
            selectionStatusBuilder.Core();
            selectionStatusBuilder.AddProgressBar();
            selectionStatusBuilder.AddClassCodeCollector(CollectCodeLog);
            selectionStatusBuilder.AddPhenotypeLog(CollectPhenotypesLog);
            selectionStatusBuilder.AddGraphPointsCollector(CollectGraphPoint);
            Status = selectionStatusBuilder.GetResult();

            _populationLifeCycles = selectionLifeCycles.ToList();

            _populationCreator = new PopulationCreator(Arguments, PopulationSize, isConvolutionMode, selectionConfig, Status);
        }

        /// <summary>
        /// Переводит отбор в режим паузы, остановка займет некоторое время(!).
        /// </summary>
        public void PauseLoop() =>
            Status.IsContinuous = false;

        /// <summary>
        /// Прогоняет жизненный цикл популяции по кругу для поиска искомой функции.
        /// </summary>
        /// <param name="force">True - игнорировать достигнутое отлонение и искать дальше.</param>
        /// <param name="unPause">True - продолжить поиск после срабатывания триггера остановки.</param>
        public void ContinueLoop(bool force = false, bool unPause = false)
        {
            if (unPause || Status.CurrentIteration == 0) Status.IsContinuous = true;

            //Чтобы не уменьшать вручную преследуемое отклонение.
            if (force && Status.BestEverIndividual.Deviation < SelectionConfig.TargetDeviation)
                SelectionConfig.TargetDeviation = Status.BestEverIndividual.Deviation;

            //if (Status.BestEverIndividual.Deviation < SelectionConfig.TargetDeviation & Status.IsContinuous)
            //    SelectionConfig.TargetDeviation = Status.BestEverIndividual.Deviation;

            while (Status.BestEverIndividual.Deviation >= SelectionConfig.TargetDeviation && Status.IsContinuous)
            {
                using (new SelectionStatus.Time.Loop(Status.Timer))
                {
                    Status.IncreaseIteration();

                    _populationCreator.Compile(SelectionConfig.TargetDeviation, Status.CurrentIteration);

                    Status.AddLastPhenotypes();
                    Status.AddLastClassCode();
                    Status.AddLastGraphPoints();

                    _populationLifeCycles.ForEach(e => e.OnPopulationCreated());

                    var newBestGenotypeNum = _populationCreator.BestGenotypeNumber;
                    var newBestDeviation = _populationCreator.Individual[newBestGenotypeNum].SurvivalRate.Deviations;
                    var wasChanged = false;

                    //В созданной популяции найдена осособь 'получше'.
                    if (Status.BestEverIndividual.Deviation > newBestDeviation)
                    {
                        Status.BestEverIndividual.Deviation = newBestDeviation;
                        wasChanged = true;
                        var newInd = _populationCreator.GetSimplify(newBestGenotypeNum);

                        for (var i = 0; i < Arguments.Rows; i++)
                            newInd = newInd.Replace("Arg[" + i + ",n]", ((char)(97 + i)).ToString());

                        Status.BestEverIndividual.Phenotype = newInd;
                        Status.BestEverIndividual.GraphPoints = _populationCreator.GraphPoints;
                        Status.BestEverIndividual.WasChanged = true;

                        _populationLifeCycles.ForEach(e => e.OnFindBetterIndividual());
                    }

                    //Новая особь еще и достигла преследуемое отклонение.
                    if (wasChanged && Status.BestEverIndividual.Deviation < SelectionConfig.TargetDeviation)
                    {
                        Status.IsContinuous = false;
                        _populationLifeCycles.ForEach(e => e.OnDeviationLeveled());
                    }
                    //Кончилось отведенное на поиск кол-во итераций.
                    else if (Status.IsIterationsEnd)
                    {
                        Status.IsContinuous = false;
                        _populationLifeCycles.ForEach(e => e.OnMaxIterationsLeveled());
                    }
                    //Продолжаем поиск
                    else
                    {
                        _populationLifeCycles.ForEach(e => e.OnSelectionContinue());
                    }
                }
            }
        }

        /// <summary>
        /// Завершение поиска.
        /// </summary>
        public void EndAlgorithm() =>
            _populationLifeCycles.ForEach(e => e.OnSelectionFinished());
        
        private void CollectPhenotypesLog()
        {
            var log = "";
            for (var i = 0; i < _populationCreator.Individual.Length; i++)
            {
                log += i + " - Кв. отклонение: " + _populationCreator.Individual[i].SurvivalRate.Deviations + "\r\n";
                string leafsJoin = string.Join("; ", _populationCreator.Individual[i].SurvivalRate.Constants.Select(dbl => dbl.ToString(CultureInfo.InvariantCulture)).ToArray());
                log += i + " - Постоянные: " + leafsJoin + "\r\n";
                log += i + " - Генотип: " + _populationCreator.Individual[i].Genotype + "\r\n";
                log += i + " - Рестартов Н-М: " + _populationCreator.Individual[i].SurvivalRate.NelMidRestarts + "\r\n";
            }

            Status.PhenotypesLog.Add(log);

            if (Status.PhenotypesLog.Count > LoggingDepthHistory)
                Status.PhenotypesLog.RemoveAt(1);
        }

        private void CollectGraphPoint() =>
            Status.LastGraphPoints = _populationCreator.GraphPoints;

        private void CollectCodeLog()
        {
            Status.CodeList.Add(_populationCreator.ClassCode);

            if (Status.CodeList.Count > LoggingDepthHistory)
                Status.CodeList.RemoveAt(1);
        }

        //private void WriTeToFile(string code)
        //{
        //    string path = @"c:\Temp\WFA\" + rnd.Next(0, 999999) + ".txt";
        //    if (!File.Exists(path))
        //    {
        //        // Create a file to write to.
        //        string createText = code;
        //        File.WriteAllText(path, createText, Encoding.UTF8);
        //    }
        //}
    }
}