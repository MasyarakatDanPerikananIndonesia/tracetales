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
    public partial class Supplier_Integration : Form
    {
        public Supplier_Integration()
        {
            InitializeComponent();
        }

        private void txtscansupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                string[] datasupplier= txtscansupplier.Text.Split(';');
                //InputReceiving frm = new InputReceiving();
                String global_suppcode = datasupplier[0].ToString();

                List<object[]> data = new List<object[]>();
                MainMenu frm = new MainMenu();
                data = frm.get_data_table_string("tbsupplier", "registration_code", global_suppcode);
                if (data.Count > 0)
                {
                    String suppliercode = data[0][2].ToString();
                    //this.Hide();
                    var frmInputReceiving = new InputReceiving();
                    frmInputReceiving.Closed += (s, args) => this.Close();
                    frmInputReceiving.set_supplier_integration(global_suppcode, sender, e);
                    frmInputReceiving.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Data Supplier for global registration " + global_suppcode + " is not available");
                    txtscansupplier.Clear();
                    txtscansupplier.Focus();
                }
            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Supplier_Integration_Load(object sender, EventArgs e)
        {
            txtscansupplier.Focus();
        }
    }
}
