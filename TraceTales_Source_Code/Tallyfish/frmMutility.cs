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
    public partial class frmMutility : Form
    {
        public frmMutility()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_server();
            loaddatautilities();
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void loaddatautilities()
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
                cmd.CommandText = "select * from tbutility";
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
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbutility";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dataGridView1.Rows[i].Height = 50;
                            dataGridView1.Rows[i].Cells[0].Value = rdr1.GetString("ipserver");
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("userid");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("passw");
                            dataGridView2.Rows[i].Height = 50;
                            dataGridView2.Rows[i].Cells[0].Value = rdr1.GetInt32("baudrate");
                            i++;
                        }
                    }


                    if (dataGridView1.Columns.Contains("btn") == false)
                    {
                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(btn);
                        btn.HeaderText = "Edit";
                        btn.Text = "Edit";
                        btn.Name = "btn";
                        btn.UseColumnTextForButtonValue = true;
                    }


                    if (dataGridView2.Columns.Contains("btn") == false)
                    {
                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        dataGridView2.Columns.Add(btn);
                        btn.HeaderText = "Edit";
                        btn.Text = "Edit";
                        btn.Name = "btn";
                        btn.UseColumnTextForButtonValue = true;
                    }

                }
                else
                {
                    MessageBox.Show("Data utilities is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtip.Clear();
                txtuser.Clear();
                txtpassw.Clear();
                txtbaud.Clear();

            }
        }


        private void save_server()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            /*
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbutility", "ipserver", txtip.Text);
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }
             */ 
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();
            mySql3.CommandText =
            "Update tbutility Set ipserver=@ipserver,userid=@userid,passw=@passw";

            mySql3.Parameters.AddWithValue("@ipserver", txtip.Text);
            mySql3.Parameters.AddWithValue("@userid", txtuser.Text);
            mySql3.Parameters.AddWithValue("@passw", txtpassw.Text);
            mySql3.ExecuteNonQuery();
            conn5.Close();
            MessageBox.Show("Data " + txtip.Text + " stored");

        }


        private void save_baudrate()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            /*
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbutility", "baudrate", txtbaud.Text);
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }
             */ 
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();
            mySql3.CommandText =
            "Update tbutility Set baudrate=@baudrate";
            mySql3.Parameters.AddWithValue("@baudrate", Int32.Parse(txtbaud.Text));
            mySql3.ExecuteNonQuery();
            conn5.Close();
            MessageBox.Show("Data baud rate " + txtbaud.Text + " stored");

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
                dataGridView1.Columns.Insert(3, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 70;
            }

        }


        
        private void tbutility_Load(object sender, EventArgs e)
        {
            loaddatautilities();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btn"].Index && e.RowIndex >= 0)
            {

                txtip.Text = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtuser.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtpassw.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["btn"].Index && e.RowIndex >= 0)
            {

                txtbaud.Text = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_baudrate();
            loaddatautilities();
        }

        private void txtip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtuser.Focus();
            }

        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtpassw.Focus();
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 3);
        }
    }
}
