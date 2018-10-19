namespace Tallyfish
{
    partial class ListPacking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPacking));
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblproduksize = new System.Windows.Forms.Label();
            this.lblproduktype = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntLotCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(305, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIST OF PACKING";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.lblproduksize);
            this.panel3.Controls.Add(this.lblproduktype);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(847, 40);
            this.panel3.TabIndex = 3;
            // 
            // lblproduksize
            // 
            this.lblproduksize.AutoSize = true;
            this.lblproduksize.Location = new System.Drawing.Point(39, 13);
            this.lblproduksize.Name = "lblproduksize";
            this.lblproduksize.Size = new System.Drawing.Size(0, 13);
            this.lblproduksize.TabIndex = 32;
            // 
            // lblproduktype
            // 
            this.lblproduktype.AutoSize = true;
            this.lblproduktype.Location = new System.Drawing.Point(12, 13);
            this.lblproduktype.Name = "lblproduktype";
            this.lblproduktype.Size = new System.Drawing.Size(0, 13);
            this.lblproduktype.TabIndex = 31;
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(750, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 30;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CaseNo,
            this.Grade,
            this.Packing,
            this.IntLotCode,
            this.BestBefore});
            this.dataGridView1.Location = new System.Drawing.Point(9, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(831, 564);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // CaseNo
            // 
            this.CaseNo.HeaderText = "Case No";
            this.CaseNo.Name = "CaseNo";
            this.CaseNo.Width = 120;
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.Width = 120;
            // 
            // Packing
            // 
            this.Packing.HeaderText = "Packing";
            this.Packing.Name = "Packing";
            this.Packing.Width = 120;
            // 
            // IntLotCode
            // 
            this.IntLotCode.HeaderText = "Int Lot Code";
            this.IntLotCode.Name = "IntLotCode";
            this.IntLotCode.Width = 150;
            // 
            // BestBefore
            // 
            this.BestBefore.HeaderText = "Best Before Date";
            this.BestBefore.Name = "BestBefore";
            this.BestBefore.Width = 150;
            // 
            // ListPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 630);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListPacking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraceTales";
            this.Load += new System.EventHandler(this.listpacking_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Packing;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntLotCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BestBefore;
        private System.Windows.Forms.Label lblproduktype;
        private System.Windows.Forms.Label lblproduksize;
    }
}