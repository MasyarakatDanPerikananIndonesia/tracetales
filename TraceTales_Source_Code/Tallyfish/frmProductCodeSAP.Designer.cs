namespace Tallyfish
{
    partial class frmProductCodeSAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductCodeSAP));
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cbproduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbgrade = new System.Windows.Forms.ComboBox();
            this.cbsize = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbcertificate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSAPItemCode = new System.Windows.Forms.TextBox();
            this.dgProductCodeSAP = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAPItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsave = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductCodeSAP)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(560, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Setup Product Code SAP";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1363, 40);
            this.panel3.TabIndex = 3;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(1264, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 28;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(53, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Product Name :";
            // 
            // cbproduct
            // 
            this.cbproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbproduct.FormattingEnabled = true;
            this.cbproduct.Location = new System.Drawing.Point(195, 71);
            this.cbproduct.Name = "cbproduct";
            this.cbproduct.Size = new System.Drawing.Size(551, 28);
            this.cbproduct.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(108, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Grade :";
            // 
            // cbgrade
            // 
            this.cbgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgrade.FormattingEnabled = true;
            this.cbgrade.Location = new System.Drawing.Point(195, 115);
            this.cbgrade.Name = "cbgrade";
            this.cbgrade.Size = new System.Drawing.Size(214, 28);
            this.cbgrade.TabIndex = 42;
            // 
            // cbsize
            // 
            this.cbsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsize.FormattingEnabled = true;
            this.cbsize.Location = new System.Drawing.Point(195, 158);
            this.cbsize.Name = "cbsize";
            this.cbsize.Size = new System.Drawing.Size(214, 28);
            this.cbsize.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(122, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Size :";
            // 
            // cbcertificate
            // 
            this.cbcertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcertificate.FormattingEnabled = true;
            this.cbcertificate.Location = new System.Drawing.Point(195, 204);
            this.cbcertificate.Name = "cbcertificate";
            this.cbcertificate.Size = new System.Drawing.Size(214, 28);
            this.cbcertificate.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(83, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Certificate :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(47, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "SAP Item Code :";
            // 
            // txtSAPItemCode
            // 
            this.txtSAPItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSAPItemCode.Location = new System.Drawing.Point(195, 251);
            this.txtSAPItemCode.Name = "txtSAPItemCode";
            this.txtSAPItemCode.Size = new System.Drawing.Size(214, 26);
            this.txtSAPItemCode.TabIndex = 48;
            // 
            // dgProductCodeSAP
            // 
            this.dgProductCodeSAP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductCodeSAP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ProductName,
            this.Grade,
            this.Size,
            this.Certificate,
            this.SAPItemCode});
            this.dgProductCodeSAP.Location = new System.Drawing.Point(12, 320);
            this.dgProductCodeSAP.Name = "dgProductCodeSAP";
            this.dgProductCodeSAP.RowHeadersVisible = false;
            this.dgProductCodeSAP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductCodeSAP.Size = new System.Drawing.Size(1338, 409);
            this.dgProductCodeSAP.TabIndex = 49;
            this.dgProductCodeSAP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProductCodeSAP_CellClick);
            this.dgProductCodeSAP.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgProductCodeSAP_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 300;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Certificate
            // 
            this.Certificate.HeaderText = "Certificate";
            this.Certificate.Name = "Certificate";
            // 
            // SAPItemCode
            // 
            this.SAPItemCode.HeaderText = "SAP Item Code";
            this.SAPItemCode.Name = "SAPItemCode";
            this.SAPItemCode.Width = 150;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Orange;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.Location = new System.Drawing.Point(451, 209);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(200, 75);
            this.btnsave.TabIndex = 50;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // frmProductCodeSAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgProductCodeSAP);
            this.Controls.Add(this.txtSAPItemCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbcertificate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbsize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbgrade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbproduct);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductCodeSAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductCodeSAP_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductCodeSAP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbproduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbgrade;
        private System.Windows.Forms.ComboBox cbsize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbcertificate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSAPItemCode;
        private System.Windows.Forms.DataGridView dgProductCodeSAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certificate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAPItemCode;
        private System.Windows.Forms.Button btnsave;
    }
}