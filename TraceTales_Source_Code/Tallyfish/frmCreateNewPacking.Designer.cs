namespace Tallyfish
{
    partial class frmCreateNewPacking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNewPacking));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbproductpacking = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbproductname = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpieces = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbpackingsize = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbcertificate = new System.Windows.Forms.ComboBox();
            this.cbgrade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbfishtype = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblsuppname = new System.Windows.Forms.Label();
            this.btnprintoff = new System.Windows.Forms.Button();
            this.btnprinton = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtboxweight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsuppcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbatch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pblabel = new System.Windows.Forms.PictureBox();
            this.lblwarning = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblabel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(546, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREATE MANUAL PACKING";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1267, 37);
            this.panel2.TabIndex = 12;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1165, 0);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 28;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbproductpacking);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbproductname);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtpieces);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbpackingsize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbcertificate);
            this.groupBox1.Controls.Add(this.cbgrade);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbfishtype);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.lblsuppname);
            this.groupBox1.Controls.Add(this.btnprintoff);
            this.groupBox1.Controls.Add(this.btnprinton);
            this.groupBox1.Controls.Add(this.btnprint);
            this.groupBox1.Controls.Add(this.txtboxweight);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtsuppcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbatch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 690);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Data Packing";
            // 
            // cbproductpacking
            // 
            this.cbproductpacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbproductpacking.FormattingEnabled = true;
            this.cbproductpacking.Location = new System.Drawing.Point(284, 452);
            this.cbproductpacking.Name = "cbproductpacking";
            this.cbproductpacking.Size = new System.Drawing.Size(274, 37);
            this.cbproductpacking.TabIndex = 50;
            this.cbproductpacking.SelectedIndexChanged += new System.EventHandler(this.cbproductpacking_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(73, 465);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 17);
            this.label12.TabIndex = 49;
            this.label12.Text = "Product Packing :";
            // 
            // cbproductname
            // 
            this.cbproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbproductname.FormattingEnabled = true;
            this.cbproductname.Location = new System.Drawing.Point(284, 409);
            this.cbproductname.Name = "cbproductname";
            this.cbproductname.Size = new System.Drawing.Size(407, 37);
            this.cbproductname.TabIndex = 48;
            this.cbproductname.SelectedIndexChanged += new System.EventHandler(this.cbproductname_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Product Name :";
            // 
            // txtpieces
            // 
            this.txtpieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpieces.Location = new System.Drawing.Point(284, 320);
            this.txtpieces.Name = "txtpieces";
            this.txtpieces.Size = new System.Drawing.Size(179, 38);
            this.txtpieces.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(73, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 17);
            this.label11.TabIndex = 45;
            this.label11.Text = "Pieces :";
            // 
            // cbpackingsize
            // 
            this.cbpackingsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbpackingsize.FormattingEnabled = true;
            this.cbpackingsize.Location = new System.Drawing.Point(284, 277);
            this.cbpackingsize.Name = "cbpackingsize";
            this.cbpackingsize.Size = new System.Drawing.Size(179, 37);
            this.cbpackingsize.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(73, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Packing Size :";
            // 
            // cbcertificate
            // 
            this.cbcertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcertificate.FormattingEnabled = true;
            this.cbcertificate.Location = new System.Drawing.Point(284, 190);
            this.cbcertificate.Name = "cbcertificate";
            this.cbcertificate.Size = new System.Drawing.Size(179, 37);
            this.cbcertificate.TabIndex = 40;
            // 
            // cbgrade
            // 
            this.cbgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgrade.FormattingEnabled = true;
            this.cbgrade.Location = new System.Drawing.Point(284, 234);
            this.cbgrade.Name = "cbgrade";
            this.cbgrade.Size = new System.Drawing.Size(179, 37);
            this.cbgrade.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Grade :";
            // 
            // cbfishtype
            // 
            this.cbfishtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbfishtype.FormattingEnabled = true;
            this.cbfishtype.Location = new System.Drawing.Point(284, 147);
            this.cbfishtype.Name = "cbfishtype";
            this.cbfishtype.Size = new System.Drawing.Size(179, 37);
            this.cbfishtype.TabIndex = 37;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(284, 108);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(179, 35);
            this.dateTimePicker1.TabIndex = 36;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblsuppname
            // 
            this.lblsuppname.AutoSize = true;
            this.lblsuppname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsuppname.Location = new System.Drawing.Point(363, 71);
            this.lblsuppname.Name = "lblsuppname";
            this.lblsuppname.Size = new System.Drawing.Size(13, 17);
            this.lblsuppname.TabIndex = 35;
            this.lblsuppname.Text = "-";
            // 
            // btnprintoff
            // 
            this.btnprintoff.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnprintoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprintoff.ForeColor = System.Drawing.Color.Gray;
            this.btnprintoff.Location = new System.Drawing.Point(135, 529);
            this.btnprintoff.Name = "btnprintoff";
            this.btnprintoff.Size = new System.Drawing.Size(81, 62);
            this.btnprintoff.TabIndex = 34;
            this.btnprintoff.Text = "OFF";
            this.btnprintoff.UseVisualStyleBackColor = false;
            this.btnprintoff.Click += new System.EventHandler(this.btnprintoff_Click);
            // 
            // btnprinton
            // 
            this.btnprinton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnprinton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprinton.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnprinton.Location = new System.Drawing.Point(58, 529);
            this.btnprinton.Name = "btnprinton";
            this.btnprinton.Size = new System.Drawing.Size(76, 62);
            this.btnprinton.TabIndex = 33;
            this.btnprinton.Text = "ON";
            this.btnprinton.UseVisualStyleBackColor = false;
            this.btnprinton.Click += new System.EventHandler(this.btnprinton_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Orange;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprint.Location = new System.Drawing.Point(284, 507);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(236, 91);
            this.btnprint.TabIndex = 29;
            this.btnprint.Text = "Save And Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtboxweight
            // 
            this.txtboxweight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtboxweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxweight.Location = new System.Drawing.Point(284, 365);
            this.txtboxweight.Name = "txtboxweight";
            this.txtboxweight.Size = new System.Drawing.Size(179, 38);
            this.txtboxweight.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(70, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Box Weight (Kg)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Certificate :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fish Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Processing / Cutting Date :";
            // 
            // txtsuppcode
            // 
            this.txtsuppcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsuppcode.Location = new System.Drawing.Point(284, 62);
            this.txtsuppcode.Name = "txtsuppcode";
            this.txtsuppcode.Size = new System.Drawing.Size(73, 35);
            this.txtsuppcode.TabIndex = 3;
            this.txtsuppcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsuppcode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Supplier Code :";
            // 
            // txtbatch
            // 
            this.txtbatch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbatch.Location = new System.Drawing.Point(284, 17);
            this.txtbatch.Name = "txtbatch";
            this.txtbatch.Size = new System.Drawing.Size(73, 35);
            this.txtbatch.TabIndex = 1;
            this.txtbatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbatch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Batch Code :";
            // 
            // pblabel
            // 
            this.pblabel.Location = new System.Drawing.Point(735, 577);
            this.pblabel.Name = "pblabel";
            this.pblabel.Size = new System.Drawing.Size(167, 152);
            this.pblabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblabel.TabIndex = 24;
            this.pblabel.TabStop = false;
            this.pblabel.Visible = false;
            // 
            // lblwarning
            // 
            this.lblwarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwarning.ForeColor = System.Drawing.Color.Red;
            this.lblwarning.Location = new System.Drawing.Point(713, 53);
            this.lblwarning.Name = "lblwarning";
            this.lblwarning.Size = new System.Drawing.Size(369, 266);
            this.lblwarning.TabIndex = 25;
            this.lblwarning.Text = "-";
            // 
            // frmCreateNewPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 733);
            this.Controls.Add(this.lblwarning);
            this.Controls.Add(this.pblabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreateNewPacking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.Load += new System.EventHandler(this.frmCreateNewPacking_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbproductpacking;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbproductname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpieces;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbpackingsize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbcertificate;
        private System.Windows.Forms.ComboBox cbgrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbfishtype;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblsuppname;
        private System.Windows.Forms.Button btnprintoff;
        private System.Windows.Forms.Button btnprinton;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtboxweight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsuppcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pblabel;
        private System.Windows.Forms.Label lblwarning;
    }
}