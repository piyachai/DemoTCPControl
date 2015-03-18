using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackOffice.Properties;
using System.Threading;
using System.Reflection;

namespace BackOffice
{
    public partial class fmLogin : Form
    {
        General gb;
        
        public static fmLogin staticVar = null;
        public fmLogin()
        {
            InitializeComponent();

            gb = new General();
            staticVar = this;
        }
        
        private void Login()
        {
            {
                if (!gb.IsValidTextbox(txt_passwd)) { return; }
                if (!gb.IsValidTextbox(txt_userName)) { return; }
  
                DBManage.TBsysUser dbmnt = new DBManage.TBsysUser();
                if (ckSaveUserName.Checked)
                {
                    Settings.Default.LoginPassword = txt_passwd.Text;
                    Settings.Default.LoginUserName = txt_userName.Text;
                    Settings.Default.UserNameRemember = ckSaveUserName.Checked;
                    Settings.Default.AutoLogin = ckAutologin.Checked;
                    Settings.Default.Save();
                }

                int _LogInID = dbmnt.LogIn(txt_userName.Text, txt_passwd.Text);

                if (_LogInID > 0)
                {   Globals.sysUserID = _LogInID;
                    this.Hide();
                    if (!ckSaveUserName.Checked)
                    {
                        gb.ResetChildControls(this);
                    }
                    lbInfo.Visible = false;
                    Hide();
                    fmMainBackoffice XF;
                    XF = new fmMainBackoffice();
                    XF.Show();
                     GC.Collect();
                   
                }
                else
                {   Globals.sysUserID = 0;
                    lbInfo.Visible = true;
                }
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            
        }

        private void btDBConfig_Click(object sender, EventArgs e)
        {
            fmDBConnectionConfig mfm = new fmDBConnectionConfig();
            mfm.ShowDialog();
        }

    
        private void txt_userName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
                
            }
        }

        private void txt_userName_Enter(object sender, EventArgs e)
        {
            gb.SetKeyboardLayout("eng");
        }

        private void ckAutologin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAutologin.Checked)
            {
                ckSaveUserName.Checked = true;
            }
        }

        private void ckSaveUserName_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckSaveUserName.Checked)
            {
                ckAutologin.Checked = false;
                Settings.Default.LoginUserName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.UserNameRemember = false;
                Settings.Default.AutoLogin = false;
                Settings.Default.Save();
            }
        }
        private void autoLoginProcess()
        {
            if (Settings.Default.UserNameRemember)
            {
                txt_userName.Text = Settings.Default.LoginUserName;
                txt_passwd.Text = Settings.Default.LoginPassword;
                ckSaveUserName.Checked = true;
            }

            if (Settings.Default.AutoLogin)
            {
                ckAutologin.Checked = true;
                Login();
            }
        }
        private void fmLogin_Shown(object sender, EventArgs e)
        {
            autoLoginProcess();
            txt_userName.Focus();
        }
    }
}
