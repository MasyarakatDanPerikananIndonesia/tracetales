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
    public partial class frmCompany : Form
    {
        public String provinsiid;
        public String kabupatenid;
        public String kecamatanid;
        public int id;

        public frmCompany()
        {
            InitializeComponent();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            //seticon_forbutton();
            loaddatacompany();
            loadprovinsi();           
        }


        private void seticon_forbutton()
        {

            MainMenu frm = new MainMenu();
            frm.setbuttonicon("edit", btneditcompany);
            frm.setbuttonicon("save", btnsavecompany);
        }





        private void loadprovinsi()
        {
            cbProvinsi.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("provinces", "", "");
            for (int i = 0; i < data.Count(); i++)
            {
                cbProvinsi.Items.Add(data[i][1].ToString());
            }

        }

       
        private void cbProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("provinces", "name", cbProvinsi.Text);
            provinsiid = data[0][0].ToString();
            loadkabupaten(provinsiid);
            cbKabupaten.Focus();
        }

        private void loadkabupaten(String value)
        {
            cbKabupaten.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("regencies", "province_id", value);
            for (int i = 0; i < data.Count(); i++)
            {
                cbKabupaten.Items.Add(data[i][2].ToString());
            }

        }


        private void loadkecamatan(String value)
        {
            cbKecamatan.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("districts", "regency_id", value);
            for (int i = 0; i < data.Count(); i++)
            {
                cbKecamatan.Items.Add(data[i][2].ToString());
            }

        }

        private void cbKabupaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("regencies", "name", cbKabupaten.Text);
            kabupatenid = data[0][0].ToString();
            loadkecamatan(kabupatenid);
            cbKecamatan.Focus();
        }

        private void cbKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("districts", "name", cbKecamatan.Text);
            kecamatanid = data[0][0].ToString();
            txtlicenseid.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_company();
            loaddatacompany();
            MessageBox.Show("Data " + txtcompany.Text + " stored");
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_company()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcompany", "companyid", txtcompany.Text);
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
                mySql3.CommandText =
                "Update tbcompany Set companyname=@companyname,owner=@owner,sex=@sex,licenseid=@licenseid,licenseexpdate=@licenseexpdate,address=@address,phone=@phone,provinceid=@provinceid,regencyid=@regencyid,districtid=@districtid,code=@code, comp_reg_no=@comp_reg_no, companyid=@companyid where id=@id";
                mySql3.Parameters.AddWithValue("@companyid", txtcompany.Text);
                mySql3.Parameters.AddWithValue("@companyname", txtcompanyname.Text);
                mySql3.Parameters.AddWithValue("@owner", txtowner.Text);
                String gender = "";
                if (rbmale.Checked)
                {
                    gender = "M";
                }
                else if (rbfemale.Checked)
                {
                    gender = "F";
                }


                List<object[]> dtarea = new List<object[]>();

                if (!cbProvinsi.Text.Equals(""))
                {
                    dtarea = frm.get_data_table_string("provinces", "name", cbProvinsi.Text);
                    provinsiid = dtarea[0][0].ToString();
                }

                if (!cbKabupaten.Text.Equals(""))
                {
                    dtarea = frm.get_data_table_string("regencies", "name", cbKabupaten.Text);
                    kabupatenid = dtarea[0][0].ToString();
                }

                if (!cbKecamatan.Text.Equals(""))
                {
                    dtarea = frm.get_data_table_string("districts", "name", cbKecamatan.Text);
                    kecamatanid = dtarea[0][0].ToString();
                }


                mySql3.Parameters.AddWithValue("@sex", gender);
                mySql3.Parameters.AddWithValue("@licenseid", txtlicenseid.Text);
                DateTime expdate = dateTimePicker1.Value.Date;
                mySql3.Parameters.AddWithValue("@licenseexpdate", expdate);
                mySql3.Parameters.AddWithValue("@address", txtaddress.Text);
                mySql3.Parameters.AddWithValue("@phone", txtphone.Text);
                mySql3.Parameters.AddWithValue("@provinceid", provinsiid);
                mySql3.Parameters.AddWithValue("@regencyid", kabupatenid);
                mySql3.Parameters.AddWithValue("@districtid", kecamatanid);
                mySql3.Parameters.AddWithValue("@code", txtcode.Text);
                mySql3.Parameters.AddWithValue("@comp_reg_no", txtcompanyregistration.Text.Trim());
                mySql3.Parameters.AddWithValue("@id", id);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
       }


        private void loaddatacompany()
        {
                List<object[]> datacompany;
                MainMenu frm = new MainMenu();
                datacompany = frm.get_data_table_string("view_company", "", "");
                txtcompany.Text = datacompany[0][1].ToString();
                txtcompanyname.Text = datacompany[0][2].ToString();
                txtowner.Text = datacompany[0][3].ToString();

                txtaddress.Text = datacompany[0][7].ToString();
                txtphone.Text = datacompany[0][8].ToString();
                cbProvinsi.Text = datacompany[0][16].ToString();
                cbKabupaten.Text = datacompany[0][17].ToString();
                cbKecamatan.Text = datacompany[0][18].ToString();
                txtlicenseid.Text = datacompany[0][5].ToString();
                txtcode.Text = datacompany[0][13].ToString();
                txtcompanyregistration.Text = datacompany[0][15].ToString();

               if (datacompany[0][4].ToString().Equals("M"))
                {
                    rbmale.Checked = true;
                    rbfemale.Checked = false;
                }
                else if (datacompany[0][4].ToString().Equals("F"))
                {
                    rbfemale.Checked = true;
                    rbmale.Checked = false;
                }
                dateTimePicker1.Value = DateTime.Parse(datacompany[0][6].ToString());
                txtcompany.Enabled = false;
                txtcompanyname.Enabled = false;
                txtowner.Enabled = false;
                txtaddress.Enabled = false;
                txtphone.Enabled = false;
                cbProvinsi.Enabled = false;
                cbKabupaten.Enabled = false;
                cbKecamatan.Enabled = false;
                txtlicenseid.Enabled = false;
                rbfemale.Enabled = false;
                rbmale.Enabled = false;
                dateTimePicker1.Enabled = false;
                txtcode.Enabled = false;
                txtcompanyregistration.Enabled = false;
        }


        private void txtcompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcompanyname.Focus();
            }

        }

        private void txtcompanyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtowner.Focus();
            }

        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                cbProvinsi.Focus();
            }

        }

        private void txtlicenseid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.dateTimePicker1.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcompany.Enabled = true;
            txtcompanyname.Enabled = true;
            txtowner.Enabled = true;
            txtaddress.Enabled = true;
            txtphone.Enabled = true;
            cbProvinsi.Enabled = true;
            cbKabupaten.Enabled = true;
            cbKecamatan.Enabled = true;
            txtlicenseid.Enabled = true;
            rbfemale.Enabled = true;
            rbmale.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtcode.Enabled = true;
            txtcompanyregistration.Enabled = true;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_fieldname("tbcompany","id","companyid",txtcompany.Text);
            if (data.Count > 0)
            {
                id = Int32.Parse(data[0][0].ToString());
            }
        }


     private void add_column_button(DataGridViewCellPaintingEventArgs e,String btn, Int32 colsidx)
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

     private void btnback_Click(object sender, EventArgs e)
     {
         this.Close();
     }
    }
}
