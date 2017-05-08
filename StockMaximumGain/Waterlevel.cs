using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using StockMaximumGain.classes;

namespace StockMaximumGain
{
    public partial class Waterlevel : Form
    {
        private static List<stock> stocklist = new List<stock>();
        private static DataTable allstock;
        private db ok = new db();
        public class tpac // o-i/i,  volume/sph
        {
            public double io,vsp;
            public tpac(double a, double b)
            {
                this.io = a; 
                this.vsp = b;
            }
            override
            public string ToString()
            {
                return io+"," + vsp;
            }
        }
        private class stock
        {
            public string stockno;
            public string sph;
            public List<tpac> turbulents = new List<tpac>();
            //formula: up/down/volume?
            public stock (string stockno,string sph)
            {
                this.stockno = stockno;
                this.sph = sph;
            }
            public void push(tpac value)
            {
                turbulents.Add(value);
            }
            public string pt()
            {
                string ret= "";
                foreach(tpac x in turbulents)
                {
                    ret += x.ToString() + " \t";
                }
                return ret;
            }
            public double avgt()
            {
                double total = 0;

                foreach (tpac x in turbulents)
                {
                    total += x.io;
                }
                return total / double.Parse(turbulents.Count.ToString());
            }
            public double avgsv()
            {
                double total = 0;

                foreach (tpac x in turbulents)
                {
                    total += x.vsp;
                }
                return total / double.Parse(turbulents.Count.ToString());
            }
        }
        public Waterlevel()
        {
            InitializeComponent();
        }
        public void updateSN(Boolean isdec)
        {
            if (isdec) sn_L.Text = (Convert.ToInt16(sn_L.Text) - 1).ToString();
            else sn_L.Text = (Convert.ToInt16(sn_L.Text) + 1).ToString();
        }
        private void Waterlevel_Load(object sender, EventArgs e)
        {
            allstock = ok.powerselect("select stockno,sph from rsi where sph>0");
            sn_L.Text = allstock.Rows.Count.ToString();
            progressBar1.Maximum = allstock.Rows.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            bgw1.RunWorkerAsync();
        }
        delegate void SetBarCallBack(int text);
        delegate void SetTextCallback(string text);
        delegate void SetDataGridViewCallback(DataTable x);

        private void SetDataGridView(DataTable x)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.sn_L.InvokeRequired)
            {
                SetDataGridViewCallback d = new SetDataGridViewCallback(SetDataGridView);
                this.Invoke(d, new object[] { x });
            }
            else
            {
                this.dataGridView1.DataSource = x;
            }
        }
        private void SetBar(int text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.sn_L.InvokeRequired)
            {
                SetBarCallBack d = new SetBarCallBack(SetBar);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                progressBar1.Value += 1;
            }
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.sn_L.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.sn_L.Text = text;
            }
        }
        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DataRow stock in allstock.Rows)
            {
                #region fetchtable
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
                    answer = Convert.ToInt32(stock[0].ToString());
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
                    pattern = "(?<=<tr.*?>).*?(?=</tr>)";//god append                              ingg      
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
                    DataTable ret2 = new DataTable();
                    ret2.Columns.Add("date");
                    ret2.Columns.Add("stockno");
                    ret2.Columns.Add("rsi");
                    ret2.Columns.Add("open");
                    ret2.Columns.Add("close");
                    ret2.Columns.Add("highest");
                    ret2.Columns.Add("lowest");
                    ret2.Columns.Add("volume");
                    ret2.Columns.Add("o-i/i%");
                    ret2.Columns.Add("v/sph%");
                    double sph = Convert.ToDouble(stock[1]);
                    stock tmpstock = new stock(stock[0].ToString(), stock[1].ToString());
                    for (int z = (ret.Rows.Count < 32 ? ret.Rows.Count-1 : 32); z >= 0; z--)//ret.Rows.Count - 1
                    {
                        /*DataRow ret2tmprow = ret2.NewRow();
                        ret2tmprow["stockno"] = stock[0];
                        ret2tmprow["date"] = ret.Rows[z]["date"];
                        ret2tmprow["open"] = ret.Rows[z]["open"];
                        ret2tmprow["close"] = ret.Rows[z]["adjusted"];
                        ret2tmprow["highest"] = ret.Rows[z]["highest"];
                        ret2tmprow["lowest"] = ret.Rows[z]["lowest"];
                        ret2tmprow["volume"] = ret.Rows[z]["volume"];                        
                        ret2tmprow["o-i/i%"] =( Math.Abs( Convert.ToDouble(ret.Rows[z]["adjusted"]) - Convert.ToDouble(ret.Rows[z]["open"]) ))/ Convert.ToDouble(ret.Rows[z]["open"]);
                        ret2tmprow["v/sph%"] = Convert.ToDouble(ret.Rows[z]["volume"].ToString())/sph;*/
                        tmpstock.push(new tpac((Math.Abs(Convert.ToDouble(ret.Rows[z]["adjusted"]) - Convert.ToDouble(ret.Rows[z]["open"])))
                            , Convert.ToDouble(ret.Rows[z]["volume"].ToString()) / sph));
//                        ret2.Rows.Add(ret2tmprow);                        
                    }
                    stocklist.Add(tmpstock);
                    SetText((Convert.ToInt32(sn_L.Text) -1).ToString());
                    SetBar(1);
 //                   SetDataGridView(ret2);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    #endregion
                #endregion               
               // break;

            }            
        }
        private void io_Btn_Click(object sender, EventArgs e)
        {
            stocklist = stocklist.OrderByDescending(o => o.avgt()).ToList();
            double mavg = 0;
            string sn = "";
            string op = "";
            foreach (stock tt in stocklist)
            {
                op += tt.stockno + " : " + tt.avgt() + "\n";
            }
            MessageBox.Show(op);
        }

        private void vsp_Btn_Click(object sender, EventArgs e)
        {
            stocklist = stocklist.OrderByDescending(o => o.avgsv()).ToList();
            double mavg = 0;
            string sn = "";
            string op = "";
            foreach (stock tt in stocklist)
            {
                op += tt.stockno + " : " + tt.avgsv() + "\n";
            }
            MessageBox.Show(op);
        }
    }
}
