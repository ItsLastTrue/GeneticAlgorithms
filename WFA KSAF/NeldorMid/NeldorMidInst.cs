using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WFA.KSAF.Entities;

namespace WFA.KSAF.NeldorMid
{
    internal struct NeldorMidResult
    {
        public int RestartCounts;
        public double[] BestLeafs;
    }

    public sealed class SurvivalTester
    {
        public int BestGenotypeNumber;
        public List<double> Points;

        private readonly Individual[] _individual;
        private readonly int _popSize;

        public SurvivalTester(Individual[] individual, int populationSize)
        {
            _individual = individual;
            _popSize = populationSize;
        }

        public void CollectFitnessFunctions(Assembly assembly, int maxIterationsNm)
        {
            object evaluator = assembly.CreateInstance("WFA.KSAF.Generated.Estimator");
            var tasks = new Task[_popSize];
            var results = new NeldorMidResult[_popSize];
            //const int copyToRun = 2;

            for (var s = 0; s < _popSize; s++) //s = s + copyToRun)
            {
                int s1 = s;
                tasks[s] = Task.Run(() => results[s1] = new NeldorMidInst(evaluator, _individual[s1].LeafsCount).Run(s1, maxIterationsNm));
            }

            Task.WaitAll(tasks);

            var bestDeviate = double.MaxValue;

            for (var s = 0; s < _popSize; s++)
            {
                double dev = results[s].BestLeafs[_individual[s].LeafsCount];
                _individual[s].SurvivalRate.Deviations = dev;

                if (dev < bestDeviate)
                {
                    bestDeviate = dev;
                    BestGenotypeNumber = s;
                }
                _individual[s].SurvivalRate.Constants = results[s].BestLeafs;
                _individual[s].SurvivalRate.NelMidRestarts = results[s].RestartCounts;
            }

            FillFunctionPoints(evaluator, _individual[BestGenotypeNumber].SurvivalRate.Constants, BestGenotypeNumber);
            //CollectBestGraphPoints(Out_Constants[Result_BestGenotype], Result_BestGenotype);
        }

        //private void RecurseFilter()
        //{
        //    var nl = new NeldorMidThreads();
        //    var best_Deviate = Math.Pow(10, 300);
        //    for (int s = 0; s < 200; s++)
        //    {
        //        for (int i = 0; i < 10; i++) RecFiltr[i] = 0;
        //        nl.NeldorMid(this, s);
        //        var _dev = BestLeafs[s][CnstInG[s]];
        //        Out_Deviations.Add(_dev);
        //        if (_dev < best_Deviate)
        //        {
        //            best_Deviate = _dev;
        //            Result_BestGenotype = s;
        //
        //        }
        //        Out_Constants.Add(BestLeafs[s]);
        //
        //    }
        //    CollectBestGraphPoints(Out_Constants[Result_BestGenotype], Result_BestGenotype);
        //
        //}

        private void FillFunctionPoints(object evaluatorInstance, double[] leafs, int genotypeIndex)
        {
            Type evaluatorType = evaluatorInstance.GetType();
            Points = (List<double>) evaluatorType.InvokeMember("GetFunctionPoints", BindingFlags.InvokeMethod, null, evaluatorInstance, new object[] {leafs, genotypeIndex});
        }
    }

    internal sealed class NeldorMidInst
    {
        private readonly object _evaluatorInstance;
        private readonly Random _rnd = new Random();

        /// <summary>
        /// Преследуемая сходимость симплекса.
        /// </summary>
        private double _targetDeviation;

        /// <summary>
        /// Количество измерений симплекса.
        /// </summary>
        private readonly int _nMer;

        public NeldorMidInst(object evaluatorInstance, int nMer)
        {
            _evaluatorInstance = evaluatorInstance
                                 ?? throw new Exception("Error 9451610. Исполнительный файл для подсчета отклонений не найден.");
            _nMer = nMer;
        }

