using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BackOffice
{
    public partial class fmMainBackoffice : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static fmMainBackoffice staticVar = null;
        public fmMainBackoffice()
        {
            InitializeComponent();
            staticVar = this;
            General gb = new General();
            gb.ConnectToShare();
        }

        private void bt_DBConnect_config_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(typeof(fmDBConnectionConfig));
        }

          private void bt_controlList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
               ShowForm(typeof(fmControlList));
          }

          private void bt_sysParam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
              ShowForm(typeof(fmSystemParamConfig));
          }

          private void bt_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
          {
              DBManage.TBsysUser dbmnt = new DBManage.TBsysUser();
              dbmnt.LogOut(Globals.sysUserID);
              Close();
              fmLogin.staticVar.Show();
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
                fNew = (Form)CreateNewInstanceOfType(typeofForm);
            else
                if (fNew.IsDisposed)
                    fNew = (Form)CreateNewInstanceOfType(typeofForm);

            if (fOpen == null)
            {

                fNew.StartPosition = FormStartPosition.Manual;
            }
            
            fNew.MdiParent = this;
            fNew.Show();
            fNew.Focus();
            Cursor.Current = Cursors.Default;
        }

            private void btTicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm(typeof(fmTicket2));
        }

        private void fmMainBackoffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DBManage.TBsysUser dbmnt = new DBManage.TBsysUser();
            dbmnt.LogOut(Globals.sysUserID);
            
            fmLogin.staticVar.Show();
        
            closeTransactionCheckFrom();
            e.Cancel = false;
            
        }
        public void ButtonTicketRelease() {
            btTicket2.Checked = false;
            btTicketExpire.Checked = false;
            btTicketFree.Checked = false;
            btTicketPrepaid.Checked = false;
        }
       
        public void ButtonAcconutingRelease() {
            btInComeGateOut.Checked = false;
            btInCome.Checked = false;
            btInComeTicketSale.Checked = false;
        }
        public void ButtonTransactionRelease (){
            btCarInOutAll.Checked = false;
            btLongTimeParking.Checked = false;
            btEmerency.Checked = false;
            btEStamp.Checked = false;
            btCarInParking.Checked = false;
            btClearTicketInParking.Checked = false;
        }
        public void RibbonQueryState(bool state) {
            rbgPageQuery.Enabled = state;
        }
        private void closeTransactionCheckFrom() {
            this.Invoke(new EventHandler(delegate
            {
                //  try
                {
                    btCarInOutAll.Checked = false;
                    btLongTimeParking.Checked = false;
                    btEmerency.Checked = false;
                    btCarInParking.Checked = false;
                    btEStamp.Checked = false;
                    btClearTicketInParking.Checked = false;
                }
                //catch { }
            }));

        }
        private void closeAccountingFrom()
        {
            this.Invoke(new EventHandler(delegate
            {
                //  try
                {
                    btInComeGateOut.Checked = false;
                    btInCome.Checked = false;
                    btInComeTicketSale.Checked = false;
                }
                //catch { }
            }));

        }
        private void openTicketCheckForm() {
            if (fmTicket2.staticVar == null)
            {
                ShowForm(typeof(fmTicket2));
            }
  
            if (btTicket2.Checked)
            {
                fmTicket2.staticVar.typeofTicket = fmTicket2.typeOfTicket.all;
            }
            else if (btTicketPrepaid.Checked)
            {
                fmTicket2.staticVar.typeofTicket = fmTicket2.typeOfTicket.Prepaid;

            }
            else if (btTicketFree.Checked)
            {
                fmTicket2.staticVar.typeofTicket = fmTicket2.typeOfTicket.Free;
            }
            else if (btTicketExpire.Checked)
            {
                fmTicket2.staticVar.typeofTicket = fmTicket2.typeOfTicket.Expire;
            }

        }


        private void btCarInOutAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btCarInOutAll.Checked)
            {
                closeAccountingFrom();
              
             }
            Cursor.Current = Cursors.Default;
        }
        private void btLongTimeParking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btLongTimeParking.Checked)
            {
                closeAccountingFrom();
               
            } Cursor.Current = Cursors.Default;
        }

        private void btCarInParking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btCarInParking.Checked)
            {
                closeAccountingFrom();
         
            } Cursor.Current = Cursors.Default;
        }

        private void btEmerency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btEmerency.Checked)
            {
                closeAccountingFrom();
             
            } Cursor.Current = Cursors.Default;
        }

        private void btEStamp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btEStamp.Checked)
            {
                closeAccountingFrom();
    
            } Cursor.Current = Cursors.Default;
        }


  

        private void btTicketPrepaid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btTicketPrepaid.Checked)
            {
                openTicketCheckForm();
            } Cursor.Current = Cursors.Default;
        }

        private void btTicketFree_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btTicketFree.Checked)
            {
                openTicketCheckForm();
            } Cursor.Current = Cursors.Default;
        }

        private void btTicketExpire_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btTicketExpire.Checked)
            {
                openTicketCheckForm();
            } Cursor.Current = Cursors.Default;
        }

        private void btTicket2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btTicket2.Checked)
            {
                openTicketCheckForm();
            } Cursor.Current = Cursors.Default;
        }

         private void btClearTicketInParking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {

                Cursor.Current = Cursors.WaitCursor;
                if (btClearTicketInParking.Checked)
                {
                    closeAccountingFrom();
                 } 
                 Cursor.Current = Cursors.Default;
            }

       }
}