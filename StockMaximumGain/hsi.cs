using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockMaximumGain
{
    public partial class hsi : Form
    {
        static string mkn = "hsi";
        public hsi()
        {
            InitializeComponent();
        }

        private void hsi_Load(object sender, EventArgs e)
        {
            loadstat();
        }
        private void loadstat()
        {
            try
            {

                db ok = new db();
                dgv2.DataSource = ok.select("date,[open],highest,lowest,closeure,(volume/100000000) as 'volume(billion)'", mkn, (!year_B.Text.Equals("") && month_CB.SelectedIndex != -1) ? " Year(date) = " + year_B.Text + " and " + " MONTH(date)=" + month_CB.SelectedItem.ToString() : "","date");
                int tp = 0;
                foreach (DataGridViewRow x in dgv2.Rows)
                {
                    if (Convert.ToDouble(x.Cells["open"].Value.ToString()) > Convert.ToDouble(x.Cells["closeure"].Value.ToString()))
                        x.DefaultCellStyle.BackColor = Color.LightCoral;
                    else x.DefaultCellStyle.BackColor = Color.LightGreen;
                    tp++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }
        private void res_Btn_Click(object sender, EventArgs e)
        {
            month_CB.SelectedIndex = -1;
            year_B.Text = "";
            loadstat();
        }

        private void month_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            year_B.Text = DateTime.Now.Year.ToString();
            loadstat();
        }
    }
}
