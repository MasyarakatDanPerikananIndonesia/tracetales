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
    public partial class frmMIncoterms : Form
    {
        public frmMIncoterms()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_incoterms();
            loaddataincoterms();
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void loaddataincoterms()
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
                cmd.CommandText = "select * from tbincoterms order by incoterms";
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
                    cmd1.CommandText = "select * from tbincoterms order by incoterms";
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
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("incoterms");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("incodescription");
                            i++;
                        }
                    }

                    Edit_columnbutton("incoterms");
                    Delete_columnbutton("incoterms");
                }
                else
                {
                    MessageBox.Show("Data incoterms is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtincoterms.Clear();
                txtdescription.Clear();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete incoterms " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String incoterms = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbincoterms", "incoterms", incoterms);
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }

            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                txtincoterms.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtdescription.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }

        }

        private void txtincoterms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtdescription.Focus();
            }

        }


        private void save_incoterms()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbincoterms", "incoterms", txtincoterms.Text);
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
                    "Insert into tbincoterms(incoterms,incodescription)" +
                    " values(@incoterms,@incodescription)";
                }

                else
                {
                    mySql3.CommandText =
                    "Update tbincoterms Set incodescription=@incodescription  where incoterms=@incoterms";
                }
                mySql3.Parameters.AddWithValue("@incoterms", txtincoterms.Text);
                mySql3.Parameters.AddWithValue("@incodescription", txtdescription.Text);
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data " + txtincoterms.Text + " stored");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            loaddataincoterms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_payterms();
            loaddatapayterms();
        }

        private void loaddatapayterms()
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
                cmd.CommandText = "select * from tbpayterms order by payterms";
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
                    cmd1.CommandText = "select * from tbpayterms order by payterms";
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
                            dataGridView2.Rows[i].Cells[1].Value = rdr1.GetString("payterms");
                            dataGridView2.Rows[i].Cells[2].Value = rdr1.GetString("paydescription");
                            dataGridView2.Rows[i].Cells[3].Value = rdr1.GetInt32("dueday").ToString();
                            i++;
                        }
                    }

                    Edit_columnbutton("payterms");
                    Delete_columnbutton("payterms");
                }
                else
                {
                    MessageBox.Show("Data payterms is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtpayterms.Clear();
                txtdescription1.Clear();
                txtdueday.Value = 0;
            }
        }


        private void save_payterms()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbpayterms", "payterms", txtpayterms.Text);
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
                    "Insert into tbpayterms(payterms,paydescription,dueday)" +
                    " values(@payterms,@paydescription,@dueday)";
                }

                else
                {
                    mySql3.CommandText =
                    "Update tbpayterms Set paydescription=@paydescription,dueday=@dueday where payterms=@payterms";
                }
                mySql3.Parameters.AddWithValue("@payterms", txtpayterms.Text);
                mySql3.Parameters.AddWithValue("@paydescription", txtdescription1.Text);
                mySql3.Parameters.AddWithValue("@dueday", Int32.Parse(txtdueday.Text));
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            MessageBox.Show("Data " + txtpayterms.Text + " stored");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loaddatapayterms();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete payterms " + this.dataGridView2.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String payterms = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbpayterms", "payterms", payterms);
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }
            }

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                txtpayterms.Text = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtdescription1.Text = this.dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtdueday.Value = Int32.Parse(this.dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }



        private void frmMIncoterms_Load(object sender, EventArgs e)
        {
            loaddataincoterms();
            loaddatapayterms();
        }


        private void Delete_columnbutton(String module)
        {

            if (module.Equals("incoterms"))
            {

                if (dataGridView1.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(4, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
            }else if (module.Equals("payterms"))
            {

                if (dataGridView2.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(5, btn);
                    btn.HeaderText = "Delete";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
            }
        }

        private void Edit_columnbutton(String module)
        {
            if (module.Equals("incoterms"))
            {
                if (dataGridView1.Columns.Contains("Edit") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(3, btn);
                    btn.HeaderText = "Edit";
                    btn.Name = "Edit";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
            }else if (module.Equals("payterms"))
            {
                if (dataGridView2.Columns.Contains("Edit") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView2.Columns.Insert(4, btn);
                    btn.HeaderText = "Edit";
                    btn.Name = "Edit";
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
            add_column_button(e, "edit", 3);
            add_column_button(e, "delete", 4);

        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "edit", 4);
            add_column_button(e, "delete", 5);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
