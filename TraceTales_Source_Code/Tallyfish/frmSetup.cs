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
    public partial class frmSetup : Form
    {
        public frmSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_rawmat_setup();
            load_rm_setup();
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }

        private void save_rawmat_setup()
        {

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tbsetup(category,optionremark,Value,Lotseq,weighing_type, description)" +
                " values(@category,@optionremark,@Value,@Lotseq,@weighing_type, @description)";

                mySql3.Parameters.AddWithValue("@category", "typefish");
                mySql3.Parameters.AddWithValue("@optionremark", txtrawmattype.Text.Trim());
                mySql3.Parameters.AddWithValue("@Value", txtcodevalue.Text);
                if (cblink1.Checked)
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", cbsequence.Text);
                }
                else
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", "0");
                }
                mySql3.Parameters.AddWithValue("@weighing_type", cbweighingtype.Text);
                mySql3.Parameters.AddWithValue("@description", txtrawmatdescription.Text);
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Raw material setup " + txtrawmattype.Text.Trim() + " has been stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            
        }


        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView3.Columns.Insert(5, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 75;
            }
        }


        private void Delete_columnbutton_certificate()
        {
            if (dataGridView2.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView2.Columns.Insert(4, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 75;
            }
        }


        private void Delete_columnbutton_option()
        {
            if (dataGridView3.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView3.Columns.Insert(4, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 75;
            }
        }


        private void load_rm_setup()
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
                cmd.CommandText = "select * from tbsetup where category='typefish' order by id";
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
                    cmd1.CommandText = "select * from tbsetup where category='typefish' order by Value";
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
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("optionremark");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("description");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("Value");
                            dataGridView1.Rows[i].Cells[4].Value = rdr1.GetString("weighing_type");
                            dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("Lotseq");
                            i++;
                        }
                    }

                    Delete_columnbutton();
                }
                else
                {
                    MessageBox.Show("Data setup is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtrawmattype.Clear();
                txtcodevalue.Clear();
                txtrawmatdescription.Clear();
                cblink1.Checked = false;
                cbsequence.Text = "0";
            }
        }

        private void cblink1_CheckedChanged(object sender, EventArgs e)
        {
            if (cblink1.Checked)
            {
                cbsequence.Text = "1";
            }
            else
            {
                cbsequence.Text = "0";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            load_rm_setup();
        }

        private void cblink2_CheckedChanged(object sender, EventArgs e)
        {
            if (cblink2.Checked)
            {
                cbsequence2.Text = "2";
            }
            else
            {
                cbsequence2.Text = "0";
            }

        }

        private void cblink3_CheckedChanged(object sender, EventArgs e)
        {
            if (cblink3.Checked)
            {
                cbsequence3.Text = "3";
            }
            else
            {
                cbsequence3.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_certificate_setup();
            load_certificate_setup();
        }

        private void save_certificate_setup()
        {

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tbsetup(category,optionremark,Value,Lotseq,description )" +
                " values(@category,@optionremark,@Value,@Lotseq,@description)";

                mySql3.Parameters.AddWithValue("@category", "certificate");
                mySql3.Parameters.AddWithValue("@optionremark", txtcertificate.Text.Trim());
                mySql3.Parameters.AddWithValue("@Value", txtcodevalue2.Text);
                if (cblink2.Checked)
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", cbsequence2.Text);
                }
                else
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", "0");
                }
                mySql3.Parameters.AddWithValue("@description", txtdescriptioncertificate.Text.Trim());
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);                
            }
            conn5.Close();
            MessageBox.Show("Certificate setup " + txtcertificate.Text.Trim() + " has been stored");
        }



        private void load_certificate_setup()
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
                cmd.CommandText = "select * from tbsetup where category=@category order by id";
                cmd.Parameters.AddWithValue("@category", "certificate");
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
                    cmd1.CommandText = "select * from tbsetup where category=@category1 order by id";
                    cmd1.Parameters.AddWithValue("@category1", "certificate");
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView2.Rows[i].Height = 50;
                            dataGridView2.Rows[i].Cells[0].Value = rdr1.GetString("optionremark");
                            dataGridView2.Rows[i].Cells[1].Value = rdr1.GetString("description");
                            dataGridView2.Rows[i].Cells[2].Value = rdr1.GetString("Value");
                            dataGridView2.Rows[i].Cells[3].Value = rdr1.GetString("Lotseq");
                            i++;
                        }
                    }

                    Delete_columnbutton_certificate();
                }
                else
                {
                    MessageBox.Show("Data certificate is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtrawmattype.Clear();
                txtcodevalue.Clear();
                cblink1.Checked = false;
                cbsequence.Text = "0";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            load_certificate_setup();
        }

        private void save_option_setup()
        {

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tbsetup(category,optionremark,Value,Lotseq)" +
                " values(@category,@optionremark,@Value,@Lotseq)";

                mySql3.Parameters.AddWithValue("@category", cbcategory.Text.Trim());
                mySql3.Parameters.AddWithValue("@optionremark", txtdescription.Text.Trim());
                mySql3.Parameters.AddWithValue("@Value", txtcodevalue3.Text.Trim());

                if (cblink3.Checked)
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", cbsequence3.Text);
                }
                else
                {
                    mySql3.Parameters.AddWithValue("@Lotseq", "0");
                }
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show(cbcategory.Text.Trim() + " setup for " + txtcertificate.Text.Trim() + " has been stored");
        }


        private void load_option_setup()
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
                cmd.CommandText = "select * from tbsetup where category=@category order by id";
                cmd.Parameters.AddWithValue("@category", cbcategory.Text.Trim());

                MySqlDataReader rdr = cmd.ExecuteReader();
                int a = 0;
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dataGridView3.Rows.Clear();
                    dataGridView3.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbsetup where category=@category order by id";
                    cmd1.Parameters.AddWithValue("@category", cbcategory.Text.Trim());
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView3.Rows[i].Height = 50;
                            dataGridView3.Rows[i].Cells[0].Value = rdr1.GetString("category");
                            dataGridView3.Rows[i].Cells[1].Value = rdr1.GetString("optionremark");
                            dataGridView3.Rows[i].Cells[2].Value = rdr1.GetString("Value");
                            dataGridView3.Rows[i].Cells[3].Value = rdr1.GetString("Lotseq");
                            i++;
                        }
                    }

                    Delete_columnbutton_option();
                }
                else
                {
                    MessageBox.Show("Data option is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtrawmattype.Clear();
                txtcodevalue.Clear();
                cblink1.Checked = false;
                cbsequence.Text = "0";
            }
        }







        private void button3_Click(object sender, EventArgs e)
        {
            save_option_setup();
            load_option_setup();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            load_option_setup();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete raw material type " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String tipe= this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table_2params("tbsetup","category","typefish","optionremark",tipe);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Certificate " + this.dataGridView2.Rows[e.RowIndex].Cells[0].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String tipe = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table_2params("tbsetup", "category", "certificate", "optionremark", tipe);
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete  " + this.dataGridView3.Rows[e.RowIndex].Cells[0].Value + " " + this.dataGridView3.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String tipe = this.dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String lotseq=this.dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table_2params("tbsetup", "Lotseq", lotseq , "optionremark", tipe);
                    dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[0].Index);
                }
            }

        }


        private void set_icon_info()
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\information.png";
            pbinfo1.Image = Image.FromFile(icondir);
            pbinfo2.Image = Image.FromFile(icondir);
            pbinfo3.Image = Image.FromFile(icondir);
        }


        private void load_sequence_receiving_setup()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "receivingsequencenumber");
            if (data.Count > 0)
            {
                if (data[0][3].ToString().Equals("Y"))
                {
                    cbsequencenumber.Checked = true;
                }
                else
                {
                    cbsequencenumber.Checked = false;
                }
            }
        }


        private void load_offline_integration_setup()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "integrationsupplierapps");
            if (data.Count > 0)
            {
                if (data[0][3].ToString().Equals("Y"))
                {
                    cbIntegrationSupplierApps.Checked = true;
                }
                else
                {
                    cbIntegrationSupplierApps.Checked = false;
                }
            }
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            set_icon_info();
            Delete_columnbutton("RawMaterial");
            Delete_columnbutton("Certificate");
            Delete_columnbutton("Optional");
            load_rm_setup();
            load_certificate_setup();
            load_option_setup();
            load_sequence_receiving_setup();
            load_offline_integration_setup();
        }


        private void Delete_columnbutton(String module)
        {

            if (module.Equals("RawMaterial"))
            {
                if (dataGridView1.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(6, btn);
                    btn.HeaderText = "Del";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
            }
            else if (module.Equals("Certificate"))
            {
                if (dataGridView2.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(4, btn);
                    btn.HeaderText = "Del";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
            }
            else if (module.Equals("Optional"))
            {
                if (dataGridView3.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView3.Columns.Insert(4, btn);
                    btn.HeaderText = "Del";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
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

            add_column_button(e, "delete", 6);
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 4);
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 4);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            String includesequence="N";
            if(cbsequencenumber.Checked)
            {
                includesequence="Y";
            }

            Boolean ada = false;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "receivingsequencenumber");
            if (data.Count > 0)
            {
                ada = true;
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();

                if (!ada)
                {

                    mySql3.CommandText =
                    "Insert into tbsetup(category,Value) values(@category,@Value)";

                    mySql3.Parameters.AddWithValue("@category", "receivingsequencenumber");
                    mySql3.Parameters.AddWithValue("@Value", includesequence);
                    mySql3.ExecuteNonQuery();
                }
                else
                {

                    mySql3.CommandText =
                    "Update tbsetup set Value=@Value where category=@category";
                    mySql3.Parameters.AddWithValue("@category", "receivingsequencenumber");
                    mySql3.Parameters.AddWithValue("@Value", includesequence);
                    mySql3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            if (includesequence.Equals("Y"))
            {
                MessageBox.Show("System has set sequence number in internal lot code for multiple receiving for same day same supplier ");

            }
            else
            {
                MessageBox.Show("System has not sequence number in internal lot code for multiple receiving for same day same supplier");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIntegrationSupplierApps_CheckedChanged(object sender, EventArgs e)
        {


            String includeintegration = "N";
            if (cbIntegrationSupplierApps.Checked)
            {
                includeintegration = "Y";
            }

            Boolean ada = false;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "integrationsupplierapps");
            if (data.Count > 0)
            {
                ada = true;
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();

                if (!ada)
                {

                    mySql3.CommandText =
                    "Insert into tbsetup(category,Value) values(@category,@Value)";

                    mySql3.Parameters.AddWithValue("@category", "integrationsupplierapps");
                    mySql3.Parameters.AddWithValue("@Value", includeintegration);
                    mySql3.ExecuteNonQuery();
                }
                else
                {

                    mySql3.CommandText =
                    "Update tbsetup set Value=@Value where category=@category";
                    mySql3.Parameters.AddWithValue("@category", "integrationsupplierapps");
                    mySql3.Parameters.AddWithValue("@Value", includeintegration);
                    mySql3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            if (includeintegration.Equals("Y"))
            {
                MessageBox.Show("System has set offline integration with supplier apps based on global registration code supplier");

            }
            else
            {
                MessageBox.Show("System has disabled integration with supplier apps");
            }


        }

    }
}
