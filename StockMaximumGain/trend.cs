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
    public partial class trend : Form
    {
        DataTable rows = new DataTable();
        db ok = new db();
        public trend()
        {
            InitializeComponent();
        }
     
        private void buy_Load(object sender, EventArgs e)
        {
           rows = ok.select("*", "area", "", "area");
           DataTable ckcr = ok.select("distinct name", "areacolumn", "", "");           
           if (ckcr.Rows.Count > 0)
           {
               Boolean buildnew = true;
               string newname = DateTime.Now.ToLocalTime().ToShortDateString();
               string datetime = DateTime.Now.ToLocalTime().Year + "-" + DateTime.Now.ToLocalTime().Month+ "-" + DateTime.Now.ToLocalTime().Day;
               foreach (DataRow ckcrr in ckcr.Rows)
               {
                   if (ckcrr[0].ToString().Equals(newname))
                       buildnew = false;
               }
               if (buildnew)
               {
                   DataTable bd = ok.select("name","areacolumn","","datetime");                   
                   foreach (DataRow x in rows.Rows)
                   {
                       ok.insert("areacolumn", new object[] { "area", "name","datetime" }, new object[] { "'" + x[0].ToString() + "'", "'" + newname + "'" ,"'"+ datetime+"'" });
                   }
                   //ok.delete("areacolumn", new string[] { "name" }, new string[] { "'" + bd.Rows[0][0].ToString() + "'" });
               }
           }           
           DataTable res =  rows; 
           List<string> vv= new List<string>();
           DataTable columns = ok.select("name,area,value", "areacolumn", "", "datetime");
           foreach (DataRow z in columns.Rows)
           {
               if (!vv.Contains(z[0].ToString()))
               {
                   res.Columns.Add(z[0].ToString());
                   vv.Add(z[0].ToString());
               }
               for (int k = 0 ; k < res.Rows.Count;k++)
               {
                   if (res.Rows[k][0].ToString() == z[1].ToString())
                   {
                       res.Rows[k][z[0].ToString()] = z[2].ToString();
                   }
               }
           }
           g1.DataSource = res;
        }

        private void g1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection x = g1.SelectedCells;
            foreach (DataGridViewCell g in x)
            {
                DataGridViewCell qdc = g1.Rows[g.RowIndex].Cells[0];
                string qc = g1.Columns[  g.ColumnIndex].Name;
                DataGridViewCell qdc3 = g1.Rows[g.RowIndex].Cells[qc];
                area_B.Text = qdc.Value.ToString();
                name_B.Text = qc.ToString();
                if (qdc3.Value.ToString().Equals("r") || qdc3.Value.ToString().Equals("Raise"))
                {
                    raise_CB.Checked = true;
                }
                else
                    drop_CB.Checked = true;
                string k = ((qdc3.Value.ToString().Equals("r") || qdc3.Value.ToString().Equals("Raise"))) ? "Drop" : "Raise";
                ok.update_free("areacolumn", new object[] { "value" }, new object[] { "'" + k + "'" },
                    "name='" + name_B.Text + "'" + " and " +
                    "area='" + area_B.Text + "'");
                buy_Load(sender, e);
                //value_B.Text = qdc3.Value.ToString();
            }
        }

        private void add_Btn_Click(object sender, EventArgs e)
        {           
            foreach (DataRow x in rows.Rows)
            {
                ok.insert("areacolumn", new object[] { "area", "name" }, new object[] {"'"+ x[0].ToString()+"'", "'"+ name_B.Text+"'" });
            }
            buy_Load( sender,  e);
        }

        private void update_Btn_Click(object sender, EventArgs e)
        {
            string k = (raise_CB.Checked) ? "Raise" : "Drop";
            ok.update_free("areacolumn",new object[]{"value"},new object[]{"'" +k+"'"},
                "name='" + name_B.Text + "'"  +  " and " +
                "area='" + area_B.Text + "'");
            buy_Load(sender,e);
        }

        private void g1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}