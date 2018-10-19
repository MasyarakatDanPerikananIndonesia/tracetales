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
    public partial class frmVessel : Form
    {
        private String vesselglobal;
        private Int32 flagedit;
        private static Int32 idvessel;

        public frmVessel()
        {
            InitializeComponent();
        }

        private void txtvesselname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtvesselsize.Focus();
            }

        }

        private void txtvesselsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtvesselregno.Focus();
            }

        }


        public void set_suppcode(String value)
        {
            this.suppcode.Text = value;
        }

        public void set_suppname(String value)
        {
            this.suppname.Text = value;
        }

        private void set_fishing_ground_supplier()
        {
            String fishingground = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsupplier","suppcode",this.suppcode.Text);
            if (data.Count > 0)
            {
                fishingground = data[0][7].ToString();
            }

            if(!fishingground.Contains(cbfishing_ground.Text))
            {
                if (fishingground.Length==0)
                {
                    fishingground = cbfishing_ground.Text;
                }
                else
                {
                    fishingground = fishingground + "," + cbfishing_ground.Text;
                }
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update tbsupplier set fishingground=@fishingground where suppcode=@suppcode";
                mySql3.Parameters.AddWithValue("@fishingground", fishingground);
                mySql3.Parameters.AddWithValue("@suppcode", this.suppcode.Text);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
         }


        private void button1_Click(object sender, EventArgs e)
        {
            save_vessel();
            loaddatavessel();
            set_fishing_ground_supplier();
            rbNo.Checked = true;
            MessageBox.Show("Data " + txtvesselname.Text + " stored");
            clear_entry();
        }

        private void clear_entry()
        {
            txtvesselname.Clear();
            txtvesselsize.Clear();
            txtvesselregno.Clear();
            cbfishing_ground.Text = "";
            cbFishingGear.Text = "";
            DateTime dt = DateTime.Parse("01/01/1990");
            dateTimePicker1.Value = dt;
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_vessel()
        {
            //String suppcode = "";
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbvessel","suppcode",this.suppcode.Text,"vesselname",vesselglobal);

            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            
            MySqlCommand mySql3 = conn5.CreateCommand();
            if (status.Equals("Not Ada"))
            {
                try
                {
                    mySql3.CommandText =
                    "Insert into tbvessel(suppcode, vesselname, vesselsize, vesselregno, vessel_flag,expired_date,fishing_gear, fishing_aggregate_device, fishing_ground, fisherman)" +
                    " values(@suppcode, @vesselname, @vesselsize, @vesselregno, @vessel_flag,@expired_date,@fishing_gear,@fishing_aggregate_device, @fishing_ground,@fisherman)";

                    mySql3.Parameters.AddWithValue("@vesselname", txtvesselname.Text);
                    mySql3.Parameters.AddWithValue("@vesselsize", txtvesselsize.Text);
                    mySql3.Parameters.AddWithValue("@vesselregno", txtvesselregno.Text);
                    mySql3.Parameters.AddWithValue("@vessel_flag", txtflag.Text);
                    DateTime dt = dateTimePicker1.Value.Date;
                    mySql3.Parameters.AddWithValue("@expired_date", DateTime.Parse(dt.ToString("yyyy-MM-dd hh:mm:ss")));
                    mySql3.Parameters.AddWithValue("@fishing_gear", cbFishingGear.Text.Trim());
                    mySql3.Parameters.AddWithValue("@suppcode", this.suppcode.Text);
                    mySql3.Parameters.AddWithValue("@fisherman", this.txtfisherman.Text);

                    String fad = "N";
                    if (rbYes.Checked)
                    {
                        fad = "Y";
                    }
                    else
                    {
                        fad = "N";
                    }

                    mySql3.Parameters.AddWithValue("@fishing_aggregate_device", fad);
                    mySql3.Parameters.AddWithValue("@fishing_ground", cbfishing_ground.Text);
                    mySql3.ExecuteNonQuery();
                }catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);                
                }
                conn5.Close();
            }
            

            if(flagedit==1)
            {
                try
                {
                    mySql3.CommandText =
                    "update tbvessel set vesselname=@vesselname2, vesselsize=@vesselsize1, vesselregno=@vesselregno1, vessel_flag=@vessel_flag1, expired_date=@expired_date1, fishing_gear=@fishing_gear1, fishing_aggregate_device=@fishing_aggregate_device1, fishing_ground=@fishing_ground1 where suppcode=@suppcode1 and vesselname=@vesselname1";
                    mySql3.Parameters.AddWithValue("@vesselname1", vesselglobal);
                    mySql3.Parameters.AddWithValue("@vesselname2", txtvesselname.Text);
                    mySql3.Parameters.AddWithValue("@vesselsize1", txtvesselsize.Text);
                    mySql3.Parameters.AddWithValue("@vesselregno1", txtvesselregno.Text);
                    mySql3.Parameters.AddWithValue("@vessel_flag1", txtflag.Text);
                    DateTime dt = dateTimePicker1.Value.Date;
                    mySql3.Parameters.AddWithValue("@expired_date1", DateTime.Parse(dt.ToString("yyyy-MM-dd hh:mm:ss")));
                    mySql3.Parameters.AddWithValue("@fishing_gear1", cbFishingGear.Text.Trim());
                    mySql3.Parameters.AddWithValue("@suppcode1", this.suppcode.Text);

                    String fad = "N";
                    if (rbYes.Checked)
                    {
                        fad = "Y";
                    }
                    else
                    {
                        fad = "N";
                    }

                    mySql3.Parameters.AddWithValue("@fishing_aggregate_device1", fad);
                    mySql3.Parameters.AddWithValue("@fishing_ground1", cbfishing_ground.Text);
                    mySql3.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
                flagedit = 0;
            }
        }


        private void loaddatavessel()
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
                cmd.CommandText = "select * from tbVessel where suppcode=@suppcode order by vesselname";
                cmd.Parameters.AddWithValue("@suppcode", suppcode.Text);
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
                    cmd1.CommandText = "select * from tbVessel where suppcode=@suppcode order by vesselname";
                    cmd1.Parameters.AddWithValue("@suppcode", suppcode.Text);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView1.Rows[i].Height = 50;

                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("vesselname");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("vesselsize");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("vesselregno");

                            DateTime dt = new DateTime();
                            dt = rdr1.GetDateTime("expired_date");
                            String exp = dt.ToString("yyyy-MM-dd");
                            if (exp.Contains("1990"))
                            {
                                dataGridView1.Rows[i].Cells[4].Value = "";
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[4].Value = dt.ToString("yyyy-MM-dd");
                            }
                            dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("fishing_gear");
                            dataGridView1.Rows[i].Cells[6].Value = rdr1.GetString("fishing_ground");
                            dataGridView1.Rows[i].Cells[7].Value = rdr1.GetString("fisherman");
                            i++;
                        }
                    }
                    txtvesselname.Focus();
                    Edit_columnbutton();
                    Delete_columnbutton();
                    dateTimePicker1.Value = DateTime.Parse("01/01/1990");
                }
                else
                {
                    MessageBox.Show("Data vessel is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                dateTimePicker1.Value= DateTime.Parse("01/01/1990");
            }

        }


        
        private void save_fishing_gear()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbsetup", "category", "fishinggear", "optionremark", txtgear.Text.Trim());
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();
            if (status.Equals("Not Ada"))
            {
                try
                {
                    mySql3.CommandText =
                    "Insert into tbsetup(optionremark, category)" +
                    " values(@optionremark, @category)";

                    mySql3.Parameters.AddWithValue("@optionremark", txtgear.Text);
                    mySql3.Parameters.AddWithValue("@category", "fishinggear");
                    mySql3.ExecuteNonQuery();
                    conn5.Close();
                    MessageBox.Show("Data " + txtgear.Text + " has been stored");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Data " + txtgear.Text + " has been available");
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


        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }


        private void Edit_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Edit") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btn);
                btn.HeaderText = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }




        private void Delete_columnbuttonvessel()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(9, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void Delete_columnbuttonfishing_gear()
        {
            if (dataGridView2.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView2.Columns.Insert(2, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        
        
        private void load_fishing_gear()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "fishinggear");
            Int32 i=0;
            if (data.Count > 0)
            {
                cbFishingGear.Items.Clear();
                for (i = 0; i < data.Count; i++)
                {
                    cbFishingGear.Items.Add(data[i][1]);
                }
            }
        }

        private void load_data_fishing_gear()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "fishinggear");
            Int32 i = 0;
            if (data.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(data.Count);
                for (i = 0; i < data.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = data[i][1].ToString();
                }
            }
        }




        private void load_fishing_ground()
        {
            MainMenu frm = new MainMenu();
            cbfishing_ground.Items.Clear();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "Fishing Area");
            if (data.Count > 0)
            {
                //to put value in combobox
                for (int i = 0; i < data.Count; i++)
                {
                    cbfishing_ground.Items.Add(data[i][1]);
                }
            }
        }



        private void frmVessel_Load(object sender, EventArgs e)
        {
            loaddatavessel();
            load_fishing_gear();
            load_fishing_ground();
            //Delete_columnbutton();
            //Edit_columnbutton();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String vessel = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table_2params("tbvessel", "vesselname", vessel, "suppcode", this.suppcode.Text);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    loaddatavessel();
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Edit " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    flagedit = 1;
                    MainMenu frm = new MainMenu();
                    String vessel = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string_2param("tbvessel", "vesselname", vessel,"suppcode",this.suppcode.Text);
                    if (data.Count > 0)
                    {
                        txtvesselname.Text = vessel;
                        vesselglobal = txtvesselname.Text;
                        txtvesselsize.Text = data[0][3].ToString();
                        txtflag.Text = data[0][5].ToString();
                        txtvesselregno.Text = data[0][4].ToString();
                        dateTimePicker1.Value = DateTime.Parse(data[0][6].ToString());
                        cbFishingGear.Text = data[0][7].ToString();
                        cbfishing_ground.Text = data[0][9].ToString();
                        if (data[0][8].ToString().Equals("Y"))
                        {
                            rbYes.Checked = true;
                        }
                        else
                        {
                            rbNo.Checked = true;
                        }
                    }

                }
            }


        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 8);
            add_column_button(e, "edit", 9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupFishingGear.Visible = true;
            load_data_fishing_gear();
            Delete_columnbuttonfishing_gear();
        }

        private void btnsavegear_Click(object sender, EventArgs e)
        {
            save_fishing_gear();
            load_data_fishing_gear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupFishingGear.Visible = false;
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "delete", 2);
       }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String vessel = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    String nilai=this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.delete_table_2params("tbsetup", "category", "fishinggear", "optionremark",nilai);
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DateTime expiration_date;
            DateTime currentDateTime = DateTime.Now;
            Int32 i = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    if (i < dataGridView1.Rows.Count-1)
                    {
                        if (!dataGridView1.Rows[i].Cells[4].Value.ToString().Equals(""))
                        {
                            expiration_date = DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                            if (expiration_date < currentDateTime)
                            {
                                Myrow.DefaultCellStyle.BackColor = Color.Red;
                                Myrow.DefaultCellStyle.ForeColor = Color.White;
                            }
                        }

                    }
                    i++;
                }

        }

        private void txtfisherman_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtvesselname.Focus();
            }


        }
    }
}
