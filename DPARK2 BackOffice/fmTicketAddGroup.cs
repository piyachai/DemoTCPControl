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
    public partial class fmTicketAddGroup : Form
    {
        public fmTicketAddGroup()
        {
            InitializeComponent();
            dtpEnd.Value = dtpBegin.Value.AddYears(5);
        }

        private void addTicketToList(string TicketNumber){
            
            if (string.IsNullOrEmpty(TicketNumber)) return;

            lbTicketNumber.Text = TicketNumber;
            lbLastTicket.Visible = true;
            lbTicketNumber.Visible = true;
            if (!txtTicketList.Items.Contains(TicketNumber))
            {
                txtTicketList.Items.Add(TicketNumber);
                txtTicketCounter.Text = txtTicketList.Items.Count.ToString();
                lbExist.Visible = false;
            }
            else {
                
                lbExist.Visible = true;
            }
        }
        private void btAddTicket_Click(object sender, EventArgs e)
        {
            addTicketToList(txtTicketNumber.Text);
            txtTicketNumber.Clear();
        }

        private void txtTicketNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
                addTicketToList(txtTicketNumber.Text);
                txtTicketNumber.Clear();
            }
        }

        private int rd_getIndex()
        {
            int indexType = 0;
          //  if (rdTicketTypeDialy.Checked) { indexType = (int)TypeOfTicket.DialyTicket; }
            if (rdTicketTypeFree.Checked) { indexType = (int)TypeOfTicket.FreeTicket; }
          //  else if (rdTicketTypeMonthly.Checked) { indexType = (int)TypeOfTicket.MonthlyTicket; }
            else if (rdTicketTypeVisitor.Checked) { indexType = (int)TypeOfTicket.VisitorTicket; }
          //  else if (rdTicketTypeTimes.Checked) { indexType = (int)TypeOfTicket.Times; }
            return indexType;
        }
        private void SaveTicketList() {
            if (txtTicketList.Items.Count == 0) return;
            List<ticket>  tk = new List<ticket>();
            int unSuccessCount = 0;
            StringBuilder sb = new StringBuilder();
            foreach (object item  in txtTicketList.Items) {
                ticket _tmp = new ticket();
                _tmp.ticketNumber = (string)item;

                _tmp.ticketTypeID = rd_getIndex(); // getType of Ticket

                _tmp.ticketStartDate = dtpBegin.Value;
                _tmp.ticketExpiryDate = dtpEnd.Value;
                _tmp.userID_Create = Globals.sysUserID;
                _tmp.ticketActive = true;
                _tmp.ticketRemainTimes = 0;
                _tmp.ticketCredit = 0;
                _tmp.ticketDateUpdate = DateTime.Now;
                DBManage.TBticket db = new DBManage.TBticket();
                int rowIndex = db.New(_tmp);
                if (rowIndex == -1)
                {  sb.Append( _tmp.ticketNumber);
                   sb.Append(Environment.NewLine);
                   unSuccessCount++;
                }
            }
            txtTicketList.Items.Clear();
            if (unSuccessCount > 0) {
                MessageBox.Show("จำนวน:"+unSuccessCount+Environment.NewLine+Environment.NewLine+"หมายเลข"+Environment.NewLine+sb.ToString(), "หมายเลขซ้ำไม่สามารถเพิ่มหมายเลขได้");
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            SaveTicketList();
            fmTicket2.staticVar.UpdateControlView();
            Close();
        }

        private void fmTicketAddGroup_Shown(object sender, EventArgs e)
        {
            txtTicketNumber.Focus();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmTicketAddGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (txtTicketList.Items.Count != 0)
            {
                if (MessageBox.Show("การปิดโดยไม่บันทึก จะทำให้ข้อมูลบัตรที่เพิ่มใหม่ไม่สามารถใช้งานได้ \r\n\r\nยืนยันการหรือไม่", "ออกโดยไม่บันทึก", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) { return; }
            }

            e.Cancel = false;
        }
    }
}
