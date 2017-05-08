using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockMaximumGain.classes;

namespace StockMaximumGain
{
    public partial class Focus : Form
    {
        db db = new db();
        public Focus()
        {
            InitializeComponent();
        }
        private void addStock_Btn_Click(object sender, EventArgs e)
        {
            addStock();
        }
        private void reloadCB()
        {
            DataTable tmp = db.powerselect("select distinct category from focus");
            List<string> kai = new List<string>();
            foreach (DataRow tr in tmp.Rows)
                kai.Add(tr[0].ToString());
            category_CB.DataSource = kai;
        }
        private void Focus_Load(object sender, EventArgs e)
        {
            reloadCB();
            bgb.RunWorkerAsync();            
        }
        private void loadHistory()
        {
            DataTable output = new DataTable();
            DataTable a = db.powerselect("select distinct category from focushistory");
            output.Columns.Add("Date");
            foreach (DataRow tmp in a.Rows)
            {
                output.Columns.Add(new DataColumn(tmp[0].ToString(), typeof(decimal)));
            }
            DataTable d = db.powerselect("select distinct date from focushistory order by date");
            foreach (DataRow tmp in d.Rows)
            {
                DataRow tmpRow = output.NewRow();
                tmpRow[0] = tmp[0];
                DataTable b = db.powerselect("select category,value from focushistory where date="+ db.nseb(tmp[0].ToString()));
                foreach (DataRow tmp2 in b.Rows)
                {
                    tmpRow[tmp2[0].ToString()] = (Convert.ToDouble(tmp2[1].ToString()) * 100).ToString("F") ;
                }
                output.Rows.Add(tmpRow);
            }
            dg1_setDT(output);

            colorifyDG1();
        }
        private void colorifyDG1()
        {
            for (int v = 0; v < dg1.Rows.Count; v++)
            {
                DataGridViewRow x = dg1.Rows[v];
                foreach (DataGridViewCell y in x.Cells)
                {
                    try
                    {
                        if (Convert.ToDouble(y.Value) > 0) y.Style.ForeColor = Color.Green;
                        else y.Style.ForeColor = Color.Red;
                    }
                    catch (Exception ex)
                    {                        
                    }
                }
            }
        }
        private void category_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void input_B_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                addStock();
            }
        }

        private void input_B_TextChanged(object sender, EventArgs e)
        {

        }
        private void addStock()
        {
            try
            {
                if (input_B.Text.Equals(""))
                {
                    MessageBox.Show("Input is empty");
                    return;
                }
                if (input_B.Text.Split('/').Length > 1)
                {
                    string cat = input_B.Text.Split('/')[0];
                    string sn = input_B.Text.Split('/')[1];
                    if (db.powerselect("select 1 from focus where stockno="+db.nseb(sn)).Rows.Count == 0) ;
                    {
                        db.powerselect("insert into focus (category,stockno)VALUES (" + db.nseb(cat) + "," + db.nseb(sn) + ")  ");
                    }
                }
                else
                {
                    if (db.powerselect("select 1 from focus where stockno=" + db.nseb(input_B.Text)).Rows.Count == 0) ;
                    {
                        db.powerselect("insert into focus (category,stockno)VALUES (" + db.nseb(category_CB.SelectedValue.ToString()) + "," + db.nseb(input_B.Text) + ")  ");
                    }
                }
                reloadCB();
                bgb.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            input_B.Text = "";
        }
        private void bgbdw()
        {
            DataTable tmp = db.powerselect("select category,stockno,remarks from focus order by category");
            string v = "";
            string pc = "";
            double cv = 0;
            int ncv = 0;
            string date;
            foreach (DataRow tr in tmp.Rows)
            {
                if (!pc.Equals(tr[0].ToString()))
                {
                    if (!pc.Equals(""))
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd");
                        if (db.powerselect("select 1 from focushistory where category=" + db.nseb(pc) + " and date=" + db.nseb(date)).Rows.Count > 0)
                            db.powerselect("update focushistory set value =" + (cv / ncv).ToString() + " where date=" + db.nseb(date) + " and category=" + db.nseb(pc));
                        else
                            db.powerselect("insert into focushistory (category,date,value) VALUES (" + db.nseb(pc) + "," + db.nseb(date) + "," + (cv / ncv).ToString() + ")");
                        v += "\n= " + ((cv / ncv) > 0 ? (cv / ncv).ToString() : "(" + (cv / ncv).ToString() + ")") + "\n\n";
                    }
                    pc = tr[0].ToString();
                    cv=0;
                    ncv = 0;                    
                }
                focus.FocusCons bb = focus.getStatus(Convert.ToInt32(tr[1]));
                cv += bb.degree;
                ncv++;
                v += tr[0].ToString() + ">>" + tr[1].ToString() + ">" + bb.print() +"    ||  "+tr[2].ToString() +"\t";
            }
            date = DateTime.Now.ToString("yyyy-MM-dd");
            if (db.powerselect("select 1 from focushistory where category=" + db.nseb(pc) + " and date=" + db.nseb(date)).Rows.Count > 0)
                db.powerselect("update focushistory set value =" + (cv / ncv).ToString() + " where date=" + db.nseb(date) + " and category=" + db.nseb(pc));
            else
                db.powerselect("insert into focushistory (category,date,value) VALUES (" + db.nseb(pc) + "," + db.nseb(date) + "," + (cv / ncv).ToString() + ")");
            v += "\n= " + ((cv / ncv) > 0 ? (cv / ncv).ToString() : "(" + (cv / ncv).ToString() + ")") + "\n\n";
            resRT_setText(v);
            loadHistory();
        }
        private void bgb_DoWork(object sender, DoWorkEventArgs e)
        {
            bgbdw();
        }

        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            bgbdw();
        }

        delegate void SetRB(string text);
        private void resRT_setText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.res_RT.InvokeRequired)
            {
                SetRB d = new SetRB(resRT_setText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.res_RT.Text = text;
            }
        }
        delegate void SetDG1(DataTable v);
        private void dg1_setDT(DataTable v)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.res_RT.InvokeRequired)
            {
                SetDG1 d = new SetDG1(dg1_setDT);
                this.Invoke(d, new object[] { v });
            }
            else
            {
                this.dg1.DataSource = v;
            }
        }
        private void removeStock_Btn_Click(object sender, EventArgs e)
        {
            if (!input_B.Text.Equals(""))
            {
                removeStock_Btn.BackColor = Color.Silver;
                db.powerselect("delete from focus where stockno = "+ db.nseb(input_B.Text));
            }
            else
            {
                removeStock_Btn.BackColor = Color.Red;                
            }
            input_B.Text = "";
        }

        private void removeCategory_Btn_Click(object sender, EventArgs e)
        {
            if (!input_B.Text.Equals(""))
            {
                removeStock_Btn.BackColor = Color.Silver;
                db.powerselect("delete from focus where category = " + db.nseb(input_B.Text));
            }
            else
            {
                removeCategory_Btn.BackColor = Color.Red;
            }
            input_B.Text = "";
        }

        private void addRemarks_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!input_B.Text.Equals("") || input_B.Text.Split('/').Length > 1)
                {
                    db.powerselect("update focus set remarks="+db.nseb( input_B.Text.Split('/')[1].ToString()) + " where stockno="+ input_B.Text.Split('/')[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            input_B.Text = "";
        }
    }
}
