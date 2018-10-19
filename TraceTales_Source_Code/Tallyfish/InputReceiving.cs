using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Tallyfish
{
    public partial class InputReceiving : Form
    {
        public String optspecies="";
        public String tipe, species, certificate = "";
        public String company = "";
        public Boolean isintegration=false;


        public InputReceiving()
        {
            InitializeComponent();
        }

        public void set_supplier_integration(String global_suppcode,object sender, EventArgs e)
        {
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbsupplier", "registration_code", global_suppcode);
            if (data.Count > 0)
            {
                isintegration = true;
                String suppliercode= data[0][2].ToString();
                comboBox1.Text = suppliercode;
                comboBox1_SelectedIndexChanged(sender, e);
            }
        }


        public void load_supplier_all()
        {
            List<object[]> dtsupplier = new List<object[]>();
            MainMenu frm = new MainMenu();
            dtsupplier = frm.get_data_table_string("tbsupplier", "", "");

            for (int i = 0; i < dtsupplier.Count; i++)
            {
                comboBox1.Items.Add(dtsupplier[i][1] + "-" + dtsupplier[i][2] + "-" + dtsupplier[i][15]);
            }

        }
        



        private void InputReceiving_Load(object sender, EventArgs e)
        {

            seticon_forbutton();

            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string_exclude("tbreceiving", "tbretouchingdetails", "intlotcode");
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbexistinglot.Items.Add(dtlot[i][1]);
                }
            }

        }


        void p_Paint(object sender, PaintEventArgs e)
        {
            var current = sender as Button;
            ControlPaint.DrawBorder(e.Graphics, current.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }


        void btnspecies_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            optspecies = current.Text;
            species = optspecies;

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                if (item.Name == "btnspec" + species.ToString())
                {
                    item.BackColor = Color.Orange;
                }
                else if (item.Name.Contains("btnspec"))
                {
                    item.BackColor = Color.LightGray;
                }
            }
        }


        void btntipe_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            optspecies = current.Text;
            tipe= optspecies;
            if (current.BackColor != Color.Orange)
            {
                current.BackColor = Color.Orange;
            }

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                if (item.Name == "btntipe" + tipe.ToString())
                {
                    item.BackColor = Color.Orange;
                }
                else if (item.Name.Contains("btntipe"))
                {
                    item.BackColor = Color.LightGray;
                }
            }
      }


        void cert_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            optspecies = current.Text;
            certificate = optspecies;
            if (current.BackColor != Color.Orange)
            {
                current.BackColor = Color.Orange;
            }
            else if (current.BackColor == Color.Orange)
            {
                current.BackColor = Color.LightGray;
                certificate = "";
                optspecies = "";
            }

        }


        void options_Click(object sender, EventArgs e)
        {
            var current = sender as Button;
            optspecies = current.Text;
            this.company = optspecies;
            if (current.BackColor != Color.Orange)
            {
                current.BackColor = Color.Orange;
            }
            else if (current.BackColor == Color.Orange)
            {
                current.BackColor = Color.LightGray;
                this.company = "";
                optspecies = "";
            }

        }



        private void clear_property_value()
        {
           optspecies="";
           tipe="";
           species="";
           certificate = "";            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear_button_species();
           clear_button_tipe();
           clear_button_certificate();            
           String value = "";
           String[] lines = new String[100];
           clear_property_value();
           String optsuppcode = "";
           if (isintegration)
           {
               optsuppcode = comboBox1.Text;
           }
           else
           {
               value = comboBox1.Text;
               lines = value.Split('-');
               optsuppcode = lines[1];
           }




           //to display species
           optionspeciesdisp( lines, optsuppcode);
           optiontypefishdisp(lines, optsuppcode);
           optioncertificate(lines, optsuppcode);
           optionoptions(lines, optsuppcode);
           tombolreceiving(220, 80, 14, 178, 356, "Create Receiving", Color.Orange);
           Int32 n = 0;
           List<object[]> data= new List<object[]>();
           MainMenu frm = new MainMenu();
           data = frm.get_data_table_string("tbvessel", "suppcode", optsuppcode);
           if (data.Count > 0)
           {
               DateTime dt = DateTime.Now;
               DateTime expdate;
               for (int i = 0; i < data.Count; i++)
               {
                   expdate = DateTime.Parse(data[i][6].ToString());
                   if (expdate < dt && !data[i][6].ToString().Contains("1990"))
                   {
                       n++;
                   }
               }

               lblerror.Text = "";
               if (n > 0)
               {

                   errorProvider1.SetError(comboBox1, "There are " + n.ToString() + " vessel has expired, please check in vessel setup for this supplier");
                   if (isintegration)
                   {
                       lblerror.Text = "There are " + n.ToString() + " vessel has expired in license, \r\n Please click here to check vessel setup for supplier " + comboBox1.Text.ToString();
                   }
                   else
                   {
                       lblerror.Text = "There are " + n.ToString() + " vessel has expired in license, \r\n Please click here to check vessel setup for supplier " + lines[2].ToString();
                   }
               }
           }
           else
           {

               lblerror.Text = "";
               errorProvider1.Dispose();
           }
        }


        public void tombolspec(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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
            btn.Name = "btnspec"+ txt ;
            btn.Click += new EventHandler(btnspecies_Click);
        }




        public void optionspeciesdisp(String[] lines, String optsuppcode)
        {
            List<object[]> dtsupplier = new List<object[]>();
            MainMenu frm = new MainMenu();
            dtsupplier = frm.get_data_table_string("tbsupplier", "suppcode", optsuppcode);

            //Option Species
            String spec = "";
            spec = dtsupplier[0][11].ToString();
            lines = spec.Split(',');

            //filter to get only have value
            lines = lines.Where(s => !String.IsNullOrEmpty(s)).ToArray();


            //Create button based on filter on Supplier
            if (lines.Length > 0)
            {


                int len = lines.Length;
                int xPos = 178;
                int yPos = 66;
                // Declare and assign number of buttons = 26 
                System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[len];
                // Create  Buttons: 
                for (int i = 0; i < len; i++)
                {
                    // Initialize one variable 
                    btnArray[i] = new System.Windows.Forms.Button();
                }

                //Create Label
                int x = 59;
                int y = 80;
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = "SPECIES :";
                lbl.Name = "lblspecies";
                lbl.Left = x;
                lbl.Top = y;
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                panel1.Controls.Add(lbl);


                int n = 0;
                //Create Button
                while (n < len)
                {
                    Color btncolor;

                    if (len == 1)
                    {
                        btncolor = Color.Orange;
                    }
                    else
                    {
                        btncolor = Color.LightGray;
                    }

                    tombolspec(100, 60, 24, xPos, yPos, lines[n].ToString(), btncolor);
                    
                    xPos = xPos + 100;

                    n++;
                }

                if (len == 1)
                {
                    species = lines[0].ToString();
                }

            }
        }


        public void tomboltipefish(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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
            btn.Name = "btntipe" + txt;
            btn.Click += new EventHandler(btntipe_Click);
        }

        

        public void optiontypefishdisp(String[] lines, String optsuppcode)
        {


            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btntipe"))
                {
                    panel1.Controls.Remove(item);
                }
            }

            this.tipe = "";

            List<object[]> dtsupplier = new List<object[]>();
            MainMenu frm = new MainMenu();
            dtsupplier = frm.get_data_table_string("tbsupplier", "suppcode", optsuppcode);

            //Option Species
            String spec = "";
            spec = dtsupplier[0][10].ToString();
            lines = spec.Split(',');

            //filter to get only have value
            lines = lines.Where(s => !String.IsNullOrEmpty(s)).ToArray();


            //Create button based on filter on Supplier
            if (lines.Length > 0)
            {
                int len = lines.Length;
                int xPos = 178;
                int yPos = 130;
                // Declare and assign number of buttons = 26 


                System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[len];
                // Create  Buttons: 
                for (int i = 0; i < len; i++)
                {
                    // Initialize one variable 
                    btnArray[i] = new System.Windows.Forms.Button();
                }

                //Create Label
                int x = 59;
                int y = 150;
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = "TYPE  :";
                lbl.Name = "lbltipe";
                lbl.Left = x;
                lbl.Top = y;
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                panel1.Controls.Add(lbl);

                int n = 0;
                //Create Button
                while (n < len)
                {

                     Color btncolor;
                     if (len == 1)
                    {
                        btncolor = Color.Orange;
                    }
                    else
                    {
                        btncolor = Color.LightGray;
                    }

                    tomboltipefish(100, 60, 24, xPos, yPos, lines[n].ToString(), btncolor);
                    xPos = xPos + 100;
                    n++;
                }

                if (len == 1)
                {
                    this.tipe = lines[0].ToString();
                }
            }
        }




        public void tombolcertificate(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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
            btn.Name = "btncertificate" + txt;
            btn.Click += new EventHandler(cert_Click);
        }


        private void clear_button_species()
        {

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btnspec"))
                {
                    panel1.Controls.Remove(item);
                }
            }


            this.tipe = "";

            foreach (Control item in panel1.Controls.OfType<Label>())
            {
                if (item.Name == "lblspecies")
                {
                    panel1.Controls.Remove(item);
                }
            }

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btnspec"))
                {
                    panel1.Controls.Remove(item);
                }
            }

            panel1.Refresh();
        }



        private void clear_button_tipe()
        {

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btntipe"))
                {
                    panel1.Controls.Remove(item);
                }
            }


            this.tipe = "";

            foreach (Control item in panel1.Controls.OfType<Label>())
            {
                if (item.Name == "lbltipe")
                {
                    panel1.Controls.Remove(item);
                }
            }

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btntipe"))
                {
                    panel1.Controls.Remove(item);
                }
            }

            panel1.Refresh();
       }




        private void clear_button_certificate()
        {
            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                if (item.Name.Contains("btncertificate"))
                {
                    panel1.Controls.Remove(item);
                }
            }

            Properties.Settings.Default.certificate = "";

            foreach (Control item in panel1.Controls.OfType<Label>())
            {
                if (item.Name == "lblcertificate")
                {
                    panel1.Controls.Remove(item);
                }
            }

            foreach (Control item in panel1.Controls.OfType<Button>())
            {
                // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                if (item.Name.Contains("btncertificate"))
                {
                    panel1.Controls.Remove(item);
                }
            }

            panel1.Refresh();
       }


        
        
        public void optioncertificate(String[] lines, String optsuppcode)
        {
            List<object[]> dtsupplier = new List<object[]>();
            MainMenu frm = new MainMenu();
            dtsupplier = frm.get_data_table_string("tbsupplier", "suppcode", optsuppcode);

            //Option Certificate
            String cert = "";
            cert = dtsupplier[0][12].ToString();
            lines = cert.Split(',');

            //filter to get only have value
            lines = lines.Where(s => !String.IsNullOrEmpty(s)).ToArray();


            //Create button based on filter on Supplier
            if (lines.Length > 0)
            {


                int len = lines.Length;
                int xPos = 178;
                int yPos = 196;
                
                // Declare and assign number of buttons = 26 
                System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[len];
                // Create  Buttons: 
                for (int i = 0; i < len; i++)
                {
                    // Initialize one variable 
                    btnArray[i] = new System.Windows.Forms.Button();
                }

                //Create Label
                int x = 59;
                int y = 220;
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = "CERTIFICATE:";
                lbl.Name = "lblcertificate";
                lbl.Left = x;
                lbl.Top = y;
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                panel1.Controls.Add(lbl);

               
                int n = 0;
                //Create Button
                while (n < len)
                {

                    Color btncolor;
                    if (len == 1)
                    {
                        btncolor = Color.Orange;
                    }
                    else
                    {
                        btncolor = Color.LightGray;
                    }
                    tombolcertificate(100, 60, 24, xPos, yPos, lines[n].ToString(), btncolor);
                    xPos = xPos + 100;
                    n++;
                }

                if (len == 1)
                {
                    certificate = lines[0].ToString();
                    Properties.Settings.Default.certificate = certificate;
                    tombolcertificate(100, 60, 24, 178, 196, certificate, Color.Orange);
                }
                 

            }
            else
            {

                
                foreach (Control item in panel1.Controls.OfType<Button>())
                {
                   // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                    if (item.Name.Contains("btncertificate"))
                    {
                        panel1.Controls.Remove(item); 
                    }
                }

                Properties.Settings.Default.certificate = "";

                foreach (Control item in panel1.Controls.OfType<Label>())
                {
                    if (item.Name == "lblcertificate")
                    {
                        panel1.Controls.Remove(item);
                    }
                }

                foreach (Control item in panel1.Controls.OfType<Button>())
                {
                    // if (item.Name == "btncertificate" + Properties.Settings.Default.certificate.ToString())
                    if (item.Name.Contains("btncertificate"))
                    {
                        panel1.Controls.Remove(item);
                    }
                }

                panel1.Refresh();

            }
                    
        }


        public void tomboloptions(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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
            btn.Name = "btnoptions" + txt;
            btn.Click += new EventHandler(options_Click);
        }







        public void optionoptions(String[] lines, String optsuppcode)
        {
            List<object[]> dtsupplier = new List<object[]>();
            MainMenu frm = new MainMenu();
            dtsupplier = frm.get_data_table_string("tbsupplier", "suppcode", optsuppcode);

            //Option Species
            String spec = "";
            spec = dtsupplier[0][21].ToString();
            lines = spec.Split(',');

            //filter to get only have value
            lines = lines.Where(s => !String.IsNullOrEmpty(s)).ToArray();


            //Create button based on filter on Supplier
            if (lines.Length > 0)
            {


                int len = lines.Length;
                int xPos = 178;
                int yPos = 266;
                // Declare and assign number of buttons = 26 
                System.Windows.Forms.Button[] btnArray = new System.Windows.Forms.Button[len];
                // Create  Buttons: 
                for (int i = 0; i < len; i++)
                {
                    // Initialize one variable 
                    btnArray[i] = new System.Windows.Forms.Button();
                }

                //Create Label
                int x = 49;
                int y = 270;
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = "OPTIONS :";
                lbl.Left = x;
                lbl.Top = y;
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                panel1.Controls.Add(lbl);


                int n = 0;
                //Create Button
                while (n < len)
                {

                    Color btncolor;
                    if (len == 1)
                    {
                        btncolor = Color.Orange;
                    }
                    else
                    {
                        btncolor = Color.LightGray;
                    }
                    //tombolcertificate(100, 60, 24, xPos, yPos, lines[n].ToString(), btncolor);
                    tomboloptions(100, 60, 24, xPos, yPos, lines[n].ToString(), btncolor);
                    xPos = xPos + 100;
                    n++;
                }

                if (len == 1)
                {
                    //certificate = lines[0].ToString();
                    //Properties.Settings.Default.certificate = certificate;
                    this.company = lines[0].ToString();
                }

            }
            else
            {

                foreach (Control item in panel1.Controls.OfType<Button>())
                {
                    if (item.Name == "btnoptions" + this.company.ToString())
                    {
                        panel1.Controls.Remove(item);
                    }
                }

            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("open", btnopen);
            frm.setbuttonicon("down", btnselectsupplier);
            frm.setbuttonicon("down", btnlot);
            frm.setbuttonicon("delete", btnclose);
        }



        public void tombolreceiving(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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
            btn.ForeColor = Color.White;
            btn.Name = "btnreceiving" + txt;
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("new", btn);
            btn.Click += new EventHandler(receivingentry);
            btn.Paint += new PaintEventHandler(p_Paint);
        }


        void receivingentry(object sender, EventArgs e)
        {
            if (species == null   || tipe == null)
            {
                MessageBox.Show("Please select option species or type");
                return;
            }


            if (species.Trim().Equals(""))
            {
                MessageBox.Show("Please select option species");
                return;
            }


            String intlotcode="";
            String rcvno="";
            String rcvdate="";
            String supplier="";
            String opt="";
            var current = sender as Button;
            this.Hide();
            var frmReceiving = new frmReceiving();
            frmReceiving.Closed += (s, args) => this.Close();

            //rcv date
            DateTime dt = DateTime.Now;
            rcvdate=dt.ToString("yyyy-MM-dd hh:mm:ss");
            
            // supplier
            supplier = comboBox1.Text.Trim();


           //operator
            opt = Properties.Settings.Default.username;

            //int lot code
            //List<object[]> fdata = new List<object[]>();
            //MainMenu fmain = new MainMenu();
            //fdata = fmain.get_data_table_string("tbcompany", "companyid", "bogi");

            //String typelotcode = "";
            
            DateTime tgl = DateTime.Now;
            int julian;
            String stddate = "";
            julian = tgl.DayOfYear;
            
            String julianstr = julian.ToString();

            if (julianstr.Length == 1)
            {
                julianstr = "00" + julianstr;
            }
            else if (julianstr.Length == 2)
            {
                julianstr = "0" + julianstr;
            }

            stddate = dt.ToString("yy") + julianstr; 


            //stddate = dt.ToString("ddMMyy");
            String[] std = new String[4];
            std = supplier.Split('-');
            String standardcode = std[0] + std[1] + stddate;


            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            
            data = frm.get_data_table_string_2param("tbsetup", "Lotseq", "1", "optionremark", this.tipe);
            String kode1 = "";
            if (data.Count > 0)
            {
                kode1 = data[0][3].ToString();
            }


            data = frm.get_data_table_string_2param("tbsetup", "Lotseq", "2", "optionremark", this.certificate);
             String kode2 = "";
            if (data.Count > 0)
            {

                kode2 = data[0][3].ToString();
            }


            data = frm.get_data_table_string_2param("tbsetup", "Lotseq", "3", "optionremark", this.company);
            String kode3 = "";
            if (data.Count > 0)
            {

                kode3 = data[0][3].ToString();
            }
                       
            //String rcvsequence = frm.get_data_sequence_receiving("tbreceiving", "intlotcode", standardcode);
            intlotcode = standardcode;


            if (!kode1.Equals(""))
            {
                intlotcode = intlotcode + "." + kode1;
            }

            if (!kode2.Equals(""))
            {
                intlotcode = intlotcode + "." + kode2;
            }

            if (!kode3.Equals(""))
            {
                intlotcode = intlotcode + "." + kode3;
            }

            //Certificate
            Properties.Settings.Default.certificate = kode2;

            //Sequence receiving
            Boolean sequence = false;
            List<object[]> data1 = new List<object[]>();
            data1 = frm.get_data_table_string("tbsetup", "category", "receivingsequencenumber");
            if (data1.Count > 0)
            {
                String sequencesetting = data1[0][3].ToString();
                if (sequencesetting.Equals("Y") || sequencesetting.Equals("y"))
                {
                    sequence = true;
                }
            }

            String rcvsequence = "";
            if (sequence)
            {
                rcvsequence = frm.get_data_sequence_receiving("tbreceiving", "intlotcode", intlotcode);
            }



            //If there is receiving sequence
            if (sequence)
            {
                intlotcode = intlotcode + "-" + rcvsequence;
            }


            String dono = txtdono.Text.Trim();

            //rcv no
            rcvno = "R1-" + intlotcode;

            //check data receiving based on intlotcode

            save_receiving(tipe, species, intlotcode, supplier, opt);

            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            Int32 id;
            if (data.Count>0)
            {
                id = Int32.Parse(data[0][0].ToString());
                frmReceiving.setInitialValue(tipe, species, intlotcode, rcvno, rcvdate, supplier, opt, id,dono);
                frmReceiving.loaddatarcvdet();
                frmReceiving.ShowDialog();
            }
        }



        void openreceivingentry(object sender, EventArgs e)
        {
            String intlotcode = cbexistinglot.Text.Trim();
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);

            if (data.Count > 0)
            {
                String tipe=data[0][3].ToString();
                String species = data[0][2].ToString();
                String rcvno = "R1-" + intlotcode;
                String rcvdate = data[0][4].ToString();
                String supplier = data[0][5].ToString();
                String opt = Properties.Settings.Default.username;
                Int32 id = Int32.Parse(data[0][0].ToString());
                String dono = data[0][8].ToString();

                var current = sender as Button;
                this.Hide();
                var frmReceiving = new frmReceiving();
                frmReceiving.Closed += (s, args) => this.Close();

                frmReceiving.setInitialValue(tipe, species, intlotcode, rcvno, rcvdate, supplier, opt, id, dono);
                frmReceiving.loaddatarcvdet();
                frmReceiving.loadtotalwrap();
                frmReceiving.set_fishno(intlotcode);
                frmReceiving.ShowDialog();
            }
        }




        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_receiving(String tipe, String species, String intlotcode, String supplier, String opt)
        {


            String userlog = "";
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);

            //get certificate code
            String suppcode = supplier.Substring(4, 3);
            List<object[]> datasupplier = new List<object[]>();
            datasupplier = frm.get_data_table_string("tbsupplier", "suppcode", suppcode);
            String certificatecode = "";
            if (datasupplier.Count > 0)
            {
                certificatecode = datasupplier[0][13].ToString();
            }


            String status = "Not Ada";
            DateTime dt = DateTime.Now;
            if (data.Count > 0)
            { //bila sdh ada record
                status = "Ada";
            }
            else
            { // bila tidak ada record
                if (species.Trim().Equals(""))
                {
                    species = "YFT";
                }

                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    if (status.Equals("Not Ada"))
                    {
                        userlog = dt.ToString("yyyy-MM-dd hh:mm:ss") + "," + opt + ", rcv creation";
                        mySql3.CommandText =
                        "Insert into tbreceiving(intlotcode,species,tipe,rcvdate,supplier,certificate,delivery_no,username,userlog, certificatecode,moddatetime)" +
                        " values(@intlotcode,@species,@tipe,@rcvdate,@supplier,@certificate,@delivery_no,@username,@userlog,@certificatecode,@moddatetime)";
                    }
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode.Trim());
                    mySql3.Parameters.AddWithValue("@species", species.Trim());
                    mySql3.Parameters.AddWithValue("@tipe", tipe.Trim());
                    mySql3.Parameters.AddWithValue("@rcvdate", DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:ss")));
                    mySql3.Parameters.AddWithValue("@supplier", supplier.Trim());
                    mySql3.Parameters.AddWithValue("@certificate", Properties.Settings.Default.certificate.ToString());
                    mySql3.Parameters.AddWithValue("@delivery_no", txtdono.Text.Trim());
                    mySql3.Parameters.AddWithValue("@username", opt.Trim());
                    mySql3.Parameters.AddWithValue("@userlog", userlog);
                    mySql3.Parameters.AddWithValue("@certificatecode", certificatecode);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }catch (Exception e) 
                {
                    MessageBox.Show("Error message " + e.Message);
                }
                conn5.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openreceivingentry(sender, e);
        }

        private void lblerror_Click(object sender, EventArgs e)
        {
            if (lblerror.Text.Length > 3)
            {
                String value = comboBox1.Text;
                String[] lines = value.Split('-');
                String suppliercode = lines[1];
                String suppname = lines[2];

                frmVessel frm = new frmVessel();
                frm.set_suppcode(suppliercode);
                frm.set_suppname(suppname);
                frm.ShowDialog();
            }



        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }

        private void btnselect_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnselectsupplier.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnlot_Click(object sender, EventArgs e)
        {
            //this.cbexistinglot.DroppedDown = true;
            show_previous_lot();
            gbPreviousLot.Visible = true;
        }


        private void show_previous_lot()
        {
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            dtlot = flot.get_data_table_string_exclude_id_desc("tbreceiving", "tbretouchingdetails", "intlotcode");
            if (dtlot.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(dtlot.Count);
                for (int i = 0; i < dtlot.Count; i++)
                {
                    cbexistinglot.Items.Add(dtlot[i][1]);
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dtlot[i][5].ToString();
                    DateTime dt = DateTime.Parse(dtlot[i][4].ToString());
                    dataGridView1.Rows[i].Cells[2].Value = dt.ToString("yyyy-MM-dd");
                    dataGridView1.Rows[i].Cells[3].Value = dtlot[i][1].ToString();
                }
            }

            Select_columnbutton();
        }

        private void Select_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Select") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(4, btn);
                btn.HeaderText = "Select";
                btn.Name = "Select";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }




        private void btnlot_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnlot.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "select", 4);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
            {
                return;
            }

            if (e.ColumnIndex == 4 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                    Int32 n = e.RowIndex;
                    String intlotcode = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cbexistinglot.Text = intlotcode;
                    gbPreviousLot.Visible = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.gbPreviousLot.Visible = false;
        }

    }
}
