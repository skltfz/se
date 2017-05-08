using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace StockMaximumGain
{
    public partial class hpattern : Form
    {
        DataTable ic;
        db jk = new db();
        enter x;
        public hpattern()
        {
            InitializeComponent();

        }

        private void hpattern_Load(object sender, EventArgs e)
        {
            x = (enter)this.Owner;
           tmp_RT.Text = "INSERT INTO [stock].[dbo].[patternhsi]([start],[highest],[lowest],[closure],[volume],[date]) VALUES (21618.15,21623.24,21531.93,21562.26,1592404700,'3/2/2012')";
            loadStat();
            //loadchart("Bar");
        }
        private void loadchart(string type)
        {
            if (type.Equals("Bar"))
            {
                chart1.Titles.Add(type);
                foreach (DataRow x in ic.Rows)
                {
                    Series series = this.chart1.Series.Add(x[5].ToString());
                    // Add point.
                    series.Points.Add(Convert.ToDouble( x[0].ToString()));                
                }
            }
        }
        private void loadStat()
        {
            dataGridView1.DataSource = jk.select("*", "patternhsi", "", "date");
            ic = jk.select("*", "patternhsi", "", "date");
        }

        private void maxVol_Btn_Click(object sender, EventArgs e)
        {

        }

        private void back_Btn_Click(object sender, EventArgs e)
        {
            x.showoff();
            this.Dispose();
        }

        private void re_Btn_Click(object sender, EventArgs e)
        {
            double k = 0;
            double min = 0;
            string ret = "";
            foreach (DataRow g in ic.Rows)
            {
                if (min != 0)
                {
                    k = Convert.ToDouble(((double)g[4] - min).ToString());
                    min = (double)g[4];
                }
                else
                {
                    k = 0;
                    min = Convert.ToDouble(g[4].ToString());
                } 
                if(k>0)
                    ret += "\n +" + k.ToString() + " +++ ";
                else
                    ret += "\n " + k.ToString() + " --- ";
            }
                            tmp_RT.Text = ret;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.LightBlue;
            DataGridViewCellStyle CellStyle2 = new DataGridViewCellStyle();
            CellStyle2.BackColor = Color.White;
            if (e.RowIndex > 0 && e.ColumnIndex>0&& dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style != CellStyle)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
            }
            else
            {
                if (e.RowIndex > 0 && e.ColumnIndex>0)
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle2;            
            }
            if (e.RowIndex > 0 && e.ColumnIndex < 0)
            {
                int s = 0;
                foreach (DataGridViewColumn g in dataGridView1.Columns)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[s].Style = CellStyle;
                    s++;
                }
            }
        }
    }
}
