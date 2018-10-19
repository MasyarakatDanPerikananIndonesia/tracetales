namespace Tallyfish
{
    partial class frmMSpecies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMSpecies));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupASFIS = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASFIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Species1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbinfo = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtasfiscode = new System.Windows.Forms.TextBox();
            this.txtscientificname = new System.Windows.Forms.TextBox();
            this.txtspeciesname = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scientificname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asfiscode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupASFIS.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.groupASFIS);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pbinfo);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txtasfiscode);
            this.panel2.Controls.Add(this.txtscientificname);
            this.panel2.Controls.Add(this.txtspeciesname);
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 695);
            this.panel2.TabIndex = 1;
            // 
            // groupASFIS
            // 
            this.groupASFIS.Controls.Add(this.panel1);
            this.groupASFIS.Controls.Add(this.button3);
            this.groupASFIS.Controls.Add(this.button1);
            this.groupASFIS.Controls.Add(this.txtsearch);
            this.groupASFIS.Controls.Add(this.label3);
            this.groupASFIS.Controls.Add(this.dataGridView1);
            this.groupASFIS.Location = new System.Drawing.Point(393, 70);
            this.groupASFIS.Name = "groupASFIS";
            this.groupASFIS.Size = new System.Drawing.Size(510, 616);
            this.groupASFIS.TabIndex = 15;
            this.groupASFIS.TabStop = false;
            this.groupASFIS.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 40);
            this.panel1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(178, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "LIST OF ASFIS CODE";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(417, 571);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 39);
            this.button3.TabIndex = 17;
            this.button3.Text = "Done";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(330, 571);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(71, 579);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(253, 20);
            this.txtsearch.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Search";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ASFIS,
            this.Species1,
            this.Species});
            this.dataGridView1.Location = new System.Drawing.Point(18, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(475, 509);
            this.dataGridView1.TabIndex = 13;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // ASFIS
            // 
            this.ASFIS.HeaderText = "ASFIS";
            this.ASFIS.Name = "ASFIS";
            this.ASFIS.Width = 70;
            // 
            // Species1
            // 
            this.Species1.HeaderText = "Scientific Name";
            this.Species1.Name = "Species1";
            this.Species1.Width = 140;
            // 
            // Species
            // 
            this.Species.HeaderText = "Species Name";
            this.Species.Name = "Species";
            this.Species.Width = 180;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(821, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Refresh";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(278, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "List";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pbinfo
            // 
            this.pbinfo.Location = new System.Drawing.Point(257, 62);
            this.pbinfo.Name = "pbinfo";
            this.pbinfo.Size = new System.Drawing.Size(18, 18);
            this.pbinfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbinfo.TabIndex = 13;
            this.pbinfo.TabStop = false;
            this.pbinfo.MouseHover += new System.EventHandler(this.pbinfo_MouseHover);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(361, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 67);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtasfiscode
            // 
            this.txtasfiscode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtasfiscode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtasfiscode.Location = new System.Drawing.Point(147, 59);
            this.txtasfiscode.Name = "txtasfiscode";
            this.txtasfiscode.Size = new System.Drawing.Size(106, 26);
            this.txtasfiscode.TabIndex = 10;
            this.txtasfiscode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtasfiscode_KeyPress);
            // 
            // txtscientificname
            // 
            this.txtscientificname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscientificname.Location = new System.Drawing.Point(147, 126);
            this.txtscientificname.Name = "txtscientificname";
            this.txtscientificname.Size = new System.Drawing.Size(326, 26);
            this.txtscientificname.TabIndex = 9;
            this.txtscientificname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscientificname_KeyPress);
            // 
            // txtspeciesname
            // 
            this.txtspeciesname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspeciesname.Location = new System.Drawing.Point(147, 94);
            this.txtspeciesname.Name = "txtspeciesname";
            this.txtspeciesname.Size = new System.Drawing.Size(326, 26);
            this.txtspeciesname.TabIndex = 7;
            this.txtspeciesname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtspeciesname_KeyPress);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.speciesname,
            this.scientificname,
            this.asfiscode});
            this.dataGridView2.Location = new System.Drawing.Point(24, 229);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(866, 463);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // speciesname
            // 
            this.speciesname.HeaderText = "Species Name";
            this.speciesname.Name = "speciesname";
            this.speciesname.Width = 200;
            // 
            // scientificname
            // 
            this.scientificname.HeaderText = "Scientific Name";
            this.scientificname.Name = "scientificname";
            this.scientificname.Width = 200;
            // 
            // asfiscode
            // 
            this.asfiscode.HeaderText = "Asfis Code";
            this.asfiscode.Name = "asfiscode";
            this.asfiscode.Width = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(28, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "ASFIS Code :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(8, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Scientific Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Species Name :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.btnback);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(907, 40);
            this.panel4.TabIndex = 1;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(810, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(360, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "SPECIES";
            // 
            // frmMSpecies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(917, 700);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMSpecies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Species Master";
            this.Load += new System.EventHandler(this.frmMSpecies_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupASFIS.ResumeLayout(false);
            this.groupASFIS.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtasfiscode;
        private System.Windows.Forms.TextBox txtscientificname;
        private System.Windows.Forms.TextBox txtspeciesname;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesname;
        private System.Windows.Forms.DataGridViewTextBoxColumn scientificname;
        private System.Windows.Forms.DataGridViewTextBoxColumn asfiscode;
        private System.Windows.Forms.PictureBox pbinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupASFIS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASFIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Species1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Species;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnback;
    }
}