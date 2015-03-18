using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Threading;
using DevExpress.XtraPrinting;
using System.Data.Entity;

namespace BackOffice
{
    public partial class fmCheckCashierStatic: Form
    {

        public fmCheckCashierStatic()
        {
            InitializeComponent();
               gb = new General();
               comboCashierPopulate();
        }
        General gb;
        Thread t;
        string fileName;
        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }
 
          private void FormatGridView()
        {
            if (gridView1.Columns.Count == 0) { return; }

            gridView1.Columns["ChkOutUser"].Caption = "ชื่อพนักงาน";
            gridView1.Columns["ChkOutUser"].Width = 150;
            gridView1.Columns["ChkOutUser"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["sysUserID"].Visible = false;

            gridView1.Columns["tranChkOut"].Caption = "วันที่ปฏิบัติงาน";
            gridView1.Columns["tranChkOut"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["tranChkOut"].DisplayFormat.FormatString = "ddMMMyyyy";
            gridView1.Columns["tranChkOut"].Width = 150;
            gridView1.Columns["tranChkOut"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["accountingPrices"].Caption = "จำนวนรียกเก็บ(บาท)";
            gridView1.Columns["accountingPrices"].Width = 100;
            gridView1.Columns["accountingPrices"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["accountingPrices"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gridView1.Columns["accountingDiscount"].Caption = "ยอดส่วนลด(บาท)";
            gridView1.Columns["accountingDiscount"].Width = 100;
            gridView1.Columns["accountingDiscount"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["accountingDiscount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gridView1.Columns["accountingReceive"].Caption = "จำนวนที่ได้รับ(บาท)";
            gridView1.Columns["accountingReceive"].Width = 100;
            gridView1.Columns["accountingReceive"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["accountingReceive"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;


            gridView1.Columns["countOfChkOut"].Caption = "รถออก(คัน)";
            gridView1.Columns["countOfChkOut"].Width = 100;
            gridView1.Columns["countOfChkOut"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["countPaymentTime"].Caption = "เสียค่าบริการ(คัน)";
            gridView1.Columns["countPaymentTime"].Width = 100;
            gridView1.Columns["countPaymentTime"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["countEStamp"].Caption = "EStamp(ครั้ง)";
            gridView1.Columns["countEStamp"].Width = 100;
            gridView1.Columns["countEStamp"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["countEmergency"].Caption = "เปิดฉุกเฉิน(ครั้ง)";
            gridView1.Columns["countEmergency"].Width = 100;
            gridView1.Columns["countEmergency"].OptionsColumn.FixedWidth = true;

        }
        private void comboCashierPopulate(){
            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();

                cbSysUser.Properties.DataSource = null;
                cbSysUser.Properties.DataSource = db.view_accounting_all.OrderBy(i => i.sysUserName).Select(i => new { i.sysUserName, i.userID }).Distinct().ToList();
          
                // cbSysUser.Properties.DataSource = db.tr_report_cashier(new DateTime(2012, 1, 1), DateTime.Now.Date, null).ToList();
               
                cbSysUser.Properties.ForceInitialize();
                cbSysUser.Properties.PopulateColumns();
                cbSysUser.Properties.DisplayMember = "sysUserName";
                cbSysUser.Properties.ValueMember = "userID";
                cbSysUser.Properties.Columns["userID"].Visible = false;
                cbSysUser.Properties.Columns["sysUserName"].Caption = "ชื่อพนักงาน";
            }
        }
        private void GridViewUpdate()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (Dpark3Entities db = new Dpark3Entities())
                {
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


                    object oj = null;

                 //   var ps;
                    if (cbSysUser.ItemIndex < 1)
                    {
                       var ps = db.tr_report_cashier(dtFr, dtTo, null);
                       oj = ps;
                    }
                    else {
                        var ps = db.tr_report_cashier(dtFr, dtTo, (int)cbSysUser.GetColumnValue("userID"));
                       oj = ps;
                    }
                       
               
                    if (oj != null)//.Count>0)
                    {     try
                            {
                        gridControl1.Invoke(new EventHandler(delegate
                        {
                         
                                gridControl1.BeginUpdate();
                                gridControl1.ForceInitialize();
                                gridView1.Columns.Clear();
                                gridControl1.DataSource = null;
                                gridControl1.DataSource = oj;// ps;
                                gridView1.PopulateColumns();
                                gridView1.ShowFindPanel();
                                FormatGridView();
                                gridControl1.EndUpdate();

                            
                        }));
                        }
                           catch { }

                    }

                }
            }
            catch (EntityException)
            {
                MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            GC.Collect();
            Cursor.Current = Cursors.Default;
        }

       // private void GridViewUpdate()
       // {
           // Thread t = new Thread(GridViewUpdateTH);
           // t.Start();
       // }
        private void btExcel_Click(object sender, EventArgs e)
        {
            General gb = new General();
            fileName = gb.ShowSaveFileDialog("Microsoft Excel", "Excel File|*.xls");
            if (fileName != "")
            {
                btExcel.Enabled = false;

                t = new Thread(exportTOXLS);
                t.Start(fileName);
            }
        }
        private void exportTOXLS(object e)
        {

            bt_find.Invoke(new EventHandler(delegate
            {
                try
                {
                    gridView1.ExportToXls(e.ToString());
                    btExcel.Enabled = true;
                    General gb = new General();
                    gb.OpenFile(e.ToString());

                }
                catch { }
            }));


        }
        private void btPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
            Cursor.Current = Cursors.Default;
        }

        private void bt_find_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GridViewUpdate();
            Cursor.Current = Cursors.Default;
        }

        public void FormClose()
        {
            if (fmMainBackoffice.staticVar != null)
            {
                fmMainBackoffice.staticVar.ButtonAcconutingRelease();
            }
            if (t != null)
            {
                t.Abort();
            }
            t = null;
            gb = null;

            this.Invoke(new EventHandler(delegate
            {
                //  try
                {
                    gridView1.Dispose();
                    gridControl1.Dispose();
                }
                //catch { }
            }));
            //Close();
            this.Dispose();
            GC.Collect();

        }

        private void fmCheckAccountingAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClose();
        }

        private void dtChkInToTime_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_find.Focus();
                GridViewUpdate();
            }

        }

    }
}
