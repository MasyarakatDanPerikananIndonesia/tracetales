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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void seticon_forbutton()
        {

            MainMenu frm = new MainMenu();
            frm.setbuttonicon("save", btnsaveproduct);
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {

            loadstate();
            loadtipe();
            loadtradeunit();
            loadspecies();
            loaddataproductgrid();

        }


        private void loadstate()
        {
            cbstate.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "state");
            for (int i = 0; i < data.Count(); i++)
            {
                cbstate.Items.Add(data[i][1].ToString());
            }
        }

        private void loadstate_grid()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "state");
            if (data.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView2.Rows[i].Height = 40;
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = data[i][1].ToString();
                }
                Delete_columnbutton_option();
            }
        }

        
        private void loadtipe()
        {
            cbtipe.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "tipe");
            for (int i = 0; i < data.Count(); i++)
            {
                cbtipe.Items.Add(data[i][1].ToString());
            }
        }

        private void loadtipe_grid()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "tipe");
            if (data.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView2.Rows[i].Height = 40;
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = data[i][1].ToString();
                }
            }
        }



        private void loadtradeunit()
        {
            cbtradeunit.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "tradeunit");
            for (int i = 0; i < data.Count(); i++)
            {
                cbtradeunit.Items.Add(data[i][1].ToString());
            }
        }


        private void loadtradeunit_grid()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tboptionproductsetup", "kategori", "tradeunit");
            if (data.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView2.Rows[i].Height = 40;
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = data[i][1].ToString();
                }
            }
        }


        private void loadspecies()
        {
            cbspecies.Items.Clear();
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbspecies", "", "");
            for (int i = 0; i < data.Count(); i++)
            {
                cbspecies.Items.Add(data[i][2].ToString());
            }
        }

        private String get_scientific(String species)
        {
            String scientific = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbspecies", "speciesname", species.Trim());
            if (data.Count > 0)
            {
                scientific = data[0][4].ToString();
            }
            return scientific;
        }

        private void save_productsetup()
        {
            Int32 idproduct = 0;
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbproductsetup", "productname", txtproduct.Text.Trim());
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
                    "Insert into tbproductsetup(state,tipe,tradeunit,species,productname,hscode,netweight,belowrange,uprange)" +
                    " values(@state,@tipe,@tradeunit,@species,@productname,@hscode,@netweight,@belowrange,@uprange)";
                }
                else
                {
                    mySql3.CommandText =
                    "Update tbproductsetup Set state=@state,tipe=@tipe,tradeunit=@tradeunit,species=@species,productname=@productname, hscode=@hscode, netweight=@netweight,belowrange=@belowrange,uprange=@uprange where id=@id";
                }
                mySql3.Parameters.AddWithValue("@state", cbstate.Text);
                mySql3.Parameters.AddWithValue("@tipe", cbtipe.Text);
                mySql3.Parameters.AddWithValue("@tradeunit", cbtradeunit.Text);
                mySql3.Parameters.AddWithValue("@species", cbspecies.Text);
                string product = cbstate.Text + " " + cbspecies.Text + " " + cbtipe.Text;
                mySql3.Parameters.AddWithValue("@productname", product);

                if (status.Equals("Ada"))
                {
                    mySql3.Parameters.AddWithValue("@id", Int32.Parse(lblid.Text));
                }

                mySql3.Parameters.AddWithValue("@hscode", txthscode.Text.Trim());
                mySql3.Parameters.AddWithValue("@netweight", Double.Parse(txtnetweight.Text.Trim()));
                mySql3.Parameters.AddWithValue("@belowrange", Double.Parse(txtlower.Text.Trim()));
                mySql3.Parameters.AddWithValue("@uprange", Double.Parse(txtupper.Text.Trim()));
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data product setup has been stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            loaddataproductgrid();
        }


        private void loaddataproduksetup()
        {
            List<object[]> datacompany;
            MainMenu frm = new MainMenu();
            datacompany = frm.get_data_table_string("tbproductsetup", "", "");
            if (datacompany.Count > 0)
            {
                cbstate.Text = datacompany[0][0].ToString();
                cbtipe.Text = datacompany[0][1].ToString();
                cbtradeunit.Text = datacompany[0][2].ToString();
                cbspecies.Text = datacompany[0][3].ToString();
                txtproduct.Text = get_scientific(cbspecies.Text.Trim());
                txtproduct.Enabled = false;
            }
            cbstate.Enabled = false;
            cbtipe.Enabled = false;
            cbtradeunit.Enabled = false;
            cbspecies.Enabled = false;
            txtproduct.Enabled = false;
        }


        private void loaddataproductgrid()
        {
            List<object[]> datacompany;
            MainMenu frm = new MainMenu();
            datacompany = frm.get_data_table_string("tbproductsetup", "", "");
            if (datacompany.Count > 0)
            {

                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(datacompany.Count);
                for (int i = 0; i < datacompany.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 40;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = datacompany[i][5].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = datacompany[i][2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = datacompany[i][6].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = datacompany[i][3].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = datacompany[i][7].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = datacompany[i][8].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = datacompany[i][9].ToString();

                }

                Edit_columnbutton();
                Delete_columnbutton();

                cbstate.Text = "";
                cbtipe.Text = "";
                cbtradeunit.Text = "";
                cbspecies.Text = "";
                txtproduct.Text = "";
                txthscode.Text = "";
                txtnetweight.Text = "";
                txtlower.Text = "";
                txtupper.Text = "";
            }
        }


        private void load_htsproduct()
        {
            List<object[]> datahts;
            MainMenu frm = new MainMenu();
            datahts = frm.get_data_table_string("tb_htsproduct", "", "");
            if (datahts.Count > 0)
            {

                dghts.Rows.Clear();
                dghts.Rows.Add(datahts.Count);
                for (int i = 0; i < datahts.Count; i++)
                {
                    dghts.Rows[i].Height = 40;
                    dghts.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dghts.Rows[i].Cells[1].Value = datahts[i][1].ToString();
                    dghts.Rows[i].Cells[2].Value = datahts[i][2].ToString();
                    dghts.Rows[i].Cells[3].Value = datahts[i][3].ToString();
                }

                select_columnbutton();
            }
        }
        
        
        
        
        private void btnsaveproduct_Click(object sender, EventArgs e)
        {
            save_productsetup();
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
                btn.Width = 50;
            }

        }


        private void select_columnbutton()
        {

            if (dghts.Columns.Contains("Select") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dghts.Columns.Insert(4, btn);

                btn.HeaderText = "Select";
                btn.Name = "Select";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }


        private void Delete_columnbutton_option()
        {
            if (dataGridView2.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView2.Columns.Insert(2, btn);

                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }


        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(9, btn);

                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 50;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete  " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbproductsetup", "productname", this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    loaddataproductgrid();
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Edit " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + " " + this.dataGridView1.Rows[e.RowIndex].Cells[2].Value + " " + this.dataGridView1.Rows[e.RowIndex].Cells[3].Value + " ?", "Edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    panel1.Visible = true;
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    MainMenu frm = new MainMenu();
                    String product = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tbproductsetup", "productname", product);
                    for (int i = 0; i <= n; i++)
                    {
                        if (i == n)
                        {
                            id = Int32.Parse(data[0][0].ToString());
                        }
                    }

                    lblid.Text = id.ToString();
                    cbstate.Text = data[0][1].ToString();
                    cbtipe.Text = data[0][2].ToString();
                    cbtradeunit.Text = data[0][3].ToString();
                    cbspecies.Text = data[0][4].ToString();
                    txtproduct.Text = data[0][5].ToString();
                    txthscode.Text = data[0][6].ToString();
                    txtnetweight.Text = data[0][7].ToString();
                    txtlower.Text = data[0][8].ToString();
                    txtupper.Text = data[0][9].ToString();
                }
            }

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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "edit", 8);
            add_column_button(e, "delete", 9);
        }

        private void cbspecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtproduct.Text = cbstate.Text + " " + cbspecies.Text + " " + cbtipe.Text;
        }

        private void btnstate_Click(object sender, EventArgs e)
        {
            groupOption.Visible = true;
            lblOption.Text = "State Setup";
            loadstate_grid();
            txtoption.Text = "";
            
        }

        private void btntype_Click(object sender, EventArgs e)
        {
            groupOption.Visible = true;
            lblOption.Text = "Type Setup";
            loadtipe_grid();
            Delete_columnbutton_option();
        }

        private void btntradeunit_Click(object sender, EventArgs e)
        {
            groupOption.Visible = true;
            lblOption.Text = "Trade Unit Setup";
            loadtradeunit_grid();
            Delete_columnbutton_option();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupOption.Visible = false;
            loadstate();
            loadtipe();
            loadtradeunit();
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            add_column_button(e, "delete", 2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete  " + this.dataGridView2.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    MainMenu frm = new MainMenu();
                    String option=this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

                    if (lblOption.Text.Contains("State"))
                    {
                        frm.delete_table_2params("tboptionproductsetup","kategori","state","options",option);
                        loadstate_grid();
                    }
                    else if (lblOption.Text.Contains("Type"))
                    {
                        frm.delete_table_2params("tboptionproductsetup", "kategori", "tipe", "options", option);
                        loadtipe_grid();
                    }
                    else if (lblOption.Text.Contains("Trade Unit"))
                    {
                        frm.delete_table_2params("tboptionproductsetup", "kategori", "tradeunit", "options", option);
                        loadtradeunit_grid();
                    }
                }
            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save_optionproduct_setup();
        }

        private void save_optionproduct_setup()
        {

            String kategori = "";
            if (lblOption.Text.Contains("State"))
            {
                kategori = "state";
                loadstate_grid();
            }
            else if (lblOption.Text.Contains("Type"))
            {
                kategori = "tipe";
                loadtipe_grid();
            }
            else if (lblOption.Text.Contains("Trade Unit"))
            {
                kategori = "tradeunit";
                loadtradeunit_grid();
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tboptionproductsetup(kategori,options) values(@kategori,@options)";
                mySql3.Parameters.AddWithValue("@kategori", kategori);
                mySql3.Parameters.AddWithValue("@options", txtoption.Text);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

            if (lblOption.Text.Contains("State"))
            {
                loadstate_grid();
            }
            else if (lblOption.Text.Contains("Type"))
            {
                loadtipe_grid();
            }
            else if (lblOption.Text.Contains("Trade Unit"))
            {
                loadtradeunit_grid();
            }

            MessageBox.Show("Data " + txtoption.Text +" has been stored");
        }

        private void btnhts_Click(object sender, EventArgs e)
        {
            gbhts.Visible = true;
            load_htsproduct();
            txtproductdescription.Focus();
        }

        private void dghts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "select", 4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbhts.Visible = false;
        }


        private void search_hts(String products)
        {
            List<object[]> datahts;
            MainMenu frm = new MainMenu();
            String product=txtproductdescription.Text.Trim();
            datahts = frm.get_data_table_string_like("tb_htsproduct", "commodity_description", product);
            if (datahts.Count > 0)
            {

                dghts.Rows.Clear();
                dghts.Rows.Add(datahts.Count);
                for (int i = 0; i < datahts.Count; i++)
                {
                    dghts.Rows[i].Height = 40;
                    dghts.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dghts.Rows[i].Cells[1].Value = datahts[i][1].ToString();
                    dghts.Rows[i].Cells[2].Value = datahts[i][2].ToString();
                    dghts.Rows[i].Cells[3].Value = datahts[i][3].ToString();
                }

                select_columnbutton();
            }
        }


        private void btnsearch_Click(object sender, EventArgs e)
        {
            search_hts(txtproductdescription.Text);
        }

        private void dghts_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == dghts.Columns["Select"].Index && e.RowIndex >= 0 && dghts.Rows.Count > 0)
            {
                    Int32 n = e.RowIndex;
                    MainMenu frm = new MainMenu();
                    String code = this.dghts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txthscode.Text = code;
                    gbhts.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProductCodeSAP frm = new frmProductCodeSAP();
            frm.ShowDialog();
        }


    }
}
