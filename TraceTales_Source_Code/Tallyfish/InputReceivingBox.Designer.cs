namespace Tallyfish
{
    partial class InputReceivingBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputReceivingBox));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblmessage = new System.Windows.Forms.Label();
            this.lblweight = new System.Windows.Forms.Label();
            this.lblrcvno = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblcase = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntLotCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RcvNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtscan = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbentry = new System.Windows.Forms.GroupBox();
            this.btnrcv = new System.Windows.Forms.Button();
            this.btnaddcompany = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnrecent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbreceiving_recent = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbreceived = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_entry_rcvbox = new System.Windows.Forms.Button();
            this.panelProcessingCompany = new System.Windows.Forms.Panel();
            this.dgprocessingcompany = new System.Windows.Forms.DataGridView();
            this.No1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcompanyname = new System.Windows.Forms.TextBox();
            this.txtcocode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbentry.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelProcessingCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgprocessingcompany)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1272, 40);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1178, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 29;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(543, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "RECEIVING BOX";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblmessage);
            this.panel1.Controls.Add(this.lblweight);
            this.panel1.Controls.Add(this.lblrcvno);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblcase);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.txtscan);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(56, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 556);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // lblmessage
            // 
            this.lblmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmessage.ForeColor = System.Drawing.Color.Red;
            this.lblmessage.Location = new System.Drawing.Point(730, 39);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(471, 56);
            this.lblmessage.TabIndex = 20;
            this.lblmessage.Text = "-";
            // 
            // lblweight
            // 
            this.lblweight.AutoSize = true;
            this.lblweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblweight.Location = new System.Drawing.Point(448, 531);
            this.lblweight.Name = "lblweight";
            this.lblweight.Size = new System.Drawing.Size(13, 20);
            this.lblweight.TabIndex = 9;
            this.lblweight.Text = ".";
            // 
            // lblrcvno
            // 
            this.lblrcvno.AutoSize = true;
            this.lblrcvno.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrcvno.Location = new System.Drawing.Point(921, 9);
            this.lblrcvno.Name = "lblrcvno";
            this.lblrcvno.Size = new System.Drawing.Size(20, 29);
            this.lblrcvno.TabIndex = 19;
            this.lblrcvno.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(311, 531);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Total Weight(Kg) :";
            // 
            // lblcase
            // 
            this.lblcase.AutoSize = true;
            this.lblcase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcase.Location = new System.Drawing.Point(117, 531);
            this.lblcase.Name = "lblcase";
            this.lblcase.Size = new System.Drawing.Size(13, 20);
            this.lblcase.TabIndex = 7;
            this.lblcase.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(793, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "Receiving No:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total Case :";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CaseNo,
            this.Grade,
            this.Size,
            this.BoxWeight,
            this.Pieces,
            this.IntLotCode,
            this.ExpDate,
            this.RcvNo});
            this.dataGridView1.Location = new System.Drawing.Point(17, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1112, 430);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // CaseNo
            // 
            this.CaseNo.HeaderText = "Case No";
            this.CaseNo.Name = "CaseNo";
            this.CaseNo.Width = 150;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // BoxWeight
            // 
            this.BoxWeight.HeaderText = "Box Weight (Kg)";
            this.BoxWeight.Name = "BoxWeight";
            // 
            // Pieces
            // 
            this.Pieces.HeaderText = "Pieces";
            this.Pieces.Name = "Pieces";
            // 
            // IntLotCode
            // 
            this.IntLotCode.HeaderText = "Int Lot Code";
            this.IntLotCode.Name = "IntLotCode";
            this.IntLotCode.Width = 150;
            // 
            // ExpDate
            // 
            this.ExpDate.HeaderText = "Exp Date";
            this.ExpDate.Name = "ExpDate";
            this.ExpDate.Width = 120;
            // 
            // RcvNo
            // 
            this.RcvNo.HeaderText = "Receiving No";
            this.RcvNo.Name = "RcvNo";
            this.RcvNo.Width = 160;
            // 
            // txtscan
            // 
            this.txtscan.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscan.Location = new System.Drawing.Point(242, 28);
            this.txtscan.Multiline = true;
            this.txtscan.Name = "txtscan";
            this.txtscan.Size = new System.Drawing.Size(482, 38);
            this.txtscan.TabIndex = 4;
            this.txtscan.TextChanged += new System.EventHandler(this.txtscan_TextChanged);
            this.txtscan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscan_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 31);
            this.label13.TabIndex = 3;
            this.label13.Text = "Scan Case Number :";
            // 
            // gbentry
            // 
            this.gbentry.Controls.Add(this.btnrcv);
            this.gbentry.Controls.Add(this.btnaddcompany);
            this.gbentry.Controls.Add(this.panel2);
            this.gbentry.Controls.Add(this.dateTimePicker1);
            this.gbentry.Controls.Add(this.button2);
            this.gbentry.Controls.Add(this.label4);
            this.gbentry.Controls.Add(this.txtreference);
            this.gbentry.Controls.Add(this.label3);
            this.gbentry.Controls.Add(this.cbreceived);
            this.gbentry.Controls.Add(this.label2);
            this.gbentry.Controls.Add(this.btn_entry_rcvbox);
            this.gbentry.Location = new System.Drawing.Point(111, 48);
            this.gbentry.Name = "gbentry";
            this.gbentry.Size = new System.Drawing.Size(632, 518);
            this.gbentry.TabIndex = 24;
            this.gbentry.TabStop = false;
            // 
            // btnrcv
            // 
            this.btnrcv.Location = new System.Drawing.Point(488, 66);
            this.btnrcv.Name = "btnrcv";
            this.btnrcv.Size = new System.Drawing.Size(48, 36);
            this.btnrcv.TabIndex = 31;
            this.btnrcv.UseVisualStyleBackColor = true;
            this.btnrcv.Click += new System.EventHandler(this.btnrcv_Click);
            this.btnrcv.Paint += new System.Windows.Forms.PaintEventHandler(this.btnrcv_Paint);
            // 
            // btnaddcompany
            // 
            this.btnaddcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddcompany.Location = new System.Drawing.Point(539, 64);
            this.btnaddcompany.Name = "btnaddcompany";
            this.btnaddcompany.Size = new System.Drawing.Size(66, 42);
            this.btnaddcompany.TabIndex = 30;
            this.btnaddcompany.Text = "+";
            this.btnaddcompany.UseVisualStyleBackColor = true;
            this.btnaddcompany.Click += new System.EventHandler(this.btnaddcompany_Click);
            this.btnaddcompany.Paint += new System.Windows.Forms.PaintEventHandler(this.btnaddcompany_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnrecent);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.cbreceiving_recent);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(31, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 163);
            this.panel2.TabIndex = 29;
            // 
            // btnrecent
            // 
            this.btnrecent.Location = new System.Drawing.Point(482, 34);
            this.btnrecent.Name = "btnrecent";
            this.btnrecent.Size = new System.Drawing.Size(48, 35);
            this.btnrecent.TabIndex = 32;
            this.btnrecent.UseVisualStyleBackColor = true;
            this.btnrecent.Click += new System.EventHandler(this.btnrecent_Click);
            this.btnrecent.Paint += new System.Windows.Forms.PaintEventHandler(this.btnrecent_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(203, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 70);
            this.button1.TabIndex = 28;
            this.button1.Text = "Open Receiving Box";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbreceiving_recent
            // 
            this.cbreceiving_recent.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbreceiving_recent.FormattingEnabled = true;
            this.cbreceiving_recent.Location = new System.Drawing.Point(203, 37);
            this.cbreceiving_recent.Name = "cbreceiving_recent";
            this.cbreceiving_recent.Size = new System.Drawing.Size(327, 31);
            this.cbreceiving_recent.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 26);
            this.label7.TabIndex = 24;
            this.label7.Text = "Recent Receiving";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 161);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(214, 29);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(197, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 70);
            this.button2.TabIndex = 27;
            this.button2.Text = "Create Receiving Box";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 26);
            this.label4.TabIndex = 26;
            this.label4.Text = "Received Date : ";
            // 
            // txtreference
            // 
            this.txtreference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(197, 114);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(221, 29);
            this.txtreference.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 26);
            this.label3.TabIndex = 24;
            this.label3.Text = "Reference # : ";
            // 
            // cbreceived
            // 
            this.cbreceived.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbreceived.FormattingEnabled = true;
            this.cbreceived.Location = new System.Drawing.Point(197, 69);
            this.cbreceived.Name = "cbreceived";
            this.cbreceived.Size = new System.Drawing.Size(338, 31);
            this.cbreceived.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "Received From : ";
            // 
            // btn_entry_rcvbox
            // 
            this.btn_entry_rcvbox.Location = new System.Drawing.Point(17, 19);
            this.btn_entry_rcvbox.Name = "btn_entry_rcvbox";
            this.btn_entry_rcvbox.Size = new System.Drawing.Size(598, 493);
            this.btn_entry_rcvbox.TabIndex = 21;
            this.btn_entry_rcvbox.UseVisualStyleBackColor = true;
            // 
            // panelProcessingCompany
            // 
            this.panelProcessingCompany.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelProcessingCompany.Controls.Add(this.dgprocessingcompany);
            this.panelProcessingCompany.Controls.Add(this.button4);
            this.panelProcessingCompany.Controls.Add(this.txtphone);
            this.panelProcessingCompany.Controls.Add(this.txtaddress);
            this.panelProcessingCompany.Controls.Add(this.txtcompanyname);
            this.panelProcessingCompany.Controls.Add(this.txtcocode);
            this.panelProcessingCompany.Controls.Add(this.label14);
            this.panelProcessingCompany.Controls.Add(this.label12);
            this.panelProcessingCompany.Controls.Add(this.label11);
            this.panelProcessingCompany.Controls.Add(this.label10);
            this.panelProcessingCompany.Controls.Add(this.panel4);
            this.panelProcessingCompany.Location = new System.Drawing.Point(749, 57);
            this.panelProcessingCompany.Name = "panelProcessingCompany";
            this.panelProcessingCompany.Size = new System.Drawing.Size(506, 443);
            this.panelProcessingCompany.TabIndex = 25;
            this.panelProcessingCompany.Visible = false;
            // 
            // dgprocessingcompany
            // 
            this.dgprocessingcompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgprocessingcompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No1,
            this.CoCode,
            this.CompanyName});
            this.dgprocessingcompany.Location = new System.Drawing.Point(6, 274);
            this.dgprocessingcompany.Name = "dgprocessingcompany";
            this.dgprocessingcompany.RowHeadersVisible = false;
            this.dgprocessingcompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgprocessingcompany.Size = new System.Drawing.Size(494, 165);
            this.dgprocessingcompany.TabIndex = 31;
            this.dgprocessingcompany.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgprocessingcompany_CellContentClick);
            this.dgprocessingcompany.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgprocessingcompany_CellPainting);
            // 
            // No1
            // 
            this.No1.HeaderText = "No";
            this.No1.Name = "No1";
            this.No1.Width = 60;
            // 
            // CoCode
            // 
            this.CoCode.HeaderText = "Co.Code";
            this.CoCode.Name = "CoCode";
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "Company Name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Width = 200;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(155, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 51);
            this.button4.TabIndex = 30;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.Location = new System.Drawing.Point(155, 185);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(155, 26);
            this.txtphone.TabIndex = 30;
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.Location = new System.Drawing.Point(155, 124);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(332, 54);
            this.txtaddress.TabIndex = 29;
            // 
            // txtcompanyname
            // 
            this.txtcompanyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcompanyname.Location = new System.Drawing.Point(156, 92);
            this.txtcompanyname.Name = "txtcompanyname";
            this.txtcompanyname.Size = new System.Drawing.Size(332, 26);
            this.txtcompanyname.TabIndex = 28;
            // 
            // txtcocode
            // 
            this.txtcocode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcocode.Location = new System.Drawing.Point(155, 60);
            this.txtcocode.Name = "txtcocode";
            this.txtcocode.Size = new System.Drawing.Size(57, 26);
            this.txtcocode.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(26, 184);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Phone :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 23);
            this.label12.TabIndex = 25;
            this.label12.Text = "Address :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Company Name :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Co.Code :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(506, 40);
            this.panel4.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(403, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 40);
            this.button5.TabIndex = 32;
            this.button5.Text = "Done";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(151, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "PROCESSING COMPANY";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(1264, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 37);
            this.button3.TabIndex = 29;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // InputReceivingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 681);
            this.Controls.Add(this.panelProcessingCompany);
            this.Controls.Add(this.gbentry);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputReceivingBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InputReceivingBox_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbentry.ResumeLayout(false);
            this.gbentry.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelProcessingCompany.ResumeLayout(false);
            this.panelProcessingCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgprocessingcompany)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtscan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblrcvno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbentry;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtreference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbreceived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_entry_rcvbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblweight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbreceiving_recent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pieces;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntLotCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RcvNo;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.Button btnaddcompany;
        private System.Windows.Forms.Panel panelProcessingCompany;
        private System.Windows.Forms.DataGridView dgprocessingcompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn No1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcompanyname;
        private System.Windows.Forms.TextBox txtcocode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnrcv;
        private System.Windows.Forms.Button btnrecent;
    }
}