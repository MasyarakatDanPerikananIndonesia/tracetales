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
    public partial class InputPacking : Form
    {

        public static String intlotcode;
        public static String loinnumber;
        public static String grade;
        public static Double rweight;
        public static String remark;

        public InputPacking()
        {
            InitializeComponent();
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("new", btnnew);
            frm.setbuttonicon("open", btnopen);
            frm.setbuttonicon("down", btntype);
            frm.setbuttonicon("down", btnsize);
            frm.setbuttonicon("down", btnexistingcase);
        }



        private void InputPacking_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            String txt = "";
            Int32 xPos = 173;
            Int32 yPos = 135;//66;



            //Product Type
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            //species
            data = frm.get_data_table_string("tbproductsetup", "", "");
            string producttype = "";
            cbproducttype.Items.Clear();
            if (data.Count > 0)
            {

                for (int i = 0; i < data.Count; i++)
                {
                    producttype = data[i][5].ToString();
                    cbproducttype.Items.Add(producttype);
                }
                if (data.Count == 1)
                {
                    cbproducttype.Text = producttype.Trim();
                }
            }


           
            data = frm.get_data_table_string("tbgrade", "module", "retouching");

            frmRetouching fcut = new frmRetouching();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    txt = data[i][1].ToString();
                    tombolgrade(100, 60, 24, xPos, yPos, txt, Color.WhiteSmoke);
                    xPos = xPos + 104;
                    //tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor);
                }
            }


            txt = "";
            xPos = 173;
            yPos = 205;   //135;
            
            //get data from table
            data = frm.get_data_table_string("tbpackingsize", "", "");

            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    txt = data[i][1].ToString();
                    tombolpackingsize(160, 60, 24, xPos, yPos, txt, Color.WhiteSmoke);
                    xPos = xPos + 164;
                    //tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor);
                }
            }



