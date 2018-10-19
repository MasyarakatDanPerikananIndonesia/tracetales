namespace Tallyfish
{
    partial class frmKanban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKanban));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnqtystuffing = new System.Windows.Forms.Button();
            this.btnqtyreceiving = new System.Windows.Forms.Button();
            this.btnpreview = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Intlotcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cutting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retouching = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1352, 34);
            this.panel2.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(330, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 31);
            this.button4.TabIndex = 33;
            this.button4.Text = "Packing";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(227, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 31);
            this.button3.TabIndex = 32;
            this.button3.Text = "Retouching";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(124, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 31);
            this.button2.TabIndex = 31;
            this.button2.Text = "Cutting";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(21, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 30;
            this.button1.Text = "Receiving";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1265, -2);
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
            this.label1.Location = new System.Drawing.Point(555, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "SUMMARY TRANSACTION";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnqtystuffing);
            this.panel3.Controls.Add(this.btnqtyreceiving);
            this.panel3.Controls.Add(this.btnpreview);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1324, 60);
            this.panel3.TabIndex = 2;
            // 
            // btnqtystuffing
            // 
            this.btnqtystuffing.BackColor = System.Drawing.Color.Orange;
            this.btnqtystuffing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnqtystuffing.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnqtystuffing.Location = new System.Drawing.Point(920, 3);
            this.btnqtystuffing.Name = "btnqtystuffing";
            this.btnqtystuffing.Size = new System.Drawing.Size(155, 55);
            this.btnqtystuffing.TabIndex = 24;
            this.btnqtystuffing.Text = "Total Qty Stuffing";
            this.btnqtystuffing.UseVisualStyleBackColor = false;
            this.btnqtystuffing.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnqtyreceiving
            // 
            this.btnqtyreceiving.BackColor = System.Drawing.Color.Orange;
            this.btnqtyreceiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnqtyreceiving.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnqtyreceiving.Location = new System.Drawing.Point(749, 3);
            this.btnqtyreceiving.Name = "btnqtyreceiving";
            this.btnqtyreceiving.Size = new System.Drawing.Size(165, 55);
            this.btnqtyreceiving.TabIndex = 22;
            this.btnqtyreceiving.Text = "Total Qty Receiving";
            this.btnqtyreceiving.UseVisualStyleBackColor = false;
            this.btnqtyreceiving.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnpreview
            // 
            this.btnpreview.BackColor = System.Drawing.Color.Orange;
            this.btnpreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpreview.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnpreview.Location = new System.Drawing.Point(548, 1);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(195, 55);
            this.btnpreview.TabIndex = 21;
            this.btnpreview.Text = "Preview";
            this.btnpreview.UseVisualStyleBackColor = false;
            this.btnpreview.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(396, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 29);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(119, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(146, 29);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(299, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "To  Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "From Date :";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Location = new System.Drawing.Point(18, 35);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1339, 70);
            this.panel6.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProgressBar1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 623);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(217, 4);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(1129, 10);
            this.ProgressBar1.TabIndex = 14;
            this.ProgressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "click the value to export to csv / excel";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(754, 202);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Intlotcode,
            this.Receiving,
            this.Cutting,
            this.Retouching,
            this.Packing});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(11, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 595);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Intlotcode
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Intlotcode.DefaultCellStyle = dataGridViewCellStyle2;
            this.Intlotcode.HeaderText = "Internal Lot Code";
            this.Intlotcode.Name = "Intlotcode";
            this.Intlotcode.Width = 200;
            // 
            // Receiving
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Receiving.DefaultCellStyle = dataGridViewCellStyle3;
            this.Receiving.HeaderText = "Receiving";
            this.Receiving.Name = "Receiving";
            this.Receiving.Width = 250;
            // 
            // Cutting
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cutting.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cutting.HeaderText = "Cutting";
            this.Cutting.Name = "Cutting";
            this.Cutting.Width = 250;
            // 
            // Retouching
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Retouching.DefaultCellStyle = dataGridViewCellStyle5;
            this.Retouching.HeaderText = "Retouching";
            this.Retouching.Name = "Retouching";
            this.Retouching.Width = 250;
            // 
            // Packing
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Packing.DefaultCellStyle = dataGridViewCellStyle6;
            this.Packing.HeaderText = "Packing";
            this.Packing.Name = "Packing";
            this.Packing.Width = 250;
            // 
            // frmKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKanban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKanban_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intlotcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cutting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retouching;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packing;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnqtyreceiving;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnqtystuffing;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar ProgressBar1;
    }
}