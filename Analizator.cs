using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyse
{
    public class Analizator
    {
        public static void AnaliseText(string text)
        {
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.Split(' ').Select(x => x.Trim(punctuation));
            List<PairsWordsStrNum> pairs = new List<PairsWordsStrNum>();
            int num = 1;
            foreach (var i in words)
            {
                if (i.Contains("\n")) num++;
                pairs.Add(new PairsWordsStrNum(i, num));
            }
            List<PairsWordsStrNum> sortedPairs = SortPairs(pairs);

            var countedPars = sortedPairs
                .GroupBy(x => x.Word)
                
                                .Select(g => new { Value = g.Key, Count = g.Count() });

            foreach(var i in countedPars) Console.WriteLine("{0}, {1}", i.Value, i.Count);
            //foreach (var i in sortedPairs) Console.WriteLine("{0}, {1}", i.Word, i.StrNum);
        }

        private static List<PairsWordsStrNum> SortPairs(List<PairsWordsStrNum> pairs)
            {
            List<PairsWordsStrNum> list = pairs;
            list.Sort((PairsWordsStrNum x, PairsWordsStrNum y) =>
            {
                return x.Word.CompareTo(y.Word);
            });
            return list;


        }
    }
}
