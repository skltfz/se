using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace StockMaximumGain.classes
{
    class quotebroker
    {
        public enum Brokername { BlackRock, JPMorgan, UBS, MorganStanley };
        public static DataTable quote(Brokername brokername)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Stock");
            dt.Columns.Add("Date");
            string threeROllrl = "";
            switch (brokername)
            {
                case Brokername.BlackRock:
                    threeROllrl = "http://www.sl886.com/%E8%82%A1%E6%9D%B1/Blackrock,%20Inc?sp=stock";
                    break;
                case Brokername.UBS:
                    threeROllrl = "http://www.sl886.com/%E8%82%A1%E6%9D%B1/UBS%20AG?sp=stock";
                    break;
                case Brokername.MorganStanley:
                    threeROllrl = "http://www.sl886.com/%E8%82%A1%E6%9D%B1/Morgan%20Stanley";
                    break;
                default:
                    threeROllrl = "http://www.sl886.com/%E8%82%A1%E6%9D%B1/JPMorgan%20Chase%20Co?sp=stock";
                    break;
            }
            WebRequest request = HttpWebRequest.Create(threeROllrl);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            string pattern = "(?<=<table class=\"listtable\" >).*?(?=</table>)";//god append                
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
                }
                String trimmedTable = lol;

                //Next step
                pattern = "(?<=<tr><tr>).*?(?=</tr></tr>)";//god append                
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(util.replaceNewline(trimmedTable)); // 將比對後集合傳給 MatchCollection
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                    {
                        lol = groups[s].Value.Trim();
                        pattern = "(?<=<td>).{3,9}[0-9](?=</td>)";//god append                
                        regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                        MatchCollection matches2 = regex.Matches(util.replaceNewline(lol)); // 將比對後集合傳給 MatchCollection
                        DataRow nr = dt.NewRow();
                        try
                        {

                            int piv = 0;
                            foreach (Match match2 in matches2) // 一一取出 MatchCollection 內容
                            {
                                // 將 Match 內所有值的集合傳給 GroupCollection groups
                                GroupCollection groups2 = match2.Groups;
                                // 印出 Group 內 word 值
                                for (int ss = 0; ss < groups2.Count; ss++)
                                {
                                    String tmp = groups2[ss].Value.Trim();
                                    nr[piv++] = tmp;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            String what = ex.Message;
                        }
                        dt.Rows.Add(nr);
                    }
                }
                dt.DefaultView.Sort = "date" + " " + "desc";
                dt = dt.DefaultView.ToTable();
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
    public class QuoteUpdate
    {
        public class Stock
        {
            public int stockNo { get; set; }
            public string name { get; set; }
            public int spn { get; set; }
        }
        public static List<Stock> Fetch()
        {

            List<Stock> list = new List<Stock>();
            string URL = "https://www.hkex.com.hk/eng/market/sec_tradinfo/stockcode/eisdeqty.htm";

            WebRequest request = HttpWebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            string pattern = "(?<=<table class=\"table_grey_border\" width=\"100%\" cellspacing=\"2\" cellpadding=\"0\">).*?(?=</table>)";//god append                
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
                    pattern = "(?<=<tr class=\"tr_normal\">).*?(?=</tr>)";
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    MatchCollection matches_sub = regex.Matches(util.replaceNewline(match.Value)); // 將比對後集合傳給 MatchCollection
                    foreach (Match match_sub in matches_sub) // 一一取出 MatchCollection 內容
                    {
                        pattern = "(?<=<td .{10,35}?\">).*?(?=</td>)";
                        regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                        MatchCollection matches_td = regex.Matches(util.replaceNewline(match_sub.Value)); // 將比對後集合傳給 MatchCollection
                        Stock s = new Stock();
                        int val = -1;
                        for (int v = 0; v < 3; v++)
                        {
                            switch (v)
                            {
                                case 0:
                                    if (int.TryParse(matches_td[v].Value, out val))
                                        s.stockNo = val;
                                    break;
                                case 1:
                                    HtmlDocument doc = new HtmlDocument();
                                    doc.LoadHtml(matches_td[v].Value);
                                    s.name = System.Web.HttpUtility.HtmlDecode(doc.DocumentNode.InnerText);
                                    break;
                                case 2:
                                    if (int.TryParse(matches_td[v].Value.Replace(",", ""), out val))
                                        s.spn = val;
                                    break;

                            }

                        }
                        list.Add(s);
                        //foreach ( Match match_td in matches_td) // 一一取出 MatchCollection 內容
                        //{
                        //}
                    }

                    //for (int s = 0; s < groups.Count; s++)
                    //lol += groups[s].Value.Trim();
                }
                //String trimmedTable = lol;

                ////Next step
                //pattern = "(?<=<tr><tr>).*?(?=</tr></tr>)";//god append                
                //regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                //matches = regex.Matches(util.replaceNewline(trimmedTable)); // 將比對後集合傳給 MatchCollection
                //foreach (Match match in matches) // 一一取出 MatchCollection 內容
                //{
                //    // 將 Match 內所有值的集合傳給 GroupCollection groups
                //    GroupCollection groups = match.Groups;
                //    // 印出 Group 內 word 值
                //    for (int s = 0; s < groups.Count; s++)
                //    {
                //        lol = groups[s].Value.Trim();
                //        pattern = "(?<=<td>).{3,9}[0-9](?=</td>)";//god append                
                //        regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                //        MatchCollection matches2 = regex.Matches(util.replaceNewline(lol)); // 將比對後集合傳給 MatchCollection
                //        Stock item = new Stock();
                //        try
                //        {

                //            int piv = 0;
                //            foreach (Match match2 in matches2) // 一一取出 MatchCollection 內容
                //            {
                //                // 將 Match 內所有值的集合傳給 GroupCollection groups
                //                GroupCollection groups2 = match2.Groups;
                //                // 印出 Group 內 word 值
                //                for (int ss = 0; ss < groups2.Count; ss++)
                //                {
                //                    String tmp = groups2[ss].Value.Trim();
                //                    //nr[piv++] = tmp;
                //                }
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            String what = ex.Message;
                //        }
                //        list.Add(item);
                //    }
                //}
                //dt.DefaultView.Sort = "date" + " " + "desc";
                //dt = dt.DefaultView.ToTable();
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
    }
}
