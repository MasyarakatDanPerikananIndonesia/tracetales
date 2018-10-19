using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
    public partial class frmCutting : Form
    {
        //public String grade;
        static bool _continue;
        static bool except = false;
        static bool lock_weight = false;
        static bool scale_on = false;

        public frmCutting()
        {
            InitializeComponent();
        }


        public void setInitialValue(String tipe, String species, String intlotcode, String supplier)
        {
            lblType.Text = tipe.ToString();
            lblSpecies.Text = species.ToString();
            lblInternalcode.Text = intlotcode.ToString();
            lblsupplier.Text = supplier.ToString();

            if (Properties.Settings.Default.module.Equals("CUTTING"))
            {
                lblcutno.Text = "C1-" + intlotcode.ToString();
            }
            else if (Properties.Settings.Default.module.Equals("RETOUCHING"))
            {
                lblcutno.Text = "RT-" + intlotcode.ToString();
            }
            
            DateTime dt = DateTime.Now;
            lblcutdate.Text = dt.ToString("yyyy-MM-dd hh:mm:ss");
            //operator
            lbloperator.Text = Properties.Settings.Default.username;
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





        private void button4_Click(object sender, EventArgs e)
        {
            save_cuttingdet();
            loaddatacutdet();
            loaddatasummary();
            lock_weight = false;
            lbl_locked.Visible = false;
        }

        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }



        private void save_cuttingdet()
        {

            MainMenu frm = new MainMenu();
            if (Properties.Settings.Default.grade == null || Properties.Settings.Default.grade.Equals(""))
            {
                MessageBox.Show(" Please entry Grade");
                return; //to stop process

            } else if (!txtweight.Text.Equals("") && double.Parse(txtweight.Text) > 0)
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
                    "Insert into tbcuttingdetails(intlotcode,cutdate, tipe, grade, cweight, username, moddatetime)" +
                            " values(@intlotcode,@cutdate,  @tipe, @grade, @cweight, @username, @moddatetime)";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@cutdate", DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:ss")));
                    mySql3.Parameters.AddWithValue("@tipe", lblType.Text.Trim());
                    mySql3.Parameters.AddWithValue("@grade", Properties.Settings.Default.grade);
                    double cweight = 0;
                    cweight = double.Parse(txtweight.Text);
                    mySql3.Parameters.AddWithValue("@cweight", cweight);
                    String username;
                    username = Properties.Settings.Default.username; 
                    mySql3.Parameters.AddWithValue("@username", username);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex.Message);
                }
                
                conn5.Close();
            }

            txtweight.Text = "0.00";
            txtweight.Focus();
        }




        public void loaddatacutdet()
        {
            //set grade empty
            String intlotcode = lblInternalcode.Text.Trim();
            //get data from table
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string_byid_desc("tbcuttingdetails", "intlotcode", intlotcode);
            //Type RM
            Int32 no = 0;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    no = data.Count-i;
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (no).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][5].ToString();
                }
            }


            //Image img1 = picedit.Image;
            //Bitmap bmp1 = new Bitmap(img1);
            Edit_columnbutton();
            

            //Image img = pictureBox2.Image;
            //Bitmap bmp = new Bitmap(img);
            Delete_columnbutton();
        }


        public void loaddatasummary_search()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.getsummary_grade_search(intlotcode, "tbcuttingdetails", textBox1.Text.Trim());
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


        public void loaddatasummary()
        {
            String intlotcode = lblInternalcode.Text.Trim();
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.getsummary_grade(intlotcode,"tbcuttingdetails");
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


      
        private void Delete_columnbutton()
        {
                if (dataGridView1.Columns.Contains("Delete") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(4, btn);
                    btn.HeaderText = "Del";
                    btn.Name = "Delete";
                    btn.UseColumnTextForButtonValue = true;
                    btn.Width = 60;
                }
        }


        private void Edit_columnbutton()
        {
                if (dataGridView1.Columns.Contains("Edit") == false)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Insert(3, btn);
                    btn.HeaderText = "Edit";
                    btn.Name = "Edit";
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


        public void loaddatasearch(String value)
        {
            //set grade empty
            String intlotcode = lblInternalcode.Text.Trim();
            //get data from table
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);

            if (value.Equals("") || value == null)
            {
                cmd.CommandText = "select * from tbcuttingdetails where intlotcode=@intlotcode";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
            }
            else
            {
                cmd.CommandText = "select * from tbcuttingdetails where intlotcode=@intlotcode and (grade=@value or cweight=@value)";
                cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
                cmd.Parameters.AddWithValue("@value", value);
            }
            
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
            //Type RM
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {

                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][5].ToString();
                }
            }

            //Image img1 = picedit.Image;
            //Bitmap bmp1 = new Bitmap(img1);
            Edit_columnbutton();

            //Image img = pictureBox2.Image;
            //Bitmap bmp = new Bitmap(img);
            Delete_columnbutton();
        }




        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon_top("save", btnsavecutting);
            frm.setbuttonicon("save", btnsaveedit);
            frm.setbuttonicon("cancel", btncancel);
        }


        private void set_scale_picture()
        {
            var path = Directory.GetCurrentDirectory();
            String icondir = path + "\\icon\\scale.png";
            pbscale.Image = Image.FromFile(icondir);

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


        private void frmCutting_Load(object sender, EventArgs e)
        {

            lbl_locked.Visible = false;
            load_port_name();
            scale_on = false;
            
            seticon_forbutton();
            set_scale_picture();
            panelpad.Visible = false;
            //to display loin
            Properties.Settings.Default.grade = "";
            String txt = "";
            Int32 xPos = 205;
            Int32 yPos = 26;
            MainMenu frm = new MainMenu();
            //get data from table
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbgrade", "module", "cutting");
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    txt=data[i][1].ToString();
                    tombolgrade(100, 60, 22, xPos, yPos, txt, Color.WhiteSmoke);
                    xPos = xPos + 105;
                    //tombolgrade(Int32 width, Int32 height, Int32 fontsize, Int32 xPos, Int32 yPos, String txt, Color btncolor);
                }
            }

            frm.setbuttonicon("search", btnsearch);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            turn_off_icon();
            button3.ForeColor = Color.Red;
            button2.ForeColor = Color.WhiteSmoke;
            txtweight.Text = "0.00";
            panelpad.Visible = true;
            if (scale_on)
            {
                Thread.Sleep(500);
                scale_on = false;
                lblconnect.Visible = false;
                lbl_locked.Visible = false;
                //stop_thread();
            }
        }

