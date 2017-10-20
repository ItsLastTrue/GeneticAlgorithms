using System;
using System.Collections.Generic;
using WFA.KSAF.Creators;
using WFA.KSAF.Entities;
using WFA.KSAF.Interfaces;

namespace WFA.KSAF.Selections
{
    /// <summary>
    /// Рулеточный отбор в островном режиме (два острова) плюс
    /// элитарное спасение двух лучших особей в популяции.
    /// </summary>
    internal sealed class MixSelection : ISelection
    {
        private readonly Individual[] _oldPopulation;
        private readonly Log _log;
        private readonly RandomProvider _randomProvider;
        private readonly string[] _operators;
        private int _operatorsCount;
        
        private int _mediateNumber;
        private int _genNum;
        private readonly int _populationSize;

        public MixSelection(Individual[] oldPopulation, Log log, RandomProvider randomProvider, string[] operators)
        {
            _oldPopulation = oldPopulation;
            _log = log;
            _randomProvider = randomProvider;
            _operators = operators;
            _operatorsCount = _operators.Length;
            _populationSize = oldPopulation.Length;
        }

        public int GrowSpeed { get; set; } = 7;

        public int MutationChance { get; set; } = 10;

        public Child[] NewGenotypes()
        {
            var newChilds = new Child[_populationSize];
            var mediateCollections = new List<string>();

            if (_oldPopulation[0] == null)
            {
                for (var i = 0; i <= 20; i++)
                    mediateCollections.Add(_randomProvider.GetNewRandomFunction());

                _mediateNumber = 20;
                var n = CrossingFunctionsGen(_log, mediateCollections[_randomProvider.Next(0, _mediateNumber)], mediateCollections[_randomProvider.Next(0, _mediateNumber)]);
                newChilds[0] = new Child(n.kid1);
                newChilds[1] = new Child(n.kid2);
            }
            else
            {
                _log.Preparation.Clear();
                CreateRuletMediateCollections(newChilds, mediateCollections);
            }

            _genNum = 1;
            for (var i = 2; i < _populationSize; i += 2)
            {
                int father;
                int mother;
                if (i < _populationSize / 2) //Первый остров
                {
                    father = _randomProvider.Next(0, _mediateNumber / 2);
                    mother = _randomProvider.Next(0, _mediateNumber / 2);
                }
                else //Второй остров
                {
                    father = _randomProvider.Next(_mediateNumber / 2, _mediateNumber);
                    mother = _randomProvider.Next(_mediateNumber / 2, _mediateNumber);
                }
                while (father == mother) mother = _randomProvider.Next(0, _mediateNumber);

                var n = CrossingFunctionsGen(_log, mediateCollections[father], mediateCollections[mother]);
                newChilds[i]     = new Child(n.kid1);
                newChilds[i + 1] = new Child(n.kid2);
            }

            return newChilds;
        }

        private void CreateRuletMediateCollections(Child[] newChilds, List<string> mediateCollections)
        {
            _mediateNumber = 0;
            mediateCollections.Clear();

            double psred = 0;
            for (var i = 0; i < _populationSize; i++)
                psred += 1.0 / _oldPopulation[i].SurvivalRate.Deviations;

            psred = psred / _populationSize;

            double fitnessRate1 = -1.0; // лучшая особь перейдет в следующую популяцию без боя.
            double fitnessRate2 = -1.0; // вторая за лучшей особь перейдет в следующую популяцию без боя.
            var fitnessFunction = new double[_populationSize]; //относительная приспособленность каждой особи.

            for (var i = 0; i < _populationSize; i++)
            {
                fitnessFunction[i] = 1.0 / _oldPopulation[i].SurvivalRate.Deviations / psred;
                if (fitnessRate1 < fitnessFunction[i])
                {
                    fitnessRate1 = fitnessFunction[i];
                    newChilds[0] = new Child(_oldPopulation[i].Genotype);
                }
            }

            for (var i = 0; i < _populationSize; i++)
            {
                if (fitnessRate2 < fitnessFunction[i] && fitnessFunction[i] != fitnessRate1)
                {
                    fitnessRate2 = fitnessFunction[i];
                    newChilds[1] = new Child(_oldPopulation[i].Genotype);
                }
            }
            
            for (var i = 0; i < _populationSize; i++)
            {
                while (fitnessFunction[i] > 1)
                {
                    mediateCollections.Add(_oldPopulation[i].Genotype);
                    fitnessFunction[i]--;
                    _mediateNumber++;
                }
                if (_randomProvider.Next(0, 100) < Math.Floor(fitnessFunction[i] * 100))
                {
                    mediateCollections.Add(_oldPopulation[i].Genotype);
                    _mediateNumber++;
                }
            }
        }