        //NELDOR MID
        public NeldorMidResult Run(int genotypenumber, int maxIterationsNm)
        {
            if (_nMer == 0)
                return new NeldorMidResult { RestartCounts = 0, BestLeafs = new[] { DeviationCollections(new[] { 0.0 }, genotypenumber) } };

            var iteration = 0;
            var bestLeafs = new double[_nMer + 1];
            var restartCount = 0;


            //коэффицент отражения";
            double A_Mirror = 1;

            // коэффицент сжатия";
            double B_Сompression = 0.5;

            //коэффицент растяжения";
            double G_Tensile = 2;

            //Центр тяжесть Xo";
            double[] gravityCentr = new double[_nMer];

            //точка отражения Xr";
            double[] mirrorVertice = new double[_nMer + 1];

            //точка растяжения Xe";
            double[] tensileVertice = new double[_nMer + 1];

            //точка сжатия Xc";
            double[] сompressionVertice = new double[_nMer + 1];

            // вершина симлекса с наименьшим значением функции Xl, лучшая  ";
            double[] minVertice = new double[_nMer + 1];

            // вершина симлекса с наибольшем значением функции Xh, худшая";
            double[] maxVertice = new double[_nMer + 1];

            // вершина симлекса со значением функции следующим за максимальным Xg";
            double[] penultMaxVertice = new double[_nMer + 1];


            //FULL RESTART
            ReStart:

            //Преследуемая сходимость
            double targetConvergence = _rnd.Next(1, 11) * 0.1;
            _targetDeviation = 1;
            double simplexStep = 1;
            List<double[]> simplexVertices = new List<double[]>();

            // Вершины симлекса
            double[] firstVertice = new double[_nMer + 1];
            for (var j = 0; j < _nMer; j++)
                firstVertice[j] = (_rnd.Next(0, 9000) - 4000) * 0.01;

            firstVertice[_nMer] = DeviationCollections(firstVertice, genotypenumber);
            simplexVertices.Add(firstVertice);
            for (var i = 1; i <= _nMer; i++)
            {
                var tempVert = new double[_nMer + 1];
                firstVertice.CopyTo(tempVert, 0);
                tempVert[i - 1] += simplexStep;
                tempVert[_nMer] = DeviationCollections(tempVert, genotypenumber);
                simplexVertices.Add(tempVert);
            }

            SortDouble(simplexVertices, 0, _nMer);

            //START ALGORITM
            // Get GravityCentr, Get Mirror Vertice (MV), Check Function in MV, Сomparison, go next or change Simplex and repite
            Start: iteration++;
            if (iteration == maxIterationsNm) goto End;

            // сортировка вершин симплекса со значениями функции от наименьшего к большему
            minVertice = simplexVertices[0];
            maxVertice = simplexVertices[_nMer];
            penultMaxVertice = simplexVertices[_nMer - 1];

            // центр тяжести противоположный наихудшей вершине
            gravityCentr = GetGravityCentr(simplexVertices, _nMer - 1);
            mirrorVertice = GetNewVertice(gravityCentr, gravityCentr, maxVertice, A_Mirror, genotypenumber);

            //MIRROR AMD TENSILE START";
            // Если точка отражения улучшила худшую вершину
            if (mirrorVertice[_nMer] < minVertice[_nMer])
            {
                tensileVertice = GetNewVertice(gravityCentr, mirrorVertice, gravityCentr, G_Tensile, genotypenumber);
                if (tensileVertice[_nMer] < mirrorVertice[_nMer])
                {
                    //Заменям Xh на Xe: наихудшую (MAX) вершину на полученную растяжением
                    tensileVertice.CopyTo(simplexVertices[_nMer], 0);
                    SortDouble(simplexVertices, 0, _nMer);
                    if (CheckСonvergence(simplexVertices) > targetConvergence) goto Start;
                    else goto End;
                }
                else
                {
                    //Заменям Xh на Xr: наихудшую (MAX) вершину на полученную отражением
                    mirrorVertice.CopyTo(simplexVertices[_nMer], 0);
                    SortDouble(simplexVertices, 0, _nMer);
                    if (CheckСonvergence(simplexVertices) > targetConvergence) goto Start;
                    else goto End;
                }

            }
            // Если точка отражения улучшила предпоследнюю по качеству вершину
            else if (mirrorVertice[_nMer] > minVertice[_nMer] && mirrorVertice[_nMer] < penultMaxVertice[_nMer])
            {
                //Заменям Xh на Xr: наихудшую (MAX) вершину на полученную отражением
                mirrorVertice.CopyTo(simplexVertices[_nMer], 0);
                SortDouble(simplexVertices, 0, _nMer);
                if (CheckСonvergence(simplexVertices) > targetConvergence) goto Start;
                else goto End;

            }
            // Если знач. функции в точке отражения меньше наихудшего (МАХ) значения симлекса
            else if (mirrorVertice[_nMer] < maxVertice[_nMer])
            {
                //Заменям Xh на Xr: наихудшую (MAX) вершину на полученную отражением
                mirrorVertice.CopyTo(simplexVertices[_nMer], 0);
                mirrorVertice.CopyTo(maxVertice, 0);
                gravityCentr = GetGravityCentr(simplexVertices, _nMer - 1);

            }
            //COMPRESSION START";
            // сжимаем симплекс относительно наихудшей(максимальной) точки симплекса
            сompressionVertice = GetNewVertice(gravityCentr, maxVertice, gravityCentr, B_Сompression, genotypenumber);
            if (сompressionVertice[_nMer] < maxVertice[_nMer])
            {
                сompressionVertice.CopyTo(simplexVertices[_nMer], 0);
                //Заменям Xh на Xc: наихудшую (MAX) вершину на полученную сжатием
                SortDouble(simplexVertices, 0, _nMer);
                if (CheckСonvergence(simplexVertices) > targetConvergence) goto Start;
                else goto End;
            }
            else
            {
                DivideSimplex(simplexVertices);
                SortDouble(simplexVertices, 0, _nMer);
                if (CheckСonvergence(simplexVertices) > targetConvergence) goto Start;
                else goto End;
            }
            End: double[] checkDeviation = GetGravityCentr(simplexVertices, _nMer - 1, genotypenumber);
            if (bestLeafs[_nMer] == 0.0)
                checkDeviation.CopyTo(bestLeafs, 0);

            if (checkDeviation[_nMer] > _targetDeviation && iteration != maxIterationsNm)
            {
                if (bestLeafs[_nMer] > checkDeviation[_nMer])
                    checkDeviation.CopyTo(bestLeafs, 0);

                restartCount++;
                goto ReStart;

            }
            return new NeldorMidResult { RestartCounts = restartCount, BestLeafs = bestLeafs };
        }

