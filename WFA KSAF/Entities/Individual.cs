using System.Diagnostics;
using System.Globalization;
using WFA.KSAF.ExpressionParser;

namespace WFA.KSAF.Entities
{
    [DebuggerDisplay("G=>{" + nameof(Genotype) + "}")]
    public sealed class Individual
    {
        public string Genotype;
        public int LeafsCount;

        public SurvivalCoefficient SurvivalRate;

        public Individual NewInstance() =>
            new Individual
            {
                LeafsCount = LeafsCount,
                SurvivalRate = SurvivalRate,
                Genotype = Genotype,
            };

        public void Simplification(Log? log = null, bool swapConstantsToLeaf = true)
        {
            if (LeafsCount > 0)
            {
                for (var i = 0; i < LeafsCount; i++)
                    Genotype = Genotype.Replace("Leaf[" + i + "]", SurvivalRate.Constants[i].ToString(CultureInfo.InvariantCulture));

                Genotype = Genotype.Replace("+-", "-").Replace("--", "+");
            }
            var synanthicTree = new TreeParser(Genotype);
            synanthicTree.Parse();
            synanthicTree.Simplification();
            if (swapConstantsToLeaf)
                SurvivalRate.Constants = synanthicTree.ChangeConstantsToLeaf();
            LeafsCount = SurvivalRate.Constants.Length;
            string simlificated = synanthicTree.ReparseTree();
            Genotype = simlificated;

            if (log == null) return;
            ((Log)log).Simplification.Add(":Gen: " + Genotype);
            ((Log)log).Simplification.Add(":End: " + Genotype);
        }

        public struct SurvivalCoefficient
        {
            public double[] Constants;
            public double Deviations;
            public int NelMidRestarts;
        }
    }
}
