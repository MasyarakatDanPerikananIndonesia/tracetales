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
    public partial class frmDefrost_Loin : Form
    {

        public String loin_code_global = "";
        public Boolean printstatus = true;

        public frmDefrost_Loin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtscan_KeyPress(object sender, KeyPressEventArgs e)
        {

            String loinnumber = "";
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loinnumber = txtscan.Text;
                loinnumber = loinnumber.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                List<object[]> data = new List<object[]>();
                MainMenu frm = new MainMenu();
                data = frm.get_data_table_string("tbretouchingdetails", "loin_number", loinnumber);
                if (data.Count > 0)
                {
                    intlotcode.Text = data[0][1].ToString();
                    txtloin.Text = loinnumber;
                    txtgrade.Text = data[0][4].ToString();
                    txtweight.Text = data[0][5].ToString();
                    txtscan.Text = "";
                    txtgrade.Focus();
                }
                else
                {
                    lblmessage.Text = "Data loin number " + loinnumber + " tidak ditemukan";
                    txtscan.Text = "";
                    txtscan.Focus();
                }


                return;
            }
        }

        private void frmDefrost_Loin_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
        }

        private void btnretouching_Click(object sender, EventArgs e)
        {
            String loin_number = txtloin.Text.Trim();
            save_retouching_edit();
            reprint_qrlabel(loin_number);
        }


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
            dtretouching = frm.get_data_table_string("tbretouchingdetails", "loin_number", loin_number);
            if (dtretouching.Count > 0)
            {
                intlotcode = dtretouching[0][1].ToString();
                grade = dtretouching[0][4].ToString();
                rweight = double.Parse(dtretouching[0][5].ToString());
                remark = dtretouching[0][6].ToString();

                Properties.Settings.Default.grade = grade;
                Properties.Settings.Default.rweight = rweight;
                Properties.Settings.Default.remark = remark;

            }

            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";

            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);

            if (data.Count > 0)
            {
                asfis = data[0][2].ToString();
                suprec = data[0][5].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
            }

            String origin = "";
            String fishing_ground = "";
            String cert = "";
            String certcode = "";

            data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                origin = data[0][9].ToString();
                fishing_ground = data[0][7].ToString();
                cert = data[0][12].ToString();
                certcode = data[0][13].ToString();
            }

            String qrtext = loin_number + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\nremark:" + remark + "\r\n";

            //to put loin code in label
            loin_code_global = loin_number;

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
            string intlotcode = this.intlotcode.Text.Trim();


            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                asfis = data[0][2].ToString();
                suprec = data[0][5].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
            }

            String origin = "";
            String fishing_ground = "";
            String cert = "";
            String certcode = "";

            data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                origin = data[0][9].ToString();
                fishing_ground = data[0][7].ToString();
                cert = data[0][12].ToString();
                certcode = data[0][13].ToString();
            }

            String loincode = loin_code_global;
            String grade = Properties.Settings.Default.grade;
            double rweight = Properties.Settings.Default.rweight;
            String remark = Properties.Settings.Default.remark;
            DateTime cutdate = DateTime.Parse("1900-1-1");
            String cutdatestr = cutdate.ToString("yyyy-MM-dd");
            data = frm.get_data_table_string("tbcuttingdetails", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                cutdate = DateTime.Parse(data[0][2].ToString());
                cutdatestr = cutdate.ToString("yyyy-MM-dd");
            }
            else
            {
                List<object[]> data1 = new List<object[]>();
                data1 = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
                if (data1.Count > 0)
                {
                    cutdate = DateTime.Parse(data1[0][4].ToString());
                    cutdatestr = cutdate.ToString("yyyy-MM-dd");
                }
            }

            String productname = "";
            data = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                productname = data[0][2].ToString();
            }


            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);

            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 35, 15);

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
            e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 135);

            if (!cert.Equals("") && !certcode.Equals(""))
            {
                datalabel = cert + " Code: " + certcode;
                e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 160);
            }
            e.Graphics.DrawString(cert, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 60, 160);
            e.Graphics.DrawString(productname, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 175); 

        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_retouching_edit()
        {
            String loinnumber = txtloin.Text.Trim();
            String intlotcode = this.intlotcode.Text;

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            List<object[]> data1 = new List<object[]>();

            String userlog = "";
            DateTime dt = DateTime.Now;
            data = frm.get_data_table_string("tbretouchingdetails", "loin_number", loinnumber.Trim());
            String sqty = "";
            if (data.Count > 0)
            {
                sqty = data[0][5].ToString();
            }

            if (!sqty.Equals(txtweight.Text.Trim()))
            {
                data1 = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
                if (data1.Count > 0)
                {
                    userlog = data1[0][11].ToString();
                }
                String username = Properties.Settings.Default.username;
                String newuserlog = DateTime.Now.ToString() + "," + username + ", " + loinnumber.Trim() + " change weight " + sqty + " to " + txtweight.Text.Trim() + " due to defrost.";
                userlog = userlog + "\r\n" + newuserlog;
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText = "update tbretouchingdetails  set grade=@grade, rweight=@rweight, moddatetime=@moddatetime where loin_number=@loin";
                mySql3.Parameters.AddWithValue("@grade", txtgrade.Text.Trim());
                mySql3.Parameters.AddWithValue("@rweight", Double.Parse(txtweight.Text.Trim()));
                mySql3.Parameters.AddWithValue("@loin", txtloin.Text.Trim());
                dt = DateTime.Now;
                String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime currdate = DateTime.Parse(cdate);
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
                conn5.Close();
                txtgrade.Text = "";
                txtweight.Text = "";
                txtloin.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
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


    }
}
