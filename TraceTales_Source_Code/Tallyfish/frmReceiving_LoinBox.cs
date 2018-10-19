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
    public partial class frmReceiving_LoinBox : Form
    {
        public frmReceiving_LoinBox()
        {
            InitializeComponent();
        }

        public void set_initial(String intlotcode,String supplier )
        {
            txtintlotcode.Text = intlotcode.Trim();
            txtsupplier.Text = supplier.Trim();
            txtloin.Focus();
        }

        public List<object[]> get_data_table_string_order(String tablename, String field, String value, String orderby)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + "=@value  order by " + orderby ;
                cmd.Parameters.AddWithValue("@value", value);
            }
            else
            { // to get all data without filtering
                cmd.CommandText = "select * from " + tablename;
            }

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

		
        public void set_box_number()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = get_data_table_string_order("tbreceiving_loinbox", "intlotcode", txtintlotcode.Text.Trim(),"boxno");
            Int32 nextbox=0;
            if (data.Count > 0)
            {
                nextbox = data.Count + 1;
            }
            else
            {
                nextbox = 1;
            }
            txtnumberbox.Text = nextbox.ToString();
        }
		


        public void display_data()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = get_data_table_string_order("tbreceiving_loinbox", "intlotcode", txtintlotcode.Text.Trim(),"boxno");
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][3].ToString();

                }
            }
            Delete_columnbutton();
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



        private void frmReceiving_LoinBox_Load(object sender, EventArgs e)
        {
            display_data();
			set_box_number();
            txtloin.Focus();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 3);
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_loin();
            display_data();
            Int32 numberbox = 0;
            numberbox = Int32.Parse(txtnumberbox.Text);
            numberbox = numberbox + 1;
            txtnumberbox.Text = numberbox.ToString();
            txtloin.Text = " 0";
            this.Close();
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_loin()
        {
            if (!txtnumberbox.Text.Equals("") && !txtloin.Text.Equals("")) 
            {
                String intlotcode = txtintlotcode.Text;
                Int32 numberbox = Int32.Parse(txtnumberbox.Text);
                Int32 numberloin = Int32.Parse(txtloin.Text);

                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into  tbreceiving_loinbox(intlotcode,boxno,qtyloin)" +
                            " values(@intlotcode,@boxno,@qtyloin)";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@boxno", numberbox);
                    mySql3.Parameters.AddWithValue("@qtyloin", numberloin);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error message " + e.Message);
                }
                conn5.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Box " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    String intlotcode = txtintlotcode.Text.Trim();
                    String boxno = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    try
                    {
                        txtnumberbox.Text = boxno;
                        frm.delete_table_2params("tbreceiving_loinbox", "intlotcode", intlotcode, "boxno", boxno);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message " + ex.Message);
                    }
                    display_data();
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
