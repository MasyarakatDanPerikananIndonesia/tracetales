using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;


namespace Tallyfish
{
    public partial class frmReceiving : Form
    {
        static bool _continue;
        static bool except=false;
        static bool lock_weight=false;
        static bool scale_on = false;


        public Boolean scale;
        public Int32 idreceiving;
        //private static String grade;

        public frmReceiving()
        {
            InitializeComponent();
        }

        public void setInitialValue(String tipe, String species, String intlotcode, String rcvno, String rcvdate, String supplier,String opt, Int32 id, String dono)
        {
            lblType.Text = tipe;
            lblSpecies.Text= species;
            lblInternalcode.Text = intlotcode;
            lblrcvno.Text = rcvno;
            lblrcvdate.Text = rcvdate;
            lblsupplier.Text = supplier;
            lbloperator.Text = opt;
            idreceiving = id;
            lbldo.Text = dono;


            String weighttype="";

            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "optionremark", tipe);
            if (data.Count > 0)
            {
                weighttype = data[0][5].ToString();
            }
            lblweighttype.Text = weighttype;
        }

        private void turn_on_icon()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("on", button2);
            frm.setbuttonicon("off", button3);
        }

        private void turn_off_icon()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("off", button2);
            frm.setbuttonicon("off", button3);
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (cbportname.Text.Equals(""))
            {
                MessageBox.Show("Sorry, systems doesn't support feature to capture digital scale values");
                return;
            }

        }


/*
        private Thread thread;

        delegate void UpdatetxtStreamingFromThreadDelegate(String msg);

        protected ManualResetEvent threadStop = new ManualResetEvent(false);

        private void bacaData()
        {
            while (_continue)
            {
                try
                {
                    String message = serialPort1.ReadLine().ToString(); 

                    String data_serialport;
                    if (!message.Equals(""))
                    {
                        data_serialport = RemoveExtraText(message);
                        UpdatetxtStreamingFromThread(data_serialport);
                        //to stop thread
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
 */ 

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

            //txtIndicator.Text = msg;

            /*
            if (!txtstreaming.Text.Equals(""))
            {
                txtstreaming.Text = txtstreaming.Text + "\r\n" + msg;
            }
            else
            {
                txtstreaming.Text = msg;
            }

            if (txtstreaming.TextLength > 200)
            {
                txtstreaming.Text = txtstreaming.Text.Remove(0, txtstreaming.TextLength - 200);
            }
             */ 

        }



        private string RemoveExtraText(string value)
        {
            var allowedChars = "01234567890.";
            return new string(value.Where(c => allowedChars.Contains(c)).ToArray());
        }


