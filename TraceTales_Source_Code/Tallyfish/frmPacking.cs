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
    public partial class frmPacking : Form
    {
        private static String boxno;
        private static Boolean printstatus = true;
        private static String globalloinno;

        public frmPacking()
        {
            InitializeComponent();
        }


        public void setInitialValue(String caseno, String sboxno, String grade, String size, String producttype, String productsize)
        {
            lblcaseno.Text = caseno.Trim();
            lblgrade.Text = grade.Trim();
            lblsize.Text = size.Trim();
            lbloperator.Text = Properties.Settings.Default.username;
            lblspecies.Text = producttype.Trim();
            lblproductsize.Text = productsize.Trim();
            boxno = sboxno;

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            //data = frm.get_data_table_string("tbpacking", "box_number", boxno);
            data = frm.get_data_table_string_fieldname("tbpacking", " intlotcode,best_before_date ", "box_number", boxno);
            if (data.Count > 0 && !boxno.Equals(""))
            {
                //lblintlotcode.Text = data[0][5].ToString();
                lblintlotcode.Text = data[0][0].ToString();
                if (data[0][1].ToString().Contains("1900"))
                {
                    lblexpdate.Text = "";
                }
                else
                {
                    DateTime expdate = DateTime.Parse(data[0][1].ToString());
                    lblexpdate.Text = expdate.ToString("yyyy-MM-dd");
                }
            }
        }


        private void loadloindetails(String boxno)
        {
            if (boxno.Equals(""))
            {
                return;
            }

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            
            //data=frm.get_data_table_string("tbretouchingdetails","box_number",boxno);

            data = frm.get_list_data_table_retouching_datetime_desc(boxno);

            double netweight = 0;
            Int32 pieces = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            Int32 count = data.Count;
            if (data.Count > 0)
            {
                pieces = data.Count;
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {

                    String size = data[i][5].ToString(); 
                    /*
                    if (Double.Parse(data[0][5].ToString()) > 2.275)
                    {
                        size = "5 lbs UP";
                    }
                    else
                    {
                        size = "3-5 lbs";
                    }
                    */

                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (pieces - i).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = size;
                    dataGridView1.Rows[i].Cells[4].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][4].ToString();
                }
            }

            Delete_columnbutton();
            Print_columnbutton();

            Int32 totalpcs = dataGridView1.Rows.Count;
            lblpcs.Text = pieces.ToString();
            lblnweight.Text = get_total_weight_packing(lblcaseno.Text).ToString();
            lblnweight1.Text = get_total_weight_packing(lblcaseno.Text).ToString();
            if (get_net_weight(lblcaseno.Text) > 0 && get_total_weight_packing(lblcaseno.Text) <= get_net_weight(lblcaseno.Text))
            {
                double sisa = get_net_weight(lblcaseno.Text) - get_total_weight_packing(lblcaseno.Text);
                String strsisa = Math.Round(sisa, 2).ToString();
                lblremains.Text = "Remains weight to load " + strsisa + " Kg";
            }
            else
            {
                lblremains.Text = "-";
            }
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        }


        private void loadloindetails_partial(String boxno, Int32 limit)
        {
            if (boxno.Equals(""))
            {
                return;
            }

            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();

            //data=frm.get_data_table_string("tbretouchingdetails","box_number",boxno);

            data = frm.get_list_data_table_retouching_datetime_desc(boxno);

            double netweight = 0;
            Int32 pieces = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            Int32 count = data.Count;
            Int32 batas = 0;
            if (data.Count > 0)
            {
                pieces = data.Count;

                if (data.Count < limit)
                {
                    batas = data.Count;
                }
                else
                {
                    batas = limit;
                }

                dataGridView1.Rows.Add(batas);
                for (int i = 0; i < batas; i++)
                {

                    String size = data[i][5].ToString();
                    /*
                    if (Double.Parse(data[0][5].ToString()) > 2.275)
                    {
                        size = "5 lbs UP";
                    }
                    else
                    {
                        size = "3-5 lbs";
                    }
                    */

                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (data.Count-i).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = size;
                    dataGridView1.Rows[i].Cells[4].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][4].ToString();
                }
            }

            Delete_columnbutton();
            Print_columnbutton();

            Int32 totalpcs = dataGridView1.Rows.Count;
            lblpcs.Text = pieces.ToString();
            lblnweight.Text = get_total_weight_packing(lblcaseno.Text).ToString();
            lblnweight1.Text = get_total_weight_packing(lblcaseno.Text).ToString();
            if (get_net_weight(lblcaseno.Text) > 0 && get_total_weight_packing(lblcaseno.Text) <= get_net_weight(lblcaseno.Text))
            {
                double sisa = get_net_weight(lblcaseno.Text) - get_total_weight_packing(lblcaseno.Text);
                String strsisa = Math.Round(sisa, 2).ToString();
                lblremains.Text = "Remains weight to load " + strsisa + " Kg";
            }
            else
            {
                lblremains.Text = "-";
            }
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
        }
		



        private double get_total_weight_packing(String caseno)
        {
            double netweight = 0;
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            String intlotcode = "";
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select sum(a.rweight) as totalweight, a.box_number from tbretouchingdetails a join tbpacking b on a.box_number=b.box_number where b.case_number=@caseno";
            cmd.Parameters.AddWithValue("@caseno", caseno);
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
            if (data.Count > 0 )
            {
                if (!data[0][1].ToString().Equals(""))
                {
                    netweight = double.Parse(data[0][0].ToString());
                }

            }
            return netweight;
        }
		
		
	
		
        private double get_net_weight(String caseno)
        {
            double netweight = 0;
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            String intlotcode = "";
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select b.netweight from tbpacking a join tbproductsetup b on a.productname = b.productname where a.case_number=@caseno";
            cmd.Parameters.AddWithValue("@caseno", caseno);
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
            
            if (data.Count > 0)
            {
                netweight = double.Parse(data[0][0].ToString());
            }
            conn3.Close();
            return netweight;
        }



        private void Delete_columnbutton(Bitmap image)
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Image = image;
                iconColumn.Name = "Delete";
                iconColumn.HeaderText = "Del";
                dataGridView1.Columns.Insert(7, iconColumn);
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                iconColumn.Width = 60;
            }
        }


        private String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }



        private String get_boxno_from_case(String caseno)
        {
            String boxno = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();

            //data = frm.get_data_table_string("tbpacking", "case_number", caseno);
            data = frm.get_data_table_string_fieldname("tbpacking","box_number", "case_number", caseno);
            if (data.Count > 0)
            {
                boxno = data[0][0].ToString();
            }
            return boxno;
        }


        private String check_loin_isallocated(String loin)
        {

            String caseno="";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_caseno_from_loin(loin);
            if (data.Count > 0)
            {
                caseno = data[0][0].ToString();
            }
            return caseno;
        }



        private Boolean check_loin_available(String loin)
        {

            Boolean available = false;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data = frm.get_data_table_string("tbretouchingdetails", "loin_number", loin);
            data = frm.get_data_table_string_fieldname("tbretouchingdetails", "id", "loin_number", loin);
            if (data.Count > 0)
            {
                available = true;
            }
            return available;
        }



        private void scanloin(String loin_number)
        {
            MainMenu frm = new MainMenu();
            loin_number = loin_number.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            String casenumber="";
            casenumber = check_loin_isallocated(loin_number);
            if (casenumber.Length > 0)
            {
                //MessageBox.Show("Loin " + loin_number + "  has been allocated in case number " + casenumber);
                lblwarning.Text = "Loin " + loin_number + " has been allocated in case: " + casenumber;
             
            }
            else
            {
                lblwarning.Text = "";
                Boolean loin_avail=false;
                loin_avail = check_loin_available(loin_number);

                if (loin_avail == true)
                {
                    //String boxno = get_boxno_from_case(lblcaseno.Text.Trim());
                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();

                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText =
                        "update tbretouchingdetails set box_number=@box_number, moddatetime=@moddatetime where loin_number=@loin_number";
                        mySql3.Parameters.AddWithValue("@box_number", boxno);
                        DateTime dt = DateTime.Now;
                        String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        DateTime currdate = DateTime.Parse(cdate);
                        mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                        mySql3.Parameters.AddWithValue("@loin_number", loin_number);
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

                    //update data header
                    update_header_packing();
                }
                else if (loin_avail == false)
                {
                    lblwarning.Text = "Mismatch loin number or loin " + loin_number + "  has not available ";
                }
            }
        }


        public void set_id_product(String species)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbproductsetup","productname",species.Trim());
            Properties.Settings.Default.id_species_product_setup=data[0][1].ToString();          
        }



        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("print", btnprintlabel);
            frm.setbuttonicon("print", btnprinton);
            frm.setbuttonicon("print", btnprintoff);
        }



        private void frmPacking_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            loadloindetails(boxno);
            txtscan.Focus();
        }

        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(7, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void Print_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Print") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btn);
                btn.HeaderText = "Print";
                btn.Name = "Print";
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


        private void txtscan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                String initletter = lblcaseno.Text.Substring(0, 2);
                String loinno = "";
                if (txtscan.Text.Contains(initletter))
                {
                    loinno = txtscan.Text;
                    loinno = loinno.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                    String casenumber = check_loin_isallocated(loinno);
                    casenumber = casenumber.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                    if (casenumber.Length > 0)
                    {
                        lblwarning.Text = "Loin " + loinno + "  has been allocated in case: " + casenumber;
                        //return;
                    }
                    else
                    {
                        scanloin(loinno);
                        //loadloindetails_partial(boxno,5);
                        loadloindetails(boxno);
                    }

                }
                 
                txtscan.Text = "";
                txtscan.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainMenu frm = new MainMenu();
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }

            if (e.ColumnIndex == 8 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                globalloinno = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                generateqrlabel_retouching();
            }

            if (e.ColumnIndex == 7 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Apakah anda yakin mendelete " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    String loin_number = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String boxkosong = "";
                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText =
                        "update tbretouchingdetails set box_number=@box_number, moddatetime=@moddatetime where loin_number=@loin_number";
                        mySql3.Parameters.AddWithValue("@box_number", boxkosong);
                        mySql3.Parameters.AddWithValue("@loin_number", loin_number);
                        DateTime dt = DateTime.Now;
                        String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        DateTime currdate = DateTime.Parse(cdate);
                        mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                        mySql3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message " + ex.Message);
                    }
                    conn5.Close();
                    this.loadloindetails(boxno);
                    if (dataGridView1.Rows.Count == 0)
                    {

                        update_header_packing();
                    }
                    txtscan.Focus();
                }
            }

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
            String case_number = lblcaseno.Text;
            String size = lblsize.Text;
            String grade = lblgrade.Text;
            String box_number = "";
            String pieces = "";
            String boxweight = "";
            String lotnumber = "";
            String suppcode = "";
            String intlotcode = "";
            String areacode = "";
            String expireddate="";
            String fishingground = "";
            String proddate = "";
            String box4dg = "";
            String certcode = "";
            String species = "";

            String id_species = "";
            String packingbox = "";
            String producttype = "";
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
                box_number=data[0][8].ToString();
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
                box4dg = Right4dg(box_number, 4);
                certcode = data[0][6].ToString();
                id_species = data[0][16].ToString();
            }


            String companyreg = "";
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                companyreg = data[0][15].ToString();
            }

            
            data = frm.get_data_table_id("tbproductsetup", Int32.Parse(id_species));
            if (data.Count > 0)
            {
                packingbox = data[0][3].ToString();
                producttype = data[0][5].ToString();
                species = data[0][4].ToString();
            }


            data = frm.get_data_table_string("tbspecies","speciesname",species.Trim());
            if(data.Count>0)
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
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + certcode + "\r\n" + processedby + "\r\n" + addresscompany ;
            }
            else
            {
                dataqr = case_number + "\r\n" + producttype + "\r\n" + scientificname + "\r\n" + packingbox + "\r\n" + grade + "\r\n" + size + "\r\n" + boxweight + "\r\n" + pieces + "\r\n" + origin + "\r\n" + intlotcode + "\r\n" + expireddate + "\r\n" + processedby + "\r\n" + addresscompany ;
            }

            dataqr = dataqr.Trim() + "\r\n" + "*" + case_number + "*" + "\r\n";
            var result = new Bitmap(qr.Write(dataqr));
            pblabel.Image = result;

            for (int i = 0; i < 2; i++)
            {
                printlabel();
            }
        }


        public static string Right4dg(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
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

/*
            doc.Print();
            doc.Dispose();


/*
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            //dlgSettings.PrinterSettings.Copies = 2;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
            doc.Dispose();
*/

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


            String intlotcode = "";
            String loincode = globalloinno;
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
                MessageBox.Show("Loin Number " + loincode + " tidak tersedia di sistem");
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


            String qrtext = loincode + "\r\nAsfis: " + asfis + "\r\ngrade: " + grade + "\r\nweight: " + rweight.ToString() + "Kg\r\n" + origin + "\r\nfishing_ground: " + fishing_ground + "\r\n" + intlotcode + "\r\n" + remark;

            var result = new Bitmap(qr.Write(qrtext));
            pblabel.Image = result;
            printlabel("retouching");
        }


        private void printlabel(String module)
        {
            PrintDocument doc = new PrintDocument();

            doc.PrintPage += this.Doc_PrintPage_retouching;
            doc.DefaultPageSettings.PaperSize = new PaperSize("100 x 50 mm", 393, 196);

            PrintPreviewDialog pd = new PrintPreviewDialog();
            pd.Document = doc;
            pd.ShowDialog();
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
            data = frm.get_data_table_string("tbretouchingdetails", "loin_number", globalloinno);
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

            String loincode = globalloinno;


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

            //Get Grup Size Retouching
            String grupsize = "";
            data = frm.get_grupsize_loin(rweight);
            if (data.Count > 0)
            {
                grupsize = data[0][0].ToString();
            }

            //Excluded FT from size specific
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();

            String packing = "";
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
            data = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                productname = data[0][2].ToString();
            }

            //e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 30, 155);
            e.Graphics.DrawString(loincode, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 38, 145);

            String textfrozen = "Keep Frozen -18\u00b0C";
            e.Graphics.DrawString(textfrozen, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 150, 160);

            e.Graphics.DrawString(grupsize, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 35, 35);

            e.Graphics.DrawString(grade, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 35, 10);

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


        }


        private void btnprintlabel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnprintlabel.ClientRectangle,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);

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
            String case_number = lblcaseno.Text;
            String size = lblsize.Text;
            String grade = lblgrade.Text;
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
            String box4dg = "";
            String certcode = "";
            String certificate = "";
            String species = "";

            String id_species = "";
            String packingbox = "";
            String producttype = "";
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
                box4dg = Right4dg(box_number, 4);
                certcode = data[0][6].ToString();

                //certificate -- get from receiving
                certificate = get_certificate_fromreceiving(intlotcode);
                
                id_species = data[0][16].ToString();
            }


            //Excluded FT from size specific
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();

            String packing = "";
            data = frm.get_data_table_string_fieldname("tbpackingsize", "packingsize", "excludedft", "1");
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    packing = data[i][0].ToString().Trim();
                    if (packing.Equals(size))
                    {
                        certificate = "";
                    }
                }
            }



            data = frm.get_data_table_id("tbproductsetup", Int32.Parse(id_species));
            if (data.Count > 0)
            {
                packingbox = data[0][3].ToString();
                producttype = data[0][5].ToString();
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
                e.Graphics.DrawRectangle(selPen, 305, 20, 70, 38);
                e.Graphics.DrawString(certificate, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 310, 20);
                selPen.Dispose();
            }

            
            if (!ismix.Equals(""))
            {
                //e.Graphics.DrawString(ismix, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 300, 205);
                e.Graphics.DrawString(batchcode, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 200, 260);
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
            e.Graphics.DrawString(intlotcode, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 16, 205);

            e.Graphics.DrawString("Packing Size", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 240);
            e.Graphics.DrawString(packingbox, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 255);

            e.Graphics.DrawString("Expiry Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 285);
            e.Graphics.DrawString(expireddate, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 16, 300);

            e.Graphics.DrawString("Production Date", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 330);
            e.Graphics.DrawString(proddate, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 16, 345);

            e.Graphics.DrawString("Origin", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 16, 375);
            e.Graphics.DrawString(origin, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 72, 375);


            if (!certcode.Equals("") && !certificate.Equals(""))
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



        private String get_max_intlotcode(String boxno)
        {
            String intlotcode = "";

            if (!boxno.Equals(""))
            {
                List<object[]> data = new List<object[]>();
                String connString = Konek();
                MySqlConnection conn3 = null;
                conn3 = new MySqlConnection(connString);
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);
                //cmd.CommandText = "SELECT intlotcode, totalcount FROM ( select intlotcode, count(intlotcode) as totalcount from tbretouchingdetails where box_number=@boxno group by intlotcode ) s HAVING totalcount = MAX(totalcount)";
                cmd.CommandText = "SELECT intlotcode, totalcount FROM ( select intlotcode, count(intlotcode) as totalcount from tbretouchingdetails where box_number=@boxno group by intlotcode ) s order by totalcount desc";

                cmd.Parameters.AddWithValue("@boxno", boxno);
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
                    intlotcode = data[0][0].ToString();
                }
            }
            return intlotcode;
        }


        private String get_boxweight_pieces(String caseno, String tofind)
        {
            String result = "0";
            if (!caseno.Equals(""))
            {
                List<object[]> data = new List<object[]>();
                String connString = Konek();
                MySqlConnection conn3 = null;
                conn3 = new MySqlConnection(connString);
                conn3.Open();
                MySqlCommand cmd = new MySqlCommand("", conn3);

                if (tofind.Equals("boxweight"))
                {
                    cmd.CommandText = "select sum(a.rweight) as totalweight from tbretouchingdetails a join tbpacking b on a.box_number=b.box_number where b.case_number=@caseno";
                    cmd.Parameters.AddWithValue("@caseno", caseno);

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
                    result = data[0][0].ToString();

                }
                else if (tofind.Equals("pieces"))
                {
                    cmd.CommandText = "select count(a.id) as pieces from tbretouchingdetails a join tbpacking b on a.box_number=b.box_number where b.case_number=@caseno";
                    cmd.Parameters.AddWithValue("@caseno", caseno);
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
                    result = data[0][0].ToString();
                }
            }
            if (result.Equals(""))
            {
                result = "0";
            }
            return result;
         }


        private DateTime getbestbefore(String intlotcode)
        {
            DateTime best_before_date;
            if (!intlotcode.Equals(""))
            {
                DateTime rcvdate = DateTime.Now;
                String species = "";

                List<object[]> data = new List<object[]>();
                MainMenu frm = new MainMenu();
                //data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode.Trim());
                data = frm.get_data_table_string_fieldname("tbreceiving","rcvdate,species", "intlotcode", intlotcode.Trim());
                if (data.Count > 0)
                {
                    rcvdate = DateTime.Parse(data[0][0].ToString());
                    species = data[0][1].ToString();
                }

                best_before_date = rcvdate.AddDays(730);
            }
            else
            {
                best_before_date = new DateTime(1900, 01, 01);
            }
            return best_before_date;
        }


        private void update_header_packing()
        {

            if (lblcaseno.Text.Trim().Equals(""))
            {
                return;
            }


            /*
            String boxno = "";
            List<object[]> dr = new List<object[]>();
            MainMenu fr = new MainMenu();
            dr = fr.get_data_table_string("tbpacking", "case_number", lblcaseno.Text.Trim());
            if (dr.Count > 0)
            {
                boxno = dr[0][1].ToString();
            }
            */
            String intlotcode = "";

            intlotcode = get_max_intlotcode(boxno);

            //get best before
            DateTime bestbeforedate= getbestbefore(intlotcode);
            
            // get pieces
            Int32 pieces = Int32.Parse(get_boxweight_pieces(lblcaseno.Text.Trim(), "pieces"));

            //get boxweight
            double boxweight = double.Parse(get_boxweight_pieces(lblcaseno.Text.Trim(), "boxweight"));

            String certificate = "";
            DateTime rcvdate = new DateTime(1900,01,01);
            String suppcode = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            data = frm.get_data_table_string_fieldname("tbreceiving","supplier,rcvdate,certificate", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                suppcode = data[0][0].ToString();
                rcvdate = DateTime.Parse(data[0][1].ToString());
                certificate = data[0][2].ToString();
                suppcode = suppcode.Substring(4, 3);
            }


            //Excluded FT from size specific
            String packing = "";
            String size = cbsize.Text.Trim();
            data = frm.get_data_table_string_fieldname("tbpackingsize", "packingsize", "excludedft", "1");
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    packing = data[i][0].ToString().Trim();
                    if (packing.Equals(size))
                    {
                        certificate = "";
                    }
                }
            }



            String caseno = lblcaseno.Text.Trim();
            String intlotcode1 = "";
            String areacode = intlotcode.Substring(0, 3);

            //data = frm.get_data_table_string("tbretouchingdetails", "box_number", boxno);
            data = frm.get_data_batch_sequence(boxno);

            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    intlotcode1 = data[i][0].ToString();

                    /*
                    if (areacode.Equals(""))
                    {
                        areacode = intlotcode1.Substring(0, 3);
                    }
                    */

                    if (!areacode.Contains(intlotcode1.Substring(0, 3)))
                    {
                        areacode = areacode+"-"+intlotcode1.Substring(0, 3);
                    }
                }
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update tbpacking set pieces=@pieces,boxweight=@boxweight, suppcode=@suppcode, proddate=@proddate, intlotcode=@intlotcode, best_before_date=@best_before_date, certificate=@certificate, batchcode=@batchcode, moddatetime=@moddatetime where case_number=@case_number";
                mySql3.Parameters.AddWithValue("@pieces", pieces);
                mySql3.Parameters.AddWithValue("@boxweight", boxweight);
                mySql3.Parameters.AddWithValue("@suppcode", suppcode);
                mySql3.Parameters.AddWithValue("@proddate", rcvdate);
                mySql3.Parameters.AddWithValue("@case_number", caseno);
                mySql3.Parameters.AddWithValue("@certificate", certificate);
                mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                mySql3.Parameters.AddWithValue("@best_before_date", bestbeforedate);
                mySql3.Parameters.AddWithValue("@batchcode", areacode);
                DateTime dt = DateTime.Now;
                String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime currdate = DateTime.Parse(cdate);
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }

            conn5.Close();

            lblintlotcode.Text = intlotcode;
            DateTime expdate = bestbeforedate;
            lblexpdate.Text = expdate.ToString("yyyy-MM-dd");

        }

        private double get_uprange_weight_product()
        {
            double nw = 0;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data=frm.get_data_table_string_2param("tbproductsetup","productname", lblspecies.Text.Trim(),"tradeunit",lblproductsize.Text.Trim());
            data = frm.get_data_table_string_2param_fieldname("tbproductsetup", "uprange",  "productname", lblspecies.Text.Trim(), "tradeunit", lblproductsize.Text.Trim());
            if(data.Count>0)
            {
                if (!data[0][0].ToString().Equals(""))
                {
                    //find out uprange
                    nw = double.Parse(data[0][0].ToString());
                }
            }
            return nw;
        }

        private double get_lowerrange_weight_product()
        {
            double nw = 0;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data = frm.get_data_table_string_2param("tbproductsetup", "productname", lblspecies.Text.Trim(), "tradeunit", lblproductsize.Text.Trim());
            data = frm.get_data_table_string_2param_fieldname("tbproductsetup","belowrange", "productname", lblspecies.Text.Trim(), "tradeunit", lblproductsize.Text.Trim());
            if (data.Count > 0)
            {
                if (!data[0][0].ToString().Equals(""))
                {
                    //find out belowrange
                    nw = double.Parse(data[0][0].ToString());
                }
            }
            return nw;
        }

        private void btnprintlabel_Click(object sender, EventArgs e)
        {
            double uprange = get_uprange_weight_product();
            double lowerrange = get_lowerrange_weight_product();
            if (double.Parse(lblnweight.Text) > uprange)
            {
                lblwarning.Text = " Total berat loin melebihi range berat maksimum yang diijinkan : " + uprange + ". Silahkan diganti dengan berat loin yang tepat";
                return;
            }
            else if (double.Parse(lblnweight.Text) < lowerrange)
            {
                lblwarning.Text = " Total berat loin di bawah range berat minimum : " + lowerrange + ". Silahkan tambah loin lagi";
                return;
            }
            else
            {
                update_header_packing();
                generateqrlabel();
            }

            this.Hide();
            var frm = new InputPacking();
            frm.Closed += (s, args) => this.Close();

            InputPacking fc = new InputPacking();
            fc.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            String boxno = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //data = frm.get_data_table_string("tbpacking", "case_number", lblcaseno.Text.Trim());
            data = frm.get_data_table_string_fieldname("tbpacking", "box_number", "case_number", lblcaseno.Text.Trim());
            if (data.Count > 0)
            {
                boxno = data[0][0].ToString();
            }
            loadloindetails(boxno);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 7);
            add_column_button(e, "print", 8);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (lblintlotcode.Text.Length > 7)
            {
                update_header_packing();
            }
            
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

        private void load_gradesize()
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbgrade", "module", "retouching");
            string grade = "";
            cbgrade.Items.Clear();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    grade = data[i][1].ToString();
                    cbgrade.Items.Add(grade);
                }
            }

            data = frm.get_data_table_string("tbpackingsize", "", "");
            string packingsize = "";
            cbsize.Items.Clear();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    packingsize = data[i][1].ToString();
                    cbsize.Items.Add(packingsize);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            if (btnedit.Text.Equals("Edit"))
            {
                load_gradesize();
                cbgrade.Visible = true;
                cbsize.Visible = true;
                btnedit.Text = "Save";
                cbgrade.Text = lblgrade.Text;
                cbsize.Text = lblsize.Text;
            }
            else if (btnedit.Text.Equals("Save"))
            {
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();
                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "update tbpacking set grade=@grade, packingsize=@packingsize, moddatetime=@moddatetime where case_number=@case_number";
                    mySql3.Parameters.AddWithValue("@case_number", lblcaseno.Text.Trim());
                    mySql3.Parameters.AddWithValue("@grade", cbgrade.Text);
                    mySql3.Parameters.AddWithValue("@packingsize", cbsize.Text);
                    DateTime dt = DateTime.Now;
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                conn5.Close();
                lblgrade.Text = cbgrade.Text;
                lblsize.Text = cbsize.Text;
                cbgrade.Visible = false;
                cbsize.Visible = false;
                btnedit.Text = "Edit";
                txtscan.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtscan.Focus();
            frmCreateNewLoin frm = new frmCreateNewLoin();
            frm.ShowDialog();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String boxgrade = lblgrade.Text.Trim();
            String boxsize = lblsize.Text.Trim();

            Int32 i = 0;
            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {
                if (i < dataGridView1.Rows.Count - 1)
                {
                    if (!dataGridView1.Rows[i].Cells[2].Value.ToString().Equals("") && !dataGridView1.Rows[i].Cells[3].Value.ToString().Equals(""))
                    {
                        String loingrade=dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                        String loinsize = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                        String loinsizespace = loinsize.Replace(" ", "");
                        String loingradespace = loingrade.Replace(" ", "");
                        String boxgradespace = boxgrade.Replace(" ", "");
                        String boxsizespace = boxsize.Replace(" ", "");

                        if (!boxgradespace.Equals(loingradespace))
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (!boxsizespace.Equals(loinsizespace)) 
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.Orange;
                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
                i++;
            }
        }

    }
}