        /// <summary>
        /// Вычисляем отклонение целевого генотипа.
        /// </summary>
        /// <param name="leafs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double DeviationCollections(double[] leafs, int index)
        {
            Type evaluatorType = _evaluatorInstance.GetType();
            var deviate = (double)evaluatorType.InvokeMember("DeviationCollections", BindingFlags.InvokeMethod, null, _evaluatorInstance, new object[] { leafs, index });
            return deviate;
        }

        /// <summary>
        /// Находим центр тяжести симлекса без значения функции.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="vercticesCount"></param>
        /// <returns></returns>
        private double[] GetGravityCentr(IReadOnlyList<double[]> array, int vercticesCount)
        {
            var tempCent = new double[_nMer + 1];
            for (var i = 0; i <= vercticesCount; i++)
            {
                double[] tempSimplexVertice = array[i];
                for (var j = 0; j < _nMer; j++)
                    tempCent[j] += tempSimplexVertice[j] / _nMer;
            }
            return tempCent;
        }

        /// <summary>
        /// Находим центр тяжести симлекса со значением функции для сравнения с глобальным отклонением.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="vercticesCount"></param>
        /// <param name="genotypenumber"></param>
        /// <returns></returns>
        private double[] GetGravityCentr(IReadOnlyList<double[]> array, int vercticesCount, int genotypenumber)
        {
            var tempCent = new double[_nMer + 1];
            for (var i = 0; i <= vercticesCount; i++)
            {
                double[] tempSimplexVertice = array[i];
                for (int j = 0; j < _nMer; j++)
                    tempCent[j] += tempSimplexVertice[j] / _nMer;
            }
            tempCent[_nMer] = DeviationCollections(tempCent, genotypenumber);
            return tempCent;
        }

        /// <summary>
        /// Универсальный конструктор векторов растяжения, отражения и сжатия.
        /// </summary>
        /// <param name="gravityCentr"></param>
        /// <param name="startingPoint"></param>
        /// <param name="reflectionPoint"></param>
        /// <param name="multiplicator"></param>
        /// <param name="genotypenumber"></param>
        /// <returns></returns>
        private double[] GetNewVertice(double[] gravityCentr, double[] startingPoint, double[] reflectionPoint, double multiplicator, int genotypenumber)
        {
            var tempVert = new double[_nMer + 1];
            for (var j = 0; j < _nMer; j++)
                tempVert[j] += gravityCentr[j] + multiplicator * (startingPoint[j] - reflectionPoint[j]);

            tempVert[_nMer] = DeviationCollections(tempVert, genotypenumber);
            return tempVert;
        }

        /// <summary>
        /// Проверка близости точек друг к другу (степень сжатия симлекса)
        /// </summary>
        /// <param name="simplexVertices"></param>
        /// <returns></returns>
        private double CheckСonvergence(List<double[]> simplexVertices)
        {
            var averageСonvergence = 0.0;
            double[] tempMinVert = simplexVertices[0];
            for (int i = 1; i <= _nMer; i++)
            {
                double[] tempVert = simplexVertices[i];
                for (int n = 0; n < _nMer; n++)
                    averageСonvergence += Math.Abs(tempMinVert[n] - tempVert[n]);
            }
            averageСonvergence = averageСonvergence / Convert.ToDouble(_nMer);
            return averageСonvergence;
        }

        /// <summary>
        /// Сжимаем симплекс к точке с минимальным значением
        /// </summary>
        /// <param name="simplexVertices"></param>
        /// <returns></returns>
        private List<double[]> DivideSimplex(List<double[]> simplexVertices)
        {
            double[] tempMinVert = simplexVertices[0];
            for (var i = 1; i <= _nMer; i++)
            {
                double[] tempVert = simplexVertices[i];
                for (var j = 0; j < _nMer; j++)
                    tempVert[j] = (tempVert[j] + tempMinVert[j]) / 2;
            }
            return simplexVertices;
        }

        /// <summary>
        /// Сортировка.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void SortDouble(List<double[]> array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);
            SortDouble(array, start, pivot - 1);
            SortDouble(array, pivot + 1, end);
        }

        private int Partition(List<double[]> array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                double[] teampReaderStart = array[i];
                double[] teampReaderEnd = array[end];
                if (!(teampReaderStart[_nMer] <= teampReaderEnd[_nMer])) continue;

                double[] temp = array[marker];
                array[marker] = array[i];
                array[i] = temp;
                marker += 1;
            }
            return marker - 1;
        }
    }
}