/*
        public void read_indicator()
        {
            thread = new Thread(bacaData);
            thread.IsBackground = true;
            thread.Start();
        }


        public void Connect()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    lblconnect.Visible = true;
                    //MessageBox.Show("Connected");
                } // else already open 
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: Connection is in use or is not available: \n\n" + e1);
            }
        }
*/

        public void set_fishno(String intlotcode)
        {
            Int32 fishno = get_loinno(intlotcode);
            fishno = fishno + 1;
            txtloinno.Text = fishno.ToString();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            save_receivingdet();
            loaddatarcvdet();
            set_fishno(lblInternalcode.Text);

            txtweight.Text = "0.00";
            txtweight.Focus();
            lock_weight = false;
            lbl_locked.Visible = false;
        }

        private int get_loinno(String intlotcode)
        {
            Int32 loinno = 0;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select  coalesce(max(fishno),0) as loinno  from tbreceivingdetails where intlotcode=@intlotcode";
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
                loinno = Int32.Parse(data[0][0].ToString());
            }
            return loinno;
        }



        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon_top("save", btnsave);
        }

        private void set_scale_picture()
        {
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\scale.png";
            pbscale.Image = Image.FromFile(icondir);

        }


        public void tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor)
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


        private void save_receivingdet()
        {

            MainMenu frm = new MainMenu();
            if (!txtweight.Text.Equals("") && double.Parse(txtweight.Text) > 0)
            {
                double weight = 0;
                weight = double.Parse(txtweight.Text);

                String intlotcode = lblInternalcode.Text.Trim();
                DateTime dt = DateTime.Now;
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Insert into tbreceivingdetails(idreceiving,intlotcode,fweight,tipe, grade, fishno,moddatetime)" +
                            " values(@idreceiving,@intlotcode,@fweight,@tipe, @grade, @fishno, @moddatetime)";
                    mySql3.Parameters.AddWithValue("@idreceiving", idreceiving);
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@fweight", weight);
                    mySql3.Parameters.AddWithValue("@tipe", lblType.Text.Trim());
                    mySql3.Parameters.AddWithValue("@grade", Properties.Settings.Default.grade);
                    mySql3.Parameters.AddWithValue("@fishno", Int32.Parse(txtloinno.Text));
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error message " + e.Message);
                }
                conn5.Close();
            }

        }

        private void loaddatasummary()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.getsummary_grade(intlotcode,"tbreceivingdetails");
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


        public void loadtotalwrap()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_fieldname("tbreceiving","weightwrap","intlotcode",intlotcode);
            if(data.Count>0)
            {
                lblweightwrap.Text = data[0][0].ToString();
                txtweightwrap.Text = data[0][0].ToString();  
            }
        }





        public void loaddatarcvdet()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_transaction("tbreceivingdetails", intlotcode,"id","");
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {

                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    if (data[i][5] != null)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = data[i][5].ToString();
                    }
                    dataGridView1.Rows[i].Cells[2].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][7].ToString();

                }
            }
            Delete_columnbutton();

            //load data summary
            loaddatasummary();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }
            
            
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && dataGridView1.Rows.Count>0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Value " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    String intlotcode = lblInternalcode.Text.Trim();
                    MainMenu frm = new MainMenu();
                    List<object[]> data = new List<object[]>();
                    data = frm.get_data_table_transaction("tbreceivingdetails", intlotcode, "id", "");

                    for (int i = 0; i <= n; i++)
                    {
                        if (i == n)
                        {
                            id = Int32.Parse(data[i][0].ToString());
                        }
                    }


                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText = "update tbreceivingdetails  set tipe=@tipe,grade=@grade,fweight=0,intlotcode=@intlotcode, moddatetime=@moddatetime where id=@id";
                        mySql3.Parameters.AddWithValue("@tipe", "");
                        mySql3.Parameters.AddWithValue("@grade", "");
                        mySql3.Parameters.AddWithValue("@intlotcode", "4del");
                        mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                        mySql3.Parameters.AddWithValue("@id", id.ToString());
                        mySql3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    loaddatarcvdet();
                }
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

        private void Delete_columnbutton()
        {

            if (dataGridView1.Columns.Contains("Delete") == false)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(4, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 70;
            }

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



        private void frmReceiving_Load(object sender, EventArgs e)
        { // to display button grade
            lbl_locked.Visible = false;
            load_port_name();
            scale_on = false;
            seticon_forbutton();
            set_scale_picture();
            String txt = "";
            Int32 xPos = 183;
            Int32 yPos = 25;
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbgrade", "module", "receiving");
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    txt = data[i][1].ToString();
                    tombolgrade(100, 55, 22, xPos, yPos, txt, Color.WhiteSmoke);
                    xPos = xPos + 101;
                }
            }
            else
            {
                //set initial value for Grade
                txt = "NA";
                Properties.Settings.Default.grade = txt;
                tombolgrade(100, 55, 22, xPos, yPos, txt, Color.WhiteSmoke);
            }
        }

        private void txtweight_TextChanged(object sender, EventArgs e)
        {

        }


        private bool dotalreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }
            return false;
        }

        private void txtweight_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
                                && !char.IsDigit(e.KeyChar)
                                && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (txtweight.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (txtweight.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (dotalreadyExist(txtweight.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (txtweight.SelectionStart != txtweight.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = txtweight.Text.Substring(txtweight.SelectionStart);

                    if (AfterDotString.Length > 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (dotalreadyExist(txtweight.Text, ref sepratorChar))
                {
                    int sepratorPosition = txtweight.Text.IndexOf(sepratorChar);
                    string afterSepratorString = txtweight.Text.Substring(sepratorPosition + 1);
                    if (txtweight.SelectionStart > sepratorPosition && afterSepratorString.Length > 2)
                    {
                        e.Handled = true;
                    }

                }
            }

        }


/*
        private void stop_thread()
        {
            try
            {
                if (thread.IsAlive)
                {

                    //threadStop.Set();

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

*/


        private void button3_Click(object sender, EventArgs e)
        {
            turn_off_icon();
            button3.ForeColor = Color.Red;
            button2.ForeColor = Color.LightGray;
            txtweight.Text = "0.00";
            panelpad.Visible = true;
            lblconnect.Visible = false;
            if (scale_on)
            {
                Thread.Sleep(500);
                scale_on = false;
                //stop_thread();
            }
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text ="1";
            }
            else
            {
                txtweight.Text = txtweight.Text+"1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "2";
            }
            else
            {
                txtweight.Text = txtweight.Text + "2";
            }

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "3";
            }
            else
            {
                txtweight.Text = txtweight.Text + "3";
            }

        }

        private void btn4_Click(object sender, EventArgs e)
        {

            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "4";
            }
            else
            {
                txtweight.Text = txtweight.Text + "4";
            }

        }

        private void btn5_Click(object sender, EventArgs e)
        {

            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "5";
            }
            else
            {
                txtweight.Text = txtweight.Text + "5";
            }

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "6";
            }
            else
            {
                txtweight.Text = txtweight.Text + "6";
            }

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "7";
            }
            else
            {
                txtweight.Text = txtweight.Text + "7";
            }

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "8";
            }
            else
            {
                txtweight.Text = txtweight.Text + "8";
            }

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) == 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = "9";
            }
            else
            {
                txtweight.Text = txtweight.Text + "9";
            }

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (Double.Parse(txtweight.Text) != 0 && !txtweight.Text.Equals("0."))
            {
                txtweight.Text = txtweight.Text + "0";
            }
            else
            {
                txtweight.Text = "0";
            }
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (!txtweight.Text.Contains("."))
            {
                txtweight.Text += ".";
            }

            if (txtweight.Text.Contains("0.0"))
            {
                txtweight.Text = "0.";
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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelpad.Visible = false;

             if(!txtweight.Text.Equals(""))
             {
                 button4_Click(sender, e);
             }

        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtweight.Text = "0.00";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (txtweight.Text.Length > 0)
            {
                if (double.Parse(txtweight.Text) != 0)
                {
                    txtweight.Text = txtweight.Text.Remove(txtweight.Text.Length - 1);
                }
                else
                {
                    txtweight.Text = "0.00";
                }
            }
            else
            {
                txtweight.Text = "0.00";
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 4);
        }

        private void btnback_Click(object sender, EventArgs e)
        {


/*
            if (scale_on== true)
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
                        //serialPort1.Dispose();
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
 */ 
            this.Close();
        }

        private void pbscale_Click(object sender, EventArgs e)
        {
            if (scale_on)
            {
                lock_weight = true;
                lbl_locked.Visible = true;
            }
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

        private void btn_totalloin_Click(object sender, EventArgs e)
        {
            frmReceiving_LoinBox frm = new frmReceiving_LoinBox();
            frm.set_initial(lblInternalcode.Text,lblsupplier.Text);
            frm.ShowDialog();
        }


        private void updateweightwrap()
        {
            MainMenu frm = new MainMenu();
            if (!txtweightwrap.Text.Equals("") && double.Parse(txtweightwrap.Text) > 0)
            {
                String intlotcode = lblInternalcode.Text.Trim();
                DateTime dt = DateTime.Now;
                String connString = Konek();
                MySqlConnection conn5 = new MySqlConnection(connString);
                conn5.Open();

                try
                {
                    MySqlCommand mySql3 = conn5.CreateCommand();
                    mySql3.CommandText =
                    "Update tbreceiving set weightwrap=@weightwrap, moddatetime=@moddatetime where intlotcode=@intlotcode";
                    mySql3.Parameters.AddWithValue("@weightwrap", double.Parse(txtweightwrap.Text));
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error message " + e.Message);
                }
                conn5.Close();
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            updateweightwrap();
            panel8.Visible = false;
            loadtotalwrap();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel8.Visible = true;
            txtweightwrap.Text = "0";
            loadtotalwrap();
        }


    }
}
