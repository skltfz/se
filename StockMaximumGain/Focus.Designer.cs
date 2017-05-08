namespace StockMaximumGain
{
    partial class Focus
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
            this.input_B = new System.Windows.Forms.TextBox();
            this.addStock_Btn = new System.Windows.Forms.Button();
            this.category_CB = new System.Windows.Forms.ComboBox();
            this.res_RT = new System.Windows.Forms.RichTextBox();
            this.bgb = new System.ComponentModel.BackgroundWorker();
            this.removeStock_Btn = new System.Windows.Forms.Button();
            this.removeCategory_Btn = new System.Windows.Forms.Button();
            this.addRemarks_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dg1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // input_B
            // 
            this.input_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_B.Location = new System.Drawing.Point(139, 7);
            this.input_B.Multiline = true;
            this.input_B.Name = "input_B";
            this.input_B.Size = new System.Drawing.Size(288, 57);
            this.input_B.TabIndex = 1;
            this.input_B.TextChanged += new System.EventHandler(this.input_B_TextChanged);
            this.input_B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_B_KeyDown);
            // 
            // addStock_Btn
            // 
            this.addStock_Btn.Location = new System.Drawing.Point(433, 7);
            this.addStock_Btn.Name = "addStock_Btn";
            this.addStock_Btn.Size = new System.Drawing.Size(118, 26);
            this.addStock_Btn.TabIndex = 2;
            this.addStock_Btn.Text = "Add Stock";
            this.addStock_Btn.UseVisualStyleBackColor = true;
            this.addStock_Btn.Click += new System.EventHandler(this.addStock_Btn_Click);
            // 
            // category_CB
            // 
            this.category_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_CB.FormattingEnabled = true;
            this.category_CB.Location = new System.Drawing.Point(12, 7);
            this.category_CB.Name = "category_CB";
            this.category_CB.Size = new System.Drawing.Size(121, 28);
            this.category_CB.TabIndex = 3;
            this.category_CB.SelectedIndexChanged += new System.EventHandler(this.category_CB_SelectedIndexChanged);
            // 
            // res_RT
            // 
            this.res_RT.Location = new System.Drawing.Point(12, 103);
            this.res_RT.Name = "res_RT";
            this.res_RT.Size = new System.Drawing.Size(727, 354);
            this.res_RT.TabIndex = 4;
            this.res_RT.Text = "";
            // 
            // bgb
            // 
            this.bgb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgb_DoWork);
            // 
            // removeStock_Btn
            // 
            this.removeStock_Btn.Location = new System.Drawing.Point(12, 71);
            this.removeStock_Btn.Name = "removeStock_Btn";
            this.removeStock_Btn.Size = new System.Drawing.Size(118, 26);
            this.removeStock_Btn.TabIndex = 6;
            this.removeStock_Btn.Text = "Remove Stock";
            this.removeStock_Btn.UseVisualStyleBackColor = true;
            this.removeStock_Btn.Click += new System.EventHandler(this.removeStock_Btn_Click);
            // 
            // removeCategory_Btn
            // 
            this.removeCategory_Btn.Location = new System.Drawing.Point(136, 71);
            this.removeCategory_Btn.Name = "removeCategory_Btn";
            this.removeCategory_Btn.Size = new System.Drawing.Size(118, 26);
            this.removeCategory_Btn.TabIndex = 7;
            this.removeCategory_Btn.Text = "Remove Category";
            this.removeCategory_Btn.UseVisualStyleBackColor = true;
            this.removeCategory_Btn.Click += new System.EventHandler(this.removeCategory_Btn_Click);
            // 
            // addRemarks_Btn
            // 
            this.addRemarks_Btn.Location = new System.Drawing.Point(433, 39);
            this.addRemarks_Btn.Name = "addRemarks_Btn";
            this.addRemarks_Btn.Size = new System.Drawing.Size(118, 26);
            this.addRemarks_Btn.TabIndex = 8;
            this.addRemarks_Btn.Text = "Add Remarks";
            this.addRemarks_Btn.UseVisualStyleBackColor = true;
            this.addRemarks_Btn.Click += new System.EventHandler(this.addRemarks_Btn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(558, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "onlysupportaddremark in format: stockno/remarks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "new stock in format: category/stockno";
            // 
            // dg1
            // 
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(12, 463);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(1396, 276);
            this.dg1.TabIndex = 11;
            // 
            // Focus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 751);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addRemarks_Btn);
            this.Controls.Add(this.removeCategory_Btn);
            this.Controls.Add(this.removeStock_Btn);
            this.Controls.Add(this.res_RT);
            this.Controls.Add(this.category_CB);
            this.Controls.Add(this.addStock_Btn);
            this.Controls.Add(this.input_B);
            this.Name = "Focus";
            this.Text = "Focus";
            this.Load += new System.EventHandler(this.Focus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_B;
        private System.Windows.Forms.Button addStock_Btn;
        private System.Windows.Forms.ComboBox category_CB;
        private System.Windows.Forms.RichTextBox res_RT;
        private System.ComponentModel.BackgroundWorker bgb;
        private System.Windows.Forms.Button removeStock_Btn;
        private System.Windows.Forms.Button removeCategory_Btn;
        private System.Windows.Forms.Button addRemarks_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dg1;
    }
}