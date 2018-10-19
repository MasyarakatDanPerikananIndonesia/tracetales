using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace Tallyfish
{

    public partial class frmRetouching : Form
    {
        static bool _continue;
        static bool except = false;
        static bool lock_weight = false;
        static bool scale_on = false;
        public String isrs = "";

        public static String loin_code_global;
        public static String modeinput;
        public static Boolean printstatus=true;

        public frmRetouching()
        {
            InitializeComponent();
        }


        private void button7_Click(object sender, EventArgs e)
        {


        }

        public void setInitialValue(String tipe, String species, String intlotcode, String supplier, String productname)
        {
            lblType.Text = tipe.ToString();
            lblSpecies.Text = species.ToString();
            lblInternalcode.Text = intlotcode.ToString();
            lblsupplier.Text = supplier.ToString();
            lblrtcno.Text = "RT-" + intlotcode.ToString();
            DateTime dt = DateTime.Now;
            lblrtcdate.Text = dt.ToString("yyyy-MM-dd hh:mm:ss");
            lblproductname.Text = productname;

            //operator
            lbloperator.Text = Properties.Settings.Default.username;
        }


        public void loaddatartcdet()
        {
            //set grade empty
            String intlotcode = lblInternalcode.Text.Trim();
            //get data from table
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();

            //data = frm.get_data_table_transaction("tbretouchingdetails", intlotcode, "id", "");
            data = frm.get_data_table_transaction_fieldname("tbretouchingdetails","loin_number,grade,rweight,remark" ,intlotcode, "id", "");



            //Type RM
            int no = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    no = data.Count-i;
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (no).ToString();
                    /*
                    dataGridView1.Rows[i].Cells[1].Value = data[i][8].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][5].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][6].ToString();
                     */
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][3].ToString();
                }
            }

            Edit_columnbutton();
            Delete_columnbutton();
            frm.Dispose();
        }


        public void loaddatartcdet_partial(Int32 limit)
        {
            //set grade empty
            String intlotcode = lblInternalcode.Text.Trim();
            //get data from table
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();

            data = frm.get_data_table_transaction_fieldname("tbretouchingdetails", "loin_number,grade,rweight,remark", intlotcode, "id", "");

            //Type RM
            int no = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();


            Int32 batas = 0;
            if (data.Count > 0)
            {
                if (data.Count > limit)
                {
                    batas = limit;
                }
                else
                {
                    batas = data.Count;
                }

                dataGridView1.Rows.Add(batas);
                for (int i = 0; i < batas; i++)
                {
                    no = data.Count - i;
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (no).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][3].ToString();
                }
            }

            Edit_columnbutton();
            Delete_columnbutton();
            frm.Dispose();
        }


        private void Edit_columnbutton(Bitmap image)
        {
                if (dataGridView1.Columns.Contains("Edit") == false)
                {
                    DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                    iconColumn.Image = image;
                    iconColumn.Name = "Edit";
                    iconColumn.HeaderText = "Edit";
                    dataGridView1.Columns.Insert(5, iconColumn);
                    iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    iconColumn.Width = 60;
                }
        }

        private void Delete_columnbutton(Bitmap image)
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Delete";
                iconColumn.HeaderText = "Del";
                dataGridView1.Columns.Insert(6, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 60;
            }

        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon_top("save", btnSimpan);
            frm.setbuttonicon("save", btnsaveedit);
            frm.setbuttonicon("cancel", btncancel);
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
            frm.setbuttonicon("scale", button3);
            frm.setbuttonicon("buttonselect", button2);
        }

        private void set_scale_picture()
        {
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\scale.png";
            pbscale.Image = Image.FromFile(icondir);

        }
   
        private void Edit_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Edit") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(5, btn);
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
                dataGridView1.Columns.Insert(6, btn);
                btn.HeaderText = "Del";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