        private (string kid1, string kid2) CrossingFunctionsGen(Log log, string male, string female)
        {
            _genNum++;
            string[] getMale = CutGen(male, GrowSpeed);
            _genNum++;
            string[] getfemale = CutGen(female, GrowSpeed);

             var kid1 = getMale[0].Insert(Convert.ToInt16(getMale[2]), Mutations(getfemale[1])).Replace("|", "").Replace("simple", ",n").Replace("+-", "-").Replace("--", "+");
             var kid2 = getfemale[0].Insert(Convert.ToInt16(getfemale[2]), Mutations(getMale[1])).Replace("|", "").Replace("simple", ",n").Replace("+-", "-").Replace("--", "+");
            log.Preparation.Add((_genNum - 1).ToString("000") + ":Kd1: " + kid1 + " ");
            log.Preparation.Add(_genNum.ToString("000") + ":Kd2: " + kid2 + " ");
            return (kid1, kid2);
        }

        private string[] CutGen(string patient, int growSpeed)
        {
            //////tododel
            //patient = "0+Cos(0.0001/Cos(2-0.0001/Cos(2-Pow(Leaf[1],Leaf[1])-Cos(0.0001/Cos(-Leaf[1]-Leaf[0]*2)))-Cos(0.0001/Cos(-(Pow(Arg[0,n],0.0001))))))/Leaf[1]-Leaf[0]*2-Pow(Arg[0,n],Leaf[1])";
            /////del
            string getGen = "";
            int startCutIndex = -1;

            var prepareKid = "";

            patient = Preparation(patient);
            _log.Preparation.Add(_genNum.ToString("000") + ":BEF: " + patient.Replace("simple", ",n") + " ");

            int сutOperator = _randomProvider.Next(1, _operatorsCount + 1); //индекс вырезаемого гена
            //////tododel
            //сutOperator = 2;
            /////del
            int letsWrite = 0;
            int bktOpen = 0;
            int step = _randomProvider.Next(1, Math.Min(growSpeed, _operatorsCount - сutOperator + 2));
            //////tododel
            //Step = 5;
            /////del
            for (var i = 0; i < patient.Length; i++)
            {
#if DEBUG
                char unused = patient[i];
#endif
                if (patient[i].CompareTo('|') == 0 && сutOperator > 0) сutOperator -= 1;

                if (patient[i].CompareTo('|') == 0 && сutOperator < 0) letsWrite -= 1;

                if (patient[i].CompareTo('|') == 0 && сutOperator == 0)
                {
                    startCutIndex = i;
                    letsWrite = step;
                    сutOperator = -1;
                }

                if (patient[i].CompareTo('(') == 0 && (letsWrite > 0 || bktOpen > 0)) bktOpen += 1;

                if (patient[i].CompareTo(')') == 0 && bktOpen > 0)
                {
                    bktOpen -= 1;
                    if (bktOpen == 0) getGen += patient[i];
                }

                if ((patient[i].CompareTo(')') == 0 || patient[i].CompareTo(',') == 0) && letsWrite > 0 && bktOpen == 0)
                    letsWrite -= 1000;

                if (letsWrite > 0 || bktOpen > 0) getGen += patient[i];
            }
            if (getGen[getGen.Length - 1].CompareTo('+') == 0 || getGen[getGen.Length - 1].CompareTo('-') == 0 || getGen[getGen.Length - 1].CompareTo('*') == 0 ||
                getGen[getGen.Length - 1].CompareTo('/') == 0)
                getGen = getGen.Substring(0, getGen.Length - 1);
            prepareKid += patient.Substring(0, startCutIndex);
            prepareKid += patient.Substring(prepareKid.Length + getGen.Length);
            _log.Preparation.Add(_genNum.ToString("000") + ":Aft: " + prepareKid.Replace("simple", ",n") + " ");
            _log.Preparation.Add(_genNum.ToString("000") + ":Cut: " + getGen + " ");
            string[] forReturn = {prepareKid, getGen, startCutIndex.ToString()};
            return forReturn;
        }

        private string Preparation(string s)
        {
            s = s.Replace(",n", "simple");
            _operatorsCount = 0;
            for (var i = 0; i < _operators.Length; i++)
                s = i < 6 ? s.Replace(_operators[i], _operators[i] + "|") : s.Replace(_operators[i], "|" + _operators[i]);

            while (s.Contains("||") || s.Contains("| |"))
                s = s.Replace("||", "|").Replace("| |", "|");

            s = s.Replace("*|-|", "*|-").Replace("/|-|", "/|-").Replace("|-|", "-|").Replace("|1/", "|1.0/");
            _operatorsCount = s.Split(new[] {"|"}, StringSplitOptions.None).Length - 1;
            return s;
        }

        private string Mutations(string genotype)
        {
            if (MutationChance > _randomProvider.Next(0, 100))
                genotype = "0.0001";

            if (MutationChance > _randomProvider.Next(0, 100))
                genotype += _operators[_randomProvider.Next(0, 4)] + _randomProvider.GetNewRandomMathFunction();

            return genotype;
        }
    }
}