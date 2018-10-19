namespace Tallyfish
{
    partial class frmMutility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMutility));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtpassw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IPServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Baudrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.txtbaud = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.txtpassw);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtuser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtip);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 485);
            this.panel1.TabIndex = 2;
            // 
            // txtpassw
            // 
            this.txtpassw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassw.Location = new System.Drawing.Point(144, 123);
            this.txtpassw.Name = "txtpassw";
            this.txtpassw.Size = new System.Drawing.Size(215, 29);
            this.txtpassw.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(19, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "DB Password :";
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(144, 90);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(215, 29);
            this.txtuser.TabIndex = 8;
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(19, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "DB Username:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(4, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Refresh";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPServer,
            this.Username,
            this.Password});
            this.dataGridView1.Location = new System.Drawing.Point(3, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(461, 297);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // IPServer
            // 
            this.IPServer.HeaderText = "IP Server";
            this.IPServer.Name = "IPServer";
            // 
            // Username
            // 
            this.Username.HeaderText = "User Name";
            this.Username.Name = "Username";
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.Width = 120;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(365, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtip
            // 
            this.txtip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtip.Location = new System.Drawing.Point(144, 56);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(215, 29);
            this.txtip.TabIndex = 2;
            this.txtip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtip_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP Server :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 40);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(137, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SERVER SETUP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txtbaud);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(471, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 485);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(4, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Refresh";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Baudrate});
            this.dataGridView2.Location = new System.Drawing.Point(3, 185);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(253, 297);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // Baudrate
            // 
            this.Baudrate.HeaderText = "Baud Rate";
            this.Baudrate.Name = "Baudrate";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(162, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbaud
            // 
            this.txtbaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbaud.Location = new System.Drawing.Point(20, 82);
            this.txtbaud.Name = "txtbaud";
            this.txtbaud.Size = new System.Drawing.Size(140, 29);
            this.txtbaud.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(16, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Baud Rate :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(258, 40);
            this.panel4.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(31, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "WEIGHING SETUP";
            // 
            // frmMutility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMutility";
            this.Text = "Utilities";
            this.Load += new System.EventHandler(this.tbutility_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtpassw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baudrate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtbaud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;

    }
}