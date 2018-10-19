using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tallyfish
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_customer();
            loaddatacustomer();
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void loaddatacustomer()
        {
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            MySqlConnection conn4 = null;
            conn4 = new MySqlConnection(connString);
            try
            {
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select * from tbcustomer order by custcode";
                MySqlDataReader rdr = cmd.ExecuteReader();
                int a = 0;
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbcustomer order by custcode";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView1.Rows[i].Height = 50;

                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("custcode");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("custname");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("phone");
                            dataGridView1.Rows[i].Cells[4].Value = rdr1.GetString("state");
                            dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("country");
                            dataGridView1.Rows[i].Cells[6].Value = rdr1.GetString("certificate");
                            i++;
                        }
                    }

                    Edit_columnbutton();
                    Delete_columnbutton();
                }
                else
                {
                    MessageBox.Show("Data Customer is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtcustcode.Clear();
                txtcustname.Clear();
                txtaddress.Clear();
                txtphone.Clear();
                txtcontactperson.Clear();
                txtstate.Clear();
                txtcertificate.Clear();
                cbcountry.Text = "";
            }
        }

        private void Delete_columnbutton(Bitmap image)
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Delete";
                iconColumn.HeaderText = "Delete";
                dataGridView1.Columns.Insert(8, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 75;
            }
        }


        private void save_customer()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcustomer", "custcode", txtcustcode.Text);
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
                //id=int.Parse(data[0][0].ToString());
            }
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                if (status.Equals("Not Ada"))
                {
                    mySql3.CommandText =
                    "Insert into tbcustomer(custcode,custname,address,phone,contact,state,country,certificate)" +
                    " values(@custcode,@custname,@address,@phone,@contact,@state,@country,@certificate)";
                }
                else
                {
                    mySql3.CommandText =
                    "Update tbcustomer Set custname=@custname,address=@address,phone=@phone,contact=@contact,state=@state,country=@country,certificate=@certificate where custcode=@custcode";
                }
                mySql3.Parameters.AddWithValue("@custcode", txtcustcode.Text);
                mySql3.Parameters.AddWithValue("@custname", txtcustname.Text);
                mySql3.Parameters.AddWithValue("@address", txtaddress.Text);
                mySql3.Parameters.AddWithValue("@phone", txtphone.Text);
                mySql3.Parameters.AddWithValue("@contact", txtcontactperson.Text);
                mySql3.Parameters.AddWithValue("@state", txtstate.Text);
                mySql3.Parameters.AddWithValue("@country", cbcountry.Text);
                mySql3.Parameters.AddWithValue("@certificate", txtcertificate.Text);
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data " + txtcustcode.Text + " stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            loaddatacustomer();
        }

        private void txtcustcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcustname.Focus();
            }

        }

        private void txtcustname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtaddress.Focus();
            }

        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcontactperson.Focus();
            }

        }

        private void txtcontactperson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtstate.Focus();
            }

        }

        private void txtstate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                cbcountry.Focus();
            }

        }

        private void cbcountry_TextChanged(object sender, EventArgs e)
        {
            txtcertificate.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Customer " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String customercode = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbcustomer", "custcode", customercode);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }

            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                txtcustcode.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                List<object[]> datacustomer;
                MainMenu frm = new MainMenu();
                datacustomer = frm.get_data_table_string("tbcustomer", "custcode", txtcustcode.Text.Trim());
                txtcustname.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtphone.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtstate.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbcountry.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtcertificate.Text = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtaddress.Text=datacustomer[0][3].ToString();
                txtcontactperson.Text = datacustomer[0][5].ToString();
            }
        }

        private void seticon_forbutton()
        {

            MainMenu frm = new MainMenu();
            frm.setbuttonicon("save", btnsave);
            frm.setbuttonicon("save", btnshippay);
        }

        private void load_country()
        {

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tb_countries", "", "");
            if (data.Count > 0)
            {
                cbcountry.Items.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    cbcountry.Items.Add(data[i][2].ToString());
                }
            }
            
       }


        private void frmCustomer_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            load_country();
            loaddatacustomer();
            cbcountry.Text = "Indonesia";
        }

        private void Edit_columnbutton()
        {

            if (dataGridView1.Columns.Contains("Edit") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(7, btn);
                btn.HeaderText = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 70;
            }
        }

        private void Delete_columnbutton()
        {

            if (dataGridView1.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 70;
            }
        }


        private void add_column_button(DataGridViewCellPaintingEventArgs e, String btn, Int32 colsidx)
        {
            if (e.ColumnIndex == colsidx)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 16; //Properties.Resources.SomeImage.Width;
                var h = 16; //Properties.Resources.SomeImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                var path = System.IO.Directory.GetCurrentDirectory();
                String icondir = path + "\\icon\\" + btn + ".png";
                System.Drawing.Image img = System.Drawing.Image.FromFile(icondir, true);
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "edit", 7);
            add_column_button(e, "delete", 8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMIncoterms frm = new frmMIncoterms();
            frm.ShowDialog();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
