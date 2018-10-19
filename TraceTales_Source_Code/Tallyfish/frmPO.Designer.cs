namespace Tallyfish
{
    partial class frmPO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPO));
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncompany = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomername = new System.Windows.Forms.Label();
            this.txtpo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnnew = new System.Windows.Forms.Button();
            this.cbcustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(621, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "PURCHASE ORDER";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 40);
            this.panel3.TabIndex = 4;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1264, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 30;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.btncompany);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCustomername);
            this.panel1.Controls.Add(this.txtpo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.cbcustomer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtremark);
            this.panel1.Location = new System.Drawing.Point(55, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 407);
            this.panel1.TabIndex = 10;
            // 
            // btncompany
            // 
            this.btncompany.Location = new System.Drawing.Point(339, 15);
            this.btncompany.Name = "btncompany";
            this.btncompany.Size = new System.Drawing.Size(48, 35);
            this.btncompany.TabIndex = 25;
            this.btncompany.UseVisualStyleBackColor = true;
            this.btncompany.Click += new System.EventHandler(this.btncompany_Click);
            this.btncompany.Paint += new System.Windows.Forms.PaintEventHandler(this.btncompany_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Remark :";
            // 
            // lblCustomername
            // 
            this.lblCustomername.AutoSize = true;
            this.lblCustomername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomername.Location = new System.Drawing.Point(233, 67);
            this.lblCustomername.Name = "lblCustomername";
            this.lblCustomername.Size = new System.Drawing.Size(13, 20);
            this.lblCustomername.TabIndex = 23;
            this.lblCustomername.Text = ".";
            // 
            // txtpo
            // 
            this.txtpo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpo.Location = new System.Drawing.Point(233, 132);
            this.txtpo.Name = "txtpo";
            this.txtpo.Size = new System.Drawing.Size(327, 30);
            this.txtpo.TabIndex = 20;
            this.txtpo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(136, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "PO No :";
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.Orange;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnnew.Location = new System.Drawing.Point(233, 319);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(232, 70);
            this.btnnew.TabIndex = 7;
            this.btnnew.Text = "Create PO";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // cbcustomer
            // 
            this.cbcustomer.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcustomer.FormattingEnabled = true;
            this.cbcustomer.Location = new System.Drawing.Point(233, 16);
            this.cbcustomer.Name = "cbcustomer";
            this.cbcustomer.Size = new System.Drawing.Size(121, 33);
            this.cbcustomer.TabIndex = 11;
            this.cbcustomer.SelectedIndexChanged += new System.EventHandler(this.cbcustomer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "From Company";
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.Location = new System.Drawing.Point(233, 190);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(327, 96);
            this.txtremark.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(641, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 679);
            this.panel2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Po,
            this.Company,
            this.Remark});
            this.dataGridView1.Location = new System.Drawing.Point(10, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(704, 622);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 40;
            // 
            // Po
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Po.DefaultCellStyle = dataGridViewCellStyle4;
            this.Po.HeaderText = "PO#";
            this.Po.Name = "Po";
            this.Po.Width = 120;
            // 
            // Company
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Company.DefaultCellStyle = dataGridViewCellStyle5;
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.Width = 150;
            // 
            // Remark
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remark.DefaultCellStyle = dataGridViewCellStyle6;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Width = 200;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(711, 40);
            this.panel4.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(3, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Refresh";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(240, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(226, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "LIST OF PURCHASE ORDER";
            // 
            // frmPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPO";
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPO_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomername;
        private System.Windows.Forms.TextBox txtpo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.ComboBox cbcustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Po;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btncompany;
    }
}