namespace StockMaximumGain
{
    partial class hpattern
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tmp_RT = new System.Windows.Forms.RichTextBox();
            this.back_Btn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.re_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(861, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tmp_RT
            // 
            this.tmp_RT.Location = new System.Drawing.Point(364, 226);
            this.tmp_RT.Name = "tmp_RT";
            this.tmp_RT.Size = new System.Drawing.Size(508, 243);
            this.tmp_RT.TabIndex = 3;
            this.tmp_RT.Text = "";
            // 
            // back_Btn
            // 
            this.back_Btn.Location = new System.Drawing.Point(12, 446);
            this.back_Btn.Name = "back_Btn";
            this.back_Btn.Size = new System.Drawing.Size(75, 23);
            this.back_Btn.TabIndex = 4;
            this.back_Btn.Text = "Back";
            this.back_Btn.UseVisualStyleBackColor = true;
            this.back_Btn.Click += new System.EventHandler(this.back_Btn_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(93, 226);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(265, 243);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // re_Btn
            // 
            this.re_Btn.Location = new System.Drawing.Point(12, 226);
            this.re_Btn.Name = "re_Btn";
            this.re_Btn.Size = new System.Drawing.Size(75, 23);
            this.re_Btn.TabIndex = 6;
            this.re_Btn.Text = "re";
            this.re_Btn.UseVisualStyleBackColor = true;
            this.re_Btn.Click += new System.EventHandler(this.re_Btn_Click);
            // 
            // hpattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 481);
            this.Controls.Add(this.re_Btn);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.back_Btn);
            this.Controls.Add(this.tmp_RT);
            this.Controls.Add(this.dataGridView1);
            this.Name = "hpattern";
            this.Text = "hpattern";
            this.Load += new System.EventHandler(this.hpattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox tmp_RT;
        private System.Windows.Forms.Button back_Btn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button re_Btn;
    }
}