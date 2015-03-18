using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BackOffice
{
    public partial class reportCashierLogout : DevExpress.XtraReports.UI.XtraReport
    {
        public reportCashierLogout()
        {
            InitializeComponent();
            plbAccountingDiscount.Text = "0";
            plbAccountingPrices.Text = "0";
            plbAccountingReceive.Text = "0";
            plbCountOfChkOut.Text = "0";
            plbCountOfEmergency.Text = "0";
            plbCountOfEStamp.Text = "0";
            plbCountOfPaymentTime.Text = "0"; 
            
        }

    }
}
