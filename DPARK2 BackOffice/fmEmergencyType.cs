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
    public partial class fmEmergencyType : DevExpress.XtraEditors.XtraForm
    {
        General gb;
        TypeRecordState flagNewOrUpdate = TypeRecordState.Save;
        public fmEmergencyType()
        {
            InitializeComponent();
            gb = new General();
            UpdateControlView();
            FormatGridView();
        }
        private void FormatGridView()
        {
            gridView1.Columns["ticketMemberTypeName"].Caption = "ประเภทผู้ใช้พื้นที่จอด";
            gridView1.Columns["ticketMemberTypeComment"].Caption = "รายละเอียด";
            gridView1.Columns["ticketMemberTypeActive"].Caption = "Active";
            gridView1.Columns["ticketMemberTypeID"].Visible = false;
            gridView1.Columns["ticketMemberTypeActive"].Width = 30;

        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

         private void UpdateControlView()
        {
            Cursor.Current = Cursors.WaitCursor;
            using (DparkEntities db = new DparkEntities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = from p in db.tran_emergencyType
                         select new
                         {
                             emergencyTypeID = p.emergencyTypeID,
                             emergencyTypeName = p.emergencyTypeName
                         };
                try
                {
                    gridControl1.DataSource = ps.ToList();
                }
                catch (EntityException)
                {
                    MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            Cursor.Current = Cursors.Default;
        }
        private void GridviewRefresh(){
            Cursor.Current = Cursors.WaitCursor;
            txtEmerTypeName2.Text= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketMemberTypeComment").ToString();
       //     chk_visitorTypeActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketMemberTypeActive");
            flagNewOrUpdate = TypeRecordState.Update;
            Cursor.Current = Cursors.Default;}

        private void btDel_Click(object sender, EventArgs e)
        {
            Del();
        }
         private void Del (){           
            Cursor.Current = Cursors.WaitCursor;
            DparkEntities db = new DparkEntities();
            db.Database.Connection.ConnectionString = gb.GetConnectionString();
            ticketMemberType vstType = (from a in db.ticketMemberTypes
                                       
                                        where a.ticketMemberTypeID == Convert.ToInt32(gridView1.Columns["ticketMemberTypeID"].ToString())
                                    select a).Single();
          
            db.ticketMemberTypes.Remove(vstType);
            db.SaveChanges();
            Cursor.Current = Cursors.Default;
         }

         private void btNew_Click(object sender, EventArgs e)
         {
             gb.ResetChildControls(this);
             flagNewOrUpdate = TypeRecordState.Save;
         }

         private void btSave_Click(object sender, EventArgs e)
         {
             if (!gb.IsValidTextbox(txtEmerTypeName2)) { return; }

             if (flagNewOrUpdate == TypeRecordState.Save)
             {
                 visitorTypeNew();
             }
             else if (flagNewOrUpdate == TypeRecordState.Update)
             {
                 visitorTypeUpdate();
             }
             gb.ResetChildControls(this);
            // chk_visitorTypeActive.Checked = true;
             flagNewOrUpdate = TypeRecordState.Save;
             UpdateControlView();
         }
         private void visitorTypeUpdate()
         {
             Cursor.Current = Cursors.WaitCursor;
             sysUser sysUser = new sysUser();
             ticketMemberType vstType = new ticketMemberType();

            // vstType.ticketMemberTypeComment= txtVisitorTypeComment.Text;
            // vstType.ticketMemberTypeActive = chk_visitorTypeActive.Checked;
             vstType.ticketMemberTypeName = txtEmerTypeName2.Text;
             vstType.ticketMemberTypeID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketMemberTypeID"));

             DBManage.TBvisitorType db = new DBManage.TBvisitorType();
             if (db.Update(vstType) == -1)
             {
                 MessageBox.Show("โปรดตรวจสอบ ชื่อประเภทผู้ใช้พื้นที่จอด ไม่สามารถซ้ำกันได้", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             Cursor.Current = Cursors.Default;
         }
         private void visitorTypeNew()
         {
             Cursor.Current = Cursors.WaitCursor;
             ticketMemberType vstType = new ticketMemberType();

             vstType.ticketMemberTypeComment = txtEmerTypeName2.Text;
            // vstType.ticketMemberTypeActive = chk_visitorTypeActive.Checked;
             vstType.ticketMemberTypeName = txtEmerTypeName2.Text;

             DBManage.TBvisitorType db = new DBManage.TBvisitorType();
             if (db.New(vstType) == -1)
             {
                 MessageBox.Show("โปรดตรวจสอบ การป้อนข้อมูล", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             Cursor.Current = Cursors.Default;
         }

         private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
         {
             GridviewRefresh();
         }
        }
    }
