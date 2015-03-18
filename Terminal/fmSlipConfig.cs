using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using DparkTerminal.Properties;
using BackOffice;

using DevExpress.XtraReports.UI;

namespace DparkTerminal
{
    public partial class fmSlipConfig : Form
    {
        public fmSlipConfig()
        {
            InitializeComponent(); 

        }
        private void readSetting() {
            if (Settings.Default.SlipPrinter != null)
            {
                Console.WriteLine(Settings.Default.SlipPrinter);
                cmPrinter.Text = Settings.Default.SlipPrinter;
                txtNameCompany.Text = Settings.Default.nameCompany;
                txtNumberCompany.Text = Settings.Default.numberCompany;
                txtSlipTitle.Text = Settings.Default.slipTitle;
            }
            else {
               cmPrinter.SelectedIndex = 0;
            }
        }
        private void saveSetting() {
            Settings.Default.SlipPrinter = cmPrinter.SelectedItem.ToString();
            Settings.Default.slipTitle = txtSlipTitle.Text;
            Settings.Default.nameCompany = txtNameCompany.Text;
            Settings.Default.numberCompany = txtNumberCompany.Text;
            Settings.Default.Save();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            saveSetting();
            txtInfo.Text = "บันทึกแล้ว";
            txtInfo.BLink();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }
 
        private void fmSlipConfig_Load(object sender, EventArgs e)
        {
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                cmPrinter.Items.Add(printer.ToString());
            }
            readSetting();
        }

        private void btPrintTest_Click(object sender, EventArgs e)
        {
            saveSetting();

            reportReceipt report = new reportReceipt();
            report.LoadLayout("reports\\ReportReceipt.repx");
            report.PrinterName = Settings.Default.SlipPrinter;
            report.Print();
        }


    }
}
