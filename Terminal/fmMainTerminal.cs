using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BackOffice;
using DparkTerminal.Properties;
using System.Linq;
namespace DparkTerminal
{
    public partial class fmMainTerminal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static fmMainTerminal staticVar = null;
        frmTCPControl mCashCtrl;
        public fmMainTerminal(string _sysUserLoginName )
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            staticVar = this;
            //active timer
            timer1.Interval = (1000) * (1);              // Timer will tick evert second
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();

            General gb = new General();

        }
        public void lbController(bool state) {
            if (state) { }
            else
            {
                lbSysUser.Text = "Failed";
                lbSysUser.BackColor = Color.Red;
            }
        }

        private void fmMainTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClose();
        }
        private void FormClose(){

            General gb = new General();
            gb.DisposeControls(this);
            trayIcon.Dispose();
            timer1.Dispose();
            trayIconMenu.Dispose();
            ribbonControl1.Dispose();
            statusStrip1.Dispose();
            xtraTabbedMdiManager1.Dispose();
            staticVar.Dispose();
            this.Dispose();
            mCashCtrl.Formclose();
            GC.Collect();

            fmLogin.staticVar.Show();
          
        }
        private void btClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormClose();
        }

        private Form GetOpenForm(Type typeofForm)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f1 in fc)
                if (f1.GetType() == typeofForm)
                    return f1;

            return null;
        }

        private object CreateNewInstanceOfType(Type typeofAny)
        {
            return Activator.CreateInstance(typeofAny);
        }

        private void ShowForm(Type typeofForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form fOpen = GetOpenForm(typeofForm);
            Form fNew = fOpen;
            if (fNew == null)
            {
                fNew = (Form)CreateNewInstanceOfType(typeofForm);

            }
            else
                if (fNew.IsDisposed)
                    fNew = (Form)CreateNewInstanceOfType(typeofForm);

            if (fOpen == null)
            {

                fNew.StartPosition = FormStartPosition.Manual;
            }
            try
            {

                fNew.MdiParent = this;
                fNew.Show();
                fNew.Focus();
            }
            catch { }
            Cursor.Current = Cursors.Default;
        }


        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }
        private void ts_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fmMainTerminal_Shown(object sender, EventArgs e)
        {

            mCashCtrl = new frmTCPControl();
            mCashCtrl.MdiParent = this;
            mCashCtrl.Show();

            //TCPClient tcp = new TCPClient("192.168.1.101");
        }

        //void mCashierReport_EventStatus(FrmMifare.Status_Mifare_Opeation status_oper)
        //{
        //    MessageBox.Show(status_oper.ToString());
        //}

     
        private void btSlipConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(typeof(fmSlipConfig));
        }
 

        private void btCashierReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmCashierReport mCashierReport = new fmCashierReport();
            mCashierReport.MdiParent = this;
            mCashierReport.Show();
        }

        private void btShowAccounting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmCheckAccountingAll fm = new fmCheckAccountingAll();
            fm.MdiParent = this;
            fm.typeofAccounting = fmCheckAccountingAll.typeOfAccounting.all;
            fm.Show();
        }

      

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmHelper fm = new fmHelper();
            fm.MdiParent = this;
            fm.Show();
        }

        private void btnSettingPrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmSettingPrice fm = new fmSettingPrice();
            fm.MdiParent = this;
            fm.Show();
        }

        private void btnAddSysUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            General gb = new General();
            using (Dpark3Entities db = new Dpark3Entities())
            {
   
                    db.Database.Connection.ConnectionString = gb.GetConnectionString();
                    //try
                    //{
                        var checkTypeUser = from a in db.sysUsers
                                            select a;
                        var chk = checkTypeUser.Where(k => k.sysUserID == fmLogin.staticVar.loginID).ToList();

                        if (chk.Count() > 0)
                        {
                            string typeUser = chk.First().sysUserTypeID.ToString();

                            if (typeUser == "1" || typeUser == "2")
                            {
                                ShowForm(typeof(fmSysUser));
                            }
                            else
                            {
                                MessageBox.Show("ระดับสิทธิ์ในการใช้งานของท่านไม่สามารถเข้าถึงการจัดการผู้ใช้ได้");
                            }

                        }
                      

                    //}
                    //catch
                    //{
                    //    MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    //return 0;
                    //}
                
            }


            

            //fmSysUser fm = new fmSysUser();
            //fm.MdiParent = this;
            //fm.Show();
        }

        private void btnSettingIPDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fmSettingIPDevice fm = new fmSettingIPDevice();
            fm.MdiParent = this;
            fm.Show();
        }



        private void settingSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DialogResult dlgResult = MessageBox.Show("เปิดการใช้งานการพิมพ์ใบเสร็จ?", "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dlgResult == DialogResult.Yes)
            //{
            //    // Yes, continue 
            //}
            //else if (dlgResult == DialogResult.No)
            //{
            //    // No, stop
            //}

            fmSlipConfig fm = new fmSlipConfig();
            fm.MdiParent = this;
            fm.Show();

        }

    }
}