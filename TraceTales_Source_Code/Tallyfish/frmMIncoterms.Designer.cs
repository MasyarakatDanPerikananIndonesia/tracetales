namespace Tallyfish
{
    partial class frmMIncoterms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMIncoterms));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnincoterm = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtincoterms = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Incoterms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdueday = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnpayterm = new System.Windows.Forms.Button();
            this.txtdescription1 = new System.Windows.Forms.TextBox();
            this.txtpayterms = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payterms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dueday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdueday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnincoterm);
            this.panel2.Controls.Add(this.txtdescription);
            this.panel2.Controls.Add(this.txtincoterms);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 697);
            this.panel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(544, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Refresh";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnincoterm
            // 
            this.btnincoterm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnincoterm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnincoterm.ForeColor = System.Drawing.Color.White;
            this.btnincoterm.Location = new System.Drawing.Point(303, 136);
            this.btnincoterm.Name = "btnincoterm";
            this.btnincoterm.Size = new System.Drawing.Size(140, 64);
            this.btnincoterm.TabIndex = 11;
            this.btnincoterm.Text = "Save";
            this.btnincoterm.UseVisualStyleBackColor = false;
            this.btnincoterm.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription.Location = new System.Drawing.Point(157, 78);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(284, 54);
            this.txtdescription.TabIndex = 9;
            // 
            // txtincoterms
            // 
            this.txtincoterms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtincoterms.Location = new System.Drawing.Point(157, 50);
            this.txtincoterms.Name = "txtincoterms";
            this.txtincoterms.Size = new System.Drawing.Size(284, 26);
            this.txtincoterms.TabIndex = 7;
            this.txtincoterms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtincoterms_KeyPress);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Incoterms,
            this.Description});
            this.dataGridView1.Location = new System.Drawing.Point(16, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(597, 474);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // Incoterms
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Incoterms.DefaultCellStyle = dataGridViewCellStyle3;
            this.Incoterms.HeaderText = "Shipment Terms";
            this.Incoterms.Name = "Incoterms";
            this.Incoterms.Width = 120;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 260;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(17, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Description ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Shipment Terms";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(620, 40);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(195, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "SHIPMENT TERMS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtdueday);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnpayterm);
            this.panel1.Controls.Add(this.txtdescription1);
            this.panel1.Controls.Add(this.txtpayterms);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(634, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 697);
            this.panel1.TabIndex = 3;
            // 
            // txtdueday
            // 
            this.txtdueday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdueday.Location = new System.Drawing.Point(147, 134);
            this.txtdueday.Name = "txtdueday";
            this.txtdueday.Size = new System.Drawing.Size(76, 26);
            this.txtdueday.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(30, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Due Days:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(644, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Refresh";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnpayterm
            // 
            this.btnpayterm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnpayterm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpayterm.ForeColor = System.Drawing.Color.White;
            this.btnpayterm.Location = new System.Drawing.Point(290, 135);
            this.btnpayterm.Name = "btnpayterm";
            this.btnpayterm.Size = new System.Drawing.Size(142, 65);
            this.btnpayterm.TabIndex = 11;
            this.btnpayterm.Text = "Save";
            this.btnpayterm.UseVisualStyleBackColor = false;
            this.btnpayterm.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdescription1
            // 
            this.txtdescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription1.Location = new System.Drawing.Point(147, 78);
            this.txtdescription1.Multiline = true;
            this.txtdescription1.Name = "txtdescription1";
            this.txtdescription1.Size = new System.Drawing.Size(284, 52);
            this.txtdescription1.TabIndex = 9;
            // 
            // txtpayterms
            // 
            this.txtpayterms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpayterms.Location = new System.Drawing.Point(147, 50);
            this.txtpayterms.Name = "txtpayterms";
            this.txtpayterms.Size = new System.Drawing.Size(284, 26);
            this.txtpayterms.TabIndex = 7;
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Payterms,
            this.Description1,
            this.Dueday});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.Location = new System.Drawing.Point(19, 206);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(622, 474);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // Payterms
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Payterms.DefaultCellStyle = dataGridViewCellStyle6;
            this.Payterms.HeaderText = "Payterms";
            this.Payterms.Name = "Payterms";
            // 
            // Description1
            // 
            this.Description1.HeaderText = "Description";
            this.Description1.Name = "Description1";
            this.Description1.Width = 250;
            // 
            // Dueday
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Dueday.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dueday.HeaderText = "Due Days";
            this.Dueday.Name = "Dueday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(32, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Payterms :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(642, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(545, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 27;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(254, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "PAYMENT TERMS";
            // 
            // frmMIncoterms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMIncoterms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipment Terms and Payment Terms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMIncoterms_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdueday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnincoterm;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtincoterms;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnpayterm;
        private System.Windows.Forms.TextBox txtdescription1;
        private System.Windows.Forms.TextBox txtpayterms;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtdueday;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Incoterms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payterms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dueday;
    }
}