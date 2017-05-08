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

namespace StockMaximumGain
{
    public partial class machinelearning : Form
    {
        double threshold = 0;
        writelog wl = new writelog();
        public machinelearning()
        {
            InitializeComponent();
            
        }
        private void writeboth(int x, string y)
        {
            wl.writeentry(x,y);
            remarks_RB.Text += x.ToString() + "["+DateTime.Now.ToString()+"]" + y + "\n";
        }
        private void learn ()
        {
            db ok = new db();
            #region initialization
            if (ok.select("*", "pptlearning", "", "").Rows.Count == 0)
            {
                //initialization
                List<string> pptnamelist = new List<string>();
                foreach (DataRow tmp in ok.select("indexname", "indexlist", "", "").Rows)
                {
                    pptnamelist.Add(tmp[0].ToString());
                }
                double dm = Convert.ToDouble(pptnamelist.Count);
                foreach (string tmp in pptnamelist)
                {
                    ok.insert("pptlearning",new object[]{"weight","pptName"}, new object[]{ 1/dm,ok.seb(tmp)});
                    writeboth(0,"Trainning"+ ok.seb(tmp)+ " to "+ (1/dm).ToString());
                }
            }
            #endregion
        }

        private void train_Btn_Click(object sender, EventArgs e)
        {
            learn();
        }

        private void pptrain_Btn_Click(object sender, EventArgs e)
        {
            db ok = new db();
            foreach (DataRow tmpRow in ok.select("*", "rsimon", "", "").Rows)
            {
                DataTable training = ok.powerselect("select * from hsi as a left outer join rsihistory as b on a.date = DATEADD(dd,-1,b.date) where b.stockno ="+tmpRow[0].ToString()+" order by a.date");
              //  double threshold = 0;
                double SSE = 0;
                int processtime = 0;
                Boolean end =false;
                while (!end)
                {
                    int success = 0;
                    foreach (DataRow trainRow in training.Rows)
                    {
                        Boolean isup = false;
                        if (trainRow[9] != DBNull.Value && trainRow[10] != DBNull.Value)
                        {
                            double inputValue = (Convert.ToDouble(trainRow[1]) - Convert.ToDouble(trainRow[4])) ;//* Convert.ToDouble(trainRow[5]));
                            if (Convert.ToDouble(trainRow[9]) > Convert.ToDouble(trainRow[10]))
                                isup = true;
                            if (threshold == 0)
                            {
                                threshold = inputValue;                               
                            }
                            else if ((Convert.ToDouble(inputValue) > threshold && isup) || (Convert.ToDouble(inputValue) < threshold && !isup))
                            {
                                writeboth(0,"success++" + threshold.ToString());
                                success++;
                            }
                            else if ((Convert.ToDouble(inputValue) > threshold && !isup) || (Convert.ToDouble(inputValue) < threshold && isup))
                            {
                                string res = "Wrong:" + (isup ? "Raise" : "Drop") + " Threshold:" + threshold.ToString() + "-->" + inputValue.ToString() + " Fix " + threshold.ToString() + " to ";
                                threshold = (Convert.ToDouble(inputValue) + threshold) / 2;
                                res += threshold.ToString();
                                writeboth(0, res);
                            }
                            else
                            {
                                MessageBox.Show("Unhandled exception");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Train is end.");                            
                        }
                    }
                    processtime++;
                    if (processtime > 5) end = true;
                    if (success > Convert.ToInt32 (0.85*Convert.ToDouble( training.Rows.Count))) end = true;
                    writeboth(1, success.ToString());
                }
            }
        }

        private void machinelearning_Load(object sender, EventArgs e)
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                1000, 70, 150, 150);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
//            FileStream xmlfile = new FileStream(@"C:\Users\sam.mak\Documents\Visual Studio 2010\Projects\StockMaximumGain\StockMaximumGain\StockMaximumGain\kai.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
//            System.Xml.XmlDocument MarketDataDoc = new System.Xml.XmlDocument();
//            MarketDataDoc.Load(xmlfile);
//            System.Xml.XmlNodeList nodes = MarketDataDoc.SelectNodes(@"//security");
          //  MessageBox.Show(nodes[0].SelectSingleNode(@"name").ChildNodes[0].Value.Replace("<","&lt;").Replace(">","&gt;"));
          //  MessageBox.Show(WebUtility.HtmlEncode(nodes[0].SelectSingleNode(@"name").ChildNodes[0].Value));
        }

    }
}
