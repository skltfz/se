namespace StockMaximumGain
{
    partial class enter
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.exit_Btn = new System.Windows.Forms.Button();
            this.rsi_Btn = new System.Windows.Forms.Button();
            this.remarks_RB = new System.Windows.Forms.RichTextBox();
            this.stock_B = new System.Windows.Forms.TextBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.srsi_B = new System.Windows.Forms.Button();
            this.ignore_Btn = new System.Windows.Forms.Button();
            this.revive_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pe_Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.el_CB = new System.Windows.Forms.ComboBox();
            this.searchType_Btn = new System.Windows.Forms.Button();
            this.type_L = new System.Windows.Forms.Label();
            this.type_B = new System.Windows.Forms.TextBox();
            this.remark_GB = new System.Windows.Forms.GroupBox();
            this.udv_Btn = new System.Windows.Forms.Button();
            this.refresh_Btn = new System.Windows.Forms.Button();
            this.ans_Btn = new System.Windows.Forms.Button();
            this.trend_Btn = new System.Windows.Forms.Button();
            this.bg1 = new System.ComponentModel.BackgroundWorker();
            this.moc_Btn = new System.Windows.Forms.Button();
            this.hsi_Btn = new System.Windows.Forms.Button();
            this.ml_Btn = new System.Windows.Forms.Button();
            this.hsbc_Btn = new System.Windows.Forms.Button();
            this.zzBtn = new System.Windows.Forms.Button();
            this.v1_B = new System.Windows.Forms.TextBox();
            this.v2_B = new System.Windows.Forms.TextBox();
            this.sym_CB = new System.Windows.Forms.ComboBox();
            this.res_L = new System.Windows.Forms.Label();
            this.fee_GB = new System.Windows.Forms.GroupBox();
            this.lo_B = new System.Windows.Forms.TextBox();
            this.li_B = new System.Windows.Forms.TextBox();
            this.co_B = new System.Windows.Forms.TextBox();
            this.ci_B = new System.Windows.Forms.TextBox();
            this.so_B = new System.Windows.Forms.TextBox();
            this.si_B = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calR_B = new System.Windows.Forms.TextBox();
            this.po_B = new System.Windows.Forms.TextBox();
            this.pi_B = new System.Windows.Forms.TextBox();
            this.jpmorgan_Btn = new System.Windows.Forms.Button();
            this.blackrock_Btn = new System.Windows.Forms.Button();
            this.ubs_btn = new System.Windows.Forms.Button();
            this.fillshare_Btn = new System.Windows.Forms.Button();
            this.bgbb = new System.ComponentModel.BackgroundWorker();
            this.waterlevel_btn = new System.Windows.Forms.Button();
            this.focus_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.remark_GB.SuspendLayout();
            this.fee_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 23);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(797, 215);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // exit_Btn
            // 
            this.exit_Btn.Location = new System.Drawing.Point(1087, 731);
            this.exit_Btn.Name = "exit_Btn";
            this.exit_Btn.Size = new System.Drawing.Size(75, 25);
            this.exit_Btn.TabIndex = 2;
            this.exit_Btn.Text = "Done";
            this.exit_Btn.UseVisualStyleBackColor = true;
            this.exit_Btn.Click += new System.EventHandler(this.exit_Btn_Click);
            // 
            // rsi_Btn
            // 
            this.rsi_Btn.Location = new System.Drawing.Point(366, 389);
            this.rsi_Btn.Name = "rsi_Btn";
            this.rsi_Btn.Size = new System.Drawing.Size(153, 53);
            this.rsi_Btn.TabIndex = 5;
            this.rsi_Btn.Text = "RSI";
            this.rsi_Btn.UseVisualStyleBackColor = true;
            this.rsi_Btn.Click += new System.EventHandler(this.rsi_Btn_Click);
            // 
            // remarks_RB
            // 
            this.remarks_RB.Location = new System.Drawing.Point(809, 23);
            this.remarks_RB.Name = "remarks_RB";
            this.remarks_RB.Size = new System.Drawing.Size(335, 190);
            this.remarks_RB.TabIndex = 7;
            this.remarks_RB.Text = "";
            // 
            // stock_B
            // 
            this.stock_B.Location = new System.Drawing.Point(106, 389);
            this.stock_B.Name = "stock_B";
            this.stock_B.Size = new System.Drawing.Size(254, 20);
            this.stock_B.TabIndex = 1;
            this.stock_B.TextChanged += new System.EventHandler(this.stock_B_TextChanged);
            this.stock_B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stock_B_KeyDown);
            this.stock_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stock_B_KeyPress);
            this.stock_B.Leave += new System.EventHandler(this.stock_B_Leave);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(6, 23);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(807, 360);
            this.dgv2.TabIndex = 9;
            this.dgv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellClick);
            this.dgv2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellValueChanged);
            // 
            // srsi_B
            // 
            this.srsi_B.Location = new System.Drawing.Point(525, 389);
            this.srsi_B.Name = "srsi_B";
            this.srsi_B.Size = new System.Drawing.Size(126, 53);
            this.srsi_B.TabIndex = 10;
            this.srsi_B.Text = "SingleRSI";
            this.srsi_B.UseVisualStyleBackColor = true;
            this.srsi_B.Click += new System.EventHandler(this.srsi_B_Click);
            // 
            // ignore_Btn
            // 
            this.ignore_Btn.Location = new System.Drawing.Point(657, 408);
            this.ignore_Btn.Name = "ignore_Btn";
            this.ignore_Btn.Size = new System.Drawing.Size(87, 34);
            this.ignore_Btn.TabIndex = 11;
            this.ignore_Btn.Text = "Ignore";
            this.ignore_Btn.UseVisualStyleBackColor = true;
            this.ignore_Btn.Click += new System.EventHandler(this.ignore_Btn_Click);
            // 
            // revive_Btn
            // 
            this.revive_Btn.Location = new System.Drawing.Point(245, 419);
            this.revive_Btn.Name = "revive_Btn";
            this.revive_Btn.Size = new System.Drawing.Size(89, 54);
            this.revive_Btn.TabIndex = 12;
            this.revive_Btn.Text = "Prompt Type Net";
            this.revive_Btn.UseVisualStyleBackColor = true;
            this.revive_Btn.Click += new System.EventHandler(this.revive_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(6, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "STOCK NUMBER";
            // 
            // pe_Btn
            // 
            this.pe_Btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pe_Btn.Location = new System.Drawing.Point(1012, 220);
            this.pe_Btn.Name = "pe_Btn";
            this.pe_Btn.Size = new System.Drawing.Size(132, 34);
            this.pe_Btn.TabIndex = 14;
            this.pe_Btn.Text = "Pop!";
            this.pe_Btn.UseVisualStyleBackColor = true;
            this.pe_Btn.Click += new System.EventHandler(this.pe_Btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.el_CB);
            this.groupBox1.Controls.Add(this.searchType_Btn);
            this.groupBox1.Controls.Add(this.type_L);
            this.groupBox1.Controls.Add(this.type_B);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rsi_Btn);
            this.groupBox1.Controls.Add(this.stock_B);
            this.groupBox1.Controls.Add(this.dgv2);
            this.groupBox1.Controls.Add(this.srsi_B);
            this.groupBox1.Controls.Add(this.ignore_Btn);
            this.groupBox1.Controls.Add(this.revive_Btn);
            this.groupBox1.ForeColor = System.Drawing.Color.Olive;
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(821, 480);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jackpot";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(366, 448);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(449, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // el_CB
            // 
            this.el_CB.Font = new System.Drawing.Font("PMingLiU", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.el_CB.FormattingEnabled = true;
            this.el_CB.Location = new System.Drawing.Point(41, 450);
            this.el_CB.Name = "el_CB";
            this.el_CB.Size = new System.Drawing.Size(110, 23);
            this.el_CB.TabIndex = 22;
            this.el_CB.SelectedIndexChanged += new System.EventHandler(this.el_CB_SelectedIndexChanged);
            // 
            // searchType_Btn
            // 
            this.searchType_Btn.Location = new System.Drawing.Point(157, 419);
            this.searchType_Btn.Name = "searchType_Btn";
            this.searchType_Btn.Size = new System.Drawing.Size(82, 54);
            this.searchType_Btn.TabIndex = 16;
            this.searchType_Btn.Text = "Search";
            this.searchType_Btn.UseVisualStyleBackColor = true;
            this.searchType_Btn.Click += new System.EventHandler(this.searchType_Btn_Click);
            // 
            // type_L
            // 
            this.type_L.AutoSize = true;
            this.type_L.Location = new System.Drawing.Point(6, 423);
            this.type_L.Name = "type_L";
            this.type_L.Size = new System.Drawing.Size(31, 13);
            this.type_L.TabIndex = 15;
            this.type_L.Text = "Type";
            // 
            // type_B
            // 
            this.type_B.Location = new System.Drawing.Point(41, 419);
            this.type_B.Name = "type_B";
            this.type_B.Size = new System.Drawing.Size(110, 20);
            this.type_B.TabIndex = 2;
            this.type_B.TextChanged += new System.EventHandler(this.type_B_TextChanged);
            this.type_B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.type_B_KeyDown);
            // 
            // remark_GB
            // 
            this.remark_GB.Controls.Add(this.udv_Btn);
            this.remark_GB.Controls.Add(this.dgv1);
            this.remark_GB.Controls.Add(this.remarks_RB);
            this.remark_GB.Controls.Add(this.pe_Btn);
            this.remark_GB.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remark_GB.ForeColor = System.Drawing.Color.MediumBlue;
            this.remark_GB.Location = new System.Drawing.Point(12, 13);
            this.remark_GB.Name = "remark_GB";
            this.remark_GB.Size = new System.Drawing.Size(1150, 260);
            this.remark_GB.TabIndex = 18;
            this.remark_GB.TabStop = false;
            this.remark_GB.Text = "Remarks";
            this.remark_GB.Enter += new System.EventHandler(this.remark_GB_Enter);
            // 
            // udv_Btn
            // 
            this.udv_Btn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udv_Btn.Location = new System.Drawing.Point(874, 220);
            this.udv_Btn.Name = "udv_Btn";
            this.udv_Btn.Size = new System.Drawing.Size(132, 34);
            this.udv_Btn.TabIndex = 15;
            this.udv_Btn.Text = "Update!";
            this.udv_Btn.UseVisualStyleBackColor = true;
            this.udv_Btn.Click += new System.EventHandler(this.udv_Btn_Click);
            // 
            // refresh_Btn
            // 
            this.refresh_Btn.Location = new System.Drawing.Point(839, 280);
            this.refresh_Btn.Name = "refresh_Btn";
            this.refresh_Btn.Size = new System.Drawing.Size(75, 25);
            this.refresh_Btn.TabIndex = 20;
            this.refresh_Btn.Text = "Refresh";
            this.refresh_Btn.UseVisualStyleBackColor = true;
            this.refresh_Btn.Click += new System.EventHandler(this.refresh_Btn_Click);
            // 
            // ans_Btn
            // 
            this.ans_Btn.Location = new System.Drawing.Point(839, 342);
            this.ans_Btn.Name = "ans_Btn";
            this.ans_Btn.Size = new System.Drawing.Size(75, 46);
            this.ans_Btn.TabIndex = 21;
            this.ans_Btn.Text = "Add new stock";
            this.ans_Btn.UseVisualStyleBackColor = true;
            this.ans_Btn.Click += new System.EventHandler(this.ans_Btn_Click);
            // 
            // trend_Btn
            // 
            this.trend_Btn.Location = new System.Drawing.Point(839, 311);
            this.trend_Btn.Name = "trend_Btn";
            this.trend_Btn.Size = new System.Drawing.Size(75, 25);
            this.trend_Btn.TabIndex = 22;
            this.trend_Btn.Text = "Trend";
            this.trend_Btn.UseVisualStyleBackColor = true;
            this.trend_Btn.Click += new System.EventHandler(this.trend_Btn_Click);
            // 
            // bg1
            // 
            this.bg1.WorkerReportsProgress = true;
            this.bg1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fillCounter);
            this.bg1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg1_ProgressChanged);
            // 
            // moc_Btn
            // 
            this.moc_Btn.Location = new System.Drawing.Point(1075, 279);
            this.moc_Btn.Name = "moc_Btn";
            this.moc_Btn.Size = new System.Drawing.Size(87, 34);
            this.moc_Btn.TabIndex = 23;
            this.moc_Btn.Text = "MOC";
            this.moc_Btn.UseVisualStyleBackColor = true;
            this.moc_Btn.Click += new System.EventHandler(this.moc_Btn_Click);
            // 
            // hsi_Btn
            // 
            this.hsi_Btn.Location = new System.Drawing.Point(1075, 319);
            this.hsi_Btn.Name = "hsi_Btn";
            this.hsi_Btn.Size = new System.Drawing.Size(87, 34);
            this.hsi_Btn.TabIndex = 24;
            this.hsi_Btn.Text = "HSI";
            this.hsi_Btn.UseVisualStyleBackColor = true;
            this.hsi_Btn.Click += new System.EventHandler(this.hsi_Btn_Click);
            // 
            // ml_Btn
            // 
            this.ml_Btn.Location = new System.Drawing.Point(839, 721);
            this.ml_Btn.Name = "ml_Btn";
            this.ml_Btn.Size = new System.Drawing.Size(179, 34);
            this.ml_Btn.TabIndex = 25;
            this.ml_Btn.Text = "Machine Learning";
            this.ml_Btn.UseVisualStyleBackColor = true;
            this.ml_Btn.Click += new System.EventHandler(this.ml_Btn_Click);
            // 
            // hsbc_Btn
            // 
            this.hsbc_Btn.Location = new System.Drawing.Point(839, 669);
            this.hsbc_Btn.Name = "hsbc_Btn";
            this.hsbc_Btn.Size = new System.Drawing.Size(75, 46);
            this.hsbc_Btn.TabIndex = 26;
            this.hsbc_Btn.Text = "HSBC";
            this.hsbc_Btn.UseVisualStyleBackColor = true;
            this.hsbc_Btn.Click += new System.EventHandler(this.hsbc_Btn_Click);
            // 
            // zzBtn
            // 
            this.zzBtn.Location = new System.Drawing.Point(243, 159);
            this.zzBtn.Name = "zzBtn";
            this.zzBtn.Size = new System.Drawing.Size(75, 31);
            this.zzBtn.TabIndex = 32;
            this.zzBtn.Text = "Get Cost";
            this.zzBtn.UseVisualStyleBackColor = true;
            this.zzBtn.Click += new System.EventHandler(this.zzBtn_Click);
            // 
            // v1_B
            // 
            this.v1_B.Location = new System.Drawing.Point(920, 283);
            this.v1_B.Name = "v1_B";
            this.v1_B.Size = new System.Drawing.Size(100, 20);
            this.v1_B.TabIndex = 28;
            this.v1_B.TextChanged += new System.EventHandler(this.v1v2_cal);
            // 
            // v2_B
            // 
            this.v2_B.Location = new System.Drawing.Point(920, 309);
            this.v2_B.Name = "v2_B";
            this.v2_B.Size = new System.Drawing.Size(100, 20);
            this.v2_B.TabIndex = 29;
            this.v2_B.TextChanged += new System.EventHandler(this.v1v2_cal);
            // 
            // sym_CB
            // 
            this.sym_CB.FormattingEnabled = true;
            this.sym_CB.Items.AddRange(new object[] {
            "+",
            "-"});
            this.sym_CB.Location = new System.Drawing.Point(920, 335);
            this.sym_CB.Name = "sym_CB";
            this.sym_CB.Size = new System.Drawing.Size(40, 21);
            this.sym_CB.TabIndex = 30;
            this.sym_CB.SelectedIndexChanged += new System.EventHandler(this.v1v2_cal);
            // 
            // res_L
            // 
            this.res_L.AutoSize = true;
            this.res_L.Location = new System.Drawing.Point(966, 338);
            this.res_L.Name = "res_L";
            this.res_L.Size = new System.Drawing.Size(0, 13);
            this.res_L.TabIndex = 31;
            // 
            // fee_GB
            // 
            this.fee_GB.Controls.Add(this.lo_B);
            this.fee_GB.Controls.Add(this.li_B);
            this.fee_GB.Controls.Add(this.co_B);
            this.fee_GB.Controls.Add(this.ci_B);
            this.fee_GB.Controls.Add(this.so_B);
            this.fee_GB.Controls.Add(this.si_B);
            this.fee_GB.Controls.Add(this.label3);
            this.fee_GB.Controls.Add(this.label2);
            this.fee_GB.Controls.Add(this.calR_B);
            this.fee_GB.Controls.Add(this.po_B);
            this.fee_GB.Controls.Add(this.pi_B);
            this.fee_GB.Controls.Add(this.zzBtn);
            this.fee_GB.Location = new System.Drawing.Point(839, 467);
            this.fee_GB.Name = "fee_GB";
            this.fee_GB.Size = new System.Drawing.Size(317, 196);
            this.fee_GB.TabIndex = 32;
            this.fee_GB.TabStop = false;
            this.fee_GB.Text = "Broker Charge";
            // 
            // lo_B
            // 
            this.lo_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lo_B.Location = new System.Drawing.Point(185, 79);
            this.lo_B.Name = "lo_B";
            this.lo_B.ReadOnly = true;
            this.lo_B.Size = new System.Drawing.Size(125, 26);
            this.lo_B.TabIndex = 57;
            // 
            // li_B
            // 
            this.li_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.li_B.Location = new System.Drawing.Point(9, 79);
            this.li_B.Name = "li_B";
            this.li_B.Size = new System.Drawing.Size(125, 26);
            this.li_B.TabIndex = 30;
            this.li_B.TextChanged += new System.EventHandler(this.li_B_TextChanged);
            // 
            // co_B
            // 
            this.co_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co_B.Location = new System.Drawing.Point(185, 111);
            this.co_B.Name = "co_B";
            this.co_B.ReadOnly = true;
            this.co_B.Size = new System.Drawing.Size(125, 26);
            this.co_B.TabIndex = 53;
            // 
            // ci_B
            // 
            this.ci_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ci_B.Location = new System.Drawing.Point(9, 111);
            this.ci_B.Name = "ci_B";
            this.ci_B.ReadOnly = true;
            this.ci_B.Size = new System.Drawing.Size(125, 26);
            this.ci_B.TabIndex = 54;
            this.ci_B.TextChanged += new System.EventHandler(this.ci_B_TextChanged);
            // 
            // so_B
            // 
            this.so_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.so_B.Location = new System.Drawing.Point(185, 47);
            this.so_B.Name = "so_B";
            this.so_B.ReadOnly = true;
            this.so_B.Size = new System.Drawing.Size(125, 26);
            this.so_B.TabIndex = 76;
            // 
            // si_B
            // 
            this.si_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.si_B.Location = new System.Drawing.Point(9, 47);
            this.si_B.Name = "si_B";
            this.si_B.ReadOnly = true;
            this.si_B.Size = new System.Drawing.Size(125, 26);
            this.si_B.TabIndex = 77;
            this.si_B.TextChanged += new System.EventHandler(this.hi_B_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "-->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "+   -";
            // 
            // calR_B
            // 
            this.calR_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calR_B.Location = new System.Drawing.Point(44, 160);
            this.calR_B.Name = "calR_B";
            this.calR_B.ReadOnly = true;
            this.calR_B.Size = new System.Drawing.Size(193, 30);
            this.calR_B.TabIndex = 55;
            // 
            // po_B
            // 
            this.po_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.po_B.Location = new System.Drawing.Point(186, 15);
            this.po_B.Name = "po_B";
            this.po_B.Size = new System.Drawing.Size(125, 26);
            this.po_B.TabIndex = 29;
            // 
            // pi_B
            // 
            this.pi_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pi_B.Location = new System.Drawing.Point(9, 15);
            this.pi_B.Name = "pi_B";
            this.pi_B.Size = new System.Drawing.Size(125, 26);
            this.pi_B.TabIndex = 28;
            this.pi_B.TextChanged += new System.EventHandler(this.pi_B_TextChanged);
            // 
            // jpmorgan_Btn
            // 
            this.jpmorgan_Btn.Location = new System.Drawing.Point(839, 438);
            this.jpmorgan_Btn.Name = "jpmorgan_Btn";
            this.jpmorgan_Btn.Size = new System.Drawing.Size(75, 23);
            this.jpmorgan_Btn.TabIndex = 33;
            this.jpmorgan_Btn.Text = "JPMorgan";
            this.jpmorgan_Btn.UseVisualStyleBackColor = true;
            this.jpmorgan_Btn.Click += new System.EventHandler(this.jpmorgan_Btn_Click);
            // 
            // blackrock_Btn
            // 
            this.blackrock_Btn.Location = new System.Drawing.Point(920, 438);
            this.blackrock_Btn.Name = "blackrock_Btn";
            this.blackrock_Btn.Size = new System.Drawing.Size(75, 23);
            this.blackrock_Btn.TabIndex = 34;
            this.blackrock_Btn.Text = "BlackRock";
            this.blackrock_Btn.UseVisualStyleBackColor = true;
            this.blackrock_Btn.Click += new System.EventHandler(this.blackrock_Btn_Click);
            // 
            // ubs_btn
            // 
            this.ubs_btn.Location = new System.Drawing.Point(1001, 439);
            this.ubs_btn.Name = "ubs_btn";
            this.ubs_btn.Size = new System.Drawing.Size(100, 23);
            this.ubs_btn.TabIndex = 35;
            this.ubs_btn.Text = "Morgan Stanley";
            this.ubs_btn.UseVisualStyleBackColor = true;
            this.ubs_btn.Click += new System.EventHandler(this.ubs_btn_Click);
            // 
            // fillshare_Btn
            // 
            this.fillshare_Btn.Location = new System.Drawing.Point(839, 409);
            this.fillshare_Btn.Name = "fillshare_Btn";
            this.fillshare_Btn.Size = new System.Drawing.Size(75, 23);
            this.fillshare_Btn.TabIndex = 36;
            this.fillshare_Btn.Text = "Fill Share";
            this.fillshare_Btn.UseVisualStyleBackColor = true;
            this.fillshare_Btn.Click += new System.EventHandler(this.fillshare_Btn_Click);
            // 
            // bgbb
            // 
            this.bgbb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgb);
            // 
            // waterlevel_btn
            // 
            this.waterlevel_btn.Location = new System.Drawing.Point(1075, 359);
            this.waterlevel_btn.Name = "waterlevel_btn";
            this.waterlevel_btn.Size = new System.Drawing.Size(87, 34);
            this.waterlevel_btn.TabIndex = 37;
            this.waterlevel_btn.Text = "Water Level";
            this.waterlevel_btn.UseVisualStyleBackColor = true;
            this.waterlevel_btn.Click += new System.EventHandler(this.waterlevel_btn_Click);
            // 
            // focus_Btn
            // 
            this.focus_Btn.Location = new System.Drawing.Point(1075, 399);
            this.focus_Btn.Name = "focus_Btn";
            this.focus_Btn.Size = new System.Drawing.Size(87, 34);
            this.focus_Btn.TabIndex = 38;
            this.focus_Btn.Text = "Focus";
            this.focus_Btn.UseVisualStyleBackColor = true;
            this.focus_Btn.Click += new System.EventHandler(this.focus_Btn_Click);
            // 
            // enter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 769);
            this.Controls.Add(this.focus_Btn);
            this.Controls.Add(this.waterlevel_btn);
            this.Controls.Add(this.fillshare_Btn);
            this.Controls.Add(this.ubs_btn);
            this.Controls.Add(this.blackrock_Btn);
            this.Controls.Add(this.jpmorgan_Btn);
            this.Controls.Add(this.fee_GB);
            this.Controls.Add(this.res_L);
            this.Controls.Add(this.sym_CB);
            this.Controls.Add(this.v2_B);
            this.Controls.Add(this.v1_B);
            this.Controls.Add(this.hsbc_Btn);
            this.Controls.Add(this.ml_Btn);
            this.Controls.Add(this.hsi_Btn);
            this.Controls.Add(this.moc_Btn);
            this.Controls.Add(this.trend_Btn);
            this.Controls.Add(this.ans_Btn);
            this.Controls.Add(this.refresh_Btn);
            this.Controls.Add(this.remark_GB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exit_Btn);
            this.Name = "enter";
            this.Text = "Maximumgain";
            this.Load += new System.EventHandler(this.enter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.remark_GB.ResumeLayout(false);
            this.fee_GB.ResumeLayout(false);
            this.fee_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button exit_Btn;
        private System.Windows.Forms.Button rsi_Btn;
        private System.Windows.Forms.RichTextBox remarks_RB;
        private System.Windows.Forms.TextBox stock_B;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button srsi_B;
        private System.Windows.Forms.Button ignore_Btn;
        private System.Windows.Forms.Button revive_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pe_Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox remark_GB;
        private System.Windows.Forms.Label type_L;
        private System.Windows.Forms.TextBox type_B;
        private System.Windows.Forms.Button udv_Btn;
        private System.Windows.Forms.Button refresh_Btn;
        private System.Windows.Forms.Button searchType_Btn;
        private System.Windows.Forms.Button ans_Btn;
        private System.Windows.Forms.ComboBox el_CB;
        private System.Windows.Forms.Button trend_Btn;
        private System.ComponentModel.BackgroundWorker bg1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button moc_Btn;
        private System.Windows.Forms.Button hsi_Btn;
        private System.Windows.Forms.Button ml_Btn;
        private System.Windows.Forms.Button hsbc_Btn;
        private System.Windows.Forms.Button zzBtn;
        private System.Windows.Forms.TextBox v1_B;
        private System.Windows.Forms.TextBox v2_B;
        private System.Windows.Forms.ComboBox sym_CB;
        private System.Windows.Forms.Label res_L;
        private System.Windows.Forms.GroupBox fee_GB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox calR_B;
        private System.Windows.Forms.TextBox po_B;
        private System.Windows.Forms.TextBox pi_B;
        private System.Windows.Forms.TextBox so_B;
        private System.Windows.Forms.TextBox si_B;
        private System.Windows.Forms.TextBox co_B;
        private System.Windows.Forms.TextBox ci_B;
        private System.Windows.Forms.Button jpmorgan_Btn;
        private System.Windows.Forms.Button blackrock_Btn;
        private System.Windows.Forms.Button ubs_btn;
        private System.Windows.Forms.Button fillshare_Btn;
        private System.ComponentModel.BackgroundWorker bgbb;
        private System.Windows.Forms.TextBox lo_B;
        private System.Windows.Forms.TextBox li_B;
        private System.Windows.Forms.Button waterlevel_btn;
        private System.Windows.Forms.Button focus_Btn;
    }
}