/*
        private void stop_thread()
        {
            try
            {
                if (thread.IsAlive)
                {
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

        public void Connect()
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    lblconnect.Visible = true;
                } 
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error: Connection is in use or is not available: \n\n" + e1);
            }
        }

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
*/

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


/*
            turn_off_icon();
            button3.ForeColor = Color.WhiteSmoke;
            button2.ForeColor = Color.LawnGreen;
            txtweight.Text = "0.00";
            panelpad.Visible = false;

            if (!scale_on)
            {
                turn_on_icon();
                scale_on = true;
                _continue = true;
                set_configuration();
                Connect();
                read_indicator();
            }
 */ 
        }





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + " , " + this.dataGridView1.Rows[e.RowIndex].Cells[2].Value + "Kg ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    String intlotcode = lblInternalcode.Text.Trim();
                    
                    MainMenu frm = new MainMenu();
                    List<object[]> data = new List<object[]>();

                    if (textBox1.Text.Equals(""))
                    {
                        data = frm.get_data_table_string_byid_desc("tbcuttingdetails", "intlotcode", intlotcode);
                    }
                    else
                    {
                        data = frm.get_data_table_search("tbcuttingdetails", lblInternalcode.Text.Trim(), textBox1.Text.Trim());
                    }
                    
                    //get_data_table_search(String tablename, String intlotcode, String value)

                  //data = frm.get_data_table_transaction("tbcuttingdetails", intlotcode, "seq1", "seq2");
                    for (int i = 0; i <= n; i++)
                    {
                        if (i == n)
                        {
                            id = Int32.Parse(data[i][0].ToString());
                        }
                    }

                    //frm.delete_table("tbcuttingdetails", "id", id.ToString());
                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText = "update tbcuttingdetails  set tipe=@tipe,grade=@grade,cweight=0,intlotcode=@intlotcode, moddatetime=@moddatetime where id=@id";
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

                    if (textBox1.Text.Equals(""))
                    {
                        loaddatacutdet();
                    }
                    else
                    {
                        loaddatasearch(textBox1.Text.Trim());
                    }
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Edit " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + " , " + this.dataGridView1.Rows[e.RowIndex].Cells[2].Value + "Kg ?", "Edit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    Int32 id = 0;
                    String intlotcode = lblInternalcode.Text.Trim();
                    MainMenu frm = new MainMenu();

                    List<object[]> data = new List<object[]>();
                    if (textBox1.Text.Equals(""))
                    {
                        data = frm.get_data_table_string_byid_desc("tbcuttingdetails", "intlotcode", intlotcode);
                    }
                    else
                    {
                        data = frm.get_data_table_search("tbcuttingdetails", lblInternalcode.Text.Trim(), textBox1.Text.Trim());
                    }
                    
                    for (int i = 0; i <= n; i++)
                    {
                        if (i == n)
                        {
                            id = Int32.Parse(data[i][0].ToString());
                            lblid.Text = id.ToString();
                        }
                    }
                    panel1.Visible = true;
                    txtgrade.Text = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtweightedit.Text = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
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

        private void button6_Click(object sender, EventArgs e)
        {
            save_cutting_edit();

            if (textBox1.Text.Equals(""))
            {
                loaddatacutdet();
            }
            else
            {
                loaddatasearch(textBox1.Text.Trim());
            }
            
            loaddatasummary();
        }

        private void save_cutting_edit()
        {
            MainMenu frm = new MainMenu();
            String intlotcode = lblInternalcode.Text.Trim();
            DateTime dt = DateTime.Now;
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();

            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText = "update tbcuttingdetails  set grade=@grade, cweight=@cweight, moddatetime=@moddatetime where id=@id";
                mySql3.Parameters.AddWithValue("@grade", txtgrade.Text.Trim());
                mySql3.Parameters.AddWithValue("@cweight", Double.Parse(txtweightedit.Text.Trim()));
                mySql3.Parameters.AddWithValue("@id", Int32.Parse(lblid.Text.Trim()));
                dt = DateTime.Now;
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.ExecuteNonQuery();
                MessageBox.Show("Data changes has been stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            finally
            {
                conn5.Close();
                panel1.Visible = false;
                txtgrade.Text = "";
                txtweightedit.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals(""))
            {
                lblsearch.Visible = true;
            }
            else
            {
                lblsearch.Visible = false;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void lblsearch_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loaddatasearch(textBox1.Text.Trim());
                loaddatasummary_search();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            add_column_button(e, "edit", 3);
            add_column_button(e, "delete", 4);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            loaddatasearch(textBox1.Text.Trim());
            loaddatasummary_search();
        }


        private void set_weight_from_Pad(String value)
        {
            if (Double.Parse(txtweight.Text) == 0 )
            {
                if (value.Equals("."))
                {
                    txtweight.Text = "0.";
                }
                else
                {

                    if (txtweight.Text.Equals("0."))
                    {
                        txtweight.Text += value;
                    }
                    else
                    {
                        txtweight.Text = value;
                    }
                }
            }
            else
            {
                txtweight.Text = txtweight.Text + value;
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

        private void delete_from_pad()
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


        private void btn1_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad("0");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            set_weight_from_Pad(".");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            delete_from_pad();
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtweight.Text="0.00";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panelpad.Visible = false;

            save_cuttingdet();
            loaddatacutdet();
            loaddatasummary();
            lock_weight = false;
            lbl_locked.Visible = false;

        }

        private void txtweight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtweight_Validating(object sender, KeyPressEventArgs e)
        {

            
        }

        private void btnback_Click(object sender, EventArgs e)
        {

/*
            if (scale_on == true)
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

        private void txtweight_TextChanged_1(object sender, EventArgs e)
        {
            if (txtweight.Text.Equals(""))
            {
                txtweight.Text = "0.00";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frmReceiving_LoinBox frm = new frmReceiving_LoinBox();
            frm.set_initial(lblInternalcode.Text, lblsupplier.Text);
            frm.display_data();
            frm.ShowDialog();
        }

    }
}
