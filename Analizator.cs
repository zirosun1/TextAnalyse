using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalyse
{
    public class Analizator
    {
        public static string AnaliseText(string text)
        {
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.Split(' ').Select(x => x.Trim(punctuation));
            List<PairsWordsStrNum> pairs = new List<PairsWordsStrNum>();
            int num = 1;
            foreach (var i in words)
            {
                if (i.Contains("\n")) num++;
                string str = Regex.Replace(i, "[^a-zA-Z]", "");
                pairs.Add(new PairsWordsStrNum(str, num));
            }

            List<PairsWordsStrNum> sortedPairs = SortPairs(pairs);

            var countedPars = sortedPairs
                .GroupBy(x => x.Word)
                                .Select(g => new { Value = g.Key, Count = g.Count(),
                                StrNumber = Counter(sortedPairs,g)

                                });
            StringBuilder sb = new StringBuilder();
            string letter="";

            foreach(var i in countedPars)
            {
                if (i.Value.Substring(0, 1).ToUpper() != letter) sb.AppendLine(i.Value.Substring(0, 1).ToUpper());
                letter = i.Value.Substring(0, 1).ToUpper();
                sb.AppendLine(i.Value+"..................."+i.Count+": "+i.StrNumber);
                //Console.WriteLine("{0}...................{1}: {2}", i.Value, i.Count, i.StrNumber);
            }
            return sb.ToString();
            
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

        private static string Counter(List<PairsWordsStrNum> pairs, IGrouping<string,PairsWordsStrNum> g)
        {
            string strNums="";
            foreach (var s in pairs)
            {
                if (s.Word == g.Key&&strNums.Contains(s.StrNum.ToString())==false) strNums += s.StrNum + " ";
            }
            return strNums;
        }
    }
}
