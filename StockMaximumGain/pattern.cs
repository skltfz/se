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
using StockMaximumGain.classes;
namespace StockMaximumGain
{
    public partial class pattern : Form
    {        
        DataTable hisData = null;
             
        db ok = new db();
        enter x;
        int stockno = 17;
        public pattern(int z)
        {
            InitializeComponent();
            if (z != 0)
            {
                stockno = z;
                sn_B.Text = z.ToString();
            }
        }           
        private void pattern_Load(object sender, EventArgs e)
        {
            x = (enter)this.Owner;
            loadStat("");
        }
        private void loadStat(string dtf)
        {
           string honort= "";
           string shamet = "";
            int mg = 0;
            int md = 0;
            int mgwh = 0;
            int mdwl = 0; 
            double mv = 0;
            Boolean found = false;
            #region chking
            DataTable chkt = ok.select("*","rsimon","stockno =" + stockno.ToString(), "");
            if (chkt.Rows.Count > 0) found = true;
            #endregion
            if (found)
                hisData = ok.powerselect("select * from rsihistory where stockno =" + stockno.ToString() + (dtf.Equals("") ? "" : " and " + dtf) + " order by date");
            else
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
                    answer = stockno;
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
                    DataTable ret2 = new DataTable();
                    ret2.Columns.Add("date");
                    ret2.Columns.Add("stockno");
                    ret2.Columns.Add("rsi");
                    ret2.Columns.Add("open");
                    ret2.Columns.Add("close");
                    ret2.Columns.Add("highest");
                    ret2.Columns.Add("lowest");
                    ret2.Columns.Add("volume");
                    for (int z = ret.Rows.Count - 1; z >= 0;z-- )
                    {
                        DataRow ret2tmprow = ret2.NewRow();
                        ret2tmprow["stockno"] = stockno;
                        ret2tmprow["date"] = ret.Rows[z]["date"];
                        ret2tmprow["open"] = ret.Rows[z]["open"];
                        ret2tmprow["close"] = ret.Rows[z]["adjusted"];
                        ret2tmprow["highest"] = ret.Rows[z]["highest"];
                        ret2tmprow["lowest"] = ret.Rows[z]["lowest"];
                        ret2tmprow["volume"] = ret.Rows[z]["volume"];
                        if (!year_B.Text.Equals("") && month_CB.SelectedIndex != -1)
                        {
                            if(Convert.ToDateTime( ret.Rows[z]["date"].ToString()).Year== Convert.ToInt32( year_B.Text) 
                                &&
                                Convert.ToDateTime(ret.Rows[z]["date"].ToString()).Month == Convert.ToInt32(month_CB.SelectedItem)                                
                                )
                                ret2.Rows.Add(ret2tmprow);
                        }
                        else ret2.Rows.Add(ret2tmprow);
                    }
                    hisData = ret2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
                #endregion
            }
            dataGridView1.DataSource = hisData;
           
            double tmd = 99999;
            double tmg = 0;
            int tmpmd = 0;
            int tmpmg = 0;
            double tmdwl = 99999;
            double tmgwh = 0;
            int tmpmgwh = 0;
            int tmpmdwl = 0;
            string tmphonort = "";
            string tmpshamet = "";
            string tmphonortwh = "";
            string acthonortwh = "";
            foreach (DataRow x in hisData.Rows)
            {
                #region maximum volume               
                   if (!DBNull.Value.Equals(x[7]) && Convert.ToDouble(x[7]) > mv) mv = Convert.ToDouble(x[7]);
                #endregion
                #region maximum up day with highest
                /*if (!DBNull.Value.Equals(x[5]) && Convert.ToDouble(x[5]) > tmgwh)//stock value
                {
                    tmphonortwh += x[0] + "\n";
                    tmgwh = Convert.ToDouble(x[4]); //stock value
                    tmpmgwh++;
                    if (tmpmgwh > mgwh)
                    {
                        acthonortwh = tmphonortwh;
                        mgwh = tmpmgwh;
                    }
                }
                else
                {
                    tmphonortwh = "";
                    tmgwh = 0; //stock value
                    tmpmgwh = 0;
                }
                */
                #endregion                           
                #region maximum up day
                    if (!DBNull.Value.Equals(x[4]) && Convert.ToDouble(x[4]) > tmg)
                    {
                        if (tmpmg == 0) tmphonort += x[4].ToString()+"\n"; 
                        tmphonort += x[0] + "\n";
                        tmg = Convert.ToDouble(x[4]);
                        tmpmg++;
                        if (tmpmg >= mg)
                        {
                            mg = tmpmg;
                            honort = tmphonort + x[4].ToString();
                        }
                    }
                    else
                    {
                        tmpmg = 0;
                        tmphonort = "";
                        tmg = 0;
                    }
                    #endregion           
                #region maximum drop day
                    if (!DBNull.Value.Equals(x[4]) && Convert.ToDouble(x[4]) <= tmd)
                    {
                        if (tmpmd == 0) tmpshamet += x[4].ToString() + "\n"; 
                        tmd = Convert.ToDouble(x[4]);
                        tmpmd++;
                        tmpshamet += x[0] + "\n";
                        if (tmpmd >= md)
                        {
                            md = tmpmd;
                            shamet = tmpshamet + x[4].ToString() ;
                        }
                    }
                    else
                    {
                        tmpshamet = "";
                        tmpmd = 0;
                        tmd = 99999;                        
                    }
                #endregion

             }
         //   MessageBox.Show(acthonortwh);
            #region set parameters
            mv_B.Text = mv.ToString();
            mg_B.Text = mg.ToString();
            md_B.Text = md.ToString();
            honor.Text =  "Honor\n"+honort +"\n\n Shame\n"+ shamet;
            #endregion
        }

        private void b_Btn_Click(object sender, EventArgs e)
        {
            x.showoff();
            this.Dispose();
        }

        private void res_Btn_Click(object sender, EventArgs e)
        {                       
            month_CB.SelectedIndex = -1;
            year_B.Text = "";
            loadStat("");
        }

        private void month_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month_CB.SelectedIndex == -1) return;
            if (year_B.Text.Equals("")) year_B.Text = DateTime.Now.Year.ToString();
            loadStat(" Year(date) = "+year_B.Text+" and " + " MONTH(date)="+ month_CB.SelectedItem.ToString());
        }

        private void sn_B_TextChanged(object sender, EventArgs e)
        {
            stockno = Convert.ToInt32(sn_B.Text);
        }
    }
}
