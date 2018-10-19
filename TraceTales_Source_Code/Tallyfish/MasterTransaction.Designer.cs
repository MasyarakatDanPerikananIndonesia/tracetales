namespace Tallyfish
{
    partial class MenuTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuTransaction));
            this.btnsummary = new System.Windows.Forms.Button();
            this.paneltrx = new System.Windows.Forms.Panel();
            this.backtomain = new System.Windows.Forms.Button();
            this.btnstuffing = new System.Windows.Forms.Button();
            this.btnreceivingbox = new System.Windows.Forms.Button();
            this.btnpacking = new System.Windows.Forms.Button();
            this.btnretouching = new System.Windows.Forms.Button();
            this.btntrimming = new System.Windows.Forms.Button();
            this.btnreceiving = new System.Windows.Forms.Button();
            this.paneltrx.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsummary
            // 
            this.btnsummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsummary.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnsummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsummary.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsummary.Location = new System.Drawing.Point(390, 426);
            this.btnsummary.Name = "btnsummary";
            this.btnsummary.Size = new System.Drawing.Size(219, 100);
            this.btnsummary.TabIndex = 19;
            this.btnsummary.Text = "Summary Transaction";
            this.btnsummary.UseVisualStyleBackColor = false;
            this.btnsummary.Click += new System.EventHandler(this.btnsummary_Click);
            this.btnsummary.Paint += new System.Windows.Forms.PaintEventHandler(this.btnsummary_Paint);
            // 
            // paneltrx
            // 
            this.paneltrx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.paneltrx.Controls.Add(this.backtomain);
            this.paneltrx.Controls.Add(this.btnsummary);
            this.paneltrx.Controls.Add(this.btnstuffing);
            this.paneltrx.Controls.Add(this.btnreceivingbox);
            this.paneltrx.Controls.Add(this.btnpacking);
            this.paneltrx.Controls.Add(this.btnretouching);
            this.paneltrx.Controls.Add(this.btntrimming);
            this.paneltrx.Controls.Add(this.btnreceiving);
            this.paneltrx.Location = new System.Drawing.Point(1, 2);
            this.paneltrx.Name = "paneltrx";
            this.paneltrx.Size = new System.Drawing.Size(1275, 736);
            this.paneltrx.TabIndex = 6;
            this.paneltrx.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltrx_Paint);
            // 
            // backtomain
            // 
            this.backtomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backtomain.BackColor = System.Drawing.Color.Orange;
            this.backtomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backtomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backtomain.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.backtomain.Location = new System.Drawing.Point(675, 426);
            this.backtomain.Name = "backtomain";
            this.backtomain.Size = new System.Drawing.Size(219, 100);
            this.backtomain.TabIndex = 23;
            this.backtomain.Text = "Back to Main";
            this.backtomain.UseVisualStyleBackColor = false;
            this.backtomain.Click += new System.EventHandler(this.button3_Click);
            this.backtomain.Paint += new System.Windows.Forms.PaintEventHandler(this.button3_Paint);
            // 
            // btnstuffing
            // 
            this.btnstuffing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnstuffing.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnstuffing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstuffing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstuffing.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnstuffing.Location = new System.Drawing.Point(390, 284);
            this.btnstuffing.Name = "btnstuffing";
            this.btnstuffing.Size = new System.Drawing.Size(219, 100);
            this.btnstuffing.TabIndex = 17;
            this.btnstuffing.Text = "Stuffing";
            this.btnstuffing.UseVisualStyleBackColor = false;
            this.btnstuffing.Click += new System.EventHandler(this.btnstuffing_Click);
            this.btnstuffing.Paint += new System.Windows.Forms.PaintEventHandler(this.btnstuffing_Paint);
            // 
            // btnreceivingbox
            // 
            this.btnreceivingbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnreceivingbox.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnreceivingbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreceivingbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreceivingbox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnreceivingbox.Location = new System.Drawing.Point(675, 148);
            this.btnreceivingbox.Name = "btnreceivingbox";
            this.btnreceivingbox.Size = new System.Drawing.Size(219, 100);
            this.btnreceivingbox.TabIndex = 16;
            this.btnreceivingbox.Text = "Receiving from Other Processor";
            this.btnreceivingbox.UseVisualStyleBackColor = false;
            this.btnreceivingbox.Click += new System.EventHandler(this.btnreceivingbox_Click);
            this.btnreceivingbox.Paint += new System.Windows.Forms.PaintEventHandler(this.btnreceivingbox_Paint);
            // 
            // btnpacking
            // 
            this.btnpacking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnpacking.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnpacking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpacking.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnpacking.Location = new System.Drawing.Point(390, 148);
            this.btnpacking.Name = "btnpacking";
            this.btnpacking.Size = new System.Drawing.Size(219, 100);
            this.btnpacking.TabIndex = 15;
            this.btnpacking.Text = "Packing";
            this.btnpacking.UseVisualStyleBackColor = false;
            this.btnpacking.Click += new System.EventHandler(this.btnpacking_Click);
            this.btnpacking.Paint += new System.Windows.Forms.PaintEventHandler(this.btnpacking_Paint);
            // 
            // btnretouching
            // 
            this.btnretouching.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnretouching.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnretouching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnretouching.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnretouching.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnretouching.Location = new System.Drawing.Point(98, 426);
            this.btnretouching.Name = "btnretouching";
            this.btnretouching.Size = new System.Drawing.Size(219, 100);
            this.btnretouching.TabIndex = 14;
            this.btnretouching.Text = "Retouching";
            this.btnretouching.UseVisualStyleBackColor = false;
            this.btnretouching.Click += new System.EventHandler(this.btnretouching_Click);
            this.btnretouching.Paint += new System.Windows.Forms.PaintEventHandler(this.btnretouching_Paint);
            // 
            // btntrimming
            // 
            this.btntrimming.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btntrimming.BackColor = System.Drawing.SystemColors.Highlight;
            this.btntrimming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntrimming.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntrimming.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btntrimming.Location = new System.Drawing.Point(98, 284);
            this.btntrimming.Name = "btntrimming";
            this.btntrimming.Size = new System.Drawing.Size(219, 100);
            this.btntrimming.TabIndex = 13;
            this.btntrimming.Text = "Cutting";
            this.btntrimming.UseVisualStyleBackColor = false;
            this.btntrimming.Click += new System.EventHandler(this.btntrimming_Click);
            this.btntrimming.Paint += new System.Windows.Forms.PaintEventHandler(this.btntrimming_Paint);
            // 
            // btnreceiving
            // 
            this.btnreceiving.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnreceiving.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnreceiving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreceiving.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreceiving.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnreceiving.Location = new System.Drawing.Point(98, 148);
            this.btnreceiving.Name = "btnreceiving";
            this.btnreceiving.Size = new System.Drawing.Size(219, 100);
            this.btnreceiving.TabIndex = 12;
            this.btnreceiving.Text = "Receiving";
            this.btnreceiving.UseVisualStyleBackColor = false;
            this.btnreceiving.Click += new System.EventHandler(this.btnreceiving_Click);
            this.btnreceiving.Paint += new System.Windows.Forms.PaintEventHandler(this.btnreceiving_Paint);
            // 
            // MenuTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 741);
            this.Controls.Add(this.paneltrx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuTransaction";
            this.Text = "TraceTales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuTransaction_Load);
            this.paneltrx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnsummary;
        private System.Windows.Forms.Panel paneltrx;
        private System.Windows.Forms.Button btnstuffing;
        private System.Windows.Forms.Button btnreceivingbox;
        private System.Windows.Forms.Button btnpacking;
        private System.Windows.Forms.Button btnretouching;
        private System.Windows.Forms.Button btntrimming;
        private System.Windows.Forms.Button btnreceiving;
        private System.Windows.Forms.Button backtomain;
    }
}