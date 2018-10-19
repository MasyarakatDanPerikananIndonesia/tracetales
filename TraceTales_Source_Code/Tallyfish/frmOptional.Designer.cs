namespace Tallyfish
{
    partial class frmOptional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptional));
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.panellabel = new System.Windows.Forms.Panel();
            this.btnscan2 = new System.Windows.Forms.Button();
            this.btnscan = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblmessage = new System.Windows.Forms.Label();
            this.txtscan = new System.Windows.Forms.TextBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnnewloin = new System.Windows.Forms.Button();
            this.btncreatelabel = new System.Windows.Forms.Button();
            this.btnpacking = new System.Windows.Forms.Button();
            this.btnretouching = new System.Windows.Forms.Button();
            this.gbreprint = new System.Windows.Forms.GroupBox();
            this.btnreprint = new System.Windows.Forms.Button();
            this.lblcaseno = new System.Windows.Forms.Label();
            this.pblabel = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panellabel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbreprint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblabel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHeader.Location = new System.Drawing.Point(587, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(122, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "OPTIONAL";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1288, 37);
            this.panel2.TabIndex = 10;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1259, 0);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 29;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // panellabel
            // 
            this.panellabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panellabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panellabel.Controls.Add(this.btnscan2);
            this.panellabel.Controls.Add(this.btnscan);
            this.panellabel.Controls.Add(this.textBox2);
            this.panellabel.Controls.Add(this.textBox1);
            this.panellabel.Controls.Add(this.lblmessage);
            this.panellabel.Controls.Add(this.txtscan);
            this.panellabel.Controls.Add(this.lblcode);
            this.panellabel.Location = new System.Drawing.Point(209, 236);
            this.panellabel.Name = "panellabel";
            this.panellabel.Size = new System.Drawing.Size(795, 223);
            this.panellabel.TabIndex = 11;
            // 
            // btnscan2
            // 
            this.btnscan2.BackColor = System.Drawing.Color.LightGray;
            this.btnscan2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnscan2.Location = new System.Drawing.Point(94, 84);
            this.btnscan2.Name = "btnscan2";
            this.btnscan2.Size = new System.Drawing.Size(62, 49);
            this.btnscan2.TabIndex = 13;
            this.btnscan2.Text = "Scan";
            this.btnscan2.UseVisualStyleBackColor = false;
            this.btnscan2.Click += new System.EventHandler(this.btnscan2_Click);
            // 
            // btnscan
            // 
            this.btnscan.BackColor = System.Drawing.Color.Orange;
            this.btnscan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnscan.Location = new System.Drawing.Point(32, 84);
            this.btnscan.Name = "btnscan";
            this.btnscan.Size = new System.Drawing.Size(62, 49);
            this.btnscan.TabIndex = 12;
            this.btnscan.Text = "Manual";
            this.btnscan.UseVisualStyleBackColor = false;
            this.btnscan.Click += new System.EventHandler(this.btnscan_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(207, 139);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(24, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(26, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Visible = false;
            // 
            // lblmessage
            // 
            this.lblmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmessage.ForeColor = System.Drawing.Color.Red;
            this.lblmessage.Location = new System.Drawing.Point(45, 158);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(766, 30);
            this.lblmessage.TabIndex = 5;
            this.lblmessage.Text = "-";
            // 
            // txtscan
            // 
            this.txtscan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtscan.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscan.Location = new System.Drawing.Point(163, 84);
            this.txtscan.Multiline = true;
            this.txtscan.Name = "txtscan";
            this.txtscan.Size = new System.Drawing.Size(551, 49);
            this.txtscan.TabIndex = 4;
            this.txtscan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscan_KeyPress);
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(160, 41);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(175, 31);
            this.lblcode.TabIndex = 3;
            this.lblcode.Text = "Scan Loin Code:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnnewloin);
            this.panel3.Controls.Add(this.btncreatelabel);
            this.panel3.Controls.Add(this.btnpacking);
            this.panel3.Controls.Add(this.btnretouching);
            this.panel3.Location = new System.Drawing.Point(54, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1278, 223);
            this.panel3.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1060, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 113);
            this.button2.TabIndex = 6;
            this.button2.Text = "Defrost Loin";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.Paint += new System.Windows.Forms.PaintEventHandler(this.button2_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(838, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 113);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create New Packing";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint_2);
            // 
            // btnnewloin
            // 
            this.btnnewloin.BackColor = System.Drawing.Color.Orange;
            this.btnnewloin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewloin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnnewloin.Location = new System.Drawing.Point(618, 60);
            this.btnnewloin.Name = "btnnewloin";
            this.btnnewloin.Size = new System.Drawing.Size(220, 113);
            this.btnnewloin.TabIndex = 3;
            this.btnnewloin.Text = "Create New Loin";
            this.btnnewloin.UseVisualStyleBackColor = false;
            this.btnnewloin.Click += new System.EventHandler(this.btnnewloin_Click);
            this.btnnewloin.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint_1);
            // 
            // btncreatelabel
            // 
            this.btncreatelabel.BackColor = System.Drawing.Color.Orange;
            this.btncreatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncreatelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncreatelabel.Location = new System.Drawing.Point(404, 60);
            this.btncreatelabel.Name = "btncreatelabel";
            this.btncreatelabel.Size = new System.Drawing.Size(213, 113);
            this.btncreatelabel.TabIndex = 2;
            this.btncreatelabel.Text = "Create Box Label";
            this.btncreatelabel.UseVisualStyleBackColor = false;
            this.btncreatelabel.Click += new System.EventHandler(this.button1_Click);
            this.btncreatelabel.Paint += new System.Windows.Forms.PaintEventHandler(this.btncreatelabel_Paint);
            // 
            // btnpacking
            // 
            this.btnpacking.BackColor = System.Drawing.Color.Orange;
            this.btnpacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpacking.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnpacking.Location = new System.Drawing.Point(230, 60);
            this.btnpacking.Name = "btnpacking";
            this.btnpacking.Size = new System.Drawing.Size(175, 114);
            this.btnpacking.TabIndex = 1;
            this.btnpacking.Text = "Reprint Label";
            this.btnpacking.UseVisualStyleBackColor = false;
            this.btnpacking.Click += new System.EventHandler(this.btnpacking_Click);
            this.btnpacking.Paint += new System.Windows.Forms.PaintEventHandler(this.btnpacking_Paint);
            // 
            // btnretouching
            // 
            this.btnretouching.BackColor = System.Drawing.Color.Orange;
            this.btnretouching.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnretouching.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnretouching.Location = new System.Drawing.Point(22, 59);
            this.btnretouching.Name = "btnretouching";
            this.btnretouching.Size = new System.Drawing.Size(208, 116);
            this.btnretouching.TabIndex = 0;
            this.btnretouching.Text = "Entry Packing";
            this.btnretouching.UseVisualStyleBackColor = false;
            this.btnretouching.Click += new System.EventHandler(this.btnretouching_Click);
            this.btnretouching.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            // 
            // gbreprint
            // 
            this.gbreprint.Controls.Add(this.btnreprint);
            this.gbreprint.Controls.Add(this.lblcaseno);
            this.gbreprint.Location = new System.Drawing.Point(242, 488);
            this.gbreprint.Name = "gbreprint";
            this.gbreprint.Size = new System.Drawing.Size(766, 166);
            this.gbreprint.TabIndex = 20;
            this.gbreprint.TabStop = false;
            this.gbreprint.Text = "Print Packing Label";
            this.gbreprint.Visible = false;
            // 
            // btnreprint
            // 
            this.btnreprint.BackColor = System.Drawing.Color.Orange;
            this.btnreprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreprint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnreprint.Location = new System.Drawing.Point(440, 19);
            this.btnreprint.Name = "btnreprint";
            this.btnreprint.Size = new System.Drawing.Size(303, 132);
            this.btnreprint.TabIndex = 21;
            this.btnreprint.Text = "Reprint Label";
            this.btnreprint.UseVisualStyleBackColor = false;
            this.btnreprint.Click += new System.EventHandler(this.btnreprint_Click);
            // 
            // lblcaseno
            // 
            this.lblcaseno.AutoSize = true;
            this.lblcaseno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcaseno.Location = new System.Drawing.Point(34, 33);
            this.lblcaseno.Name = "lblcaseno";
            this.lblcaseno.Size = new System.Drawing.Size(88, 31);
            this.lblcaseno.TabIndex = 20;
            this.lblcaseno.Text = "CASE";
            // 
            // pblabel
            // 
            this.pblabel.Location = new System.Drawing.Point(2, 521);
            this.pblabel.Name = "pblabel";
            this.pblabel.Size = new System.Drawing.Size(200, 200);
            this.pblabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblabel.TabIndex = 18;
            this.pblabel.TabStop = false;
            this.pblabel.Visible = false;
            // 
            // frmOptional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 733);
            this.Controls.Add(this.gbreprint);
            this.Controls.Add(this.pblabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panellabel);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOptional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReprint_Label_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panellabel.ResumeLayout(false);
            this.panellabel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbreprint.ResumeLayout(false);
            this.gbreprint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panellabel;
        private System.Windows.Forms.TextBox txtscan;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnpacking;
        private System.Windows.Forms.Button btnretouching;
        private System.Windows.Forms.PictureBox pblabel;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.GroupBox gbreprint;
        private System.Windows.Forms.Button btnreprint;
        private System.Windows.Forms.Label lblcaseno;
        private System.Windows.Forms.Button btncreatelabel;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.Button btnnewloin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnscan2;
        private System.Windows.Forms.Button btnscan;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}