using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Globalization;
using System.Diagnostics;
using StockMaximumGain.classes;
using Amazon.DynamoDBv2.DocumentModel;
using StockMaximumGain.Model;

namespace StockMaximumGain
{
    public partial class enter : Form
    {
        Bridge efDb = new Bridge();
        writelog wl;
        static int rsiindex = 22;
        db ok = new db();
        public enter()
        {
            InitializeComponent();
        }
        protected string ssn(XmlDocument x, string path)
        {
            // TODO: TAS scheme conversion process
            //            XmlNodeList result = x.SelectNodes("/result");
            XmlNode sv = x.SelectSingleNode(path);
            if (sv != null)
                return sv.InnerText;
            else return "";
        }
        private List<String> mSplit(String input, char delimiter)
        {
            int ct = 0;
            List<String> ret = new List<String>();
            String tmp = "";
            Boolean escape = false;
            foreach (Char x in input)
            {
                if (ct != 3)
                {
                    if (!x.Equals(','))
                        tmp += x.ToString();
                    else
                    {
                        ret.Add(tmp);
                        tmp = "";
                        ct++;
                    }
                }
                else
                {
                    if (x.Equals('"') && !escape)
                    {
                        escape = true;
                    }
                    else if (x.Equals('"') && escape)
                    {
                        escape = false;
                    }
                    else
                    {

                        if (escape)
                        {
                            tmp += x.ToString();
                        }
                        else
                        {
                            if (!x.Equals(','))
                                tmp += x.ToString();
                            else
                            {
                                ret.Add(tmp);
                                tmp = "";
                                ct++;
                            }
                        }
                    }
                }
            }
            return ret;
        }
        private void enter_Load(object sender, EventArgs e)
        {
            bg_Init.RunWorkerAsync();
            /*  string x = "Kang Chen <Kang.Chen@wesoft.com>; Kyle Yu <kyle.yu@wesoft.com>; James Li <james.li@wesoft.com>; Kitty Wu <kitty.wu@wesoft.com>; Niya Lu <niya.lu@wesoft.com>";
              string pattern = "(?<=<).*?(?=>)";               
              Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); 
              MatchCollection matches = regex.Matches(util.replaceNewline(x)); 
              List<String> result = new List<String>();
              foreach (Match match in matches) 
              {
                  GroupCollection groups = match.Groups;
                  for (int s = 0; s < groups.Count; s++)
                  {
                      result.Add(groups[s].Value.Trim());
                  }
              }
              foreach(String email in result)
                  MessageBox.Show(email);*/
            /*string x = " adaptability, assertiveness, diligence, efficiency, emotional stability, initiative, motivation, numeracy, patience, responsible, self-learning";
            string[] xx = x.Split(',');
            List<string> m = new List<string>();            
            foreach (string y in xx)
            {
                m.Add(y);
            }
            m.Sort();
            string res = "";
            foreach (string z in m)
            {
                res += z+ ",";

            }
            MessageBox.Show(res);*/
            //  Focus w = new Focus();
            //  w.Show(this);

            /* sym_CB.SelectedIndex = 1;
             int tmp  = 0;
             double mux = 240;
             string x = "";
             while (tmp < 25)
             {
                 tmp++;
                 mux *= 1.2;
                 x += " " + mux;
             }*/
            //   MessageBox.Show(x);
            //    wl= new writelog();
            //   wl.writeentry(0,"bababa");
            //            rc_RT.Text = "一般外圍市況,\n52week高/52week低,\n 派息時間/數量/原因,\n 保力加通道中位線, \n正/負新聞, \n 買前無論如何都GOOGLE一下";
            refreshg1();
            refreshg2();
            addgrid();
        }
        private void addgrid()
        {
            DataTable x = new DataTable();
            x = ok.select("distinct type", "rsi", "", "type");
            List<string> kai = new List<string>();
            foreach (DataRow z in x.Rows)
            {
                kai.Add(z[0].ToString());
            }
            el_CB.DataSource = kai;
        }
        private void stock_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            // stock cb = new stock();
            // cb.ShowDialog(this);

        }
        public void showoff()
        {
            this.Show();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void pattern_Btn_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            pattern cb = new pattern();
            cb.ShowDialog(this);*/
        }

