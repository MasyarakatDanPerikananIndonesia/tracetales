using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    public partial class frmCreateNewLoin : Form
    {
        public string loin_code_global;
        public static Boolean printstatus = true;
        public frmCreateNewLoin()
        {
            InitializeComponent();
        }

        private void frmCreateNewLoin_Load(object sender, EventArgs e)
        {
            txtbatch.Focus();
            seticon_forbutton();
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string("tbsetup", "category", "certificate");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbcertificate.Items.Add(dtlot[i][1]);
                }
                cbcertificate.Items.Add(" ");
            }

            dtlot = flot.get_data_table_string("tbgrade", "module", "retouching");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbgrade.Items.Add(dtlot[i][1]);
                }
            }

            dtlot = flot.get_data_table_string("tbsetup", "category", "typefish");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbfishtype.Items.Add(dtlot[i][1]);
                }
            }


            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void txtsuppcode_TextChanged(object sender, EventArgs e)
        {
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string("tbsupplier", "suppcode", txtsuppcode.Text);
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    lblsuppname.Text = dtlot[i][15].ToString();
                }
            }


        }

        private void txtbatch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                List<object[]> dtlot = new List<object[]>();
                MainMenu flot = new MainMenu();
                dtlot = flot.get_data_table_string("tbsupplier", "batchcode", txtbatch.Text.Trim());
                if (dtlot.Count == 0)
                {
                    MessageBox.Show("No batch code "+ txtbatch.Text.Trim() +" found in Supplier Setup");
                    txtbatch.Focus();
                }
                else
                {
                    txtsuppcode.Focus();
                }
            }
        }

        private void txtsuppcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                List<object[]> dtlot = new List<object[]>();
                MainMenu flot = new MainMenu();
                dtlot = flot.get_data_table_string("tbsupplier", "suppcode", txtsuppcode.Text.Trim());
                if (dtlot.Count == 0)
                {
                    MessageBox.Show("No supplier code " + txtsuppcode.Text.Trim() + " found in Supplier Setup");
                    txtsuppcode.Focus();
                }
                else
                {
                    this.dateTimePicker1.Focus();
                }
            }

        }

        private void cbcertificate_Click(object sender, EventArgs e)
        {
        }

        private void txtpackingsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtremark.Focus();
            }

        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnprint.Focus();
            }

        }

        private String get_intlotcode()
        {
            String intlotcode = "";
            String batch = txtbatch.Text.Trim();
            String suppcode = txtsuppcode.Text.Trim();

            String fishtipe = cbfishtype.Text.Trim();
            String fishtipeval = "";
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string_2param("tbsetup", "category", "typefish","optionremark",fishtipe);
            if (dtlot.Count > 0)
            {
                fishtipeval = dtlot[0][3].ToString();
            }

            DateTime tgl = dateTimePicker1.Value.Date;
            int julian = tgl.DayOfYear;
            String juliancode = julian.ToString();
			
            if (juliancode.Length == 1)
            {
                juliancode = "00" + juliancode;
            }
            else if (juliancode.Length == 2)
            {
                juliancode = "0" + juliancode;
            }
			
			
			
            String curryear = DateTime.Now.ToString("yy");
            String pdc = curryear + juliancode;

            if (cbcertificate.Text.Trim().Length == 0)
            {

                intlotcode = batch + suppcode + pdc + "." + fishtipeval;
            }
            else
            {
                intlotcode = batch + suppcode + pdc + "." + fishtipeval + "." + cbcertificate.Text.Trim();
            }

            return intlotcode;
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
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
            conn5.Close();
        }


        public String loingeneration()
        {
            String loin = "";

            DateTime tgl = dateTimePicker2.Value;
            int julian = tgl.DayOfYear;
            String juliancode = julian.ToString();
			
            if (juliancode.Length == 1)
            {
                juliancode = "00" + juliancode;
            }
            else if (juliancode.Length == 2)
            {
                juliancode = "0" + juliancode;
            }
			
			
            String curryear = tgl.ToString("yy");
            String pdc = curryear + juliancode;


            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();

            //get intlotcode the first row

            //data = frm.get_data_table_string("increment_loin", "pdc", pdc);
            data = frm.get_max_sequence_loin(pdc);

            Int32 urutan = 0;
            String urutanstr = "";
            String maxstring = "";
            if (data.Count > 0 )
            {

                maxstring = data[0][0].ToString();
                if (!maxstring.Equals(""))
                {
                    string rightnumber = maxstring.Substring(maxstring.Length - 5, 5);
                    urutan = Int32.Parse(rightnumber) + 1;
                }
                else
                {
                    urutan = 1;
                }

                //urutan = Int32.Parse(data[0][1].ToString());

               if (urutan.ToString().Length == 1)
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
            set_nextnumber_loin(pdc, urutan + 1);


            String compcode = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                compcode = data[0][13].ToString();
            }

            loin = compcode + "." + curryear + juliancode + "." + urutanstr;
            return loin;
        }



        private void save_retouchingdet()
        {
            MainMenu frm = new MainMenu();
            String intlotcode = get_intlotcode();
            String suppcode = txtsuppcode.Text.Trim();

            String loinnumber=""; 

            if (radioButton1.Checked)
            {
                loinnumber = loingeneration();
            }
            else if (radioButton2.Checked)
            {
                loinnumber = txtloin.Text.Trim();
            }

            String lotnumber = "L-" + loinnumber;

            DateTime dtcutting = dateTimePicker1.Value;
            DateTime dtretouching = dateTimePicker2.Value;
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
                mySql3.Parameters.AddWithValue("@rtcdate", DateTime.Parse(dtretouching.ToString("yyyy-MM-dd HH:mm:ss")));
                mySql3.Parameters.AddWithValue("@tipe", cbfishtype.Text.Trim());
                mySql3.Parameters.AddWithValue("@grade", cbgrade.Text.Trim());
                double cweight = 0;
                cweight = double.Parse(txtweight.Text);
                mySql3.Parameters.AddWithValue("@rweight", cweight);
                mySql3.Parameters.AddWithValue("@remark", txtremark.Text.Trim());

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
            conn5.Close();
        }


        private void save_receiving()
        {
            Boolean statusada = false;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //get intlotcode the first row
            data = frm.get_data_table_string("tbreceiving", "intlotcode", get_intlotcode());
            if (data.Count > 0)
            {
                statusada = true;
            }
            String species = "";
            data = frm.get_data_table_string("tbspecies", "", "");
            if (data.Count > 0)
            {
                species = data[0][1].ToString();
            }
            String certificatecode="";
            data = frm.get_data_table_string("tbsupplier", "suppcode", txtsuppcode.Text.Trim());
            if (data.Count > 0)
            {
                certificatecode= data[0][13].ToString();
            }


            if (!statusada)
            {

                String intlotcode = get_intlotcode();
                String suppcode = txtsuppcode.Text.Trim();

                String loinnumber = loingeneration();
                String lotnumber = "L-" + loinnumber;

                DateTime dtcutting = dateTimePicker1.Value;
                DateTime dtretouching = dateTimePicker2.Value;
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into tbreceiving(intlotcode,species, tipe, rcvdate, supplier, certificate, username, certificatecode)" +
                            " values(@intlotcode1,@species, @tipe, @rcvdate, @supplier, @certificate, @username, @certificatecode)";
                    mySql3.Parameters.AddWithValue("@intlotcode1", intlotcode);
                    mySql3.Parameters.AddWithValue("@species", species);
                    mySql3.Parameters.AddWithValue("@tipe", cbfishtype.Text);
                    mySql3.Parameters.AddWithValue("@rcvdate", DateTime.Parse(dtcutting.ToString("yyyy-MM-dd HH:mm:ss")));
                    mySql3.Parameters.AddWithValue("@supplier", txtbatch.Text.Trim()+"-"+txtsuppcode.Text.Trim()+"-"+lblsuppname.Text);
                    mySql3.Parameters.AddWithValue("@certificate", cbcertificate.Text);
                    String username;
                    username = Properties.Settings.Default.username;
                    mySql3.Parameters.AddWithValue("@username", username);
                    mySql3.Parameters.AddWithValue("@certificatecode", certificatecode);
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
            }
        }



        private void save_retouching_productname()
        {
            String intlotcode = get_intlotcode();
            String productname = "Frozen Yellowfin Tuna Loin";

            Boolean ada = false;
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string_2param("tbretouching", "intlotcode", intlotcode, "productname", productname);
            if (data.Count > 0)
            {
                ada = true;
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();

            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();

                if (!ada)
                {
                    mySql3.CommandText = "Insert into tbretouching(intlotcode,productname) values(@intlotcode,@productname)";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    mySql3.ExecuteNonQuery();
                }
                else if (ada)
                {
                    mySql3.CommandText = "Update tbretouching set productname=@productname, moddatetime=@moddatetime  where intlotcode=@intlotcode";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    DateTime dt = DateTime.Now;
                    String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime currdate = DateTime.Parse(cdate);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }

        private String get_fishing_ground()
        {
            String fishingground = "";
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string("tbsupplier", "suppcode", txtsuppcode.Text.Trim());
            if (dtlot.Count > 0)
            {
                fishingground= dtlot[0][7].ToString();
            }
            return fishingground;
        }

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

            string intlotcode = get_intlotcode();

            String asfis = "";
            String suppliercode = txtsuppcode.Text.Trim();

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbspecies", "", "");

            if (data.Count > 0)
            {
                asfis = data[0][1].ToString();
            }

            String origin = "INDONESIA";
            String fishing_ground = get_fishing_ground();
            String certcode = cbcertificate.Text.Trim();

            String loincode = loin_code_global;
            String grade = cbgrade.Text.Trim();
            double rweight = Double.Parse(txtweight.Text);
            String remark = txtremark.Text.Trim();

            String qrtext = loincode + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\n" + remark + "\r\n";

            var result = new Bitmap(qr.Write(qrtext));
            pbLabel.Image = result;

            printlabel();

        }

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

        private String sign_remark(String intlotcode, String remark)
        {
            MainMenu frm = new MainMenu();
            Int32 signed = frm.get_count_remark(intlotcode, remark);
            String doublechar = "";
            for (int i = 0; i < signed - 2; i++)
            {
                doublechar = doublechar + "X";
            }
            return doublechar;
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
            e.Graphics.DrawImage((Image)bmp, 30, 40);
            string intlotcode = get_intlotcode();
            String asfis = "";
            String suppliercode = txtsuppcode.Text.Trim();

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbspecies", "", "");

            if (data.Count > 0)
            {
                asfis = data[0][1].ToString();
            }

            String origin = "INDONESIA";
            String fishing_ground = get_fishing_ground();
            String certcode = "";
            String loincode = loin_code_global;
            String grade = cbgrade.Text.Trim();
            double rweight = Double.Parse(txtweight.Text);
            String remark = txtremark.Text.Trim() + sign_remark(intlotcode, txtremark.Text.Trim());
            String cert = cbcertificate.Text.Trim();

            DateTime cutdate = dateTimePicker1.Value;
            String cutdatestr = cutdate.ToString("yy-MM-dd");
            String productname = "";
            data = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                productname = data[0][2].ToString();
            }


            data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                certcode = data[0][13].ToString();
            }



            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);

            String textfrozen = "Keep Frozen -18\u00b0C";
            e.Graphics.DrawString(textfrozen, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 160);

            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 34, 15);

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

            datalabel = intlotcode;
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
                datalabel = cert + " Code: " + certcode;
                e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 145);
            }
            e.Graphics.DrawString(cert, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 60, 160);
            e.Graphics.DrawString(productname, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 175); 




