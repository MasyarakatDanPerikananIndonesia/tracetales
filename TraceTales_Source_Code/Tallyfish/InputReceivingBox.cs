using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Tallyfish
{
    public partial class InputReceivingBox : Form
    {
        public InputReceivingBox()
        {
            InitializeComponent();
        }

        private String get_receivingbox_no()
        {
            String rcvbox = "";
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            String tahunbulan="";
            DateTime dt = DateTime.Now;
            tahunbulan=dt.ToString("yyMM");
            //Int32 urut = 0;
            String urutstr = "";
            String urutseq = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            String co_code = "";
            if (data.Count > 0)
            {
                co_code = data[0][13].ToString();
            }

            Int32 nextnumber = 0;

            data = frm.get_data_table_string("increment_receivingbox", "tahunbulan",tahunbulan);
            if (data.Count > 0)
            {
                urutstr = data[0][1].ToString();
                if (urutstr.Length == 1)
                {
                    urutseq = "00" + urutstr;
                }
                else if (urutstr.Length == 2)
                {
                    urutseq = "0" + urutstr;
                }
                else if (urutstr.Length == 3)
                {
                    urutseq = urutstr;
                }

                rcvbox = "R" + co_code + "-" + urutseq;
                nextnumber = Int32.Parse(urutstr) + 1;
            }
            else
            {
                urutstr = "1";
                urutseq = "00" + urutstr;
                rcvbox = "R" + co_code + "-" + urutseq;
                nextnumber = Int32.Parse(urutstr) + 1;
            }

           
            //update increment_receivingbox
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update increment_receivingbox set tahunbulan=@tahunbulan,nextnumber=@nextnumber";
                mySql3.Parameters.AddWithValue("@tahunbulan", tahunbulan);
                mySql3.Parameters.AddWithValue("@nextnumber", nextnumber);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

            return rcvbox;
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            create_receivingbox();
            btn_entry_rcvbox.Visible = false;
        }


        private void create_receivingbox()
        {
            //To get receiving box number from sequence
            lblrcvno.Text = get_receivingbox_no();

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into tbreceiving_box(rcvno,receivedfrom,refno,rcvdate,operator)" +
                " values(@rcvno,@receivedfrom,@refno,@rcvdate,@operator)";
                mySql3.Parameters.AddWithValue("@rcvno", lblrcvno.Text.Trim());
                mySql3.Parameters.AddWithValue("@receivedfrom", cbreceived.Text.Trim());
                mySql3.Parameters.AddWithValue("@refno", txtreference.Text.Trim());
                mySql3.Parameters.AddWithValue("@rcvdate", dateTimePicker1.Value.Date);
                mySql3.Parameters.AddWithValue("@operator", Properties.Settings.Default.username);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

        }


        private void load_processing_company_cb()
        {
            List<object[]> data1 = new List<object[]>();
            MainMenu frm = new MainMenu();
            data1 = frm.get_data_table_string_byid_desc("tbprocessingcompany", "", "");
            cbreceived.Items.Clear();
            if (data1.Count > 0)
            {
                for (int i = 0; i < data1.Count; i++)
                {
                    cbreceived.Items.Add(data1[i][1].ToString().Trim());
                }
            }
        }



        public void setInitialValue()
        {
            gbentry.Visible = true;
            load_processing_company_cb();

            
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            /*
            data = frm.get_data_table_string_byid_desc("tbprocessingcompany", "", "");
            cbreceived.Items.Clear();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    cbreceived.Items.Add(data[i][1].ToString().Trim());
                }
            }
            */ 

            dateTimePicker1.Value = DateTime.Now;


            data = frm.get_data_table_string_byid_desc("tbreceiving_box", "", "");
            cbreceiving_recent.Items.Clear();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    cbreceiving_recent.Items.Add(data[i][1].ToString().Trim());
                }
            }

        }



        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("create", button2);
            frm.setbuttonicon("open", button1);
            frm.setbuttonicon("down", btnrecent);
            frm.setbuttonicon("down", btnrcv);
        }



        private void InputReceivingBox_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            setInitialValue();
        }

        private void load_box(String rcvno)
        {
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbpacking", "rcvno", rcvno);
            double netweight = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
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
                    dataGridView1.Rows[i].Cells[3].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][11].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][8].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][5].ToString();

                    DateTime dt = DateTime.Parse(data[i][7].ToString());
                    dataGridView1.Rows[i].Cells[7].Value = dt.ToString("yyyy-MM-dd");
                    
                    dataGridView1.Rows[i].Cells[8].Value = lblrcvno.Text.Trim();
                    netweight = netweight + Double.Parse(data[i][11].ToString());
                }
            }

            Delete_columnbutton();
            Int32 totalpcs = data.Count;
            lblcase.Text = totalpcs.ToString();
            lblweight.Text = netweight.ToString();
        }

        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(9, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
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


        private void scan_box()
        {
            String data = txtscan.Text.Trim();
            String[] eachdata = data.Split('*');

            String caseno = eachdata[1].ToString();
            String productname = eachdata[2].ToString();
            String productpacking = eachdata[3].ToString();
            String grade = eachdata[4].ToString();
            String size = eachdata[5].ToString();
            double boxweight = Double.Parse(eachdata[6].ToString());
            Int32 pcs = Int32.Parse(eachdata[7].ToString());
            String intlotcode = eachdata[8].ToString();
            DateTime expdate = DateTime.Parse(eachdata[9].ToString());
            String expdateonly = eachdata[9].ToString();
            DateTime proddate = expdate.AddYears(-2);
            String proddateonly = proddate.ToString("yyyy-MM-dd");
            String certificate = eachdata[10].ToString();

            //Check case no
            
            List<object[]> data1 = new List<object[]>();
            MainMenu frm = new MainMenu();
            data1 = frm.get_data_table_string("tbpacking", "case_number", caseno);
            if (data1.Count > 0)
            {
                lblmessage.Text = "Case No " + caseno + " has been available, under " + data1[0][17].ToString() + ", please use another case number";
                txtscan.Clear();
                txtscan.Focus();
                return;
            }
            else
            {
                //Insert data
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();
                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into tbpacking(box_number,case_number,grade,packingsize,intlotcode,lot_number,best_before_date,pieces,id_species,boxweight,proddate,username,moddatetime, rcvno, productname,productpacking,certificate)" +
                    " values(@box_number,@case_number,@grade,@packingsize,@intlotcode,@lot_number,@best_before_date,@pieces,@id_species,@boxweight,@proddate,@username,@moddatetime,@rcvno,@productname,@productpacking,@certificate)";
                    mySql3.Parameters.AddWithValue("@box_number", caseno.Trim());
                    mySql3.Parameters.AddWithValue("@case_number", caseno.Trim());
                    mySql3.Parameters.AddWithValue("@grade", grade.Trim());
                    mySql3.Parameters.AddWithValue("@packingsize", size.Trim());
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode.Trim());
                    mySql3.Parameters.AddWithValue("@lot_number", "L" + caseno.Trim());
                    mySql3.Parameters.AddWithValue("@best_before_date", DateTime.Parse(expdateonly));
                    mySql3.Parameters.AddWithValue("@pieces", pcs);
                    mySql3.Parameters.AddWithValue("@id_species", 1);
                    mySql3.Parameters.AddWithValue("@boxweight", boxweight);
                    mySql3.Parameters.AddWithValue("@proddate", DateTime.Parse(proddateonly));
                    mySql3.Parameters.AddWithValue("@username", Properties.Settings.Default.username);
                    mySql3.Parameters.AddWithValue("@moddatetime", DateTime.Now);
                    mySql3.Parameters.AddWithValue("@rcvno", lblrcvno.Text.Trim());
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    mySql3.Parameters.AddWithValue("@productpacking", productpacking);
                    mySql3.Parameters.AddWithValue("@certificate", certificate);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
                load_box(lblrcvno.Text.Trim());
            }
            txtscan.Text = "";
            txtscan.Text=txtscan.Text.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            txtscan.Focus();
        }

        private void txtscan_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                if (txtscan.Text.Contains("*"))
                {
                    String data_scan = "";
                    data_scan = txtscan.Text;
                   get_data_split_enter(data_scan);
                }
                txtscan.Text.Replace("\r", "");
                txtscan.Text.Replace("\n", "");
  
