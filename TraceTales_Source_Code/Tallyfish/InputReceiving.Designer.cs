namespace Tallyfish
{
    partial class InputReceiving
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputReceiving));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbPreviousLot = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intlotcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnselectsupplier = new System.Windows.Forms.Button();
            this.txtdono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblerror = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnlot = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.cbexistinglot = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbPreviousLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.gbPreviousLot);
            this.panel1.Controls.Add(this.btnselectsupplier);
            this.panel1.Controls.Add(this.txtdono);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblerror);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(174, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 586);
            this.panel1.TabIndex = 0;
            // 
            // gbPreviousLot
            // 
            this.gbPreviousLot.Controls.Add(this.btnclose);
            this.gbPreviousLot.Controls.Add(this.dataGridView1);
            this.gbPreviousLot.Location = new System.Drawing.Point(377, 63);
            this.gbPreviousLot.Name = "gbPreviousLot";
            this.gbPreviousLot.Size = new System.Drawing.Size(638, 411);
            this.gbPreviousLot.TabIndex = 7;
            this.gbPreviousLot.TabStop = false;
            this.gbPreviousLot.Text = "List Previous Receiving ";
            this.gbPreviousLot.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Supplier,
            this.Date,
            this.Intlotcode});
            this.dataGridView1.Location = new System.Drawing.Point(19, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(605, 363);
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
            this.Date.HeaderText = "Receiving Date";
            this.Date.Name = "Date";
            this.Date.Width = 130;
            // 
            // Intlotcode
            // 
            this.Intlotcode.HeaderText = "Internal Lot Code";
            this.Intlotcode.Name = "Intlotcode";
            this.Intlotcode.Width = 150;
            // 
            // btnselectsupplier
            // 
            this.btnselectsupplier.Location = new System.Drawing.Point(432, 14);
            this.btnselectsupplier.Name = "btnselectsupplier";
            this.btnselectsupplier.Size = new System.Drawing.Size(50, 35);
            this.btnselectsupplier.TabIndex = 6;
            this.btnselectsupplier.UseVisualStyleBackColor = true;
            this.btnselectsupplier.Click += new System.EventHandler(this.button1_Click_1);
            this.btnselectsupplier.Paint += new System.Windows.Forms.PaintEventHandler(this.btnselect_Paint);
            // 
            // txtdono
            // 
            this.txtdono.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdono.Location = new System.Drawing.Point(673, 17);
            this.txtdono.Name = "txtdono";
            this.txtdono.Size = new System.Drawing.Size(328, 27);
            this.txtdono.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(511, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Delivery Order No";
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(180, 52);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(10, 13);
            this.lblerror.TabIndex = 3;
            this.lblerror.Text = ".";
            this.lblerror.Click += new System.EventHandler(this.lblerror_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.btnlot);
            this.panel2.Controls.Add(this.btnopen);
            this.panel2.Controls.Add(this.cbexistinglot);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 492);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 90);
            this.panel2.TabIndex = 2;
            // 
            // btnlot
            // 
            this.btnlot.Location = new System.Drawing.Point(493, 26);
            this.btnlot.Name = "btnlot";
            this.btnlot.Size = new System.Drawing.Size(50, 33);
            this.btnlot.TabIndex = 7;
            this.btnlot.UseVisualStyleBackColor = true;
            this.btnlot.Click += new System.EventHandler(this.btnlot_Click);
            this.btnlot.Paint += new System.Windows.Forms.PaintEventHandler(this.btnlot_Paint);
            // 
            // btnopen
            // 
            this.btnopen.BackColor = System.Drawing.Color.Orange;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnopen.Location = new System.Drawing.Point(651, 6);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(250, 72);
            this.btnopen.TabIndex = 3;
            this.btnopen.Text = "Open Receiving";
            this.btnopen.UseVisualStyleBackColor = false;
            this.btnopen.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbexistinglot
            // 
            this.cbexistinglot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbexistinglot.FormattingEnabled = true;
            this.cbexistinglot.Location = new System.Drawing.Point(193, 26);
            this.cbexistinglot.Name = "cbexistinglot";
            this.cbexistinglot.Size = new System.Drawing.Size(314, 32);
            this.cbexistinglot.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "EXISTING LOT :";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(178, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "SUPPLIER :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(674, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "INITIAL ENTRY";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1363, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1265, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 27;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(608, 9);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(29, 26);
            this.btnclose.TabIndex = 3;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // InputReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1354, 722);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputReceiving";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InputReceiving_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPreviousLot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.ComboBox cbexistinglot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.TextBox txtdono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnselectsupplier;
        private System.Windows.Forms.Button btnlot;
        private System.Windows.Forms.GroupBox gbPreviousLot;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intlotcode;
        private System.Windows.Forms.Button btnclose;
    }
}