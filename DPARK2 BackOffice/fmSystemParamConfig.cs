using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UserDesigner;
using System.IO;
namespace BackOffice
{
    public partial class fmSystemParamConfig : Form
    {
        public fmSystemParamConfig()
        {
            InitializeComponent();
            readParameter();
           rtReceipt   = new reportReceipt();
           rtTakeTicketReceipt = new reportTakeTicketReceipt();
           rtChkIn = new reportChkIn();
           rtCashierLogout = new reportCashierLogout();
        }

        private void bt_pictureDrive_Click(object sender, EventArgs e)
        {
            var folderName = GetImgFolders(txtImgPath.Text);
            if (folderName != string.Empty)
            {
                txtImgPath.Text = folderName;
            }
        }
        private string GetImgFolders(string defaultPath)
        {

            folderBrowserDialog1.SelectedPath = defaultPath;
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }

            return string.Empty;
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void readParameter()
        {
            Cursor.Current = Cursors.WaitCursor;
            DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();
            DBMnt.ReadAll();
            txtImgPath.Text = DBMnt.imgPath;
            txtUsername.Text = DBMnt.imgPathUser;
            txtPasswd.Text = DBMnt.imgPathPasswd;
            ckEnableAutoPrintChkOut.Checked = DBMnt.EnableAutoReprotChkOut;
            ckEnableAutoPrintChkIn.Checked = DBMnt.EnableAutoReprotChkIn;
            ckPermitCashierPrint.Checked = DBMnt.EnableGateInSummaryPrintByCashier;
            ckEnableAntiPassback.Checked = DBMnt.EnableAntiPassback;
            ckAcceptRegisterTicketOnly.Checked = DBMnt.AcceptRegisterTicketOnly;
            ckEnableAutoPrintTakeTicket.Checked = DBMnt.EnableAutoReportTicket;
            Cursor.Current = Cursors.Default;
        }
        private void saveParameter()
        {
            Cursor.Current = Cursors.WaitCursor;
            DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();

            DBMnt.imgPath = txtImgPath.Text;
            DBMnt.imgPathPasswd = txtPasswd.Text;
            DBMnt.imgPathUser = txtUsername.Text;
            DBMnt.EnableAutoReprotChkIn = ckEnableAutoPrintChkIn.Checked;
            DBMnt.EnableAutoReprotChkOut = ckEnableAutoPrintChkOut.Checked;
            DBMnt.EnableGateInSummaryPrintByCashier = ckPermitCashierPrint.Checked;
            DBMnt.EnableAntiPassback = ckEnableAntiPassback.Checked;
            DBMnt.AcceptRegisterTicketOnly = ckAcceptRegisterTicketOnly.Checked;
            DBMnt.EnableAutoReportTicket = ckEnableAutoPrintTakeTicket.Checked;
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.imgPath);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.imgPathUser);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.imgPathPasswd);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.EnableAutoReprotChkIn);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.EnableAutoReprotChkOut);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.EnableGateInSummaryPrintByCashier);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.EnableAntiPassback);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.AcceptRegisterTicketOnly);
            DBMnt.SaveParam(DBManage.TBsysParam.paramType.EnableAutoReportTicket);

            Cursor.Current = Cursors.Default;
            MessageBox.Show("บันทึกสำเร็จ", "สถานะการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            saveParameter();
        }
        
        
        reportReceipt rtReceipt;
        reportChkIn rtChkIn;
        reportCashierLogout rtCashierLogout;
        reportTakeTicketReceipt rtTakeTicketReceipt;

        static General.typeOfReport reportType;
        static XRDesignMdiController mdiController;
       

        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            mdiController.AddCommandHandler(new SaveCommandHandler(panel));
            mdiController.SetCommandVisibility(ReportCommand.NewReport, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.OpenFile, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);
            mdiController.SetCommandVisibility(ReportCommand.SaveAll, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);

        }

        public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
        {
            XRDesignPanel panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this.panel = panel;
              
            }

            public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command, object[] args)
            {
                // Save the report.
                Save();
            }

            public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs ||
                    command == ReportCommand.Closing);
                return !useNextHandler;
            }

            void Save()
            {
                General gb = new General();
                string fileDest = string.Empty;

                switch (reportType)
                 {
                     case General.typeOfReport.receiptReport: fileDest = gb.reportReceiptFile; break;
                     case General.typeOfReport.CashierLogoutReport: fileDest = gb.reportCashierLogout; break;
                     case General.typeOfReport.chkInReport: fileDest = gb.reportChkIn; break;
                     case General.typeOfReport.TakeTicketReceipt: fileDest = gb.reportTakeTicketReceipt; break;
                  }
                 fileDest = gb.reportDir + "\\" + fileDest;

                // Write your custom saving here.
                // ...
                // For instance:
                panel.Report.SaveLayout(fileDest);
                // Prevent the "Report has been changed" dialog from being shown.
                panel.ReportState = ReportState.Saved;
            }
        }
        private void reportDesigner(General.typeOfReport e)
        {
            General gb = new General();
            reportType = e;
            if (!File.Exists(gb.reportGetFilePath(e)))
            {
                if (!Directory.Exists(gb.reportDir))
                {
                    Directory.CreateDirectory(gb.reportDir);
                }

                reportSaveLayOut(e);
            }
            // report.xrLabel1.LockedInUserDesigner = true;
            XRDesignForm form = new XRDesignForm();
            mdiController = form.DesignMdiController;
            mdiController.DesignPanelLoaded += mdiController_DesignPanelLoaded;
            mdiController.OpenReport(gb.reportGetFilePath(e));
            form.ShowDialog();
        }
        private void reportSaveLayOut(General.typeOfReport e)
        {
            General gb = new General();
            reportType = e;
            string fileName = gb.reportGetFileName(e);
            if (File.Exists(fileName))
            {
                File.Copy(fileName, gb.reportGetFilePath(e));
                return;
            }
            else
            {// สร้าง  file ดีฟอล 

                switch (e)
                {
                    case General.typeOfReport.receiptReport: rtReceipt.SaveLayout(gb.reportGetFilePath(e)); break;
                    case General.typeOfReport.CashierLogoutReport: rtCashierLogout.SaveLayout(gb.reportGetFilePath(e)); break;
                    case General.typeOfReport.chkInReport: rtChkIn.SaveLayout(gb.reportGetFilePath(e)); break;
                    case General.typeOfReport.TakeTicketReceipt: rtTakeTicketReceipt.SaveLayout(gb.reportGetFilePath(e)); break;
                 
                }
            }
        }
       
        private bool reportPublish( General.typeOfReport e)
        {
            General gb = new General();
            reportType = e;
            string SharePath = gb.GetSharePath();
            const string reportFolder = @"\reports\";

            if (File.Exists(SharePath + reportFolder + gb.reportGetFileName(e)))
            {
                File.Delete(SharePath + reportFolder + gb.reportGetFileName(e));
            }

            if (!Directory.Exists(SharePath + reportFolder))
            {
                try
                {
                    Directory.CreateDirectory(SharePath + reportFolder);
                }
                catch (IOException)
                {
                    return false;
                }
            } 
            
            try
            {
                string desFileName = gb.reportGetFileName(e);
                File.Copy(gb.reportGetFilePath(e), SharePath + reportFolder + desFileName);
            }
            catch (IOException)
            {
                return false;
                // MessageBox.Show("ตรวจสอบตำแหน่งการบันทึกภาพ", "การบันทึกภาพผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GC.Collect();
            return true;

        }
        private void reportDeploy(General.typeOfReport e)
        {
            reportType = e;
            Cursor.Current = Cursors.WaitCursor;
            General gb = new General();

            if (reportPublish(e))
            {
                txtReportInfo.Text = "ส่งออกรายงาน สำเร็จ";
                txtReportInfo.BLink();
            }
            Cursor.Current = Cursors.Default;
        }
        private void reportDefualt(General.typeOfReport e) {
            General gb = new General();
            reportType = e;
            Cursor.Current = Cursors.WaitCursor;

            if (!Directory.Exists(gb.reportDir))
            {
                Directory.CreateDirectory(gb.reportDir);
            }
            if (File.Exists(gb.reportGetFilePath(e)))
            {
                File.Delete(gb.reportGetFilePath(e));
            }
            reportSaveLayOut(e);
            reportDeploy(e);

            Cursor.Current = Cursors.Default;
            txtReportInfo.Text = "คืนค่าเดิมของ Report แล้ว";
            txtReportInfo.BLink();
        }
      

        private void btRepReportDefualt_Click(object sender, EventArgs e)
        {
            reportDefualt(General.typeOfReport.receiptReport);
        }
        private void btChkOutReportDesign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDesigner(General.typeOfReport.receiptReport);
            Cursor.Current = Cursors.Default;
        }
        private void btChkInReportDesign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDesigner(General.typeOfReport.chkInReport);
            Cursor.Current = Cursors.Default;
        }
        private void btChkOutReportDeploy_Click(object sender, EventArgs e)
        {
            reportDeploy(General.typeOfReport.receiptReport);
        }
        private void btCashierLogoutDeploy_Click(object sender, EventArgs e)
        {
            reportDeploy(General.typeOfReport.CashierLogoutReport);
        }

        private void btChkInReportDeploy_Click(object sender, EventArgs e)
        {
            reportDeploy(General.typeOfReport.chkInReport);
        }

        private void btCashierLogoutDesign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDesigner(General.typeOfReport.CashierLogoutReport);
            Cursor.Current = Cursors.Default;
        }

        private void btChkInReportDefualt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDefualt(General.typeOfReport.chkInReport);
            Cursor.Current = Cursors.Default;
        }

        private void btCashierLogoutReportDefualt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDefualt(General.typeOfReport.CashierLogoutReport);
            Cursor.Current = Cursors.Default;
        }

        private void btTicketRepReportDefualt_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDefualt(General.typeOfReport.TakeTicketReceipt);
            Cursor.Current = Cursors.Default;
        }

        private void btTicketRepReportDeploy_Click(object sender, EventArgs e)
        {
            reportDeploy(General.typeOfReport.TakeTicketReceipt);
        }

        private void btTicetRepReportDesign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            reportDesigner(General.typeOfReport.TakeTicketReceipt);
            Cursor.Current = Cursors.Default;
        }
    }
}