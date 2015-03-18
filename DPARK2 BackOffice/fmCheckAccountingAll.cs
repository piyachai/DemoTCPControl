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
    public partial class fmCheckAccountingAll : Form
    {
        public enum typeOfAccounting
        {
            all,
            GateOut=1,
            TicketSale
        }
        public typeOfAccounting typeofAccounting
        {
            get { return _typeOfAccounting; }
            set
            {
                _typeOfAccounting = value;
                switch (value)
                {
                    case typeOfAccounting.all: Text = "รายรับทั้งหมด";
                        break;
                    case typeOfAccounting.GateOut:
                        Text = "รายรับจากค่าจอดทางออก";
                        break;
                    case typeOfAccounting.TicketSale:
                        Text = "รายรับจากการจำหน่ายตั๋ว";
                        break;
                 
                }
                if (this.IsHandleCreated)
                {
                    fmMainBackoffice.staticVar.RibbonQueryState(false);
                    GridViewUpdate();
                    
                }
            }

        }
        string reportTitle { set; get; }
        public static fmCheckAccountingAll staticVar = null;
        public fmCheckAccountingAll()
        {
            InitializeComponent();
            staticVar = this;
            gb = new General();
        }
        General gb;
        Thread t;
        string fileName;
        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private typeOfAccounting _typeOfAccounting;
          private void FormatGridView()
        {
            if (gridView1.Columns.Count == 0) { return; }
            gridView1.Columns["accountingID"].Caption ="หมายเลขรายการ";
            gridView1.Columns["userID"].Visible = false;
            gridView1.Columns["accountingTypeID"].Visible = false;

            gridView1.Columns["accountingTypeName"].Caption ="ชนิดการเงิน";
            //gridView1.Columns["accountingTypeName"].Width = 120;
            //gridView1.Columns["accountingTypeName"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["accountingDateTime"].Caption = "วันที่บันทึก";
            gridView1.Columns["accountingDateTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["accountingDateTime"].DisplayFormat.FormatString = "ddMMMyyyy HH:mm";
            //gridView1.Columns["accountingDateTime"].Width = 130;
            gridView1.Columns["sysUserName"].Caption = "ผู้บันทึก";
            gridView1.Columns["accountingPrices"].Caption = "จำนวนเรียกเก็บ";
            gridView1.Columns["accountingDiscount"].Caption = "ส่วนลด";
            gridView1.Columns["accountingReceive"].Caption = "จำนวนที่รับมา";
            gridView1.Columns["accountingComment"].Caption = "หมายเหตุการเงิน";
            gridView1.Columns["accountingComment"].Visible = true;


            gridView1.Columns["priceProfileName"].Caption = "เกณฑ์ราคาตั๋ว";
            gridView1.Columns["numOfPerson"].Caption = "จำนวนคนสูงสุดที่เข้าได้";
            gridView1.Columns["realNumOfPerson"].Caption = "จำนวนคนที่เข้าจริง";
            gridView1.Columns["cancleProblemComment"].Caption = "หมายเหตุยกเลิกการนับ";

            gridView1.Columns["priceProfileName"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            gridView1.Columns["accountingID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns["accountingDiscount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["accountingReceive"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["accountingPrices"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            //gridView1.Columns["carPlateNumber"].Caption = "เลขทะเบียน";
            //gridView1.Columns["ticketMemberName"].Caption = "ชื่อสมาชิก";
            //gridView1.Columns["ticketNumber"].Caption = "หมายเลขบัตร";


            if (fmMainBackoffice.staticVar != null)
            {
                fmMainBackoffice.staticVar.RibbonQueryState(true);
            }
        }
      
        private void GridViewUpdateTH()
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


                    

                    //var ps = db.tr_accounting_saleTicket_bydate_userID_accType(dtFr, dtTo, null).ToList();
                    var ps = db.tr_accounting_with_numperson(dtFr, dtTo, null).ToList();
                    
                    oj = ps;
                    reportTitle = "รายงานการเงิน ขายตั๋ว ระหว่างวันที่ " + dtFr.ToString("dd/MMM/yyyy HH:mm") 
                                    + " ถึง " + dtTo.ToString("dd/MMM/yyyy HH:mm");

                 

                    if (oj != null)//.Count>0)
                    {     try
                            {
                        gridControl1.Invoke(new EventHandler(delegate
                        {
                                
                                gridControl1.BeginUpdate();
                                gridControl1.ForceInitialize();
                                gridView1.Columns.Clear();
                                gridControl1.DataSource = null;
                                gridControl1.DataSource = oj;
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

        private void GridViewUpdate()
        {
         //   Thread t = new Thread(GridViewUpdateTH);
           // t.Start();
            GridViewUpdateTH();
        }
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
                   // gridView1.ExportToXls(e.ToString());
                    
                    Cursor.Current = Cursors.WaitCursor;
                    PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                    link.CreateReportHeaderArea += link_CreateReportHeaderArea;
                    link.Component = gridControl1;
                    
                    link.Landscape = true;
                    link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    //link.ShowPreview();
                    link.ExportToXls(e.ToString());
                    btExcel.Enabled = true;
                    General gb = new General();
                    gb.OpenFile(e.ToString());

                    Cursor.Current = Cursors.Default;

                }
                catch { }
            }));


        }
        private void btPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.CreateReportHeaderArea += link_CreateReportHeaderArea;
            link.Component = gridControl1;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
            Cursor.Current = Cursors.Default;
        }

        void link_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DevExpress.XtraPrinting.TextBrick brick;

            brick = e.Graph.DrawString(reportTitle, Color.Navy, new RectangleF(0,0,800,50) ,DevExpress.XtraPrinting.BorderSide.None);

            brick.Font = new Font("Arial", 16);

            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

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

            staticVar = null;
            Console.WriteLine("TR Close");
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
