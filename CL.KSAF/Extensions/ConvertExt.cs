using System;
using System.Collections.Generic;
using System.Globalization;
using CL.KSAF.ExpressionParser;

namespace CL.KSAF.Extensions
{
    public static class ConvertExt
    {
        public static string ToStr(this object o) =>
            o.ToString();

        public static IntCounter ToIntCounter(this int str) =>
            new IntCounter(str);

        public static TreeNode FindByID(this List<TreeNode> list, int id)
        {
            foreach (var element in list)
            {
                if (element.ID == id)
                    return element;

                if (element.Child.Count > 0)
                {
                    var node = element.Child.FindByID(id);
                    if (node != null)
                        return node;
                }
            }
            return null;
        }

        public static double ToDbl(this object x)
        {
            if (x == null) return 0.0;
            var str = x.ToStr();
            if (double.TryParse(str, out var d))
                return d;

            if (double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out var di))
                return di;

            //if (double.TryParse(str, NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out var de))
            //    return de;

            throw new ArgumentException($"Error 8230609. Can't parse '{x}' to double");
        }

        public static string ToStrRound(this double number, int capacity = 3) =>
            Math.Round(number, capacity).ToString(CultureInfo.InvariantCulture).Replace(',', '.');

        public static double ToDblSlow(this object x)
        {
            double temp;
            try
            {
                temp = Convert.ToDouble(x);
            }
            catch
            {
                try
                {
                    temp = Convert.ToDouble(x.ToString().Replace(",", "."));
                }
                catch
                {
                    temp = Convert.ToDouble(x.ToString().Replace(".", ","));
                }
            }
            return temp;
        }


        //public static double ToDbl(this object x)
        //{
        //    var temp = 0.0;
        //
        //    try
        //    {
        //        temp = Convert.ToDouble(x);
        //    }
        //    catch
        //    {
        //        if (string.IsNullOrEmpty(x.ToString())) return 0;
        //        var str = x.ToString().Replace(" ", "");
        //        try
        //        {
        //            temp = Convert.ToDouble(str.Replace(",", "."));
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                temp = Convert.ToDouble(str.Replace(".", ","));
        //            }
        //            catch { return temp; }
        //        }
        //    }
        //    return temp;
        //}
    }
}
