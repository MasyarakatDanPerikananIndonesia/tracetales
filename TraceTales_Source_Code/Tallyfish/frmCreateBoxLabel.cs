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
    public partial class frmCreateBoxLabel : Form
    {
        private static Boolean printstatus = false;

        public frmCreateBoxLabel()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
        }



        private void frmCreateBoxLabel_Load(object sender, EventArgs e)
        {
            dtexpiry.Value = DateTime.Now;
            dtproduction.Value = DateTime.Now;
            txtproductname.Text = "FROZEN YELLOWFIN TUNA LOIN";
            txtscientificname.Text = "Thunnus albacares";
            txtpackingsize.Text = "Case 30 Kg";
            txtcountryorigin.Text = "INDONESIA";
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprint);
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
            txtcaseno.Focus();

        }

        private void clear_entry()
        {
            txtcaseno.Clear();
            txtgrade.Clear();
            txtsize.Clear();
            txtnetweight.Clear();
            txtpieces.Clear();
            txtintlotcode.Clear();
            txtcompanyname.Clear();
            txtcompanyaddress.Clear();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            generateqrlabel();
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
            //Variable
            String case_number = txtcaseno.Text.Trim();
            String producttype = txtproductname.Text.Trim();
            String scientificname = txtscientificname.Text.Trim();
            String packingbox = txtpackingsize.Text.Trim();
            String grade = txtgrade.Text.Trim();
            String size = txtsize.Text.Trim();
            String boxweight = txtnetweight.Text.Trim();
            String pieces = txtpieces.Text.Trim();
            String origin = txtcountryorigin.Text.Trim();
            String intlotcode = txtintlotcode.Text.Trim();
            DateTime dtexp = dtexpiry.Value.Date;
            String expireddate = dtexp.ToString("yyyy-MM-dd");
            DateTime dtprod = dtproduction.Value.Date;
            String productiondate = dtprod.ToString("yyyy-MM-dd");
            String countryorigin = txtcountryorigin.Text.Trim();
            String companyname = txtcompanyname.Text.Trim();
            String companyaddress = txtcompanyaddress.Text.Trim();
            
            String certificate = txtcertificate.Text.Trim();
            String certcode = txtcertificatecode.Text.Trim();

            String dataqr = "";

            if (!certificate.Equals(""))
            {
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + certificate + "\r\n" + companyname + "\r\n" + companyaddress;
            }
            else
            {
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + companyname + "\r\n" + companyaddress;
            }

            //create code for QR Code reader
            dataqr = dataqr + "\r\n" + "*" + case_number + "*" + "\r\n";

            dataqr = dataqr.Trim();
            var result = new Bitmap(qr.Write(dataqr));
            pblabel.Image = result;
            pblabel.Height = 180;
            pblabel.Width = 180;
            printlabel();
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
            String case_number = txtcaseno.Text.Trim();
            String size = txtsize.Text.Trim();
            String grade = txtgrade.Text.Trim();
            String pieces = txtpieces.Text.Trim();
            String boxweight = txtnetweight.Text.Trim();
            String intlotcode = txtintlotcode.Text.Trim();
            DateTime dtexp = dtexpiry.Value.Date;
            String expireddate = dtexp.ToString("yyyy-MM-dd");
            DateTime dtprod = dtproduction.Value.Date;
            String proddate = dtprod.ToString("yyyy-MM-dd");
            String certificate = txtcertificate.Text.Trim();
            String certcode = txtcertificatecode.Text.Trim();
            String packingbox = txtpackingsize.Text.Trim();
            String producttype = txtproductname.Text.Trim();
            String scientificname = txtscientificname.Text.Trim();
            String origin = txtcountryorigin.Text.Trim();
            String processedby = txtcompanyname.Text.Trim();
            String addresscompany = txtcompanyaddress.Text.Trim();

            e.Graphics.DrawString("Case No.", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 38);
            e.Graphics.DrawString(case_number, new Font("Arial", 22, FontStyle.Bold), Brushes.Black, 76, 24);

            if (!certificate.Equals(""))
            {
                Pen selPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(selPen, 325, 20, 38, 35);
                e.Graphics.DrawString(certificate, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 330, 25);
                selPen.Dispose();
            }

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String companyreg = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                processedby = data[0][2].ToString();
                addresscompany = data[0][7].ToString();
                companyreg = data[0][15].ToString();
            }


            producttype = producttype.ToUpper();
            e.Graphics.DrawString(producttype, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 18, 70);
            e.Graphics.DrawString("( " + scientificname + " )", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 90, 96);

            e.Graphics.DrawString("Grade", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 140);
            e.Graphics.DrawString(grade, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 155);

            e.Graphics.DrawString("Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, 140);
            e.Graphics.DrawString(size, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 100, 155);

            e.Graphics.DrawString("Net Weight", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 210, 140);
            e.Graphics.DrawString(boxweight + " Kg", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 210, 155);


            e.Graphics.DrawString("Pieces", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 320, 140);
            e.Graphics.DrawString(pieces, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 320, 155);

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

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprinton_Click(object sender, EventArgs e)
        {
            btnprinton.Enabled = true;
            btnprinton.ForeColor = Color.Green;
            btnprintoff.ForeColor = Color.Gray;
            printstatus = true;

        }

        private void btnprintoff_Click(object sender, EventArgs e)
        {
            btnprinton.ForeColor = Color.Gray;
            btnprintoff.ForeColor = Color.Red;
            printstatus = false;
        }

        private void txtcaseno_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtgrade.Focus();
            }
        }

        private void txtgrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtsize.Focus();
            }

        }

        private void txtsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtnetweight.Focus();
            }
        }

        private void txtnetweight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtpieces.Focus();
            }
        }

        private void txtpieces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtintlotcode.Focus();
            }
        }

        private void txtintlotcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                dtexpiry.Focus();
            }

        }

        private void txtcertificate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcertificatecode.Focus();
            }
        }

        private void txtcertificatecode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcompanyname.Focus();
            }
        }

        private void txtcompanyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcompanyaddress.Focus();
            }
        }


    }


}
