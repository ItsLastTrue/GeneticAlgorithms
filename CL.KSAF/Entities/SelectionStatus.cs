using System;
using System.Collections.Generic;
using CL.Extensions;

namespace CL.KSAF.Entities
{
    public sealed class SelectionStatus
    {
        private readonly SelectionConfig _selectionConfig;

        public Action LogPhenotypesFunc;

        public Action CollectClassCode;

        public Action GraphPointsCollector;

        public Action ProgressBarEstimate;

        public readonly Log Log;

        public SelectionStatus(SelectionConfig selectionConfig)
        {
            _selectionConfig = selectionConfig;
            Log = new Log
            {
                Preparation = new List<string>(),
                Simplification = new List<string>(),
                CompileErrors = new List<CompileError>(),
            };
        }

        /// <summary>
        /// Лог последних герерируемых файлов с исходным кодом популяции.
        /// </summary>
        public List<string> CodeList { get; } = new List<string>();

        /// <summary>
        /// Лог коллекции фенотипов.
        /// </summary>
        public List<string> PhenotypesLog { get; } = new List<string>();

        /// <summary>
        /// Текущая итерация.
        /// </summary>
        public int CurrentIteration { get; private set; } = 0;

        /// <summary>
        /// Сообщает нужно ли продолжать создание новых популяций.
        /// </summary>
        public bool IsContinuous { get; set; } = false;

        /// <summary>
        /// True когда выполнилось пропорциональное указанному кол-ву итераций кругов (Exp.: при MAX 10 и итерации №103 => 110)
        /// </summary>
        public bool IsIterationsEnd
        {
            get
            {
                double ratio = (double) CurrentIteration / _selectionConfig.MaxAlgorithmIterations;

                return (ratio / Math.Truncate(ratio) - 1).IsLessThanEpsilon();
            }
        }

        public bool IsProgressOnline { get; set; }

        /// <summary>
        /// Коллекция значений функции в заданных точках для лучшей особи в последней созданной популяции.
        /// </summary>
        public List<double> LastGraphPoints { get; set; }

        public void IncreaseIteration() =>
            CurrentIteration++;

        public int GetProgressPercent(int maxIterations)
        {
            if (IsProgressOnline == false) return 0;

            var progressBar = (int)Math.Round(100 * ((double)CurrentIteration / _selectionConfig.MaxAlgorithmIterations -
                                                     Math.Truncate((double)CurrentIteration / _selectionConfig.MaxAlgorithmIterations)));
            if (progressBar == 0) progressBar = 100;
            return progressBar;
        }

        /// <summary>
        /// Считывает последний набор значений функций.
        /// </summary>
        public void AddLastGraphPoints() =>
            GraphPointsCollector?.Invoke();

        /// <summary>
        /// Добавляет в лог сгенерированный класс последней популяции.
        /// </summary>
        public void AddLastClassCode() =>
            CollectClassCode?.Invoke();

        /// <summary>
        /// Добавляет в лог последний сгенерировнный набор фенотипов.
        /// </summary>
        public void AddLastPhenotypes() =>
            LogPhenotypesFunc?.Invoke();

        public Time Timer = new Time();

        public BestIndividual BestEverIndividual = new BestIndividual();

        public sealed class BestIndividual
        {
            public bool WasChanged { get; set; }

            /// <summary>
            /// Лучшее из достигнутых (за все время) отклонении.
            /// </summary>
            public double Deviation { get; set; } = Math.Pow(10, 300);

            /// <summary>
            /// Функция в 'понятном человеку' математическом виде.
            /// </summary>
            public string Phenotype { get; set; }

            /// <summary>
            /// Значения функций в точках
            /// </summary>
            public List<double> GraphPoints { get; set; }
        }

        public sealed class Time
        {
            public DateTime Created { get; } = DateTime.Now;

            public bool IsActive { get; set; }

            public DateTime Started { get; set; }

            public TimeSpan Elapsed { get; set; }

            public sealed class Loop : IDisposable
            {
                private readonly Time _timer;

                public Loop(Time timer)
                {
                    _timer = timer;
                    _timer.Started = DateTime.Now;
                }

                public void Dispose() =>
                    _timer.Elapsed += DateTime.Now - _timer.Started;
            }
        }
    }
}