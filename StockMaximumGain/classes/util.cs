using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMaximumGain.classes
{
    class util
    {
        public static string replaceNewline(string s)
        {
            string rq = s.Replace(System.Environment.NewLine, "");
            rq = rq.Replace("\n", "");
            rq = rq.Replace("\r\n", "");
            rq = rq.Replace("\t", "");
            return rq;
        }    
    }
}
