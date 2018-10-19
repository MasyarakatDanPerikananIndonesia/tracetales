namespace Tallyfish
{
    partial class frmVessel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVessel));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupFishingGear = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnsavegear = new System.Windows.Forms.Button();
            this.txtgear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FishingGear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cbfishing_ground = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbFishingGear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtflag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.suppname = new System.Windows.Forms.Label();
            this.suppcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtvesselsize = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtvesselname = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtvesselregno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfisherman = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vesselname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VesselSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VesselRegno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VesselYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ground = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisherman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupFishingGear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1328, 702);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Vesselname,
            this.VesselSize,
            this.VesselRegno,
            this.VesselYear,
            this.gear,
            this.ground,
            this.Fisherman});
            this.dataGridView1.Location = new System.Drawing.Point(419, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(853, 647);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.btnback);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(416, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 40);
            this.panel4.TabIndex = 5;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(763, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 27;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(348, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "VESSEL LIST";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.txtfisherman);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.groupFishingGear);
            this.panel2.Controls.Add(this.cbfishing_ground);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.rbNo);
            this.panel2.Controls.Add(this.rbYes);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.cbFishingGear);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.txtflag);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtvesselsize);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtvesselname);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtvesselregno);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 696);
            this.panel2.TabIndex = 4;
            // 
            // groupFishingGear
            // 
            this.groupFishingGear.Controls.Add(this.button3);
            this.groupFishingGear.Controls.Add(this.btnsavegear);
            this.groupFishingGear.Controls.Add(this.txtgear);
            this.groupFishingGear.Controls.Add(this.label9);
            this.groupFishingGear.Controls.Add(this.dataGridView2);
            this.groupFishingGear.Controls.Add(this.panel5);
            this.groupFishingGear.Location = new System.Drawing.Point(13, 375);
            this.groupFishingGear.Name = "groupFishingGear";
            this.groupFishingGear.Size = new System.Drawing.Size(374, 315);
            this.groupFishingGear.TabIndex = 64;
            this.groupFishingGear.TabStop = false;
            this.groupFishingGear.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Location = new System.Drawing.Point(122, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 50);
            this.button3.TabIndex = 57;
            this.button3.Text = "Done";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnsavegear
            // 
            this.btnsavegear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsavegear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsavegear.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsavegear.Location = new System.Drawing.Point(243, 261);
            this.btnsavegear.Name = "btnsavegear";
            this.btnsavegear.Size = new System.Drawing.Size(123, 50);
            this.btnsavegear.TabIndex = 56;
            this.btnsavegear.Text = "Save";
            this.btnsavegear.UseVisualStyleBackColor = false;
            this.btnsavegear.Click += new System.EventHandler(this.btnsavegear_Click);
            // 
            // txtgear
            // 
            this.txtgear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtgear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgear.Location = new System.Drawing.Point(138, 234);
            this.txtgear.Name = "txtgear";
            this.txtgear.Size = new System.Drawing.Size(227, 24);
            this.txtgear.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(6, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 18);
            this.label9.TabIndex = 54;
            this.label9.Text = "New Fishing Gear";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.FishingGear});
            this.dataGridView2.Location = new System.Drawing.Point(6, 57);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(362, 169);
            this.dataGridView2.TabIndex = 53;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            // 
            // Seq
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Seq.DefaultCellStyle = dataGridViewCellStyle5;
            this.Seq.HeaderText = "No";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.Width = 60;
            // 
            // FishingGear
            // 
            this.FishingGear.HeaderText = "Fishing Gear";
            this.FishingGear.Name = "FishingGear";
            this.FishingGear.ReadOnly = true;
            this.FishingGear.Width = 220;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.label11);
            this.panel5.Location = new System.Drawing.Point(0, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 43);
            this.panel5.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(128, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "FISHING GEAR";
            // 
            // cbfishing_ground
            // 
            this.cbfishing_ground.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbfishing_ground.FormattingEnabled = true;
            this.cbfishing_ground.Items.AddRange(new object[] {
            "Bitung"});
            this.cbfishing_ground.Location = new System.Drawing.Point(168, 290);
            this.cbfishing_ground.Name = "cbfishing_ground";
            this.cbfishing_ground.Size = new System.Drawing.Size(178, 24);
            this.cbfishing_ground.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(59, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 62;
            this.label8.Text = "Fishing Ground";
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Checked = true;
            this.rbNo.Location = new System.Drawing.Point(241, 267);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(41, 17);
            this.rbNo.TabIndex = 61;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "NO";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(172, 267);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(46, 17);
            this.rbYes.TabIndex = 60;
            this.rbYes.Text = "YES";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(10, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "Fish Aggregate Device";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 29);
            this.button2.TabIndex = 58;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbFishingGear
            // 
            this.cbFishingGear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFishingGear.FormattingEnabled = true;
            this.cbFishingGear.Items.AddRange(new object[] {
            "Bitung"});
            this.cbFishingGear.Location = new System.Drawing.Point(168, 239);
            this.cbFishingGear.Name = "cbFishingGear";
            this.cbFishingGear.Size = new System.Drawing.Size(178, 24);
            this.cbFishingGear.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(78, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 56;
            this.label6.Text = "Fishing Gear";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(169, 210);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(218, 23);
            this.dateTimePicker1.TabIndex = 55;
            // 
            // txtflag
            // 
            this.txtflag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtflag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtflag.Location = new System.Drawing.Point(170, 151);
            this.txtflag.Name = "txtflag";
            this.txtflag.Size = new System.Drawing.Size(217, 24);
            this.txtflag.TabIndex = 54;
            this.txtflag.Text = "INDONESIA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(79, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Vessel Flag *";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(168, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 62);
            this.button1.TabIndex = 52;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.suppname);
            this.panel1.Controls.Add(this.suppcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 43);
            this.panel1.TabIndex = 51;
            // 
            // suppname
            // 
            this.suppname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.suppname.AutoSize = true;
            this.suppname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.suppname.Location = new System.Drawing.Point(105, 24);
            this.suppname.Name = "suppname";
            this.suppname.Size = new System.Drawing.Size(10, 15);
            this.suppname.TabIndex = 3;
            this.suppname.Text = ".";
            this.suppname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // suppcode
            // 
            this.suppcode.AutoSize = true;
            this.suppcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppcode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.suppcode.Location = new System.Drawing.Point(3, 21);
            this.suppcode.Name = "suppcode";
            this.suppcode.Size = new System.Drawing.Size(13, 20);
            this.suppcode.TabIndex = 2;
            this.suppcode.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(111, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "VESSEL SETUP";
            // 
            // txtvesselsize
            // 
            this.txtvesselsize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtvesselsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvesselsize.Location = new System.Drawing.Point(169, 121);
            this.txtvesselsize.Name = "txtvesselsize";
            this.txtvesselsize.Size = new System.Drawing.Size(217, 24);
            this.txtvesselsize.TabIndex = 50;
            this.txtvesselsize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvesselsize_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(78, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 18);
            this.label12.TabIndex = 49;
            this.label12.Text = "Vessel Size *";
            // 
            // txtvesselname
            // 
            this.txtvesselname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtvesselname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvesselname.Location = new System.Drawing.Point(169, 91);
            this.txtvesselname.Name = "txtvesselname";
            this.txtvesselname.Size = new System.Drawing.Size(217, 24);
            this.txtvesselname.TabIndex = 30;
            this.txtvesselname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvesselname_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(66, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "Vessel Name *";
            // 
            // txtvesselregno
            // 
            this.txtvesselregno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtvesselregno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvesselregno.Location = new System.Drawing.Point(170, 180);
            this.txtvesselregno.Name = "txtvesselregno";
            this.txtvesselregno.Size = new System.Drawing.Size(217, 24);
            this.txtvesselregno.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(71, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Expired Date ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(52, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Registration No";
            // 
            // txtfisherman
            // 
            this.txtfisherman.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfisherman.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfisherman.Location = new System.Drawing.Point(169, 61);
            this.txtfisherman.Name = "txtfisherman";
            this.txtfisherman.Size = new System.Drawing.Size(217, 24);
            this.txtfisherman.TabIndex = 68;
            this.txtfisherman.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfisherman_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(22, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 18);
            this.label10.TabIndex = 67;
            this.label10.Text = "Fisherman / Nelayan*";
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // Vesselname
            // 
            this.Vesselname.HeaderText = "Vessel Name";
            this.Vesselname.Name = "Vesselname";
            this.Vesselname.Width = 180;
            // 
            // VesselSize
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VesselSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.VesselSize.HeaderText = "Vessel Size";
            this.VesselSize.Name = "VesselSize";
            this.VesselSize.Width = 80;
            // 
            // VesselRegno
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VesselRegno.DefaultCellStyle = dataGridViewCellStyle3;
            this.VesselRegno.HeaderText = "Vessel Reg No";
            this.VesselRegno.Name = "VesselRegno";
            this.VesselRegno.Width = 90;
            // 
            // VesselYear
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.VesselYear.DefaultCellStyle = dataGridViewCellStyle4;
            this.VesselYear.HeaderText = "Expired Date";
            this.VesselYear.Name = "VesselYear";
            this.VesselYear.Width = 90;
            // 
            // gear
            // 
            this.gear.HeaderText = "Fishing Gear";
            this.gear.Name = "gear";
            this.gear.Width = 80;
            // 
            // ground
            // 
            this.ground.HeaderText = "Fishing Ground";
            this.ground.Name = "ground";
            this.ground.Width = 80;
            // 
            // Fisherman
            // 
            this.Fisherman.HeaderText = "Fisherman";
            this.Fisherman.Name = "Fisherman";
            // 
            // frmVessel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 708);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVessel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVessel_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupFishingGear.ResumeLayout(false);
            this.groupFishingGear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvesselsize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtvesselname;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtvesselregno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label suppcode;
        private System.Windows.Forms.Label suppname;
        private System.Windows.Forms.TextBox txtflag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbFishingGear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbfishing_ground;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupFishingGear;
        private System.Windows.Forms.TextBox txtgear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnsavegear;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn FishingGear;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vesselname;
        private System.Windows.Forms.DataGridViewTextBoxColumn VesselSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn VesselRegno;
        private System.Windows.Forms.DataGridViewTextBoxColumn VesselYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ground;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fisherman;
        private System.Windows.Forms.TextBox txtfisherman;
        private System.Windows.Forms.Label label10;

    }
}