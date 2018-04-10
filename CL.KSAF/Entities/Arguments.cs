using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CL.KSAF.Entities
{
    public sealed class Arguments : IEnumerable<List<double>>
    {
        /// <summary>
        /// Набор исходных точек и значений в них.
        /// </summary>
        private readonly List<List<double>> _arguments;

        /// <summary>
        /// Количество переменных в функции - x,y,z,...;
        /// Ex. F(x,y,z,q) = 4.
        /// </summary>
        public readonly int Rows;

        /// <summary>
        /// Количество точек {[1,3],[3,3],...}.
        /// </summary>
        public readonly int Count;

        public Arguments(int argumentRows, int argumentsCount, List<List<double>> arguments)
        {
            Rows = argumentRows;
            Count = argumentsCount;
            _arguments = arguments;
        }

        /// <summary>
        /// Набор исходных точек и значений в них.
        /// </summary>
        public double this[int row, int n] =>
            _arguments.ElementAt(row).ElementAt(n);

        public IEnumerator<List<double>> GetEnumerator() =>
            _arguments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}