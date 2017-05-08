using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace StockMaximumGain.classes
{
    class realtimequote
    {
        //<td class="font12_grey">每手股數</td> 
//                                            <td class="font12 R">400</td>

        //http://www.aastocks.com/tc/Stock/BasicQuote.aspx?Symbol=0005
        public static double quote(string no)
        {
            string threeROllrl = "http://hk.finance.yahoo.com/q/hp?s=" + no.ToString().PadLeft(4, '0') + ".HK";
            WebRequest request = HttpWebRequest.Create(threeROllrl);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
                   pattern = "(?<=<span class=\"time_rtq_ticker\">).*?(?=</span>)";//god append                
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            MatchCollection matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
            string lol = "";
            double RSI = 0;
            try
            {
                #region reinitialization   
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    return Convert.ToDouble(lol);
                }
                return -100;
            }
            catch (Exception ex)
            {
                return -100;
            }
        }
        private static string replaceNewline(string s)
        {
            string rq = s.Replace(System.Environment.NewLine, "");
            rq = rq.Replace("\n", "");
            rq = rq.Replace("\r\n", "");
            rq = rq.Replace("\t", "");
            return rq;
        }
        public static DataTable getStockHistory(int sn)
        {
            WebRequest request = null;
            WebResponse response = null;
            Regex regex = null;
            MatchCollection matches;
            StreamReader vr = null;
            string pattern;
            string lol ="";
            string result = "";
            DataTable ret = new DataTable();
            ret.Columns.Add("date");
            ret.Columns.Add("open");
            ret.Columns.Add("highest");
            ret.Columns.Add("lowest");
            ret.Columns.Add("closure");
            ret.Columns.Add("volume");
            ret.Columns.Add("adjusted");
            ret.Columns.Add("uod");
            string threeROllrl = "http://hk.finance.yahoo.com/q/hp?s=" + sn.ToString().PadLeft(4, '0') + ".HK";
            request = HttpWebRequest.Create(threeROllrl);
            response = request.GetResponse();
            vr = new StreamReader(response.GetResponseStream());
            result = vr.ReadToEnd();
            pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(replaceNewline(result)); // 將比對後集合傳給 MatchCollection
            #region got the table
            #region initialization
            DataRow tmp = ret.NewRow();
            #endregion
            foreach (Match match in matches) // 一一取出 MatchCollection 內容
            {
                // 將 Match 內所有值的集合傳給 GroupCollection groups
                GroupCollection groups = match.Groups;
                // 印出 Group 內 word 值
                for (int s = 0; s < groups.Count; s++)
                    lol += groups[s].Value.Trim();
            }
            #region reinitialization
            string extracted = lol;
            //remarks_RB.Text = extracted;
            pattern = "(?<=<tr.*?>).*?(?=</tr>)";//god append                                    
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(replaceNewline(extracted)); // 將比對後集合傳給 MatchCollection                    
            lol = "";
            int cl = 0;
            tmp = ret.NewRow();
            #endregion
            for (int q = 0; q < (matches.Count>focus.reCnt?focus.reCnt:matches.Count)/*matches.Count*/; q++)
//                foreach (Match match in matches) // 一一取出 MatchCollection 內容
            {
                Match match = matches[q];
                    if (match.Length > 0)
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                        {
                            pattern = "(?<=<td.*?>).{1,35}?(?=</td>)";//god append                
                            string extractedrows = lol;
                            //remarks_RB.Text = extracted;
                            //<tr><td class="yfnc_tabledata1" nowrap align="right">2013年4月5日</td>
                            //<td class="yfnc_tabledata1" align="center" colspan="6">1:            10 股票分拆</td></tr><
                            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫                            
                            MatchCollection mat2 = regex.Matches(replaceNewline(groups[s].Value.Trim()));
                            if (mat2.Count > 2)
                            {
                                foreach (Match mat in mat2) // 一一取出 MatchCollection 內容
                                {
                                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                                    GroupCollection gps = mat.Groups;
                                    // 印出 Group 內 word 值
                                    for (int m = 0; m < gps.Count; m++)
                                    {
                                        lol += /*++index + "<:> " + */gps[s].Value.Trim() + " [lol]\n  ";/* + " [" + cl.ToString() + "]"*/
                                    }
                                    if (cl > 5)
                                    {
                                        tmp[cl] = gps[0].Value.Trim();
                                        cl = 0;
                                        ret.Rows.Add(tmp);
                                        tmp = ret.NewRow();
                                        //lol += "\n";
                                    }
                                    else
                                    {
                                        tmp[cl] = gps[0].Value.Trim();
                                        cl++;
                                        //lol += "\t\t";
                                    }
                                }
                            }
                            else cl = 0;
                        }
                        //lol += "\nkai?\n ";
                    }
                    //                        else lol += "\non9\n";
                }
            //   dgv2.DataSource = ret;
            #endregion
            return ret;
        }
        public static double quoteET(string no)
        {
            string threeROllrl = "http://www.etnet.com.hk/www/tc/stocks/realtime/quote.php?code=1299";// "http://www.etnet.com.hk/www/tc/stocks/realtime/quote.php?code=" + no;
            WebRequest request = HttpWebRequest.Create(threeROllrl);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
            pattern = "(?<=<span class=\".{7,15}?\">).*?(?=&nbsp;</span>)";//god append     
            //<span class="Price up2">2.900&nbsp;</span>
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            MatchCollection matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
            string lol = "";
            double RSI = 0;
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    return Convert.ToDouble(lol);
                }
                return -100;
            }
            catch (Exception ex)
            {
                return -100;
            }
        }
        //view-source:http://www.etnet.com.hk/www/tc/stocks/realtime/quote.php?code=323

        public static srcStock AAQuote(string no)
        {
            double price = 0;
            int share = 0;
            string name = "";
            string threeROllrl = "https://www.hkex.com.hk/eng/invest/company/quote_page_e.asp?WidCoID=" + no;          
            WebRequest request = HttpWebRequest.Create(threeROllrl);
        /*    request.Method = "POST";

            string data = "symbol=" + no; //replace <value>
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataStream.Length;  
            Stream newStream = request.GetRequestStream();           
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();*/            
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            result = util.replaceNewline(result);
            string pattern = "";
            Regex regex;
            MatchCollection matches;
            string lol = "";
          /*  string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append     
            //            <ul class="UL1"><li class="LI2 font28 C bold W1"><span class="pos bold">3.930</span></li></ul>

            pattern = "(?<=<ul class=\"UL1\"><li class=\"LI2 font28 C bold W1\"><span class=\".*? bold\">).*?(?=</span></li></ul>)";//god append  
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            MatchCollection matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection
            string lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    price = Convert.ToDouble(lol);
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                //return new srcStock(11,0,"error");
            }*/
            //.{0,600}?
            pattern = "(?<=width=\"61\"><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=\"2\">).*?(?=</font></td>)";//god append              
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection           
            lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    try
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                            lol = groups[s].Value.Trim().Replace(",","");
                        share = Convert.ToInt32(lol);
                    }
                    catch (Exception ex)
                    {
                        //it is lot sizer
                    }
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                String v = ex.Message;
                //return new srcStock(11,0,"error");
            }
            // <font class="font15_white"><b>華電福新&nbsp;00816.HK</b>
            pattern = "(?<=<font class=\"font15_white\"><b>).*?(?=</b>)";//god append              
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection           
            lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    name = lol;
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                String v = ex.Message;
                //return new srcStock(11,0,"error");
            }
            return new srcStock(price, share, name);
        }
        public static srcStock ENAAQuote(string no)
        {
            double price = 0;
            int share = 0;
            string name = "";
            string threeROllrl = "http://www.aastocks.com/en/Stock/BasicQuote.aspx?Symbol=" + no;
            WebRequest request = HttpWebRequest.Create(threeROllrl);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            result = util.replaceNewline(result);
            string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append     
            //            <ul class="UL1"><li class="LI2 font28 C bold W1"><span class="pos bold">3.930</span></li></ul>

            pattern = "(?<=<ul class=\"UL1\"><li class=\"LI2 font28 C bold W1\"><span class=\".*? bold\">).*?(?=</span></li></ul>)";//god append  
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            MatchCollection matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection
            string lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    price = Convert.ToDouble(lol);
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                //return new srcStock(11,0,"error");
            }
            //.{0,600}?
            pattern = "(?<=Lot Size.{0,50}?<td class=\"font12 R\">)[0-9^.]{0,5}?(?=</td>)";//god append              
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection           
            lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    share = Convert.ToInt32(lol);
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                String v = ex.Message;
                //return new srcStock(11,0,"error");
            }
            // <font class="font15_white"><b>華電福新&nbsp;00816.HK</b>
            pattern = "(?<=<font class=\"font15_white\"><b>).*?(?=</b>)";//god append              
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection           
            lol = "";
            try
            {
                #region reinitialization
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    name = lol;
                }
                // return new srcStock(11,0,"error");
            }
            catch (Exception ex)
            {
                String v = ex.Message;
                //return new srcStock(11,0,"error");
            }
            return new srcStock(price, share, name);
        }

    }
    public class srcStock
    {
        public double price;
        public int share;
        public string name;
        public srcStock(double price, int share, string name)
        {
            this.price = price;
            this.share = share;
            this.name = name;
        }
        public srcStock()
        {
        }
    }
}
