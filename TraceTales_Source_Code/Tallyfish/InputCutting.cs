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
    public partial class InputCutting : Form
    {
        public InputCutting()
        {
            InitializeComponent();
        }

        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("save", btnnew);
            frm.setbuttonicon("open", btnopen);
            frm.setbuttonicon("down", btninternal);
            frm.setbuttonicon("down", btnprevinternal);
            frm.setbuttonicon("down", btnproduct);
            frm.setbuttonicon("delete", btnclose);
        }



        private void InputCutting_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();

            if (Properties.Settings.Default.module.Equals("CUTTING"))
            {
                   dtlot = flot.get_data_table_string_exclude("tbreceiving", "tbcuttingdetails", "intlotcode");
                   btnnew.Text = "Create Cutting";
                   btnopen.Text = "Open Cutting";
                   groupproductname.Visible = false;
            }
            else if (Properties.Settings.Default.module.Equals("RETOUCHING"))
            {
                dtlot = flot.get_data_table_string_exclude("tbcuttingdetails", "tbretouchingdetails", "intlotcode");
                btnnew.Text = "Create Retouching";
                btnopen.Text = "Open Retouching";
                groupproductname.Visible = true;

                List<object[]> data = new List<object[]>();
                data = flot.get_data_table_string("tbproductsetup", "", "");
                if (data.Count > 0)
                {
                    cbproductname.Items.Clear();
                    for (int i = 0; i < data.Count; i++)
                    {
                        cbproductname.Items.Add( data[i][5].ToString().ToUpper());
                    }

                    if (data.Count == 1)
                    {
                        cbproductname.Text = data[0][5].ToString().ToUpper();
                    }
                }
            }

            String previntlotcode = "";            
            if (dtlot.Count > 0)
            {
                for (int i = 0; i < dtlot.Count; i++)
                {
                    if (!previntlotcode.Equals(dtlot[i][1].ToString()))
                    {
                        cbexistinglot.Items.Add(dtlot[i][1]);
                    }
                    previntlotcode = dtlot[i][1].ToString();
                }
            }

            previntlotcode="";
            List<object[]> dtplot = new List<object[]>();
            MainMenu frm = new MainMenu();

            if (Properties.Settings.Default.module.Equals("CUTTING"))
            {
                dtplot = frm.get_data_table_string_exclude("tbcuttingdetails", "tbretouchingdetails", "intlotcode");
                //dtplot = frm.get_data_table_daysearlier(14, "tbcuttingdetails");
            }
            else if (Properties.Settings.Default.module.Equals("RETOUCHING"))
            {
                //dtplot = frm.get_data_table_string_exclude("tbretouchingdetails", "tbpacking", "intlotcode");
                dtplot = frm.get_data_table_daysearlier(7, "tbretouchingdetails");
            }

            String value = "";
            if (dtplot.Count > 0)
            {
                for (int i = 0; i < dtplot.Count; i++)
                {
                    value=dtplot[i][1].ToString();
                    if (!cbprevlotcode.Items.Contains(value))
                    {
                        cbprevlotcode.Items.Add(value);
                    }
                }
            }

        }


        void cuttingentry(object sender, EventArgs e, String intlot)
        {
            String intlotcode = "";
            String cutdate = "";
            String supplier = "";
            String tipe="";
            String species="";

            
            //var current = sender as Button;
            //this.Hide();
            //var frmCutting = new frmCutting();
            //frmCutting.Closed += (s, args) => this.Close();

            //rcv date
            DateTime dt = DateTime.Now;
            cutdate = dt.ToString("yyyy-MM-dd HH:mm tt");

            // supplier
            intlotcode = intlot;


            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            if(data.Count > 0)
            {
               tipe=data[0][3].ToString();
               species=data[0][2].ToString();
               supplier=data[0][5].ToString();
            }

            if (supplier.Equals(""))
            {
                supplier = frm.get_suppliername(intlotcode);
            }

            if (species.Equals(""))
            {
                data = frm.get_data_table_string_byid_desc("tbreceiving", "", "");
                if (data.Count > 0)
                {
                    species = data[0][2].ToString();
                }
            }

            if (tipe.Equals(""))
            {
                data = frm.get_data_table_string("tbcuttingdetails", "intlotcode", intlotcode);
                if (data.Count > 0)
                {
                    tipe = data[0][3].ToString();
                }
            }


/*

            if (supplier.Equals(""))
            {
                data = frm.get_data_table_string("tbcuttingdetails", "intlotcode", intlotcode);
                if (data.Count > 0)
                {
                    tipe = data[0][3].ToString();
                    supplier = frm.get_suppliername(intlotcode);
                }

                data = frm.get_data_table_string_byid_desc("tbreceiving", "", "");
                if (data.Count > 0)
                {
                    species = data[0][2].ToString();
                }
            }
*/

            this.Hide();
            frmCutting fc = new frmCutting();
            fc.Closed += (s, args) => this.Close();

            if (data.Count > 0)
            {
               
                fc.setInitialValue(tipe, species, intlotcode, supplier);
                fc.loaddatacutdet();
                fc.loaddatasummary();
                fc.ShowDialog();
            }
        }


        void retouchingentry(object sender, EventArgs e, String intlot)
        {
            String intlotcode = "";
            String rtcdate = "";
            String supplier = "";
            String tipe = "";
            String species = "";

            //var current = sender as Button;
            //this.Hide();
            //var frmCutting = new frmCutting();
            //frmCutting.Closed += (s, args) => this.Close();

            //rcv date
            DateTime dt = DateTime.Now;
            rtcdate = dt.ToString("yyyy-MM-dd hh:mm:ss");

            // supplier
            intlotcode = intlot;


            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string("tbreceiving", "intlotcode", intlotcode);
            if (data.Count > 0)
            {
                tipe = data[0][3].ToString();
                species = data[0][2].ToString();
                supplier = data[0][5].ToString();
            }

            //get productname
            String productname = "";
            List<object[]> data1 = new List<object[]>();
            data1 = frm.get_data_table_string("tbretouching", "intlotcode", intlotcode);
            if (data1.Count > 0)
            {
                if (data1[0][2].ToString().Length > 0)
                {
                    productname = data1[0][2].ToString();
                }
                else
                {
                    productname = "";
                }
            }

            this.Hide();
            
            frmRetouching fc = new frmRetouching();
            
            fc.Closed += (s, args) => this.Close();

            if (data.Count > 0)
            {
                fc.setInitialValue(tipe, species, intlotcode, supplier, productname);
                fc.loaddatartcdet_partial(10); 
                fc.loaddatasummary();
                fc.ShowDialog();
            }
        }



        public String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void save_retouching_productname()
        {

            String intlotcode = cbexistinglot.Text.Trim();
            String productname = cbproductname.Text.Trim();

            Boolean ada = false;
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string_2param("tbretouching", "intlotcode", intlotcode, "productname", productname);
            if (data.Count > 0)
            {
                ada = true;
            }

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();

            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();

                if (!ada)
                {
                    mySql3.CommandText = "Insert into tbretouching(intlotcode,productname,moddatetime) values(@intlotcode,@productname,@moddatetime)";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    DateTime dt = DateTime.Now;
                    String cdate = dt.ToString("yyyy-MM-dd HH:mm tt");
                    DateTime currdate = DateTime.Parse(cdate);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
                else if (ada)
                {
                    mySql3.CommandText = "Update tbretouching set productname=@productname, moddatetime=@moddatetime  where intlotcode=@intlotcode";
                    mySql3.Parameters.AddWithValue("@intlotcode", intlotcode);
                    mySql3.Parameters.AddWithValue("@productname", productname);
                    DateTime dt = DateTime.Now;
                    String cdate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime currdate = DateTime.Parse(cdate);
                    mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                    mySql3.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }


        public void setmodule()
        {
            lblmodule.Text = Properties.Settings.Default.module;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.module.Equals("CUTTING"))
            {
                cuttingentry(sender, e, cbexistinglot.Text.Trim());
            }
            else if (Properties.Settings.Default.module.Equals("RETOUCHING"))
            {
                //to save productname in retouching
                save_retouching_productname();
                retouchingentry(sender, e, cbexistinglot.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.module.Equals("CUTTING"))
            {
                cuttingentry(sender, e, cbprevlotcode.Text.Trim());
            }
            else if (Properties.Settings.Default.module.Equals("RETOUCHING"))
            {

                retouchingentry(sender, e, cbprevlotcode.Text.Trim());            
            }


        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btninternal_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btninternal.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnproduct_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnproduct.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnprevinternal_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnprevinternal.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btninternal_Click(object sender, EventArgs e)
        {
            //cbexistinglot.DroppedDown = true;
            gblot.Visible = true;
            show_list_lot(Properties.Settings.Default.module, "new");
        }

        private void show_list_lot(String param, String status)
        {
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();
            lblstatus.Text = status;
            if (param.Equals("CUTTING"))
            {

                if (status.Equals("new"))
                {
                    dtlot = flot.get_data_table_string_exclude_id_desc("tbreceiving", "tbretouchingdetails", "intlotcode");
                    if (dtlot.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(dtlot.Count);
                        for (int i = 0; i < dtlot.Count; i++)
                        {
                            dataGridView1.Rows[i].Height = 50;
                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dtlot[i][5].ToString();
                            DateTime dt = DateTime.Parse(dtlot[i][4].ToString());
                            dataGridView1.Rows[i].Cells[2].Value = dt.ToString("yyyy-MM-dd");
                            dataGridView1.Rows[i].Cells[3].Value = dtlot[i][1].ToString();
                        }
                        Select_columnbutton();
                    }
                }
                else if (status.Equals("existing"))
                {

                    dtlot = get_data_cutting_existing();

                    if (dtlot.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(dtlot.Count);
                        for (int i = 0; i < dtlot.Count; i++)
                        {

                            dataGridView1.Rows[i].Height = 50;
                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dtlot[i][0].ToString();
                            DateTime dt = DateTime.Parse(dtlot[i][1].ToString());
                            dataGridView1.Rows[i].Cells[2].Value = dt.ToString("yyyy-MM-dd");
                            dataGridView1.Rows[i].Cells[3].Value = dtlot[i][2].ToString();
                        }
                        Select_columnbutton();
                    }

                }
            }
            else if (param.Equals("RETOUCHING"))
            {
                if (status.Equals("new"))
                {

                    dtlot = get_data_cutting_existing();
                    if (dtlot.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(dtlot.Count);
                        for (int i = 0; i < dtlot.Count; i++)
                        {

                            dataGridView1.Rows[i].Height = 50;
                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dtlot[i][0].ToString();
                            DateTime dt = DateTime.Parse(dtlot[i][1].ToString());
                            dataGridView1.Rows[i].Cells[2].Value = dt.ToString("yyyy-MM-dd");
                            dataGridView1.Rows[i].Cells[3].Value = dtlot[i][2].ToString();
                        }
                        Select_columnbutton();
                    }


                }
                else if (status.Equals("existing"))
                {

                    dtlot=get_data_retouching_existing(12);
                    if (dtlot.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(dtlot.Count);
                        for (int i = 0; i < dtlot.Count; i++)
                        {

                            dataGridView1.Rows[i].Height = 50;
                            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells[1].Value = dtlot[i][0].ToString();
                            DateTime dt = DateTime.Parse(dtlot[i][1].ToString());
                            dataGridView1.Rows[i].Cells[2].Value = dt.ToString("yyyy-MM-dd");
                            dataGridView1.Rows[i].Cells[3].Value = dtlot[i][2].ToString();
                        }
                        Select_columnbutton();
                    }
                }
                
            }
            
        }


        public List<object[]> get_data_retouching_existing(Int32 daysearlier)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(-daysearlier);

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select distinct b.suppname, CAST(a.moddatetime AS DATE) as rtcdate,a.intlotcode from tbretouchingdetails a join tbsupplier b on substring(a.intlotcode,4,3)=b.suppcode  where a.moddatetime >= @dateearlier order by a.id desc";
            cmd.Parameters.AddWithValue("@dateearlier", DaysEarlier);
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
            return data;
        }


        public List<object[]> get_data_cutting_existing()
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();

            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select distinct b.suppname, CAST(a.cutdate AS DATE) as cutdate,a.intlotcode from tbcuttingdetails a join tbsupplier b  on substring(a.intlotcode,4,3)=b.suppcode where a.intlotcode not in ( select intlotcode from tbretouchingdetails ) order by a.id desc";
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
            return data;
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



        private void btnproduct_Click(object sender, EventArgs e)
        {
            cbproductname.DroppedDown = true;
        }

        private void btnprevinternal_Click(object sender, EventArgs e)
        {
            //cbprevlotcode.DroppedDown = true;

            gblot.Visible = true;
            show_list_lot(Properties.Settings.Default.module, "existing");
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
                if (lblstatus.Text.Equals("new"))
                {
                    cbexistinglot.Text = intlotcode;
                }
                else
                {
                    cbprevlotcode.Text = intlotcode;
                }
                gblot.Visible = false;
                lblstatus.Text = "status";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gblot.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