/*

            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);
            
            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, 15);

            String datalabel;
            datalabel = "Species";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 20);
            datalabel = asfis;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 35);

            datalabel = "Grade";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 237, 20);

            datalabel = grade;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 237, 35);

            datalabel = "Weight";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 297, 20);
            datalabel = rweight.ToString() + " (Kg)";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 297, 35);


            //e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 140, 60);

            datalabel = "Internal Lot Code";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 55);

            datalabel = intlotcode;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 70);


            datalabel = "Remark";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 297, 55);

            datalabel = remark;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 297, 70);

            datalabel = "Origin";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 90);

            datalabel = origin;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 105);

            datalabel = "Fishing Ground";
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 260, 90);

            datalabel = fishing_ground;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 260, 105);

            datalabel = "Processing Date: " + cutdatestr;
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 125);

            if (!cert.Equals(""))
            {
                datalabel = cert + " Code: " + certcode;
                e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 145);
            }

            e.Graphics.DrawString(productname, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 170);
 */
        }

        private Int32 remark_double(String intlotcode, String remark)
        {
            remark = remark.Replace("X", "");
            String doublechar = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbretouchingdetails", "intlotcode", intlotcode, "remark", remark);
            return data.Count;
        }


        private void btnprint_Click(object sender, EventArgs e)
        {
            String intlotcode= get_intlotcode();
            String remark = txtremark.Text.Trim() + sign_remark(intlotcode, txtremark.Text.Trim());

            Boolean validsimpan = true;
            remark = remark.Replace("X", "");

            if (cbgrade.Text.Contains('A'))
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

            if (validsimpan == true)
            {
                save_retouchingdet();
                save_retouching_productname();
                save_receiving();
                generateqrlabel();
                txtbatch.Clear();
                txtsuppcode.Clear();
                txtremark.Clear();
                txtweight.Clear();
                cbfishtype.Text = "";
                cbgrade.Text = "";
                cbcertificate.Text = "";
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprinton_Click(object sender, EventArgs e)
        {
            btnprinton.Enabled = true;
            btnprinton.ForeColor = Color.LightGreen;
            btnprintoff.ForeColor = Color.Gray;
            printstatus = true;
        }

        private void btnprintoff_Click(object sender, EventArgs e)
        {
            btnprinton.ForeColor = Color.Gray;
            btnprintoff.ForeColor = Color.Red;
            printstatus = false;
        }

        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtloin.Visible = true;
            txtloin.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtloin.Visible = false;
        }

        private void dateTimePicker2_Validated(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {



        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker2.Value.Date;
            String tgl = dt.ToString("yyyy-MM-dd");
            DateTime dtnow = DateTime.Now;
            String tglnow = dtnow.ToString("yyyy-MM-dd");
            if (DateTime.Parse(tgl) > DateTime.Parse(tglnow))
            {
                MessageBox.Show("Input tanggal tidak valid karena melebihi tanggal hari ini");
                dateTimePicker2.Value = dtnow;
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value.Date;
            String tgl = dt.ToString("yyyy-MM-dd");
            DateTime dtnow = DateTime.Now;
            String tglnow = dtnow.ToString("yyyy-MM-dd");
            if (DateTime.Parse(tgl) > DateTime.Parse(tglnow))
            {
                MessageBox.Show("Input tanggal tidak valid karena melebihi tanggal hari ini");
                dateTimePicker1.Value = dtnow;
                dateTimePicker1.Focus();
            }


        }

    }
}