/*
        private void Print_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Print") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(7, btn);
                btn.HeaderText = "Print";
                btn.Name = "Print";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }
*/


        private void frmRetouching_Load(object sender, EventArgs e)
        {

            lbl_locked.Visible = false;
            load_port_name();
            scale_on = false;

            seticon_forbutton();
            set_scale_picture();
            panelpad.Visible = false;
            //to display loin
            String txt = "";
            //Int32 xPos = 145;
            //Int32 xPos = 115;
            Int32 xPos = 95;
            Int32 yPos = 12;
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbgrade", "module", "retouching");

            frmRetouching fcut = new frmRetouching();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    txt = data[i][1].ToString();
                    //tombolgrade(77, 55, 16, xPos, yPos, txt, Color.WhiteSmoke);
                    tombolgrade(62, 55, 14, xPos, yPos, txt, Color.WhiteSmoke);
                    //xPos = xPos + 77;
                    xPos = xPos + 60;
                    //tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor);
                }
            }
            Edit_columnbutton();
            Delete_columnbutton();
            //Print_columnbutton();
            frm.setbuttonicon("search", btnsearch);
        }

        private void tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn.Width = width; // Width of button 
            btn.Height = height; // Height of button 
            btn.Font = new Font(btn.Font.FontFamily, fontsize);
            btn.Left = xPos;
            btn.Top = yPos;
            // Add buttons to a Panel: 
            button1.Controls.Add(btn); // Let panel hold the Buttons 
            btn.Text = txt.ToString();
            btn.BackColor = btncolor;
            btn.Name = "btngrade" + txt;
            btn.Click += new EventHandler(btngrade_Click);
        }


        void btngrade_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            Properties.Settings.Default.grade = current.Text;

            //grade = current.Text;

            foreach (Control item in button1.Controls.OfType<Button>())
            {
                if (item.Name == "btngrade" + Properties.Settings.Default.grade.ToString())
                {
                    item.BackColor = Color.Orange;
                    item.ForeColor = Color.White;
                }
                else if (item.Name.Contains("btngrade"))
                {
                    item.BackColor = Color.WhiteSmoke;
                    item.ForeColor = Color.Black;
                }
            }
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }

        private String sign_remark(String intlotcode, String remark)
        {
            MainMenu frm = new MainMenu();
            Int32 signed = frm.get_count_remark(intlotcode, remark);
            String doublechar = "";
            for (int i = 0; i < signed - 2; i++)
            {
                doublechar = doublechar + "X";
            }
            frm.Dispose();
            return doublechar;
            
        }


       private void save_retouchingdet()
        {
                
                String intlotcode = lblInternalcode.Text.Trim();
                String suppcode = intlotcode.Substring(3, 3);

                //lotnumber
                
                String loinnumber = loingeneration();
                String lotnumber = "L-" + loinnumber;

                
                /*
                 * Hilangkan validasi untuk kecepatam akses

                String remark1 = txtremark.Text.Trim() + sign_remark(intlotcode, txtremark.Text.Trim());
                remark1 = remark1.Trim();
                 */
                MainMenu frm = new MainMenu();
                String remark1 = txtremark.Text.Trim();

                DateTime dt = DateTime.Now;
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into tbretouchingdetails(intlotcode,rtcdate, tipe, grade, rweight, remark, username, moddatetime, lotnumber, loin_number,suppcode)" +
                            " values(@intlotcode,@rtcdate, @tipe, @grade, @rweight, @remark, @username, @moddatetime, @lotnumber, @loin_number,@suppcode)";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@rtcdate", DateTime.Parse(dt.ToString("yyyy-MM-dd hh:mm:ss")));
                    mySql3.Parameters.AddWithValue("@tipe", lblType.Text.Trim());
                    mySql3.Parameters.AddWithValue("@grade", Properties.Settings.Default.grade + isrs.Trim());
                    double cweight = 0;
                    cweight = double.Parse(txtweight.Text);
                    mySql3.Parameters.AddWithValue("@rweight", cweight);
                    mySql3.Parameters.AddWithValue("@remark", remark1);

                    String username;
                    username = Properties.Settings.Default.username;
                    mySql3.Parameters.AddWithValue("@username", username);
                    mySql3.Parameters.AddWithValue("@lotnumber", lotnumber);
                    mySql3.Parameters.AddWithValue("@loin_number", loinnumber);
                    mySql3.Parameters.AddWithValue("@suppcode", suppcode);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                    Properties.Settings.Default.rweight = cweight;
                    Properties.Settings.Default.remark = txtremark.Text.Trim();
                    loin_code_global = loinnumber;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                finally
                {
                    conn5.Close();
                }
        }


        public static string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }


        private void set_nextnumber_loin(String pdc, Int32 nextnumber)
        {
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update increment_loin set pdc=@pdc, nextnumber=@nextnumber";
                mySql3.Parameters.AddWithValue("@pdc", pdc);
                mySql3.Parameters.AddWithValue("@nextnumber", nextnumber);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            finally
            {
                conn5.Close();
                
            }
        }




        public String loingeneration()
        {
            String loin = "";

            DateTime tgl = DateTime.Now;
            int julian = tgl.DayOfYear;

            String julianstr = julian.ToString();

            if (julianstr.Length == 1)
            {
                julianstr = "00" + julianstr;
            }
            else if (julianstr.Length == 2)
            {
                julianstr = "0" + julianstr;
            }


            String juliancode = julianstr;

            String curryear = DateTime.Now.ToString("yy");
            String pdc = curryear + juliancode;




            MainMenu frm = new MainMenu();
            List<object[]> data= new List<object[]>();
            
            //get intlotcode the first row
            //data=frm.get_data_sequence_loin("tbretouchingdetails", "loin_number", pdc);

            //data = frm.get_data_table_string("increment_loin", "pdc", pdc);
            data = frm.get_max_sequence_loin(pdc);

            Int32 urutan = 0;
            String urutanstr = "";
            //String maxstring = "";
            String maxstring = data[0][0].ToString();
            if (data.Count > 0 && !maxstring.Equals(""))
            {
                /*
                String loinnumberexist = data[0][8].ToString();
                String fourchar = Right(loinnumberexist, 5);
                urutan = Int32.Parse(fourchar);
                urutan = urutan + 1;
                */

                maxstring = data[0][0].ToString();
                string rightnumber = maxstring.Substring(maxstring.Length - 5, 5);

                urutan = Int32.Parse(rightnumber) + 1;
                
                //urutan = Int32.Parse(data[0][1].ToString());

                if ( urutan.ToString().Length == 1)
                {
                    urutanstr = "0000" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 2)
                {
                    urutanstr = "000" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 3)
                {
                    urutanstr = "00" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 4)
                {
                    urutanstr = "0" + urutan.ToString();
                }
                else if (urutan.ToString().Length == 5)
                {
                    urutanstr = urutan.ToString();
                }
            }
            else
            {
                urutan = 1;
                urutanstr = "0000" + urutan.ToString();
            }
            //set next number for loin number
            //set_nextnumber_loin(pdc, urutan + 1);


            String compcode = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                compcode = data[0][13].ToString();
            }

            loin = compcode+"." +curryear+juliancode + "." + urutanstr;
            return loin;
        }



        private void valueclear()
        {
            txtweight.Text="0.00";
            //txtremark.Text=txtremark.Text.Substring(0, 2);
            txtremark.Text = "";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.grade == null || Properties.Settings.Default.grade.Equals(""))
            {
                MessageBox.Show(" Please Entry Grade");
                return; //to stop process

            }
            if (txtremark.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Please Entry Remark");
                txtremark.Focus();
                return; //to stop process

            }
            
            if (txtweight.Text.Equals("") || double.Parse(txtweight.Text)== 0)
            {
                MessageBox.Show(" Please Entry Weight");
                txtweight.Focus();
                return; //to stop process
            }
            

            String intlotcode=lblInternalcode.Text;
            String remark=txtremark.Text;
            Boolean validsimpan = true;

            

            /* hilangkan validasi untuk kecepatan
            remark = remark.Replace("X", "");

            if (Properties.Settings.Default.grade.Contains('A'))
            {
                if (remark_double(intlotcode, remark) >= 2)
                {
                    DialogResult dialogResult = MessageBox.Show(" No Ikan dan no urut " + remark + " terdeteksi sudah diinput sama dengan sebelumnya, apakah Remark ini akan lanjut disimpan? Remark otomatis diset dengan karakter X", "Pesan Kesalahan " + remark, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        validsimpan = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        validsimpan = false;
                    }
                }
            }
             */

            if (validsimpan == true)
            {

                save_retouchingdet();
                loaddatartcdet_partial(10);
                loaddatasummary();
                panelpad.Visible = false;
                //generateqrlabel();
                valueclear();
                 
            }
            //btnoff_Click(sender, e);
            //panelpad.Visible = false;

            lock_weight = false;
            lbl_locked.Visible = false;
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnSimpan.Focus();
            }
        }

