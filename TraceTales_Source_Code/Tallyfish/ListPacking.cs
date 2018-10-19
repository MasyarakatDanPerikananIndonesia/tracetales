using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tallyfish
{
    public partial class ListPacking : Form
    {
        public ListPacking()
        {
            InitializeComponent();
        }

        private void Select_columnbutton()
        {
            if (dataGridView1.Columns.Contains("Select") == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Insert(6, btn);
                btn.HeaderText = "Select";
                btn.Name = "Select";
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 60;
            }
        }


        public void show_list_packing()
        {
            List<object[]> dtlot = new List<object[]>();
            MainMenu flot = new MainMenu();

            //dtlot = flot.get_data_listpacking_daysearlier(20);
            dtlot = flot.get_data_listpacking_daysearlier_fieldname(7,"case_number,grade,packingsize,intlotcode,best_before_date");

            if (dtlot.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(dtlot.Count);
                for (int i = 0; i < dtlot.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 50;
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    /*
                    dataGridView1.Rows[i].Cells[1].Value = dtlot[i][2].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dtlot[i][3].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dtlot[i][4].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dtlot[i][5].ToString();
                    DateTime dt = DateTime.Parse(dtlot[i][7].ToString());

                    if (!dt.ToString("yyyy-MM-dd").Equals("1900-01-01"))
                    {
                        dataGridView1.Rows[i].Cells[5].Value = dt.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[5].Value = "";
                    }
                     */


                    dataGridView1.Rows[i].Cells[1].Value = dtlot[i][0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dtlot[i][1].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dtlot[i][2].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dtlot[i][3].ToString();
                    DateTime dt = DateTime.Parse(dtlot[i][4].ToString());

                    if (!dt.ToString("yyyy-MM-dd").Equals("1900-01-01"))
                    {
                        dataGridView1.Rows[i].Cells[5].Value = dt.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[5].Value = "";
                    }


                }
                Select_columnbutton();
            }
        }

        private void listpacking_Load(object sender, EventArgs e)
        {
            show_list_packing();
        }

        public void set_initial(String type, String size)
        {
            lblproduktype.Text = type;
            lblproduksize.Text = size;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            add_column_button(e, "select", 6);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                return;
            }

            if (e.ColumnIndex == 6 && e.RowIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                String caseno = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String boxno = "";
                String grade = "";
                String size = "";
                Int32 id_species = 0;
                String opt = Properties.Settings.Default.username;
                String producttype = lblproduktype.Text;
                String productsize = lblproduksize.Text;

                List<object[]> dtpacking = new List<object[]>();
                MainMenu frm = new MainMenu();
                //dtpacking = frm.get_data_table_string("tbpacking", "case_number", caseno);
                dtpacking = frm.get_data_table_string_fieldname("tbpacking","box_number,grade,packingsize,id_species,productname,productpacking", "case_number", caseno);
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

        }



    }
}
