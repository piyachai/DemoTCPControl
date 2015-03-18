using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Data.Objects;
using System.Threading;
namespace BackOffice
{
    public partial class fmSysUser : DevExpress.XtraEditors.XtraForm
    {
        General gb;
        TypeRecordState flagNewOrUpdate = TypeRecordState.Save;
        public fmSysUser()
        {
            InitializeComponent();
            gb = new General();
            UpdateControlView();
            FormatGridView();
        }
        private void FormatGridView()
        {
            if (gridView1.Columns.Count == 0) { return; }
            //gridView1.Columns["OnwerCompanyName"].Caption = "ต้นสังกัด";
            gridView1.Columns["sysUserActive"].Caption = "Active";
            gridView1.Columns["sysUserLoginName"].Caption = "UserName";
            gridView1.Columns["sysUserName"].Caption = "ชื่อ-สกุล";
            gridView1.Columns["sysUserTel"].Caption = "Tel.";
            gridView1.Columns["sysUserPhone"].Caption = "Phone";
            gridView1.Columns["sysUserMail"].Caption = "Email";
            gridView1.Columns["sysUserTypeName"].Caption = "ระดับสิทธิ์";
            

            gridView1.Columns["sysUserAddr"].Visible= false;
            gridView1.Columns["sysUserID"].Visible= false;
            gridView1.Columns["sysUserPassword"].Visible = false;
            
            gridView1.Columns["sysUserExpiryDate"].Caption = "วันหมดอายุ";
            gridView1.Columns["sysUserExpiryDate"].Width = 60;
            //gridView1.Columns["OnwerCompanyName"].Width = 150;
            gridView1.Columns["sysUserActive"].Width = 30;
            gridView1.Columns["sysUserLoginName"].Width = 60;
        }
        private void ComboBoxGetData()
        {
            using (Dpark3Entities  db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var owner = from a in db.sysOwnerCompanies
                            where a.ownerCompanyActive == true
                            select new { a.ownerCompanyID, a.ownerCompanyName };
                    if (owner.Count() > 0)
                    {
                        cbOwnerCompany.BeginUpdate();
                        cbOwnerCompany.DisplayMember = "ownerCompanyName";
                        cbOwnerCompany.ValueMember = "ownerCompanyID";
                        cbOwnerCompany.DataSource = owner.ToList();
                        cbOwnerCompany.EndUpdate();
                    }
            }
        }
        private void UpdateControlView()
        {
            Cursor.Current = Cursors.WaitCursor;
            using (Dpark3Entities  db = new Dpark3Entities())
            {
             db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = from p in db.sysUsers
                         from a in db.sysOwnerCompanies
                         from b in db.sysUserTypes
     
                         where p.OwnerCompanyID == a.ownerCompanyID && p.sysUserActive == true
                         select new
                         {
                             sysUserLoginName = p.sysUserLoginName,
                             sysUserPassword = p.sysUserPassword,
                             sysUserActive = p.sysUserActive,
                             //OnwerCompanyName = a.ownerCompanyName,
                             sysUserName = p.sysUserName,
                             sysUserExpiryDate =p.sysUserExpiryDate,
                             sysUserTel = p.sysUserTel,
                             sysUserPhone = p.sysUserPhone,
                             sysUserMail = p.sysUserEmail,
                             sysUserAddr = p.sysUserAddr,
                             sysUserID  = p.sysUserID,
                             sysUserTypeName = b.sysUserTypeName
                         };
                try
                {
                    gridControl1.DataSource = ps.ToList();
                    ComboBoxGetData();
                    
                }
                catch (EntityException) {
                    MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
                }
                
            }
            dtpUserExpiryDate.Value = DateTime.Now.AddYears(3);
            Cursor.Current = Cursors.Default;
        }
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bt_del_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int[] selRows = gridView1.GetSelectedRows();
            for (int row = 0; row < selRows.Count(); row++)
            {
                selRows[row] = (int)gridView1.GetRowCellValue(selRows[row], "sysUserID");
            }
           