//Existing packing


            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();

            dtlot = flot.get_data_listpacking_daysearlier(7);
            String previntlotcode = "";       
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    if (!previntlotcode.Equals(dtlot[i][2].ToString()))
                    {
                        cbexistingpacking.Items.Add(dtlot[i][2]);
                    }
                    previntlotcode = dtlot[i][2].ToString();
                }
            }

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
            panel1.Controls.Add(btn); // Let panel hold the Buttons 
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

            foreach (Control item in panel1.Controls.OfType<Button>())
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

        private void tombolpackingsize(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn.Width = width; // Width of button 
            btn.Height = height; // Height of button 
            btn.Font = new Font(btn.Font.FontFamily, fontsize);
            btn.Left = xPos;
            btn.Top = yPos;
            // Add buttons to a Panel: 
            panel1.Controls.Add(btn); // Let panel hold the Buttons 
            btn.Text = txt.ToString();
            btn.BackColor = btncolor;
            btn.Name = "btnpackingsize" + txt;
            btn.Click += new EventHandler(btnpackingsize_Click);
        }

        void btnpackingsize_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            Properties.Settings.Default.packingsize = current.Text;

            //grade = current.Text;

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                if (item.Name == "btnpackingsize" + Properties.Settings.Default.packingsize.ToString())
                {
                    item.BackColor = Color.Orange;
                    item.ForeColor = Color.White;
                }
                else if (item.Name.Contains("btnpackingsize"))
                {
                    item.BackColor = Color.WhiteSmoke;
                    item.ForeColor = Color.Black;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cbproducttype.Text.Equals(""))
            {
                MessageBox.Show("Please fill product type");
                return;
            }

            if (cbproductsize.Text.Equals(""))
            {
                MessageBox.Show("Please fill product size");
                return;
            }
            
            createpacking(sender,e);
        }


        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private static string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }

        private string generateseqno(Int32 urutan)
        {
            String urutanstr = "";

            if (urutan.ToString().Length == 1)
            {
                urutanstr = "000" + urutan.ToString();
            }
            else if (urutan.ToString().Length == 2)
            {
                urutanstr = "00" + urutan.ToString();
            }
            else if (urutan.ToString().Length == 3)
            {
                urutanstr = "0" + urutan.ToString();
            }
            else if (urutan.ToString().Length == 4)
            {
                urutanstr = urutan.ToString();
            }
            return urutanstr;
        }


        private void createpacking(object sender, EventArgs e)
        {
            String opt = Properties.Settings.Default.username;
            String grade=Properties.Settings.Default.grade;
           
            String packingsize=Properties.Settings.Default.packingsize;
            DateTime dt = DateTime.Now;
            int julian = dt.DayOfYear;
            String juliancode = julian.ToString();
            String curryear = DateTime.Now.ToString("yy");

            List<object[]> ft = new List<object[]>();
            MainMenu frm = new MainMenu();
            
            //get sequence box, boxno, caseno, lot_number
            frm = new MainMenu();
            String boxno = frm.get_data_sequence_boxno();
            String caseno = frm.get_data_sequence_caseno();


            /*
            List<object[]> data1 = new List<object[]>();
            do
            {
                data1 = frm.get_data_table_string("tbpacking", "case_number", caseno);
                if (data1.Count > 0)
                {
                    caseno = frm.get_data_sequence_caseno();
                }
            }
            while (data1.Count > 0);
            */


            String lot_number = "L" + caseno;
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                String userlog = dt.ToString("yyyy-MM-dd hh:mm:ss") + "," + opt + ", rcv creation";
                mySql3.CommandText =
                "Insert into tbpacking(box_number,case_number,grade,packingsize,username,moddatetime,lot_number,productname, productpacking)" +
                " values(@box_number,@case_number,@grade,@packingsize,@username,@moddatetime,@lot_number, @productname, @productpacking)";
                mySql3.Parameters.AddWithValue("@box_number", boxno);
                mySql3.Parameters.AddWithValue("@case_number", caseno);
                mySql3.Parameters.AddWithValue("@grade", grade);
                mySql3.Parameters.AddWithValue("@packingsize", packingsize);
                mySql3.Parameters.AddWithValue("@moddatetime", DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm tt")));
                mySql3.Parameters.AddWithValue("@username", opt);
                mySql3.Parameters.AddWithValue("@lot_number", lot_number);
                mySql3.Parameters.AddWithValue("@productname", cbproducttype.Text.Trim());
                mySql3.Parameters.AddWithValue("@productpacking", cbproductsize.Text.Trim());
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            packingentry(sender, e, caseno, boxno, grade, packingsize);
        }


        void packingentry(object sender, EventArgs e, String caseno, String boxno, String grade, String size)
        {

            String producttype = "";
            String productsize = "";
            producttype = cbproducttype.Text.Trim();
            productsize = cbproductsize.Text.Trim();
            var current = sender as Button;
            this.Hide();
            var frmPacking = new frmPacking();
            frmPacking.Closed += (s, args) => this.Close();

            frmPacking fc = new frmPacking();
            fc.setInitialValue(caseno, boxno, grade, size, producttype, productsize);
            fc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String caseno = cbexistingpacking.Text.Trim();
            String boxno = "";
            String grade="";
            String size = "";
            Int32 id_species = 0;
            String opt = Properties.Settings.Default.username;
            String producttype = cbproducttype.Text.Trim();
            String productsize = cbproductsize.Text.Trim();

            List<object[]> dtpacking = new List<object[]>();
            MainMenu frm = new MainMenu();
            // dtpacking = frm.get_data_table_string("tbpacking", "case_number",caseno);
            dtpacking = frm.get_data_table_string_fieldname("tbpacking","box_number, grade, packingsize, id_species,productname,productpacking", "case_number", caseno);
            if (dtpacking.Count > 0)
            {
                boxno = dtpacking[0][0].ToString();
                grade = dtpacking[0][1].ToString();
                size = dtpacking[0][2].ToString();
                id_species = Int32.Parse(dtpacking[0][3].ToString());
                producttype = dtpacking[0][4].ToString();
                productsize = dtpacking[0][5].ToString();
            }

            this.Hide();
            frmPacking fc = new frmPacking();
            fc.Closed += (s, args) => this.Close();

            fc.setInitialValue(caseno, boxno, grade, size, producttype, productsize);
            fc.ShowDialog();
        }

        private void cbproducttype_SelectedIndexChanged(object sender, EventArgs e)
        {

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            //Product Size
            data = frm.get_data_table_string("tbproductsetup", "productname", cbproducttype.Text.Trim());
            string productsize = "";
            cbproductsize.Items.Clear();
            if (data.Count > 0)
            {

                for (int i = 0; i < data.Count; i++)
                {
                    productsize = data[i][3].ToString();
                    cbproductsize.Items.Add(productsize);
                }

                if (data.Count == 1)
                {
                    cbproductsize.Text = productsize.Trim();
                }
            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntype_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btntype.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnsize_Click(object sender, EventArgs e)
        {
            cbproductsize.DroppedDown = true;
        }

        private void btnexistingcase_Click(object sender, EventArgs e)
        {

            this.Hide();
            ListPacking frm = new ListPacking();
            frm.Closed += (s, args) => this.Close();
            frm.set_initial(cbproducttype.Text, cbproductsize.Text);
            frm.ShowDialog();
        }

        private void btnsize_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnsize.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnexistingcase_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnexistingcase.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btntype_Click(object sender, EventArgs e)
        {
            cbproducttype.DroppedDown = true;
        }
   }
}
