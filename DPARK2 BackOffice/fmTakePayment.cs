using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackOffice.Properties;
//using DparkTerminal.Properties;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using System.Threading;
namespace BackOffice
{
    public enum TypeOfPayment { 
        takeDialyCard=2,takeMonthlyCard=3,GateOut=1,Balancing=4
    }

    public partial class fmTakePayment : Form
    {
        public string nameCompany { set; get; }

        public string numberCompany { set; get; }

        public string slipTitle { set; get; }

        public string sysUser { set; get; }
        public string printerName { set; get; }
        public bool AutoEnableReportChkOut{set;get;}
        public int ticketID { set; get; }
        public bool AutoEnableReportTakeTicket { set; get; }
        public TypeOfPayment PaymentType { set; get; }
        public int accountingInsertID { set; get; }
        reportReceipt reportRep;
        reportTakeTicketReceipt reportTakeTicketRep;


        public accounting getAccounting { get; set; }
        

        public reportTakeTicketInfo rptTakeTicketInfo
        {
            set;
            get;
        }
        public reportRecitptInfo rptRepInfo
        {
            set;
            get;
        }
        public fmTakePayment(TypeOfPayment paymentType, double prices)
        {
            InitializeComponent();
            PaymentType = paymentType;
            AutoEnableReportChkOut = false;
            AutoEnableReportTakeTicket = false;
            txtPrices.Text = prices.ToString();
            txtGrandTotal.Text = prices.ToString();
            
        }


        public void printSlip(reportReceipt reportRep)
        { 
            
            reportRep.ExportToPdf("lastprint.pdf");
            reportRep.Print(printerName);
        }

        public  void submitMoney() 
        {
            if (txtDiscount.Text == string.Empty) { txtDiscount.Text = "0"; }
            if (txtGetMoney.Text == string.Empty) { txtGetMoney.Text = "0"; }

            if (Convert.ToDouble(txtGetMoney.Text) < Convert.ToDouble(txtGrandTotal.Text))
            {
                DialogResult = DialogResult.None;
                txtInfo.Text= "รับเงินน้อยกว่าค่าเข้า";
                txtInfo.BLink();
                return;
            }else if (Convert.ToDouble(txtGrandTotal.Text)<0)
            {
                DialogResult = DialogResult.None;
                txtGrandTotal.Text = "0";
                txtInfo.Text= "ส่วนลด มากกว่ายอดเรียกเก็บไม่ได้";
                txtInfo.BLink();
                return ; 
            }

            accounting acc = new accounting();
            acc.accountingDateTime = DateTime.Now;
            acc.userID = Globals.sysUserID;
            acc.accountingDiscount =Convert.ToDouble( txtDiscount.Text);
            acc.accountingPrices = Convert.ToDouble(txtPrices.Text);
            acc.accountingTypeID =  (int)PaymentType;
            acc.accountingComment = txtComment.Text;
            acc.cancleProblemComment = "";



            //reportTakeTicketRep.lbNameCompany.Text = nameCompany;
            //reportTakeTicketRep.lbNumberCompany.Text = numberCompany;
            //reportTakeTicketRep.lbTitle.Text = slipTitle;
            //reportTakeTicketRep.lbSysUserName.Text = sysUser;
            //reportTakeTicketRep.lbInVoice.Text = acc.accountingID.ToString();
            //reportTakeTicketRep.lbSumPrice.Text = acc.accountingReceive.ToString();
            //reportTakeTicketRep.Print(printerName);
            //reportRep.ExportToPdf("lastprint.pdf");
            //reportRep.plbPrices.Text = "100";
            //reportRep.plbLostCardFee.Text = "cvcvcvv";
            //reportRep.Print(printerName);
            //reportRep.ExportToPdf("lastprint.pdf");

            //if (PaymentType == TypeOfPayment.GateOut)
            //{
            //    if (AutoEnableReportChkOut)
            //    {
            //        //reportRep.xrTaxID.Text = accountingInsertID.ToString("00000000");
            //        reportRep.Print(printerName);
            //    }
            //    reportRep.Print(printerName);
            //    reportRep.ExportToPdf("lastprint.pdf");
            //}
            //else if ((PaymentType == TypeOfPayment.takeDialyCard) || (PaymentType == TypeOfPayment.takeMonthlyCard))
            //{
            //    if (AutoEnableReportTakeTicket)
            //    {
            //        reportTakeTicketRep.Print(printerName);
            //    }
            //    //reportRep.ExportToXls("aa.xls");
            //    reportRep.ExportToPdf("lastprint.pdf");
            //    //throw new NotImplementedException(); 
            //}
            //else
            //{
            //    MessageBox.Show("เครื่องพิมพ์ไม่พร้อมใช้งาน fmTakePayment L:101");
            //}
            
            


            //DBManage.TBAccounting  DBMnt = new DBManage.TBAccounting();
            //accountingInsertID = DBMnt.New(acc);

            //if (accountingInsertID > 0)
            //{
            //    if (PaymentType == TypeOfPayment.GateOut)
            //    {
            //        if (AutoEnableReportChkOut)
            //        {
            //            //reportRep.xrTaxID.Text = accountingInsertID.ToString("00000000");
            //            reportRep.Print(printerName);
            //        }
            //        reportRep.ExportToPdf("lastprint.pdf");
            //    }
            //    else if((PaymentType == TypeOfPayment.takeDialyCard) ||( PaymentType == TypeOfPayment.takeMonthlyCard))
            //    {
            //        if (AutoEnableReportTakeTicket) {
            //            reportTakeTicketRep.Print(printerName);
            //        }
            //        //reportRep.ExportToXls("aa.xls");
            //        reportRep.ExportToPdf("lastprint.pdf");
            //        //throw new NotImplementedException(); 
            //    }else{
            //                MessageBox.Show("เครื่องพิมพ์ไม่พร้อมใช้งาน fmTakePayment L:101");
            //    }
            //}
            //else {
            //    MessageBox.Show("can't accounting new REc. fmTakePayment L:107");
            //}

            this.getAccounting = acc;

            DialogResult = DialogResult.OK;
            
            Close();
        }

        

