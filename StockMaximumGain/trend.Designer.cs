namespace StockMaximumGain
{
    partial class trend
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
            this.g1 = new System.Windows.Forms.DataGridView();
            this.area_B = new System.Windows.Forms.TextBox();
            this.name_B = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.update_Btn = new System.Windows.Forms.Button();
            this.add_Btn = new System.Windows.Forms.Button();
            this.raise_CB = new System.Windows.Forms.RadioButton();
            this.drop_CB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // g1
            // 
            this.g1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g1.Location = new System.Drawing.Point(12, 12);
            this.g1.Name = "g1";
            this.g1.RowTemplate.Height = 24;
            this.g1.Size = new System.Drawing.Size(819, 498);
            this.g1.TabIndex = 0;
            this.g1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g1_CellClick);
            this.g1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g1_CellContentClick);
            // 
            // area_B
            // 
            this.area_B.Location = new System.Drawing.Point(874, 12);
            this.area_B.Name = "area_B";
            this.area_B.Size = new System.Drawing.Size(100, 22);
            this.area_B.TabIndex = 1;
            // 
            // name_B
            // 
            this.name_B.Location = new System.Drawing.Point(874, 56);
            this.name_B.Name = "name_B";
            this.name_B.Size = new System.Drawing.Size(100, 22);
            this.name_B.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(844, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "area";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(838, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "value";
            // 
            // update_Btn
            // 
            this.update_Btn.Location = new System.Drawing.Point(840, 124);
            this.update_Btn.Name = "update_Btn";
            this.update_Btn.Size = new System.Drawing.Size(139, 61);
            this.update_Btn.TabIndex = 7;
            this.update_Btn.Text = "Update";
            this.update_Btn.UseVisualStyleBackColor = true;
            this.update_Btn.Click += new System.EventHandler(this.update_Btn_Click);
            // 
            // add_Btn
            // 
            this.add_Btn.Location = new System.Drawing.Point(837, 191);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(75, 23);
            this.add_Btn.TabIndex = 8;
            this.add_Btn.Text = "Add";
            this.add_Btn.UseVisualStyleBackColor = true;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // raise_CB
            // 
            this.raise_CB.AutoSize = true;
            this.raise_CB.Location = new System.Drawing.Point(6, 13);
            this.raise_CB.Name = "raise_CB";
            this.raise_CB.Size = new System.Drawing.Size(48, 16);
            this.raise_CB.TabIndex = 9;
            this.raise_CB.TabStop = true;
            this.raise_CB.Text = "Raise";
            this.raise_CB.UseVisualStyleBackColor = true;
            // 
            // drop_CB
            // 
            this.drop_CB.AutoSize = true;
            this.drop_CB.Location = new System.Drawing.Point(55, 13);
            this.drop_CB.Name = "drop_CB";
            this.drop_CB.Size = new System.Drawing.Size(47, 16);
            this.drop_CB.TabIndex = 10;
            this.drop_CB.TabStop = true;
            this.drop_CB.Text = "Drop";
            this.drop_CB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.raise_CB);
            this.groupBox1.Controls.Add(this.drop_CB);
            this.groupBox1.Location = new System.Drawing.Point(874, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 34);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // trend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.add_Btn);
            this.Controls.Add(this.update_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_B);
            this.Controls.Add(this.area_B);
            this.Controls.Add(this.g1);
            this.Name = "trend";
            this.Text = "Trend";
            this.Load += new System.EventHandler(this.buy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView g1;
        private System.Windows.Forms.TextBox area_B;
        private System.Windows.Forms.TextBox name_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button update_Btn;
        private System.Windows.Forms.Button add_Btn;
        private System.Windows.Forms.RadioButton raise_CB;
        private System.Windows.Forms.RadioButton drop_CB;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}