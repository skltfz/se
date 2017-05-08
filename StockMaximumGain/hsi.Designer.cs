namespace StockMaximumGain
{
    partial class hsi
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
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.year_B = new System.Windows.Forms.TextBox();
            this.month_CB = new System.Windows.Forms.ComboBox();
            this.res_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(12, 12);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(677, 553);
            this.dgv2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(695, 543);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Month";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(709, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "Year";
            // 
            // year_B
            // 
            this.year_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year_B.Location = new System.Drawing.Point(768, 504);
            this.year_B.Name = "year_B";
            this.year_B.Size = new System.Drawing.Size(98, 30);
            this.year_B.TabIndex = 37;
            // 
            // month_CB
            // 
            this.month_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month_CB.FormattingEnabled = true;
            this.month_CB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month_CB.Location = new System.Drawing.Point(768, 540);
            this.month_CB.Name = "month_CB";
            this.month_CB.Size = new System.Drawing.Size(66, 33);
            this.month_CB.TabIndex = 38;
            this.month_CB.SelectedIndexChanged += new System.EventHandler(this.month_CB_SelectedIndexChanged);
            // 
            // res_Btn
            // 
            this.res_Btn.Location = new System.Drawing.Point(840, 542);
            this.res_Btn.Name = "res_Btn";
            this.res_Btn.Size = new System.Drawing.Size(59, 26);
            this.res_Btn.TabIndex = 36;
            this.res_Btn.Text = "Reload";
            this.res_Btn.UseVisualStyleBackColor = true;
            this.res_Btn.Click += new System.EventHandler(this.res_Btn_Click);
            // 
            // hsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 577);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.year_B);
            this.Controls.Add(this.month_CB);
            this.Controls.Add(this.res_Btn);
            this.Controls.Add(this.dgv2);
            this.Name = "hsi";
            this.Text = "hsi";
            this.Load += new System.EventHandler(this.hsi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox year_B;
        private System.Windows.Forms.ComboBox month_CB;
        private System.Windows.Forms.Button res_Btn;
    }
}