/*
                if (txtscan.Text.Contains("*"))
                {
                    if (txtscan.Text.Length > 12)
                    {
                        scan_box();
                    }
                    else
                    {
                        lblmessage.Text = "Sorry, case_number is not valid ";
                        txtscan.Text = "";
                        txtscan.Focus();
                    }
                }
 */ 


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Case No " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    String case_number = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "delete from tbpacking where case_number=@case_number";
                    mySql3.Parameters.AddWithValue("@case_number", case_number);
                    mySql3.ExecuteNonQuery();
                    conn5.Close();
                    load_box(lblrcvno.Text.Trim());
                    txtscan.Clear();
                    txtscan.Focus();
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            gbentry.Visible = false;
            create_receivingbox();
            panel1.Visible = true;
            txtscan.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblrcvno.Text = cbreceiving_recent.Text.Trim();
            load_box(lblrcvno.Text);
            gbentry.Visible = false;
            panel1.Visible = true;
            txtscan.Clear();
            txtscan.Focus();
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 9);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtscan_TextChanged(object sender, EventArgs e)
        {

        }

        private void get_data_split_enter(String data)
        {

            String[] eachdata= null;
            Char[] splitChars = new Char[] { '\n' };
            eachdata = data.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            String data2 = "";
            for (int i = 0; i < eachdata.Length; i++)
            {
                if (data2.Equals(""))
                {
                    data2 = eachdata[i];
                }
                else
                {
                    data2 = data2 + eachdata[i];
                }
            }

            splitChars = new Char[] { '\r' };
            eachdata = data2.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);


            String caseno = eachdata[0].ToString().Replace("\r","");
            String productname = eachdata[1].ToString().Replace("\r", "");
            String productpacking = eachdata[3].ToString().Replace("\r", "");
            String grade = eachdata[4].ToString().Replace("\r", "");
            String size = eachdata[5].ToString().Replace("\r", "");
            double boxweight = Double.Parse(eachdata[6].ToString().Replace("\r", ""));
            Int32 pcs = Int32.Parse(eachdata[7].ToString().Replace("\r", ""));
            String intlotcode = eachdata[9].ToString().Replace("\r", "");
            DateTime expdate = DateTime.Parse(eachdata[10].ToString().Replace("\r", ""));
            String expdateonly = eachdata[10].ToString();
            DateTime proddate = expdate.AddYears(-2);
            String proddateonly = proddate.ToString("yyyy-MM-dd");
            
            String certificate = "";
            if (intlotcode.Contains("FT"))
            {
                certificate = "FT";
            }
            else if (intlotcode.Contains("MSC"))
            {
                certificate = "MSC";
            }

            //Check case no

            List<object[]> data1 = new List<object[]>();
            MainMenu frm = new MainMenu();
            data1 = frm.get_data_table_string("tbpacking", "case_number", caseno);
            if (data1.Count > 0)
            {
                String reference=data1[0][9].ToString();
                if (reference.Length == 0)
                {
                    reference = data1[0][17].ToString();
                }

                lblmessage.Text = "Case No " + caseno + " has been available, under " + reference + ", please use another case number";
                txtscan.Clear();
                txtscan.Focus();
                return;
            }
            else
            {
                //Insert data
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();
                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into tbpacking(box_number,case_number,grade,packingsize,intlotcode,lot_number,best_before_date,pieces,id_species,boxweight,proddate,username,moddatetime, rcvno, productname,productpacking,certificate)" +
                    " values(@box_number,@case_number,@grade,@packingsize,@intlotcode,@lot_number,@best_before_date,@pieces,@id_species,@boxweight,@proddate,@username,@moddatetime,@rcvno,@productname,@productpacking,@certificate)";
                    mySql3.Parameters.AddWithValue("@box_number", caseno.Trim());
                    mySql3.Parameters.AddWithValue("@case_number", caseno.Trim());
                    mySql3.Parameters.AddWithValue("@grade", grade.Trim());
                    mySql3.Parameters.AddWithValue("@packingsize", size.Trim());
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode.Trim());
                    mySql3.Parameters.AddWithValue("@lot_number", "L" + caseno.Trim());
                    mySql3.Parameters.AddWithValue("@best_before_date", DateTime.Parse(expdateonly));
                    mySql3.Parameters.AddWithValue("@pieces", pcs);
                    mySql3.Parameters.AddWithValue("@id_species", 1);
                    mySql3.Parameters.AddWithValue("@boxweight", boxweight);
                    mySql3.Parameters.AddWithValue("@proddate", DateTime.Parse(proddateonly));
                    mySql3.Parameters.AddWithValue("@username", Properties.Settings.Default.username);
                    mySql3.Parameters.AddWithValue("@moddatetime", DateTime.Now);
                    mySql3.Parameters.AddWithValue("@rcvno", lblrcvno.Text.Trim());
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    mySql3.Parameters.AddWithValue("@productpacking", productpacking);
                    mySql3.Parameters.AddWithValue("@certificate", certificate);
                    mySql3.ExecuteNonQuery();
                }catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);                
                }
                conn5.Close();
                load_box(lblrcvno.Text.Trim());
            }
            txtscan.Text = "";
            txtscan.Clear();
            txtscan.Text = txtscan.Text.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            txtscan.Focus();
            return;
       }

        private void btnaddcompany_Click(object sender, EventArgs e)
        {
            panelProcessingCompany.Visible = true;
            loaddataprocessingcompany();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save_processing_company();
            loaddataprocessingcompany();
        }


        private void save_processing_company()
        {
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbprocessingcompany", "co_code", txtcocode.Text.Trim());
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
                    "Insert into tbprocessingcompany(co_code, companyname,address,phone) " +
                    " values(@co_code, @companyname,@address,@phone)";

                    mySql3.Parameters.AddWithValue("@co_code", txtcocode.Text);
                    mySql3.Parameters.AddWithValue("@companyname", txtcompanyname.Text);
                    mySql3.Parameters.AddWithValue("@address", txtaddress.Text);
                    mySql3.Parameters.AddWithValue("@phone", txtphone.Text);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
            }
            else
            {

                try
                {
                    mySql3.CommandText =
                    "Update tbprocessingcompany set companyname=@companyname,address=@address,phone=@phone where co_code=@co_code ";

                    mySql3.Parameters.AddWithValue("@co_code", txtcocode.Text);
                    mySql3.Parameters.AddWithValue("@companyname", txtcompanyname.Text);
                    mySql3.Parameters.AddWithValue("@address", txtaddress.Text);
                    mySql3.Parameters.AddWithValue("@phone", txtphone.Text);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
            }
        }


        private void loaddataprocessingcompany()
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
                cmd.CommandText = "select * from tbprocessingcompany order by co_code";
                MySqlDataReader rdr = cmd.ExecuteReader();
                int a = 0;
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dgprocessingcompany.Rows.Clear();
                    dgprocessingcompany.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbprocessingcompany order by co_code";
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    while (rdr1.Read())
                    {
                        if (a > 0)
                        {
                            dgprocessingcompany.Rows[i].Height = 50;
                            dgprocessingcompany.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dgprocessingcompany.Rows[i].Cells[1].Value = rdr1.GetString("co_code");
                            dgprocessingcompany.Rows[i].Cells[2].Value = rdr1.GetString("companyname");
                            i++;
                        }
                    }

                    txtcocode.Focus();
                    Edit_columnbutton_processing();
                    Delete_columnbutton_processing();
                }
                else
                {
                    MessageBox.Show("Data Processing Company is empty");
                }
            }
            finally
            {
                conn3.Close();
                conn4.Close();
                txtcocode.Clear();
                txtcompanyname.Clear();
                txtphone.Clear();
                txtaddress.Clear();

            }
        }


        private void Edit_columnbutton_processing()
        {
            if (dgprocessingcompany.Columns.Contains("Edit") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgprocessingcompany.Columns.Insert(3, btn);
                btn.HeaderText = "Edit";
                btn.Name = "Edit";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void Delete_columnbutton_processing()
        {
            if (dgprocessingcompany.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgprocessingcompany.Columns.Insert(4, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelProcessingCompany.Visible = false;
            load_processing_company_cb();
        }

        private void dgprocessingcompany_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "edit", 3);
            add_column_button(e, "delete", 4);
        }

        private void dgprocessingcompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgprocessingcompany.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dgprocessingcompany.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + this.dgprocessingcompany.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    String cocode = this.dgprocessingcompany.Rows[e.RowIndex].Cells[1].Value.ToString();
                    MainMenu frm = new MainMenu();
                    frm.delete_table("tbprocessingcompany", "co_code", cocode);
                    dgprocessingcompany.Rows.RemoveAt(dgprocessingcompany.SelectedRows[0].Index);
                    loaddataprocessingcompany();
                }
            }


            if (e.ColumnIndex == dgprocessingcompany.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Edit " + this.dgprocessingcompany.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MainMenu frm = new MainMenu();
                    String cocode = this.dgprocessingcompany.Rows[e.RowIndex].Cells[1].Value.ToString();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_string("tbprocessingcompany", "co_code",cocode);
                    if (data.Count > 0)
                    {
                        txtcocode.Text = cocode;
                        txtcompanyname.Text = data[0][1].ToString();
                        txtaddress.Text = data[0][2].ToString();
                        txtphone.Text = data[0][3].ToString();
                    }

                }
            }
        }

        private void btnrcv_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnrcv.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnrecent_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnrecent.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnrcv_Click(object sender, EventArgs e)
        {
            cbreceived.DroppedDown = true;
        }

        private void btnrecent_Click(object sender, EventArgs e)
        {
            this.cbreceiving_recent.DroppedDown = true;
        }

        private void btnaddcompany_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnaddcompany.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

    }
}
