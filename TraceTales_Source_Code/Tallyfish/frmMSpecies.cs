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
    public partial class frmMSpecies : Form
    {

        private static Int32 idspecies;

        public frmMSpecies()
        {
            InitializeComponent();
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void loaddataspecies()
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
                cmd.CommandText = "select * from tbspecies order by speciescode";
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
                    cmd1.CommandText = "select * from tbspecies order by speciescode";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView2.Rows[i].Height = 50;

                            dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView2.Rows[i].Cells[1].Value = rdr1.GetString("speciesname");
                            dataGridView2.Rows[i].Cells[2].Value = rdr1.GetString("scientificname");
                            dataGridView2.Rows[i].Cells[3].Value = rdr1.GetString("speciescode");
                            i++;
                        }
                    }

                    Edit_columnbutton();
                    Delete_columnbutton("species");

                }
                else
                {
                    MessageBox.Show("Data species is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtspeciesname.Clear();
                txtscientificname.Clear();
                txtasfiscode.Clear();

            }
        }


        private void save_species()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbspecies", "speciesname", txtspeciesname.Text);
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
                    "Insert into tbspecies(speciescode, speciesname, scientificname)" +
                    " values(@speciescode, @speciesname, @scientificname)";
                }
                else
                {
                    mySql3.CommandText =
                    "Update tbspecies Set speciesname=@speciesname,scientificname=@scientificname, speciescode=@speciescode where id=@id";
                }


                mySql3.Parameters.AddWithValue("@speciescode", txtasfiscode.Text);
                mySql3.Parameters.AddWithValue("@speciesname", txtspeciesname.Text);
                mySql3.Parameters.AddWithValue("@scientificname", txtscientificname.Text);
                if (status.Equals("Ada"))
                {
                    mySql3.Parameters.AddWithValue("@id", idspecies);
                }
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data " + txtscientificname.Text + " has been stored ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_species();
            loaddataspecies();
        }


        private void frmMSpecies_Load(object sender, EventArgs e)
        {
            loaddataspecies();
            set_icon_info();
       }

        private void Delete_columnbutton(String module)
        {

            if (module.Equals("species"))
            {
                if (dataGridView2.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(5, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 70;
                }
           }
        }

        private void Edit_columnbutton()
        {
                if (dataGridView2.Columns.Contains("Edit") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(4, btn);
                    btn.HeaderText = "Edit";
                    btn.Name = "Edit";
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


        private void label8_Click(object sender, EventArgs e)
        {
            loaddataspecies();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }
            
            
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Species " + this.dataGridView2.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String speciescode = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    Int32 id=frm.get_id_data_table("tbspecies", "speciescode", e.RowIndex);
                    frm.delete_table_id("tbspecies", id);
                    //frm.delete_table("tbspecies", "speciescode", speciescode);
                    //dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                    loaddataspecies();
                }
            }


            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                    //capture id species
                    MainMenu frm = new MainMenu();
                    idspecies = frm.get_id_data_table("tbspecies","speciescode",e.RowIndex);

                    txtspeciesname.Text = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtscientificname.Text=this.dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtasfiscode.Text=this.dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }


        }

        private void txtspeciesname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtscientificname.Focus();
            }
        }

        private void txtscientificname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtasfiscode.Focus();
            }

        }

        private void txtasfiscode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                MainMenu frm = new MainMenu();
                List<object[]> data = new List<object[]>();
                data = frm.get_data_table_string("tbasfis", "asfis_code", txtasfiscode.Text.Trim());
                if (data.Count > 0)
                {
                    txtspeciesname.Text = data[0][2].ToString();
                    txtscientificname.Text = data[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Code " + txtasfiscode.Text + " has not found, please try another code");
                    txtasfiscode.Focus();
                }
                button2.Focus();
            }

        }


        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "edit", 4);
            add_column_button(e, "delete", 5);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pbinfo_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.pbinfo, "This keypoint used to input asfis code of species (3 character). Please click the list to show details");
        }

        private void set_icon_info()
        {
            var path = System.IO.Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\information.png";
            pbinfo.Image = Image.FromFile(icondir);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupASFIS.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            groupASFIS.Visible=true;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbasfis", "", "");
            if (data.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(data.Count);
                int a = data.Count;
                int i = 0;
                while (i < a)
                {
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    if (data[i][1].Equals(null))
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    }


                    if (data[i][2].Equals(null))
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    }
                    i = i + 1;
                }


            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_like("tbasfis", "speciesname", txtsearch.Text.Trim());
            if (data.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(data.Count);

                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();


                    if (data[i][1] == null)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    }


                    if (data[i][2] == null)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    }

                }
            }


        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
