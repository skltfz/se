using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StockMaximumGain
{
    public partial class on9 : Form
    {
        public on9()
        {
            InitializeComponent();
        }
        public class S2
        {
            public string name;
            public DateTime dt;
            public S2(string name, DateTime dt)
            {
                this.name = name;
                this.dt = dt;
            }
        }
        private List<S2> GetFileList(List<S2> g)
        {
            for (int v = 0; v < 100; v++ )
            {
                g.Add(new S2(v.ToString(),DateTime.Now.AddDays(v)));
            }
//            DateTime.Now.
            // stocklist = stocklist.OrderByDescending(o => o.avgt()).ToList();
//           g = g.OrderByDescending(o => o.name).ToList();
           return g.OrderByDescending(o => o.dt).ToList(); //dateList.Reverse();
        }
        
        private void on9_Load(object sender, EventArgs e)
        {
            List<S2> g = new List<S2>();
            for (int v = 0; v < 100; v++)
            {
                g.Add(new S2(v.ToString(), DateTime.Now.AddDays(v)));
            }
            g= g.OrderByDescending(o => o.dt).ToList();
            string on9 ="";
           
            foreach (S2 gg in g)
            {
                on9 += "\n" +  gg.name +"\t" +gg.dt; 
            }
            MessageBox.Show(on9);
        }
    }
}
