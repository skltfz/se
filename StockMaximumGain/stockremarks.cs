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
    public partial class stockremarks : Form
    {
        int stockno = 5;
        db ok = new db();        
        public stockremarks(int sn)
        {
            InitializeComponent();
            stockno = sn;
        }

        private void stockremarks_Load(object sender, EventArgs e)
        {
            pl();
        }
        private void pl()
        {
            rgg.DataSource = ok.select("remarks", "stockremarks", "no=" + stockno.ToString(), "");
            if (rgg.Columns[0] != null) rgg.Columns[0].Width = 330;
        }
        private void add_Btn_Click(object sender, EventArgs e)
        {
            ok.insert("stockremarks",new object[]{"no","remarks"},new object[]{stockno.ToString(),"'"+rb.Text+"'"});
            stockremarks_Load(sender,e);
            //pl();
        }

        private void rgg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection x = rgg.SelectedCells;
            foreach (DataGridViewCell g in x)
            {
                rb.Text = g.Value.ToString();
            }
        }

        private void del_Btn_Click(object sender, EventArgs e)
        {
            ok.delete("stockremarks", new string[] { "no", "remarks" }, new string[] {stockno.ToString(),"'"+rb.Text+"'" });
            pl();
        }

       
    }
}
