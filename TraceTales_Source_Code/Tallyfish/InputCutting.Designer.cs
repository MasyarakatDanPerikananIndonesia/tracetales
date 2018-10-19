namespace Tallyfish
{
    partial class InputCutting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputCutting));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.lblmodule = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gblot = new System.Windows.Forms.GroupBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intlotcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnprevinternal = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.cbprevlotcode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btninternal = new System.Windows.Forms.Button();
            this.groupproductname = new System.Windows.Forms.GroupBox();
            this.btnproduct = new System.Windows.Forms.Button();
            this.cbproductname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnnew = new System.Windows.Forms.Button();
            this.cbexistinglot = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gblot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupproductname.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.lblmodule);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 40);
            this.panel3.TabIndex = 2;
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1264, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 29;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lblmodule
            // 
            this.lblmodule.AutoSize = true;
            this.lblmodule.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmodule.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblmodule.Location = new System.Drawing.Point(765, 5);
            this.lblmodule.Name = "lblmodule";
            this.lblmodule.Size = new System.Drawing.Size(18, 26);
            this.lblmodule.TabIndex = 1;
            this.lblmodule.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(595, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "INITIAL ENTRY";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.gblot);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(153, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 665);
            this.panel1.TabIndex = 3;
            // 
            // gblot
            // 
            this.gblot.Controls.Add(this.btnclose);
            this.gblot.Controls.Add(this.lblstatus);
            this.gblot.Controls.Add(this.dataGridView1);
            this.gblot.Location = new System.Drawing.Point(267, 170);
            this.gblot.Name = "gblot";
            this.gblot.Size = new System.Drawing.Size(638, 466);
            this.gblot.TabIndex = 8;
            this.gblot.TabStop = false;
            this.gblot.Text = "List Cutting";
            this.gblot.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(607, 7);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(29, 26);
            this.btnclose.TabIndex = 2;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(592, 446);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(35, 13);
            this.lblstatus.TabIndex = 1;
            this.lblstatus.Text = "status";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Supplier,
            this.Date,
            this.Intlotcode});
            this.dataGridView1.Location = new System.Drawing.Point(19, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(605, 414);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.Width = 150;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 130;
            // 
            // Intlotcode
            // 
            this.Intlotcode.HeaderText = "Internal Lot Code";
            this.Intlotcode.Name = "Intlotcode";
            this.Intlotcode.Width = 150;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.Controls.Add(this.btnprevinternal);
            this.panel4.Controls.Add(this.btnopen);
            this.panel4.Controls.Add(this.cbprevlotcode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(42, 355);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(863, 90);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnprevinternal
            // 
            this.btnprevinternal.Location = new System.Drawing.Point(605, 31);
            this.btnprevinternal.Name = "btnprevinternal";
            this.btnprevinternal.Size = new System.Drawing.Size(50, 33);
            this.btnprevinternal.TabIndex = 8;
            this.btnprevinternal.UseVisualStyleBackColor = true;
            this.btnprevinternal.Click += new System.EventHandler(this.btnprevinternal_Click);
            this.btnprevinternal.Paint += new System.Windows.Forms.PaintEventHandler(this.btnprevinternal_Paint);
            // 
            // btnopen
            // 
            this.btnopen.BackColor = System.Drawing.Color.Orange;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnopen.Location = new System.Drawing.Point(664, 19);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(189, 56);
            this.btnopen.TabIndex = 3;
            this.btnopen.Text = "Open Cutting";
            this.btnopen.UseVisualStyleBackColor = false;
            this.btnopen.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbprevlotcode
            // 
            this.cbprevlotcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbprevlotcode.FormattingEnabled = true;
            this.cbprevlotcode.Location = new System.Drawing.Point(341, 31);
            this.cbprevlotcode.Name = "cbprevlotcode";
            this.cbprevlotcode.Size = new System.Drawing.Size(314, 32);
            this.cbprevlotcode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "PREVIOUS INTERNAL LOT CODE :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.btninternal);
            this.panel2.Controls.Add(this.groupproductname);
            this.panel2.Controls.Add(this.btnnew);
            this.panel2.Controls.Add(this.cbexistinglot);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(42, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 131);
            this.panel2.TabIndex = 2;
            // 
            // btninternal
            // 
            this.btninternal.Location = new System.Drawing.Point(605, 28);
            this.btninternal.Name = "btninternal";
            this.btninternal.Size = new System.Drawing.Size(50, 33);
            this.btninternal.TabIndex = 8;
            this.btninternal.UseVisualStyleBackColor = true;
            this.btninternal.Click += new System.EventHandler(this.btninternal_Click);
            this.btninternal.Paint += new System.Windows.Forms.PaintEventHandler(this.btninternal_Paint);
            // 
            // groupproductname
            // 
            this.groupproductname.Controls.Add(this.btnproduct);
            this.groupproductname.Controls.Add(this.cbproductname);
            this.groupproductname.Controls.Add(this.label4);
            this.groupproductname.Location = new System.Drawing.Point(61, 62);
            this.groupproductname.Name = "groupproductname";
            this.groupproductname.Size = new System.Drawing.Size(598, 56);
            this.groupproductname.TabIndex = 4;
            this.groupproductname.TabStop = false;
            this.groupproductname.Visible = false;
            // 
            // btnproduct
            // 
            this.btnproduct.Location = new System.Drawing.Point(542, 12);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Size = new System.Drawing.Size(50, 33);
            this.btnproduct.TabIndex = 8;
            this.btnproduct.UseVisualStyleBackColor = true;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            this.btnproduct.Paint += new System.Windows.Forms.PaintEventHandler(this.btnproduct_Paint);
            // 
            // cbproductname
            // 
            this.cbproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbproductname.FormattingEnabled = true;
            this.cbproductname.Location = new System.Drawing.Point(177, 12);
            this.cbproductname.Name = "cbproductname";
            this.cbproductname.Size = new System.Drawing.Size(415, 32);
            this.cbproductname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "PRODUCT NAME :";
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.Orange;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnnew.Location = new System.Drawing.Point(665, 28);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(189, 71);
            this.btnnew.TabIndex = 3;
            this.btnnew.Text = "Create Cutting";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbexistinglot
            // 
            this.cbexistinglot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbexistinglot.FormattingEnabled = true;
            this.cbexistinglot.Location = new System.Drawing.Point(238, 28);
            this.cbexistinglot.Name = "cbexistinglot";
            this.cbexistinglot.Size = new System.Drawing.Size(417, 32);
            this.cbexistinglot.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "INTERNAL LOT CODE :";
            // 
            // InputCutting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputCutting";
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InputCutting_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gblot.ResumeLayout(false);
            this.gblot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupproductname.ResumeLayout(false);
            this.groupproductname.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.ComboBox cbprevlotcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.ComboBox cbexistinglot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblmodule;
        private System.Windows.Forms.GroupBox groupproductname;
        private System.Windows.Forms.ComboBox cbproductname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnprevinternal;
        private System.Windows.Forms.Button btninternal;
        private System.Windows.Forms.Button btnproduct;
        private System.Windows.Forms.GroupBox gblot;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intlotcode;
    }
}