/*
        private void generateqrlabel()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;

            string intlotcode = lblInternalcode.Text;

            String asfis = "";
            String suprec = "";
            String[] suppcode ;
            String suppliercode ="";
            String cert = "";
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            //data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);

            data = frm.get_data_table_string_fieldname("tbreceiving","species,supplier,certificate", "intlotcode", intlotcode);

            if(data.Count>0)
            {
                asfis = data[0][0].ToString();
                suprec = data[0][1].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
                cert = data[0][2].ToString();
 
            }

            String origin = "";
            String fishing_ground = "";
            
            String certcode = "";
            
            //data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);

            data = frm.get_data_table_string_fieldname("tbsupplier","countryorigin,fishingground,certificatecode", "suppcode", suppliercode);

            if (data.Count > 0)
            {
                origin = data[0][0].ToString();
                fishing_ground = data[0][1].ToString();
                certcode = data[0][2].ToString();

            }
            
            String loincode = loin_code_global;
            String grade = Properties.Settings.Default.grade;
            double rweight = Properties.Settings.Default.rweight;

            //Properties.Settings.Default.remark = txtremark.Text.Trim() + sign_remark(intlotcode, txtremark.Text.Trim());

            Properties.Settings.Default.remark = txtremark.Text.Trim();

            String remark = Properties.Settings.Default.remark;

            String qrtext = loincode + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\n" + remark + "\r\n";


            var result = new Bitmap(qr.Write(qrtext));
            pbLabel.Image = result;
            printlabel();

        }
*/


