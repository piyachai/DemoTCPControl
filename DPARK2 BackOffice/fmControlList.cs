using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Design;
using DevExpress.XtraEditors;

namespace BackOffice
{
    public partial class fmControlList : DevExpress.XtraEditors.XtraForm
    {
        public fmControlList()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}