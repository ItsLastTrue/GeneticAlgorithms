using System.Diagnostics;

namespace CL.KSAF.Entities
{
    [DebuggerDisplay("Rest: {" + nameof(RestartCounts) + "} Const: {"+ nameof(BestLeafs) + "}")]
    internal struct OptimizationResults
    {
        public int RestartCounts;

        /// <summary>
        /// Последний элемент содержит искомое отклоенение!!!
        /// </summary>
        public double[] BestLeafs;
    }
}