using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using CL.KSAF.Entities;
using CL.KSAF.Extensions;
using CL.KSAF.Interfaces;
using CL.KSAF.Optimization;
using WFA.KSAF.Selections;

namespace CL.KSAF.Creators
{
    internal sealed class PopulationCreator
    {
        /// <summary>
        /// Порядковый номер лучшей особи в популяции.
        /// </summary>
        public int BestGenotypeNumber;

        #region Первый запуск                               ***********************************************************************************************************************************************
        public readonly Individual[] Individual;

        private readonly SelectionConfig _selectionConfig;
        private readonly SelectionStatus _selectionStatus;
        
        public string[] GenotypeKids;
        public List<double> GraphPoints;

        private readonly CsharpCompiler _csharpCompiler;
        private readonly RandomProvider _randomProvider;
        private readonly ISelection _selectionProvider;

        /// <summary>
        /// Значения функции в области определения.
        /// </summary>
        private readonly Arguments _arguments;
        private readonly int _populationSize;
        private readonly bool _convolutionMode;

        public PopulationCreator(Arguments arguments, int popSize, bool goConvolutionMod, SelectionConfig selectionConfig, SelectionStatus selectionStatus)
        {
            _arguments = arguments;
            _convolutionMode = goConvolutionMod;
            _selectionConfig = selectionConfig;
            _selectionStatus = selectionStatus;
            _arguments = arguments;
            _populationSize = popSize;

            _csharpCompiler = new CsharpCompiler();
            _randomProvider = new RandomProvider(selectionConfig.Operators, selectionConfig.MaxConstantsCount, _arguments.Rows);


            Individual = new Individual[_populationSize];

            if (goConvolutionMod)
                _populationSize = _selectionConfig.MaxConstantsCount * 3 - 3;
            else
                _selectionProvider = new MixSelection(Individual, _selectionStatus.Log, _randomProvider, _selectionConfig.Operators)
                {
                    MutationChance = _selectionConfig.MutationChance,
                    GrowSpeed = _selectionConfig.GrowSpeed,
                };

            GenotypeKids = new string[_populationSize];

        }

        public string ClassCode { get; private set; }

