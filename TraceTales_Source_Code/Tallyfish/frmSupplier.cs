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
    public partial class frmSupplier : Form
    {
        public static String typefish;
        public static String species;
        public static String certificate;
        public  String options;
        public static String provinsiid;
        public static String kabupatenid;
        public static String kecamatanid;
        public static String desaid;

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_supplier();
            loaddatasupplier();
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }

        private void loaddatasupplier()
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
                cmd.CommandText = "select * from view_supplier order by suppcode";
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
                    cmd1.CommandText = "select * from view_supplier order by suppcode";
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
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("batchcode");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("suppcode");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("suppname");
                            if (!rdr1.IsDBNull(rdr1.GetOrdinal("kabupaten")))
                            {
                                dataGridView1.Rows[i].Cells[4].Value = rdr1.GetString("kabupaten");
                            }
                            if (!rdr1.IsDBNull(rdr1.GetOrdinal("kecamatan")))
                            {
                                dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("kecamatan");
                            }
                            
                            dataGridView1.Rows[i].Cells[6].Value = rdr1.GetString("landingsite");
                            dataGridView1.Rows[i].Cells[7].Value = rdr1.GetString("fishingground");
                            dataGridView1.Rows[i].Cells[8].Value = rdr1.GetString("countryorigin");
                            i++;
                        }
                    }

                    //Vessel
                    Vessel_columnbutton();


                    //Edit button
                    Edit_columnbutton();

                    //Delete button
                    Delete_columnbutton();
                }
                else
                {
                    MessageBox.Show("Data Supplier is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtbatch.Clear();
                txtsuppcode.Clear();
                txtsuppname.Clear();
                cbProvinsi.Text = "";
                cbKabupaten.Text = "";
                cbKecamatan.Text = "";
                cbDesa.Text = "";
                txtlandingsite.Clear();
                cbfishingground.Text = "";
                txtlandingsite.Clear();
                txtcertificate.Clear();
                txtperson.Text = "";
                cbsex.Text = "Male";
                txtcompany.Text = "";
                txtcoordinate.Text = "";
                txtregistration.Text = "";
                dateTimePicker1.Value = DateTime.Now;

                for (int i = 0; i <= (clTypeFish.Items.Count - 1); i++)
                {
                        clTypeFish.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clSpecies.Items.Count - 1); i++)
                {
                    clSpecies.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clCertificate.Items.Count - 1); i++)
                {
                    clCertificate.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clOptions.Items.Count - 1); i++)
                {
                    clOptions.SetItemCheckState(i, CheckState.Unchecked);
                }

            }
        }








        private void save_supplier()
        {

            //Type Fish
            for (int i = 0; i < clTypeFish.Items.Count; i++)
            {
                if (clTypeFish.GetItemChecked(i))
                {
                    if (!typefish.Equals("") && !typefish.Contains((string)clTypeFish.Items[i]))
                    {
                        typefish = typefish + "," + (string)clTypeFish.Items[i];
                    }
                    else
                    {
                        typefish = (string)clTypeFish.Items[i];
                    }
                }
            }


            //Species
            for (int i = 0; i < clSpecies.Items.Count; i++)
            {
                if (clSpecies.GetItemChecked(i))
                {
                    if (!species.Equals("") && !species.Contains((string)clSpecies.Items[i]))
                    {
                        species = species + "," + (string)clSpecies.Items[i];
                    }
                    else
                    {
                        species = (string)clSpecies.Items[i];
                    }
                }
            }


            //Certificate
            for (int i = 0; i < clCertificate.Items.Count; i++)
            {
                if (clCertificate.GetItemChecked(i))
                {

                    if (!certificate.Equals("") && !certificate.Contains((string)clCertificate.Items[i]))
                    {
                        certificate = certificate +", "+(string)clCertificate.Items[i];
                    }
                    else
                    {
                        certificate = (string)clCertificate.Items[i];
                    }
                }
            }


            //Options
            options = "";
            for (int i = 0; i < clOptions.Items.Count; i++)
            {
                if (clOptions.GetItemChecked(i))
                {

                    String val = (string)clOptions.Items[i];
                    if (!options.Equals("") && !options.Contains((string)clOptions.Items[i]))
                    {
                        options = options + ", " + (string)clOptions.Items[i];
                    }
                    else
                    {
                        options = (string)clOptions.Items[i];
                    }
                }
            }


            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsupplier", "suppcode", txtsuppcode.Text);
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
                    "Insert into tbsupplier(batchcode,suppcode,suppname,province,regencies,district,village,fishingground,landingsite,countryorigin,typefish,species,certificate,certificatecode,moddatetime,person, sex, licenseid,licenseexpdate,phone, options, companyname, landing_coordinate,registration_code)" +
                    " values(@batchcode,@suppcode,@suppname,@province,@regencies,@district,@village,@fishingground,@landingsite,@countryorigin,@typefish,@species,@certificate,@certificatecode,@moddatetime,@person, @sex, @licenseid,@licenseexpdate,@phone,@options,@companyname,@landing_coordinate,@registration_code)";
                }
                else
                {
                    mySql3.CommandText =
                    "Update tbsupplier Set batchcode=@batchcode,suppcode=@suppcode,suppname=@suppname,province=@province,regencies=@regencies,district=@district,village=@village,fishingground=@fishingground,landingsite=@landingsite,countryorigin=@countryorigin,typefish=@typefish,species=@species,certificate=@certificate,certificatecode=@certificatecode,moddatetime=@moddatetime, person=@person, sex=@sex, licenseid=@licenseid,licenseexpdate=@licenseexpdate,phone=@phone, options=@options, companyname=@companyname, landing_coordinate=@landing_coordinate, registration_code=@registration_code where suppcode=@suppcode";
                }


                //Filter batch code
                if (txtbatch.Text.Trim().Length == 0)
                {
                    txtbatch.Text = "000";
                }
                mySql3.Parameters.AddWithValue("@batchcode", txtbatch.Text);
                mySql3.Parameters.AddWithValue("@suppcode", txtsuppcode.Text);
                mySql3.Parameters.AddWithValue("@suppname", txtsuppname.Text);

                if (cbProvinsi.Text.Trim().Equals(""))
                {
                    provinsiid = "00";
                }
                if (cbKabupaten.Text.Trim().Equals(""))
                {
                    kabupatenid = "00";
                }
                if (cbKecamatan.Text.Trim().Equals(""))
                {
                    kecamatanid = "00";
                }
                if (cbDesa.Text.Trim().Equals(""))
                {
                    desaid= "00";
                }

                mySql3.Parameters.AddWithValue("@province", provinsiid);
                mySql3.Parameters.AddWithValue("@regencies", kabupatenid);
                mySql3.Parameters.AddWithValue("@district", kecamatanid);
                mySql3.Parameters.AddWithValue("@village", desaid);               
                mySql3.Parameters.AddWithValue("@fishingground", cbfishingground.Text);
                mySql3.Parameters.AddWithValue("@countryorigin", cbcountryorigin.Text);
                mySql3.Parameters.AddWithValue("@landingsite", txtlandingsite.Text);
                mySql3.Parameters.AddWithValue("@typefish", typefish);
                mySql3.Parameters.AddWithValue("@species", species);
                mySql3.Parameters.AddWithValue("@certificate", certificate);
                mySql3.Parameters.AddWithValue("@options", options);
                mySql3.Parameters.AddWithValue("@certificatecode", txtcertificate.Text);
                DateTime dt = DateTime.Now;
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.Parameters.AddWithValue("@person", txtperson.Text);
                mySql3.Parameters.AddWithValue("@sex", cbsex.Text);
                mySql3.Parameters.AddWithValue("@licenseid", txtlicense.Text);
                DateTime tgl = dateTimePicker1.Value.Date;
                mySql3.Parameters.AddWithValue("@licenseexpdate", DateTime.Parse(tgl.ToString("yyyy-MM-dd")));
                mySql3.Parameters.AddWithValue("@phone", txtphone.Text);
                mySql3.Parameters.AddWithValue("@companyname", txtcompany.Text);
                mySql3.Parameters.AddWithValue("@landing_coordinate", txtcoordinate.Text);
                mySql3.Parameters.AddWithValue("@registration_code", txtregistration.Text);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show("Data " + txtsuppname.Text + " stored");
        }



        private void save_category_setup(String value)
        {
            MainMenu frm = new MainMenu();
            //get data from table
            String value2 = txtdescription.Text.Trim();
            List<object[]> data = new List<object[]>();
            data=frm.get_data_table_string_2param("tbsetup", "category", value, "optionremark", value2);

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
                    "Insert into tbsetup(optionremark,category)" +
                    " values(@optionremark,@category)";
                    mySql3.Parameters.AddWithValue("@optionremark", txtdescription.Text);
                    mySql3.Parameters.AddWithValue("@category", value);
                    mySql3.ExecuteNonQuery();
                    MessageBox.Show("Data " + txtdescription.Text + " stored");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            
        }


        private void loadcategorysetup(String value)
        {
            dataGridView2.Rows.Clear();
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            MySqlConnection conn4 = null;
            conn4 = new MySqlConnection(connString);
            try
            {
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select * from tbsetup where category=@category";
                cmd.Parameters.AddWithValue("@category", value);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int a = 0;
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbsetup where category=@category";
                    cmd1.Parameters.AddWithValue("@category", value);

                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView2.Rows[i].Height = 50;
                            dataGridView2.Rows[i].Cells[0].Value = rdr1.GetString("optionremark");
                            i++;
                        }
                    }

                    Delete_setup_columnbutton();
                }
                else
                {
                    //MessageBox.Show("Data "+ labelsetup.Text + " is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtdescription.Clear();
            }
        }



        private void Delete_setup_columnbutton()
        {

            if (dataGridView2.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView2.Columns.Insert(11, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
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
                dataGridView1.Columns.Insert(11, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 75;
            }
        }


        private void Delete_columnbutton_supplier(Bitmap image)
        {
            if (dataGridView2.Columns.Contains("Delete") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Delete";
                iconColumn.HeaderText = "Delete";
                dataGridView2.Columns.Insert(2, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 75;
            }
        }


        private void Vessel_columnbutton(Bitmap image)
        {
            if (dataGridView1.Columns.Contains("Vessel") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Vessel";
                iconColumn.HeaderText = "Vessel";
                dataGridView1.Columns.Insert(9, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 75;
            }
        }


        private void Edit_columnbutton(Bitmap image)
        {
            if (dataGridView1.Columns.Contains("Edit") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Edit";
                iconColumn.HeaderText = "Edit";
                dataGridView1.Columns.Insert(10, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 75;
            }
        }
        

        
        private void txtsuppcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtsuppname.Focus();
            }

        }

        private void txtsuppname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcompany.Focus();
            }

        }


        private void txtfleet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                cbfishingground.Focus();
            }

        }

        private void cbfishingarea_Validated(object sender, EventArgs e)
        {
            cbcountryorigin.Focus();
        }

        private void cbcountryorigin_Validated(object sender, EventArgs e)
        {
            txtcertificate.Focus();
        }

        private void txtftfacode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnsave.Focus();
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {
            loaddatasupplier();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }
            
            
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Supplier " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String suppliercode= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    MainMenu frm = new MainMenu();


                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "update tbsupplier set suppcode='4del', batchcode='', suppname='', fishingground='',countryorigin='',typefish='',species='',certificate='',moddatetime=@moddatetime where suppcode=@suppcode";
                    mySql3.Parameters.AddWithValue("@suppcode", suppliercode);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                    conn5.Close();

                    //frm.delete_table("tbsupplier", "suppcode", suppliercode);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["Vessel"].Index && e.RowIndex >= 0)
            {

                    String suppliercode= this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    String suppname = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frmVessel frm = new frmVessel();
                    frm.set_suppcode(suppliercode);
                    frm.set_suppname(suppname);
                    frm.ShowDialog();
             }


            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                            List<object[]> datasupplier=new List<object[]>();
                            txtsuppcode.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            MainMenu frm = new MainMenu();
                            txtbatch.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtsuppcode.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                            String msql = "select a.*, b.name as provinsi, c.name as kabupaten, d.name as kecamatan, e.name as desa from tbsupplier a left outer join provinces b on a.province=b.id left outer join regencies c on a.regencies=c.id left outer join districts d on a.district=d.id left outer join villages e on a.village=e.id where a.suppcode=@suppcode";
                            String connString = Konek();
                            MySqlConnection conn3 = null;
                            conn3 = new MySqlConnection(connString);
                            conn3.Open();
                            MySqlCommand cmd = new MySqlCommand("", conn3);
                            cmd.CommandText = msql;
                            cmd.Parameters.AddWithValue("@suppcode", txtsuppcode.Text.Trim());
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            int a;
                            
                            while (rdr.Read())
                            {
                                if (rdr.IsDBNull(0))
                                {
                                    a = 0;
                                }
                                else
                                {
                                    a = 1;
                                }

                                object[] tempRow = new object[rdr.FieldCount];
                                for (int i = 0; i < rdr.FieldCount; i++)
                                {
                                    tempRow[i] = rdr[i];
                                }
                                datasupplier.Add(tempRow);

                                //datasupplier.Add(tempRow);
                            }
                            conn3.Close();
                            //datasupplier = frm.get_data_table_string("view_supplier", "suppcode", txtsuppcode.Text.Trim());

                            txtsuppname.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtcompany.Text = datasupplier[0][22].ToString();
                            txtperson.Text = datasupplier[0][16].ToString();

                            cbProvinsi.Text = datasupplier[0][25].ToString();
                            cbKabupaten.Text = datasupplier[0][26].ToString();
                            cbKecamatan.Text = datasupplier[0][27].ToString();
                            cbDesa.Text = datasupplier[0][28].ToString();
                            txtlandingsite.Text = datasupplier[0][8].ToString();
                            txtcoordinate.Text = datasupplier[0][23].ToString();
                            txtregistration.Text = datasupplier[0][24].ToString();

                            cbfishingground.Text = datasupplier[0][7].ToString();
                            cbcountryorigin.Text = datasupplier[0][9].ToString();
                            cbsex.Text = datasupplier[0][17].ToString();
                            String jenisfish = "";
                            //checked type of fish
                            jenisfish = datasupplier[0][10].ToString().ToLower();
                            Int32 count = clTypeFish.Items.Count;
                            String option;
                            for (int i = 0; i <= (clTypeFish.Items.Count - 1); i++)
                            {
                                option = clTypeFish.Items[i].ToString().ToLower();
                                if (jenisfish.ToLower().Contains(option))
                                {
                                    clTypeFish.SetItemCheckState(i, CheckState.Checked);
                                }
                                else
                                {
                                    clTypeFish.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }

                            //checked species
                            String jenisspecies = "";
                            jenisspecies = datasupplier[0][11].ToString().ToLower();
                            count = clSpecies.Items.Count;
                            for (int i = 0; i <= (clSpecies.Items.Count - 1); i++)
                            {
                                option = clSpecies.Items[i].ToString().ToLower();
                                if (jenisspecies.ToLower().Contains(option))
                                {
                                    clSpecies.SetItemCheckState(i, CheckState.Checked);
                                }
                                else
                                {
                                    clSpecies.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }


                            //checked certificate
                            String jeniscertificate = "";
                            jeniscertificate = datasupplier[0][12].ToString().ToLower();
                            count = clCertificate.Items.Count;
                            for (int i = 0; i <= (clCertificate.Items.Count - 1); i++)
                            {
                                option = clCertificate.Items[i].ToString().ToLower();
                                if (jeniscertificate.ToLower().Contains(option))
                                {
                                    clCertificate.SetItemCheckState(i, CheckState.Checked);
                                }
                                else
                                {
                                    clCertificate.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }

                            //checked options
                            String jenisoptions= "";
                            jenisoptions = datasupplier[0][21].ToString().ToLower();
                            count = clOptions.Items.Count;
                            for (int i = 0; i <= (clOptions.Items.Count - 1); i++)
                            {
                                option = clOptions.Items[i].ToString().ToLower();
                                if (jenisoptions.ToLower().Contains(option))
                                {
                                    clOptions.SetItemCheckState(i, CheckState.Checked);
                                }
                                else
                                {
                                    clOptions.SetItemCheckState(i, CheckState.Unchecked);
                                }
                            }  
            }
        }

        private void Edit_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Edit") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(10, btn);
                btn.HeaderText = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(11, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }


        private void Vessel_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Vessel") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(9, btn);
                btn.HeaderText = "Vessel";
                btn.Name = "Vessel";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void refreshdatacbbox(String value)
        {
            MainMenu frm = new MainMenu();
            try
            {
                if (value.Equals("Supplier Group"))
                {
                    cbProvinsi.Items.Clear();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tbsetup", "category", value);
                    if (data.Count > 0)
                    {
                        //to put value in combobox
                        for (int i = 0; i < data.Count; i++)
                        {
                            cbProvinsi.Items.Add(data[i][1]);
                        }
                    }
                }
                else if (value.Equals("Fishing Area"))
                {

                    cbfishingground.Items.Clear();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tbsetup", "category", value);
                    if (data.Count > 0)
                    {
                        //to put value in combobox
                        for (int i = 0; i < data.Count; i++)
                        {
                            cbfishingground.Items.Add(data[i][1]);
                        }
                    }
                }
                else if (value.Equals("Country Origin"))
                {

                    cbcountryorigin.Items.Clear();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tb_countries", "", "");
                    if (data.Count > 0)
                    {
                        //to put value in combobox
                        for (int i = 0; i < data.Count; i++)
                        {
                            cbcountryorigin.Items.Add(data[i][2]);
                        }
                    }
                    cbcountryorigin.Text = "Indonesia";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            pnlSupplierGroup.Visible = true;
            labelsetup.Text = "Fishing Area";
            loadcategorysetup(labelsetup.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pnlSupplierGroup.Visible = true;
            labelsetup.Text = "Country Origin";
            loadcategorysetup(labelsetup.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save_category_setup(labelsetup.Text);
            loadcategorysetup(labelsetup.Text);
            refreshdatacbbox(labelsetup.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlSupplierGroup.Visible = false;
        }


        private void set_icon_info()
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\information.png";
            pbinfo1.Image = Image.FromFile(icondir);
            pbinfo2.Image = Image.FromFile(icondir);
            pbinfo3.Image = Image.FromFile(icondir);
            pbinfo4.Image = Image.FromFile(icondir);
            pbinfo5.Image = Image.FromFile(icondir);

            MainMenu frm = new MainMenu();
            frm.setbuttonicon("search", btnsearch);
        }


        private void frmSupplier_Load(object sender, EventArgs e)
        {
            set_icon_info();
            typefish="";
            species="";
            certificate="";
            provinsiid="";
            kabupatenid="";
            kecamatanid="";
            desaid="";
           
            optiontypefish();
            optionspecies();
            optioncertificate();
            optionoptions();
            loadprovinsi();
            //refreshdatacbbox("Supplier Group");
            refreshdatacbbox("Fishing Area");
            refreshdatacbbox("Country Origin");
            loaddatasupplier();
            Vessel_columnbutton();
            Edit_columnbutton();
            Delete_columnbutton();
            cbcountryorigin.Text = "Indonesia";
            txtbatch.Focus();
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


        private void optiontypefish()
        {
            clTypeFish.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "Lotseq", "1");
            for (int i = 0; i < data.Count(); i++)
            {
                clTypeFish.Items.Add(data[i][1].ToString());
            }
            
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            typefish = "";
            var checkBox = (CheckBox)sender;
            //no need to check bools against true or false, they evaluate themselves
            if (checkBox.Checked)
            {
                if (!typefish.Equals(""))
                {
                    typefish = typefish + "," + checkBox.Text;
                }
                else
                {
                    typefish = checkBox.Text;
                }
            }
        }



        private void optionspecies()
        {
            clSpecies.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbspecies", "", "");
            for (int i = 0; i < data.Count(); i++)
            {
                clSpecies.Items.Add(data[i][1].ToString());
            }

        }

        private void checkbox_CheckedChangedSpecies(object sender, EventArgs e)
        {
            species = "";
            var checkBox = (CheckBox)sender;
            //no need to check bools against true or false, they evaluate themselves
            if (checkBox.Checked)
            {
                if (!species.Equals(""))
                {
                    species = species + "," + checkBox.Text;
                }
                else
                {
                    species = checkBox.Text;
                }
            }
        }


        private void optioncertificate()
        {
            clCertificate.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "Lotseq", "2");
            for (int i = 0; i < data.Count(); i++)
            {
                clCertificate.Items.Add(data[i][1].ToString());
            }

        }

        private void optionoptions()
        {
            clOptions.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "Lotseq", "3");
            for (int i = 0; i < data.Count(); i++)
            {
                clOptions.Items.Add(data[i][1].ToString());
            }
        }



        private void checkbox_CheckedChangedCertificate(object sender, EventArgs e)
        {
            certificate = "";
            var checkBox = (CheckBox)sender;
            //no need to check bools against true or false, they evaluate themselves
            if (checkBox.Checked)
            {
                if (!certificate.Equals(""))
                {
                    certificate = certificate + "," + checkBox.Text;
                }
                else
                {
                    certificate = checkBox.Text;
                }
            }
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


        private void loaddesa(String value)
        {
            cbDesa.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("villages", "district_id", value);
            for (int i = 0; i < data.Count(); i++)
            {
                cbDesa.Items.Add(data[i][2].ToString());
            }

        }







        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + this.dataGridView2.Rows[e.RowIndex].Cells[0].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String code = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table_2params("tbsetup", "optionremark", code,"category",labelsetup.Text.Trim());
                    loadcategorysetup(labelsetup.Text);
                }
            }
        }

        private void txtbatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtsuppcode.Focus();
            }

        }

        private void cbProvinsi_TextChanged(object sender, EventArgs e)
        {
            cbKabupaten.Focus();
        }

        private void cbKabupaten_TextChanged(object sender, EventArgs e)
        {
            cbKecamatan.Focus();
        }

        private void cbKecamatan_TextChanged(object sender, EventArgs e)
        {
            cbDesa.Focus();
        }

        private void cbDesa_TextChanged(object sender, EventArgs e)
        {
            txtlandingsite.Focus();
        }

        private void cbwpp_TextChanged(object sender, EventArgs e)
        {
            cbcountryorigin.Focus();
        }

        private void clTypeFish_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (typefish != null)
            {
                typefish = typefish + "," + clTypeFish.Text;
            }
            else if (!clTypeFish.Text.Equals(""))
            {
                typefish = clTypeFish.Text;
            }
            
            if (clTypeFish.Text.Equals(""))
            {
                typefish = "";
            }
             */ 

        }

        private void clSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (species != null)
            {
                species = species + "," + clSpecies.Text;
            }
            else if (!clSpecies.Text.Equals(""))
            {
                species = clSpecies.Text;
            }

            if (clSpecies.Text.Equals(""))
            {
                species = "";
            }
             */ 

        }

        private void clCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (certificate != null)
            {
                certificate = certificate + "," + clCertificate.Text;
            }
            else if (!clCertificate.Text.Equals(""))
            {
                certificate = clCertificate.Text;
            }

            if (clCertificate.Text.Equals(""))
            {
                certificate = "";
            }
             */ 
            
        }

        private void cbProvinsi_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("provinces", "name", cbProvinsi.Text);
            provinsiid = data[0][0].ToString();
            loadkabupaten(provinsiid);
        }

        private void cbKabupaten_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("regencies", "name", cbKabupaten.Text);
            kabupatenid = data[0][0].ToString();
            loadkecamatan(kabupatenid);
        }

        private void cbKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data = frm.get_data_table_string("districts", "name", cbKecamatan.Text);

            data = frm.get_data_table_string_2param("districts", "name", cbKecamatan.Text, "regency_id", kabupatenid);
            kecamatanid = data[0][0].ToString();
            loaddesa(kecamatanid);
        }

        private void cbDesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("villages", "name", cbDesa.Text);
            desaid = data[0][0].ToString();

        }

        private void cbwpp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbcountryorigin_TextChanged(object sender, EventArgs e)
        {
            txtperson.Focus();
        }

        private void txtperson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.cbProvinsi.Focus();
            }
        }

        private void cbsex_TextChanged(object sender, EventArgs e)
        {
            txtlicense.Focus();
        }

        private void txtlicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dateTimePicker1.Focus();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtphone.Focus();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "vessel", 9);
            add_column_button(e, "edit", 10);
            add_column_button(e, "delete", 11);
        }

        private void txtbatch_Validating(object sender, CancelEventArgs e)
        {

            if (txtbatch.Text.Length > 3)
            {
                MessageBox.Show("Please use batch code 3 character only");
                txtbatch.Text = txtbatch.Text.Substring(0, 3);
                txtbatch.Focus();
            }
        }

        private void txtsuppcode_Validating(object sender, CancelEventArgs e)
        {
            if (txtsuppcode.Text.Length > 3)
            {
                MessageBox.Show("Please use batch code 3 character only");
                txtsuppcode.Text = txtsuppcode.Text.Substring(0, 3);
                txtsuppcode.Focus();
            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbinfo1_MouseHover(object sender, EventArgs e)
        {

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo1, "This keypoint used to set group area fishing of supplier, i.e: Obi Bacan ");
        }

        private void pbinfo2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo2, "This keypoint used to set province area fishing");
        }

        private void pbinfo3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo3, "This keypoint used to set district area fishing");

        }

        private void pbinfo4_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo4, "This keypoint used to set sub district area fishing");

        }

        private void pbinfo5_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo5, "This keypoint used to set village area fishing");

        }

        private void txtcompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtperson.Focus();
            }

        }

        private void searchdatasupplier()
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
                cmd.CommandText = "select * from view_supplier where suppname like @suppname order by suppcode";
                cmd.Parameters.AddWithValue("@suppname", "%" + txtsearch.Text.Trim() + "%" );
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
                    cmd1.CommandText = "select * from view_supplier where suppname like @suppname1 order by suppcode";
                    cmd1.Parameters.AddWithValue("@suppname1", "%" + txtsearch.Text.Trim() + "%");
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
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("batchcode");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("suppcode");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("suppname");
                            if (!rdr1.IsDBNull(rdr1.GetOrdinal("kabupaten")))
                            {
                                dataGridView1.Rows[i].Cells[4].Value = rdr1.GetString("kabupaten");
                            }
                            if (!rdr1.IsDBNull(rdr1.GetOrdinal("kecamatan")))
                            {
                                dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("kecamatan");
                            }

                            dataGridView1.Rows[i].Cells[6].Value = rdr1.GetString("landingsite");
                            dataGridView1.Rows[i].Cells[7].Value = rdr1.GetString("fishingground");
                            dataGridView1.Rows[i].Cells[8].Value = rdr1.GetString("countryorigin");
                            i++;
                        }
                    }

                    //Vessel
                    Vessel_columnbutton();


                    //Edit button
                    Edit_columnbutton();

                    //Delete button
                    Delete_columnbutton();
                }
                else
                {
                    MessageBox.Show("Data Supplier is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtbatch.Clear();
                txtsuppcode.Clear();
                txtsuppname.Clear();
                cbProvinsi.Text = "";
                cbKabupaten.Text = "";
                cbKecamatan.Text = "";
                cbDesa.Text = "";
                txtlandingsite.Clear();
                cbfishingground.Text = "";
                txtlandingsite.Clear();
                txtcertificate.Clear();
                txtperson.Text = "";
                cbsex.Text = "Male";
                txtcompany.Text = "";
                txtcoordinate.Text = "";
                txtregistration.Text = "";
                dateTimePicker1.Value = DateTime.Now;

                for (int i = 0; i <= (clTypeFish.Items.Count - 1); i++)
                {
                    clTypeFish.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clSpecies.Items.Count - 1); i++)
                {
                    clSpecies.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clCertificate.Items.Count - 1); i++)
                {
                    clCertificate.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = 0; i <= (clOptions.Items.Count - 1); i++)
                {
                    clOptions.SetItemCheckState(i, CheckState.Unchecked);
                }

            }
        }



        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                searchdatasupplier();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            searchdatasupplier();
        }

    }
}
