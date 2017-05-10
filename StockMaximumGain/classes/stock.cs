using StockMaximumGain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMaximumGain.classes
{
    class stock
    {
        public static void PushToDBFromHKEX(StockMaximumGain.enter me)
        {
            aws aws = new aws();

            Bridge db = new Bridge();
            List<QuoteUpdate.Stock> list = QuoteUpdate.Fetch();
            foreach (QuoteUpdate.Stock item in list)
            {
                try
                {
                    if (db.rsi.Any(x => x.stockno.Equals(item.stockNo)))
                    {
                        rsi tar = db.rsi.FirstOrDefault(x => x.stockno == item.stockNo);
                        tar.name = item.name;
                        tar.sph = item.spn;
                        db.SaveChanges();

                    }
                    else
                    {
                        rsi s = new rsi();
                        s.name = item.name;
                        s.sph = item.spn;
                        s.stockno = item.stockNo;
                        db.rsi.Add(s);
                        db.SaveChanges();
                    }
                    //AWS
                    List<Vp> hmm = new List<Vp>();
                    hmm.Add(new Vp("sph", item.spn));
                    hmm.Add(new Vp("sph2", item.spn));
                    aws.pullToAWS_ezstockquote(me,item.stockNo, hmm);
                    me.writeToTextbox(item.name);
                }
                catch (Exception ex)
                {
                }

            }

        }
        public static double buy(double value, int share, int lot)
        {
            double p_duel = 0.25; //it is vary between different bank
            double p_gov = 0.1;
            double p_sfc = 0.0027;
            double p_hkse = 0.005;
            double result = (double)0;
            double baseVal = value * share * lot;
            double hsbc_duel = (baseVal * (p_duel / 100)) > 100 ? (baseVal * (0.25 / 100)) : 100;
            double govsfchkseAMP = (p_gov + p_sfc + p_hkse) / 100;
            double si = lot > 6 ? lot * 5 : 30;
            result = baseVal + (baseVal * (govsfchkseAMP)) + hsbc_duel + si;
            return result;
        }
        public static double sell(double value, int share, int lot)
        {
            double p_duel = 0.25; //it is vary between different bank
            double p_gov = 0.1;
            double p_sfc = 0.0027;
            double p_hkse = 0.005;
            double result = (double)0;
            double baseVal = value * share * lot;
            double hsbc_duel = (baseVal * (p_duel / 100)) > 100 ? (baseVal * (0.25 / 100)) : 100;
            double govsfchkseAMP = (p_gov + p_sfc + p_hkse) / 100;
            result = baseVal - (baseVal * (govsfchkseAMP)) - hsbc_duel;
            return result;
        }
    }
}
