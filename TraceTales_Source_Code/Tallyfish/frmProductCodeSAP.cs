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
    public partial class frmProductCodeSAP : Form
    {
        public frmProductCodeSAP()
        {
            InitializeComponent();
        }

        private void load_product()
        {
            cbproduct.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbproductsetup", "", "");
            for (int i = 0; i < data.Count(); i++)
            {
                cbproduct.Items.Add(data[i][5].ToString());
            }
        }

        private void load_grade()
        {
            cbgrade.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbgrade", "module", "retouching");
            for (int i = 0; i < data.Count(); i++)
            {
                cbgrade.Items.Add(data[i][1].ToString());
            }
        }

        private void load_size()
        {
            cbsize.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbpackingsize", "", "");
            for (int i = 0; i < data.Count(); i++)
            {
                cbsize.Items.Add(data[i][1].ToString());
            }
        }


        private void load_certificate()
        {
            cbcertificate.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category", "certificate");
            for (int i = 0; i < data.Count(); i++)
            {
                cbcertificate.Items.Add(data[i][1].ToString());
            }
            cbcertificate.Items.Add("N/A");
        }


        private void frmProductCodeSAP_Load(object sender, EventArgs e)
        {
            load_product();
            load_grade();
            load_size();
            load_certificate();
            txtSAPItemCode.Focus();
            loaddataproductgrid();
        }

        private String Konek()
        {
            String konek = "";
            MainMenu frm = new MainMenu();
            konek=frm.Konek();
            return konek;
        }


        private void loaddataproductgrid()
        {
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();

            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select product,grade,size,certificate,itemcodesap,unitprice from tbproductsetup_sapcode order by product, certificate,grade, size";

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

            if (data.Count > 0)
            {
                
                dgProductCodeSAP.Rows.Clear();
                dgProductCodeSAP.Rows.Add(data.Count);

                for (int i = 0; i < data.Count; i++)
                {
                    dgProductCodeSAP.Rows[i].Height = 40;
                    dgProductCodeSAP.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dgProductCodeSAP.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dgProductCodeSAP.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dgProductCodeSAP.Rows[i].Cells[3].Value = data[i][2].ToString();
                    dgProductCodeSAP.Rows[i].Cells[4].Value = data[i][3].ToString();
                    dgProductCodeSAP.Rows[i].Cells[5].Value = data[i][4].ToString();
                }

                Edit_columnbutton();
                Delete_columnbutton();
            }
        }


        private void Edit_columnbutton()
        {

            if (dgProductCodeSAP.Columns.Contains("Edit") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgProductCodeSAP.Columns.Insert(6, btn);

                btn.HeaderText = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }

        private void Delete_columnbutton()
        {

            if (dgProductCodeSAP.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgProductCodeSAP.Columns.Insert(7, btn);

                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }



        private void save_productsetupSAP()
        {
            MainMenu frm = new MainMenu();

            //get data from table
            List<object[]> data = new List<object[]>();

            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from  tbproductsetup_sapcode where product=@product and grade=@grade and size=@size and certificate=@certificate";
            cmd.Parameters.AddWithValue("@product", cbproduct.Text.Trim());
            cmd.Parameters.AddWithValue("@grade", cbgrade.Text.Trim());
            cmd.Parameters.AddWithValue("@size", cbsize.Text.Trim());
            cmd.Parameters.AddWithValue("@certificate", cbcertificate.Text.Trim());
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
            
            String status = "Not Ada";
            if (data.Count > 0)
            {
                status = "Ada";
            }

            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                if (status.Equals("Not Ada"))
                {
                    mySql3.CommandText =
                    "Insert into tbproductsetup_sapcode(product,grade,size,certificate,itemcodesap)" +
                    " values(@product,@grade,@size,@certificate,@itemcodesap)";
                }
                else
                {
                    mySql3.CommandText =
                    "Update tbproductsetup_sapcode Set itemcodesap=@itemcodesap where product=@product and grade=@grade and size=@size and certificate=@certificate";
                }
                mySql3.Parameters.AddWithValue("@product", cbproduct.Text);
                mySql3.Parameters.AddWithValue("@grade", cbgrade.Text);
                mySql3.Parameters.AddWithValue("@size", cbsize.Text);

                String certificate;
                if (cbcertificate.Text.Contains("N/A"))
                {
                    certificate="";
                }else
                {
                    certificate = cbcertificate.Text.Trim();
                }

                mySql3.Parameters.AddWithValue("@certificate", certificate);
                mySql3.Parameters.AddWithValue("@itemcodesap", txtSAPItemCode.Text.Trim());
                mySql3.ExecuteNonQuery();
                loaddataproductgrid();
                MessageBox.Show("Data Product SAP Code has been stored");

                cbproduct.Text = "";
                cbgrade.Text = "";
                cbsize.Text = "";
                cbcertificate.Text = "";
                txtSAPItemCode.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }



        private void btnsave_Click(object sender, EventArgs e)
        {
            save_productsetupSAP();
        }

        private void dgProductCodeSAP_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "edit", 6);
            add_column_button(e, "delete", 7);
        }

        private void add_column_button(DataGridViewCellPaintingEventArgs e, String btn, Int32 colsidx)
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

        private void dgProductCodeSAP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgProductCodeSAP.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dgProductCodeSAP.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete  " + this.dgProductCodeSAP.Rows[e.RowIndex].Cells[5].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbproductsetup_sapcode", "itemcodesap", this.dgProductCodeSAP.Rows[e.RowIndex].Cells[5].Value.ToString());
                    loaddataproductgrid();
                }
            }


            if (e.ColumnIndex == dgProductCodeSAP.Columns["Edit"].Index && e.RowIndex >= 0 && dgProductCodeSAP.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Edit Code " + this.dgProductCodeSAP.Rows[e.RowIndex].Cells[5].Value + " ?", "Edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    MainMenu frm = new MainMenu();
                    String itemcode = this.dgProductCodeSAP.Rows[e.RowIndex].Cells[5].Value.ToString();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tbproductsetup_sapcode", "itemcodesap", itemcode);
                    if (data.Count > 0)
                    {
                        cbproduct.Text = data[0][1].ToString();
                        cbgrade.Text = data[0][2].ToString();
                        cbsize.Text = data[0][3].ToString();
                        cbcertificate.Text = data[0][4].ToString();
                        txtSAPItemCode.Text = data[0][5].ToString();
                    }
                }
            }
        }

    }
}
