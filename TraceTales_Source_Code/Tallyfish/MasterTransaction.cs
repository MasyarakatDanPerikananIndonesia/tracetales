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
    public partial class MenuTransaction : Form
    {
        public MenuTransaction()
        {
            InitializeComponent();
        }


        private String get_useraccess()
        {
            String useraccess = "";
            String userlogin = Properties.Settings.Default.username; 
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbuser", "username", userlogin.Trim());
            if (data.Count > 0)
            {
                useraccess = data[0][9].ToString();
            }
            return useraccess;
        }


        private Boolean Is_integration_supplierapps()
        {
            String integrate = "N";
            Boolean status = false;
            MainMenu frm = new MainMenu();
            List<object[]> data = new List<object[]>();
            data = frm.get_data_table_string("tbsetup", "category","integrationsupplierapps");
            if (data.Count > 0)
            {
                integrate=data[0][3].ToString();
                if (integrate.Equals("Y"))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }



        private void btnreceiving_Click(object sender, EventArgs e)
        {

            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("receiving") )
            {

                Boolean status=false;
                status=Is_integration_supplierapps();
                if (status)
                {
                    Supplier_Integration frm = new Supplier_Integration();
                    frm.ShowDialog();
                    return;
                }
                else
                {
                    InputReceiving frm = new InputReceiving();
                    frm.load_supplier_all();
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No access for receiving module");
                return;
            }
        }

        private void btnretouching_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("retouching") )
            {
                InputCutting frm = new InputCutting();
                Properties.Settings.Default.module = "RETOUCHING";
                frm.setmodule();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for retouching module");
                return;
            }
        }

        private void btntrimming_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("cutting") )
            {
                InputCutting frm = new InputCutting();
                Properties.Settings.Default.module = "CUTTING";
                frm.setmodule();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for cutting module");
                return;
            }
        }

        private void btnpacking_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("packing") )
            {
                InputPacking frm = new InputPacking();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for packing module");
                return;
            }

        }

        private void btnreceiving_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics,btnreceiving.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btntrimming_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btntrimming.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnretouching_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnretouching.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnpacking_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpacking.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnreceivingbox_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnreceivingbox.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }

        private void btnstuffing_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnstuffing.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }


        private void btnsummary_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnsummary.ClientRectangle,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 3, ButtonBorderStyle.Outset);
        }



        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnstuffing_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("stuffing") )
            {
                InputStuffing frm = new InputStuffing();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for stuffing module");
                return;
            }

        }

        private void btnsummary_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("summary") )
            {
                frmKanban frm = new frmKanban();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for summary transaction module");
                return;
            }


        }


        private void btnreceivingbox_Click(object sender, EventArgs e)
        {
            String userlogin = Properties.Settings.Default.username; 
            String useraccess = get_useraccess();
            if (useraccess.Contains("receivingbox") )
            {
                InputReceivingBox frm = new InputReceivingBox();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for receiving box from other processor module");
                return;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, backtomain.ClientRectangle,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 1, ButtonBorderStyle.Outset);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String useraccess = get_useraccess();
            String userlogin = Properties.Settings.Default.username;
            if (useraccess.Contains("reprintlabel") )
            {
                frmOptional frm = new frmOptional();
                frm.set_button_reprint_label();
                frm.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No access for reprint label module");
                return;
            }
        }



        private void seticon_forbutton()
        {
            MainMenu frm = new MainMenu();
            frm.setbuttonicon("receiving", btnreceiving);
            frm.setbuttonicon("cutting_retouching", btntrimming);
            frm.setbuttonicon("cutting_retouching", btnretouching);
            frm.setbuttonicon("packing", btnpacking);
            frm.setbuttonicon("stuffing", btnstuffing);
            frm.setbuttonicon("packing", btnreceivingbox);
            frm.setbuttonicon("summary", btnsummary);
            frm.setbuttonicon("back", backtomain);
        }


        private void MenuTransaction_Load(object sender, EventArgs e)
        {
            seticon_forbutton();
        }

        private void paneltrx_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
