using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyse
{
    class PairsWordsStrNum
    {
        public PairsWordsStrNum(string str,int num)
        {
            Word = str;
            StrNum = num;
        }
        public string Word { get; set; }
        public int StrNum { get; set; }
    }
}
