using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DtimeServer
{
    class mTextBox : TextBox
    {
        public bool IsIntTextBox { set; get; }
        public bool CheckIsNull() {
            if (string.IsNullOrEmpty(Text)) {
                MessageBox.Show("ข้อความห้ามว่าง","ผิดพลาด",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        public mTextBox() {
            this.KeyPress += mTextBox_KeyPress;
        }

        void mTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsIntTextBox) { return; }
            if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar)
              && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

    }
}
