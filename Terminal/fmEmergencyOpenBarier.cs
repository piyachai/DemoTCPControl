using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DparkTerminal.Properties;
using BackOffice;

namespace DparkTerminal
{
    public partial class fmEmergencyOpenBarier : DevExpress.XtraEditors.XtraForm
    {
        public int gateID { get; set; }
        public int tranID { set; get; }

        public int emergency = -1;
        public fmEmergencyOpenBarier(int tranID,string username,int gateID)
        {
            InitializeComponent();
            lbName.Text = username;
            lbTranID.Text = tranID.ToString();
            //ProcessWorkingMode();
            this.gateID = gateID;
            
        }

        private void frmxEmergencyOpenBarier_Shown(object sender, EventArgs e)
        {
            txtComment.Focus();
            emergency = -1;
        }


        public string problemMessage { get; set; }
        private void btSave_Click(object sender, EventArgs e)
        {
            //General gb = new General();

            //using (DLogisticsEntities db = new DLogisticsEntities())
            //{

            //    db.Database.Connection.ConnectionString = gb.GetConnectionString();

            //    transaction mTranSaction = new transaction();

            //    mTranSaction.transactionDatetTime = DateTime.Now;
            //    mTranSaction.transactionTypeId = "0";
            //    mTranSaction.personId = null;
            //    mTranSaction.personid2 = null;
            //    mTranSaction.carID = null;
            //    mTranSaction.ObjectID = null;
            //    mTranSaction.GateId_In = this.gateID; // Out = 2
            //    mTranSaction.GateId_out = 10;
            //    mTranSaction.sysUser_In = "admin";
            //    mTranSaction.sysUser_out = "admin";


            //    db.transactions.Add(mTranSaction);
            //    db.SaveChanges();
            //    tranID = mTranSaction.transactionID;
            //    DialogResult = DialogResult.OK;
            //}
            this.problemMessage = txtComment.Text;
            DialogResult = DialogResult.OK;
            GC.Collect();
            Close();
        }
        public void ProcessWorkingMode()
        {
            if (Settings.Default.terminalWorkingMode == (int)TerminalWorkingMode.GateIn)
            {
               // lyQuickComment.Visible = false;
                lyQuickComment.Visible = true;
                btCM1.Visible = true;
                btCM5.Visible = true;
                btCM6.Visible = true;
            }
            else if (Settings.Default.terminalWorkingMode == (int)TerminalWorkingMode.GateOut)
            {
                lyQuickComment.Visible = true;
                btCM1.Visible = true;
                btCM5.Visible = true;
                btCM6.Visible = true;
                btCM2.Visible = true;
                btCM3.Visible = true;
                btCM4.Visible = true;
            }
        }

        private void btComment_Click(object sender, EventArgs e)
        {
            txtComment.Text = ((Button)sender).Text;
        }

    }
}