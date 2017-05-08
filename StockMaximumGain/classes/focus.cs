using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace StockMaximumGain.classes
{
    class focus
    {
        public static double threshold = 0.03;//to determine raise or drop, threshold > < 3.5
        public static double reCnt = 12;//to determine raise or drop, threshold > < 3.5
        public enum focusstatus { Raise, Drop, Stay }
        public class FocusCons
        {
            public double degree;
            public focusstatus stat;
            public FocusCons(double degree)
            {
                if(Math.Abs(degree)< threshold) stat = focusstatus.Stay;
                else
                {
                    if(degree>0)
                        stat = focusstatus.Raise;
                    else stat = focusstatus.Drop;
                }
                this.degree = degree;
            }
            public string print()
            {
                return " (" +stat.ToString() +") "+ degree ;
            }
        }
        public static FocusCons getStatus(int stockno)
        {
            DataTable tmp = realtimequote.getStockHistory(stockno);   
            double retVal=0;
            List<double> bl = new List<double>();            
            foreach(DataRow tr in tmp.Rows)
            {
                bl.Add(Convert.ToDouble(tr[6]));
            }
            for(int pvt =0 ; pvt <bl.Count;pvt ++)
            {
                try
                {
                    double v = bl[pvt];
                    double v2 = bl[pvt + 1];
                    retVal += (v - v2)/v2;
                }
                catch (Exception ex)
                { }
            }
            return new FocusCons(retVal);
        }

    }
}