        private void hsipattern_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            hpattern cb = new hpattern();
            cb.ShowDialog(this);
        }

        private double EMA(double price, double ytdema)
        {
            double tmp = 0;
            double k = 2 / (rsiindex + 1);
            tmp = ytdema * (1 - k) + price * k;
            return tmp;
        }
        private void rsi_Btn_Click(object sender, EventArgs e)
        {
            bg1.RunWorkerAsync();
            refreshg2();
        }
        public Boolean stop = false;

        private DataGridView CopyDataGridView(DataGridView dgv_org)
        {
            DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_copy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_org.Columns)
                    {
                        dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_org.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_org.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_org.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_copy.Rows.Add(row);
                }
                dgv_copy.AllowUserToAddRows = false;
                dgv_copy.Refresh();

            }
            catch (Exception ex)
            {
                //  cf.ShowExceptionErrorMsg("Copy DataGridViw", ex);
            }
            return dgv_copy;
        }

        private void fillCounter(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetText(realtimequote.quote(stock_B.Text).ToString());
                if (!stock_B.Text.Equals(""))
                    SetTextB(Convert.ToInt32(new db().powerselect("select sph from rsi where stockno=" + stock_B.Text).Rows[0][0]).ToString());
            }
            catch (Exception ex)
            {
            }
            /*            while (true)
                        {

                            Thread.Sleep(2000);               
                            Process myProcess = new Process();
                            myProcess.StartInfo.UseShellExecute = true;
                            myProcess.StartInfo.FileName = "https://store.apple.com/hk/go/iphone";
                            myProcess.Start();
                        }*/
        }
        private void bgb(object sender, DoWorkEventArgs e)
        {
            db db = new db();
            aws aws = new aws();
            List<rsi> list = efDb.rsi.ToList();
            DataTable tb = db.powerselect("select stockno,sph from rsi order by stockno");
            //            DataGridView tmp = CopyDataGridView(dgv2);
            foreach (rsi item in list)
            {
                int number = 0;
                if (item.sph.HasValue)
                {
                    int curNumber = item.sph.Value;
                    try
                    {
                        //number = realtimequote.AAQuote(item.stockno.ToString()).share;
                        //if (number != curNumber && number > 0)
                        //{
                        //    //db.spowerselect("update rsi set sph = " + number.ToString() + " where stockno =" + x[0].ToString());
                            List<Vp> hmm = new List<Vp>();
                            hmm.Add(new Vp("sph", number));
                            hmm.Add(new Vp("sph2", number));
                           // aws.pullToAWS_ezstockquote(item.stockno, hmm);
                        //    //                        aws.pullToAWS( Convert.ToInt32( x[0].ToString()), number);
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            //foreach (DataRow x in tb.Rows)
            //{
            //    int number = 0;
            //    int curNumber = x[1] != null && x[1].ToString().Length > 0 ? Convert.ToInt32(x[1].ToString()) : 0;
            //    try
            //    {
            //        number = realtimequote.AAQuote(x[0].ToString()).share;
            //        if (number != curNumber && number > 0)
            //        {
            //            db.spowerselect("update rsi set sph = " + number.ToString() + " where stockno =" + x[0].ToString());
            //            List<Vp> hmm = new List<Vp>();
            //            hmm.Add(new Vp("sph", number));
            //            hmm.Add(new Vp("sph2", number));
            //            aws.pullToAWS_ezstockquote(Convert.ToInt32(x[0]), hmm);
            //            //                        aws.pullToAWS( Convert.ToInt32( x[0].ToString()), number);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //}
//            tb = null;
            MessageBox.Show("Work Completed. Refreshing now");
            refreshg1();
            refreshg2();
            addgrid();
        }
        private void bg1_DoWork2(object sender, DoWorkEventArgs e)
        {
            #region
            DataTable trick = ok.select("stockno", "rsi", "ignore=0", "");
            string done = "";
            string notwork = "";
            double no = 1;
            #region AI enchanment
            DataTable AI = null;
            if (ok.select("*", "rsimon", "", "").Rows.Count > 0)
            {
                AI = ok.select("*", "rsimon", "", "");
            }
            #endregion
            foreach (DataRow tutu in trick.Rows)
            {
                int progress = Convert.ToInt16(100 * (no / trick.Rows.Count));
                no++;
                bg1.ReportProgress(progress);
                string lol = "";
                double RSI = 0;
                StreamReader vr = null;
                string result = "";
                WebRequest request = null;
                WebResponse response = null;
                Regex regex = null;
                MatchCollection matches;
                int answer = 0;
                string pattern = "";
                try
                {
                    answer = Convert.ToInt32(tutu[0]);
                    DataTable ret = new DataTable();
                    ret.Columns.Add("date");
                    ret.Columns.Add("open");
                    ret.Columns.Add("highest");
                    ret.Columns.Add("lowest");
                    ret.Columns.Add("closure");
                    ret.Columns.Add("volume");
                    ret.Columns.Add("adjusted");
                    ret.Columns.Add("uod");
                    string threeROllrl = "http://hk.finance.yahoo.com/q/hp?s=" + answer.ToString().PadLeft(4, '0') + ".HK";
                    request = HttpWebRequest.Create(threeROllrl);
                    response = request.GetResponse();
                    vr = new StreamReader(response.GetResponseStream());
                    result = vr.ReadToEnd();
                    pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
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
                    matches = regex.Matches(util.replaceNewline(extracted)); // 將比對後集合傳給 MatchCollection                    
                    lol = "";
                    int cl = 0;
                    tmp = ret.NewRow();
                    #endregion
                    foreach (Match match in matches) // 一一取出 MatchCollection 內容
                    {
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
                                MatchCollection mat2 = regex.Matches(util.replaceNewline(groups[s].Value.Trim()));
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
                    #region updatetable
                    #region AI enhancement
                    if (AI != null)
                    {
                        foreach (DataRow z in AI.Rows)
                        {
                            if (Convert.ToInt32(answer.ToString()) == Convert.ToInt32(z[0].ToString()))
                            {
                                for (int y = 0; y < ret.Rows.Count - 1; y++)
                                {
                                    if (ok.select("*", "rsihistory", "stockno=" + answer.ToString() + " and " + "date=" + ok.seb(Convert.ToDateTime(ret.Rows[y][0]).ToShortDateString()), "").Rows.Count > 0)
                                    {
                                        ok.update_free("rsihistory", new object[] { "open", "highest", "lowest", "close", "volume" }, new object[]
                                        { ret.Rows[y][1].ToString(),
  ret.Rows[y][2].ToString(),
  ret.Rows[y][3].ToString(),
  ret.Rows[y][6].ToString(),
  ret.Rows[y][5].ToString().Replace(",", "")
                                        }
                                        , "stockno=" + answer.ToString() + " and " + "date=" + ok.seb(Convert.ToDateTime(ret.Rows[y][0]).ToShortDateString()));
                                    }
                                    else
                                    {
                                        ok.insert("rsihistory", new object[] { "stockno", "date", "open", "highest", "lowest", "close", "volume" },
                                            new object[]
                                            {
                                                answer.ToString(),
                                                ok.seb(Convert.ToDateTime(ret.Rows[y][0]).ToShortDateString()),
                                                ret.Rows[y][1].ToString(),
                                                ret.Rows[y][2].ToString(),
                                                ret.Rows[y][3].ToString(),
                                                ret.Rows[y][6].ToString(),
                                                ret.Rows[y][5].ToString().Replace(",", "")
                                            }
                                            );
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    for (int y = 0; y < ret.Rows.Count - 1; y++)
                    {
                        try
                        {
                            if (Convert.ToDouble(ret.Rows[y][5]) == 0)
                                ret.Rows[y][7] = 100;
                            else if (Convert.ToDouble(ret.Rows[y][4]) > Convert.ToDouble(ret.Rows[y][1]))//it is pretty defensive
                                ret.Rows[y][7] = 1;
                            else ret.Rows[y][7] = 0;
                        }
                        catch
                        {
                            ret.Rows[y][7] = 1000;//exception
                        }
                    }
                    #endregion
                    #region calculate RSI
                    double uptrend = getEMA(ret, 1);
                    double downtrend = getEMA(ret, 0);
                    double RS = 0;

                    RS = (rsiindex * uptrend) / (rsiindex * downtrend);
                    RSI = 100 - (100 / (1 + RS));
                    if (uptrend == 0 && downtrend == 0) RSI = 0;
                }
                catch (Exception ex)
                {
                    notwork += answer + "\t";
                }
                try
                {
                    #region other way round
                    string peurl = "http://hk.finance.yahoo.com/q?s=" + answer.ToString().PadLeft(4, '0') + "&ql=1";
                    request = HttpWebRequest.Create(peurl);
                    response = request.GetResponse();
                    vr = new StreamReader(response.GetResponseStream());
                    result = vr.ReadToEnd();
                    // "(?<=<td class=\"yfnc_tabledata1\".*?\">).*?(?=</td>)"
                    pattern = "(?<=股利與收益率:.*?<td.*?>).*?(?=</td>)";//god append                
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection
                    string pe = "";
                    string ii = "";
                    double volume = 0;
                    lol = "";
                    foreach (Match match in matches) // 一一取出 MatchCollection 內容
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                            lol += groups[s].Value.Trim();
                    }
                    ii = lol;
                    lol = "";
                    pattern = "(?<=\\>成交量:.*?<td.*?><span>)[^B.]*?(?=</span></td>)";
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                    foreach (Match match in matches) // 一一取出 MatchCollection 內容
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                            lol += groups[s].Value.Trim();

                        //                lol+= ++index + ": " + groups["word"].Value.Trim();
                    }
                    volume = Convert.ToDouble(lol.Replace(",", ""));

                    lol = "";
                    pattern = "(?<=P/E.*?<td.*?>).{0,8}?(?=</td>)";//god append  
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                    foreach (Match match in matches) // 一一取出 MatchCollection 內容
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                            lol += groups[s].Value.Trim();
                        break;
                        //                lol+= ++index + ": " + groups["word"].Value.Trim();
                    }
                    pe = lol;

                    #endregion

                    ok.update("rsi", new object[] { "rsi", "date", "volume", "PE", "ii" }, new object[] { RSI, "'" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "'", volume, "'" + pe + "'", "'" + ii + "'" }, "stockno", answer.ToString());
                    #region AI enhancement
                    if (AI != null)
                    {
                        foreach (DataRow t2 in AI.Rows)
                        {
                            if (Convert.ToInt32(answer.ToString()) == Convert.ToInt32(t2[0].ToString()))
                            {
                                if (ok.powerselect("select * from rsihistory where date = " + ok.seb(DateTime.Now.ToShortDateString()) + " and stockno=" + answer.ToString()).Rows.Count == 0)
                                    ok.insert("rsihistory", new object[] { "date", "stockno", "rsi" }, new object[] { ok.seb(DateTime.Now.ToShortDateString()), answer.ToString(), RSI });
                                else
                                    ok.update_free("rsihistory", new object[] { "rsi" }, new object[] { RSI }, "date = " + ok.seb(DateTime.Now.ToShortDateString()) + " and stockno=" + answer.ToString());
                            }
                        }
                    }
                    #endregion
                    #endregion
                    done += answer + "\t";
                }
                catch (Exception ex)
                {
                    notwork += answer + "\t";
                }
            }
            MessageBox.Show(notwork);
            #endregion
        }

        private void bg1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
        }
        private double getEMA(DataTable ret, int upordown) //1 is up, 0 is down
        {
            double UTyema = 0;
            List<int> sri = new List<int>();
            int t = 0;
            int rownumber = 0;
            foreach (DataRow j in ret.Rows)
            {
                if (t > rsiindex) break;
                if (Convert.ToInt16(j[7]) == upordown)
                {
                    sri.Add(t);
                    UTyema += Convert.ToDouble(j[4]);
                }
                t++;
                rownumber++;
            }
            UTyema /= rsiindex;
            string lol = "";
            foreach (int j in sri) lol += j.ToString() + "\n";
            for (int j = sri.Count - 1; j >= 0; j--)
            {
                double price = Convert.ToDouble(ret.Rows[sri[j]][4]);
                UTyema = EMA(price, UTyema);
                //                tmp43+=(sri[j].ToString()+" "+(Convert.ToDouble(ret.Rows[sri[j]][4])).ToString())+"\n";
            }
            return UTyema;
        }
        public void q1stock(int stockno)
        {
            string done = "";
            string notwork = "";
            if (stock_B.Text.Equals(""))
            {
                MessageBox.Show("not found");
                return;
            }
            int answer = stockno;//Convert.ToInt32(stock_B.Text);
            DataTable ret = new DataTable();
            ret.Columns.Add("date");
            ret.Columns.Add("open");
            ret.Columns.Add("highest");
            ret.Columns.Add("lowest");
            ret.Columns.Add("closure");
            ret.Columns.Add("volume");
            ret.Columns.Add("adjusted");
            ret.Columns.Add("uod");
            string threeROllrl = "http://hk.finance.yahoo.com/q/hp?s=" + answer.ToString().PadLeft(4, '0') + ".HK";
            WebRequest request = HttpWebRequest.Create(threeROllrl);
            WebResponse response = request.GetResponse();
            StreamReader vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
                                                                                           //                   pattern = "(?<=<span class=\"time_rtq_ticker\">).*?(?=</span>)";//god append                
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            MatchCollection matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
            string lol = "";
            double RSI = 0;
            try
            {
                #region got the table
                #region reinitialization
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
                pattern = "(?<=<tr.*?>).*?(?=</tr>)";//god append                
                string extracted = lol;
                remarks_RB.Text = extracted;
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(util.replaceNewline(extracted)); // 將比對後集合傳給 MatchCollection                    
                lol = "";
                int cl = 0;
                tmp = ret.NewRow();
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    if (match.Length > 0)
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                        {
                            pattern = "(?<=<td.*?>).{1,35}?(?=</td>)";//god append                
                            string extractedrows = lol;
                            remarks_RB.Text = extracted;
                            //<tr><td class="yfnc_tabledata1" nowrap align="right">2013年4月5日</td>
                            //<td class="yfnc_tabledata1" align="center" colspan="6">1:            10 股票分拆</td></tr><
                            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫                            
                            MatchCollection mat2 = regex.Matches(util.replaceNewline(groups[s].Value.Trim()));
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
                dgv2.DataSource = ret;
                #endregion
                #region updatetable
                for (int y = 0; y < ret.Rows.Count - 1; y++)
                {
                    try
                    {
                        if (Convert.ToDouble(ret.Rows[y][5]) == 0)
                            ret.Rows[y][7] = 100;
                        else if (Convert.ToDouble(ret.Rows[y][4]) > Convert.ToDouble(ret.Rows[y][1]))//it is pretty defensive
                            ret.Rows[y][7] = 1;
                        else ret.Rows[y][7] = 0;
                    }
                    catch
                    {
                        ret.Rows[y][7] = 1000;//exception
                    }
                }
                #endregion
                #region calculate RSI
                double uptrend = getEMA(ret, 1);
                double downtrend = getEMA(ret, 0);
                double RS = 0;
                RS = (rsiindex * uptrend) / (rsiindex * downtrend);
                RSI = 100 - (100 / (1 + RS));
                if (uptrend == 0 && downtrend == 0) RSI = 0;


            }
            catch (Exception ex)
            {
                // notwork += answer + "\t";
                MessageBox.Show(threeROllrl + " is not worked." + ex.Message);
            }
            try
            {
                #region other way round
                string peurl = "http://hk.finance.yahoo.com/q?s=" + answer.ToString().PadLeft(4, '0') + "&ql=1";
                request = HttpWebRequest.Create(peurl);
                response = request.GetResponse();
                vr = new StreamReader(response.GetResponseStream());
                result = vr.ReadToEnd();
                // "(?<=<td class=\"yfnc_tabledata1\".*?\">).*?(?=</td>)"
                pattern = "(?<=股利與收益率:.*?<td.*?>).*?(?=</td>)";//god append                
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(result); // 將比對後集合傳給 MatchCollection
                string pe = "";
                string ii = "";
                double volume = 0;
                lol = "";
                double infl = 0;
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                }
                ii = lol;
                lol = "";
                pattern = "(?<=\\>成交量:.*?<td.*?><span>)[^B.]*?(?=</span></td>)";
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();

                    //                lol+= ++index + ": " + groups["word"].Value.Trim();
                }
                volume = Convert.ToDouble(lol.Replace(",", ""));

                lol = "";
                pattern = "(?<=P/E.*?<td.*?>).{0,8}?(?=</td>)";//god append  
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    break;
                    //                lol+= ++index + ": " + groups["word"].Value.Trim();
                }
                pe = lol;


                lol = "";
                pattern = "(?<=P/E.*?<td.*?>).{0,8}?(?=</td>)";//god append  
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    break;
                    //                lol+= ++index + ": " + groups["word"].Value.Trim();
                }
                pe = lol;

                lol = "";
                pattern = "(?<=前收市價.*?<td.*?>).{0,8}?(?=</td>)";//god append  
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(result); // 將比對後集合傳給 MatchCollectio
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    for (int s = 0; s < groups.Count; s++)
                        lol += groups[s].Value.Trim();
                    break;
                    //                lol+= ++index + ": " + groups["word"].Value.Trim();
                }
                infl = Convert.ToDouble(lol) * volume;
                #endregion

                ok.update("rsi", new object[] { "rsi", "date", "volume", "PE", "ii", "infl" }, new object[] { RSI, "'" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "'", volume, "'" + pe + "'", "'" + ii + "'", "'" + infl + "'" }, "stockno", answer.ToString());

                #endregion
                done += answer + "\t";
                //MessageBox.Show(RSI.ToString());

            }
            catch (Exception ex)
            {
                // notwork += answer + "\t";
                MessageBox.Show(threeROllrl + " is not worked." + ex.Message);
            }
            //}
        }
        private void gethsi()
        {
            foreach (DataRow tmplistitem in ok.select("*", "indexlist", "indexname = 'hsi'", "").Rows)
            {
                string done = "";
                string notwork = "";
                DataTable ret = new DataTable();
                ret.Columns.Add("date");
                ret.Columns.Add("open");
                ret.Columns.Add("highest");
                ret.Columns.Add("lowest");
                ret.Columns.Add("closure");
                ret.Columns.Add("volume");
                ret.Columns.Add("adjusted");
                ret.Columns.Add("uod");
                string threeROllrl = tmplistitem[0].ToString(); //usa
                WebRequest request = HttpWebRequest.Create(threeROllrl);
                WebResponse response = request.GetResponse();
                StreamReader vr = new StreamReader(response.GetResponseStream());
                string result = vr.ReadToEnd();
                string pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                MatchCollection matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
                string lol = "";
                double RSI = 0;
                #region got the table
                #region reinitialization
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
                pattern = "(?<=<tr.*?>).*?(?=</tr>)";//god append                
                string extracted = lol;
                remarks_RB.Text = extracted;
                regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                matches = regex.Matches(util.replaceNewline(extracted)); // 將比對後集合傳給 MatchCollection                    
                lol = "";
                int cl = 0;
                tmp = ret.NewRow();
                #endregion
                foreach (Match match in matches) // 一一取出 MatchCollection 內容
                {
                    if (match.Length > 0)
                    {
                        // 將 Match 內所有值的集合傳給 GroupCollection groups
                        GroupCollection groups = match.Groups;
                        // 印出 Group 內 word 值
                        for (int s = 0; s < groups.Count; s++)
                        {
                            pattern = "(?<=<td.*?>).{1,35}?(?=</td>)";//god append                
                            string extractedrows = lol;
                            remarks_RB.Text = extracted;
                            //<tr><td class="yfnc_tabledata1" nowrap align="right">2013年4月5日</td>
                            //<td class="yfnc_tabledata1" align="center" colspan="6">1:            10 股票分拆</td></tr><
                            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫                            
                            MatchCollection mat2 = regex.Matches(util.replaceNewline(groups[s].Value.Trim()));
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
                #endregion
                foreach (DataRow tmprow in ret.Rows)
                {
                    if (ok.select("date", tmplistitem[1].ToString(), "date=" + ok.seb(Convert.ToDateTime(tmprow[0].ToString()).ToShortDateString()), "").Rows.Count > 0)
                    {
                        ok.update_free(tmplistitem[1].ToString(), new object[] { "open", "highest", "lowest", "closeure", "volume" }, new object[]
                        {Convert.ToDouble(tmprow[1]).ToString(),
                            Convert.ToDouble(tmprow[2]).ToString(),
                            Convert.ToDouble(tmprow[3]).ToString(),
                            Convert.ToDouble(tmprow[4]).ToString(),
                            Convert.ToDouble(tmprow[5]).ToString()
                        }, "date =" + ok.seb(Convert.ToDateTime(tmprow[0]).ToShortDateString()));
                    }
                    else
                    {
                        ok.insert(tmplistitem[1].ToString(), new object[] { "date", "open", "highest", "lowest", "closeure", "volume" }, new object[] {
                            ok.seb( Convert.ToDateTime(tmprow[0]).ToShortDateString()),
                            Convert.ToDouble(tmprow[1]).ToString(),
                            Convert.ToDouble(tmprow[2]).ToString(),
                            Convert.ToDouble(tmprow[3]).ToString(),
                            Convert.ToDouble(tmprow[4]).ToString(),
                            Convert.ToDouble(tmprow[5]).ToString()
                        });
                    }
                }
                // dgv2.DataSource = ret;
            }

        }
        private void srsi_B_Click(object sender, EventArgs e)
        {
            //gethsi();
            //return;
            if (!stock_B.Text.Equals(""))
                q1stock(Convert.ToInt32(stock_B.Text));
        }

        private void ignore_Btn_Click(object sender, EventArgs e)
        {
            ok.update("rsi", new object[] { "ignore" }, new object[] { '1' }, "stockno", stock_B.Text);
            refreshg2();
        }

        private void revive_Btn_Click(object sender, EventArgs e)
        {
            string g = type_B.Text;
            for (int xx = 0; xx < dgv2.Rows.Count - 1; xx++)
            {
                if (dgv2.Rows[xx].Cells[2].Value.ToString().Equals(g))
                {
                    dgv2.Sort(dgv2.Columns["type"], ListSortDirection.Descending);
                    dgv2.CurrentCell = dgv2.Rows[xx].Cells[2];
                    break;
                }
            }
            DataTable x = ok.select("stockno", "rsi", "type='" + type_B.Text + "'", "");
            foreach (DataRow v in x.Rows)
            {
                string stockno = v[0].ToString();
                double Num = 0;
                if (Double.TryParse(stockno, out Num))
                {
                    //System.Diagnostics.Process.Start("http://www.aastocks.com/tc/stock/detailchart.aspx?symbol=" + stockno + "#GTop");
                    System.Diagnostics.Process.Start("http://money18.on.cc/info/liveinfo_quote.html?symbol=" + stockno);
                    Thread.Sleep(400);
                    //                    string datefrom = DateTime.Now.AddMonths(-12).Year.ToString() + DateTime.Now.AddMonths(-12).Month.ToString().PadLeft(2, '0') + DateTime.Now.AddMonths(-12).Day.ToString().PadLeft(2, '0');
                    //                    string dateto = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                    //                    System.Diagnostics.Process.Start("http://corpsv.etnet.com.hk/webservice/jsp/ETNET/DIV-ANNOUNCE/BIG5/SearchResult.jsp?SORT=CODE&TO=" + dateto + "&ENCODING=BIG5&ANNOUNCETYPE=D&STOCKCODE=" + stockno + "&MAINTYPE=DIVANNOUNCE&FROM=" + datefrom + "&INDUSTRY=&SUBTYPE=SEARCH&CLIENT=ETNET");
                }
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            promptNet();
        }

        private void pe_Btn_Click(object sender, EventArgs e)
        {
            ok.insert("remarks", new object[] { "date", "remarks", "removestamp" }, new object[] { "'" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "'", "'" + remarks_RB.Text + "'", "'" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "'" });
            refreshg1();

        }
        private void refreshg2()
        {
            try
            {
                dgv2.DataSource = ok.select("stockno as 股號,name,type,rsi,volume,ii as '股利' ,pe as 'P/E', infl as 'Influence(萬)', sph", "rsi", "(ignore is null OR ignore<>1) and sph>0", "rsi desc");
                foreach (DataGridViewColumn g in dgv2.Columns)
                {
                    if (g.Name.Equals("name")) g.Width = 110;
                    else if (g.Name.Equals("volume")) g.Width = 110;
                    else if (g.Name.Equals("rsi")) g.Width = 100;
                    else if (g.Name.Equals("Influence(萬)")) g.Width = 100;
                    else
                        g.Width = 70;
                }
            }
            catch (Exception ex)
            { }
        }
        private void refreshg1()
        {
            try
            {
                dgv1.DataSource = dgv1.DataSource = ok.select("*", "remarks", "", "date desc");
            }
            catch (Exception ex)
            {
            }
        }

        private void stock_B_TextChanged(object sender, EventArgs e)
        {
            string g = stock_B.Text;
            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                if (dgv2.Rows[x].Cells[0].Value.ToString().Equals(g))
                {
                    dgv2.CurrentCell = dgv2.Rows[x].Cells[0];
                    type_B.Text = dgv2.Rows[x].Cells[2].Value.ToString();
                    return;
                }
            }
        }
        private Boolean isNumeric(string k)
        {
            double outnum = 0;
            bool isNum = double.TryParse(k, out outnum);
            if (isNum)

                return true;
            else
                return false;
        }
        private void promptNet(string x)
        {

            double Num = 0;
            if (Double.TryParse(x.ToString(), out Num))
            {
                //                        if (MessageBox.Show("Edit the remarks now?","Hello", MessageBoxButtons.YesNo) == DialogResult.No)
                //                        {
                System.Diagnostics.Process.Start("http://www.sl886.com/p/stock?c=" + x.ToString());
                Thread.Sleep(400);
                System.Diagnostics.Process.Start("http://money18.on.cc/info/liveinfo_quote.html?symbol=" + x.ToString());
                string datefrom = DateTime.Now.AddMonths(-12).Year.ToString() + DateTime.Now.AddMonths(-12).Month.ToString().PadLeft(2, '0') + DateTime.Now.AddMonths(-12).Day.ToString().PadLeft(2, '0');
                string dateto = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                System.Diagnostics.Process.Start("http://corpsv.etnet.com.hk/webservice/jsp/ETNET/DIV-ANNOUNCE/BIG5/SearchResult.jsp?SORT=CODE&TO=" + dateto + "&ENCODING=BIG5&ANNOUNCETYPE=D&STOCKCODE=" + x.ToString() + "&MAINTYPE=DIVANNOUNCE&FROM=" + datefrom + "&INDUSTRY=&SUBTYPE=SEARCH&CLIENT=ETNET");
                System.Diagnostics.Process.Start("http://www.aastocks.com/tc/stock/detailchart.aspx?symbol=" + x.ToString() + "#GTop");
                /*                        }
                                        else
                                        {
                                            stockremarks sr = new stockremarks(Convert.ToInt32(g.Value.ToString()));
                                            sr.Show();
                                        }*/
            }
        }
        private void promptNet()
        {
            DataGridViewSelectedCellCollection x = dgv2.SelectedCells;
            foreach (DataGridViewCell g in x)
            {
                double Num = 0;
                if (Double.TryParse(g.Value.ToString(), out Num) && g.ColumnIndex == 0)
                {
                    //                        if (MessageBox.Show("Edit the remarks now?","Hello", MessageBoxButtons.YesNo) == DialogResult.No)
                    //                        {
                    System.Diagnostics.Process.Start("http://www.sl886.com/p/stock?c=" + g.Value.ToString());
                    Thread.Sleep(400);
                    System.Diagnostics.Process.Start("http://money18.on.cc/info/liveinfo_quote.html?symbol=" + g.Value.ToString());
                    string datefrom = DateTime.Now.AddMonths(-12).Year.ToString() + DateTime.Now.AddMonths(-12).Month.ToString().PadLeft(2, '0') + DateTime.Now.AddMonths(-12).Day.ToString().PadLeft(2, '0');
                    string dateto = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                    System.Diagnostics.Process.Start("http://corpsv.etnet.com.hk/webservice/jsp/ETNET/DIV-ANNOUNCE/BIG5/SearchResult.jsp?SORT=CODE&TO=" + dateto + "&ENCODING=BIG5&ANNOUNCETYPE=D&STOCKCODE=" + g.Value.ToString() + "&MAINTYPE=DIVANNOUNCE&FROM=" + datefrom + "&INDUSTRY=&SUBTYPE=SEARCH&CLIENT=ETNET");
                    System.Diagnostics.Process.Start("http://www.aastocks.com/tc/stock/detailchart.aspx?symbol=" + g.Value.ToString() + "#GTop");
                    /*                        }
                                            else
                                            {
                                                stockremarks sr = new stockremarks(Convert.ToInt32(g.Value.ToString()));
                                                sr.Show();
                                            }*/
                }
            }
        }
        private void stock_B_KeyDown(object sender, KeyEventArgs e)
        {
            string g = stock_B.Text;
            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                if (dgv2.Rows[x].Cells[0].Value.ToString().Equals(g))
                {
                    dgv2.CurrentCell = dgv2.Rows[x].Cells[0];
                    type_B.Text = dgv2.Rows[x].Cells[2].Value.ToString();
                    break;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dbt = db.spowerselect("select COUNT(1) from rsi where stockno  = " + stock_B.Text);
                if (Convert.ToInt16(dbt.Rows[0][0]) == 0)
                {
                    db.spowerselect("insert into rsi (name,stockno) VALUES ('" + stock_B.Text + "'," + stock_B.Text + ")");
                    bgbb.RunWorkerAsync();
                }
                promptNet(stock_B.Text);
            }
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection x = dgv1.SelectedCells;
                foreach (DataGridViewCell g in x)
                {
                    if (g.ColumnIndex == 2 && isNumeric(g.Value.ToString()))
                    {
                        if (MessageBox.Show("Remove remarks:" + g.Value.ToString() + "?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ok.delete("remarks", new string[] { "removestamp" }, new string[] { g.Value.ToString() });
                            refreshg1();
                        }
                    }
                    else
                    {
                        remarks_RB.Text = g.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void udv_Btn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection x = dgv1.SelectedCells;
            foreach (DataGridViewCell g in x)
            {
                DataGridViewCell qdc = dgv1.Rows[g.RowIndex].Cells[2];
                if (isNumeric(qdc.Value.ToString()))
                {
                    ok.update("remarks", new object[] { "date", "remarks" }, new object[] { "'" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "'", "'" + remarks_RB.Text + "'" }, "removestamp", qdc.Value.ToString());
                    refreshg1();
                }
            }
        }

        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            refreshg1();
            refreshg2();
            addgrid();
        }

        private void type_B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok.update("rsi", new object[] { "type" }, new object[] { "'" + type_B.Text + "'" }, "stockno", stock_B.Text);
                refreshg2();
            }

        }

        private void type_B_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchType_Btn_Click(object sender, EventArgs e)
        {
            string g = type_B.Text;
            dgv2.Sort(dgv2.Columns["type"], ListSortDirection.Descending);
            for (int xx = 0; xx < dgv2.Rows.Count - 1; xx++)
            {
                if (dgv2.Rows[xx].Cells[2].Value.ToString().Equals(g))
                {
                    dgv2.CurrentCell = dgv2.Rows[xx].Cells[2];
                    break;
                }
            }
        }

        private void ans_Btn_Click(object sender, EventArgs e)
        {
            StreamReader vr = null;
            WebRequest request = null;
            WebResponse response = null;
            Regex regex = null;
            MatchCollection matches;
            string threeROllrl = "http://www.etnet.com.hk/www/tc/stocks/ci_ipo.php";
            request = HttpWebRequest.Create(threeROllrl);
            response = request.GetResponse();
            vr = new StreamReader(response.GetResponseStream());
            string result = vr.ReadToEnd();
            ///pattern = "(?<=調整後的收市價\\*.*?</th></tr>).*?(?=\\* <small>收市價已按股息和拆細而調整)";//god append                
            //remarks_RB.Text = result;
            string pattern = "(?<=即將上市資訊.{0,1000}?入場費</td></tr>).*?(?=</table></div><!-- END_NEW_IPO -->)";//god append                
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(util.replaceNewline(result)); // 將比對後集合傳給 MatchCollection
            string wiw = "";
            foreach (Match match in matches) // 一一取出 MatchCollection 內容
            {
                // 將 Match 內所有值的集合傳給 GroupCollection groups
                GroupCollection groups = match.Groups;
                // 印出 Group 內 word 值
                for (int s = 0; s < groups.Count; s++)
                    wiw += groups[s].Value.Trim();
            }
            pattern = "(?<=<tr .{5,20}?\">).{0,650}?(?=</tr>)";
            regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
            matches = regex.Matches(util.replaceNewline(wiw)); // 將比對後集合傳給 MatchCollection
            string log = "";
            string dmasql = "-----------------Report-----------------\n";
            foreach (Match match in matches) // fetch the table by tr
            {
                string stockno = "";
                string stockname = "";
                GroupCollection groups = match.Groups;
                for (int s = 0; s < groups.Count; s++) // fetch the table by tr
                {
                    string wiw2 = groups[s].Value.Trim();
                    pattern = "(?<=<td><a href.{0,80}?\">).{0,10}?(?=</a></td>)";
                    regex = new Regex(pattern, RegexOptions.IgnoreCase); // 宣告 Regex 忽略大小寫
                    MatchCollection matches2;
                    matches2 = regex.Matches(util.replaceNewline(wiw2)); // 將比對後集合傳給 MatchCollection
                    foreach (Match match2 in matches2) // 一一取出 MatchCollection 內容
                    {
                        #region fetch StockNo and Name
                        GroupCollection groups2 = match2.Groups;
                        for (int b = 0; b < groups2.Count; b++)
                        {
                            try
                            {
                                stockno = Convert.ToInt32(groups2[b].Value.Trim()).ToString();
                                stockname = Convert.ToInt32(groups2[b].Value.Trim()).ToString();
                            }
                            catch (Exception ex)
                            {
                                stockname = groups2[b].Value.Trim();
                            }
                        }
                        #endregion
                    }
                    #region add stock
                    if (!stockno.Equals(""))
                    {
                        db ok = new db();
                        DataTable r = ok.select("stockno", "rsi", "stockno =" + stockno, "");
                        if (r.Rows.Count == 0)
                        {
                            ok.insert("rsi", new object[] { "stockno", "name" }, new object[] { stockno, "'" + stockname + "'" });
                            //                        x.q1stock(Convert.ToInt32(stockno));
                            log += "New stock is created with stockno:" + stockno + " and name:" + stockname + "\n";
                        }
                        else
                        {
                            log += stockno + ":" + stockname + " is exist.\n";
                            dmasql += "select * from rsi where stockno =" + ok.seb(stockno) + "\n";
                        }

                    }
                    #endregion
                }
            }
            if (!log.Equals(""))
                MessageBox.Show(log);
            if (!dmasql.Equals("")) MessageBox.Show(dmasql);

            return;
            //XmlDocument res = new XmlDocument();
            //res.LoadXml(ss);           
            New_Stock cb = new New_Stock();
            cb.ShowDialog(this);
        }

        private void el_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_B.Text = el_CB.Text;
        }

        private void trend_Btn_Click(object sender, EventArgs e)
        {
            trend sr = new trend();
            sr.Show();
        }

        private void moc_Btn_Click(object sender, EventArgs e)
        {
            pattern x = null;
            try
            {
                x = new pattern(Convert.ToInt32(stock_B.Text));

            }
            catch (Exception ex)
            {
                x = new pattern(17);
            }
            x.ShowDialog(this);

        }

        private void stock_B_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                moc_Btn_Click(sender, e);
            }
            if (((Keys)e.KeyChar) == Keys.R)
            {
                stockremarks sr = new stockremarks(Convert.ToInt32(stock_B.Text));
                sr.Show();
                e.Handled = true;
            }
        }

        private void hsi_Btn_Click(object sender, EventArgs e)
        {
            hsi s = new hsi();
            s.ShowDialog(this);
        }

        private void ml_Btn_Click(object sender, EventArgs e)
        {
            machinelearning x = new machinelearning();
            x.Show(this);
        }

        private void hsbc_Btn_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://www.ebanking.hsbc.com.hk/1/2/logon?LANGTAG=en&COUNTRYTAG=US&fbc=HomeEngLeftMenu");
        }

        private void zzBtn_Click(object sender, EventArgs e)
        {
            Boolean findres = true;
            /* try{
             foreach (DataGridViewRow x in dgv2.Rows)                
             {
                 if (x.Cells[0].Value.ToString().Equals(stock_B.Text))
                 {
                     quan = Convert.ToDouble(x.Cells[8].Value.ToString());
                     findres= true;
                     break;
                 }
             }
             }
             catch(Exception ex) {MessageBox.Show("Cannot parse the quantity");}*/
            if (!findres) return;
            try
            {
                double pi = Convert.ToDouble(pi_B.Text);
                int share = Convert.ToInt32(si_B.Text);
                int lot = Convert.ToInt32(li_B.Text);
                ci_B.Text = stock.buy(pi, share, lot).ToString();
            }
            catch (Exception ex)
            {
                ci_B.Text = "N/A";
                findres = false;
            }

            try
            {
                double po = Convert.ToDouble(po_B.Text);
                int share = Convert.ToInt32(so_B.Text);
                int lot = Convert.ToInt32(lo_B.Text);
                co_B.Text = stock.sell(po, share, lot).ToString();
            }
            catch (Exception ex)
            {
                co_B.Text = "N/A";
                findres = false;
            }
            if (findres)
            {
                double vrse = Convert.ToDouble(co_B.Text) - Convert.ToDouble(ci_B.Text);
                calR_B.Text = vrse.ToString();
                if (vrse > 0) calR_B.BackColor = Color.Green;
                else calR_B.BackColor = Color.Gray;
            }
            /**/
        }

        private void v1v2_cal(object sender, EventArgs e)
        {
            if (v1_B.Text.Equals("") || v2_B.Text.Equals("")) return;
            switch (sym_CB.SelectedIndex)
            {
                case 0:
                    res_L.Text = (Convert.ToDouble(v1_B.Text) + Convert.ToDouble(v2_B.Text)).ToString();
                    break;
                case 1:
                    res_L.Text = (Convert.ToDouble(v1_B.Text) - Convert.ToDouble(v2_B.Text)).ToString();
                    break;

            }
        }

        private void dgv2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
                db.spowerselect("update rsi set sph = " + (dgv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("") ? "null" : dgv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) + " where stockno =" + dgv2.Rows[e.RowIndex].Cells[0].Value);
            else if (e.ColumnIndex == 1)
                db.spowerselect("update rsi set name = " + db.sseb(dgv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) + " where stockno =" + dgv2.Rows[e.RowIndex].Cells[0].Value);

        }

        private void hi_B_TextChanged(object sender, EventArgs e)
        {
            so_B.Text = si_B.Text;
        }

        private void pi_B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (po_B.Text.Equals("") || Convert.ToDouble(po_B.Text) < Convert.ToDouble(pi_B.Text))
                    po_B.Text = pi_B.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void stock_B_Leave(object sender, EventArgs e)
        {
            stop = !stop;
            try
            {
                bg1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
            }
        }
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pi_B.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.pi_B.Text = text;
            }
        }
        delegate void SetTextCallbackB(string text);
        private void SetTextB(string share)
        {
            if (this.si_B.InvokeRequired)
            {
                SetTextCallbackB d = new SetTextCallbackB(SetTextB);
                this.Invoke(d, new object[] { share.ToString() });
            }
            else
            {
                this.si_B.Text = share.ToString();
            }
        }

        private void jpmorgan_Btn_Click(object sender, EventArgs e)
        {
            DataTable tmp3 = quotebroker.quote(StockMaximumGain.classes.quotebroker.Brokername.JPMorgan);
            promptBrokerChoices(tmp3);
            dgv1.DataSource = tmp3;
        }

        private void blackrock_Btn_Click(object sender, EventArgs e)
        {
            DataTable tmp3 = quotebroker.quote(StockMaximumGain.classes.quotebroker.Brokername.BlackRock);
            promptBrokerChoices(tmp3);
            dgv1.DataSource = tmp3;
        }

        private void ubs_btn_Click(object sender, EventArgs e)
        {
            DataTable tmp3 = quotebroker.quote(StockMaximumGain.classes.quotebroker.Brokername.MorganStanley);
            promptBrokerChoices(tmp3);
            dgv1.DataSource = tmp3;
        }
        private void promptBrokerChoices(DataTable tmp3)
        {
            Boolean found = false;
            int initDay = -8;
            do
            {
                foreach (DataRow x in tmp3.Rows)
                {
                    if (DateTime.Now.AddDays(initDay) < Convert.ToDateTime(x[1]))
                    {
                        System.Diagnostics.Process.Start("http://www.sl886.com/p/stockshareholder?c=" + x[0].ToString());
                        found = true;
                    }
                }
                initDay--;
            } while (!found);
        }

        private void ci_B_TextChanged(object sender, EventArgs e)
        {

        }

        private void li_B_TextChanged(object sender, EventArgs e)
        {
            lo_B.Text = li_B.Text;
        }

        private void waterlevel_btn_Click(object sender, EventArgs e)
        {
            Waterlevel x = new Waterlevel();
            x.ShowDialog(this);

        }

        private void on9_btn_Click(object sender, EventArgs e)
        {
            on9 x = null;
            x = new on9();
            x.ShowDialog(this);
        }

        private void fillshare_Btn_Click(object sender, EventArgs e)
        {
            //support amazon dynamodb
            try
            {
                bgbb.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void remark_GB_Enter(object sender, EventArgs e)
        {

        }

        private void focus_Btn_Click(object sender, EventArgs e)
        {
            Focus w = new Focus();
            w.Show(this);
        }

        private void bg_Init_DoWork(object sender, DoWorkEventArgs e)
        {
            stock.PushToDBFromHKEX(this);
            refreshg1();
            refreshg2();
            addgrid();
            writeToTextbox("All");
        }
        delegate void UpdateLabel(string result);
        //...
        public void writeToTextbox(string fCounter)
        {
            if (this.InvokeRequired)
            {
                UpdateLabel textWriter = new UpdateLabel(writeToTextbox);
                this.Invoke(textWriter, new object[] { fCounter });
            }
            else
            {
                result_L.Text = string.Format("{0} : Done", fCounter);
            }
        }
    }
}
