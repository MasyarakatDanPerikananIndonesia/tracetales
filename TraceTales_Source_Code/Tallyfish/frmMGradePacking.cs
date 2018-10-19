using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO.Ports;

namespace Tallyfish
{
    public partial class frmMGradePacking : Form
    {
        public String packingglobal;
        public frmMGradePacking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_grade();
            loaddatagrade();
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void loaddatagrade()
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
                cmd.CommandText = "select * from tbgrade order by module,gradecode";
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
                    cmd1.CommandText = "select * from tbgrade order by module,gradecode";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView1.Rows[i].Height = 50;

                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("gradecode");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("gradedescription");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("module");
                            i++;
                        }
                    }

                    Delete_columnbutton("grade");
                }
                else
                {
                    MessageBox.Show("Data grade is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtgrade.Clear();
                comboBox1.Text="";
            }
        }


        
        

        private void loaddatapacking()
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
                cmd.CommandText = "select * from tbpackingsize order by packingsize";
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
                    cmd1.CommandText = "select * from tbpackingsize order by packingsize";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView2.Rows[i].Height = 50;

                            dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView2.Rows[i].Cells[1].Value = rdr1.GetString("packingsize");
                            dataGridView2.Rows[i].Cells[2].Value = rdr1.GetString("excludedft");
                            i++;
                        }
                    }

                    Delete_columnbutton("size");




                }
                else
                {
                    MessageBox.Show("Data Packing is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtgrade.Clear();
                comboBox1.Text = "";
            }
        }


        private void loaddatainterval()
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
                cmd.CommandText = "select * from tbgrupsize order by module, grupsize";
                MySqlDataReader rdr = cmd.ExecuteReader();
                int a = 0;
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dgInterval.Rows.Clear();
                    dgInterval.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbgrupsize order by module,grupsize";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    this.dgInterval.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dgInterval.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            this.dgInterval.Rows[i].Height = 50;

                            this.dgInterval.Rows[i].Cells[0].Value = (i + 1).ToString();
                            this.dgInterval.Rows[i].Cells[1].Value = rdr1.GetString("grupsize");
                            this.dgInterval.Rows[i].Cells[2].Value = rdr1.GetString("lower");
                            this.dgInterval.Rows[i].Cells[3].Value = rdr1.GetString("upper");
                            this.dgInterval.Rows[i].Cells[4].Value = rdr1.GetString("module");
                            i++;
                        }
                    }

                    Delete_columnbutton("interval");
                }
                else
                {
                    MessageBox.Show("Data Grup Size is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtlower.Clear();
                txtupper.Clear();
                cbsize.Text = "";
            }
        }

        
        
        
        public List<object[]> get_data_grade()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from tbgrade where gradecode=@grade and module=@module";
            cmd.Parameters.AddWithValue("@grade", txtgrade.Text);
            cmd.Parameters.AddWithValue("@module", comboBox1.Text);
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
                data.Add(tempRow);
            }
            conn3.Close();
            return data;
        }



        private void save_grade()
        {
            //get data from table
            List<object[]> data = new List<object[]>();
            data = get_data_grade();
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
                    "Insert into tbgrade(gradecode,gradedescription,module)" +
                    " values(@gradecode,@gradedescription,@module)";
                }

                //else
                //{
                //mySql3.CommandText =
                //"Update tbgrade Set grade=@grade, module=@module where id=@id";
                //mySql3.Parameters.AddWithValue("@id", id);
                //}
                mySql3.Parameters.AddWithValue("@gradecode", txtgrade.Text);
                mySql3.Parameters.AddWithValue("@gradedescription", txtgradedescription.Text);
                mySql3.Parameters.AddWithValue("@module", comboBox1.Text);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show("Data " + txtgrade.Text + " stored");
        }




        private void label10_Click(object sender, EventArgs e)
        {
            loaddatagrade();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            loaddatapacking();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_packing();
            loaddatapacking();
            load_grupsize_list();
        }

        private void save_packing()
        {

            Int32 excludedft = 0;
            if (cbexclude.Checked)
            {
                excludedft = 1;
            }
            else
            {
                excludedft = 0;
            }

            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbpackingsize", "packingsize", txtpacking.Text);
            String status = "Not Ada";
            //Int32 id=0;
            if (data.Count > 0)
            {
                status = "Ada";
                //id = int.Parse(data[0][0].ToString());
            }
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                if (status.Equals("Not Ada"))
                {
                    mySql3.CommandText = "Insert into tbpackingsize(packingsize)values(@packingsize)";
                    mySql3.Parameters.AddWithValue("@packingsize", txtpacking.Text);
                    mySql3.ExecuteNonQuery();
                }
                else
                {
                    mySql3.CommandText = "update tbpackingsize set packingsize=@packingsize, excludedft=@excludedft where packingsize=@packingsize1";
                    mySql3.Parameters.AddWithValue("@packingsize", txtpacking.Text);
                    mySql3.Parameters.AddWithValue("@packingsize1", packingglobal);
                    mySql3.Parameters.AddWithValue("@excludedft", excludedft);
                    mySql3.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show("Data " + txtpacking.Text + " stored");
            txtpacking.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Grade " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + " - " + this.dataGridView1.Rows[e.RowIndex].Cells[2].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String grade = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String module = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                    string connString = Konek();
                    MySqlConnection conn3 = null;
                    conn3 = new MySqlConnection(connString);
                    conn3.Open();
                    MySqlCommand mySql = conn3.CreateCommand();
                    mySql.CommandText = "delete from tbgrade where gradecode=@grade and module=@module";
                    mySql.Parameters.AddWithValue("@grade", grade.Trim());
                    mySql.Parameters.AddWithValue("@module", module.Trim());
                    mySql.ExecuteNonQuery();
                    conn3.Close();
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }
            

            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Packing " + this.dataGridView2.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String packing = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

                    string connString = Konek();
                    MySqlConnection conn3 = null;
                    conn3 = new MySqlConnection(connString);
                    conn3.Open();
                    MySqlCommand mySql = conn3.CreateCommand();
                    mySql.CommandText = "delete from tbpackingsize where packingsize=@packing";
                    mySql.Parameters.AddWithValue("@packing", packing);
                    mySql.ExecuteNonQuery();
                    conn3.Close();
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                    load_grupsize_list();
                }
            }

            if (e.ColumnIndex == dataGridView2.Columns["Edit"].Index && e.RowIndex >= 0)
            {

                String packing = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtpacking.Text = packing;
                packingglobal = packing;
                MainMenu frm = new MainMenu();
                List<object[]> data = new List<object[]>();
                data = frm.get_data_table_string_fieldname("tbpackingsize", "excludedft", "packingsize", packing);
                String excludedft = "";
                if (data.Count > 0)
                {
                    excludedft = data[0][0].ToString();
                }
                if (excludedft.Equals("1"))
                {
                    cbexclude.Checked = true;
                }
                else
                {
                    cbexclude.Checked = false;
                }

            }

        }


        private void set_icon_info(String option)
        {

            var path = System.IO.Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\information.png";
            if (option.Equals("Size"))
            {
                pbinfo.Image = Image.FromFile(icondir);
            }else if (option.Equals("Grade"))
            {
                pbgrade.Image = Image.FromFile(icondir);
            }
            else if (option.Equals("ByProduct"))
            {
                pbbyproduct.Image = Image.FromFile(icondir);
            }
        
        }


        private void load_grupsize_list()
        {
            cbsize.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbpackingsize", "", "");
            if (data.Count > 0)
            {
                for(int i=0; i<data.Count;i++)
                {
                    cbsize.Items.Add(data[i][1].ToString());
                }
            }
        }


        private void frmMGradePacking_Load(object sender, EventArgs e)
        {
            loaddatagrade();
            loaddatapacking();
            loaddata_tipe_byproduct();
            loaddatainterval();
            load_grupsize_list();
            set_icon_info("Size");
            set_icon_info("Grade");
            set_icon_info("ByProduct");

        }

        private void Delete_columnbutton(String module)
        {

            if (module.Equals("grade"))
            {
                if (dataGridView1.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(4, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 70;
                }
            }else if (module.Equals("size"))
            {
                if (dataGridView2.Columns.Contains("Delete") == false)
                {

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(3, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 70;
                }

                if (dataGridView2.Columns.Contains("Edit") == false)
                {

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(4, btn);
                    btn.HeaderText = "Edit";
                    btn.Name = "Edit";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 50;
                }

            }
            else if (module.Equals("by_product"))
            {
                if (dataGridView3.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView3.Columns.Insert(4, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 70;
                }
             }
            else if (module.Equals("interval"))
            {
                if (dgInterval.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dgInterval.Columns.Insert(5, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 50;
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


        private void txttype_Validated(object sender, EventArgs e)
        {
            if (txttype.Text.Length > 3)
            {
                MessageBox.Show("Maximum character allowed is 3 character only, please revise your input");
                txttype.Focus();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save_byproducttype();
            loaddata_tipe_byproduct();
        }


        private void loaddata_tipe_byproduct()
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
                cmd.CommandText = "select optionremark,category, Value, weighing_type from tbsetup where category=@category order by weighing_type";
                cmd.Parameters.AddWithValue("@category", "byproduct");
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
                    cmd1.CommandText = "select optionremark,category,Value, weighing_type from tbsetup  where category=@category order by weighing_type";
                    cmd1.Parameters.AddWithValue("@category", "byproduct");
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView3.Rows[i].Height = 50;
                            dataGridView3.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView3.Rows[i].Cells[1].Value = rdr1.GetString("optionremark");
                            dataGridView3.Rows[i].Cells[2].Value = rdr1.GetString("Value");
                            dataGridView3.Rows[i].Cells[3].Value = rdr1.GetString("weighing_type");
                            i++;
                        }
                    }
                    Delete_columnbutton("by_product");
                }
                else
                {
                    MessageBox.Show("Data By Product is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtgrade.Clear();
                comboBox1.Text = "";
            }
        }



        public List<object[]> get_data_tipe_byproduct()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from tbsetup where optionremark=@optionremark and category=@category and weighing_type=@weighing_type";
            cmd.Parameters.AddWithValue("@optionremark", txttype.Text);
            cmd.Parameters.AddWithValue("@category", "byproduct");
            cmd.Parameters.AddWithValue("@weighing_type", cbstage.Text.Trim());
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
                data.Add(tempRow);
            }
            conn3.Close();
            return data;
        }

        private void save_byproducttype()
        {
            //get data from table
            List<object[]> data = new List<object[]>();
            data = get_data_tipe_byproduct();
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
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
                    "Insert into tbsetup(optionremark,category,Value,weighing_type)" +
                    " values(@optionremark,@category,@value,@weighing_type)";
                }

                mySql3.Parameters.AddWithValue("@optionremark", txttype.Text);
                mySql3.Parameters.AddWithValue("@category", "byproduct");
                mySql3.Parameters.AddWithValue("@value", txtbyproductdescription.Text.Trim());
                mySql3.Parameters.AddWithValue("@weighing_type", cbstage.Text.Trim());
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data " + txttype.Text + " stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            txttype.Clear();
            txtbyproductdescription.Clear();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            loaddata_tipe_byproduct();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView3.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Type By Product " + this.dataGridView3.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String packing = this.dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String stage = this.dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();

                    string connString = Konek();
                    MySqlConnection conn3 = null;
                    conn3 = new MySqlConnection(connString);
                    conn3.Open();
                    MySqlCommand mySql = conn3.CreateCommand();
                    mySql.CommandText = "delete from tbsetup where optionremark=@optionremark and category=@category and weighing_type=@weighing_type";
                    mySql.Parameters.AddWithValue("@optionremark", packing);
                    mySql.Parameters.AddWithValue("@category", "byproduct");
                    mySql.Parameters.AddWithValue("@weighing_type", stage);
                    mySql.ExecuteNonQuery();
                    conn3.Close();
                    loaddata_tipe_byproduct();
                }
            }

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 4);
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 3);
            add_column_button(e, "edit", 4);
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 4);
        }

        private void txtgrade_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtgradedescription.Focus();
            }


        }

        private void txtgradedescription_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                comboBox1.Focus();
            }


        }

        private void pbinfo_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo, "This keypoint used to input size category for packing module");
        }

        private void pbgrade_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbgrade, "This keypoint used to input grade code appeared in processing module selected");
        }

        private void pbbyproduct_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbbyproduct, "This keypoint used to input grade code appeared in byproduct module selected");

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgInterval_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 5);
        }

        private void dgInterval_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgInterval.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dgInterval.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                String grupsize = this.dgInterval.Rows[e.RowIndex].Cells[1].Value.ToString();
                String module = this.dgInterval.Rows[e.RowIndex].Cells[4].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Size " + grupsize + " and "+ module +" ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    string connString = Konek();
                    MySqlConnection conn3 = null;
                    conn3 = new MySqlConnection(connString);
                    conn3.Open();
                    MySqlCommand mySql = conn3.CreateCommand();
                    mySql.CommandText = "delete from tbgrupsize where grupsize=@grupsize and module=@module";
                    mySql.Parameters.AddWithValue("@grupsize", grupsize);
                    mySql.Parameters.AddWithValue("@module", module);
                    mySql.ExecuteNonQuery();
                    conn3.Close();
                    dgInterval.Rows.RemoveAt(dgInterval.SelectedRows[0].Index);
                }
            }


        }

        private void save_grupsize_packing()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbgrupsize", "grupsize", cbsize.Text.Trim(), "module", cbmodule.Text.Trim());
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                if (status.Equals("Not Ada"))
                {
                    mySql3.CommandText = "Insert into tbgrupsize(module,grupsize,lower,upper) values(@module,@grupsize,@lower,@upper)";
                    mySql3.Parameters.AddWithValue("@module", cbmodule.Text.Trim());
                    mySql3.Parameters.AddWithValue("@grupsize", cbsize.Text.Trim());
                    mySql3.Parameters.AddWithValue("@lower", txtlower.Text);
                    mySql3.Parameters.AddWithValue("@upper", txtupper.Text);
                    mySql3.ExecuteNonQuery();
                }
                else
                {
                    mySql3.CommandText = "update tbgrupsize Set lower=@lower,upper=@upper where grupsize=@grupsize and module=@module";
                    mySql3.Parameters.AddWithValue("@grupsize", cbsize.Text.Trim());
                    mySql3.Parameters.AddWithValue("@module", cbmodule.Text.Trim());
                    mySql3.Parameters.AddWithValue("@lower", txtlower.Text);
                    mySql3.Parameters.AddWithValue("@upper", txtupper.Text);
                    mySql3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show("Data " + cbsize.Text + " has been stored");

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            save_grupsize_packing();
            loaddatainterval();
        }

        private void cbsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtlower.Focus();
        }

        private void txtlower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtupper.Focus();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
