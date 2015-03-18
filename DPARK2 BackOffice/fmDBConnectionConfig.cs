using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackOffice.Properties;
using System.Configuration;
namespace BackOffice
{
    public partial class fmDBConnectionConfig : Form
    {
        public fmDBConnectionConfig()
        {
            InitializeComponent();
            dtp = new DBManage();

            txt_serverName.Text = Settings.Default.DBServer;
            txt_dbName.Text = Settings.Default.DBName;
            txt_username.Text = Settings.Default.DBUsername;
            txt_password.Text = Settings.Default.DBPassword;

        }
 
        DBManage dtp;
        private void dbTest()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dtp.DBConnectionTest())
            {
                MessageBox.Show("DB Connection OK", "DB Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("DB Connection Fail", "DB Connect", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            Cursor.Current = Cursors.Default;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Settings.Default.DBPassword = txt_password.Text;
            Settings.Default.DBName = txt_dbName.Text;
            Settings.Default.DBServer = txt_serverName.Text;
            Settings.Default.DBUsername = txt_username.Text;
            Settings.Default.Save();
            dbTest();
            
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