/*
        private void reprint_qrlabel(String loin_number)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;


            String intlotcode = "";
            String grade = "";
            Double rweight = 0;
            String remark = "";


            List<object[]> dtretouching = new List<object[]>();
            MainMenu frm = new MainMenu();
            //dtretouching = frm.get_data_table_string("tbretouchingdetails", "loin_number", loin_number);
            dtretouching = frm.get_data_table_string_fieldname("tbretouchingdetails", "intlotcode,grade,rweight,remark","loin_number", loin_number);

            if (dtretouching.Count > 0)
            {
                intlotcode = dtretouching[0][0].ToString();
                grade = dtretouching[0][1].ToString();
                rweight = double.Parse(dtretouching[0][2].ToString());
                remark = dtretouching[0][3].ToString();

                Properties.Settings.Default.grade= grade;
                Properties.Settings.Default.rweight = rweight;
                Properties.Settings.Default.remark=remark;

            }

            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";
            String cert = "";
            List<object[]> data = new List<object[]>();

            //data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            data = frm.get_data_table_string_fieldname("tbreceiving","species,supplier,certificate", "intlotcode", intlotcode);

            if (data.Count > 0)
            {
                asfis = data[0][0].ToString();
                suprec = data[0][1].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
                cert = data[0][2].ToString();
            }

            String origin = "";
            String fishing_ground = "";
            String certcode = "";

            //data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            data = frm.get_data_table_string_fieldname("tbsupplier","countryorigin,fishingground,certificatecode", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                origin = data[0][0].ToString();
                fishing_ground = data[0][1].ToString();
                certcode = data[0][2].ToString();

            }

            String qrtext = loin_number + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\n" + remark + "\r\n";
            
            //to put loin code in label
            loin_code_global = loin_number;


            var result = new Bitmap(qr.Write(qrtext));
            pbLabel.Image = result;
            printlabel();
        }
*/


        public List<object[]> get_dataretouching(String intlotcode, double rweight, string remark)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            if (!remark.Equals(""))
            { //to get all data with filtering
                cmd.CommandText = "select loin_number from tbretouchingdetails where intlotcode=@intlotcode and rweight=@rweight and remark=@remark order by id desc";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                cmd.Parameters.AddWithValue("@rweight", rweight);
                cmd.Parameters.AddWithValue("@remark", remark);
            }
            else
            { // to get all data without filtering
                cmd.CommandText = "select loin_number from tbretouchingdetails where intlotcode=@intlotcode and rweight=@rweight order by id desc";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                cmd.Parameters.AddWithValue("@rweight", rweight);
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


        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            this.pbLabel.Width = 100;
            this.pbLabel.Height = 100;

            Bitmap bmp = new Bitmap(this.pbLabel.Width, this.pbLabel.Height);
            this.pbLabel.DrawToBitmap(bmp, new Rectangle(0, 0, this.pbLabel.Width, this.pbLabel.Height));
            // e.Graphics.DrawImage((Image)bmp, x, y);
            e.Graphics.DrawImage((Image)bmp, 30, 45);
            string intlotcode = lblInternalcode.Text.Trim();


            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";
            String cert = "";
            DateTime cutdate = DateTime.Parse("1900-1-1");
            String cutdatestr = cutdate.ToString("yyyy-MM-dd");
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            //data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);

            data = frm.get_data_table_string_fieldname("tbreceiving","species,supplier,certificate, rcvdate", "intlotcode", intlotcode);

            if (data.Count > 0)
            {
                asfis = data[0][0].ToString();
                suprec = data[0][1].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
                cert = data[0][2].ToString();

                cutdate = DateTime.Parse(data[0][3].ToString());
                cutdatestr = cutdate.ToString("yyyy-MM-dd");
             }



            String origin = "";
            String fishing_ground = "";
            
            String certcode = "";

            //data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            data = frm.get_data_table_string_fieldname("tbsupplier","countryorigin,fishingground,certificatecode", "suppcode", suppliercode);
            if (data.Count > 0)
            {

                origin = data[0][0].ToString();
                fishing_ground = data[0][1].ToString();
                certcode = data[0][2].ToString();

            }

            String loincode = loin_code_global;
            String grade = Properties.Settings.Default.grade;
            double rweight = Properties.Settings.Default.rweight;
            String remark = Properties.Settings.Default.remark;
           
            //data = frm.get_data_table_string("tbcuttingdetails", "intlotcode", intlotcode);
            data = frm.get_data_table_string_fieldname("tbcuttingdetails", "cutdate","intlotcode", intlotcode);
            if (data.Count > 0)
            {
                 //cutdate = DateTime.Parse(data[0][2].ToString());
                 cutdate = DateTime.Parse(data[0][0].ToString());
                 cutdatestr = cutdate.ToString("yyyy-MM-dd");
            }
            
            //Get Grup Size Retouching
            String grupsize = "";
            data = frm.get_grupsize_loin(rweight);
            if (data.Count > 0)
            {
                grupsize = data[0][0].ToString();
            }

            //Certificate FT enabled/disabled
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();

            String packing="";
            data = frm.get_data_table_string_fieldname("tbpackingsize", "packingsize", "excludedft", "1");
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    packing = data[i][0].ToString().Trim();

                    if (packing.Equals(grupsize))
                    {
                        cert = "";
                    }
                }
            }
            
           
            String productname = "";

            //data = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            data = frm.get_data_table_string_fieldname("tbretouching","productname", "intlotcode", intlotcode);

            if (data.Count > 0)
            {
                productname = data[0][0].ToString();
            }

            //e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 30, 155);
            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);
            String textfrozen = "Keep Frozen -18\u00b0C";
            e.Graphics.DrawString(textfrozen, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 160);

            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 35, 10);
            e.Graphics.DrawString(grupsize, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 35, 35);

            String datalabel;
            datalabel = "Species";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 20);
            datalabel = asfis;
            e.Graphics.DrawString(datalabel, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 150, 35);

            datalabel = "Grade";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 215, 20);

            datalabel = grade;
            e.Graphics.DrawString(datalabel, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 215, 35);

            datalabel = "Weight (Kg)";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 297, 20);
            datalabel = rweight.ToString();
            e.Graphics.DrawString(datalabel, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 297, 35);


            //e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 140, 60);

            datalabel = "Internal Lot Code";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 148, 60);
            
            datalabel = intlotcode ;
            e.Graphics.DrawString(datalabel, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, 145, 75);

            datalabel = "Remark";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 316, 60);

            datalabel = remark;
            e.Graphics.DrawString(datalabel, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, 315, 75);

            datalabel = "Origin";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 100);

            datalabel = origin;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 115);

            datalabel = "Fishing Ground";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 215, 100);

            datalabel = fishing_ground;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 220, 115);

            datalabel = "Processing Date: " + cutdatestr;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 130);

            if (!cert.Equals("") && !certcode.Equals(""))
            {
                datalabel = cert+" Code: " + certcode;
                e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 145);
            }
            e.Graphics.DrawString(cert, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 60, 160);
            e.Graphics.DrawString(productname, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 175); 
        }


