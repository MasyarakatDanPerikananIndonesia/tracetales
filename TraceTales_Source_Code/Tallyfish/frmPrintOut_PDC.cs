using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using System.IO;

namespace Tallyfish
{
    public partial class frmPrintOut_PDC : Form
    {
        public frmPrintOut_PDC()
        {
            InitializeComponent();
        }

        public void setpl(String pl)
        {
            lblplno.Text=pl;
        }

        private void frmPrintOut_PDC_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            var path = Directory.GetCurrentDirectory();
            var location = path + "\\database.config";
            var report_pl = path + "\\report_summary_prod.rpt";
            String ipserver = "";
            String userid = "";
            String pwd = "";

            if (System.IO.File.Exists(location) == true)
            {
                using (StreamReader reader = new StreamReader(location))
                {
                    const int linesToRead = 5;
                    while (!reader.EndOfStream)
                    {
                        string[] currReadLines = new string[linesToRead];
                        for (var i = 0; i < linesToRead; i++)
                        {
                            var currLine = reader.ReadLine();
                            if (currLine == null)
                                break;

                            currReadLines[i] = currLine;
                        }
                        ipserver = currReadLines[0];
                        userid = currReadLines[2];
                        pwd = currReadLines[3];
                    }

                }
            }


            cryRpt.Load(report_pl);
            cryRpt.SetDatabaseLogon(userid, pwd);
            cryRpt.SetParameterValue("plno", lblplno.Text.Trim());
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
         }
    }
}