            Del(selRows);
            UpdateControlView();
            gb.ResetChildControls(this);
            flagNewOrUpdate = TypeRecordState.Save;
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (!gb.IsValidTextbox(txt_loginName)) { return; }
            if (!gb.IsValidTextbox(txt_name)) { return; }
            if (!gb.IsValidTextbox(txt_password)) { return; }
            if (!gb.IsValidTextbox(txt_passwdConfirm)) { return; }
            if (txt_password.Text != txt_passwdConfirm.Text) {
                MessageBox.Show("รหัสผ่าน และ ยืนยันรหัส่ผานไม่ตรงกัน", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
                txt_passwdConfirm.Text = string.Empty;
                txt_password.Text = string.Empty;
                return;
            }
  
            if (flagNewOrUpdate == TypeRecordState.Save)
            {
                sysUserNew();
            }
            else if (flagNewOrUpdate == TypeRecordState.Update)
            {
               sysUserUpdate();
            }
            gb.ResetChildControls(this);
            chk_UserActive.Checked = true;
            flagNewOrUpdate = TypeRecordState.Save;
            UpdateControlView();
        }
        private void sysUserUpdate() {
            Cursor.Current = Cursors.WaitCursor;
            sysUser sysUser = new sysUser();
            sysUser.OwnerCompanyID = Convert.ToInt32(cbOwnerCompany.SelectedValue);
            sysUser.sysUserActive = chk_UserActive.Checked;
            sysUser.sysUserLoginName = txt_loginName.Text;
            sysUser.sysUserPassword = txt_password.Text;
            sysUser.sysUserName = txt_name.Text;
            sysUser.sysUserTel = txt_tel.Text;
            sysUser.sysUserPhone = txt_phone.Text;
            sysUser.sysUserEmail = txt_email.Text;
            sysUser.sysUserAddr = txt_addr.Text;
            sysUser.sysUserExpiryDate = dtpUserExpiryDate.Value;
            sysUser.sysUserTypeID = Convert.ToInt32(cbsysUserType1.SelectedValue);
            sysUser.sysUserID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sysUserID"));
            DBManage.TBsysUser db = new DBManage.TBsysUser();
            int rowIndex = db.Update(sysUser);
            if (rowIndex == -1)
            {
                MessageBox.Show("โปรดตรวจสอบ UserName ห้ามซ้ำชื่อเดิม", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }
            gb.saveImg(img_userImg.Image, rowIndex.ToString(), TypeOfImg.sysUser);
            img_userImg.Image = global::BackOffice.Properties.Resources._1351994560_People_MSN;
            Cursor.Current = Cursors.Default;
        }
        private void sysUserNew() {
            Cursor.Current = Cursors.WaitCursor;
            sysUser sysUser = new sysUser();

                             sysUser.sysUserLoginName= txt_loginName.Text;
                             sysUser.sysUserPassword = txt_password.Text;
                             sysUser.sysUserName = txt_name.Text;
                             sysUser.OwnerCompanyID = Convert.ToInt32(cbOwnerCompany.SelectedValue);
                             sysUser.sysUserActive = chk_UserActive.Checked;
                             sysUser.sysUserTel = txt_tel.Text;
                             sysUser.sysUserPhone = txt_phone.Text;
                             sysUser.sysUserEmail = txt_email.Text;
                             sysUser.sysUserAddr =txt_addr.Text;
                             sysUser.sysUserExpiryDate = dtpUserExpiryDate.Value;
                             sysUser.sysUserTypeID = Convert.ToInt32(cbsysUserType1.SelectedValue);

                             DBManage.TBsysUser db = new DBManage.TBsysUser();
            if (db.New(sysUser) == -1)
            {
                MessageBox.Show("โปรดตรวจสอบ UserName ห้ามซ้ำชื่อเดิม", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            gb.saveImg(img_userImg.Image, sysUser.sysUserID.ToString(), TypeOfImg.sysUser);
            img_userImg.Image = global::BackOffice.Properties.Resources._1351994560_People_MSN;
            Cursor.Current = Cursors.Default;
        }
        private void Del (int[] sysUserID){           
            Cursor.Current = Cursors.WaitCursor;

            DBManage.TBsysUser sysUser = new DBManage.TBsysUser();
            sysUser.Del(sysUserID);
            foreach (int id in sysUserID)
            {
                gb.delImg(id.ToString(), TypeOfImg.sysUser);
            }
            img_userImg.Image = global::BackOffice.Properties.Resources._1351994560_People_MSN;
            Cursor.Current = Cursors.Default;
        }
        private void btUserName_Click(object sender, EventArgs e)
        {
            gb.ResetChildControls(this);
            flagNewOrUpdate = TypeRecordState.Save;
        }
        private void cbOwnerCompany_DropDown(object sender, EventArgs e)
        {
            ComboBoxGetData();
        }
        private void loadImgTH(object id)
        {
            Image mImg = gb.loadImg(TypeOfImg.sysUser, Convert.ToString(id));
            if (img_userImg.Created)
            {
                this.Invoke((Action)delegate
                {
                    img_userImg.Image = mImg;
                });
            }
        }
        private void GridviewRefresh(){
          Cursor.Current = Cursors.WaitCursor;

          if (gridView1.GetSelectedRows().Count() > 0)
          {
              if (gridView1.GetSelectedRows()[0] >= 0)
              {
                  //   int rowIndex = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketMemberID").ToString());
                  
                  int rowIndex = gridView1.FocusedRowHandle;
                  if (rowIndex >= gridView1.RowCount) { return; }
                  Cursor.Current = Cursors.WaitCursor;

                  txt_loginName.Text = gridView1.GetRowCellValue(rowIndex, "sysUserLoginName").ToString();
                  txt_name.Text = gridView1.GetRowCellValue(rowIndex, "sysUserName") ==null?string.Empty:  gridView1.GetRowCellValue(rowIndex, "sysUserName").ToString();
                  txt_addr.Text = gridView1.GetRowCellValue(rowIndex, "sysUserAddr") == null ? string.Empty : gridView1.GetRowCellValue(rowIndex, "sysUserAddr").ToString();
                  txt_email.Text = gridView1.GetRowCellValue(rowIndex, "sysUserMail").ToString();
                  txt_phone.Text = gridView1.GetRowCellValue(rowIndex, "sysUserPhone").ToString();
                  txt_tel.Text = gridView1.GetRowCellValue(rowIndex, "sysUserTel").ToString();
                  //cbOwnerCompany.Text = gridView1.GetRowCellValue(rowIndex, "OnwerCompanyName").ToString();
                  chk_UserActive.Checked = (bool)gridView1.GetRowCellValue(rowIndex, "sysUserActive");
                  txt_password.Text = gridView1.GetRowCellValue(rowIndex, "sysUserPassword").ToString();
                  string id = gridView1.GetRowCellValue(rowIndex, "sysUserID").ToString();
                  txt_passwdConfirm.Text = txt_password.Text;
                  DateTime dtExpiry = Convert.ToDateTime(gridView1.GetRowCellValue(rowIndex, "sysUserExpiryDate"));
                  dtpUserExpiryDate.Value = dtExpiry;
                  Thread TH = new Thread(new ParameterizedThreadStart(loadImgTH));
                  TH.Start(id);
                  flagNewOrUpdate = TypeRecordState.Update;

                  Cursor.Current = Cursors.Default;
              }
          }
             
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle == 0) { return; }

            if (
               (gridView1.GetSelectedRows().Count() > 0) &&
               (gridView1.RowCount > gridView1.FocusedRowHandle)
              )
            {
                try
                {
                    GridviewRefresh();
                }
                catch { }
            }
           
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == 0)
            {
                GridviewRefresh();
            }
        }

    }
}