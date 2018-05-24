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
            var words = from str in text.Split(new Char[] { ' ', ',', '.', ':', '\t' })
                                 orderby str
                                 select str;
            foreach (var i in words) Console.WriteLine(i);
        }
    }
}
