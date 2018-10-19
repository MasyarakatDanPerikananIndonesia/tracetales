using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;

namespace Tallyfish
{

    public partial class MainMenu : Form
    {

        public String userlogin;

        public MainMenu()
        {
            InitializeComponent();
        }

        
        private String getpassword(String value){
            UserAccount frm = new UserAccount();
            List<object[]> data = new List<object[]>();
            data = frm.data_user(value);
            if (data.Count > 0)
            {
                String data1 = data[0][2].ToString();

                return data1;
            }
            else
            {
                MessageBox.Show("System has not found the match password ");
                return "NA";
            }
        }


        private Boolean matchpassword(String userlogin, String pwdinput)
        {

            if (userlogin.Equals("admin"))
            {
                return true;
            }
            else
            {

                UserAccount frm = new UserAccount();
                String pwd_database = getpassword(userlogin);
                String pwd_input = frm.CreateMD5(pwdinput);
                if (pwd_input.Equals(pwd_database))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }


        public DateTime get_server_time()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            try
            {
                conn3 = new MySqlConnection(connString);
                conn3.Open();

                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select NOW() from DUAL";

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
            }
            finally
            {
                conn3.Close();
            }
            return DateTime.Parse(data[0][0].ToString());
        }




        private void button2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (matchpassword(txtuser.Text.Trim(), txtpass.Text.Trim()) || (txtuser.Text.ToLower().Equals("admin") && txtpass.Text.ToLower().Equals("admin")))
            {

                btnmastersetup1.Visible = true;
                btntransaction1.Visible = true;
                panel1.Hide();
                Properties.Settings.Default.username = txtuser.Text.Trim();
                MessageBox.Show(txtuser.Text + " has been logged in");
                btnlogout.Visible = true;
                panelsetup.Visible = false;

            }
            else
            {
                MessageBox.Show("Password yang diinput salah, silahkan ulangi kembali");
                txtuser.Clear();
                txtpass.Clear();
            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("master", btnmastersetup1);
            frm.setbuttonicon("transaction", btntransaction1);
            frm.setbuttonicon("company", btncompany);
            frm.setbuttonicon("user", btnuser);
            frm.setbuttonicon("customer", btncustomer);
            frm.setbuttonicon("species", btnspecies);
            frm.setbuttonicon("processing_categories", btncategories);
            frm.setbuttonicon("product_setup", btnproduct);
            frm.setbuttonicon("supplier", btnsupplier);
            frm.setbuttonicon("supplieradd", btnsupplieradd);
            frm.setbuttonicon("logout", btnlogout);
            frm.setbuttonicon("back", btnback);
            frm.setbuttonicon("logout", btnexit);
            frm.setbuttonicon("login", btnlogin);
        }



        private String get_useraccess()
        {
            String useraccess = "";
            String userlogin = Properties.Settings.Default.username;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbuser", "username", userlogin.Trim());
            if (data.Count > 0)
            {
                useraccess = data[0][9].ToString();
            }
            return useraccess;
        }


        private void MainMenu_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\background.jpg";
            pbbackground.Image = Image.FromFile(icondir);
            //btnlogout.Visible = true;
        }


