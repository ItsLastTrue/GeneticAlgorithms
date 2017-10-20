using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WFA.KSAF.ExpressionParser;
using WFA.KSAF.Extensions;
using WFA.KSAF.Generated;

namespace WFA.KSAF.Forms
{
    public partial class FormTests : Form
    {
        public FormTests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                var input = "2.2512867321E-02+15*Exp(1,2)";
                var pattern = "[0-9][.][0-9]+[E][-+]?[0-9]+";
                var output = Regex.Replace(input, pattern, "__");
                foreach (Match m in Regex.Matches(input, pattern))
                {
                    if (decimal.TryParse(m.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var dec))
                        input = input.Remove(m.Index, m.Length).Insert(m.Index, Convert.ToDouble(dec).ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = "2.2512867321E-02+15*Exp(1,2)";
            for (var i = 0; i < 15; i++)
                input += input;
            DateTime startTime;
            TimeSpan sbTime;
            {
                startTime = DateTime.Now;
                for (var i = 0; i < 1_000; i++)
                {
                    var sb = new StringBuilder(input);
                    var output = sb.Replace("2.2512867321E-02", "__");
                }
                sbTime = startTime - DateTime.Now;
            }

            TimeSpan regexpTime;
            {
                startTime = DateTime.Now;
                for (var i = 0; i < 1_000; i++)
                {
                    var stringS = input;
                    var pattern = "[0-9][.][0-9]+[E][-+]?[0-9]+";
                    var output = Regex.Replace(stringS, pattern, "__");
                }
                regexpTime = startTime - DateTime.Now;
            }

            TimeSpan stringTime;
            {
                startTime = DateTime.Now;
                for (var i = 0; i < 1_000; i++)
                {
                    var stringS = input;
                    var output = stringS.Replace("2.2512867321E-02", "__");
                }
                stringTime = startTime - DateTime.Now;
            }

            labelReplaceResults.Text = $@"sb: {sbTime}; rg: {regexpTime}; str {stringTime} ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var leafs = new[] {5.1254, 424421.21, 45484484848.213232132131, 45111.231241, 11111,2131387612638712.32131231412};

            var expression =
                "0+Leaf[2]*Cos(Leaf[1]-Arg[0,n]/Leaf[0])+Leaf[2]-Cos(Exp(Arg[0,n])*Leaf[0]-Exp(Cos(Arg[0,n]-Pow(Arg[0,n]/Leaf[0]*Arg[0,n]/Cos(0.0001)," +
                "Cos(Leaf[2]*Arg[0,n]-Cos(Cos(Cos(Cos(Arg[0,n]-Cos(Arg[0,n]/Cos(Leaf[2]+Arg[0,n]+Cos(Arg[0,n])))-Leaf[0]))-Cos(Arg[0,n]/Cos(Leaf[2]+Arg[0,n]" +
                "+Cos(Arg[0,n]))))/Leaf[4]*Arg[0,n]-Cos(Cos(Arg[0,n]-Sin(Arg[0,n]/Leaf[1]))-Cos(Leaf[2]-Cos(Cos(Cos(Cos(Arg[0,n]-Sin(Arg[0,n]/Leaf[1]))-Cos(Arg[0,n])))" +
                "*0.0001*Sin(Arg[0,n])-Exp(Cos(Leaf[0]-Leaf[0])))))*Cos(Leaf[1]*Exp(Cos(Leaf[3]-Leaf[1]*Cos(Pow(Leaf[2],Arg[0,n])-Arg[0,n]/Cos(Cos(Leaf[2]*Arg[0,n]+Leaf[0]))" +
                "-Tan(Arg[0,n]))/Leaf[1]*Leaf[5]-Arg[0,n]/Leaf[2])))+Arg[0,n]/Cos(Arg[0,n])+Arg[0,n]+Leaf[0])))-Leaf[0])))";
            Reader();


            var est = new Estimator();
            var comlpRes = 0.0;
            for (var i = 0; i < 100; i++)
                comlpRes+= est.DeviationCollections(leafs, 0);

            var leafExpress = expression;
            //for (var i=0;i<leafs.Length;i++)
            //    leafExpress = leafExpress.Replace($"Leaf[{i}]", leafs[i].ToString(CultureInfo.InvariantCulture));

            var tree = new TreeParser(leafExpress, leafs);
            tree.Parse();
            tree.Estimate(Arg, leafs);

        }

        //private double Deviate(string genotype)
        //{
        //    var dev = 0.0;
        //    for (var i = 0; i < PointsCount; i++)
        //    {
        //        var expr = genotype;
        //        for (var n = 0; n < 2; n++)
        //        {
        //            expr = expr.Replace($"Leaf[{n}]", Arg[n, i].ToString(CultureInfo.InvariantCulture));
        //        }
        //
        //    }
        //    return dev;
        //}

        private static int PointsCount = 41;

        private List<List<double>> Arg;
        private void Reader()
        {
            Arg = new List<List<double>>
            {
                new List<double> { 20, 4400 },
                new List<double> { 19, 3500 },
                new List<double> { 18, 2716 },
                new List<double> { 17, 2042 },
                new List<double> { 16, 1472 },
                new List<double> { 15, 1000 },
                new List<double> { 14, 620 },
                new List<double> { 13, 326 },
                new List<double> { 12, 112 },
                new List<double> { 11, -28 },
                new List<double> { 10, -100 },
                new List<double> { 9, -110 },
                new List<double> { 8, -64 },
                new List<double> { 7, 32 },
                new List<double> { 6, 172 },
                new List<double> { 5, 350 },
                new List<double> { 4, 560 },
                new List<double> { 3, 796 },
                new List<double> { 2, 1052 },
                new List<double> { 1, 1322 },
                new List<double> { 0, 1600 },
                new List<double> { -1, 1880 },
                new List<double> { -2, 2156 },
                new List<double> { -3, 2422 },
                new List<double> { -4, 2672 },
                new List<double> { -5, 2900 },
                new List<double> { -6, 3100 },
                new List<double> { -7, 3266 },
                new List<double> { -8, 3392 },
                new List<double> { -9, 3472 },
                new List<double> { -10, 3500 },
                new List<double> { -11, 3470 },
                new List<double> { -12, 3376 },
                new List<double> { -13, 3212 },
                new List<double> { -14, 2972 },
                new List<double> { -15, 2650 },
                new List<double> { -16, 2240 },
                new List<double> { -17, 1736 },
                new List<double> { -18, 1132 },
                new List<double> { -19, 422 },
                new List<double> { -20, -400 },

            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reader();
            var leafs = new[] {12.0, 5.0, 4.0, 3.0 };
            var expression = "0-12+Cos(4-1.570796327*4)*3";
            var leafExpression = "0-Leaf[0]+Sin(Leaf[1]-1.570796327*Leaf[2])*Leaf[3]";


            var tree = new TreeParser(leafExpression, leafs);
            tree.Parse();
            tree.Estimate(Arg, leafs);
        }
    }
}