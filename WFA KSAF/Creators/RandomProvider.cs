using System;

namespace WFA.KSAF.Creators
{
    public sealed class RandomProvider
    {
        private readonly string[] _operators;
        private readonly int _maxLeafs;
        private readonly int _maxArguments;
        private readonly Random _rnd = new Random();

        public int Next(int minValue, int maxValue) =>
            _rnd.Next(minValue, maxValue);

        public RandomProvider(string[] operators,int maxLeafs, int maxArguments)
        {
            _operators = operators;
            _maxLeafs = maxLeafs;
            _maxArguments = maxArguments;
        }

        public string GetNewRandomFunction()
        {
            var func = "0+";
            func += GetNewRandomMathFunction() + _operators[_rnd.Next(0, 4)] + GetNewRandomMathFunction() + _operators[_rnd.Next(0, 4)] + GetNewRandomMathFunction();
            return func;
        }

        public string GetNewRandomMathFunction()
        {
            string func = "";
            int operat = _rnd.Next(6, 12);
            func += _operators[operat] + "(" + GetArgumentOrLeaf();
            if (operat < 8)
                func += "," + GetArgumentOrLeaf();
            func += ")";

            return func;
        }

        private string GetArgumentOrLeaf() =>
            _rnd.Next(0, 2) == 0 ? "Arg[" + _rnd.Next(0, _maxArguments) + ",n]" : "Leaf[" + _rnd.Next(0, _maxLeafs) + "]";
    }
}
