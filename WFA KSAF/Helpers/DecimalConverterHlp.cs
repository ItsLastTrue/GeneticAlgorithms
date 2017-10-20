using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WFA.KSAF.Helpers
{
    public static class DecimalConverterHlp
    {
        private const string DecimalPattern = "[0-9][.][0-9]+[E][-+]?[0-9]+";

        public static string ReplaceDecimalToDouble(string expression)
        {
            foreach (Match m in Regex.Matches(expression, DecimalPattern))
                if (decimal.TryParse(m.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var dec))
                    expression = expression.Remove(m.Index, m.Length).Insert(m.Index, Convert.ToDouble(dec).ToString(CultureInfo.InvariantCulture));
                else
                throw new Exception($"Error 15471110. Cant parse '{m.Value}' to decimal");
            
            return expression;
        }
    }
}
