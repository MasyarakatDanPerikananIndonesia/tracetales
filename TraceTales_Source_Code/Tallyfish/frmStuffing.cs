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
    public partial class frmStuffing : Form
    {
        public String companycode = "";
        public frmStuffing()
        {
            InitializeComponent();
        }

        public void setInitial(String pl, String cust, String po)
        {
            lblpackinglist.Text = pl;
            lblshipto.Text = cust;
            lblpo.Text = po;
            display_closed_button(pl);
            
        }

        private String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void frmStuffing_Load(object sender, EventArgs e)
        {
            txtscan.Focus();
        }

        private void txtscan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }




        private void scanpacking(String packing)
        {
            lblMessage.Text = "";
            lblMessage.Text = packing;
            
            packing=packing.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            //lblMessage.Text = packing;
             


            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();

            //Get Box No
            String boxno = "";
            data = frm.get_data_table_string_fieldname("tbpacking","box_number", "case_number", packing);
            if (data.Count > 0)
            {
                boxno = data[0][0].ToString();
            }

            //Check Shipping Number
            data = frm.get_data_table_string_fieldname("tbpacking","shipping_unit_number", "case_number", packing);
            if (data.Count > 0)
            {
                String shipno = data[0][0].ToString();
                if(!shipno.Equals(""))
                {
                    lblMessage.Text = "Case No " + packing + " has been loaded to " + shipno + ". Please scan another case_number";
                    return;
                }else
                {
                    String batchno = frm.get_batch_number(boxno);

                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText =
                        "update tbpacking set shipping_unit_number=@shipping_unit_number, remark=@remark, batchcode=@batchcode,moddatetime=@moddatetime where case_number=@case_number";
                        mySql3.Parameters.AddWithValue("@shipping_unit_number", lblpackinglist.Text.Trim());
                        mySql3.Parameters.AddWithValue("@case_number", packing);
                        mySql3.Parameters.AddWithValue("@batchcode", batchno);
                        mySql3.Parameters.AddWithValue("@remark", txtremark.Text.Trim());
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
                }
            }
            else
            {
                lblMessage.Text = "Case No " + packing + " is not available. Please scan another case_number";
                return;
            }
             
        }

        private void set_packinglist(String plno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            
            MySqlCommand mySql3 = conn5.CreateCommand();
            /*
            mySql3.CommandText =
            "delete from tbpackinglistdetails where plno=@plno";
            mySql3.Parameters.AddWithValue("@plno", plno);
            mySql3.ExecuteNonQuery();
            conn5.Close();
            */

            mySql3.CommandText =
            "delete from tbpackinglist where plno=@plno1";
            mySql3.Parameters.AddWithValue("@plno1", plno);
            mySql3.ExecuteNonQuery();
            conn5.Close();

            
            /*
            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "insert into tbpackinglistdetails(plno,customerid,itemcode,productname,grade,size,case_number,loin_number,weight,intlotcode,certificate,certificateid,box_number) ";
                mySql3.CommandText += "select e.shipping_unit_number, f.customerid, g.itemcodesap, e.productname,e.grade, e.packingsize, e.case_number, a.loin_number, a.rweight, a.intlotcode, c.certificate, d.certificateid, a.box_number from tbretouchingdetails a ";
                mySql3.CommandText += "  left outer join tbpacking b on a.box_number = b.box_number left outer join tbreceiving c on a.intlotcode = c.intlotcode left outer join tbcertificate d on c.certificatecode = d.certificatecode ";
                mySql3.CommandText += "  left outer join tbpacking e on e.box_number = a.box_number left outer join shipping_unit f on e.shipping_unit_number = f.shipping_unit_number   ";
                mySql3.CommandText += "  left outer join tbproductsetup_sapcode g on e.productname=g.product and e.grade=g.grade and e.packingsize=g.size and e.certificate = g.certificate   ";
                mySql3.CommandText += " where e.shipping_unit_number = @plno2";
                mySql3.Parameters.AddWithValue("@plno2", plno);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
            */

            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();
                /*
                mySql3.CommandText =
                "insert into tbpackinglist(plno,customerid,batchcode, itemcode, product, grade,size, certificate, qty,total_weight_ctn, unitprice) ";
                mySql3.CommandText += " SELECT a.shipping_unit_number as plno, c.customerid, substr(a.intlotcode,1,3) as batchcode, b.itemcodesap, a.productname, a.grade, a.packingsize, a.certificate, count(a.case_number) as totalpacking, sum(a.boxweight) as total_weight_ctn, b.unitprice  FROM `tbpacking` a left outer join tbproductsetup_sapcode b on a.productname=b.product ";
                mySql3.CommandText += " and a.certificate = b.certificate AND a.grade=b.grade and a.packingsize=b.size left outer join shipping_unit c on a.shipping_unit_number = c.shipping_unit_number left outer join tbproductsetup d on a.productname = d.productname and a.productpacking = d.tradeunit  where a.shipping_unit_number=@plno3  group by a.shipping_unit_number, c.customerid, substr(a.intlotcode,1,3), b.itemcodesap, a.productname, a.grade, a.packingsize, a.certificate ";
                 */

                mySql3.CommandText =
                "insert into tbpackinglist(plno,customerid,itemcode, product, grade,size, certificate, qty,total_weight_ctn, unitprice) ";
                mySql3.CommandText += " SELECT distinct a.shipping_unit_number as plno, c.customerid, b.itemcodesap, a.productname, a.grade, a.packingsize, concat(e.certificate , ' ' , f.certificatecode), count(a.case_number) as totalpacking, round(sum(a.boxweight),2) as total_weight_ctn, b.unitprice  FROM `tbpacking` a join tbreceiving e on a.intlotcode=e.intlotcode left outer join tbproductsetup_sapcode b on a.productname=b.product ";
                mySql3.CommandText += " and e.certificate = b.certificate AND a.grade=b.grade and a.packingsize=b.size left outer join shipping_unit c on a.shipping_unit_number = c.shipping_unit_number left outer join tbproductsetup d on a.productname = d.productname and a.productpacking = d.tradeunit  left outer join tbsupplier f on substr(e.supplier,5,3) = f.suppcode and e.certificate<>'' where a.shipping_unit_number=@plno3  ";
                mySql3.CommandText += " group by a.shipping_unit_number, c.customerid, b.itemcodesap, a.productname, a.grade, a.packingsize, concat(e.certificate , ' ' , f.certificatecode) ";
                mySql3.Parameters.AddWithValue("@plno3", plno);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();


            /*
            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "UPDATE tbpackinglist a INNER JOIN vw_packinglist_totalcarton b ";
                mySql3.CommandText += " ON a.plno = b.plno and a.grade=b.grade and a.size = b.size and a.certificate = b.certificate and a.certificateid = b.certificateid  ";
                mySql3.CommandText += " SET a.qty = b.totcarton where a.plno=@plno4 ";
                mySql3.Parameters.AddWithValue("@plno4", plno);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

             */
            MainMenu frm = new MainMenu();
 
            String companyid = "";
            List<object[]> dr = new List<object[]>();
            MainMenu fr = new MainMenu();
            dr = fr.get_data_table_string("tbcompany", "", "");
            if (dr.Count > 0)
            {
                companyid = dr[0][1].ToString();
            }

            String user = Properties.Settings.Default.username;

            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update tbpackinglist set companyid=@companyid, user=@user, moddatetime=@moddatetime where plno=@plno";
                mySql3.Parameters.AddWithValue("@companyid", companyid);
                mySql3.Parameters.AddWithValue("@user", user);
                mySql3.Parameters.AddWithValue("@plno", plno);
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

            //Excluded FT, request from Bas 10 Aug 2018
            set_excludeft();
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
        
        public void loadpackingdetails(String pl)
        {

            List<object[]> data1 = new List<object[]>();
            MainMenu frm = new MainMenu();
            data1 = frm.get_data_netweight_packing(pl);
            double netweight = double.Parse(data1[0][0].ToString());


            List<object[]> data = new List<object[]>();
            //data=frm.get_data_table_string("tbpacking","shipping_unit_number",pl);
            data = frm.get_data_table_packing_datetime_desc_fieldname(pl, "case_number,grade,packingsize,intlotcode,pieces,boxweight,remark");
            Int32 pieces = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {

                pieces = data.Count;
                dataGridView1.Rows.Add(data.Count);
                for (int i = 0; i < data.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 50;
                    /*
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][5].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][8].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][11].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = data[i][16].ToString();
                    netweight = netweight + double.Parse(data[i][11].ToString());
                     */

                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][5].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = data[i][6].ToString();
                    //netweight = netweight + double.Parse(data[i][5].ToString());
                }
            }

            Delete_columnbutton();

            Int32 totalpcs = pieces;
            lblbox.Text=totalpcs.ToString();
            lblnweight1.Text = netweight.ToString();
        }


        public void loadpackingdetails_20(String pl)
        {
            List<object[]> data1 = new List<object[]>();
            MainMenu frm = new MainMenu();
            data1 = frm.get_data_netweight_packing(pl);
            double netweight = double.Parse(data1[0][0].ToString());

            List<object[]> data = new List<object[]>();
            //data=frm.get_data_table_string("tbpacking","shipping_unit_number",pl);
            data = frm.get_data_table_packing_datetime_desc_fieldname(pl, "case_number,grade,packingsize,intlotcode,pieces,boxweight,remark");
            
            Int32 pieces = 0;
            Int32 batas = 0;
            dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                
                pieces = data.Count;
                if (pieces < 20)
                {
                    batas = pieces;
                }
                else
                {
                    batas = 20;
                }
                dataGridView1.Rows.Add(batas);
                for (int i = 0; i < batas; i++)
                {
                    dataGridView1.Rows[i].Height = 50;
                    /*
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][5].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][8].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][11].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = data[i][16].ToString();
                    netweight = netweight + double.Parse(data[i][11].ToString());
                     */

                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells[1].Value = data[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = data[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = data[i][2].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = data[i][3].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = data[i][4].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = data[i][5].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = data[i][6].ToString();
                }
            }

            Delete_columnbutton();

            Int32 totalpcs = pieces;
            lblbox.Text = totalpcs.ToString();
            lblnweight1.Text = netweight.ToString();
        }



        private void Delete_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Delete") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(8, btn);
                btn.HeaderText = "Delete";
                btn.Name = "Delete";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MainMenu frm = new MainMenu();
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }

            
            if (btnpost.Enabled == false)
            {
                MessageBox.Show("This Packing List has been closed, prohibited to delete record");
                return;
            }

        
            if (e.ColumnIndex == 8 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete Value " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Int32 n = e.RowIndex;
                    String caseno = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    String boxkosong = "";
                    String connString = Konek();
                    MySqlConnection conn5 = new MySqlConnection(connString);
                    conn5.Open();
                    try
                    {
                        MySqlCommand mySql3 = conn5.CreateCommand();
                        mySql3.CommandText =
                        "update tbpacking set shipping_unit_number=@shipping_unit_number, moddatetime=@moddatetime where case_number=@case_number and shipping_unit_number=@shipping_unit_number1";
                        mySql3.Parameters.AddWithValue("@shipping_unit_number", boxkosong);
                        mySql3.Parameters.AddWithValue("@shipping_unit_number1", lblpackinglist.Text.Trim());
                        mySql3.Parameters.AddWithValue("@case_number", caseno);
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

                    this.loadpackingdetails(lblpackinglist.Text.Trim());
                    txtscan.Focus();
                }
            }





        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, button1.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            loadpackingdetails(lblpackinglist.Text.Trim());
        }


        private void txtscan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                if (txtscan.Text.Contains("*"))
                {

                        String data = txtscan.Text.Trim();
                        String[] eachdata = data.Split('*');
                        String caseno = eachdata[1].ToString();
                        //txtscan.Text = txtscan.Text.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
                        //scanpacking(txtscan.Text.Trim());
                        scanpacking(caseno);
                        loadpackingdetails_20(lblpackinglist.Text.Trim());
                        txtscan.Text = "";
                        txtscan.Focus();
                }
            }

        }

        private void txtscan_TextChanged(object sender, EventArgs e)
        {

        }


        private void set_po_status(String po, String status)
        {
            MainMenu frm = new MainMenu();
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update tbpo set status=@status, moddatetime=@moddatetime where pono=@po";
                mySql3.Parameters.AddWithValue("@po", po);
                mySql3.Parameters.AddWithValue("@status", status);
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();
        }


        private void set_packinglist_summary(String plno)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();

            MySqlCommand mySql3 = conn5.CreateCommand();

            mySql3.CommandText =
            "delete from tbpackinglist_summary where plno=@plno1";
            mySql3.Parameters.AddWithValue("@plno1", plno);
            mySql3.ExecuteNonQuery();
            conn5.Close();

            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();

                mySql3.CommandText =
                "insert into tbpackinglist_summary(plno,customerid,itemcode, product, grade,size, certificate, qty,total_weight_ctn, unitprice,batchcode) ";
                mySql3.CommandText += " SELECT distinct a.shipping_unit_number as plno, c.customerid, b.itemcodesap, a.productname, a.grade, a.packingsize, concat(e.certificate, ' ' , f.certificatecode) as certificate   , count(a.case_number) as totalpacking, round(sum(a.boxweight),2) as total_weight_ctn, b.unitprice, a.batchcode  FROM `tbpacking` a join tbreceiving e on a.intlotcode=e.intlotcode left outer join tbproductsetup_sapcode b on a.productname=b.product ";
                mySql3.CommandText += " and e.certificate = b.certificate AND a.grade=b.grade and a.packingsize=b.size left outer join shipping_unit c on a.shipping_unit_number = c.shipping_unit_number left outer join tbproductsetup d on a.productname = d.productname and a.productpacking = d.tradeunit  left outer join tbsupplier f on substr(e.supplier,5,3) = f.suppcode and e.certificate<>'' where a.shipping_unit_number=@plno3    group by a.shipping_unit_number, c.customerid, b.itemcodesap, a.productname, a.grade, a.packingsize, concat(e.certificate, ' ' , f.certificatecode), a.batchcode ";
                mySql3.Parameters.AddWithValue("@plno3", plno);
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

            String companyid = "";
            List<object[]> dr = new List<object[]>();
            MainMenu fr = new MainMenu();
            dr = fr.get_data_table_string("tbcompany", "", "");
            if (dr.Count > 0)
            {
                companyid = dr[0][1].ToString();
            }

            String user = Properties.Settings.Default.username;

            conn5.Open();
            try
            {
                mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update tbpackinglist_summary set companyid=@companyid, user=@user, moddatetime=@moddatetime where plno=@plno";
                mySql3.Parameters.AddWithValue("@companyid", companyid);
                mySql3.Parameters.AddWithValue("@user", user);
                mySql3.Parameters.AddWithValue("@plno", plno);
                mySql3.Parameters.AddWithValue("@moddatetime", frm.get_server_time());
                mySql3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex.Message);
            }
            conn5.Close();

            //Excluded FT, request from Bas 10 Aug 2018
            set_excludeft();
        }


        private void btnprintlabel_Click(object sender, EventArgs e)
        {
            if (lblnweight1.Text.Equals("."))
            {
                lblMessage.Text = "No case number scanned yet. Please scan case number for stuffing";
                return;

            }
            
            set_packinglist(lblpackinglist.Text.Trim());

            //Set packinglist_summary
            set_packinglist_summary(lblpackinglist.Text.Trim());


            post_unpost_stuffing(lblpackinglist.Text.Trim(),"post");
            MessageBox.Show("Stuffing has been posted, packing list # " + lblpackinglist.Text + " may be printed");
            display_closed_button(lblpackinglist.Text.Trim());

        }


        private void set_excludeft()
        {

            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            MySqlCommand mySql3 = conn5.CreateCommand();

            String packing = "";
            List<object[]> data = new List<object[]>();
            MainMenu frm = new MainMenu();
            data = frm.get_data_table_string_fieldname("tbpackingsize", "packingsize", "excludedft", "1");
            if (data.Count > 0)
            {

                for (int i = 0; i < data.Count; i++)
                {
                    packing = data[i][0].ToString();
                    mySql3.CommandText =
                    "update tbpackinglist set certificate=@certificate where size=@size and certificate like @certificate1";
                    mySql3.Parameters.AddWithValue("@certificate", "");
                    mySql3.Parameters.AddWithValue("@size", packing);
                    mySql3.Parameters.AddWithValue("@certificate1", "%FT%");
                    mySql3.ExecuteNonQuery();


                    mySql3.CommandText =
                    "update tbpackinglist_summary set certificate=@certificate2 where size=@size1 and certificate like @certificate3";
                    mySql3.Parameters.AddWithValue("@certificate2", "");
                    mySql3.Parameters.AddWithValue("@size1", packing);
                    mySql3.Parameters.AddWithValue("@certificate3", "%FT%");
                    mySql3.ExecuteNonQuery();

                }
            }
            conn5.Close();
        }


        public void display_closed_button(String plno)
        {
            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select closed from shipping_unit where packingslipno=@plno";
            cmd.Parameters.AddWithValue("@plno", plno);
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
                if (data[0][0].ToString().Equals("1"))
                {
                    btnpost.Enabled = false;
                    btnpost.BackColor = Color.Gray;
                    btnunpost.Visible = true;
                    btnunpost.BackColor = Color.Orange;
                    txtscan.Enabled = false;
                    txtremark.Enabled = false;
                }
                else
                {
                    btnpost.Enabled = true;
                    btnpost.BackColor = Color.Orange;
                    btnunpost.Visible = false;
                    btnunpost.BackColor = Color.Gray;
                    txtscan.Enabled = true;
                    txtremark.Enabled = true;
                    txtscan.Focus();
                }
            }
       }


        private void post_unpost_stuffing(String plno, String status)
        {
            MainMenu frm = new MainMenu();
            Int32 valuestatus = 0;
            String connString = Konek();
            MySqlConnection conn5 = new MySqlConnection(connString);
            conn5.Open();
            try
            {
                MySqlCommand mySql3 = conn5.CreateCommand();
                mySql3.CommandText =
                "update shipping_unit set closed=@closed, moddatetime=@moddatetime where packingslipno=@plno";
                mySql3.Parameters.AddWithValue("@plno", plno);
                if (status.Equals("post"))
                {
                    valuestatus = 1;
                }
                else
                {
                    valuestatus = 0;
                }
                mySql3.Parameters.AddWithValue("@closed", valuestatus);

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

            if (valuestatus == 1)
            {
                set_po_status(lblpo.Text.Trim(), "closed");
            }
            else if (valuestatus == 0)
            {
                set_po_status(lblpo.Text.Trim(), "open");
            }
        }

        private void btnunpost_Click(object sender, EventArgs e)
        {
            post_unpost_stuffing(lblpackinglist.Text.Trim(),"unpost");
            display_closed_button(lblpackinglist.Text.Trim());
            MessageBox.Show("Stuffing has been unposted");
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            add_column_button(e, "delete", 8);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
