namespace StockMaximumGain
{
    partial class stockremarks
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
            this.rgg = new System.Windows.Forms.DataGridView();
            this.add_Btn = new System.Windows.Forms.Button();
            this.rb = new System.Windows.Forms.RichTextBox();
            this.del_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rgg)).BeginInit();
            this.SuspendLayout();
            // 
            // rgg
            // 
            this.rgg.AllowUserToAddRows = false;
            this.rgg.AllowUserToDeleteRows = false;
            this.rgg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.rgg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rgg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.rgg.Location = new System.Drawing.Point(12, 13);
            this.rgg.Name = "rgg";
            this.rgg.RowTemplate.Height = 24;
            this.rgg.Size = new System.Drawing.Size(445, 258);
            this.rgg.TabIndex = 99;
            this.rgg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rgg_CellClick);
            // 
            // add_Btn
            // 
            this.add_Btn.Location = new System.Drawing.Point(126, 429);
            this.add_Btn.Name = "add_Btn";
            this.add_Btn.Size = new System.Drawing.Size(105, 42);
            this.add_Btn.TabIndex = 1;
            this.add_Btn.Text = "ADD";
            this.add_Btn.UseVisualStyleBackColor = true;
            this.add_Btn.Click += new System.EventHandler(this.add_Btn_Click);
            // 
            // rb
            // 
            this.rb.Location = new System.Drawing.Point(12, 277);
            this.rb.Name = "rb";
            this.rb.Size = new System.Drawing.Size(445, 145);
            this.rb.TabIndex = 100;
            this.rb.Text = "";
            // 
            // del_Btn
            // 
            this.del_Btn.Location = new System.Drawing.Point(237, 429);
            this.del_Btn.Name = "del_Btn";
            this.del_Btn.Size = new System.Drawing.Size(105, 42);
            this.del_Btn.TabIndex = 2;
            this.del_Btn.Text = "Delete";
            this.del_Btn.UseVisualStyleBackColor = true;
            this.del_Btn.Click += new System.EventHandler(this.del_Btn_Click);
            // 
            // stockremarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 490);
            this.Controls.Add(this.del_Btn);
            this.Controls.Add(this.rb);
            this.Controls.Add(this.add_Btn);
            this.Controls.Add(this.rgg);
            this.Name = "stockremarks";
            this.Text = "stockremarks";
            this.Load += new System.EventHandler(this.stockremarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rgg;
        private System.Windows.Forms.Button add_Btn;
        private System.Windows.Forms.RichTextBox rb;
        private System.Windows.Forms.Button del_Btn;
    }
}