/*
        private void printlabel()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.PaperSize = new PaperSize("100 x 50 mm", 393, 196);


            if (printstatus)
            {
                doc.Print();
                doc.Dispose();
            }
            else
            {
                
                PrintPreviewDialog pd = new PrintPreviewDialog();
                pd.Document = doc;
                pd.ShowDialog();           
                
            }



        }
*/

        private Int32 remark_double(String intlotcode, String remark)
        {
            remark = remark.Replace("X", "");
            String doublechar = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param_fieldname("tbretouchingdetails","id","intlotcode", intlotcode, "remark", remark);
            return data.Count;
        }


        private Boolean valid_amend(String loin)
        {
            Boolean valid = true;
            return valid;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                String loin = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (!valid_amend(loin))
                {
                    MessageBox.Show("Data " + loin + " tidak valid di delete karena sudah lewat hari dari tanggal entry data");
                    return;
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("Anda yakin menghapus Loin " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Hapus", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        String userlog = "";
                        MainMenu frm = new MainMenu();
                        List<object[]> data = new List<object[]>();
                        data = frm.get_data_table_string("tbreceiving", "intlotcode", lblInternalcode.Text.Trim());
                        if (data.Count > 0)
                        {
                            userlog = data[0][11].ToString();
                        }

                        String username = Properties.Settings.Default.username;
                        String newuserlog = DateTime.Now.ToString() + "," + username + " delete " + loin;
                        userlog = userlog + "\r\n" + newuserlog;

                        //frm.delete_table("tbretouchingdetails", "loin_number", loin);

                        String connString = Konek();
                        MySqlConnection conn5 = new MySqlConnection(connString);
                        conn5.Open();
                        try
                        {
                            MySqlCommand mySql3 = conn5.CreateCommand();
                            mySql3.CommandText = "update tbreceiving  set userlog=@userlog, moddatetime=@moddatetime where intlotcode=@intlotcode";
                            mySql3.Parameters.AddWithValue("@userlog", userlog);
                            mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                            mySql3.Parameters.AddWithValue("@intlotcode", lblInternalcode.Text.Trim());
                            mySql3.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn5.Close();
                            
                        }

                        connString = Konek();
                        conn5 = new MySqlConnection(connString);
                        conn5.Open();
                        try
                        {
                            MySqlCommand mySql3 = conn5.CreateCommand();
                            mySql3.CommandText = "update tbretouchingdetails  set intlotcode=@intlotcode,tipe=@tipe, grade=@grade,rweight=@rweight,remark=@remark, lotnumber=@lotnumber, loin_number=@loin_number,suppcode=@suppcode, moddatetime=@moddatetime where loin_number=@loin_number1";
                            mySql3.Parameters.AddWithValue("@tipe", "");
                            mySql3.Parameters.AddWithValue("@grade", "");
                            mySql3.Parameters.AddWithValue("@rweight", 0);
                            mySql3.Parameters.AddWithValue("@remark", "");
                            mySql3.Parameters.AddWithValue("@lotnumber", "");
                            mySql3.Parameters.AddWithValue("@loin_number", "");
                            mySql3.Parameters.AddWithValue("@suppcode", "");
                            mySql3.Parameters.AddWithValue("@intlotcode", "4del");
                            mySql3.Parameters.AddWithValue("@loin_number1", loin);
                            mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                            mySql3.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn5.Close();
                            
                        }

                        loaddatartcdet();
                    }
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {

                    String loin = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    panel1.Visible = true;
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    String intlotcode = lblInternalcode.Text.Trim();
                    MainMenu frm = new MainMenu();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_transaction("tbretouchingdetails", intlotcode, "moddatetime", "");
                    for (int i = 0; i <= n; i++)
                    {
                        if (i == n)
                        {
                            id = Int32.Parse(data[i][0].ToString());
                        }
                    }

                    lblid.Text = id.ToString();
                    txtgrade.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                    if (!valid_amend(loin))
                    {
                        txtweightedit.Enabled = false;
                    }
                    else
                    {
                        txtweightedit.Enabled = true;
                    }

                    txtweightedit.Text = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtremark1.Text = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    lblloin.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               
            }


/*
            if (e.ColumnIndex == dataGridView1.Columns["Print"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
               
                    String loin_number = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    loin_number = loin_number.Trim();
                    //reprint_qrlabel(loin_number);
            }
 */ 
        }

        private void load_port_name()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbportname.Items.Add(port);
                cbportname.Text = port;
            }
        }


        private void turn_on_icon()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("on", btnon);
            frm.setbuttonicon("off", btnoff);
        }

        private void turn_off_icon()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("off", btnoff);
            frm.setbuttonicon("off", btnon);
        }


        private void btnon_Click(object sender, EventArgs e)
        {
            
            if (cbportname.Text.Equals(""))
            {
                MessageBox.Show("Sorry, systems doesn't detect COM port available. Please check if scale cable has connected to USB port");
                return;
            }


            turn_off_icon();
            btnoff.ForeColor = Color.WhiteSmoke;
            btnon.ForeColor = Color.LawnGreen;
            txtweight.Text = "0.00";
            panelpad.Visible = false;
            if (!scale_on)
            {
                turn_on_icon();
                scale_on = true;
                _continue = true;
                set_configuration();
                Connect();
                read_indicator();
            }
        }

        private void btnoff_Click(object sender, EventArgs e)
        {
            turn_off_icon();
            btnoff.ForeColor = Color.Red;
            btnon.ForeColor = Color.WhiteSmoke;
            txtweight.Text = "0.00";
            panelpad.Visible = true;
            modeinput = "weight";
            if (scale_on)
            {
                Thread.Sleep(500);
                scale_on = false;
                lblconnect.Visible = false;
                lbl_locked.Visible = false;
                stop_thread();
            }
        }


        private void stop_thread()
        {
            try
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                    thread.Join();
                    thread = null;
                }

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                _continue = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void set_configuration()
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = Int32.Parse(txtbaudrate.Text);
                serialPort1.DataBits = Int32.Parse(txtdatabits.Text);
                try
                {
                    serialPort1.PortName = cbportname.Text.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    except = true;
                    return;
                }

                if (cbparity.Text.Contains("None"))
                {
                    serialPort1.Parity = Parity.None;
                }
                else if (cbparity.Text.Contains("Odd"))
                {
                    serialPort1.Parity = Parity.Odd;
                }
                else if (cbparity.Text.Contains("Even"))
                {
                    serialPort1.Parity = Parity.Even;
                }
                else if (cbparity.Text.Contains("Mark"))
                {
                    serialPort1.Parity = Parity.Mark;
                }
                else if (cbparity.Text.Contains("Space"))
                {
                    serialPort1.Parity = Parity.Space;
                }
            }
        }

        public void Connect()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    lblconnect.Visible = true;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: Connection is in use or is not available: \n\n" + e1);
            }
        }

        private void disconnect()
        {
            // to handle if connection serial port is closed
            if (!serialPort1.IsOpen)
            {
                if (thread.IsAlive)
                {
                    Thread.Sleep(1000);
                    scale_on = false;
                    _continue = false;
                    threadStop.Set();
                    thread.Abort();
                    thread.Join();
                    thread = null;
                    return;
                }
            }
        }

        private Thread thread;

        delegate void UpdatetxtStreamingFromThreadDelegate(String msg);

        protected ManualResetEvent threadStop = new ManualResetEvent(false);

        private void bacaData()
        {
            while (_continue )
            {
                try
                {

                    if (serialPort1.IsOpen)
                    {
                        String message ="";
                        if (serialPort1.BytesToRead > 0)
                        {
                            message = serialPort1.ReadLine().ToString();
                        }

                        //message = serialPort1.ReadLine().ToString();
                        String data_serialport;
                        if (!message.Equals(""))
                        {
                            data_serialport = RemoveExtraText(message);
                            UpdatetxtStreamingFromThread(data_serialport);
                            //to stop thread
                        }
                    }


                    if (threadStop.WaitOne(0))
                        break;

                }
                catch (TimeoutException) { }

            }

        }


        public void UpdatetxtStreamingFromThread(String msg)
        {
            if ((!this.IsDisposed && txtstreaming.InvokeRequired) & !msg.Equals(""))
            {
                this.txtstreaming.Invoke(new UpdatetxtStreamingFromThreadDelegate(setMessage), new Object[] { msg });
            }
        }

        public void setMessage(string msg)
        {
            msg = RemoveExtraText(msg);
            string[] weightstring = msg.Split('.');
            String leftdec = "";
            String rightdec = "";
            String weight = "";
            double leftdouble = 0;
            if (weightstring.Length > 1)
            {
                leftdec = weightstring[0];
                leftdouble = double.Parse(leftdec);
                rightdec = weightstring[1];
                weight = leftdouble.ToString() + "." + rightdec;
            }
            else
            {
                weight = weightstring[0];
            }


            txtIndicator.Text = weight;
        }



        private string RemoveExtraText(string value)
        {
            var allowedChars = "01234567890.";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }


        public void read_indicator()
        {
            thread = new Thread(bacaData);
            thread.IsBackground = true;
            thread.Start();
        }




        private void lblsearch_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loaddatasearch(textBox1.Text.Trim());
                loaddatasummary_search();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            save_retouching_edit();
            if (textBox1.Text.Equals(""))
            {
                loaddatartcdet();
                loaddatasummary();
                
            }
            else
            {
                loaddatasearch(textBox1.Text);
                loaddatasummary_search();
            }
            MessageBox.Show("Data changes has been stored");
        }

        private void save_retouching_edit()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            List<object[]> data1 = new List<object[]>();
            String intlotcode = lblInternalcode.Text.Trim();
            String userlog="";
            DateTime dt = DateTime.Now;
            data = frm.get_data_table_string("tbretouchingdetails", "loin_number", lblloin.Text.Trim());
            String sqty = "";
            if (data.Count > 0)
            {
                sqty = data[0][5].ToString();
            }

            if (!sqty.Equals(txtweightedit.Text.Trim()))
            {

                data1 = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
                if (data1.Count > 0)
                {
                    userlog = data1[0][11].ToString();
                }
                String username = Properties.Settings.Default.username;
                String newuserlog = DateTime.Now.ToString() + "," + username + ", " + lblloin.Text.Trim() + " change weight " + sqty + " to " + txtweightedit.Text.Trim();
                userlog = userlog + "\r\n" + newuserlog;
            }


            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText = "update tbretouchingdetails  set grade=@grade, rweight=@rweight, remark=@remark, moddatetime=@moddatetime where loin_number=@loin";
                mySql3.Parameters.AddWithValue("@grade", txtgrade.Text.Trim());
                mySql3.Parameters.AddWithValue("@rweight", Double.Parse(txtweightedit.Text.Trim()));
                mySql3.Parameters.AddWithValue("@remark", txtremark1.Text.Trim());
                mySql3.Parameters.AddWithValue("@loin", lblloin.Text.Trim());
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.ExecuteNonQuery();

                if (!userlog.Equals(""))
                {

                    mySql3.CommandText = "update tbreceiving set moddatetime=@moddatetime1, userlog=@userlog where intlotcode=@intlotcode";
                    mySql3.Parameters.AddWithValue("@userlog", userlog);
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@moddatetime1", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }

                //conn5.Close();

                panel1.Visible = false;
                txtgrade.Text = "";
                txtweightedit.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            finally
            {
                conn5.Close();
                
            }

            if (textBox1.Text.Equals(""))
            {
                loaddatartcdet();
            }
            else
            {
                loaddatasearch(textBox1.Text.Trim());
            }
        }

        public void loaddatasummary()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.getsummary_grade(intlotcode, "tbretouchingdetails");
            dataGridView2.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView2.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {

                    dataGridView2.Rows[i].Height = 35;
                    if (data[i][1] != null)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = data[i][1].ToString();
                    }
                    if (data[i][2] != null)
                    {
                        dataGridView2.Rows[i].Cells[1].Value = data[i][2].ToString();
                    }

                    if (data[i][3] != null)
                    {
                        dataGridView2.Rows[i].Cells[2].Value = data[i][3].ToString();
                    }
                }
            }
        }


        public void loaddatasummary_search()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.getsummary_grade_search(intlotcode, "tbretouchingdetails", textBox1.Text.Trim());
            dataGridView2.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView2.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {

                    dataGridView2.Rows[i].Height = 35;
                    if (data[i][1] != null)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = data[i][1].ToString();
                    }
                    if (data[i][2] != null)
                    {
                        dataGridView2.Rows[i].Cells[1].Value = data[i][2].ToString();
                    }

                    if (data[i][3] != null)
                    {
                        dataGridView2.Rows[i].Cells[2].Value = data[i][3].ToString();
                    }
                }
            }
        }


        public void loaddatasearch(String value)
        {
            //set grade empty
            String intlotcode = lblInternalcode.Text.Trim();
            //get data from table
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);

            if (value.Equals("") || value == null)
            {
                cmd.CommandText = "select * from tbretouchingdetails where intlotcode=@intlotcode order by id desc";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
            }
            else
            {
                cmd.CommandText = "select * from tbretouchingdetails where intlotcode=@intlotcode and (grade=@value or rweight=@value or remark=@value or loin_number like @loin_number) order by id desc";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.Parameters.AddWithValue("@loin_number", "%"+value+"%");
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
                //Type RM
                dataGridView1.Visible = true;
                dataGridView1.Rows.Clear();
                if (data.Count > 0)
                {
                    dataGridView1.Rows.Add(data.Count);
                    for (int i = 0; i < data.Count; i++)
                    {

                        dataGridView1.Rows[i].Height = 50;
                        dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                        dataGridView1.Rows[i].Cells[1].Value = data[i][8].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = data[i][4].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = data[i][5].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = data[i][6].ToString();

                    }
                }

                Edit_columnbutton();
                Delete_columnbutton();
            }
            finally
            {
                conn3.Close();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                lblsearch.Visible = true;
            }
            else
            {
                lblsearch.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            add_column_button(e, "edit", 5);
            add_column_button(e, "delete", 6);
            //add_column_button(e, "print", 7);

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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            loaddatasearch(textBox1.Text.Trim());
            loaddatasummary_search();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("1");
        }

        private void set_weight_from_Pad(String value)
        {

            if (modeinput.Equals("weight"))
            {
                if (Double.Parse(txtweight.Text) == 0)
                {
                    if (value.Equals("."))
                    {
                        txtweight.Text = "0.";
                    }
                    else
                    {

                        if (txtweight.Text.Equals("0."))
                        {
                            txtweight.Text += value;
                        }
                        else
                        {
                            txtweight.Text = value;
                        }
                    }
                    
                }
                else
                {
                    txtweight.Text = txtweight.Text + value;
                }

                String test = txtweight.Text.Trim();
                int count = test.Split('.').Length - 1;
                if (count > 1)
                {
                    MessageBox.Show("Duplicated dot, please choose another number");
                    test = test.Remove(test.Length - 1);
                    txtweight.Text = test.Trim();
                    return;
                }

            }else if (modeinput.Equals("remark"))
            {
                if (txtremark.Text.Equals(""))
                {
                    txtremark.Text = value;
                }
                else
                {
                    txtremark.Text = txtremark.Text + value;
                }

                String test = txtremark.Text.Trim();
                int count = test.Split('.').Length - 1;
                if (count > 1)
                {
                    MessageBox.Show("Duplicated dot, please choose another number");
                    test = test.Remove(test.Length - 1);
                    txtremark.Text = test.Trim();
                    return;
                }
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("0");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad(".");
        }

        private void del_from_pad()
        {

            if (modeinput.Equals("weight"))
            {
                if (txtweight.Text.Length > 0)
                {
                    txtweight.Text = txtweight.Text.Remove(txtweight.Text.Length - 1);
                }
                else
                {
                    txtweight.Text = "0.00";
                }
            }
            else if (modeinput.Equals("remark"))
            {

                if (txtremark.Text.Length > 0)
                {
                    txtremark.Text = txtremark.Text.Remove(txtremark.Text.Length - 1);
                }
                else
                {
                    txtremark.Text = "";
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            del_from_pad();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panelpad.Visible = false;
            if (modeinput.Equals("remark"))
            {
                button4_Click(sender, e);
            }
            modeinput = "";
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            if (modeinput.Equals("weight"))
            {
                txtweight.Text = "0.00";
            }
            else
            {
                txtremark.Text = "";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panelpad.Visible = true;
            modeinput = "remark";
        }

        private void panelpad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (scale_on == true)
            {
                try
                {
                    if (thread.IsAlive)
                    {
                        Thread.Sleep(1000);
                        scale_on = false;
                        _continue = false;
                        threadStop.Set();
                        thread.Abort();
                        thread.Join();
                        thread = null;
                    }


                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }

                    scale_on = false;
                    _continue = false;
                    lblconnect.Visible = false;
                    lock_weight = false;
                    lbl_locked.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Close();
        }

        private void btnprintoff_Click(object sender, EventArgs e)
        {
            btnprinton.ForeColor = Color.Gray;
            btnprintoff.ForeColor = Color.Red;
            printstatus = false;
        }

        private void btnprinton_Click(object sender, EventArgs e)
        {
            btnprinton.Enabled = true;
            btnprinton.ForeColor = Color.LightGreen;
            btnprintoff.ForeColor = Color.Gray;
            printstatus = true;
        }

        private void txtIndicator_TextChanged(object sender, EventArgs e)
        {
            if (scale_on)
            {
                if (lock_weight == false)
                {
                    txtweight.Text = txtIndicator.Text;
                    lbl_locked.Visible = false;
                }
                else
                {
                    double weight1 = 0;
                    if (!txtweight.Text.Equals(""))
                    {
                        weight1 = double.Parse(txtweight.Text);
                        txtweight.Text = weight1.ToString();
                    }
                }
            }
        }

        private void pbscale_Click(object sender, EventArgs e)
        {
            valueclear();
            if (scale_on)
            {
                lock_weight = true;
                lbl_locked.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (scale_on)
            {

                if (button3.Text.Equals("LOCKED"))
                {
                    lock_weight = true;
                    lbl_locked.Visible = true;
                    button3.Text = "UNLOCKED";
                }
                else
                {
                    lock_weight = false;
                    lbl_locked.Visible = false;
                    button3.Text = "LOCKED";
                }
            }





        }

        private void btnrs_Click(object sender, EventArgs e)
        {
            if (isrs.Equals(""))
            {
                btnrs.BackColor = Color.Orange;
                isrs = "-RS";
            }
            else
            {
                btnrs.BackColor = Color.LightGray;
                isrs = "";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            loaddatartcdet();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("/HC");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("/TC");
        }

    }
}
