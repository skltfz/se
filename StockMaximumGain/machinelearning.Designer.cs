namespace StockMaximumGain
{
    partial class machinelearning
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
            this.train_Btn = new System.Windows.Forms.Button();
            this.remarks_RB = new System.Windows.Forms.RichTextBox();
            this.pptrain_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // train_Btn
            // 
            this.train_Btn.Location = new System.Drawing.Point(1217, 41);
            this.train_Btn.Name = "train_Btn";
            this.train_Btn.Size = new System.Drawing.Size(157, 23);
            this.train_Btn.TabIndex = 0;
            this.train_Btn.Text = "Train";
            this.train_Btn.UseVisualStyleBackColor = true;
            this.train_Btn.Click += new System.EventHandler(this.train_Btn_Click);
            // 
            // remarks_RB
            // 
            this.remarks_RB.Location = new System.Drawing.Point(1217, 70);
            this.remarks_RB.Name = "remarks_RB";
            this.remarks_RB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.remarks_RB.Size = new System.Drawing.Size(157, 104);
            this.remarks_RB.TabIndex = 1;
            this.remarks_RB.Text = "";
            // 
            // pptrain_Btn
            // 
            this.pptrain_Btn.Location = new System.Drawing.Point(1217, 12);
            this.pptrain_Btn.Name = "pptrain_Btn";
            this.pptrain_Btn.Size = new System.Drawing.Size(157, 23);
            this.pptrain_Btn.TabIndex = 2;
            this.pptrain_Btn.Text = "Perceptron Training";
            this.pptrain_Btn.UseVisualStyleBackColor = true;
            this.pptrain_Btn.Click += new System.EventHandler(this.pptrain_Btn_Click);
            // 
            // machinelearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 563);
            this.Controls.Add(this.pptrain_Btn);
            this.Controls.Add(this.remarks_RB);
            this.Controls.Add(this.train_Btn);
            this.Name = "machinelearning";
            this.Text = "machinelearning";
            this.Load += new System.EventHandler(this.machinelearning_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button train_Btn;
        private System.Windows.Forms.RichTextBox remarks_RB;
        private System.Windows.Forms.Button pptrain_Btn;
    }
}