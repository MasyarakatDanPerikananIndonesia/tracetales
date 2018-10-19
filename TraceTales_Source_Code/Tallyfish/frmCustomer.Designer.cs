namespace Tallyfish
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnshippay = new System.Windows.Forms.Button();
            this.cbcountry = new System.Windows.Forms.ComboBox();
            this.txtcertificate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcustname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtstate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcontactperson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcustcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnshippay);
            this.panel2.Controls.Add(this.cbcountry);
            this.panel2.Controls.Add(this.txtcertificate);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtcustname);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtstate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtcontactperson);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtphone);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnsave);
            this.panel2.Controls.Add(this.txtaddress);
            this.panel2.Controls.Add(this.txtcustcode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 736);
            this.panel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 516);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "-";
            // 
            // btnshippay
            // 
            this.btnshippay.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnshippay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshippay.ForeColor = System.Drawing.Color.White;
            this.btnshippay.Location = new System.Drawing.Point(196, 423);
            this.btnshippay.Name = "btnshippay";
            this.btnshippay.Size = new System.Drawing.Size(180, 74);
            this.btnshippay.TabIndex = 24;
            this.btnshippay.Text = "Shipment Terms && Payment Terms ";
            this.btnshippay.UseVisualStyleBackColor = false;
            this.btnshippay.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbcountry
            // 
            this.cbcountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcountry.FormattingEnabled = true;
            this.cbcountry.Items.AddRange(new object[] {
            "Indonesia",
            "Vietnam",
            "Thailand",
            "Philiphine"});
            this.cbcountry.Location = new System.Drawing.Point(160, 263);
            this.cbcountry.Name = "cbcountry";
            this.cbcountry.Size = new System.Drawing.Size(215, 26);
            this.cbcountry.TabIndex = 23;
            this.cbcountry.TextChanged += new System.EventHandler(this.cbcountry_TextChanged);
            // 
            // txtcertificate
            // 
            this.txtcertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcertificate.Location = new System.Drawing.Point(160, 297);
            this.txtcertificate.Name = "txtcertificate";
            this.txtcertificate.Size = new System.Drawing.Size(217, 24);
            this.txtcertificate.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(12, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "Operation License ID";
            // 
            // txtcustname
            // 
            this.txtcustname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustname.Location = new System.Drawing.Point(160, 80);
            this.txtcustname.Name = "txtcustname";
            this.txtcustname.Size = new System.Drawing.Size(217, 24);
            this.txtcustname.TabIndex = 20;
            this.txtcustname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcustname_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(81, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Country";
            // 
            // txtstate
            // 
            this.txtstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstate.Location = new System.Drawing.Point(160, 231);
            this.txtstate.Name = "txtstate";
            this.txtstate.Size = new System.Drawing.Size(217, 24);
            this.txtstate.TabIndex = 17;
            this.txtstate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtstate_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(98, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "State";
            // 
            // txtcontactperson
            // 
            this.txtcontactperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontactperson.Location = new System.Drawing.Point(160, 199);
            this.txtcontactperson.Name = "txtcontactperson";
            this.txtcontactperson.Size = new System.Drawing.Size(217, 24);
            this.txtcontactperson.TabIndex = 15;
            this.txtcontactperson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcontactperson_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(31, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Contact Person";
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.Location = new System.Drawing.Point(160, 168);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(217, 24);
            this.txtphone.TabIndex = 13;
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtphone_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(44, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Phone/Mobile";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(197, 340);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(180, 69);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.Location = new System.Drawing.Point(160, 112);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(217, 50);
            this.txtaddress.TabIndex = 10;
            // 
            // txtcustcode
            // 
            this.txtcustcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustcode.Location = new System.Drawing.Point(160, 50);
            this.txtcustcode.Name = "txtcustcode";
            this.txtcustcode.Size = new System.Drawing.Size(217, 24);
            this.txtcustcode.TabIndex = 7;
            this.txtcustcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcustcode_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(80, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Customer Name*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(28, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer Code*";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 40);
            this.panel4.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(151, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "CUSTOMER";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(409, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 736);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(946, 40);
            this.panel3.TabIndex = 2;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(851, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 27;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(21, 10);
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
            this.label12.Location = new System.Drawing.Point(423, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "LIST OF CUSTOMER";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CustCode,
            this.CustName,
            this.Phone,
            this.State,
            this.Country,
            this.Certificate});
            this.dataGridView1.Location = new System.Drawing.Point(28, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(918, 676);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // CustCode
            // 
            this.CustCode.HeaderText = "Cust Code";
            this.CustCode.Name = "CustCode";
            // 
            // CustName
            // 
            this.CustName.HeaderText = "Cust Name";
            this.CustName.Name = "CustName";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            // 
            // Certificate
            // 
            this.Certificate.HeaderText = "Certificate";
            this.Certificate.Name = "Certificate";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomer";
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcustname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtstate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcontactperson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcustcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certificate;
        private System.Windows.Forms.TextBox txtcertificate;
        private System.Windows.Forms.ComboBox cbcountry;
        private System.Windows.Forms.Button btnshippay;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label6;
    }
}