namespace Tallyfish
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelsetup = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btncompany = new System.Windows.Forms.Button();
            this.btnsupplieradd = new System.Windows.Forms.Button();
            this.btnproduct = new System.Windows.Forms.Button();
            this.btncustomer = new System.Windows.Forms.Button();
            this.btnsupplier = new System.Windows.Forms.Button();
            this.btnuser = new System.Windows.Forms.Button();
            this.btncategories = new System.Windows.Forms.Button();
            this.btnspecies = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnmastersetup1 = new System.Windows.Forms.Button();
            this.btntransaction1 = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.pbbackground = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelsetup.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbbackground)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.txtpass);
            this.panel1.Controls.Add(this.txtuser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 559);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 147);
            this.panel1.TabIndex = 0;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Location = new System.Drawing.Point(18, 89);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(131, 44);
            this.btnexit.TabIndex = 5;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.button2_Click);
            this.btnexit.Paint += new System.Windows.Forms.PaintEventHandler(this.button2_Paint);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnlogin.Location = new System.Drawing.Point(155, 89);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(131, 44);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.button1_Click);
            this.btnlogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnlogin_Paint);
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(101, 53);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(181, 26);
            this.txtpass.TabIndex = 3;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(101, 18);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(181, 26);
            this.txtuser.TabIndex = 2;
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name :";
            // 
            // panelsetup
            // 
            this.panelsetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelsetup.Controls.Add(this.panel2);
            this.panelsetup.Location = new System.Drawing.Point(0, 0);
            this.panelsetup.Name = "panelsetup";
            this.panelsetup.Size = new System.Drawing.Size(1255, 733);
            this.panelsetup.TabIndex = 4;
            this.panelsetup.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btncompany);
            this.panel2.Controls.Add(this.btnsupplieradd);
            this.panel2.Controls.Add(this.btnproduct);
            this.panel2.Controls.Add(this.btncustomer);
            this.panel2.Controls.Add(this.btnsupplier);
            this.panel2.Controls.Add(this.btnuser);
            this.panel2.Controls.Add(this.btncategories);
            this.panel2.Controls.Add(this.btnspecies);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Location = new System.Drawing.Point(144, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 530);
            this.panel2.TabIndex = 23;
            // 
            // btncompany
            // 
            this.btncompany.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncompany.BackColor = System.Drawing.SystemColors.Highlight;
            this.btncompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncompany.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncompany.Location = new System.Drawing.Point(76, 75);
            this.btncompany.Name = "btncompany";
            this.btncompany.Size = new System.Drawing.Size(219, 100);
            this.btncompany.TabIndex = 28;
            this.btncompany.Text = "Company Profile";
            this.btncompany.UseVisualStyleBackColor = false;
            this.btncompany.Click += new System.EventHandler(this.btncompany_Click);
            this.btncompany.Paint += new System.Windows.Forms.PaintEventHandler(this.btncompany_Paint);
            // 
            // btnsupplieradd
            // 
            this.btnsupplieradd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsupplieradd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsupplieradd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupplieradd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsupplieradd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsupplieradd.Location = new System.Drawing.Point(673, 216);
            this.btnsupplieradd.Name = "btnsupplieradd";
            this.btnsupplieradd.Size = new System.Drawing.Size(219, 100);
            this.btnsupplieradd.TabIndex = 27;
            this.btnsupplieradd.Text = "Supplier Additional";
            this.btnsupplieradd.UseVisualStyleBackColor = false;
            this.btnsupplieradd.Click += new System.EventHandler(this.btnsupplieradd_Click);
            this.btnsupplieradd.Paint += new System.Windows.Forms.PaintEventHandler(this.btnsupplieradd_Paint);
            // 
            // btnproduct
            // 
            this.btnproduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnproduct.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproduct.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnproduct.Location = new System.Drawing.Point(371, 359);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Size = new System.Drawing.Size(219, 100);
            this.btnproduct.TabIndex = 26;
            this.btnproduct.Text = "Product Setup";
            this.btnproduct.UseVisualStyleBackColor = false;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            this.btnproduct.Paint += new System.Windows.Forms.PaintEventHandler(this.btnproduct_Paint);
            // 
            // btncustomer
            // 
            this.btncustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncustomer.BackColor = System.Drawing.SystemColors.Highlight;
            this.btncustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncustomer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncustomer.Location = new System.Drawing.Point(76, 359);
            this.btncustomer.Name = "btncustomer";
            this.btncustomer.Size = new System.Drawing.Size(219, 100);
            this.btncustomer.TabIndex = 25;
            this.btncustomer.Text = "Customer Setup";
            this.btncustomer.UseVisualStyleBackColor = false;
            this.btncustomer.Click += new System.EventHandler(this.btncustomer_Click_2);
            this.btncustomer.Paint += new System.Windows.Forms.PaintEventHandler(this.btncustomer_Paint_1);
            // 
            // btnsupplier
            // 
            this.btnsupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsupplier.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsupplier.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsupplier.Location = new System.Drawing.Point(672, 75);
            this.btnsupplier.Name = "btnsupplier";
            this.btnsupplier.Size = new System.Drawing.Size(219, 100);
            this.btnsupplier.TabIndex = 24;
            this.btnsupplier.Text = "Supplier Setup";
            this.btnsupplier.UseVisualStyleBackColor = false;
            this.btnsupplier.Click += new System.EventHandler(this.btnsupplier_Click_1);
            // 
            // btnuser
            // 
            this.btnuser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnuser.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnuser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnuser.Location = new System.Drawing.Point(76, 214);
            this.btnuser.Name = "btnuser";
            this.btnuser.Size = new System.Drawing.Size(219, 100);
            this.btnuser.TabIndex = 23;
            this.btnuser.Text = "User Setup";
            this.btnuser.UseVisualStyleBackColor = false;
            this.btnuser.Click += new System.EventHandler(this.btnuser_Click_1);
            this.btnuser.Paint += new System.Windows.Forms.PaintEventHandler(this.btnuser_Paint_1);
            // 
            // btncategories
            // 
            this.btncategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncategories.BackColor = System.Drawing.SystemColors.Highlight;
            this.btncategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncategories.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncategories.Location = new System.Drawing.Point(372, 215);
            this.btncategories.Name = "btncategories";
            this.btncategories.Size = new System.Drawing.Size(219, 100);
            this.btncategories.TabIndex = 22;
            this.btncategories.Text = "Processing Categories";
            this.btncategories.UseVisualStyleBackColor = false;
            this.btncategories.Click += new System.EventHandler(this.btncategories_Click);
            this.btncategories.Paint += new System.Windows.Forms.PaintEventHandler(this.btncategories_Paint);
            // 
            // btnspecies
            // 
            this.btnspecies.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnspecies.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnspecies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnspecies.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnspecies.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnspecies.Location = new System.Drawing.Point(372, 76);
            this.btnspecies.Name = "btnspecies";
            this.btnspecies.Size = new System.Drawing.Size(219, 100);
            this.btnspecies.TabIndex = 21;
            this.btnspecies.Text = "Species Setup";
            this.btnspecies.UseVisualStyleBackColor = false;
            this.btnspecies.Click += new System.EventHandler(this.btnspecies_Click_1);
            this.btnspecies.Paint += new System.Windows.Forms.PaintEventHandler(this.btnspecies_Paint_1);
            // 
            // btnback
            // 
            this.btnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnback.Location = new System.Drawing.Point(672, 360);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(219, 100);
            this.btnback.TabIndex = 20;
            this.btnback.Text = "back to main";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click_1);
            this.btnback.Paint += new System.Windows.Forms.PaintEventHandler(this.btnback_Paint_1);
            // 
            // btnmastersetup1
            // 
            this.btnmastersetup1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnmastersetup1.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnmastersetup1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmastersetup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmastersetup1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnmastersetup1.Location = new System.Drawing.Point(299, 290);
            this.btnmastersetup1.Name = "btnmastersetup1";
            this.btnmastersetup1.Size = new System.Drawing.Size(260, 121);
            this.btnmastersetup1.TabIndex = 17;
            this.btnmastersetup1.Text = "Master Setup";
            this.btnmastersetup1.UseVisualStyleBackColor = false;
            this.btnmastersetup1.Visible = false;
            this.btnmastersetup1.Click += new System.EventHandler(this.btnmastersetup1_Click);
            this.btnmastersetup1.Paint += new System.Windows.Forms.PaintEventHandler(this.btnmastersetup1_Paint);
            // 
            // btntransaction1
            // 
            this.btntransaction1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btntransaction1.BackColor = System.Drawing.SystemColors.Highlight;
            this.btntransaction1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntransaction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntransaction1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btntransaction1.Location = new System.Drawing.Point(627, 291);
            this.btntransaction1.Name = "btntransaction1";
            this.btntransaction1.Size = new System.Drawing.Size(260, 121);
            this.btntransaction1.TabIndex = 18;
            this.btntransaction1.Text = "Transaction";
            this.btntransaction1.UseVisualStyleBackColor = false;
            this.btntransaction1.Visible = false;
            this.btntransaction1.Click += new System.EventHandler(this.btntransaction1_Click);
            this.btntransaction1.Paint += new System.Windows.Forms.PaintEventHandler(this.btntransaction1_Paint);
            // 
            // btnlogout
            // 
            this.btnlogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlogout.BackColor = System.Drawing.Color.Orange;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnlogout.Location = new System.Drawing.Point(1077, 12);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(166, 45);
            this.btnlogout.TabIndex = 22;
            this.btnlogout.Text = " Logout";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Visible = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click_1);
            this.btnlogout.Paint += new System.Windows.Forms.PaintEventHandler(this.btnlogout_Paint_1);
            // 
            // pbbackground
            // 
            this.pbbackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbbackground.Location = new System.Drawing.Point(0, 0);
            this.pbbackground.Name = "pbbackground";
            this.pbbackground.Size = new System.Drawing.Size(1255, 733);
            this.pbbackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbbackground.TabIndex = 19;
            this.pbbackground.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1255, 733);
            this.Controls.Add(this.panelsetup);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnmastersetup1);
            this.Controls.Add(this.btntransaction1);
            this.Controls.Add(this.pbbackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelsetup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbbackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelsetup;
        private System.Windows.Forms.Button btnmastersetup1;
        private System.Windows.Forms.Button btntransaction1;
        private System.Windows.Forms.PictureBox pbbackground;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btncompany;
        private System.Windows.Forms.Button btnsupplieradd;
        private System.Windows.Forms.Button btnproduct;
        private System.Windows.Forms.Button btncustomer;
        private System.Windows.Forms.Button btnsupplier;
        private System.Windows.Forms.Button btnuser;
        private System.Windows.Forms.Button btncategories;
        private System.Windows.Forms.Button btnspecies;
        private System.Windows.Forms.Button btnback;
    }
}

