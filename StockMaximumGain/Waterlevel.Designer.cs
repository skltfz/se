namespace StockMaximumGain
{
    partial class Waterlevel
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
            this.sn_L = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.io_Btn = new System.Windows.Forms.Button();
            this.vsp_Btn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sn_L
            // 
            this.sn_L.AutoSize = true;
            this.sn_L.Location = new System.Drawing.Point(6, 16);
            this.sn_L.Name = "sn_L";
            this.sn_L.Size = new System.Drawing.Size(0, 13);
            this.sn_L.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.sn_L);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock";
           
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1302, 443);
            this.dataGridView1.TabIndex = 2;
            // 
            // bgw1
            // 
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            // 
            // io_Btn
            // 
            this.io_Btn.Location = new System.Drawing.Point(669, 18);
            this.io_Btn.Name = "io_Btn";
            this.io_Btn.Size = new System.Drawing.Size(75, 23);
            this.io_Btn.TabIndex = 3;
            this.io_Btn.Text = "Output IO%";
            this.io_Btn.UseVisualStyleBackColor = true;
            this.io_Btn.Click += new System.EventHandler(this.io_Btn_Click);
            // 
            // vsp_Btn
            // 
            this.vsp_Btn.Location = new System.Drawing.Point(750, 18);
            this.vsp_Btn.Name = "vsp_Btn";
            this.vsp_Btn.Size = new System.Drawing.Size(75, 23);
            this.vsp_Btn.TabIndex = 4;
            this.vsp_Btn.Text = "VSP";
            this.vsp_Btn.UseVisualStyleBackColor = true;
            this.vsp_Btn.Click += new System.EventHandler(this.vsp_Btn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 13);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 23);
            this.progressBar1.TabIndex = 5;
          
            // 
            // Waterlevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 510);
            this.Controls.Add(this.vsp_Btn);
            this.Controls.Add(this.io_Btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Waterlevel";
            this.Text = "Water Level";
            this.Load += new System.EventHandler(this.Waterlevel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sn_L;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker bgw1;
        private System.Windows.Forms.Button io_Btn;
        private System.Windows.Forms.Button vsp_Btn;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}