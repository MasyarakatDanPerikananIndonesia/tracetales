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
    public partial class frmOptional : Form
    {
        public static String caseno;
        public static String packingbox;
        public static String producttype;
        public static String scientificname;
        public static String loinnumber;
        public Int32 numenter = 1;
        public Int32 tipescan = 0; //manual

        public frmOptional()
        {
            InitializeComponent();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnretouching.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnpacking_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpacking.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnretouching_Click(object sender, EventArgs e)
        {
            if (btnretouching.Text.Contains("Retouching"))
            {
                panel3.Visible = false;
                panellabel.Visible = true;
                lblcode.Text = "Scan Loin Code: ";
                txtscan.Clear();
                txtscan.Focus();
                btnscan.Visible = true;
                btnscan2.Visible = true;
            }
        }

        public void set_button_reprint_label()
        {
            btnretouching.Text = "Label Retouching";
            btnpacking.Text = "Label Packing";
            lblHeader.Text = "RE-PRINT LABEL";
        }


        private void btnpacking_Click(object sender, EventArgs e)
        {

            if (btnpacking.Text.Contains("Reprint Label"))
            {
                btnretouching.Text = "Label Retouching";
                btnpacking.Text = "Label Packing";
                lblHeader.Text = "RE-PRINT LABEL";
            }


            if (btnpacking.Text.Contains("Packing"))
            {
                panel3.Visible = false;
                panellabel.Visible = true;
                lblcode.Text = "Scan Case Number: ";
                txtscan.Clear();
                txtscan.Focus();
                btnscan.Visible = false;
                btnscan2.Visible = false;
            }
        }


        private void reprint_label_retouching()
        {

        }

        private void reprint_label_packing()
        {
        }


        private void generateqrlabel_packing()
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

            String size = "";
            String grade = "";
            String box_number = "";
            String pieces = "";
            String boxweight = "";
            String lotnumber = "";
            String suppcode = "";
            String intlotcode = "";
            String areacode = "";
            String expireddate = "";
            String fishingground = "";
            String proddate = "";
            String certcode = "";
            String species = "";
            String id_species = "";
            String origin = "";
            String processedby = "";
            String addresscompany = "";
            lblmessage.Text = "-";

            caseno = lblcaseno.Text;
            caseno = caseno.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("vw_packing_supplier", "case_number", caseno);
            if (data.Count > 0)
            {
                size = data[0][11].ToString();
                grade = data[0][10].ToString();
                origin = data[0][4].ToString();
                box_number = data[0][8].ToString();
                pieces = data[0][15].ToString();
                boxweight = data[0][17].ToString();

                lotnumber = data[0][13].ToString();
                suppcode = data[0][1].ToString();
                intlotcode = data[0][12].ToString();
                areacode = data[0][0].ToString();
                DateTime expdate = DateTime.Parse(data[0][14].ToString());
                expireddate = expdate.ToString("yyyy-MM-dd");
                fishingground = data[0][2].ToString();
                DateTime pdate = DateTime.Parse(data[0][18].ToString());
                proddate = pdate.ToString("yyyy-MM-dd");
                certcode = data[0][6].ToString();
                id_species = data[0][16].ToString();
            }
            else
            {
                lblmessage.Text = "Case Number " + caseno + " is not available. Please scan another case number";
                txtscan.Clear();
                txtscan.Focus();
                return;
            }

            data = frm.get_data_table_string("tbpacking","case_number",caseno);
            if (data.Count > 0)
            {
                producttype = data[0][18].ToString();
            }
            data = frm.get_data_table_string("tbproductsetup", "productname", producttype);
            if (data.Count > 0)
            {
                packingbox = data[0][3].ToString();
                species = data[0][4].ToString();
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

            String companyreg = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                companyreg = data[0][15].ToString();
            }

            String dataqr = "";
            if (!certcode.Equals(""))
            {
                dataqr = caseno + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + certcode + "\r\n" + processedby + "\r\n" + addresscompany ; 
            }
            else
            {
                dataqr = caseno + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + processedby + "\r\n" + addresscompany ;  
            }

            //dataqr = dataqr.Trim() + "*" + caseno + "*";
            dataqr = dataqr.Trim() + "\r\n" + "*" + caseno + "*";
            var result = new Bitmap(qr.Write(dataqr));
            pblabel.Image = result;
            for (int i = 0; i < 2; i++)
            {
                printlabel("packing");
            }
        }



        private void generateqrlabel_retouching()
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

            //loinnumber = get_data_scan();
            String intlotcode = "";
            String loincode = loinnumber;
            String grade = "";
            double rweight = 0;
            String remark = "";


            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbretouchingdetails", "loin_number", loincode);
            if (data.Count > 0)
            {
                intlotcode = data[0][1].ToString();
                grade = data[0][4].ToString();
                rweight = Double.Parse(data[0][5].ToString());
                remark = data[0][6].ToString();
            }
            else
            {
                MessageBox.Show("Loin Number " + loincode + " is not available");
                txtscan.Clear();
                txtscan.Focus();
                return;
            }

            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";
            String cert = "";
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                asfis = data[0][2].ToString();
                suprec = data[0][5].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
                cert = data[0][6].ToString();
            }

            String origin = "";
            String fishing_ground = "";
            
            String certcode = "";

            data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                origin = data[0][9].ToString();
                fishing_ground = data[0][7].ToString();
                
                certcode = data[0][13].ToString();
            }


            String qrtext = loincode + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\n" + remark + "\r\n";

            var result = new Bitmap(qr.Write(qrtext));
            pblabel.Image = result;
            printlabel("retouching");
        }






        private void printlabel(String module)
        {
            PrintDocument doc = new PrintDocument();
            
            if (module.Equals("packing"))
            {

                doc.PrintPage += this.Doc_PrintPage_packing;
                doc.DefaultPageSettings.PaperSize = new PaperSize("100 x 150 mm", 393, 590);
            }
            else if (module.Equals("retouching"))
            {
                doc.PrintPage += this.Doc_PrintPage_retouching;
                doc.DefaultPageSettings.PaperSize = new PaperSize("100 x 50 mm", 393, 196);
            }

            /*
            PrintPreviewDialog pd = new PrintPreviewDialog();
            pd.Document = doc;
            pd.ShowDialog();
            */
           
            doc.Print();
            doc.Dispose();
             
             
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private String get_certificate_fromreceiving(String intlotcode)
        {
            String intlotcoderesult = "";
            if (!intlotcode.Equals(""))
            {
                List<object[]> data = new List<object[]>();
                String connString = Konek();
                MySqlConnection conn3 = null;
                conn3 = new MySqlConnection(connString);
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                cmd.CommandText = "SELECT certificate FROM tbreceiving where intlotcode=@intlotcode";
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

                if (data.Count > 0)
                {
                    intlotcoderesult = data[0][0].ToString();
                }
            }
            return intlotcoderesult;
        }




        private void Doc_PrintPage_packing(object sender, PrintPageEventArgs e)
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
            String case_number = caseno;

            String size = "";
            String grade = "";
            String box_number = "";
            String pieces = "";
            String boxweight = "";
            String lotnumber = "";
            String suppcode = "";
            String intlotcode = "";
            String areacode = "";
            String expireddate = "";
            String fishingground = "";
            String proddate = "";
            String certcode = "";
            String certificate = "";
            String species = "";
            String origin = "";
            String processedby = "";
            String addresscompany = "";


            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("vw_packing_supplier", "case_number", case_number);
            if (data.Count > 0)
            {
                size = data[0][11].ToString();
                grade = data[0][10].ToString();
                origin = data[0][4].ToString();
                box_number = data[0][8].ToString();
                pieces = data[0][15].ToString();
                boxweight = data[0][17].ToString();
                lotnumber = data[0][13].ToString();
                suppcode = data[0][1].ToString();
                intlotcode = data[0][12].ToString();
                areacode = data[0][0].ToString();
                DateTime expdate = DateTime.Parse(data[0][14].ToString());
                expireddate = expdate.ToString("yyyy-MM-dd");
                fishingground = data[0][2].ToString();
                DateTime pdate = DateTime.Parse(data[0][18].ToString());
                proddate = pdate.ToString("yyyy-MM-dd");
                certcode = data[0][6].ToString();
                //certificate = data[0][5].ToString();
            }

            certificate = get_certificate_fromreceiving(intlotcode);


            String companyreg="";
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
                ismix = batchcode;
            }

            if (!ismix.Equals(""))
            {
                e.Graphics.DrawString(ismix, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 300, 205);
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


            producttype = producttype.ToUpper();
            e.Graphics.DrawString(producttype, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 18, 70);
            e.Graphics.DrawString("( " + scientificname + " )", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 90, 96);

            e.Graphics.DrawString("Grade", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 140);
            e.Graphics.DrawString(grade, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 12, 155);

            e.Graphics.DrawString("Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, 140);
            e.Graphics.DrawString(size, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 100, 155);

            e.Graphics.DrawString("Net Weight (Kg)", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 210, 140);
            e.Graphics.DrawString(boxweight, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 210, 155);


            e.Graphics.DrawString("Pieces", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 320, 140);
            e.Graphics.DrawString(pieces, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 320, 155);

            e.Graphics.DrawString("Production Code", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 190);
            e.Graphics.DrawString(intlotcode, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 12, 210);

            e.Graphics.DrawString("Packing Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 240);
            e.Graphics.DrawString(packingbox, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 12, 255);

            e.Graphics.DrawString("Expiry Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 285);
            e.Graphics.DrawString(expireddate, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 12, 300);

            e.Graphics.DrawString("Production Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 330);
            e.Graphics.DrawString(proddate, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 12, 345);

            e.Graphics.DrawString("Origin", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 375);
            e.Graphics.DrawString(origin, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 70, 375);


            if (!certcode.Equals("") && !certificate.Equals(""))
            {
                e.Graphics.DrawString(certificate + " Code", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 400);
                e.Graphics.DrawString(certcode, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 80, 400);
            }

            e.Graphics.DrawString("Processed By", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 430);
            e.Graphics.DrawString(processedby, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 12, 455);
            e.Graphics.DrawString(addresscompany, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 12, 475);


            if (!companyreg.Equals(""))
            {
                e.Graphics.DrawString("Vietnam Registration No", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 530);
                e.Graphics.DrawString(companyreg, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 180, 530);
            }
        }


        private void Doc_PrintPage_retouching(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            this.pblabel.Width = 100;
            this.pblabel.Height = 100;

            Bitmap bmp = new Bitmap(this.pblabel.Width, this.pblabel.Height);
            this.pblabel.DrawToBitmap(bmp, new Rectangle(0, 0, this.pblabel.Width, this.pblabel.Height));
            // e.Graphics.DrawImage((Image)bmp, x, y);
            e.Graphics.DrawImage((Image)bmp, 30, 45);


            String intlotcode = "";
            String grade = "";
            double rweight = 0;
            String remark = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbretouchingdetails", "loin_number", loinnumber);
            if (data.Count > 0)
            {
                intlotcode = data[0][1].ToString();
                grade = data[0][4].ToString();
                rweight = double.Parse(data[0][5].ToString());
                remark = data[0][6].ToString();
            }

            String asfis = "";
            String suprec = "";
            String[] suppcode;
            String suppliercode = "";
            String cert = "";
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                asfis = data[0][2].ToString();
                suprec = data[0][5].ToString();
                suppcode = suprec.Split('-');
                suppliercode = suppcode[1].ToString();
                cert = data[0][6].ToString();
            }


            String origin = "";
            String fishing_ground = "";
            
            String certcode = "";

            data = frm.get_data_table_string("tbsupplier", "suppcode", suppliercode);
            if (data.Count > 0)
            {
                origin = data[0][9].ToString();
                fishing_ground = data[0][7].ToString();
                certcode = data[0][13].ToString();
            }

            String loincode = loinnumber;


            DateTime cutdate;
            String cutdatestr = "";
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
                cutdate = DateTime.Parse(data1[0][4].ToString());
                cutdatestr = cutdate.ToString("yyyy-MM-dd");
            }

            String productname = "";
            data = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                productname = data[0][2].ToString();
            }

            String grupsize = "";
            data = frm.get_grupsize_loin(rweight);
            if (data.Count > 0)
            {
                grupsize = data[0][0].ToString();
            }

            /*
            List<object[]> dataretouching = new List<object[]>();
            dataretouching= get_dataretouching(intlotcode, rweight, remark);
            */

            //e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 30, 155);

            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);

            String textfrozen = "Keep Frozen -18\u00b0C";
            e.Graphics.DrawString(textfrozen, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 160);


            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 35, 10);
            e.Graphics.DrawString(grupsize, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 35, 35);

            //e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 34, 15);

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
            datalabel = "Asfis";
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

            datalabel = "Lot code";
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
                datalabel = "FT Code: " + certcode;
                e.Graphics.DrawString(datalabel, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 180, 145);
            }

 */ 
        }


        private String getcocode()
        {
            String cocode = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                cocode = data[0][13].ToString();
            }
            return cocode;

        }


        private String get_data_scan()
        {

            String initletter = getcocode();
            String data_case = "";
            if (txtscan.Text.Contains(initletter))
            {
                String data = txtscan.Text.Trim();
                String[] eachdata = data.Split('\n');
                data_case = eachdata[0].ToString().Replace("\r", "");
            }
            return data_case;
        }


        private void txtscan_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (lblcode.Text.Contains("Loin"))
                {
                    //loinnumber = get_data_scan();

                    /*
                    String initletter = getcocode();
                    if (txtscan.Text.Contains(initletter))
                    {
                        txtscan.Focus();
                        String loinno = "";
                        loinno = txtscan.Text;
                        loinno = loinno.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                        generateqrlabel_retouching();
                    }

                    txtscan.Text = "";
                    txtscan.Focus();
                    */

                    if (tipescan == 1)
                    {
                        String initletter = getcocode();
                        if (txtscan.Text.Contains(initletter))
                        {
                            txtscan.Focus();
                            String loinno = "";
                            loinno = txtscan.Text;
                            loinno = loinno.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                            //generateqrlabel_retouching();
                            textBox1.Text = loinno;
                        }
                        numenter = numenter + 1;
                        txtscan.Text = "";
                        txtscan.Focus();
                        textBox2.Text = numenter.ToString();
                    }
                    else if (tipescan == 0)
                    {
                        loinnumber = txtscan.Text;
                        loinnumber = loinnumber.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                        generateqrlabel_retouching();
                        txtscan.Text = "";
                        txtscan.Focus();
                        return;
                    }
                }

                if (lblcode.Text.Contains("Case"))
                {
            

                    if (txtscan.Text.Contains("*"))
                    {

                        String data = txtscan.Text.Trim();
                        String[] eachdata = data.Split('*');
                        String caseno = eachdata[1].ToString();

                        lblcaseno.Text = caseno;
                        generateqrlabel_packing();
                    }

                    txtscan.Text = "";
                    txtscan.Focus();
                }

            }
        }

        public void initial_button_stuffing()
        {
            seticon_forbutton_stuffing();
            btnretouching.Text = "Create PO";
            btnpacking.Text = "Create Stuffing";
            lblHeader.Text = "OPTIONAL";
        }


        public void initial_button()
        {
            seticon_forbutton();
            btnretouching.Text = "Entry Packing";
            btnpacking.Text = "Reprint Label";
            lblHeader.Text = "OPTIONAL";
        }

        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon_top("print", btnpacking);
            frm.setbuttonicon_top("new", btnretouching);
        }


        private void seticon_forbutton_stuffing()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon_top("new", btnpacking);
            frm.setbuttonicon_top("new", btnretouching);
        }

        private void frmReprint_Label_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (lblHeader.Text.Equals("RE-PRINT LABEL") && panellabel.Visible==true)
            {
                panel3.Visible = true;
                panellabel.Visible = false;
                gbreprint.Visible = false;
            }
            else if (lblHeader.Text.Equals("RE-PRINT LABEL") && panel3.Visible == true)
            {
                this.Close();
            }


        }

        private void btnreprint_Click(object sender, EventArgs e)
        {
            generateqrlabel_packing();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCreateBoxLabel frm = new frmCreateBoxLabel();
            frm.ShowDialog();
        }

        private void btncreatelabel_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, btncreatelabel.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void button1_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnnewloin.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnnewloin_Click(object sender, EventArgs e)
        {
            frmCreateNewLoin frm = new frmCreateNewLoin();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCreateNewPacking frm = new frmCreateNewPacking();
            frm.ShowDialog();
        }

        private void button1_Paint_2(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnscan_Click(object sender, EventArgs e)
        {
            tipescan = 0;
            btnscan2.BackColor = Color.LightGray;
            btnscan.BackColor = Color.Orange;
            txtscan.Focus();
        }

        private void btnscan2_Click(object sender, EventArgs e)
        {
            tipescan = 1;
            btnscan2.BackColor = Color.Orange;
            btnscan.BackColor = Color.LightGray;
            txtscan.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Int32 mod1 = Int32.Parse(textBox2.Text) % 8;
            if ((mod1 == 0) || (mod1 == 1))
            {
                loinnumber = textBox1.Text;
                generateqrlabel_retouching();
                numenter = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            var frm = new frmDefrost_Loin();
            frm.Closed += (s, args) => this.Close();
            frm.ShowDialog();
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }


    }
}