        #endregion  
        #region Сборка класса популяции                     ***********************************************************************************************************************************************
        public void Compile(double targetDeviation, int iterationNum)
        {
            IntCounter errCount = 0.ToIntCounter();
            RestartIfErr:
            var recurseFilterIndex = 0;

            if (_convolutionMode)
            {
                RecurseFilter();
                recurseFilterIndex = _selectionConfig.MaxConstantsCount - 1;
            }
            Child[] childs = _selectionProvider.NewGenotypes();

            string switchGenotypes = childs.ToList()
                .Select((e, i) => "               case " + i + ": return " + e.Genotype + ";")
                .Aggregate(string.Empty, (all, next) => all + next + "\r\n");

            string pointsReader = _arguments.Select((arr, row) => string.Join("\r\n",
                    arr.Select((d, column) => "       Arg[" + column + "," +  row + "]=" + d.ToString(CultureInfo.InvariantCulture) + ";")))
                .Aggregate(string.Empty, (all, next) => all + next + "\r\n");

            #region code

            ClassCode = @"using System;
using System.Collections.Generic;

namespace WFA.KSAF.Generated
{
    public class Estimator
    {
       private readonly double[,] Arg = new double[" + (_arguments.Rows + 1) + ", " + _arguments.Count + @"];
       private int PointsCount;
       public List<double[]> BestLeafs = new List<double[]>();

       public Estimator()
       {
           Reader();
       }

       private static bool CompareToZero(double d) => Math.Abs(d) < Double.Epsilon;
       private static double Sin(double arg) => Math.Sin(arg);
       private static double Cos(double arg) => Math.Cos(arg);
       private static double Tan(double arg) => Math.Tan(arg);
       private static double Exp(double arg) => Math.Exp(arg);
       private static double Log(double leaf, double arg) => Math.Log(arg, leaf);
       private static double Pow(double arg, double leaf)
       {
           if (arg > 0) return Math.Pow(arg, leaf);
           double tmp = arg;
           while ((int)tmp % 10 == 0  && CompareToZero(tmp) == false)
               tmp *= 10;
           var negativeArgument = false;

           if (CompareToZero(leaf % 2) == false)
           {
               arg = arg * -1;
              negativeArgument = true;
           }
           double result = Math.Pow(arg, leaf);
           if (negativeArgument) result = result * -1;
           return result;
       }

       private void Reader()
       {
           PointsCount = " + _arguments.Count + @";
" + pointsReader + 
@"       }

       private double GenotypeCollections(int GenotypeIndex, int n, double[] Leaf)
       {
           switch (GenotypeIndex)
           {
" + switchGenotypes + @"
               default:
                   throw new Exception(" + "\"Error 10241610. Размер популяции был изменен.\"" + @");
           }
       }

       public double DeviationCollections(double[] Leaf, int index)
       {
           double temp = 0;
           for (int i = 0 + " + recurseFilterIndex + @"; i < PointsCount; i++)
               temp += Math.Abs((Arg[" + _arguments.Rows + @", i] - GenotypeCollections(index, i, Leaf)));
           
           if (double.IsNaN(temp)) temp = Math.Pow(10, 300);
           return temp;
       }

            //Возвращает график математической функции.
       public List<double> GetFunctionPoints(double[] leafs, int index)
       {
           var points = new List<double>();
           for (int i = 0 + " + recurseFilterIndex + @"; i < PointsCount; i++)
               points.Add(GenotypeCollections(index, i, leafs));

           return points;
       }
   }
}";
            #endregion

            var results = _csharpCompiler.Compile(ClassCode);

            if (results.Errors.HasErrors)
            {
                if (errCount.Val == 10) return;

                string err = results.Errors.Cast<object>().Aggregate(string.Empty, (current, e) => current + e + "\r\n");

                _selectionStatus.Log.CompileErrors.Add(new CompileError {Iteration = iterationNum, Code = ClassCode, ErrorText = err});
                errCount.Inc();
                goto RestartIfErr;
            }

            Assembly assembly = results.CompiledAssembly;
            
            //Новая популяция жизнеспособна
            for (var i = 0; i < _populationSize; i++)
                Individual[i] = childs[i].ToIndividual();

            //Вычисляем приспособленность новой популяции
            var tester = new SurvivalTester(Individual, _populationSize);
            tester.CollectFitnessFunctions(assembly, _selectionConfig.MaxNelrodMidIterations);

            BestGenotypeNumber = tester.BestGenotypeNumber;
            GraphPoints = tester.Points;
            double simpPopul = iterationNum / 10.0;

            if (_convolutionMode == false && Math.Abs(simpPopul / Math.Truncate(simpPopul)).Equals(1))
                SimplifyPopulation();
        }
        #endregion
        #region Упрощение                                   ***********************************************************************************************************************************************
        private void SimplifyPopulation()
        {
            _selectionStatus.Log.Simplification.Clear();
            for (var s = 0; s < _populationSize; s++)
                if (Individual[s].Genotype.Length > 400)
                    Individual[s].Genotype = _randomProvider.GetNewRandomFunction();
                else
                    Individual[s].Simplification(_selectionStatus.Log);
        }

        public string GetSimplify(int index)
        {
            var indv = Individual[index].NewInstance();
            indv.Simplification(null, false);
            return indv.Genotype;
        }
        #endregion
        #region Создание популяции. Свертка                 ***********************************************************************************************************************************************
        private void RecurseFilter()
        {
            for (int cifFiltr = 0; cifFiltr < _selectionConfig.MaxConstantsCount; cifFiltr++)
            {
                var temp = "0";
                for (int i = -1; i < cifFiltr; i++)
                    temp += "+Leaf[" + (i + 1) + "]*Arg[0,n-" + (i + 1) + "]";
                
                Individual[cifFiltr].Genotype = temp;
            }

            for (var rec1Filtr = 0; rec1Filtr < _selectionConfig.MaxConstantsCount - 1; rec1Filtr++)
            {
                string temp = "0";
                for (int i = -1; i < rec1Filtr; i++)
                    temp += "+Leaf[" + (i + 1) + "]*Arg[0,n-" + (i + 1) + "]";
                
                temp += "-Leaf[" + (rec1Filtr + 1) + "]*RecFiltr[n-1]";

                Individual[_selectionConfig.MaxConstantsCount + rec1Filtr].Genotype = temp;
            }

            for (var rec2Filtr = 0; rec2Filtr < _selectionConfig.MaxConstantsCount - 2; rec2Filtr++)
            {
                string temp = "0";
                for (int i = -1; i < rec2Filtr; i++)
                    temp += "+Leaf[" + (i + 1) + "]*Arg[0,n-" + (i + 1) + "]";
                
                temp += "-Leaf[" + (rec2Filtr + 1) + "]*RecFiltr[n-1]";
                temp += "-Leaf[" + (rec2Filtr + 2) + "]*RecFiltr[n-2]";
                Individual[_selectionConfig.MaxConstantsCount + _selectionConfig.MaxConstantsCount - 1 + rec2Filtr].Genotype = temp;
            }
        }
        #endregion
        #region Корзина. Упрощение MathExpressions.NET      ***********************************************************************************************************************************************
        //public string GetPow(string st)
        //{
        //    if (!st.Contains("^"))
        //        return st;
        //
        //    string readyWord = "";
        //    string[] parts = new string[2];
        //    parts[0] = st.Substring(0, st.LastIndexOf('^'));
        //    parts[1] = st.Substring(st.LastIndexOf('^') + 1, st.Length - 1 - parts[0].Length);
        //    string str1 = parts[0];
        //    bool exist = false;
        //    int bropen = 0;
        //    for (int j = str1.Length - 1; j >= 0; j--)
        //    {
        //        if (str1[j].CompareTo(')') == 0) bropen++;
        //        if ((str1[j].CompareTo('-') == 0 || str1[j].CompareTo('*') == 0 || str1[j].CompareTo('+') == 0 ||
        //             str1[j].CompareTo('/') == 0 || str1[j].CompareTo('(') == 0) && bropen < 1)
        //        {
        //
        //            readyWord += str1.Substring(0, j + 1);
        //            readyWord += "Pow(" + str1.Substring(j + 1, str1.Length - 1 - j) + ",";
        //            j = -1;
        //            exist = true;
        //        }
        //        if (j > 0) if (str1[j].CompareTo('(') == 0) bropen--;
        //    }
        //    if (!exist) readyWord += "Pow(" + str1 + ",";
        //    exist = false;
        //    string str = parts[1];
        //    bropen = 0;
        //    for (int j = 0; j < str.Length - 1; j++)
        //    {
        //        //char temp = str[j];
        //        if (str[j].CompareTo('(') == 0) bropen++;
        //        if ((str[j].CompareTo('-') == 0 || str[j].CompareTo('*') == 0 || str[j].CompareTo('+') == 0 ||
        //             str[j].CompareTo('/') == 0 || str[j].CompareTo(')') == 0 || str[j].CompareTo(',') == 0) && (j != 1) && bropen < 1)
        //        {
        //            readyWord += str.Substring(0, j) + ")";
        //            readyWord += str.Substring(j, str.Length - j);
        //            exist = true;
        //            j = str.Length;
        //        }
        //        if (j > 0 && j != str.Length) if (str[j].CompareTo(')') == 0) bropen--;
        //    }
        //    if (!exist) readyWord += str + ")";
        //    readyWord = GetPow(readyWord);
        //    return readyWord;
        //}

        //private string GetAntiPow(string st)
        //{
        //    if (!st.ToLower().Contains("pow") && !st.ToLower().Contains("%"))
        //        return st;
        //
        //    st = st.ToLower().Replace("pow", "%");
        //    string readyWord = st.Substring(0, st.LastIndexOf('%'));
        //    string str1 = st.Substring(st.LastIndexOf('%') + 1, st.Length - 1 - readyWord.Length);
        //    var commaPos = 0;
        //    var wait = 0;
        //    for (var i = 1; i < str1.Length; i++)
        //    {
        //        if (wait >= 0 && str1[i].CompareTo(',') == 0)
        //        {
        //            commaPos = i;
        //            i = str1.Length;
        //        }
        //        else if (str1[i].CompareTo('(')==0)
        //            wait --;
        //        else if (str1[i].CompareTo(')') == 0)
        //            wait++;
        //    }
        //
        //    readyWord += str1.Substring(0, commaPos) + ")^(";
        //    str1 = str1.Substring(commaPos + 1, str1.Length - commaPos - 1);
        //    readyWord += str1;
        //    readyWord = GetAntiPow(readyWord);
        //    return readyWord;
        //}

        //private string GetPrepare(string targer, bool reverse)
        //{
        //    if (reverse)
        //    {
        //        targer = GetPow(targer);
        //        targer = ("0+ " + targer + " ").Replace("(", "( ").Replace(")", " )").Replace(",", ", ").Replace(",", " ,").Replace("-", "- ");                
        //        targer = targer.Replace("pow", "Pow").Replace("sin", "Sin").Replace("cos", "Cos").Replace("tan", "Tan").Replace("log", "Log").Replace("exxp", "Exp");
        //        for (var i = 0; i < MaxLeafs; i++)
        //            targer = targer.Replace(" " + ((char)(97 + i)) + ((char)(97 + i)) + " ", "Leaf[" + i + "]");
        //
        //        for (var i = 0; i < ArgumentsCount; i++)
        //            targer = targer.Replace(" " + (char) (97 + i) + " ", "Arg[" + i + ",n]");
        //    }
        //    else
        //    {
        //        targer = targer.Replace("Exp", "exxp").Replace("0.0001*0.0001", "0.0001");
        //        for (var i = 0; i < MaxLeafs; i++)
        //            targer = targer.Replace("Leaf[" + i + "]", (char)(97 + i) + ((char)(97 + i)).ToString());
        //        
        //        for (var i = 0; i < ArgumentsCount; i++)
        //            targer = targer.Replace("Arg[" + i + ",n]", ((char)(97 + i)).ToString());
        //        
        //        targer = GetAntiPow(targer);
        //    }
        //    return targer.Replace(" ", "").Replace(" ", "");
        //}

        //private void GetSimplified()
        //{
        //    var assembly = new MathFuncAssemblyCecil();
        //    var variable = new VarNode("a".ToLowerInvariant());
        //    if (ConvolutionMode) return;
        //
        //    for (var s = 0; s < PopulationSize; s++)
        //    {                    
        //        if (GenotypeCollections[s].Length > 400)
        //        {
        //            GenotypeCollections[s] = GetNewRandomFunction();
        //            GenotypeCollections[s] = GetPrepare(GenotypeCollections[s], false);
        //        }
        //        else
        //            GenotypeCollections[s] = GetPrepare(GenotypeCollections[s], false);
        //        assembly.Init();
        //
        //        try
        //        {
        //            MathFunc simplifiedFunc = new MathExpressionsNET.MathFunc(GenotypeCollections[s], "a").Simplify();
        //            var rememb = simplifiedFunc.ToString();
        //            GenotypeCollections[s] = simplifiedFunc.GetPrecompilied().ToString();
        //            if (GenotypeCollections[s].Contains("E"))
        //                GenotypeCollections[s] = rememb;
        //            GenotypeCollections[s] = GetPrepare(GenotypeCollections[s], true);
        //        }
        //        catch
        //        {
        //            GenotypeCollections[s] = GetNewRandomFunction();
        //            //GenotypeCollections[2, s] = "0+" + GetLeafs(LeafsCount) + "*Pow(" + GetArgument(MainForm.ArgumentsRows) + "," + GetLeafs(LeafsCount) + ")+" + GetLeafs(LeafsCount) + "*" + GetArgument(MainForm.ArgumentsRows) + "*" + GetLeafs(LeafsCount) + "-" + GetArgument(MainForm.ArgumentsRows) + "/" + GetLeafs(LeafsCount) + "+" + GetLeafs(LeafsCount) + "/Sin(" + GetArgument(MainForm.ArgumentsRows) + ")+" + GetLeafs(LeafsCount) + "*Exp(" + GetArgument(MainForm.ArgumentsRows) + ")";
        //        }
        //        GenotypeCollections[s] = GenotypeCollections[s].Replace("+-", "-").Replace("--", "+");
        //    }
        //}

        //public string GetSimplified(string func)
        //{
        //    func = GetPrepare(func, false);
        //    var assembly = new MathFuncAssemblyCecil();
        //    assembly.Init();
        //    //var variable = new VarNode("a".ToLowerInvariant());
        //    try
        //    {
        //        MathFunc simplifiedFunc = new MathFunc(func, "a").Simplify();
        //        func = simplifiedFunc.GetPrecompilied().ToString();
        //
        //        func = DecimalConverterHlp.ReplaceDecimalToDouble(func);
        //        //if (func.Contains("E")) func = simplifiedFunc.ToString();
        //    }
        //    catch (Exception exp)
        //    {
        //        return func + "\r\n" + exp;
        //    }
        //    func = func.Replace("+-", "-").Replace("--", "+");
        //    return func;
        //}
        #endregion
        #region Корзина. Сортировка                         ***********************************************************************************************************************************************
        //private void QuickSort(string[,] sArr, int first, int last)
        //{
        //    int i = first, j = last;
        //    double x = sArr[0, (first + last) / 2].ToDbl();
        //    do
        //    {
        //        while (sArr[0, i].ToDbl() < x) i++;
        //        while (sArr[0, j].ToDbl() > x) j--;
        //        if (i <= j)
        //        {
        //            if (i < j)
        //            {
        //                SwapString(ref sArr[0, i], ref sArr[0, j]);
        //                SwapString(ref sArr[1, i], ref sArr[1, j]);
        //                SwapString(ref sArr[2, i], ref sArr[2, j]);
        //            }
        //            i++;
        //            j--;
        //        }
        //    } while (i <= j);
        //    if (i < last)
        //        QuickSort(sArr, i, last);
        //    if (first < j)
        //        QuickSort(sArr, first, j);
        //}
        //private void SwapString(ref string arr1, ref string arr2)
        //{
        //    string temp;
        //    temp = arr1;
        //    arr1 = arr2;
        //    arr2 = temp;
        //}
        #endregion
        #region Корзина. Общее                              ***********************************************************************************************************************************************
        //private string GetArgument(int n)
        //{
        //    return "Arg[" + rnd.Next(0, n).ToString() + ",n]";
        //}
        //private string GetLeafs(int n)
        //{
        //    return "Leaf[" + rnd.Next(0, n).ToString() + "]";
        //}
        //private void CreateTournamentFitnessFunction()
        //{
        //    int one;
        //    int two;
        //    QuickSort(GenotypeCollections, 0, PopulationSize);
        //    MediateNumber = 0;
        //    for (int i = 0; i < PopulationSize; i++)
        //    {
        //        if (i < PopulationSize / 2)
        //        {
        //            one = rnd.Next(0, PopulationSize / 2);
        //            two = rnd.Next(0, PopulationSize / 2);
        //            while (one == two) two = rnd.Next(0, PopulationSize / 2);
        //        }
        //        else
        //        {
        //            one = rnd.Next(PopulationSize / 2, PopulationSize);
        //            two = rnd.Next(PopulationSize / 2, PopulationSize);
        //            while (one == two) two = rnd.Next(PopulationSize / 2, PopulationSize);
        //        }
        //        if (MainForm.ConvertToDouble(Result_Deviations[one]) > MainForm.ConvertToDouble(Result_Deviations[two])) MediateCollections[i] = GenotypeCollections[2, two];
        //        else MediateCollections[i] = GenotypeCollections[2, one];
        //        MediateNumber++;
        //    }
        //}
        //private string GetPlaceToChange(string gen)// Сортирует индексы Leaf в возрастающем порядке для ускорения работы алгоритма Н-М
        //{
        //    bool findPlace = false;
        //    for (int i = MaxLeafs - 1; i > 0; i--)
        //    {
        //        if (gen.Contains("Leaf[" + i + "]"))
        //        {
        //            findPlace = false;
        //            for (int j = 0; j < MaxLeafs; j++)
        //            {
        //                if (!gen.Contains("Leaf[" + j + "]") && j < i && findPlace == false)
        //                {
        //                    gen = gen.Replace("Leaf[" + i + "]", "Leaf[" + j + "]");
        //                    findPlace = true;
        //                }
        //            }
        //        }
        //    }
        //    return gen;
        //}
        #endregion
    }
}