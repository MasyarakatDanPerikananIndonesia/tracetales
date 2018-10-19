namespace Tallyfish
{
    partial class Supplier_Integration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supplier_Integration));
            this.txtscansupplier = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtscansupplier
            // 
            this.txtscansupplier.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscansupplier.Location = new System.Drawing.Point(565, 201);
            this.txtscansupplier.Name = "txtscansupplier";
            this.txtscansupplier.Size = new System.Drawing.Size(341, 38);
            this.txtscansupplier.TabIndex = 24;
            this.txtscansupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscansupplier_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(591, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(277, 31);
            this.label13.TabIndex = 23;
            this.label13.Text = "Scan Supplier Code Global";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Location = new System.Drawing.Point(215, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(922, 183);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnback
            // 
            this.btnback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback.BackColor = System.Drawing.Color.Orange;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(925, 1);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(93, 37);
            this.btnback.TabIndex = 29;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // Supplier_Integration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 733);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.txtscansupplier);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Supplier_Integration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier_Integration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Supplier_Integration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtscansupplier;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnback;
    }
}