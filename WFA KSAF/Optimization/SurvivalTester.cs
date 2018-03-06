using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using WFA.KSAF.Entities;

namespace WFA.KSAF.Optimization
{
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
            var results = new OptimizationResults[_popSize];
            //const int copyToRun = 2;

            for (var s = 0; s < _popSize; s++) //s = s + copyToRun)
            {
                int s1 = s;
                tasks[s] = Task.Run(() => results[s1] = new NeldorMid(evaluator, _individual[s1].LeafsCount).Run(s1, maxIterationsNm));
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
}