        private void btGetMoney_Click(object sender, EventArgs e)
        {
           if (printerName != null)
           {
               reportRep.PrinterName = printerName;
               reportTakeTicketRep.PrinterName = printerName;
           }
           else {
               //throw new NoNullAllowedException();
           }
           submitMoney();
        }
        private void LoadReportTH()
        {
            General gb =new General();
            try
            {
                reportRep.LoadLayout(gb.reportGetFilePath(General.typeOfReport.receiptReport));
                reportTakeTicketRep.LoadLayout(gb.reportGetFilePath(General.typeOfReport.TakeTicketReceipt));
            }
            catch { }
        }
        private void fmPaymentCalculator_Shown(object sender, EventArgs e)
        {
            reportRep = new reportReceipt();
            reportTakeTicketRep = new reportTakeTicketReceipt();
            txtGetMoney.Focus();
            Thread t = new Thread(LoadReportTH);
            t.Start();
        }

        private void moneyReset() {
            txtGetMoney.Text = "0";
            txtDiscount.Text = "0";
        }
        private void btReset_Click(object sender, EventArgs e)
        {
            moneyReset();
        }

        private void bt20_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetMoney.Text))
            {
                txtGetMoney.Text = "0";
            }
            txtGetMoney.Text = string.Format("{0}", Convert.ToDouble(txtGetMoney.Text) + 20);
        }

        private void bt50_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetMoney.Text))
            {
                txtGetMoney.Text = "0";
            }
            txtGetMoney.Text = string.Format("{0}",Convert.ToDouble(txtGetMoney.Text) + 50);
        }

        private void bt1000_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetMoney.Text))
            {
                txtGetMoney.Text = "0";
            }
            txtGetMoney.Text = string.Format("{0}", Convert.ToDouble(txtGetMoney.Text) + 1000);
        }

        private void bt100_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetMoney.Text))
            {
                txtGetMoney.Text = "0";
            }
            txtGetMoney.Text = string.Format("{0}", Convert.ToDouble(txtGetMoney.Text) + 100);
        }

        private void bt500_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetMoney.Text))
            {
                txtGetMoney.Text = "0";
            }
            txtGetMoney.Text = string.Format("{0}", Convert.ToDouble(txtGetMoney.Text) + 500);
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == string.Empty) { return; }
            txtGrandTotal.Text = string.Format("{0}", (Convert.ToDouble(txtPrices.Text) - Convert.ToDouble(txtDiscount.Text)));
            CalMoneyReturn();
        }
        private void CalMoneyReturn() {
            if(string.IsNullOrEmpty(txtGetMoney.Text)){
                txtGetMoney.Text = "0";
            }
            if (string.IsNullOrEmpty(txtGrandTotal.Text))
            {
                txtGrandTotal.Text = "0";
            }
            double turn = Convert.ToDouble(txtGetMoney.Text) - Convert.ToDouble(txtGrandTotal.Text);
            if (turn > 0)
            {
                txtReturn.Text = string.Format("{0}", turn);
            }
            else
            {
                txtReturn.Text = "0";
            }
        }
        private void txtGetMoney_TextChanged(object sender, EventArgs e)
        {
            if (txtGetMoney.Text == string.Empty) { return; }
            CalMoneyReturn();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btGetMoney.PerformClick();
                return true;    // indicate that you handled this keystroke
            }

            if (keyData == Keys.Escape)
            {
                //btnGateOpen.PerformClick();
                btExit.PerformClick();

                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "0")
            {
                txtDiscount.Text = string.Empty;
            }
        }

        private void txtGetMoney_Enter(object sender, EventArgs e)
        {
            if (txtGetMoney.Text == "0")
            {
                txtGetMoney.Text = string.Empty;
            }
        }
        private void btFullDiscount_Click(object sender, EventArgs e)
        {
            txtDiscount.Text = txtPrices.Text;
        }
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtGetMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        public void formclose()
        {
            this.Close();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



       

        private void canclePayment()
        {
            Console.WriteLine("Exit!!!!");
            formclose();


        }
    }
}
