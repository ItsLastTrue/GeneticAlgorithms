namespace CL.KSAF.ExpressionParser
{
    public enum MathType
    {
        /// <summary>
        /// Мат операторы высшего приоритета '/','*'.
        /// </summary>
        HightPrtOperator,

        /// <summary>
        /// Мат операторы низкого приоритета '+','-'.
        /// </summary>
        LowPrtOperator,

        /// <summary>
        /// Запятая ','.
        /// </summary>
        Comma,

        /// <summary>
        /// Мат функции содержащие 1 входящий параметр 'Sin', 'Cos', 'Tan', 'Exp'.
        /// </summary>
        EasyFunction,

        /// <summary>
        /// Мат функции содержащие несколько параметров 'Pow', 'Log'.
        /// </summary>
        MultiFunction,

        /// <summary>
        /// Узел верхнего уровня в древе.
        /// </summary>
        Home,

        /// <summary>
        /// Константа Leaf[n].
        /// </summary>
        Constant,

        /// <summary>
        /// Переменная Arg[x].
        /// </summary>
        Argument,
    }

    public static class MathTypeHlp
    {
        public static MathType GetNodeType(string word)
        {
            //                                                         "|+", "|-", "~*", "~/", " ,", "~Pow", "~Log", "~Sin", "~Cos", "~Tan", "~Exp" };
            if (word[0] == '~' || word[0] == '|' || word[0] == ' ')
            {
                switch (word[1])
                {
                    case ',':
                        return MathType.Comma;

                    case '+':
                    case '-':
                        return MathType.LowPrtOperator;

                    case '/':
                    case '*':
                        return MathType.HightPrtOperator;
                }
            }

            if (word.Length > 2)
            {
                switch (word.Substring(0, 3))
                {
                    case "Sin":
                    case "Cos":
                    case "Tan":
                    case "Exp":
                        return MathType.EasyFunction;

                    case "Pow":
                    case "Log":
                        return MathType.MultiFunction;
                }
            }

            return word.Contains("Arg") ? MathType.Argument : MathType.Constant;
        }
    }
}
