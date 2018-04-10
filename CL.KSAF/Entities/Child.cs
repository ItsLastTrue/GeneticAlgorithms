using System.Linq;
using System.Text.RegularExpressions;

namespace CL.KSAF.Entities
{
    public sealed class Child
    {
        private static readonly string LeafPatten = "[Leaf]" + Regex.Escape("[") + "[0-9]+" + Regex.Escape("]");

        public readonly string Genotype;
        public readonly int LeafsCount;

        public Child(string kid, int? leafsCount = null)
        {
            Genotype = kid;
            if (leafsCount != null)
            {
                LeafsCount = (int)leafsCount;
                return;
            }

            Genotype = GetSortedLeafs(Genotype);
            LeafsCount = GetLeafsCount(Genotype);
        }

        public Individual ToIndividual() =>
            new Individual {Genotype = Genotype, LeafsCount = LeafsCount};

        /// <summary>
        /// Сортирует константы в порядке возрастания.
        /// </summary>
        /// <param name="gen"></param>
        /// <param name="startIndex"></param>
        /// <param name="lastIndex"></param>
        /// <remarks>Подготовка к алгоритму Нелдера-Мида</remarks>
        /// <returns></returns>
        private static string GetSortedLeafs(string gen, int startIndex = 0, int lastIndex = 0)//сортирует константы после скрешиваний для улучшения работы АНМ
        {
            if (startIndex == 0) gen = gen.Replace("Leaf", "LF");
            while (gen.Contains("LF["))
            {
                var lf = "LF[" + lastIndex + "]";
                if (gen.Contains(lf))
                {
                    gen = gen.Replace(lf, "Leaf[" + startIndex + "]");
                    gen = GetSortedLeafs(gen, startIndex + 1, lastIndex + 1);
                }
                else
                    gen = GetSortedLeafs(gen, startIndex, lastIndex + 1);
            }
            return gen;
        }

        /// <summary>
        /// Получает количество констант в генотипе.
        /// </summary>
        /// <param name="gen"></param>
        /// <returns></returns>
        private static int GetLeafsCount(string gen) =>
            Regex.Matches(gen, LeafPatten).Cast<Match>().Select(e => Regex.Match(e.Value, "[0-9]+").Value).Distinct().Count();
        
        //{
        //if (!gen.Contains("Leaf[")) return 0;
        //
        //for (var i = 0; i < 100; i++)
        //{
        //    var cut = "Leaf[" + i + "]";
        //    if (gen.Contains(cut))
        //        return 1 + Convert.ToInt32(GetLeafCount(gen.Replace(cut, string.Empty)));
        //
        //}
        //return 0;
        //}
    }
}
