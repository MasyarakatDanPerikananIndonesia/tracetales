using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Tallyfish
{
    public partial class frmPO : Form
    {
        public frmPO()
        {
            InitializeComponent();
        }

        private void setoptioncustomer()
        {

            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcustomer", "", "");
            if (data.Count > 0)
            {
                cbcustomer.Items.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    cbcustomer.Items.Add(data[i][1].ToString());
                }
            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("new", btnnew);
            frm.setbuttonicon("down", btncompany);
        }


        private void frmPO_Load(object sender, EventArgs e)
        {
            setoptioncustomer();
            seticon_forbutton();
            loaddatapo();
        }

        private void cbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcustomer", "custcode", cbcustomer.Text.Trim());
            if (data.Count > 0)
            {
                lblCustomername.Text = data[0][2].ToString();
            }
            txtpo.Focus();
        }


        private String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_po()
        {

            String pono = txtpo.Text.Trim();
            //save in plnoglobal

            String cust = cbcustomer.Text.Trim();
            String remark = txtremark.Text.Trim();

            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tbpo(pono, customerid,remark)" +
                " values(@pono, @customerid,@remark)";
                mySql3.Parameters.AddWithValue("@pono", pono);
                mySql3.Parameters.AddWithValue("@customerid", cust);
                mySql3.Parameters.AddWithValue("@remark", remark);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }


        private void loaddatapo()
        {
            dataGridView1.Rows.Clear();
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbpo", "", "");
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][3].ToString();
                }
                Delete_columnbutton();
            }
        }


        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(4, btn);

                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }



        private void btnnew_Click(object sender, EventArgs e)
        {
            save_po();
            loaddatapo();
            cbcustomer.Text = "";
            txtpo.Text = "";
            txtremark.Text = "";
            MessageBox.Show("Data PO has been stored");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            loaddatapo();
        }

        private void add_column_button(DataGridViewCellPaintingEventArgs e, String btn, Int32 colsidx)
        {
            if (e.ColumnIndex == colsidx)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 16;
                var h = 16;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                var path = Directory.GetCurrentDirectory();
                String icondir = path + "\\icon\\" + btn + ".png";
                System.Drawing.Image img = System.Drawing.Image.FromFile(icondir, true);
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete  " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String pono=this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Int32 n = e.RowIndex;
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbpo", "pono", this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    loaddatapo();
                    MessageBox.Show("Data PO " + pono + " has been deleted");
                }
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 4);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            /*
            var frm = new InputStuffing();
            frm.Closed += (s, args) => this.Close();
            frm.setoptionpo();
            frm.ShowDialog();
             */ 
        }

        private void btncompany_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btncompany.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btncompany_Click(object sender, EventArgs e)
        {
            cbcustomer.DroppedDown = true;
        }

        private void txtpo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtremark.Focus();
            }

        }
    }
}
