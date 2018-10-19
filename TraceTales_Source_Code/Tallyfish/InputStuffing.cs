using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tallyfish
{
    public partial class InputStuffing : Form
    {
        private String plnoglobal, custglobal, poglobal;


        public InputStuffing()
        {
            InitializeComponent();
        }


       public void setoptionpo()
        {

             MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbpo", "status", "open");
            if (data.Count > 0)
            {
                cbpo.Items.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    cbpo.Items.Add(data[i][1].ToString());
                }
            }
        }


       private void setoptionshipterms()
       {

           MainMenu frm = new MainMenu();
           //get data from table
           List<object[]> data = new List<object[]>();
           data = frm.get_data_table_string("tbincoterms", "", "");
           if (data.Count > 0)
           {
               cbshipterms.Items.Clear();
               for (int i = 0; i < data.Count; i++)
               {
                   cbshipterms.Items.Add(data[0][1].ToString());
               }
           }
       }

       private void setoptionexistingpl()
       {

           MainMenu frm = new MainMenu();
           //get data from table
           List<object[]> data = new List<object[]>();
           data = frm.get_data_shipping_unit(1000);
           if (data.Count > 0)
           {
               cbexistingpl.Items.Clear();
               for (int i = 0; i < data.Count; i++)
               {
                   cbexistingpl.Items.Add(data[i][1].ToString());
               }
           }
       }

       private void seticon_forbutton()
       {
           MainMenu frm = new MainMenu();
           frm.setbuttonicon("new", btnnew);
           frm.setbuttonicon("open", btnopen);
           frm.setbuttonicon("edit", btnedit);
           frm.setbuttonicon("down", btnpo);
           frm.setbuttonicon("down", btnship);
           frm.setbuttonicon("down", btndate);
           frm.setbuttonicon("down", button2);
           frm.setbuttonicon("down", btnrecent);
       }
        



        private void InputStuffing_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            setoptionpo();
            setoptionshipterms();
            dateTimePicker1.Value = DateTime.Now;
            setoptionexistingpl();
            txtorigin.Text = "INDONESIA";

        }


        public String get_number_sequence_packinglist()
        {
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            String connString = frm.Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select * from shipping_unit where year(shipdate)=@tahun order by id desc";
            DateTime myDateTime = DateTime.Now;
            Int32 tahun = myDateTime.Year;
            cmd.Parameters.AddWithValue("@tahun",tahun );

            MySqlDataReader rdr = cmd.ExecuteReader();
            int a;

            int temp;
            String pl = "";
            String seq = "";
            Boolean status = false;
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

                pl = rdr.GetString("shipping_unit_number");
                seq=Right(pl,3);
                status = int.TryParse(seq, out temp);

                if (status == true)
                {
                    object[] tempRow = new object[rdr.FieldCount];
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        tempRow[i] = rdr[i];
                    }
                    data.Add(tempRow);
                }
            }




            String plno = "";
            String urut = "";
            Int32 urutint = 0;
            String uruthasil = "";
            if (data.Count > 0)
            {
                plno = data[0][1].ToString();
                urut = Right(plno, 3);
                urutint = Int32.Parse(urut) + 1;


                if (urutint.ToString().Length == 3)
                {
                    uruthasil = urutint.ToString();
                }
                else if (urutint.ToString().Length == 2)
                {
                    uruthasil = "0" + urutint.ToString();
                }
                else if (urutint.ToString().Length == 1)
                {
                    uruthasil = "00" + urutint.ToString();
                }
            }
            else
            {
                uruthasil = "001";
            }

           conn3.Close();
           return uruthasil;
        }

        public static string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }


        public String generatePL()
        {
            String seq = get_number_sequence_packinglist();
            String company = "";
            String plno = "";
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbcompany", "", "");
            if (data.Count > 0)
            {
                company = data[0][1].ToString().Trim();
            }

            DateTime dt = DateTime.Now; // Or whatever
            string formatdate = dt.ToString("yyyy/MM");

            plno = company + "-" + formatdate + "/" + seq;
            return plno;
        }


        private String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_pl()
        {

            if (cbpo.Text.Equals(""))
            {
                MessageBox.Show("Please fill PO");
                return;
            }

            if (txtcustomer.Text.Equals(""))
            {
                MessageBox.Show("Please fill Customer");
                txtcustomer.Focus();
                return;
            }
            if (cbshipterms.Text.Equals(""))
            {
                MessageBox.Show("Please fill Ship Terms");
                return;
            }

            if (txtorigin.Text.Equals(""))
            {
                MessageBox.Show("Please fill Origin");
                txtorigin.Focus();
                return;
            }

            if (checkBox1.Checked)
            {
                if (txtlocalpl.Text.Equals(""))
                {
                    MessageBox.Show("Please fill PL Number");
                    txtlocalpl.Focus();
                    return;
                }
                else
                {
                    MainMenu frm1 = new MainMenu();
                    List<object[]> data1 = new List<object[]>();
                    data1 = frm1.get_data_table_string("shipping_unit", "packingslipno", txtlocalpl.Text.Trim());
                    if (data1.Count > 0)
                    {
                        MessageBox.Show("PL Number " + txtlocalpl.Text.Trim() +" sudah ada, silahkan input PL# yang lain");
                        txtlocalpl.Focus();
                        return;
                    }
                }
             }

            String plno = "";
            if (checkBox1.Checked == false)
            {
                plno = generatePL();
            }
            else
            {
                plno = txtlocalpl.Text.Trim();
            }

            //save in plnoglobal
            plnoglobal = plno;

            String cust = txtcustomer.Text.Trim();
            custglobal = cust;

            String po = cbpo.Text.Trim();
            poglobal = po;

            String shipterm = cbshipterms.Text.Trim();
            String blno = txtblno.Text.Trim();
            DateTime shipdate = dateTimePicker1.Value.Date;
            String origin = txtorigin.Text.Trim();
            String vessel = txtvessel.Text.Trim();
            String voyage = txtvoyage.Text.Trim();
            String container = txtcontainer.Text.Trim();
            String signer = txtsigner.Text.Trim();
            String sealno = txtseal.Text.Trim();
            DateTime etd = dateTimePicker2.Value.Date;
            String shipment = txtshipment.Text.Trim();
            String username = Properties.Settings.Default.username;

            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "Insert into shipping_unit(packingslipno,	po_number,customerid,bill_of_lading,vessel_name,container_number,shipping_unit_number,seal_number,country_origin,shipdate,username,	moddatetime,incoterms,voyage,signer,etd,shipment)" +
                " values(@packingslipno,@po_number,@customerid,@bill_of_lading,@vessel_name,@container_number,@shipping_unit_number,@seal_number,@country_origin,@shipdate,@username,	@moddatetime,@incoterms,@voyage,@signer,@etd,@shipment)";
                mySql3.Parameters.AddWithValue("@packingslipno", plno);
                mySql3.Parameters.AddWithValue("@po_number", po);
                mySql3.Parameters.AddWithValue("@customerid", cust);
                mySql3.Parameters.AddWithValue("@bill_of_lading", blno);
                mySql3.Parameters.AddWithValue("@vessel_name", vessel);
                mySql3.Parameters.AddWithValue("@container_number", container);
                mySql3.Parameters.AddWithValue("@shipping_unit_number", plno);
                mySql3.Parameters.AddWithValue("@seal_number", sealno);
                mySql3.Parameters.AddWithValue("@country_origin", origin);
                mySql3.Parameters.AddWithValue("@shipdate", shipdate);
                mySql3.Parameters.AddWithValue("@etd", etd);
                mySql3.Parameters.AddWithValue("@username", username);
                DateTime dt = DateTime.Now;
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.Parameters.AddWithValue("@incoterms", shipterm);
                mySql3.Parameters.AddWithValue("@voyage", voyage);
                mySql3.Parameters.AddWithValue("@signer", signer);
                mySql3.Parameters.AddWithValue("@shipment", shipment);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

            frmStuffing fc = new frmStuffing();
            fc.setInitial(plnoglobal, custglobal, poglobal);
            fc.ShowDialog();

        }


        private void update_pl(String plno)
        {
            //save in plnoglobal
            String cust =txtcustomer.Text.Trim();

            String po = cbpo.Text.Trim();
            String shipterm = cbshipterms.Text.Trim();
            String blno = txtblno.Text.Trim();
            DateTime shipdate = dateTimePicker1.Value.Date;
            DateTime etd= dateTimePicker2.Value.Date;
            String origin = txtorigin.Text.Trim();
            String vessel = txtvessel.Text.Trim();
            String voyage = txtvoyage.Text.Trim();
            String container = txtcontainer.Text.Trim();
            String signer = txtsigner.Text.Trim();
            String sealno = txtseal.Text.Trim();
            String shipment = txtshipment.Text.Trim();
            String username = Properties.Settings.Default.username;

            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update shipping_unit set po_number=@po,customerid=@cust, bill_of_lading=@blno,vessel_name=@vessel ,container_number=@container, seal_number=@sealno, country_origin=@origin, shipdate=@shipdate, moddatetime=@moddatetime,incoterms=@shipterm,voyage=@voyage,signer=@signer, etd=@etd,shipment=@shipment where packingslipno=@plno";
                mySql3.Parameters.AddWithValue("@plno", plno);
                mySql3.Parameters.AddWithValue("@po", po);
                mySql3.Parameters.AddWithValue("@cust", cust);
                mySql3.Parameters.AddWithValue("@blno", blno);
                mySql3.Parameters.AddWithValue("@vessel", vessel);
                mySql3.Parameters.AddWithValue("@container", container);
                mySql3.Parameters.AddWithValue("@sealno", sealno);
                mySql3.Parameters.AddWithValue("@origin", origin);
                mySql3.Parameters.AddWithValue("@shipdate", shipdate);
                mySql3.Parameters.AddWithValue("@etd", etd);
                DateTime dt = DateTime.Now;
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.Parameters.AddWithValue("@shipterm", shipterm);
                mySql3.Parameters.AddWithValue("@shipment", shipment);
                mySql3.Parameters.AddWithValue("@voyage", voyage);
                mySql3.Parameters.AddWithValue("@signer", signer);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }


        private void clear_entry()
        {
            cbpo.Text = "";
            txtcustomer.Text = "";
            cbshipterms.Text = "";
            txtorigin.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            txtvessel.Text = "";
            txtvoyage.Text = "";
            txtcontainer.Text = "";
            txtseal.Text = "";
            txtblno.Text = "";
            txtsigner.Text = "";
            txtshipment.Text = "";
        }

        private void validate_input()
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (btnnew.Text.Contains("Save"))
            {
                String plno = cbexistingpl.Text.Trim();
                update_pl(plno);
                MessageBox.Show("Data has been stored");
                clear_entry();
                btnnew.Text = "Create Packing List";
                return;
            }
            else
            {
                save_pl();
                /*
                var current = sender as Button;
                this.Hide();
                var frmStuffing = new frmStuffing();
                frmStuffing.Closed += (s, args) => this.Close();
                */

            }
        }

        private void cbcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            List<object[]> datacust = new List<object[]>();
            String cust = "";
            data = frm.get_data_table_string("tbpo","pono",cbpo.Text.Trim());
            if (data.Count > 0)
            {
                cust = data[0][2].ToString();
                txtcustomer.Text = data[0][2].ToString();
                datacust = frm.get_data_table_string("tbcustomer", "custcode", cust);
                if (datacust.Count > 0)
                {
                    lblCustomername.Text = datacust[0][2].ToString();
                }
            }
        }

        private void cbshipterms_SelectedIndexChanged(object sender, EventArgs e)
        {

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbincoterms", "incoterms", cbshipterms.Text.Trim());
            if (data.Count > 0)
            {
                lblshipterms.Text = data[0][2].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            custglobal = "";
            poglobal = "";
            plnoglobal = cbexistingpl.Text;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("shipping_unit","packingslipno",plnoglobal);
            if(data.Count>0)
            {
                custglobal=data[0][3].ToString();
                poglobal = data[0][2].ToString();
            }

            //var current = sender as Button;
            //this.Hide();
            //var frmStuffing = new frmStuffing();
            //frmStuffing.Closed += (s, args) => this.Close();

            frmStuffing fc = new frmStuffing();
            fc.setInitial(plnoglobal, custglobal, poglobal);
            fc.loadpackingdetails(plnoglobal);
            fc.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtblno_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (cbexistingpl.Text.Equals(""))
            {

                MessageBox.Show("Please select packing list");
                cbexistingpl.Focus();
                return;
            }

            
            String plno = "";
            plno = cbexistingpl.Text.Trim();
            List<object[]> data = new List<object[]>();
            List<object[]> datacust = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("shipping_unit", "packingslipno", plno);
            if (data.Count > 0)
            {
                txtcustomer.Text=data[0][3].ToString();
                datacust = frm.get_data_table_string("tbcustomer", "custcode", txtcustomer.Text.Trim());
                lblCustomername.Text = datacust[0][2].ToString();
                cbpo.Text = data[0][2].ToString();
                cbshipterms.Text = data[0][14].ToString();
                datacust = frm.get_data_table_string("tbincoterms", "incoterms", cbshipterms.Text.Trim());
                if (data.Count > 0)
                {
                    lblshipterms.Text = data[0][2].ToString();
                }
                dateTimePicker1.Value = DateTime.Parse(data[0][11].ToString());
                txtorigin.Text = data[0][10].ToString();
                txtvessel.Text = data[0][5].ToString();
                txtvoyage.Text = data[0][15].ToString();
                txtcontainer.Text = data[0][6].ToString();
                txtseal.Text = data[0][9].ToString();
                txtblno.Text = data[0][4].ToString();
                txtsigner.Text = data[0][16].ToString();
                txtshipment.Text = data[0][19].ToString();
                dateTimePicker2.Value = DateTime.Parse(data[0][18].ToString());
            }
            btnnew.Text = "Save Packing List";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            var frm = new frmPO();
            //frm.Closed += (s, args) => this.Close();
            frm.ShowDialog();
        }

        private void btnpo_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpo.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnship_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnship.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);


        }

        private void btnpo_Click(object sender, EventArgs e)
        {
            setoptionpo();
            cbpo.DroppedDown = true;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnship_Click(object sender, EventArgs e)
        {
             cbshipterms.DroppedDown = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dateTimePicker1.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void btndate_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btndate.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);

        }

        private void btnrecent_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnrecent.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnrecent_Click(object sender, EventArgs e)
        {
            setoptionexistingpl();
            cbexistingpl.DroppedDown = true;
        }

        private void cbpo_Validated(object sender, EventArgs e)
        {
            txtcustomer.Focus();
        }

        private void txtcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                cbshipterms.Focus();
            }
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            txtorigin.Focus();
        }

        private void txtvessel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtvoyage.Focus();
            }
        }

        private void txtvoyage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtcontainer.Focus();
            }
        }

        private void txtcontainer_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtseal.Focus();
            }
        }

        private void txtseal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtblno.Focus();
            }
        }

        private void txtblno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtsigner.Focus();
            }
        }

        private void txtsigner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnnew.Focus();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel4.Visible = true;
                txtlocalpl.Focus();
            }
            else
            {
                panel4.Visible = false;
            }
        }

        private void cbexistingpl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dateTimePicker2.Select();
            SendKeys.Send("%{DOWN}");
        }

    }
}
