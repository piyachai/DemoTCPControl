using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackOffice
{
    public partial class fmTicket2 : Form
    {
        TypeRecordState flagNewOrUpdate = TypeRecordState.Save;
        
        General gb;
        public static fmTicket2 staticVar = null;
        public reportTakeTicketInfo rptTakeTicketInfo;
    
        public fmTicket2()
        {
            InitializeComponent();
            gb = new General();
            rptTakeTicketInfo = new reportTakeTicketInfo();
            staticVar = this;
            DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();
            DBMnt.ReadAll();
            AutoEnableReportTakeTicket = DBMnt.EnableAutoReportTicket;

        }
        private bool AutoEnableReportTakeTicket;
        private double dialyPrices { set; get; }
        private double monthlyPrices { set; get; }
        public enum typeOfTicket
        {
            all,
            Prepaid,
            Free,
            Expire
        }
        private typeOfTicket _typeOfTicket;
        public typeOfTicket typeofTicket
        {
            get { return _typeOfTicket; }
            set
            {
                _typeOfTicket = value;
                switch (value)
                {
                    case typeOfTicket.all: Text = "บัตรทุกประเภท";
                        gridView1.ActiveFilterString =string.Empty;
                        break;
                    case typeOfTicket.Prepaid:
                        Text = "บัตร รายวัน/รายเดือน";
                        gridTicketPaidFilter(); // รายวัน เดือน
                        break;
                    case typeOfTicket.Free:
                        Text = "บัตรฟรี";
                        gridTicketFreeFilter();
                        break;
                    case typeOfTicket.Expire:
                        Text = "บัตรหมดอายุ";
                       gridTicketExpiryFilter();
                        break;

                }
                if (this.IsHandleCreated)
                {
                  GridviewRefresh();
                }
            }

        }
        private void ShowTicketPrice()
        {

            if (this.DesignMode) { return; }
            Cursor.Current = Cursors.WaitCursor;
            int id = 1+(int)(DateTime.Now.DayOfWeek);
            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var qs =
                         (from q in db.tran_priceDialy
                          where (q.priceDialyID == id)
                          select q).First();
                var ps = (from p in db.param_systemParam
                          where (p.systemParamKey == "pricesMonthlyTicket")
                          select p).First();
                DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();
                DBMnt.ReadAll();
                monthlyPrices = DBMnt.pricesMonthlyTicket;
                
                try
                {
                    dialyPrices = qs.priceDialyRate;
                    monthlyPrices = monthlyPrices;
                  
                    calcTotalPricse();
                }
                catch (EntityException)
                {
                }

            }
            Cursor.Current = Cursors.Default;
        }
        private void calcTotalPricse()
        {
            if (rdTicketTypeDialy.Checked)
            {
                txtDialyPrices.Text = dialyPrices.ToString();
                txtTotalPrices.Text = (dialyPrices * Convert.ToDouble(nmQuatity.Value)).ToString();
            }
            else if (rdTicketTypeMonthly.Checked)
            {
                txtDialyPrices.Text = monthlyPrices.ToString();
                txtTotalPrices.Text = (monthlyPrices * Convert.ToDouble(nmQuatity.Value)).ToString();
            }

        }
        /*
        private void formReset()
        { // summit new form
            txtTicketNo.Text = string.Empty;
            isReNewTicket = false;   
            nmQuatity.Value = 1;
            dtpEnd.Enabled = true;
            dtpBegin.Enabled = true;
            gpTicketType.Enabled = true;
        }*/
        private void defaultControl()
        {
            gb.SetKeyboardLayout("eng");
            nmQuatity.Minimum = 1;
            nmQuatity.Value = 1;
            isReNewTicket = false;   
            flagNewOrUpdate = TypeRecordState.Save;
            txtCarPlateNumber.Text = string.Empty;
            chkActive.Checked = true;
            txtTicketNo.Text = string.Empty;
            dtpBegin.MinDate = DateTime.Now;
            dtpBegin.Value = DateTime.Now;
            
            dtpEnd.MaxDate = dtpBegin.Value.AddYears(3);
            dtpEnd.MinDate = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddYears(1);
            txtTicketNo.Focus();
            TicketMemberControlClear();
            CarControlClear();
            ShowTicketPrice();
            rdTicketTypeDialy.Checked = true;
            btReNewTicket.Enabled = false;
            btReNewTicket.Visible = true;
            gpShowPrices.Visible = false;

        }
        public void ComboBoxCarGetData()
        {
            using (Dpark3Entities db = new Dpark3Entities())
            {   db.Database.Connection.ConnectionString = gb.GetConnectionString();

                cbCarPlateNumber.BeginUpdate();
                cbCarPlateNumber.ValueMember = "carID";
                cbCarPlateNumber.DisplayMember = "carPlateNumber";
                var ps = db.cars.OrderBy(i => i.carPlateNumber).Select(i => new { i.carID, i.carPlateNumber }).ToList();
                cbCarPlateNumber.DataSource = ps;
                cbCarPlateNumber.SelectedText = string.Empty;
                cbCarPlateNumber.Text = null;
                cbCarPlateNumber.EndUpdate();
            }
        }
        public void ComboBoxTicketMemberGetData() {

            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();

                cbTicketMember.BeginUpdate();
                cbTicketMember.ValueMember = "ticketMemberID";
                cbTicketMember.DisplayMember = "ticketMemberName";
                var ps = db.ticketMembers.OrderBy(i => i.ticketMemberName).Select(i => new { i.ticketMemberID, i.ticketMemberName }).ToList();
                cbTicketMember.DataSource = ps;
               
                cbTicketMember.SelectedText = string.Empty;
                cbTicketMember.Text = null;
                cbTicketMember.EndUpdate();
            }
        }
        public void ComboBoxGetData()
        {
            ComboBoxTicketMemberGetData();
            ComboBoxCarGetData();
            
        }
        private void controlState(bool state) {
            btSave.Enabled = state;
            btDel.Enabled = state;
            btTicketMemberEdit.Enabled = state;
            btTicketMemberNew.Enabled = state;
            btCarEdit.Enabled = state;
            btCarNew.Enabled = state;
            cbCarPlateNumber.Enabled = state;
            cbTicketMember.Enabled = state;
            dtpBegin.Enabled = state;
            dtpEnd.Enabled = state;
            gpTicketType.Enabled = state;
            
        }
        private void enableControl() { controlState(true); ticketTypeRadioProcess(); }
        private void disableControl() { controlState(false);
                 
        }
        public void UpdateControlView()
        {

            if (this.DesignMode) { return; }
            Cursor.Current = Cursors.WaitCursor;
            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = db.view_ticketInfo.ToList();
              
                try
                {
                    gridControl1.BeginUpdate();
                    gridControl1.ForceInitialize();
                    gridControl1.DataSource = ps.ToList();
                    gridControl1.EndUpdate();
                    ComboBoxGetData();
                    defaultControl();

                }
                catch (EntityException)
                {
                    MessageBox.Show("โปรดตรวจสอบการเชื่อมต่อ,ฐานข้อมูล", "ไม่สามารถติดต่อฐานข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            Cursor.Current = Cursors.Default;
        }
        private void FormatGridView()
        {
            if (gridView1.Columns.Count == 0) { return; }
            gridView1.Columns["ticketNumber"].Caption = "หมายเลขบัตร";
            gridView1.Columns["ticketNumber"].Width = 100;
            gridView1.Columns["ticketNumber"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["ticketNumber"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

          
            gridView1.Columns["ticketMemberName"].Caption = "เจ้าของบัตร";
            gridView1.Columns["ticketMemberName"].Width = 120;
            gridView1.Columns["ticketMemberName"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["ticketStartDate"].Caption = "วันที่เริ่มใช้งานได้";
            gridView1.Columns["ticketExpiryDate"].Caption = "วันหมดอายุ";

            gridView1.Columns["ticketTypeName"].Caption = "ประเภทบัตร";
            gridView1.Columns["ticketTypeName"].Width = 80;
            gridView1.Columns["ticketTypeName"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["ticketMemberTypeName"].Caption = "ประเภทสมาชิก";

            gridView1.Columns["ticketActive"].Caption = "Active";
            gridView1.Columns["ticketActive"].Width = 40;
            gridView1.Columns["ticketActive"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["sysUserName"].Caption = "ผู้ออกบัตร";
            gridView1.Columns["carPlateNumber"].Caption = "เลขทะเบียน";

            gridView1.Columns["ticketRemainDay"].Caption = "อายุคงเหลือ";

            gridView1.Columns["ticketRemainSecond"].Visible = false;
            gridView1.Columns["ticketID"].Visible = false;
            gridView1.Columns["ticketDateUpdate"].Visible = false;
            gridView1.Columns["ticketTypeID"].Visible = false;
            gridView1.Columns["ticketMemberID"].Visible = false;
            gridView1.Columns["ticketMemberTel"].Visible = false;
            gridView1.Columns["ticketMemberAddr"].Visible = false;
            gridView1.Columns["ticketMemberEmail"].Visible = false;

            gridView1.Columns["userID_Create"].Visible = false;

            gridView1.Columns["ticketCredit"].Visible = false;
            gridView1.Columns["ticketRemainTimes"].Visible = false;
            gridView1.Columns["carBrandName"].Visible = false;
            gridView1.Columns["carTypeName"].Visible = false;
            gridView1.Columns["provinceName"].Visible = false;
            gridView1.Columns["ticketMemberID"].Visible = false;
            gridView1.Columns["carModel"].Visible = false;
            gridView1.Columns["carColor"].Visible = false;
            gridView1.Columns["carID"].Visible = false;
        }
        private void GridviewRefresh()
        {
            //defaultControl();
            int rowIndex = gridView1.FocusedRowHandle;
            if (rowIndex < 0) { return; }

            Cursor.Current = Cursors.WaitCursor;
            
            txtTicketNo.Text = gridView1.GetRowCellValue(rowIndex, "ticketNumber").ToString();
   
            chkActive.Checked = (bool)gridView1.GetRowCellValue(rowIndex, "ticketActive");

            txtCarPlateNumber.Text = gridView1.GetRowCellValue(rowIndex, "carPlateNumber") == null ? string.Empty : gridView1.GetRowCellValue(rowIndex, "carPlateNumber").ToString();
            txtCarColor.Text = gridView1.GetRowCellValue(rowIndex, "carColor") == null ? string.Empty : gridView1.GetRowCellValue(rowIndex, "carColor").ToString();
            txtCarModel.Text = gridView1.GetRowCellValue(rowIndex, "carModel") == null ? string.Empty : gridView1.GetRowCellValue(rowIndex, "carModel").ToString();

            if (gridView1.GetRowCellValue(rowIndex, "ticketMemberID") != null)
            {
                cbTicketMember.SelectedValue = gridView1.GetRowCellValue(rowIndex, "ticketMemberID");
            }
            else
            {
                TicketMemberControlClear();
            }

            if (gridView1.GetRowCellValue(rowIndex, "carID") != null)
            {
                cbCarPlateNumber.SelectedValue = gridView1.GetRowCellValue(rowIndex, "carID");
        
            }
            else
            {
                CarControlClear();
            }

            flagNewOrUpdate = TypeRecordState.Update;
            rd_setIndex((int)gridView1.GetRowCellValue(rowIndex, "ticketTypeID"));

            btSave.Enabled = true;
            btDel.Enabled = true;
            cbCarPlateNumber.Enabled = true;
            cbTicketMember.Enabled = true;
            btTicketMemberNew.Enabled = true;
            btCarNew.Enabled = true;
            gpShowPrices.Visible = false;
            dtpBegin.MinDate = Convert.ToDateTime(gridView1.GetRowCellValue(rowIndex, "ticketStartDate"));
            dtpBegin.Value = dtpBegin.MinDate; 
            
            if (
                ((int)gridView1.GetRowCellValue(rowIndex, "ticketTypeID") == (int)TypeOfTicket.FreeTicket) ||
                ((int)gridView1.GetRowCellValue(rowIndex, "ticketTypeID") == (int)TypeOfTicket.VisitorTicket)
                )
            { 
                // ตั๋วฟรี  & Visitor  ไม่ต้อง คิดเงิน ค่าเพิ่มวัน
                dtpEnd.MaxDate = Convert.ToDateTime(gridView1.GetRowCellValue(rowIndex, "ticketExpiryDate")).AddYears(10);
                dtpEnd.MinDate = dtpBegin.Value.AddSeconds(-1) ;
                dtpEnd.Value = Convert.ToDateTime(gridView1.GetRowCellValue(rowIndex, "ticketExpiryDate"));
                dtpBegin.Enabled = true;
                dtpEnd.Enabled = true;
                btReNewTicket.Enabled = false;
            }
            else { 
                //ตั๋วจ่ายเงิน
                dtpEnd.MaxDate = Convert.ToDateTime(gridView1.GetRowCellValue(rowIndex, "ticketExpiryDate"));
                dtpEnd.Value = dtpEnd.MaxDate;

                dtpBegin.Enabled = false;
                dtpEnd.Enabled = false;
                btReNewTicket.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }
        
        private void takeVisitorCard()
        {
            if (flagNewOrUpdate == TypeRecordState.Save)
            {
                TicketNew();
            }
            else if (flagNewOrUpdate == TypeRecordState.Update)
            {
                TicketUpdate();
            }
        }
        private void ComBoBoxAllowList(object sender, KeyPressEventArgs e)
        {
                        ComboBox cb = (ComboBox)sender;
                cb.DroppedDown = true;
                string strFindStr = "";
                if (e.KeyChar == (char)8)
                {
                    if (cb.SelectionStart <= 1)
                    {
                        cb.Text = "";
                        return;
                    }
 
                    if (cb.SelectionLength == 0)
                        strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                    else
                        strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
                }
                else
                {
                    if (cb.SelectionLength == 0)
                        strFindStr = cb.Text + e.KeyChar;
                    else
                        strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
                }
                int intIdx = -1;
                // Search the string in the ComboBox list.
                intIdx = cb.FindString(strFindStr);
                if (intIdx != -1)
                {
                    cb.SelectedText = "";
                    cb.SelectedIndex = intIdx;
                    cb.SelectionStart = strFindStr.Length;
                    cb.SelectionLength = cb.Text.Length;
                    e.Handled = true;
                }
                else
                    e.Handled = true;
        }
        private void TicketTopUp() {
            Cursor.Current = Cursors.WaitCursor;
            ticket tk = new ticket();

            tk.ticketStartDate = dtpBegin.Value;
            tk.ticketExpiryDate = dtpEnd.Value;
            tk.ticketID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketID"));
            tk.ticketNumber = txtTicketNo.Text;
            tk.ticketTypeID = rd_getIndex();
            tk.userID_Create = Globals.sysUserID;
            tk.ticketActive = chkActive.Checked;
            tk.ticketRemainTimes = 0;
            tk.ticketCredit = 0;
            tk.ticketMemberID = (int)cbTicketMember.SelectedValue;
            tk.carID = (int)cbCarPlateNumber.SelectedValue;

            DBManage.TBticket db = new DBManage.TBticket();

            using (Dpark3Entities db1 = new Dpark3Entities())
            {
                db1.Database.Connection.ConnectionString = gb.GetConnectionString();
                var ps = db1.sysUsers.Select(i => new { i.sysUserName, i.sysUserID }).Where(i => i.sysUserID == Globals.sysUserID).ToList();
                rptTakeTicketInfo.sysUserName = ps.Select(i => i.sysUserName).First().ToString();
            }

            //rptTakeTicketInfo.carPlateNumber = cbCarPlateNumber.Text;
            //rptTakeTicketInfo.ticketExpiryDate = tk.ticketExpiryDate;
            //rptTakeTicketInfo.ticketMemberName = cbTicketMember.Text;

            //rptTakeTicketInfo.ticketNumber = tk.ticketNumber;
            //rptTakeTicketInfo.ticketStartDate = tk.ticketStartDate;
            //rptTakeTicketInfo.ticketTypeName = rd_getName();

            string tmpUnit = string.Empty;
            TypeOfPayment _typeOfPayment= TypeOfPayment.takeDialyCard ; // init 
            
            if (rdTicketTypeDialy.Checked)
            {
                tmpUnit = " วัน";
                _typeOfPayment = TypeOfPayment.takeDialyCard;
            }
            else if (rdTicketTypeMonthly.Checked)
            {
                tmpUnit = " เดือน";
                _typeOfPayment = TypeOfPayment.takeMonthlyCard;
            }
            //rptTakeTicketInfo.pageTitle = "เพิ่มเวลาให้บัตร " + nmQuatity.Value.ToString() + tmpUnit;

            using (fmTakePayment fm = new fmTakePayment(_typeOfPayment, Convert.ToDouble(txtTotalPrices.Text)))
            {
                fm.rptTakeTicketInfo = rptTakeTicketInfo;
                fm.AutoEnableReportTakeTicket = AutoEnableReportTakeTicket;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                        int rowIndex = db.Update(tk);
                        if (rowIndex == -1)
                        {
                            MessageBox.Show("โปรดตรวจสอบ เลขบัตร ห้ามมีการใช้ซ้ำของเดิม", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
    
                    db.Update(tk);
                }

                fm.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }
        private void TicketUpdate()
        {
            Cursor.Current = Cursors.WaitCursor;
            ticket tk = new ticket();
            tk.ticketNumber = txtTicketNo.Text;
            tk.ticketTypeID = rd_getIndex();

  
            if ((tk.ticketTypeID  !=(int)TypeOfTicket.DialyTicket) ||(tk.ticketTypeID  !=(int)TypeOfTicket.MonthlyTicket) ){ 
                tk.ticketStartDate = dtpBegin.Value;
                tk.ticketExpiryDate = dtpEnd.Value;
            }

            tk.userID_Create = Globals.sysUserID;
            tk.ticketActive = chkActive.Checked;
            tk.ticketRemainTimes = 0;
            tk.ticketCredit = 0;
            tk.ticketID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ticketID"));
           
            if (cbTicketMember.SelectedValue != null)
            {
                tk.ticketMemberID = (int)cbTicketMember.SelectedValue;
            }
            
            if (cbCarPlateNumber.SelectedValue != null) {
                tk.carID = (int)cbCarPlateNumber.SelectedValue;
            }
           
            DBManage.TBticket db = new DBManage.TBticket();
           // try
            {
                int rowIndex = db.Update(tk);
                if (rowIndex == -1)
                {
                    MessageBox.Show("โปรดตรวจสอบ เลขบัตร ห้ามมีการใช้ซ้ำของเดิม", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //catch { }

            Cursor.Current = Cursors.Default;
        }
        private void TicketNew()
        {
            Cursor.Current = Cursors.WaitCursor;
            ticket tk = new ticket();
            tk.ticketNumber = txtTicketNo.Text;
            tk.ticketTypeID = rd_getIndex();
            tk.ticketStartDate = dtpBegin.Value;
            tk.ticketExpiryDate = dtpEnd.Value;
            tk.userID_Create = Globals.sysUserID;
            tk.ticketActive = chkActive.Checked;
            tk.ticketRemainTimes = 0;
            tk.ticketCredit = 0;
            tk.ticketDateUpdate = DateTime.Now;
            if (cbTicketMember.SelectedValue != null)
            {
                tk.ticketMemberID = (int)cbTicketMember.SelectedValue;
            }

            if (cbCarPlateNumber.SelectedValue != null)
            {
                tk.carID = (int)cbCarPlateNumber.SelectedValue;
            }

                using (Dpark3Entities db1 = new Dpark3Entities())
                {
                    db1.Database.Connection.ConnectionString = gb.GetConnectionString();
                    var ps = db1.sysUsers.Select(i=>new {i.sysUserName,i.sysUserID}).Where(i => i.sysUserID == Globals.sysUserID).ToList();
                    rptTakeTicketInfo.sysUserName = ps.Select(i => i.sysUserName).First().ToString();
                }

            //rptTakeTicketInfo.carPlateNumber = cbCarPlateNumber.Text;
            //rptTakeTicketInfo.ticketExpiryDate = tk.ticketExpiryDate;
            //rptTakeTicketInfo.ticketMemberName = cbTicketMember.Text;

            //rptTakeTicketInfo.ticketNumber = tk.ticketNumber;
            //rptTakeTicketInfo.ticketStartDate = tk.ticketStartDate;
            //rptTakeTicketInfo.ticketTypeName = rd_getName();


            DBManage.TBticket db = new DBManage.TBticket();
            int rowIndex = db.New(tk);
            if (rowIndex == -1)
            {
                MessageBox.Show("โปรดตรวจสอบ เลขบัตร ห้ามมีการใช้ซ้ำของเดิม", "ไม่สามารถเพิ่มข้อมูลได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rdTicketTypeDialy.Checked)
                {
                    using (fmTakePayment fm = new fmTakePayment(TypeOfPayment.takeDialyCard, Convert.ToDouble(txtTotalPrices.Text)))
                    {
                        fm.rptTakeTicketInfo = rptTakeTicketInfo;
                        fm.AutoEnableReportTakeTicket = AutoEnableReportTakeTicket;
                        if (fm.ShowDialog() == DialogResult.OK)
                        {
                            tk.ticketID = rowIndex;
                            db.Update(tk);
                        }
                        fm.Dispose();
                    }

                }
                else if (rdTicketTypeMonthly.Checked)
                {
                    using (fmTakePayment fm = new fmTakePayment(TypeOfPayment.takeMonthlyCard, Convert.ToDouble(txtTotalPrices.Text)))
                    {
                        fm.rptTakeTicketInfo = rptTakeTicketInfo;
                        fm.AutoEnableReportTakeTicket = AutoEnableReportTakeTicket;
                        if (fm.ShowDialog() == DialogResult.OK)
                        {
                            tk.ticketID = rowIndex;
                            db.Update(tk);

                        }
                        fm.Dispose();
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }
        private void rd_setIndex(int e)
        {
            rdTicketTypeDialy.BackColor = Color.White;
            rdTicketTypeFree.BackColor = Color.White;
            rdTicketTypeMonthly.BackColor = Color.White;
            rdTicketTypeVisitor.BackColor = Color.White;
            rdTicketTypeTimes.BackColor = Color.White;

            gpTicketType.Enabled = false;

            switch (e)
            {
                case (int)TypeOfTicket.DialyTicket:
                    rdTicketTypeDialy.Checked = true;
                    rdTicketTypeDialy.BackColor = Color.Lime;
                    dtpBegin.Enabled = false;
                    dtpEnd.Enabled = false;
                    break;
                case (int)TypeOfTicket.FreeTicket:
                    rdTicketTypeFree.Checked = true;
                    rdTicketTypeFree.BackColor = Color.Lime;
                    dtpBegin.Enabled = true;
                    dtpEnd.Enabled = true;
                    break;
                case (int)TypeOfTicket.MonthlyTicket:
                    rdTicketTypeMonthly.Checked = true;
                    rdTicketTypeMonthly.BackColor = Color.Lime;
                    dtpBegin.Enabled = false;
                    dtpEnd.Enabled = false;
                    break;
                case (int)TypeOfTicket.VisitorTicket:
                    rdTicketTypeVisitor.Checked = true;
                    rdTicketTypeVisitor.BackColor = Color.Lime;
                    dtpBegin.Enabled = false;
                    dtpEnd.Enabled = false;
                    break;
                case (int)TypeOfTicket.Times:
                    dtpBegin.Enabled = false;
                    dtpEnd.Enabled = false;
                    throw new NotImplementedException();
            }
        }
        private string rd_getName()
        {
            if (rdTicketTypeDialy.Checked) { return rdTicketTypeDialy.Text; }
            else if (rdTicketTypeFree.Checked) { return rdTicketTypeFree.Text; }
            else if (rdTicketTypeMonthly.Checked) { return rdTicketTypeMonthly.Text; }
            else if (rdTicketTypeVisitor.Checked) { return rdTicketTypeVisitor.Text; }
            else if (rdTicketTypeTimes.Checked) { return rdTicketTypeTimes.Text;} 
            return string.Empty;
        }
        private int rd_getIndex()
        {
            int indexType = 0;
            if (rdTicketTypeDialy.Checked) { indexType = (int)TypeOfTicket.DialyTicket; }
            else if (rdTicketTypeFree.Checked) { indexType = (int)TypeOfTicket.FreeTicket; }
            else if (rdTicketTypeMonthly.Checked) { indexType = (int)TypeOfTicket.MonthlyTicket; }
            else if (rdTicketTypeVisitor.Checked) { indexType = (int)TypeOfTicket.VisitorTicket; }
            else if (rdTicketTypeTimes.Checked) { indexType = (int)TypeOfTicket.Times; }
            return indexType;
        }
        private void ProcessRadioTicketType() {
           
                switch (rd_getIndex())
                {
                    case (int)TypeOfTicket.FreeTicket:
                        dtpEnd.MinDate = new DateTime(2000, 01, 01);
                        dtpEnd.MaxDate = dtpBegin.Value.AddYears(10);
                        
                        dtpEnd.Value = dtpBegin.Value.AddYears(1);
                        gpShowPrices.Visible = false;
                        break;
                    case (int)TypeOfTicket.DialyTicket:
                        dtpEnd.MinDate = new DateTime(2000, 01, 01);
                        dtpEnd.MaxDate = dtpBegin.Value.AddDays(2);
                        
                        dtpEnd.Value = dtpBegin.Value.AddDays(1);
                        if (flagNewOrUpdate == TypeRecordState.Update)
                        {
                                //gpShowPrices.Visible = btReNewTicket.Enabled;
                        }
                        else
                        {
                            gpShowPrices.Visible = true;
                        }
                        lbUnit.Text = "วัน";
                        lbTicketType.Text = rdTicketTypeDialy.Text;
                        calcTotalPricse();
                        break;
                    case (int)TypeOfTicket.MonthlyTicket:
                        dtpEnd.MinDate = new DateTime(2000, 01, 01);
                        dtpEnd.MaxDate = dtpBegin.Value.AddDays(32);
                        dtpEnd.Value = dtpBegin.Value.AddMonths(1);
                        if (flagNewOrUpdate == TypeRecordState.Update)
                        {
                            //gpShowPrices.Visible = btReNewTicket.Enabled;
                        }
                        else
                        {
                            gpShowPrices.Visible = true;
                        }
                        lbUnit.Text = "เดือน";
                        lbTicketType.Text = rdTicketTypeMonthly.Text;
                        calcTotalPricse();
                        break;
                    case (int)TypeOfTicket.VisitorTicket:
                        dtpEnd.MinDate = new DateTime(2000, 01, 01);
                        dtpEnd.MaxDate = dtpBegin.Value.AddYears(10);
                        
                        dtpEnd.Value = dtpBegin.Value.AddYears(5);
                        gpShowPrices.Visible = false;
                        break;
                    case (int)TypeOfTicket.Times:
                        throw new NotImplementedException();
                }
        }
        private void rdTicketTypeFree_CheckedChanged(object sender, EventArgs e)
        { 
            RadioButton rb = (RadioButton)sender;
            if (((RadioButton)sender).Checked)
            {
                ProcessRadioTicketType();
                rb.BackColor = Color.Lime;
            }
            else
            {
                rb.BackColor = Color.White;
            }
            nmQuatity.Value = 1;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (txtTicketNo.Text == "")
            {
                txtInfo.Text = "โปรดใส่ข้อมูลหมายเลขบัตร";
                txtInfo.BLink(); return;
            }

                if (rd_getIndex() == 0)
                {
                    txtInfo.Text = "โปรดตรวจสอบ ประเภทบัตร";
                    txtInfo.BLink();
                    return;
                }

                if (flagNewOrUpdate == TypeRecordState.Save)
                {
                    TicketNew();
                    
                }
                else if (flagNewOrUpdate == TypeRecordState.Update)
                {
                    if (isReNewTicket)
                    {
                        TicketTopUp();
                    }else
                    {
                        TicketUpdate();
                    }
                }
              
            defaultControl();
            IsControlAccessable = false;
            UpdateControlView();
            IsControlAccessable = true;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
 
        private void btNew_Click(object sender, EventArgs e)
        {
            defaultControl();
            enableControl();
        }

        private void viewFoucuseChangedProcess(){
            if (gridView1.GetSelectedRows()[0] >= 0)
            {
                btReNewTicket.Visible = true;
                dtpEnd.MaxDate = dtpBegin.Value.AddYears(20);
                GridviewRefresh();
            }
            else
            {
                defaultControl();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (!IsControlAccessable) { return; }
            if (gridView1.FocusedRowHandle == 0) { return; }
            if (
                (gridView1.GetSelectedRows().Count() > 0) &&
                (gridView1.RowCount > gridView1.FocusedRowHandle)
               )
            {
                viewFoucuseChangedProcess();
            }
            else
            {
                Console.Write("count>{0},select>{1}", gridView1.RowCount, gridView1.FocusedRowHandle);
            }
        }
        private void fmTicket2_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode) { return; }
            UpdateControlView();
            FormatGridView();
            calcTotalPricse();
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = true;
            IsControlAccessable = true;
            ticketTypeRadioProcess();
        }
        private void CarControlClear(){
            if (!IsControlAccessable) { return; }
            btCarEdit.Enabled = false;
            cbCarPlateNumber.SelectedText = string.Empty;
            cbCarPlateNumber.Text = null;
            txtCarBrand.Text = string.Empty;
            txtCarColor.Text = string.Empty;
            txtCarModel.Text = string.Empty;
            txtCarPlateCity.Text = string.Empty;
            txtCarType.Text = string.Empty;

        }
        public void CarControlRefresh(int CarID) {
            if (!IsControlAccessable) { return; }
            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();
                var Car = db.cars.Where(i => i.carID == CarID).ToList().First();

                txtCarBrand.Text = Car.car_carBrand == null ? string.Empty : Car.car_carBrand.carBrandName;
                txtCarType.Text = Car.car_carType == null ? string.Empty : Car.car_carType.carTypeName;
                txtCarColor.Text = Car.carColor == null ? string.Empty : Car.carColor;
                txtCarModel.Text = Car.carModel == null ? string.Empty : Car.carModel;
                txtCarPlateCity.Text = Car.param_province == null ? string.Empty : Car.param_province.provinceName;
            }  
        }
        private void TicketMemberControlClear() {
            if (!IsControlAccessable) { return; }
            btTicketMemberEdit.Enabled = false;
            cbTicketMember.SelectedText = string.Empty;
            cbTicketMember.Text = null;
            txtMemberType.Text = string.Empty;
            txtTicketMemberAddr.Text = string.Empty;
            txtTicketMemberEmail.Text = string.Empty;
            txtTicketMemberTel.Text = string.Empty;
        }
        private bool IsControlAccessable = false;  // flag to force access control when form shown complete
        public  void TicketMemberControlRefresh(int SelectTicketMemberID)
        {
            if (!IsControlAccessable) { return; }
            if (SelectTicketMemberID==0) { return; }
            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();

                var tkMember = db.ticketMembers.Where(i => i.ticketMemberID == SelectTicketMemberID).First();
                cbTicketMember.SelectedValue = tkMember.ticketMemberID;
                txtMemberType.Text = tkMember.ticketMemberType.ticketMemberTypeName;
                txtTicketMemberAddr.Text = tkMember.ticketMemberAddr;
                txtTicketMemberEmail.Text = tkMember.ticketMemberEmail;
                txtTicketMemberTel.Text = tkMember.ticketMemberTel;
            }  

        }
 
  private void ComboBoxOutOfSelect(ComboBox sender){
            if ((sender).SelectedIndex == -1)
            {
                (sender).Text = String.Empty;
                if (sender.Name == "cbTicketMember")
                {
                    TicketMemberControlClear();
                }
                else if (sender.Name == "cbCarPlateNumber")
                {
                    CarControlClear();
                }
            }
        }
  private void cbTicketMember_Leave(object sender, EventArgs e)
  {
      ComboBoxOutOfSelect((ComboBox)sender);

  }
        private void cbTicketMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbTicketMember.SelectedValue == null)||(cbTicketMember.SelectedIndex ==-1) ||(string.IsNullOrEmpty( cbTicketMember.Text))) {
                return; }
            btTicketMemberEdit.Enabled = true;

            int SelectTicketMemberID = Convert.ToInt32(cbTicketMember.SelectedValue.ToString());
            TicketMemberControlRefresh(SelectTicketMemberID);
        }

  
        private void cbCarPlateNumber_Leave(object sender, EventArgs e)
        {
            ComboBoxOutOfSelect((ComboBox)sender);
            
        }

        private void cbCarPlateNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbCarPlateNumber.SelectedValue == null) || (cbCarPlateNumber.SelectedIndex == -1) || (string.IsNullOrEmpty(cbCarPlateNumber.Text)))
            {
                return;
            }
            btCarEdit.Enabled= true;

            int SelectCarID = Convert.ToInt32(cbCarPlateNumber.SelectedValue.ToString());
            CarControlRefresh(SelectCarID);
        }
       
        private void btRefresh_Click(object sender, EventArgs e)
        {
            UpdateControlView();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("การบัตร จะทำให้ข้อมูลสมาชิก และข้อมูลรถถูกลบไปด้วย \r\n\r\nยืนยันการลบบัตรหรือไม่", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) { return; }


            Cursor.Current = Cursors.WaitCursor;
            int[] selRows = gridView1.GetSelectedRows();

            Dpark3Entities db = new Dpark3Entities();
            db.Database.Connection.ConnectionString = gb.GetConnectionString();

            for (int row = 0; row < selRows.Count(); row++)
            {
                string TicketNumber = gridView1.GetRowCellValue(selRows[row], "ticketNumber").ToString();
                var tk = (from a in db.tickets
                          where a.ticketNumber == TicketNumber
                          select a).First();
                
                db.tickets.Remove(tk);
                db.SaveChanges();
                if (tk.ticketMemberID != null)
                {
                    int memberId = (int)tk.ticketMemberID;

                    var tkMember = (from a in db.ticketMembers
                                    where a.ticketMemberID == memberId
                                    select a).First();
                    db.ticketMembers.Remove(tkMember);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch { }
                }

                if (tk.carID != null)
                {
                    int CarId = (int)tk.carID;
                    var car = (from a in db.cars
                               where a.carID == CarId
                               select a).First();
                    db.cars.Remove(car);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch { }
                }
            }

            gridView1.ActiveFilterString = null;
            UpdateControlView();
        }
        private void gridTicketFilter() {
            if (string.IsNullOrEmpty(txtTicketNo.Text)) { return; }
            string caption = gridView1.Columns["ticketNumber"].Caption;

            gridView1.ActiveFilterString = string.Format("Contains([ticketNumber] , '{0}')", txtTicketNo.Text);
            defaultControl();
            if (
                (gridView1.GetSelectedRows().Count() > 0) &&
                (gridView1.RowCount > gridView1.FocusedRowHandle)
               )
            {
                if (gridView1.GetSelectedRows()[0] >= 0)
                {
                    GridviewRefresh();
                    
                }

            }
        }
        private void btFindTicketNumber_Click(object sender, EventArgs e)
        {
            gridTicketFilter();

        }
        public void gridTicketPaidFilter() {
            gridView1.ActiveFilterString = string.Format("Contains([ticketTypeId] , '{0}') Or Contains([ticketTypeId] , '{1}')", '2','3');
        defaultControl();
        }
        public void gridTicketFreeFilter(){
            gridView1.ActiveFilterString = string.Format("Contains([ticketTypeId] , '{0}')", '1');
            defaultControl();
        }
        public  void gridTicketExpiryFilter()
        {
            gridView1.ActiveFilterString = string.Format("Contains([ticketRemainDay] , '{0}')", '-');
            defaultControl();
        }
        private void gridCarFilter() {
            if (string.IsNullOrEmpty(txtCarPlateNumber.Text)) { return; }
            string caption = gridView1.Columns["carPlateNumber"].Caption;
            gridView1.ActiveFilterString = string.Format("Contains([carPlateNumber] , '{0}')", txtCarPlateNumber.Text);
            defaultControl();
            if (
                  (gridView1.GetSelectedRows().Count() > 0) &&
                  (gridView1.RowCount > gridView1.FocusedRowHandle)
               )
            {
                if (gridView1.GetSelectedRows()[0] >= 0)
                {
                    GridviewRefresh();
                }
            }
        }
        private void bt_find_Click(object sender, EventArgs e)
        {
            gridCarFilter();
        }

        private void txtCarPlateNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridCarFilter();
            }
 
        }

        private void txtTicketNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
           // {
              //  gridTicketFilter();
           // }
            
        }
        bool isReNewTicket = false;
        private void btReNewTicket_Click(object sender, EventArgs e)
        {
            isReNewTicket = true;
            btReNewTicket.Visible = false;
            gpShowPrices.Visible = true;
            dtpEnd.MinDate = dtpEnd.Value;
            dtpEnd.Enabled = true;  // กำหนดวันหมดอายุใหม่
            tmpDtpEndValue = dtpEnd.Value;
            if (dtpEnd.Value <= DateTime.Now)
            { // กรณีบัตรหมดอายุแล้ว
                dtpBegin.Enabled = true;  // กำหนดวันเริ่มใหม่
                nmQuatity.Value = 1;
                dtpBegin.Value = DateTime.Now;
            }
            else { 
                //บัตรยังไม่หมดอายุ 
                dtpBegin.Enabled = false;
                nmQuatity.Minimum = 0;
                nmQuatity.Value = 0;
                
            }
        }
        private DateTime tmpDtpEndValue;
        private void ticketTypeRadioProcess() {
            if (rdTicketTypeDialy.Checked)
            {
                if (btReNewTicket.Enabled)
                {// กรณี เติมเงิน
                    dtpEnd.MaxDate = dtpEnd.Value.AddYears(3);
                    if (dtpEnd.Value <= DateTime.Now)
                    {

                        dtpEnd.MinDate = dtpBegin.Value.AddDays((int)nmQuatity.Value).AddDays(-1);
                        dtpEnd.Value = dtpBegin.Value.AddDays((int)nmQuatity.Value);

                    }
                    else {
                       
                       dtpEnd.Value =tmpDtpEndValue.AddDays((int)nmQuatity.Value);
                    }
                    dtpEnd.MaxDate = dtpEnd.Value.AddHours(1); // เพิ่มเวลาให้ 1 ชม
                }
                else
                {// กรณี สร้างใหม่
                    dtpEnd.MaxDate = dtpEnd.Value.AddYears(3);
                    dtpEnd.MinDate = dtpBegin.Value.AddDays((int)nmQuatity.Value).AddDays(-1);
                    dtpEnd.Value = dtpBegin.Value.AddDays((int)nmQuatity.Value);
                    dtpEnd.MaxDate = dtpEnd.Value.AddHours(1); // เพิ่มเวลาให้ 1 ชม
                }
            }
            else if (rdTicketTypeMonthly.Checked)
            {
                if (btReNewTicket.Enabled)
                {// กรณี เติมเงิน
                    dtpEnd.MaxDate = dtpEnd.Value.AddYears(3);
                    if (dtpEnd.Value <= DateTime.Now)
                    {
                        
                        dtpEnd.MinDate = dtpBegin.Value.AddMonths((int)nmQuatity.Value).AddDays(-1);
                        dtpEnd.Value = dtpBegin.Value.AddMonths((int)nmQuatity.Value);
                        
                    }
                    else
                    {
                        dtpEnd.Value = tmpDtpEndValue.AddMonths((int)nmQuatity.Value);
                    } 
                    dtpEnd.MaxDate = dtpEnd.Value.AddDays(1); // เพิ่มเวลาให้ 1 วัน
                }
                else
                {// กรณี สร้างใหม่
                    dtpEnd.MaxDate = dtpEnd.Value.AddYears(3);
                    dtpEnd.MinDate = dtpBegin.Value.AddMonths((int)nmQuatity.Value).AddDays(-1); 
                    dtpEnd.Value = dtpBegin.Value.AddMonths((int)nmQuatity.Value);
                    dtpEnd.MaxDate = dtpEnd.Value.AddDays(1); // เพิ่มเวลาให้ 1 วัน
                }
            }
        }
        private void nmQuatity_ValueChanged(object sender, EventArgs e)
        {
            ticketTypeRadioProcess();
            calcTotalPricse();
        }
        public void FormClose()
        {
            if (fmMainBackoffice.staticVar != null)
            {
                fmMainBackoffice.staticVar.ButtonTicketRelease();
            }
            staticVar = null;

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
        private void fmTicket2_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClose();
        }
        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            ProcessRadioTicketType();
        }

        private void btNewMulti_Click(object sender, EventArgs e)
        {
            fmTicketAddGroup fmTk = new fmTicketAddGroup();
            fmTk.ShowDialog();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == 0)
            {
                viewFoucuseChangedProcess();
            }
        }

    }
}
