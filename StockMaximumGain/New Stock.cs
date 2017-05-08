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
    public partial class New_Stock : Form
    {
        enter x;
        public New_Stock()
        {
            InitializeComponent();
        }

        private void New_Stock_Load(object sender, EventArgs e)
        {
            x = (enter)this.Owner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db ok = new db();
            DataTable r = ok.select("stockno","rsi","stockno ="+ textBox1.Text,"");            
            if (r.Rows.Count == 0)
            {
                ok.insert("rsi", new object[] { "stockno", "name" }, new object[] { textBox1.Text, "'" + textBox2.Text + "'" });
                x.q1stock(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("New stock is created with stockno:" + textBox1.Text + " and name:" + textBox2.Text);
            }
            else
            {
                MessageBox.Show("Cannot create, exist.");
            }
            x.showoff();
            this.Dispose();

        }
    }
}