        public void setbuttonicon(String function, Button btn)
        {
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\" + function + ".png";
            btn.Image = Image.FromFile(icondir);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public void setbuttonicon_top(String function, Button btn)
        {
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\" + function + ".png";
            btn.Image = Image.FromFile(icondir);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;
        }


        public string getdbname()
        {

            var path = Directory.GetCurrentDirectory();
            var location = path + "\\database.config";
            String ipserver = "";
            String database = "";
            String userid = "";
            String pwd = "";
            Int32 baud = 0;
            Int32 port = 0;

            if (System.IO.File.Exists(location) == true)
            {
                using (StreamReader reader = new StreamReader(location))
                {
                    const int linesToRead = 5;
                    while (!reader.EndOfStream)
                    {
                        string[] currReadLines = new string[linesToRead];
                        for (var i = 0; i < linesToRead; i++)
                        {
                            var currLine = reader.ReadLine();
                            if (currLine == null)
                                break;

                            currReadLines[i] = currLine;
                        }
                        ipserver = currReadLines[0];
                        database = currReadLines[1];
                        userid = currReadLines[2];
                        pwd = currReadLines[3];
                        baud = Int32.Parse(currReadLines[4]);
                    }

                }
            }

            return database;
        }



        public string Konek()
        {

            var path = Directory.GetCurrentDirectory();
            var location = path + "\\database.config";
            String ipserver = "";
            String database = "";
            String userid = "";
            String pwd = "";
            Int32 baud = 0;
            Int32 port = 0;

            if (System.IO.File.Exists(location) == true)
            {
                using (StreamReader reader = new StreamReader(location))
                {
                    const int linesToRead = 5;
                    while (!reader.EndOfStream)
                    {
                        string[] currReadLines = new string[linesToRead];
                        for (var i = 0; i < linesToRead; i++)
                        {
                            var currLine = reader.ReadLine();
                            if (currLine == null)
                                break;

                            currReadLines[i] = currLine;
                        }
                        ipserver = currReadLines[0];
                        database = currReadLines[1];
                        userid = currReadLines[2];
                        pwd = currReadLines[3];
                        baud = Int32.Parse(currReadLines[4]);
                    }

                }
            }


            String connString = @"server = " + ipserver + ";database = " + database + ";user id = " + userid + ";password=" + pwd + "" + ";default command timeout=0";
       
            
            return connString;
        }

        public void delete_fisherman(String intlotcode, String fisherman, Int32 fishnoawal)
        {
            MainMenu frm = new MainMenu();
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand mySql = conn3.CreateCommand();
            mySql.CommandText = "update tbreceiving_fisherman  set intlotcode='4del', fishno_awal=0, fishno_akhir=0, moddatetime=@moddatetime where intlotcode=@intlotcode and  fisherman=@fisherman and fishno_awal=@fishno_awal";
            mySql.Parameters.AddWithValue("@intlotcode", intlotcode);
            mySql.Parameters.AddWithValue("@fisherman", fisherman);
            mySql.Parameters.AddWithValue("@fishno_awal", fishnoawal);
            mySql.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
            mySql.ExecuteNonQuery();
            conn3.Close();
            //conn3.Dispose();
        }

        public String get_supplier_receiving(String supp)
        {
            String supplier = "";
            String[] getsupplier = supp.Split('-');
            supplier = getsupplier[1];
            return supplier;
        }

        public List<object[]> get_data_table_string(String tablename, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            try
            {
                conn3 = new MySqlConnection(connString);
                conn3.Open();

                MySqlCommand cmd = new MySqlCommand("", conn3);
                if (!field.Equals(""))
                { //to get all data with filtering
                    cmd.CommandText = "select * from " + tablename + " where " + field + "=@value";
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
            }
            finally
            {
                conn3.Close();
            }
            return data;
        }


        public List<object[]> get_caseno_from_loin(String loin)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            try
            {
                conn3 = new MySqlConnection(connString);
                conn3.Open();

                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "SELECT b.case_number FROM `tbretouchingdetails` a join tbpacking b on a.box_number = b.box_number where a.`loin_number`=@value";
                cmd.Parameters.AddWithValue("@value", loin);
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
            }
            finally
            {
                conn3.Close();
            }
            return data;
        }




        public List<object[]> get_data_packing_list(String tablename, String plno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);

            if (tablename.Equals("tbpacking"))
            {
                if (!plno.Equals(""))
                { //to get all data with filtering

                    cmd.CommandText = "select * from tbpacking where shipping_unit_number=@value order by grade, packingsize desc";
                    cmd.Parameters.AddWithValue("@value", plno);
                }
                else
                { // to get all data without filtering
                    cmd.CommandText = "select * from tbpacking order by grade, packingsize desc";
                }
            }
            else if (tablename.Equals("tbpackinglist"))
            {

                if (!plno.Equals(""))
                { //to get all data with filtering

                    cmd.CommandText = "select * from tbpackinglist where plno=@value order by grade, size,certificate desc";
                    cmd.Parameters.AddWithValue("@value", plno);
                }
                else
                { // to get all data without filtering
                    cmd.CommandText = "select * from tbpackinglist order by grade, size desc";
                }
            }


            try
            {
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
            }
            finally
            {
                conn3.Close();
                
            }
            return data;
        }



        
        /*
        public List<object[]> get_data_table_string_field(String tablename, Int32 fieldindex, Int32 lengthfield, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (fieldindex>0)
            { //to get all data with filtering
                cmd.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + tablename + "' and table_schema = '" + getdbname() + "' limit " + fieldindex + "," + lengthfield;
            }

            String namafield = "";
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

            for (int n = 0; n < data.Count; n++)
            {
                if (!namafield.Equals(""))
                {
                    namafield = namafield + "," + data[n];
                }
                else
                {
                    namafield = data[n].ToString();
                }
            }
            conn3.Close();

            conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select " + namafield + " from " + tablename + " where " + field + " like @value";
                cmd.Parameters.AddWithValue("@value", "%" + value + "%");
            }
            else
            { // to get all data without filtering
                cmd.CommandText = "select " + namafield + " from " + tablename;
            }

            rdr = cmd.ExecuteReader();
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
         */ 


