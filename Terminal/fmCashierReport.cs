using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackOffice;
using DparkTerminal.Properties;
using DevExpress.XtraReports.UI;
//using DevExpress.XtraReports;

namespace DparkTerminal
{
    public partial class fmCashierReport : Form
    {
        reportCashierLogout report;
        public fmCashierReport()
        {
            InitializeComponent();
          report = new reportCashierLogout();

        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            report.Print(Settings.Default.SlipPrinter);
        }
        
        private void ReportUpdate() {
            using (Dpark3Entities db = new Dpark3Entities())
            {
                General gb = new General();
                db.Database.Connection.ConnectionString = gb.GetConnectionString();

                DateTime dtFr = new DateTime(dtChkInFromDate.Value.Year,
                                                dtChkInFromDate.Value.Month,
                                                dtChkInFromDate.Value.Day,
                                                dtChkInFromTime.Value.Hour,
                                                dtChkInFromTime.Value.Minute,
                                                0);

                DateTime dtTo = new DateTime(dtChkInToDate.Value.Year,
                                                dtChkInToDate.Value.Month,
                                                dtChkInToDate.Value.Day,
                                                dtChkInToTime.Value.Hour,
                                                dtChkInToTime.Value.Minute,
                                                0);
               
                var ps = db.tr_report_cashier_sum(dtFr, dtTo, Globals.sysUserID).ToList();

                docView.PrintingSystem = report.PrintingSystem;
                if (ps.Count > 0)
                {
                    report.plbSysUserName.Text = ps.First().ChkOutUser.ToString();
                    report.plbAccountingDiscount.Text = ps.First().accountingDiscount.ToString();
                    report.plbAccountingPrices.Text = ps.First().accountingPrices.ToString();
                    report.plbAccountingReceive.Text = ps.First().accountingReceive.ToString();
                    report.plbCountOfChkOut.Text = ps.First().countOfChkOut.ToString();
                    report.plbCountOfEmergency.Text = ps.First().countEmergency.ToString();
                    report.plbCountOfPaymentTime.Text = ps.First().countPaymentTime.ToString();
                }
                else
                {
                    DBManage.TBsysUser dbmntSysUser = new DBManage.TBsysUser();
                    report.plbSysUserName.Text = dbmntSysUser.GetSysUserInfo(Globals.sysUserID).sysUserName;
                }
                report.plbReportTimeFr.Text = dtFr.ToString("ddMMMyy HH:mm");
                report.plbReportTimeTo.Text = dtTo.ToString("ddMMMyy HH:mm");
                report.CreateDocument();
                
            }
        }
        private void bt_find_Click(object sender, EventArgs e)
        {
            ReportUpdate();           
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Close();
            GC.Collect();
        }

        private void dtChkInFromDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReportUpdate();
            }
        }
    }
}
