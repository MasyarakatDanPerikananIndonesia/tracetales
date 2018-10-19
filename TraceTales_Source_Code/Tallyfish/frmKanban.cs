using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel=Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace Tallyfish
{
    public partial class frmKanban : Form
    {
        public frmKanban()
        {
            InitializeComponent();
        }

        private String Konek()
        {
            MainMenu frm = new MainMenu();
            return frm.Konek();
        }


        private void display_lotnumber(DateTime dt1, DateTime dt2)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);
            cmd.CommandText = "select a.intlotcode, a.rcvdate,b.suppname from tbreceiving a join tbsupplier b on a.supplier=concat(b.batchcode,'-',b.suppcode,'-',b.suppname)  where Cast(rcvdate as Date) >= @dt1 and Cast(rcvdate as Date)  <=@dt2 order by a.id";

            dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
            dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));

            cmd.Parameters.AddWithValue("@dt1", dt1);
            cmd.Parameters.AddWithValue("@dt2", dt2);
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
            
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                dataGridView1.Rows.Add(data.Count);
            }

            String intlotcode, rcvdate;
            DateTime dt;
            String combined = "";

            String suppname = "";
            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count; i++)
            {
                intlotcode=data[i][0].ToString();
                suppname = data[i][2].ToString();
                
                // For display Internal Lot Code
                rcvdate = data[i][1].ToString();
                dt = DateTime.Parse(rcvdate);
                rcvdate = dt.ToString("yyyy-MM-dd");

                combined = intlotcode + "\r\n" + rcvdate + "\r\n" + suppname;
                dataGridView1.Rows[i].Height = 150;
                dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Rows[i].Cells[0].Value = combined;

                //For displaying Receiving
                display_data(intlotcode,"receiving",i);
                display_data(intlotcode, "cutting",i);
                display_data(intlotcode, "retouching",i);
                display_data(intlotcode, "packing",i);

                //For Displaying Cutting

                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;
        }


        private void display_data(String lot, String module, Int32 row)
        {
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();

            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            Int32 cellnumber = 0;
            if (module.ToLower().Equals("receiving"))
            {
                cmd.CommandText = "select intlotcode,moddatetime as tgl, count(intlotcode) as pcs, sum(fweight) as weight from tbreceivingdetails where intlotcode=@intlotcode";
                cellnumber = 1;
            }
            else if (module.ToLower().Equals("cutting"))
            {
                cmd.CommandText = "select intlotcode,cutdate as tgl, count(intlotcode) as pcs, sum(cweight) as weight from tbcuttingdetails where intlotcode=@intlotcode";
                cellnumber = 2;
            }
            else if (module.ToLower().Equals("retouching"))
            {
                cmd.CommandText = "select intlotcode,rtcdate as tgl, count(intlotcode) as pcs, sum(rweight) as weight from tbretouchingdetails where intlotcode=@intlotcode";
                cellnumber = 3;
            }
            else if (module.ToLower().Equals("packing"))
            {
                cmd.CommandText = "select intlotcode,moddatetime as tgl, count(intlotcode) as pcs, sum(boxweight) as weight from tbpacking where intlotcode=@intlotcode";
                cellnumber = 4;
            }

            cmd.Parameters.AddWithValue("@intlotcode", lot);
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


            Int32 ct = 0;
            ct = Int32.Parse(data[0][2].ToString());

            if (data.Count > 0 && ct > 0)
            {

                String pcs = "";
                String weight = "";
                String combined = "";
                DateTime dt;
                String tgl;
                String intlotcode = "";

                tgl = data[0][1].ToString();
                dt = DateTime.Parse(tgl);
                tgl = dt.ToString("yyyy-MM-dd");

                intlotcode = data[0][0].ToString();
                pcs = data[0][2].ToString();
                weight = data[0][3].ToString();

                combined = intlotcode + "\r\n" + tgl + "\r\n" + weight + " Kg | " + pcs + "pcs";

                dataGridView1.Columns[cellnumber].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.Rows[row].Cells[cellnumber].Value = combined;
            }
        }


        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("preview", btnpreview);
            frm.setbuttonicon("inventory", btnqtyreceiving);
            frm.setbuttonicon("inventory", btnqtystuffing);
        }





        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
            dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));
            display_lotnumber(dt1, dt2);
        }

        private void frmKanban_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            seticon_forbutton();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String word="";
            String intlotcode="";
            String module="";
            String stage="";

            if (e.ColumnIndex == 1)
            {
                stage = "Receiving";
            }
            else if (e.ColumnIndex == 2)
            {
                stage = "Cutting";
            }
            else if (e.ColumnIndex == 3)
            {
                stage = "Retouching";
            }
            else if (e.ColumnIndex == 4)
            {
                stage = "Packing";
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to export to excel for " + stage + " "+ this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                word = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var newLinesRegex = new Regex(@"\r\n|\n|\r", RegexOptions.Singleline);
                var lines = newLinesRegex.Split(word);
                intlotcode = lines[0].ToString();

                if (e.ColumnIndex == 0)
                {
                    export_excel_all(intlotcode);

                }
                else if (e.ColumnIndex == 1)
                {
                    module = "receiving";
                    export_excel_individual(intlotcode, module);
                }
                else if (e.ColumnIndex == 2)
                {
                    module = "cutting";
                    export_excel_individual(intlotcode, module);
                }
                else if (e.ColumnIndex == 3)
                {
                    module = "retouching";
                    export_excel_individual(intlotcode, module);
                }
                else if (e.ColumnIndex == 4)
                {
                    //module = "packing";
                    //export_excel_individual(intlotcode, module);
                    export_excel_packing(intlotcode);
                    return;

                }

                //Export to excel
            }

        }


        private void export_excel_periods(String module)
        {

            DialogResult dialogResult = MessageBox.Show("Do you want to export to excel for " + module  + "?", "Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                export_excel_all_periods(module);
            }

        }


        private void export_excel_individual(String intlotcode, String module)
        {

            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            Int32 cellnumber = 0;
            Int32 colscount=0;
            String[] colsname = new String[1];
            if (module.ToLower().Equals("receiving"))
            {

                String msql=
                " SELECT a.intlotcode, a.species, a.tipe, c.grade,c.fweight,c.fishno, a.rcvdate,b.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, b.fishingground, b.landingsite,b.batchcode, a.username, h.fisherman FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails C on a.intlotcode=c.intlotcode left outer join provinces d on b.province=d.id left outer join regencies e on b.regencies=e.id left outer join districts f on b.district = f.id left outer join villages g on b.village = g.id  left outer join tbreceiving_fisherman h on a.intlotcode=h.intlotcode and c.fishno >=h.fishno_awal and c.fishno <=h.fishno_akhir   where a.intlotcode=@intlotcode";
                cmd.CommandText = msql; 
                    
                                    //SELECT a.intlotcode, a.species, a.tipe, c.grade,c.fweight, a.rcvdate,b.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, b.fishingground, b.landingsite,b.batchcode FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails C on a.intlotcode=c.intlotcode left outer join provinces d on b.province=d.id left outer join regencies e on b.regencies=e.id left outer join districts f on b.district = f.id left outer join villages g on b.village = g.id where a.intlotcode=@intlotcode";
                cellnumber = 1;
                colscount=17;
                colsname = new String[17]{ "Int Lot Code", "Species", "State", "Grade", "Weight_Kg","FishNo","Receiving Date", "Supplier Name", "Province","Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User", "Fisherman"};
            }
            else if (module.ToLower().Equals("cutting"))
            {
                cmd.CommandText = "SELECT a.intlotcode, b.species, a.tipe, a.grade,a.cweight, h.grupsize, a.cutdate,b.rcvdate,c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbcuttingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id left outer join tbgrupsize h on a.cweight>=h.lower and a.cweight<=h.upper and h.module=@module  where a.intlotcode=@intlotcode";
                cellnumber = 2;
                colscount=17;
                colsname = new String[17] { "Int Lot Code", "Species", "State", "Grade", "Weight_Kg","Size", "Cutting Date", "Receiving Date", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code", "User" };
            }
            else if (module.ToLower().Equals("retouching"))
            {
                cmd.CommandText = "SELECT a.loin_number,a.intlotcode, b.species, a.tipe, a.grade,a.rweight, h.grupsize, a.rtcdate,b.rcvdate,c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbretouchingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id  left outer join tbgrupsize h on a.rweight>=h.lower and a.rweight<=h.upper and h.module=@module where a.intlotcode=@intlotcode";
                cellnumber = 3;
                colscount=18;
                colsname = new String[18] { "Loin Number", "Int Lot Code", "Species", "State","Grade", "Weight_Kg", "Size", "Retouching Date", "Receiving Date", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User" };
            }
            else if (module.ToLower().Equals("packing"))
            {
                cmd.CommandText = "SELECT a.case_number,a.moddatetime, a.boxweight, b.species, a.grade, a.packingsize, a.pieces, a.best_before_date, a.intlotcode, c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbpacking a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id where a.intlotcode=@intlotcode";
                cellnumber = 4;
                colscount=18;
                colsname = new String[18] { "Case Number", "Modification Date", "Box Weight Kg", "Species", "Grade", "Size", "Pieces", "Best Before Date", "Int Lot Code", "Supplier Name", "Province", "Regencies", "Districts", "Village", "Fishing Ground", "Landing Site", "Batch Code","User"};
            }

            cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
            if (module.ToLower().Equals("cutting"))
            {
                cmd.Parameters.AddWithValue("@module", "Cutting");
            }
            else if (module.ToLower().Equals("retouching"))
            {
                cmd.Parameters.AddWithValue("@module", "Retouching");
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
            conn3.Close();


            Excel.Application xlApp ;
            Excel.Workbook xlWorkBook ;
            Excel.Worksheet xlWorkSheet ;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            
            Excel.Worksheet worksheet = (Excel.Worksheet)xlApp.Worksheets["Sheet1"];
            worksheet.Name = module;

            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count ; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }

                //Progress Bar
                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }

            ProgressBar1.Value = 100;

            //var b = Environment.CurrentDirectory + @"\"+module+"_"+intlotcode+".xls";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var b = filePath + @"\" + module + "_" + intlotcode + ".xls";
            xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + module + "_" + intlotcode + ".xls");
            System.Diagnostics.Process.Start(b);

        }


        private void export_excel_all_periods(String module)
        {

            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            Int32 cellnumber = 0;
            Int32 colscount = 0;
            String[] colsname = new String[1];


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Name = module;


            if (module.Equals("receiving"))
            {

                cellnumber = 1;
                colscount = 17;
                colsname = new String[17] { "Int Lot Code", "Species", "State", "Grade", "Weight_Kg","FishNo", "Receiving Date", "Date_Rcv", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User"};

                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                String msql =
                " SELECT a.intlotcode, a.species, a.tipe, c.grade,c.fweight,c.fishno,a.rcvdate, date_format(a.rcvdate, '%Y-%m-%d') as Tgl, b.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, b.fishingground, b.landingsite,b.batchcode, a.username, h.fisherman FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails C on a.intlotcode=c.intlotcode left outer join provinces d on b.province=d.id left outer join regencies e on b.regencies=e.id left outer join districts f on b.district = f.id left outer join villages g on b.village = g.id  where Cast(a.rcvdate as Date)>=@dt1 and Cast(a.rcvdate as Date) <=@dt2";
                cmd.CommandText = msql;

                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;

                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));

                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
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

                ProgressBar1.Value = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                    Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                    ProgressBar1.Value = prg;
                }
                ProgressBar1.Value = 100;
            }




            //Cutting
            if (module.Equals("cutting"))
            {

                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = module+"_detail";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                cellnumber = 1;
                colscount = 19;
                colsname = new String[19] { "Int Lot Code", "Species", "State", "Grade", "Weight_Kg", "Size", "Cutting Date", "Date_Cut", "Receiving Date","Date_Rcv", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code", "User" };
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                data = new List<object[]>();
                //conn3.Open();
                cmd.CommandText = "SELECT a.intlotcode, b.species, a.tipe, a.grade,a.cweight, h.grupsize, a.cutdate, date_format(a.cutdate, '%Y-%m-%d') as Tgl,  b.rcvdate, date_format(b.rcvdate, '%Y-%m-%d') as tanggal2,  c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbcuttingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id  left outer join tbgrupsize h on a.cweight>=h.lower and a.cweight<=h.upper and h.module=@module where Cast(a.cutdate as Date) >= @dt1 and Cast(a.cutdate as Date) <= @dt2";

                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;

                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));

                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
                cmd.Parameters.AddWithValue("@module", "Cutting");
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


                ProgressBar1.Value = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }

                    Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                    ProgressBar1.Value = prg;
                }
                ProgressBar1.Value = 100;
            }




            if (module.Equals("retouching"))
            {
                //Retouching
                data = new List<object[]>();

                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = module+"_detail";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                cellnumber = 1;
                colscount = 20;
                colsname = new String[20] { "Loin Number", "Int Lot Code", "Species", "State", "Grade", "Weight_Kg", "Size",  "Retouching Date","RctDate", "Receiving Date","RcvDate", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User" };

                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }
                //conn3.Open();
                cmd.CommandText = "SELECT a.loin_number,a.intlotcode, b.species, a.tipe, a.grade,a.rweight, h.grupsize, a.rtcdate, date_format(a.rtcdate, '%Y-%m-%d' ) as Tgl1, b.rcvdate, date_format(b.rcvdate, '%Y-%m-%d') as Tgl2,c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, b.username FROM tbretouchingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id left outer join tbgrupsize h  on a.rweight>=h.lower and a.rweight<=h.upper and h.module=@module where Cast(a.rtcdate as Date) >= @dt1 and Cast(a.rtcdate as Date) <= @dt2";
                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;

                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));

                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
                cmd.Parameters.AddWithValue("@module", "Retouching");
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 a = 0;
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


                ProgressBar1.Value = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                    Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                    ProgressBar1.Value = prg;
                }
                ProgressBar1.Value = 100;

            }
            //xlWorkBook.Worksheets.Add(xlWorkSheet);


            //Packing

            if (module.Equals("packing"))
            {
                data = new List<object[]>();
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = module +"_detail";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                cellnumber = 1;
                colscount = 20;
                colsname = new String[20] { "Ship Number","Case Number", "Packing Date","PackDate", "Box Weight Kg", "Species", "Grade", "Size", "Pieces", "Best Before Date", "Int Lot Code", "Supplier Name", "Province", "Regencies", "Districts", "Village", "Fishing Ground", "Landing Site", "Batch Code", "User" };
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                data = new List<object[]>();
                //conn3.Open();
                cmd.CommandText = "SELECT a.shipping_unit_number, a.case_number,a.moddatetime, date_format(a.moddatetime, '%Y-%m-%d') as PackDate, a.boxweight, b.species, a.grade, a.packingsize, a.pieces, a.best_before_date, a.intlotcode, c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbpacking a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id where Cast(a.moddatetime as Date) >= @dt1 and Cast(a.moddatetime as Date) <= @dt2";
                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;

                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));
                
                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 a = 0;
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


                ProgressBar1.Value = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                    Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                    ProgressBar1.Value = prg;
                }
                ProgressBar1.Value = 100;
            }
            //xlWorkBook.Worksheets.Add(xlWorkSheet);


            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var b = filePath + @"\" + module + "_details.xls";
            xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + module + "_summary.xls");
            System.Diagnostics.Process.Start(b);
        }




        private void export_excel_all(String intlotcode)
        {

            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            Int32 cellnumber = 0;
            Int32 colscount = 0;
            String[] colsname = new String[1];
            

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Name = "receiving";

            cellnumber = 1;
            colscount = 17;
            colsname = new String[17] { "Int Lot Code", "Species", "State", "Grade", "Weight_Kg","FishNo", "Receiving Date","RcvDate", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User" };
          
            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            String msql =
            " SELECT a.intlotcode, a.species, a.tipe, c.grade,c.fweight, c.fishno,a.rcvdate, date_format(a.rcvdate, '%Y-%m-%d') as rcvdate,  b.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, b.fishingground, b.landingsite,b.batchcode, a.username FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails C on a.intlotcode=c.intlotcode left outer join provinces d on b.province=d.id left outer join regencies e on b.regencies=e.id left outer join districts f on b.district = f.id left outer join villages g on b.village = g.id   where a.intlotcode=@intlotcode";
            cmd.CommandText = msql;
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

            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }

                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;

            //Cutting

            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "cutting";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);


            cellnumber = 2;
            colscount = 19;
            colsname = new String[19] { "Int Lot Code", "Species", "State", "Grade", "Weight_Kg", "Size", "Cutting Date", "CutDate", "Receiving Date","RcvDate","Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code","User" };
            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            data = new List<object[]>();
            conn3.Open();
            cmd.CommandText = "SELECT a.intlotcode, b.species, a.tipe, a.grade,a.cweight, h.grupsize,  a.cutdate, date_format(a.cutdate, '%Y-%m-%d') as tgl1, b.rcvdate,date_format(b.rcvdate, '%Y-%m-%d') as tgl2,c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbcuttingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id  left outer join tbgrupsize h on a.cweight>=h.lower and a.cweight<=h.upper and h.module=@module1 where a.intlotcode=@intlotcode1";
            cmd.Parameters.AddWithValue("@intlotcode1", intlotcode);
            cmd.Parameters.AddWithValue("@module1", "Cutting");
            //MySqlDataReader rdr = cmd.ExecuteReader();
            rdr = cmd.ExecuteReader();
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

            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }

                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;

            //Retouching
            data = new List<object[]>();

            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[3], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "retouching";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
            
            cellnumber = 3;
            colscount = 20;
            colsname = new String[20] { "Loin Number", "Int Lot Code", "Species", "State", "Grade", "Weight_Kg","Size", "Retouching Date", "rtcdate",  "Receiving Date","rcvdate", "Supplier Name", "Province", "Regencies", "District", "Village", "Fishing Ground", "Landing Site", "Batch Code", "User" };

            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }
            conn3.Open();
            cmd.CommandText = "SELECT a.loin_number,a.intlotcode, b.species, a.tipe, a.grade,a.rweight, h.grupsize, a.rtcdate, date_format(a.rtcdate,'%Y-%m-%d') as tgl1, b.rcvdate,date_format(b.rcvdate,'%Y-%m-%d') as tgl2, c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbretouchingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id  left outer join tbgrupsize h on a.rweight>=h.lower and a.rweight<=h.upper and h.module=@module2  where a.intlotcode=@intlotcode2";
            cmd.Parameters.AddWithValue("@intlotcode2", intlotcode);
            cmd.Parameters.AddWithValue("@module2", "Retouching");
            rdr = cmd.ExecuteReader();
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

            ProgressBar1.Value = 0;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }

                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;

            //xlWorkBook.Worksheets.Add(xlWorkSheet);


            //Packing
            data = new List<object[]>();
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[4], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "packing";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4);

            cellnumber = 4;
            colscount = 19;
            colsname = new String[19] { "Case Number", "Modification Date","PackDate","Box Weight Kg", "Species", "Grade", "Size", "Pieces", "Best Before Date", "Int Lot Code", "Supplier Name", "Province", "Regencies", "Districts", "Village", "Fishing Ground", "Landing Site", "Batch Code","User"};
            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            data = new List<object[]>();
            conn3.Open();
            cmd.CommandText = "SELECT a.case_number,a.moddatetime, date_format(a.moddatetime, '%Y-%m-%d') as packdate, a.boxweight, b.species, a.grade, a.packingsize, a.pieces, a.best_before_date, a.intlotcode, c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbpacking a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id where a.intlotcode=@intlotcode3";
            cmd.Parameters.AddWithValue("@intlotcode3", intlotcode);
            rdr = cmd.ExecuteReader();
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


            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }
                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;
            //xlWorkBook.Worksheets.Add(xlWorkSheet);



            //Details Packing
            data = new List<object[]>();
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[5], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "details_packing";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(5);

            cellnumber = 5;
            colscount = 14;
            colsname = new String[14] { "Product Name", "Case No", "Size", "Packing Grade", "Pieces", "Box Weight Kg", "Supplier", "Production Date", "Loin Number", "Retouching Grade", "Loin Weight Kg", "Remark", "Retouching Date", "Int Lot Code" };

            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            data = new List<object[]>();
            conn3.Open();
            cmd.CommandText = " select a.productname,a.case_number, a.packingsize, a.grade as packing_grade, a.pieces,a.boxweight,a.suppcode as supplier, a.proddate as production_date, ";
            cmd.CommandText += " b.loin_number, b.grade as retouching_grade,b.rweight,b.remark, date_format(b.rtcdate,'%Y-%m-%d') as retouching_date, b.intlotcode  from tbpacking a  ";
            cmd.CommandText += " join tbretouchingdetails b on a.box_number = b.box_number and b.intlotcode=@intlotcode4";
            cmd.Parameters.AddWithValue("@intlotcode4", intlotcode);
            rdr = cmd.ExecuteReader();
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


            ProgressBar1.Value = 0;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }
                Int32 prg = Convert.ToInt32(i * 100 / data.Count);
                ProgressBar1.Value = prg;
            }
            ProgressBar1.Value = 100;
            //xlWorkBook.Worksheets.Add(xlWorkSheet);

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var b = filePath + @"\ALL_" + intlotcode + ".xls";
            xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ALL_" + intlotcode + ".xls");
            System.Diagnostics.Process.Start(b);
        }




        private void export_excel_packing(String intlotcode)
        {

            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            //conn3.Open();
            
            MySqlCommand cmd = new MySqlCommand("", conn3);
            MySqlDataReader rdr ;

            Int32 cellnumber = 0;
            Int32 colscount = 0;
            String[] colsname = new String[1];


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //Packing
            data = new List<object[]>();
            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "packing";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            cellnumber = 1;
            colscount = 18;
            colsname = new String[18] { "Case Number", "Modification Date", "Box Weight Kg", "Species", "Grade", "Size", "Pieces", "Best Before Date", "Int Lot Code", "Supplier Name", "Province", "District", "Sub Districts", "Village", "Fishing Ground", "Landing Site", "Batch Code","User"};
            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            data = new List<object[]>();
            conn3.Open();
            cmd.CommandText = "SELECT a.case_number,a.moddatetime, a.boxweight, b.species, a.grade, a.packingsize, a.pieces, a.best_before_date, a.intlotcode, c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode, a.username FROM tbpacking a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id where a.intlotcode=@intlotcode3 and a.box_number in ( select box_number from tbretouchingdetails )";
            cmd.Parameters.AddWithValue("@intlotcode3", intlotcode);
            Int32 a = 0;
            rdr = cmd.ExecuteReader();
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



            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }
            }


            //Details Packing

            xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
            xlWorkSheet.Name = "details_packing";
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);

            cellnumber = 2;
            colscount = 14;

            colsname = new String[14] { "Product Name", "Case No", "Size", "Packing Grade", "Pieces", "Box Weight Kg", "Supplier", "Production Date", "Loin Number", "Retouching Grade", "Loin Weight Kg", "Remark", "Retouching Date", "Int Lot Code" };
            for (int i = 0; i < colscount; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
            }

            data = new List<object[]>();
            conn3.Open();
           // cmd.CommandText = "SELECT a.intlotcode, b.species, a.tipe, a.grade,a.cweight, a.cutdate,b.rcvdate,c.suppname, d.name as province,e.name as regencies, f.name as districts,g.name as village, c.fishingground, c.landingsite,c.batchcode FROM tbcuttingdetails a join tbreceiving b on a.intlotcode=b.intlotcode join tbsupplier c on b.supplier= concat(c.batchcode,'-',c.suppcode,'-',c.suppname) left outer join provinces d on c.province=d.id left outer join regencies e on c.regencies=e.id left outer join districts f on c.district = f.id left outer join villages g on c.village = g.id where a.intlotcode=@intlotcode1";
            cmd.CommandText =" select a.productname,a.case_number, a.packingsize, a.grade as packing_grade, a.pieces,a.boxweight,a.suppcode as supplier, a.proddate as production_date, ";
            cmd.CommandText += " b.loin_number, b.grade as retouching_grade,b.rweight,b.remark, date_format(b.rtcdate,'%Y-%m-%d') as retouching_date, b.intlotcode  from tbpacking a  ";
            //cmd.CommandText += " join tbretouchingdetails b on a.box_number = b.box_number and b.intlotcode=@intlotcode";
            cmd.CommandText += " join tbretouchingdetails b on a.box_number = b.box_number where a.case_number in ( select case_number from tbpacking where intlotcode=@intlotcode) ";
            cmd.Parameters.AddWithValue("@intlotcode", intlotcode);
            //MySqlDataReader rdr = cmd.ExecuteReader();
            rdr = cmd.ExecuteReader();
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


            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < colscount; j++)
                {
                    xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                }
            }

            String filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var b = filePath + @"\packing_" + intlotcode + ".xls";
            xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ALL_" + intlotcode + ".xls");
            System.Diagnostics.Process.Start(b);
        }





        private void export_excel_totalkg(String module)
        {


            List<object[]> data = new List<object[]>();
            String connString = Konek();
            MySqlConnection conn3 = null;
            conn3 = new MySqlConnection(connString);
            conn3.Open();
            MySqlCommand cmd = new MySqlCommand("", conn3);


            Int32 cellnumber = 0;
            Int32 colscount = 0;
            String[] colsname = new String[1];
            if (module.ToLower().Equals("receiving"))
            {

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                //Receiving Details
                data = new List<object[]>();
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = "Receiving Details";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                cellnumber = 1;
                colscount = 6;
                colsname = new String[6] { "Int Lot Code", "Species", "State", "Receiving Date", "Supplier Name", "Total Kg" };
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                String msql =
                " SELECT a.intlotcode, a.species, a.tipe, a.rcvdate,b.suppname, sum(c.fweight) as totalkg FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails c on a.intlotcode=c.intlotcode where Cast(a.rcvdate as Date) >= @dt1 and Cast(a.rcvdate as Date) <= @dt2  group by a.intlotcode, a.species, a.tipe, a.rcvdate,b.suppname";
                cmd.CommandText = msql;

                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;
                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
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

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                }


               //Receiving Summary

                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = "Receiving Summary";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);

                cellnumber = 2;
                colscount = 2;

                colsname = new String[2] { "Supplier", "Total Qty (Kg)"};
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                data = new List<object[]>();
                conn3.Open();
                msql =
                " SELECT b.suppname, sum(c.fweight) as totalkg FROM tbreceiving a join tbsupplier B on a.supplier= concat(b.batchcode,'-',b.suppcode,'-',b.suppname) join tbreceivingdetails c on a.intlotcode=c.intlotcode where Cast(a.rcvdate as Date) >= @dt3 and Cast(a.rcvdate as Date) <= @dt4  group by b.suppname";
                cmd.CommandText = msql;

                dt1 = dateTimePicker1.Value;
                dt2 = dateTimePicker2.Value;
                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@dt3", dt1);
                cmd.Parameters.AddWithValue("@dt4", dt2);
                rdr = cmd.ExecuteReader();

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


                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                }

                String filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var b = filePath + @"\total_receiving.xls";
                xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\total_receiving.xls");
                System.Diagnostics.Process.Start(b);
            }



            if (module.ToLower().Equals("stuffing"))
            {

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                var xlSheets = xlWorkBook.Sheets as Excel.Sheets;
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                //Stuffing Details
                data = new List<object[]>();
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = "Stuffing Details";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                cellnumber = 1;
                colscount = 6;

                colsname = new String[6] { "CustName","Grade","PackingSize","Int Lot Code","Certificate", "Total Kg" };
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }

                String msql =
                " SELECT c.custname, a.grade, a.packingsize, a.intlotcode, a.certificate, sum(a.boxweight) as totalweightkg FROM tbpacking a join shipping_unit b on a.shipping_unit_number = b.shipping_unit_number  join tbcustomer c on b.customerid=c.custcode  ";
                msql = msql + "  where Cast(b.shipdate as Date) >= @dt1 and Cast(b.shipdate as Date) <=@dt2 group by c.custname, a.grade, a.packingsize, a.intlotcode, a.certificate";
                cmd.CommandText = msql;
                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;
                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));              
                cmd.Parameters.AddWithValue("@dt1", dt1);
                cmd.Parameters.AddWithValue("@dt2", dt2);
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

                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                }


                //Stuffing Summary
                xlWorkSheet = (Excel.Worksheet)xlSheets.Add(xlSheets[2], Type.Missing, Type.Missing, Type.Missing);
                xlWorkSheet.Name = "Stuffing Summary";
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);

                cellnumber = 2;
                colscount = 2;

                colsname = new String[2] { "Customer", "Total Qty (Kg)" };
                for (int i = 0; i < colscount; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = colsname[i].ToString();
                }


                data = new List<object[]>();
                conn3.Open();
                msql =
                " SELECT c.custname, sum(a.boxweight) as totalweightkg FROM tbpacking a join shipping_unit b on a.shipping_unit_number = b.shipping_unit_number  join tbcustomer c on b.customerid=c.custcode  ";
                msql = msql + "  where Cast(b.shipdate as Date) >= @dt1 and Cast(b.shipdate as Date) <=@dt2 group by c.custname";
                cmd.CommandText = msql;

                dt1 = dateTimePicker1.Value;
                dt2 = dateTimePicker2.Value;
                dt1 = DateTime.Parse(dt1.ToString("yyyy-MM-dd 00:00:00"));
                dt2 = DateTime.Parse(dt2.ToString("yyyy-MM-dd 00:00:00"));              
                cmd.Parameters.AddWithValue("@dt3", dt1);
                cmd.Parameters.AddWithValue("@dt4", dt2);
                rdr = cmd.ExecuteReader();

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


                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < colscount; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = data[i][j].ToString().Trim();
                    }
                }


                //var b = Environment.CurrentDirectory + @"\"+module+"_"+intlotcode+".xls";
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var b = filePath + @"\total_stuffing.xls";

                xlWorkBook.SaveAs(b, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file in " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\total_stuffing.xls");
                System.Diagnostics.Process.Start(b);
            }
        }
        
        
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            export_excel_totalkg("receiving");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            export_excel_totalkg("stuffing");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            export_excel_all_periods("receiving");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            export_excel_all_periods("cutting");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            export_excel_all_periods("retouching");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            export_excel_all_periods("packing");
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