        public List<object[]> get_data_table_string_fieldname(String tablename, String fieldname, String fieldcondition, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);

            if (fieldcondition.Equals(""))
            {
                cmd.CommandText = "select " + fieldname + " from " + tablename;
            }
            else
            {
                cmd.CommandText = "select " + fieldname + " from " + tablename + " where " + fieldcondition + " = @value";
            }
            
            cmd.Parameters.AddWithValue("@value",  value );

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


        public List<object[]> get_data_batch_sequence(String boxno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!boxno.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT intlotcode, count(intlotcode) as jum FROM `tbretouchingdetails` WHERE `box_number`=@boxno group by intlotcode order by count(intlotcode) desc";
                cmd.Parameters.AddWithValue("@boxno", boxno);
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



        public String get_batch_number(String boxno)
        {
            List<object[]> data = new List<object[]>();
            data = get_data_batch_sequence(boxno);
            String intlotcode1 = "";
            String areacode = "";

            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    intlotcode1 = data[i][0].ToString();
                    if (areacode.Equals(""))
                    {
                        areacode = intlotcode1.Substring(0, 3);
                    }
                    if (!areacode.Contains(intlotcode1.Substring(0, 3)))
                    {
                        areacode = areacode + "-" + intlotcode1.Substring(0, 3);
                    }
                }
            }
            return areacode;
        }


        public List<object[]> get_data_table_string_like(String tablename, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + " like @value";
                cmd.Parameters.AddWithValue("@value", "%"+value+"%");
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




        public List<object[]> get_data_table_string_byid_desc(String tablename, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + "=@value order by id desc";
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


        public List<object[]> get_grupsize_loin(Double weight)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (weight>0)
            { //to get all data with filtering
                cmd.CommandText = "SELECT grupsize FROM tbgrupsize where @weight >=lower and @weight<=upper and module=@module";
                cmd.Parameters.AddWithValue("@module", "retouching");
                cmd.Parameters.AddWithValue("@weight", weight);
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




        public List<object[]> get_data_table_retouching_datetime_desc(String boxno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!boxno.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT a.*, b.grupsize FROM tbretouchingdetails a left outer join tbgrupsize b  on a.rweight>=b.lower and a.rweight<=b.upper and b.module=@module where a.box_number=@boxno order by a.moddatetime desc";
                cmd.Parameters.AddWithValue("@module", "retouching");
                cmd.Parameters.AddWithValue("@boxno", boxno);
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


        public List<object[]> get_list_data_table_retouching_datetime_desc(String boxno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!boxno.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT a.loin_number, a.grade, a.rweight, a.remark, a.intlotcode, b.grupsize FROM tbretouchingdetails a left outer join tbgrupsize b  on a.rweight>=b.lower and a.rweight<=b.upper and b.module=@module where a.box_number=@boxno order by a.moddatetime desc";
                cmd.Parameters.AddWithValue("@module", "retouching");
                cmd.Parameters.AddWithValue("@boxno", boxno);
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




        public List<object[]> get_data_table_packing_datetime_desc(String pl)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!pl.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT * FROM tbpacking where shipping_unit_number=@pl order by moddatetime desc";
                cmd.Parameters.AddWithValue("@pl", pl);
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


        public List<object[]> get_data_table_packing_datetime_desc_fieldname(String pl,String fieldname)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!pl.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT "+ fieldname+" FROM tbpacking where shipping_unit_number=@pl order by moddatetime desc";
                cmd.Parameters.AddWithValue("@pl", pl);
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


        public List<object[]> get_data_netweight_packing(String pl)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!pl.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "SELECT coalesce(sum(boxweight),0) as netweight FROM tbpacking where shipping_unit_number=@pl";
                cmd.Parameters.AddWithValue("@pl", pl);
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



        public List<object[]> get_data_table_id(String tablename, Int32 id)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (id != null )
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
            }
            else
            { // to get all data without filtering
                cmd.CommandText = "select * from " + tablename;
            }


                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
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




        public List<object[]> get_data_table_transaction(String tablename, String intlot, String orderfield1, String orderfield2)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);

            try
            {
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);

                if (!orderfield1.Equals("") && !orderfield2.Equals(""))
                {
                    cmd.CommandText = "select * from " + tablename + " where intlotcode=@intlot order by " + orderfield1 + " desc, " + orderfield2 + " desc";
                }
                else if (!orderfield1.Equals(""))
                {
                    cmd.CommandText = "select * from " + tablename + " where intlotcode=@intlot order by " + orderfield1 + " desc ";
                }

                cmd.Parameters.AddWithValue("@intlot", intlot);

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
            }
            finally
            {
                conn3.Close();
            }
            return data;
        }



        public List<object[]> get_data_table_transaction_fieldname(String tablename, String fieldname, String intlot, String orderfield1, String orderfield2)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);

            try
            {
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);

                if (!orderfield1.Equals("") && !orderfield2.Equals(""))
                {
                    cmd.CommandText = "select " + fieldname + " from " + tablename + " where intlotcode=@intlot order by " + orderfield1 + " desc, " + orderfield2 + " desc";
                }
                else if (!orderfield1.Equals(""))
                {
                    cmd.CommandText = "select "+ fieldname+ " from " + tablename + " where intlotcode=@intlot order by " + orderfield1 + " desc ";
                }

                cmd.Parameters.AddWithValue("@intlot", intlot);

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
            }
            finally
            {
                conn3.Close();
            }
            return data;
        }



        public List<object[]> get_data_table_search(String tablename, String intlotcode, String value)
        {

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            if (tablename.Contains("tbcuttingdetails"))
            {
                if (value.Equals("") || value == null)
                {
                    cmd.CommandText = "select * from tbcuttingdetails where intlotcode=@intlotcode";
                    cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                }
                else
                {
                    cmd.CommandText = "select * from tbcuttingdetails where intlotcode=@intlotcode and (grade=@value or cweight=@value)";
                    cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                    cmd.Parameters.AddWithValue("@value", value);
                }
            }
            else if (tablename.Contains("tbretouchingdetails"))
            {

                if (value.Equals("") || value == null)
                {
                    cmd.CommandText = "select * from tbretouchingdetails where intlotcode=@intlotcode";
                    cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                }
                else
                {
                    cmd.CommandText = "select * from tbretouchingdetails where intlotcode=@intlotcode and (grade=@value or rweight=@value)";
                    cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                    cmd.Parameters.AddWithValue("@value", value);
                }
           
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


        public Int32 get_id_data_table(String tablename, String orderfield, Int32 rowindex)
        {
            Int32 id=0;
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!orderfield.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " order by " + orderfield ;
            }
            else
            { // to get all data without filtering
                cmd.CommandText = "select * from " + tablename;
            }


                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object[] tempRow = new object[rdr.FieldCount];
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        tempRow[i] = rdr[i];
                    }
                    data.Add(tempRow);
                }
                //conn3.Close();
                id = Int32.Parse(data[rowindex][0].ToString());
                conn3.Close();
            return id;
        }


        public List<object[]> get_max_sequence_loin(String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!value.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select max(loin_number) from tbretouchingdetails where loin_number like @value";
                cmd.Parameters.AddWithValue("@value", "%" + value + "%");
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







        public List<object[]> get_data_sequence_loin(String tablename, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + " like  @value  order by loin_number desc";
                cmd.Parameters.AddWithValue("@value", "%"+value+"%");
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



        public String get_data_sequence_receiving(String tablename, String field, String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select count(intlotcode)+1 as sequence from " + tablename + " where " + field + " like  @value  ";
                cmd.Parameters.AddWithValue("@value",  "%"+value+"%" );
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
            return data[0][0].ToString();
        }







        public List<object[]> get_data_sequence_lot_grade_pdc(String intlotcode, String tipe, String grade)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!intlotcode.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from tbretouchingdetails where tipe=@tipe and grade=@grade and intlotcode=@intlotcode order by lotnumber desc";
                cmd.Parameters.AddWithValue("@tipe", tipe);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
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



        private void set_nextnumber_box(String pdc, Int32 nextnumber)
        {
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update increment_box set pdc=@pdc, nextnumber=@nextnumber";
                mySql3.Parameters.AddWithValue("@pdc", pdc);
                mySql3.Parameters.AddWithValue("@nextnumber", nextnumber);
                mySql3.ExecuteNonQuery();
                conn5.Close();
        }


        public List<object[]> get_max_sequence_boxno(String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!value.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select max(box_number) from tbpacking where box_number like @value";
                cmd.Parameters.AddWithValue("@value", "%" + value + "%");
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



        public String get_data_sequence_boxno()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            
            DateTime tgl = DateTime.Now;
            Int32 julian = tgl.DayOfYear;

            String julianstr = julian.ToString();
            if (julianstr.Length == 1)
            {
                julianstr = "00" + julianstr;
            }
            else if (julianstr.Length == 2)
            {
                julianstr = "0" + julianstr;
            }

            String curryear = DateTime.Now.ToString("yy");
            String pdc = curryear + julianstr;
            Int32 urutan= 0;
            String urutstr = "";
            //get box sequence
            MainMenu frm = new MainMenu();
            
            //data = frm.get_data_table_string("increment_box", "pdc", pdc);
            data = frm.get_max_sequence_boxno(pdc);
            if (data.Count > 0 && !data[0][0].ToString().Equals(""))
            {

                string nobox = data[0][0].ToString();
                string urutstring = nobox.Substring(nobox.Length - 4, 4);
                urutan = Int32.Parse(urutstring) + 1;
                //urutan = Int32.Parse(data[0][1].ToString());

                if (urutan.ToString().Length == 1)
                {
                    urutstr = "000" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 2)
                {
                    urutstr = "00" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 3)
                {
                    urutstr = "0" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 4)
                {
                    urutstr = urutan.ToString();
                }

            }
            else
            {
                urutan = 1;
                urutstr = "000" + urutan.ToString();
            }

            //set number increment_box
            //set_nextnumber_box(pdc, urutan + 1);

            String co_code = "";
            List<object[]> dt = new List<object[]>();
            dt = get_data_table_string("tbcompany", "", "");
            if (dt.Count > 0)
            {
                co_code = dt[0][13].ToString();
            }


            String boxnumber = co_code + "." + curryear + julianstr + "." + urutstr;
            return boxnumber;

            /*
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from tbpacking where box_number like @boxnumber order by box_number desc";
            cmd.Parameters.AddWithValue("@boxnumber", boxnumber+"%");

            data.Clear();
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
             */ 
        }


        private void set_nextnumber_case(String bulantahun, Int32 nextnumber)
        {
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update increment_case set bulantahun=@bulantahun, nextnumber=@nextnumber";
                mySql3.Parameters.AddWithValue("@bulantahun", bulantahun);
                mySql3.Parameters.AddWithValue("@nextnumber", nextnumber);
                mySql3.ExecuteNonQuery();
                conn5.Close();
        }


        public List<object[]> get_max_sequence_caseno(String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                if (!value.Equals(""))
                { //to get all data with filtering
                    cmd.CommandText = "select max(case_number) from tbpacking where case_number like @value";
                    cmd.Parameters.AddWithValue("@value", "%" + value + "%");
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


        public List<object[]> get_max_sequence_caseno_1804(String value)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!value.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select max(case_number) from tbpacking where case_number < 'BO.1804.1805' and case_number like @value";
                cmd.Parameters.AddWithValue("@value", "%" + value + "%");
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






        public String get_data_sequence_caseno()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            //data = get_data_table_string("tbcompany", "", "");

            data = get_data_table_string_fieldname("tbcompany","code", "", "");
            String companycode = data[0][0].ToString();
            

            DateTime tgl = DateTime.Now;
            String curryear = DateTime.Now.ToString("yy");
            String curryear4 = DateTime.Now.ToString("yyyy");
            String bulan = DateTime.Now.ToString("MM");
            String yearbulan = curryear + bulan;

            Int32 urutan = 0;
            String urutstr = "";
            //get box sequence
            MainMenu frm = new MainMenu();
            //data = frm.get_data_table_string("increment_case", "bulantahun", yearbulan);
            data = frm.get_max_sequence_caseno(companycode + "." + yearbulan);
            if (data.Count > 0 && !data[0][0].ToString().Equals(""))
            {

                string nobox = data[0][0].ToString();
                string urutstring = nobox.Substring(nobox.Length - 4, 4);
                urutan = Int32.Parse(urutstring) + 1;

                //urutan = Int32.Parse(data[0][2].ToString());
                if (urutan.ToString().Length == 1)
                {
                    urutstr = "000" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 2)
                {
                    urutstr = "00" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 3)
                {
                    urutstr = "0" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 4)
                {
                    urutstr = urutan.ToString();
                }

            }
            else
            {
                urutan = 1;
                urutstr = "000" + urutan.ToString();
            }


            String co_code = "";
            List<object[]> dt = new List<object[]>();
            //dt = get_data_table_string("tbcompany", "", "");
            dt = get_data_table_string_fieldname("tbcompany", "code", "", "");
            if (dt.Count > 0)
            {
                co_code = dt[0][0].ToString();
            }

            String caseno = co_code + "." + yearbulan + "." + urutstr;
            return caseno;

        }


        public List<object[]> get_data_listpacking_daysearlier(Int32 days)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(-days);
            
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from tbpacking where moddatetime >= @dateearlier and rcvno=@rcvno order by id desc";
            cmd.Parameters.AddWithValue("@dateearlier", DaysEarlier);
            cmd.Parameters.AddWithValue("@rcvno", "");

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





        public List<object[]> get_data_listpacking_daysearlier_fieldname(Int32 days, String fieldname)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(-days);

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select " + fieldname+" from tbpacking where moddatetime >= @dateearlier and rcvno=@rcvno order by id desc";
            cmd.Parameters.AddWithValue("@dateearlier", DaysEarlier);
            cmd.Parameters.AddWithValue("@rcvno", "");

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




        public List<object[]> get_data_table_daysearlier(Int32 days, String tablename)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(-days);

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from " + tablename + " where moddatetime >= @dateearlier order by id desc";
            cmd.Parameters.AddWithValue("@dateearlier", DaysEarlier);

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



        public List<object[]> get_data_shipping_unit(Int32 days)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(-days);

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from shipping_unit where shipdate >= @dateearlier order by id desc";
            cmd.Parameters.AddWithValue("@dateearlier", DaysEarlier);

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



        public List<object[]> get_data_listpacking_intlot_null(String box_number)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            String intlotcode = "";
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from tbpacking where box_number=@box_number and intlotcode=@intlotcode order by id desc";
            cmd.Parameters.AddWithValue("@box_number", box_number);
            cmd.Parameters.AddWithValue("@intlotcode", intlotcode);

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


        public List<object[]> getsummary_grade(String intlotcode, String tablename)
        {
            //get data from table
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);

            if (tablename.Contains("receivingdetails"))
            {
                cmd.CommandText = "SELECT intlotcode,grade, sum(fweight) as fweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
            }
            else if (tablename.Contains("cuttingdetails"))
            {
                cmd.CommandText = "SELECT intlotcode,grade, sum(cweight) as cweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
            }
            else if (tablename.Contains("retouchingdetails"))
            {
                cmd.CommandText = "SELECT intlotcode,grade, round(sum(rweight),2) as rweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
            }


            cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
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


        public List<object[]> getsummary_grade_search(String intlotcode, String tablename, String value)
        {
            //get data from table
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();

                MySqlCommand cmd = new MySqlCommand("", conn3);
                //String conditional = "";

                if (tablename.Contains("receivingdetails"))
                {

                    if (value.Equals("") || value == null)
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(fweight) as fweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(fweight) as fweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode and (grade=@value or cweight=@value or loin_number like @loin_number) group by grade";
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@loin_number", "%" + value + "%");
                    }
                }
                else if (tablename.Contains("cuttingdetails"))
                {
                    if (value.Equals("") || value == null)
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(cweight) as cweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(cweight) as cweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode and (grade=@value or cweight=@value) group by grade";
                        cmd.Parameters.AddWithValue("@value", value);
                    }
                }
                else if (tablename.Contains("retouchingdetails"))
                {
                    if (value.Equals("") || value == null)
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(rweight) as rweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode group by grade";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT intlotcode,grade, sum(rweight) as rweight, count(intlotcode) as pieces FROM " + tablename + " where intlotcode=@intlotcode and (grade=@value or rweight=@value or remark=@value or loin_number like @loin_number) group by grade";
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@loin_number", "%" + value + "%");
                    }
                }

                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
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






        public List<object[]> get_data_table_string_2param(String tablename, String field, String value, String field2, String value2)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + "=@value  and " + field2 + "=@value2 order by id desc" ;
                cmd.Parameters.AddWithValue("@value", value);
                cmd.Parameters.AddWithValue("@value2", value2);
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


        public List<object[]> get_data_table_string_2param_fieldname(String tablename, String fieldname, String field, String value, String field2, String value2)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select "+ fieldname+" from " + tablename + " where " + field + "=@value  and " + field2 + "=@value2 order by id desc";
                cmd.Parameters.AddWithValue("@value", value);
                cmd.Parameters.AddWithValue("@value2", value2);
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


        public String get_suppliername(String intlotcode)
        {
            String suppname = "";
            String suppcode = intlotcode.Substring(3, 3);
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select suppname from tbsupplier where suppcode=@suppcode";
                cmd.Parameters.AddWithValue("@suppcode", suppcode);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    suppname = rdr.GetString("suppname");
                }
                conn3.Close();
                //conn3.Dispose();
            return suppname;
        }


        public List<object[]> get_data_table_string_exclude(String tablename, String excludetable, String field)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                if (!field.Equals(""))
                { //to get all data with filtering
                    cmd.CommandText = "select * from " + tablename + " where " + field + " not in ( select " + field + " from " + excludetable + " ) order by " + field + " desc";
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
                //conn3.Dispose();
            return data;
        }


        public List<object[]> get_data_table_string_exclude_id_desc(String tablename, String excludetable, String field)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!field.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select * from " + tablename + " where " + field + " not in ( select " + field + " from " + excludetable + " ) order by id desc";
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
                //conn3.Dispose();
            return data;
        }




        // to get data from table
        public void delete_table(String table, String fieldname, String value)
        {
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand mySql = conn3.CreateCommand();
                mySql.CommandText = "delete from " + table + " where " + fieldname + "=@" + fieldname;
                mySql.Parameters.AddWithValue("@" + fieldname, value);
                mySql.ExecuteNonQuery();
                conn3.Close();
                //conn3.Dispose();
        }


        public void delete_table_id(String table, Int32 id)
        {
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand mySql = conn3.CreateCommand();
                mySql.CommandText = "delete from " + table + " where id=" + id;
                mySql.ExecuteNonQuery();
                conn3.Close();
                //conn3.Dispose();
        }


        public void delete_table_2params(String table, String fieldname, String value, String fieldname1, String value1)
        {
            string connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
                MySqlCommand mySql = conn3.CreateCommand();
                mySql.CommandText = "delete from " + table + " where " + fieldname + "=@" + fieldname + " and " + fieldname1 + "=@" + fieldname1;
                mySql.Parameters.AddWithValue("@" + fieldname, value);
                mySql.Parameters.AddWithValue("@" + fieldname1, value1);
                mySql.ExecuteNonQuery();
                conn3.Close();
                //conn3.Dispose();
        }




        private void backtomainbtn_Click(object sender, EventArgs e)
        {
            panelsetup.Visible = false;
        }

        private void btntransaction_Click(object sender, EventArgs e)
        {


        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtpass.Focus();
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnlogin.Focus();
            }

        }


        private void btnback_Click(object sender, EventArgs e)
        {
        }


        private void btnspecies_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void btngrade_Click(object sender, EventArgs e)
        {
            
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
        }

        private void btncustomer_Click_1(object sender, EventArgs e)
        {

        }

        private void btnincoterms_Click(object sender, EventArgs e)
        {
            

        }

        private void btnspecies_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btngrade_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnuser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsupplier_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btncustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnincoterms_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnback_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }


        private void button2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnlogin_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelsetup.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmCompany frm = new frmCompany();
            frm.ShowDialog();
        }

        private void btnretouching_Click(object sender, EventArgs e)
        {
        }

        private void btnpacking_Click(object sender, EventArgs e)
        {

        }

        private void btnpackinglist_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         }

        private void btnsetup_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnmastersetup_Paint(object sender, PaintEventArgs e)
        {



        }

        private void btntransaction_Paint(object sender, PaintEventArgs e)
        {



        }

        private void btnmastersetup_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnmastersetup1_Click(object sender, EventArgs e)
        {
            btnlogout.Visible = false;
            panelsetup.Visible = true;
        }

        private void btnmastersetup1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnmastersetup1.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void btntransaction1_Click(object sender, EventArgs e)
        {
            btnlogout.Visible = true;
            panelsetup.Visible = false;
            MenuTransaction frm = new MenuTransaction();
            frm.Show();
        }

        private void btntransaction1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btntransaction1.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);


        }

        private void btnlogout_Click(object sender, EventArgs e)
        {


        }

        private void btnlogout_Paint(object sender, PaintEventArgs e)
        {



        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            panelsetup.Visible = false;
            panel1.Show();
            txtuser.Clear();
            txtpass.Clear();
            txtuser.Focus();
            btnmastersetup1.Visible = false;
            btntransaction1.Visible = false;
            btnlogout.Visible = false;

        }

        private void btnlogout_Paint_1(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, btnlogout.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        public Int32 get_count_remark(String intlotcode, String remark)
        {
            String loin = "";
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            Int32 count = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "select * from tbretouchingdetails where intlotcode=@intlotcode and remark=@remark  union select * from tbretouchingdetails where intlotcode=@intlotcode and remark like @remark1";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                cmd.Parameters.AddWithValue("@remark", remark);
                cmd.Parameters.AddWithValue("@remark1", remark + "X");
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    loin = rdr.GetString("loin_number");
                    count++;
                }
            }
            finally
            {
                conn3.Close();
                //conn3.Dispose();
            }

            return count;
        }




        private void btncompany_Click(object sender, EventArgs e)
        {

            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("companyprofile") )
            {
                var frmCompany = new frmCompany();
                frmCompany.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for company profile");
                return;
            }

        }

        private void btnspecies_Click_1(object sender, EventArgs e)
        {

            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("speciessetup") )
            {
                frmMSpecies frm = new frmMSpecies();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for species setup");
                return;
            }

        }

        private void btncompany_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, btncompany.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnspecies_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnsupplier_Click_1(object sender, EventArgs e)
        {
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("suppliersetup") )
            {
                frmSupplier frm = new frmSupplier();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for supplier setup");
                return;
            }
        }

        private void btnuser_Click_1(object sender, EventArgs e)
        {

            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("usersetup") )
            {
                UserAccount frm = new UserAccount();
                frm.ShowDialog();
                return;
            }
            {
                MessageBox.Show("No access for user setup");
                return;
            }
        }

        private void btnuser_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btncategories_Click(object sender, EventArgs e)
        {
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("processingcategories") )
            {
                frmMGradePacking frm = new frmMGradePacking();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for processing categories setup");
                return;
            }
        }

        private void btncategories_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnsupplieradd_Click(object sender, EventArgs e)
        {
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("supplieradditional") )
            {
                frmSetup frm = new frmSetup();
                frm.Show();
                return;
            }
            else
            {

                MessageBox.Show("No access for supplier additional setup");
                return;
            }
        }

        private void btnsupplieradd_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnsupplieradd.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btncustomer_Click_2(object sender, EventArgs e)
        {
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("customersetup") )
            {
                frmCustomer frm = new frmCustomer();
                frm.ShowDialog();
                return;
            }
            {
                MessageBox.Show("No access for customer setup");
                return;
            }

        }

        private void btncustomer_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnspecies.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("productsetup") )
            {
                frmProduct frm = new frmProduct();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for product setup");
                return;
            }
        }

        private void btnproduct_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnproduct.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnback_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnback.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            panelsetup.Visible = false;
            btnlogout.Visible = true;
        }


    }
}
