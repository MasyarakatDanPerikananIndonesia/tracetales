namespace Tallyfish
{
    partial class frmReceiving_LoinBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiving_LoinBox));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsupplier = new System.Windows.Forms.TextBox();
            this.txtintlotcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtloin = new System.Windows.Forms.TextBox();
            this.txtnumberbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsave = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(398, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTAL LOIN IN BOX";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 37);
            this.panel2.TabIndex = 1;
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(839, 0);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(166, 37);
            this.btnback.TabIndex = 28;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtsupplier);
            this.panel1.Controls.Add(this.txtintlotcode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 85);
            this.panel1.TabIndex = 2;
            // 
            // txtsupplier
            // 
            this.txtsupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsupplier.Location = new System.Drawing.Point(225, 42);
            this.txtsupplier.Name = "txtsupplier";
            this.txtsupplier.ReadOnly = true;
            this.txtsupplier.Size = new System.Drawing.Size(281, 29);
            this.txtsupplier.TabIndex = 3;
            // 
            // txtintlotcode
            // 
            this.txtintlotcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtintlotcode.Location = new System.Drawing.Point(225, 7);
            this.txtintlotcode.Name = "txtintlotcode";
            this.txtintlotcode.ReadOnly = true;
            this.txtintlotcode.Size = new System.Drawing.Size(281, 29);
            this.txtintlotcode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "SUPPLIER ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "INTERNAL LOT CODE";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtloin);
            this.panel3.Controls.Add(this.txtnumberbox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(530, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 85);
            this.panel3.TabIndex = 3;
            // 
            // txtloin
            // 
            this.txtloin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtloin.Location = new System.Drawing.Point(178, 43);
            this.txtloin.Name = "txtloin";
            this.txtloin.Size = new System.Drawing.Size(102, 29);
            this.txtloin.TabIndex = 3;
            this.txtloin.Text = " 0";
            // 
            // txtnumberbox
            // 
            this.txtnumberbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumberbox.Location = new System.Drawing.Point(178, 8);
            this.txtnumberbox.Name = "txtnumberbox";
            this.txtnumberbox.Size = new System.Drawing.Size(102, 29);
            this.txtnumberbox.TabIndex = 2;
            this.txtnumberbox.Text = " 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "TOTAL LOIN :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "NUMBER BOX :";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 140);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(1023, 505);
            this.button5.TabIndex = 10;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Grd,
            this.Weight});
            this.dataGridView1.Location = new System.Drawing.Point(23, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(988, 461);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Grd
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grd.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grd.HeaderText = "Box Number";
            this.Grd.Name = "Grd";
            this.Grd.Width = 150;
            // 
            // Weight
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weight.DefaultCellStyle = dataGridViewCellStyle5;
            this.Weight.HeaderText = "Total Loin";
            this.Weight.Name = "Weight";
            this.Weight.Width = 150;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.Orange;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.Location = new System.Drawing.Point(842, 49);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(166, 85);
            this.btnsave.TabIndex = 29;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // frmReceiving_LoinBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 655);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReceiving_LoinBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.Load += new System.EventHandler(this.frmReceiving_LoinBox_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtsupplier;
        private System.Windows.Forms.TextBox txtintlotcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtloin;
        private System.Windows.Forms.TextBox txtnumberbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
    }
}