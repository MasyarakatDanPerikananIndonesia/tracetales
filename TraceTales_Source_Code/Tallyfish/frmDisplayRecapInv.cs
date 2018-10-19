using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tallyfish
{
    public partial class frmDisplayRecapInv : Form
    {
        public frmDisplayRecapInv()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void setlabel(String label)
        {
            label1.Text = label;
        }

        private void frmDisplayRecapInv_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains("INVOICE RECAP"))
            {
                frmRecapInvoice frm = new frmRecapInvoice();
                frm.setTgl(dateTimePicker1.Value, dateTimePicker2.Value);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
