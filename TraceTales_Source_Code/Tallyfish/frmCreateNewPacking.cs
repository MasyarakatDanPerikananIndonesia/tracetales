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


namespace Tallyfish
{
    public partial class frmCreateNewPacking : Form
    {
        private static Boolean printstatus = true;
        public string gcaseno,gboxno,glotnumber;
        public DateTime gbest_before_date;
        public frmCreateNewPacking()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateNewPacking_Load(object sender, EventArgs e)
        {

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

            dtlot = flot.get_data_table_string("tbpackingsize", "", "");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbpackingsize.Items.Add(dtlot[i][1]);
                }
            }

            dtlot = flot.get_data_table_string("tbproductsetup", "", "");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbproductname.Items.Add(dtlot[i][5]);
                }
            }


            dateTimePicker1.Value = DateTime.Now;
            seticon_forbutton();
        }

        private void cbproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string("tbproductsetup", "productname", cbproductname.Text.Trim());
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbproductpacking.Items.Add(dtlot[i][3]);
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
                    MessageBox.Show("No batch code " + txtbatch.Text.Trim() + " found in Supplier Setup");
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

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
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
            dtlot = flot.get_data_table_string_2param("tbsetup", "category", "typefish", "optionremark", fishtipe);
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


        private void createpacking()
        {
            String opt = Properties.Settings.Default.username;
            String grade = cbgrade.Text.Trim();
            String intlotcode = get_intlotcode();
            String packingsize = cbpackingsize.Text.Trim();
            DateTime dt = DateTime.Now;
            int julian = dt.DayOfYear;
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

            List<object[]> ft = new List<object[]>();
            MainMenu frm = new MainMenu();

            //get sequence box, boxno, caseno, lot_number
            frm = new MainMenu();
            String boxno = frm.get_data_sequence_boxno();
            gboxno = boxno;
            String caseno = frm.get_data_sequence_caseno();
            gcaseno = caseno;
            String lot_number = "L" + caseno;
            glotnumber = lot_number;

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                String userlog = dt.ToString("yyyy-MM-dd hh:mm:ss") + "," + opt + ", rcv creation";
                mySql3.CommandText =
                "Insert into tbpacking(box_number,case_number,grade,packingsize,username,moddatetime,lot_number,productname, productpacking, batchcode, suppcode, best_before_date, pieces, boxweight,proddate,certificate, intlotcode)" +
                " values(@box_number,@case_number,@grade,@packingsize,@username,@moddatetime,@lot_number, @productname, @productpacking,@batchcode, @suppcode,@best_before_date,@pieces,@boxweight,@proddate,@certificate,@intlotcode)";
                mySql3.Parameters.AddWithValue("@box_number", boxno);
                mySql3.Parameters.AddWithValue("@case_number", caseno);
                mySql3.Parameters.AddWithValue("@grade", grade);
                mySql3.Parameters.AddWithValue("@packingsize", packingsize);
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.Parameters.AddWithValue("@username", opt);
                mySql3.Parameters.AddWithValue("@lot_number", lot_number);
                mySql3.Parameters.AddWithValue("@productname", cbproductname.Text.Trim());
                mySql3.Parameters.AddWithValue("@productpacking", cbproductpacking.Text.Trim());
                mySql3.Parameters.AddWithValue("@batchcode", txtbatch.Text);
                mySql3.Parameters.AddWithValue("@suppcode", txtsuppcode.Text);

                DateTime processdate = dateTimePicker1.Value;
                DateTime best_before_date = processdate.AddDays(730);
                gbest_before_date = best_before_date;
                mySql3.Parameters.AddWithValue("@best_before_date", best_before_date);
                mySql3.Parameters.AddWithValue("@pieces", Int32.Parse(txtpieces.Text.Trim()));
                mySql3.Parameters.AddWithValue("@boxweight", Double.Parse(txtboxweight.Text.Trim()));
                mySql3.Parameters.AddWithValue("@proddate", processdate);
                mySql3.Parameters.AddWithValue("@certificate", cbcertificate.Text.Trim());
                mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }


        private void cleardata()
        {
            txtbatch.Clear();
            txtsuppcode.Clear();
            cbfishtype.Text = "";
            cbcertificate.Text = "";
            cbgrade.Text = "";
            cbpackingsize.Text = "";
            txtpieces.Clear();
            txtboxweight.Clear();
            cbproductname.Text = "";
            cbproductpacking.Text = "";
        }


        private void generateqrlabel()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 180,
                Height = 180,
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;

            //data label
            String case_number = gcaseno;
            String size = cbpackingsize.Text.Trim();
            String grade = cbgrade.Text.Trim();
            String box_number = gboxno;

            String pieces = txtpieces.Text;
            String boxweight = txtboxweight.Text;
            String lotnumber = glotnumber;
            String suppcode = txtsuppcode.Text;
            String intlotcode = get_intlotcode();
            String areacode = txtbatch.Text.Trim();
            String expireddate = gbest_before_date.ToString("yyyy-MM-dd");
            String fishingground = "";
            String proddate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String certcode = "";
            String species = "";

            String id_species = "";
            String packingbox = cbproductpacking.Text.Trim();
            String producttype = cbproductname.Text.Trim();
            String scientificname = "";
            String origin = "";
            String processedby = "";
            String addresscompany = "";


            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("vw_packing_supplier", "case_number", case_number);
            if (data.Count > 0)
            {
                origin = data[0][4].ToString();
                fishingground = data[0][2].ToString();
                certcode = data[0][6].ToString();
                id_species = data[0][16].ToString();
            }

            data = frm.get_data_table_id("tbproductsetup", Int32.Parse(id_species));
            if (data.Count > 0)
            {
                species = data[0][4].ToString();
            }

            String companyreg = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                companyreg = data[0][15].ToString();
            }


            data = frm.get_data_table_string("tbspecies", "speciesname", species.Trim());
            if (data.Count > 0)
            {
                scientificname = data[0][4].ToString();
            }

            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                processedby = data[0][2].ToString();
                addresscompany = data[0][7].ToString();
            }

            String dataqr = "";

            if (!certcode.Equals(""))
            {
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + certcode + "\r\n" + processedby + "\r\n" + addresscompany;
            }
            else
            {
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + processedby + "\r\n" + addresscompany;
            }

            dataqr = dataqr.Trim() + "\r\n" + "*" + case_number + "*" + "\r\n";
            var result = new Bitmap(qr.Write(dataqr));
            pblabel.Image = result;

            for (int i = 0; i < 2; i++)
            {
                printlabel();
            }
        }


        private double get_uprange_weight_product()
        {
            double nw = 0;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbproductsetup", "productname", cbproductname.Text.Trim(), "tradeunit", cbproductpacking.Text.Trim());
            if (data.Count > 0)
            {
                if (!data[0][9].ToString().Equals(""))
                {
                    //find out uprange
                    nw = double.Parse(data[0][9].ToString());
                }
            }
            return nw;
        }

        private double get_lowerrange_weight_product()
        {
            double nw = 0;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_2param("tbproductsetup", "productname", cbproductname.Text.Trim(), "tradeunit", cbproductpacking.Text.Trim());
            if (data.Count > 0)
            {
                if (!data[0][8].ToString().Equals(""))
                {
                    //find out uprange
                    nw = double.Parse(data[0][8].ToString());
                }
            }
            return nw;
        }







        private void printlabel()
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            doc.DefaultPageSettings.PaperSize = new PaperSize("100 x 150 mm", 393, 590);

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

            this.pblabel.Width = 180;
            this.pblabel.Height = 180;
            this.pblabel.SizeMode = PictureBoxSizeMode.StretchImage;

            Bitmap bmp = new Bitmap(this.pblabel.Width, this.pblabel.Height);
            this.pblabel.DrawToBitmap(bmp, new Rectangle(0, 0, this.pblabel.Width, this.pblabel.Height));
            e.Graphics.DrawImage((Image)bmp, 180, 260);
            //data label
            String case_number = gcaseno;
            String size = cbpackingsize.Text.Trim();
            String grade = cbgrade.Text.Trim();
            String box_number = gboxno;
            String pieces = txtpieces.Text.Trim();
            String boxweight = txtboxweight.Text.Trim();
            String lotnumber = glotnumber;
            String suppcode = txtsuppcode.Text.Trim();
            String intlotcode = get_intlotcode();
            String areacode = txtbatch.Text.Trim();
            String expireddate = gbest_before_date.ToString("yyyy-MM-dd");
            String fishingground = "";
            String proddate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String certcode = "";
            String certificate = cbcertificate.Text.Trim();
            String species = "";

            String id_species = "";
            String packingbox = cbproductpacking.Text.Trim();
            String producttype = cbproductname.Text.Trim();
            String scientificname = "";
            String origin = "";
            String processedby = "";
            String addresscompany = "";


            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("vw_packing_supplier", "case_number", case_number);
            if (data.Count > 0)
            {
                origin = data[0][4].ToString();
                fishingground = data[0][2].ToString();
                certcode = data[0][6].ToString();
                id_species = data[0][16].ToString();
            }


            data = frm.get_data_table_id("tbproductsetup", Int32.Parse(id_species));
            if (data.Count > 0)
            {
                species = data[0][4].ToString();
            }


            data = frm.get_data_table_string("tbspecies", "speciesname", species.Trim());
            if (data.Count > 0)
            {
                scientificname = data[0][4].ToString();
            }

            String companyreg = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                processedby = data[0][2].ToString();
                addresscompany = data[0][7].ToString();
                companyreg = data[0][15].ToString();
            }

            String batchcode = "";
            data = frm.get_data_table_string("tbpacking", "case_number", case_number);
            if (data.Count > 0)
            {
                batchcode = data[0][21].ToString();
            }
            string[] batch = batchcode.Split('-');
            String ismix = "";
            if (batch.Length > 1)
            {
                ismix = "MIX";
            }

            e.Graphics.DrawString("Case No.", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 38);
            e.Graphics.DrawString(case_number, new Font("Arial", 22, FontStyle.Bold), Brushes.Black, 76, 24);


            if (!certificate.Equals(""))
            {
                Pen selPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(selPen, 325, 20, 38, 35);
                e.Graphics.DrawString(certificate, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 330, 25);
                selPen.Dispose();
            }

            if (!ismix.Equals(""))
            {
                e.Graphics.DrawString(ismix, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 300, 205);
            }

            producttype = producttype.ToUpper();
            e.Graphics.DrawString(producttype, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 18, 70);
            e.Graphics.DrawString("( " + scientificname + " )", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 90, 96);

            e.Graphics.DrawString("Grade", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 140);
            e.Graphics.DrawString(grade, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 16, 155);

            e.Graphics.DrawString("Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, 140);
            e.Graphics.DrawString(size, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 100, 155);

            e.Graphics.DrawString("Net Weight (Kg)", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 210, 140);
            e.Graphics.DrawString(boxweight, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 210, 155);


            e.Graphics.DrawString("Pieces", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 320, 140);
            e.Graphics.DrawString(pieces, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 320, 155);

            e.Graphics.DrawString("Internal Lot Code", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 190);
            e.Graphics.DrawString(intlotcode, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 210);

            e.Graphics.DrawString("Packing Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 240);
            e.Graphics.DrawString(packingbox, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 255);

            e.Graphics.DrawString("Expiry Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 285);
            e.Graphics.DrawString(expireddate, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 300);

            e.Graphics.DrawString("Production Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 330);
            e.Graphics.DrawString(proddate, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 345);

            e.Graphics.DrawString("Origin", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 375);
            e.Graphics.DrawString(origin, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 72, 375);


            if (!certcode.Equals(""))
            {
                e.Graphics.DrawString(certificate + " Code", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 400);
                e.Graphics.DrawString(certcode, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 80, 400);
            }

            e.Graphics.DrawString("Processed By", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 440);
            e.Graphics.DrawString(processedby, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 465);
            e.Graphics.DrawString(addresscompany, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 485);

            if (!companyreg.Trim().Equals(""))
            {
                e.Graphics.DrawString("Vietnam Registration No", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 540);
                e.Graphics.DrawString(companyreg, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 180, 540);
            }
        }



        private void btnprint_Click(object sender, EventArgs e)
        {

            double uprange = get_uprange_weight_product();
            double lowerrange = get_lowerrange_weight_product();
            if (double.Parse(txtboxweight.Text) > uprange)
            {
                lblwarning.Text = " Total berat loin melebihi range berat maksimum yang diijinkan : " + uprange + ". Silahkan diganti dengan berat loin yang tepat";
                txtboxweight.Focus();
                return;
            }
            else if (double.Parse(txtboxweight.Text) < lowerrange)
            {
                lblwarning.Text = " Total berat loin di bawah range berat minimum : " + lowerrange + ". Silahkan tambah loin lagi";
                txtboxweight.Focus();
                return;
            }
            else
            {
                createpacking();
                generateqrlabel();
            }
            cleardata();
            txtbatch.Focus();
        }

        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
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

        private void cbproductpacking_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
