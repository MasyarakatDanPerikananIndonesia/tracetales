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
    public partial class UserAccount : Form
    {
        public UserAccount()
        {
            InitializeComponent();
        }

        public static bool IsValidPassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{5,}");
            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
            return isValidated;
        }

        public String CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("useraccess", btnaccess);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            save_useraccount();
            loaddatauser();
            cselectall.Checked = false;
            cselectall2.Checked = false;
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }

        public List<object[]> data_user(string userid)
        {
             List<object[]> data = new List<object[]>();
             String connString = Konek();
             MySqlConnection conn3 = null;
             try
             {
                conn3 = new MySqlConnection(connString);
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select * from tbuser where username=@username";
                cmd.Parameters.AddWithValue("@username", userid);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"Please check apache services has been started in XAMMP software");
            }

                return data;
        }


        private void save_pwd_change()
        {
            Boolean salah = false;
            if (txtnewpwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("Maaf, password belum diinput, silahkan input password");
                txtnewpwd.Focus();
                txtnewpwd.Clear();
                txtrenewpwd.Clear();
                salah = true;
                return;
            }

            if (!IsValidPassword(txtnewpwd.Text))
            {
                MessageBox.Show("Password harus terdiri dari min 5 character, angka, dan minimal satu huruf kapital, silahkan ulangi masukkan password ");
                txtnewpwd.Focus();
                txtnewpwd.Clear();
                txtrenewpwd.Clear();
                salah = true;
                return;
            }


            if (txtnewpwd.Text != this.txtrenewpwd.Text)
            {
                MessageBox.Show("Maaf, konfirmasi password tidak sama, silahkan entry password yang sama ");
                txtnewpwd.Focus();
                txtnewpwd.Clear();
                txtrenewpwd.Clear();
                salah = true;
                return;
            }

            if (!salah)
            {
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Update tbuser Set ModDateTime=@ModDateTime, passname=@passname where username=@username";

                    mySql3.Parameters.AddWithValue("@passname", CreateMD5(txtnewpwd.Text.Trim()));
                    DateTime dt1 = DateTime.Now;
                    mySql3.Parameters.AddWithValue("@ModDateTime", DateTime.Parse(dt1.ToString("yyyy-MM-dd")));
                    mySql3.Parameters.AddWithValue("@username", txtuseredit.Text);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
                MessageBox.Show("Password for " + txtuseredit.Text  + " has been changed");

            }

        }


        private String get_access_user()
        {
            String access = "";


            if (ccompanyprofile.Checked)
            {
                if (access.Equals(""))
                {
                    access = "companyprofile";
                }
                else
                {
                    access = access + ",companyprofile";
                }
            }

            if (cusersetup.Checked)
            {
                if (access.Equals(""))
                {
                    access = "usersetup";
                }
                else
                {
                    access = access + ",usersetup";
                }
            }

            if (ccustomersetup.Checked)
            {
                if (access.Equals(""))
                {
                    access = "customersetup";
                }
                else
                {
                    access = access + ",customersetup";
                }
            }

            if (cspeciessetup.Checked)
            {
                if (access.Equals(""))
                {
                    access = "speciessetup";
                }
                else
                {
                    access = access + ",speciessetup";
                }
            }

            if (cprocessingcategories.Checked)
            {
                if (access.Equals(""))
                {
                    access = "processingcategories";
                }
                else
                {
                    access = access + ",processingcategories";
                }
            }

            if (cproductsetup.Checked)
            {
                if (access.Equals(""))
                {
                    access = "productsetup";
                }
                else
                {
                    access = access + ",productsetup";
                }
            }

            if (csuppliersetup.Checked)
            {
                if (access.Equals(""))
                {
                    access = "suppliersetup";
                }
                else
                {
                    access = access + ",suppliersetup";
                }
            }

            if (csupplieradditional.Checked)
            {
                if (access.Equals(""))
                {
                    access = "supplieradditional";
                }
                else
                {
                    access = access + ",supplieradditional";
                }
            }

            
            if (creceiving.Checked)
            {
                if (access.Equals(""))
                {
                    access = "receiving";
                }
                else
                {
                    access = access + ",receiving";
                }
            }
            if (ccutting.Checked)
            {
                if (access.Equals(""))
                {
                    access = "cutting";
                }
                else
                {
                    access = access + ",cutting";
                }
            }
            if (cretouching.Checked)
            {
                if (access.Equals(""))
                {
                    access = "retouching";
                }
                else
                {
                    access = access + ",retouching";
                }
            }
            if (cpacking.Checked)
            {
                if (access.Equals(""))
                {
                    access = "packing";
                }
                else
                {
                    access = access + ",packing";
                }
            }
            if (cstuffing.Checked)
            {
                if (access.Equals(""))
                {
                    access = "stuffing";
                }
                else
                {
                    access = access + ",stuffing";
                }
            }
            if (cpackinglist.Checked)
            {
                if (access.Equals(""))
                {
                    access = "plinvoice";
                }
                else
                {
                    access = access + ",plinvoice";
                }
            }

            if (csummary.Checked)
            {
                if (access.Equals(""))
                {
                    access = "summary";
                }
                else
                {
                    access = access + ",summary";
                }
            }

            if (cbyproduct.Checked)
            {
                if (access.Equals(""))
                {
                    access = "byproduct";
                }
                else
                {
                    access = access + ",byproduct";
                }
            }

            if (creceivingbox.Checked)
            {
                if (access.Equals(""))
                {
                    access = "receivingbox";
                }
                else
                {
                    access = access + ",receivingbox";
                }
            }

            if (cinventory.Checked)
            {
                if (access.Equals(""))
                {
                    access = "inventory";
                }
                else
                {
                    access = access + ",inventory";
                }
            }

            if (creprintlabel.Checked)
            {
                if (access.Equals(""))
                {
                    access = "reprintlabel";
                }
                else
                {
                    access = access + ",reprintlabel";
                }
            }

            return access;
        }



        private void save_useraccount()
        {
            Boolean salah=false;

            if (!this.flag.Text.Equals("edit"))
            {
                if (txtpassword.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Maaf, password belum diinput, silahkan input password");
                    txtpassword.Focus();
                    txtpassword.Clear();
                    txtretypepassword.Clear();
                    salah = true;
                    return;
                }

                if (!IsValidPassword(txtpassword.Text))
                {
                    MessageBox.Show("Password harus terdiri dari min 5 character, angka, dan minimal satu huruf kapital, silahkan ulangi masukkan password ");
                    txtpassword.Focus();
                    txtpassword.Clear();
                    txtretypepassword.Clear();
                    salah = true;
                    return;
                }


                if (txtpassword.Text != this.txtretypepassword.Text)
                {
                    MessageBox.Show("Maaf, konfirmasi password tidak sama, silahkan entry password yang sama ");
                    txtpassword.Focus();
                    txtpassword.Clear();
                    txtretypepassword.Clear();
                    salah = true;
                    return;
                }
            }


            if (!salah)
            {
                MainMenu frm = new MainMenu();
                List<object[]> data = new List<object[]>();
                data=data_user(txtuserid.Text);
                String status ="Not Ada";
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
                        "Insert into tbuser(longname,personalid,jobtitle,username,passname,ModDateTime,gender,nationality,useraccess,dateofbirth)" +
                        " values(@longname,@personalid,@jobtitle,@username,@passname,@ModDateTime,@gender,@nationality,@useraccess,@dateofbirth)";
                    }
                    else
                    {
                        mySql3.CommandText =
                        "Update tbuser Set longname=@longname,personalid=@personalid,jobtitle=@jobtitle,ModDateTime=@ModDateTime, gender=@gender,nationality=@nationality,useraccess=@useraccess,dateofbirth=@dateofbirth where username=@username";
                    }

                    mySql3.Parameters.AddWithValue("@longname", txtlongname.Text);
                    mySql3.Parameters.AddWithValue("@personalid", txtpersonalid.Text);
                    mySql3.Parameters.AddWithValue("@jobtitle", txtjobtitle.Text);
                    mySql3.Parameters.AddWithValue("@username", txtuserid.Text.Trim());

                    if (status.Equals("Not Ada"))
                    {
                        mySql3.Parameters.AddWithValue("@passname", CreateMD5(txtpassword.Text.Trim()));
                    }

                    DateTime dt1 = DateTime.Now;
                    mySql3.Parameters.AddWithValue("@ModDateTime", DateTime.Parse(dt1.ToString("yyyy-MM-dd")));
                    mySql3.Parameters.AddWithValue("@gender", comboBox1.Text);
                    mySql3.Parameters.AddWithValue("@nationality", txtnationality.Text);
                    mySql3.Parameters.AddWithValue("@dateofbirth", dateTimePicker1.Value.Date);
                    //read access user
                    String access = get_access_user();
                    mySql3.Parameters.AddWithValue("@useraccess", access);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
                this.flag.Text = ".";
                MessageBox.Show("Data " + txtlongname.Text + " stored");
                clearentry();
            }
        }

        private void clearentry()
        {
            txtlongname.Clear();
            comboBox1.Text = "Male";
            txtjobtitle.Clear();
            txtnationality.Clear();
            txtpersonalid.Clear();
            txtuserid.Clear();
            txtpassword.Clear();
            txtretypepassword.Clear();
        }


        private void loaddatauser()
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
                cmd.CommandText = "select * from tbuser order by username";
                MySqlDataReader rdr = cmd.ExecuteReader();
                int a = 0;
                dataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    a++;
                }
                if (a > 0)
                {
                    dataGridView1.Rows.Add(a);
                    int i = 0;
                    conn4.Open();
                    MySqlCommand cmd1 = new MySqlCommand("", conn4);
                    cmd1.CommandText = "select * from tbuser order by username";
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
                            dataGridView1.Rows[i].Cells[1].Value = rdr1.GetString("username");
                            dataGridView1.Rows[i].Cells[2].Value = rdr1.GetString("longname");
                            dataGridView1.Rows[i].Cells[3].Value = rdr1.GetString("personalid");
                            dataGridView1.Rows[i].Cells[4].Value = rdr1.GetString("jobtitle");
                            dataGridView1.Rows[i].Cells[5].Value = rdr1.GetString("nationality");

                            String datebirth = rdr1.GetString("dateofbirth");
                            DateTime dtbirth = DateTime.Parse(datebirth);
                            dataGridView1.Rows[i].Cells[6].Value = dtbirth.ToString("yyyy-MM-dd");
                            dataGridView1.Rows[i].Cells[7].Value = rdr1.GetString("gender");
                            i++;
                        }
                    }


                    /*
                    if (dataGridView1.Columns.Contains("btn") == false)
                    {

                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(btn);
                        btn.HeaderText = "Edit";
                        btn.Text = "Edit";
                        btn.Name = "btn";
                        btn.UseColumnTextForButtonValue = true;
                        //Delete button
                    }
                     */ 
                    Edit_columnbutton();
                    Delete_columnbutton();
                    Password_columnbutton();
                }
                else
                {
                    MessageBox.Show("Data user is empty");
                }
            }
            finally
            {
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                txtuserid.Visible = true;
                txtpassword.Visible = true;
                txtretypepassword.Visible = true;
                conn3.Close();
                conn4.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            loaddatauser();
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


        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(9, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void Password_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Password") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(10, btn);
                btn.HeaderText = "Password";
                btn.Name = "Password";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;               
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


        private void load_access_user(String useraccess)
        {

            if (useraccess.ToLowerInvariant().Contains("companyprofile"))
            {
                ccompanyprofile.Checked = true;
            }
            else
            {
                ccompanyprofile.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("usersetup"))
            {
                cusersetup.Checked = true;
            }
            else
            {
                cusersetup.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("customersetup"))
            {
                ccustomersetup.Checked = true;
            }
            else
            {
                ccustomersetup.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("speciessetup"))
            {
                cspeciessetup.Checked = true;
            }
            else
            {
                cspeciessetup.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("processingcategories"))
            {
                cprocessingcategories.Checked = true;
            }
            else
            {
                cprocessingcategories.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("productsetup"))
            {
                cproductsetup.Checked = true;
            }
            else
            {
                cproductsetup.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("suppliersetup"))
            {
                csuppliersetup.Checked = true;
            }
            else
            {
                csuppliersetup.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("supplieradditional"))
            {
                csupplieradditional.Checked = true;
            }
            else
            {
                csupplieradditional.Checked = false;
            }
            
            
            if (useraccess.ToLowerInvariant().Contains("receiving"))
            {
                creceiving.Checked = true;
            }
            else
            {
                creceiving.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("cutting"))
            {
                ccutting.Checked = true;
            }
            else
            {
                ccutting.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("retouching"))
            {
                cretouching.Checked = true;
            }
            else
            {
                cretouching.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("packing"))
            {
                cpacking.Checked = true;
            }
            else
            {
                cpacking.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("stuffing"))
            {
                cstuffing.Checked = true;
            }
            else
            {
                cstuffing.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("plinvoice"))
            {
                cpackinglist.Checked = true;
            }
            else
            {
                cpackinglist.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("receivingbox"))
            {
                creceivingbox.Checked = true;
            }
            else
            {
                creceivingbox.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("summary"))
            {
                csummary.Checked = true;
            }
            else
            {
                csummary.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("byproduct"))
            {
                cbyproduct.Checked = true;
            }
            else
            {
                cbyproduct.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("inventory"))
            {
                cinventory.Checked = true;
            }
            else
            {
                cinventory.Checked = false;
            }

            if (useraccess.ToLowerInvariant().Contains("reprintlabel"))
            {
                creprintlabel.Checked = true;
            }
            else
            {
                creprintlabel.Checked = false;
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete user account " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    MainMenu frm = new MainMenu();
                    Int32 id = frm.get_id_data_table("tbuser", "username", e.RowIndex);


                    string connString = Konek();
                    MySqlConnection conn3 = null;
                    conn3 = new MySqlConnection(connString);
                    conn3.Open();
                    MySqlCommand mySql = conn3.CreateCommand();
                    mySql.CommandText = "delete from tbuser where id=@id";
                    mySql.Parameters.AddWithValue("@id", id);
                    mySql.ExecuteNonQuery();
                    conn3.Close();
                    //Delete from Receive_Truck
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    loaddatauser();
                }
            }



            if (e.ColumnIndex == dataGridView1.Columns["Password"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to change password for " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Change Password", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    panel2.Visible = true;
                    txtuseredit.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    return;
                }
            }



            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                if (dataGridView1.Columns["Edit"].HeaderText.Equals("Edit"))
                {
                    

                    txtlongname.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtpersonalid.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtjobtitle.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtnationality.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    String tgl = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(tgl);

                    txtuserid.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtuserid.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    txtpassword.Visible = false;
                    txtretypepassword.Visible = false;
                    this.flag.Text = "edit";

                    MainMenu frm= new MainMenu();
                    List<object[]> data = new List<object[]>();
                    Int32 id = frm.get_id_data_table("tbuser", "username", e.RowIndex);
                    data = frm.get_data_table_id("tbuser", id);
                    //data = frm.get_data_table_string("tbuser", "username", txtuserid.Text);
                    if (data[0][7] != null || !data[0][7].ToString().Equals(""))
                    {
                        comboBox1.Text = data[0][7].ToString();
                    }
                    else
                    {
                        comboBox1.Text = "Male";
                    }
                    txtnationality.Text=data[0][8].ToString();
                    txtpersonalid.Text = data[0][4].ToString();
                    if (data[0][10] != null)
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(data[0][10]);
                    }
                    String useraccess = data[0][9].ToString();

                    load_access_user(useraccess);

                    /*
                    if (useraccess.ToLowerInvariant().Contains("master"))
                    {
                        cmaster.Checked = true;
                    }
                    else
                    {
                        cmaster.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("receiving"))
                    {
                        creceiving.Checked = true;
                    }
                    else
                    {
                        creceiving.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("cutting"))
                    {
                        ccutting.Checked = true;
                    }
                    else
                    {
                        ccutting.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("retouching"))
                    {
                        cretouching.Checked = true;
                    }
                    else
                    {
                        cretouching.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("boxing"))
                    {
                        cpacking.Checked = true;
                    }
                    else
                    {
                        cpacking.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("boxing"))
                    {
                        cpacking.Checked = true;
                    }
                    else
                    {
                        cpacking.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("packing"))
                    {
                        cstuffing.Checked = true;
                    }
                    else
                    {
                        cstuffing.Checked = false;
                    }

                    if (useraccess.ToLowerInvariant().Contains("invoice"))
                    {
                        cpackinglist.Checked = true;
                    }
                    else
                    {
                        cpackinglist.Checked = false;
                    }
                     */ 
                    return;
                }
            }

        }

        private void txtlongname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
                txtpersonalid.Focus();

        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtjobtitle.Focus();
            }

        }



        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtnationality.Focus();
            }

        }

        private void txtnationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dateTimePicker1.Focus();
            }

        }

        private void txtuserid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtpassword.Focus();
            }

        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtretypepassword.Focus();
            }

        }

        private void txtretypepassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                button1.Focus();
            }

        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            txtpersonalid.Focus();
        }

        private void txtcertificate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtuserid.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_pwd_change();
            panel2.Visible = false;
        }

        private void txtuseredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtnewpwd.Focus();
            }

        }

        private void txtnewpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtrenewpwd.Focus();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            var frmCompany = new frmCompany();
            frmCompany.Closed += (s, args) => this.Close();
            frmCompany.ShowDialog();
            
            //frmCompany frm = new frmCompany();
            //frm.Show();
        }

        private void txtpersonalid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtjobtitle.Focus();
            }
        }

        private void txtjobtitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtnationality.Focus();
            }

        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            loaddatauser();
            seticon_forbutton();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "edit", 8);
            add_column_button(e, "delete", 9);
            add_column_button(e, "password", 10);


        }

        private void cmaster_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            grpaccess.Visible = false;
        }

        private void btnaccess_Click(object sender, EventArgs e)
        {

            if (txtuserid.Text.Equals(""))
            {
                MessageBox.Show("You cannot display access user, please click edit button in specified user");
            }
            else
            {
                grpaccess.Visible = true;
                String useraccess = "";
                List<object[]> data = new List<object[]>();
                MainMenu frm = new MainMenu();
                data = frm.get_data_table_string("tbuser", "username", txtuserid.Text.Trim());
                if (data.Count > 0)
                {
                    useraccess = data[0][9].ToString();
                }

                load_access_user(useraccess);
            }
        }

        private void creceiving_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cselectall.Checked)
            {
                ccompanyprofile.Checked = true;
                cusersetup.Checked = true;
                ccustomersetup.Checked = true;
                cspeciessetup.Checked = true;
                cprocessingcategories.Checked = true;
                cproductsetup.Checked = true;
                csuppliersetup.Checked = true;
                csupplieradditional.Checked = true;
            }
            else
            {
                ccompanyprofile.Checked = false;
                cusersetup.Checked = false;
                ccustomersetup.Checked = false;
                cspeciessetup.Checked = false;
                cprocessingcategories.Checked = false;
                cproductsetup.Checked = false;
                csuppliersetup.Checked = false;
                csupplieradditional.Checked = false;
            }
            

        }

        private void cselectall2_CheckedChanged(object sender, EventArgs e)
        {
            if (cselectall2.Checked)
            {
                creceiving.Checked = true;
                ccutting.Checked = true;
                cretouching.Checked = true;
                cpacking.Checked = true;
                cstuffing.Checked = true;
                cpackinglist.Checked = true;
                creceivingbox.Checked = true;
                csummary.Checked = true;
                cbyproduct.Checked = true;
                cinventory.Checked = true;
                creprintlabel.Checked = true;
            }
            else
            {
                creceiving.Checked = false;
                ccutting.Checked = false;
                cretouching.Checked = false;
                cpacking.Checked = false;
                cstuffing.Checked = false;
                cpackinglist.Checked = false;
                creceivingbox.Checked = false;
                csummary.Checked = false;
                cbyproduct.Checked = false;
                cinventory.Checked = false;
                creprintlabel.Checked = false;
            }
        }

    }
}
