using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DparkTerminal.Properties;
using BackOffice;

namespace DparkTerminal
{

    public partial class fmLogin : Form
    {

        public static fmLogin staticVar = null;
        public int loginID { get; set; }
        #region control
        public fmLogin()
        {
            InitializeComponent();
            staticVar = this;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.TopMost = true;
        }
        private void  Login()
        {
            General gb = new General();
            if (!gb.IsValidTextbox(txtPassword)) { return; }
            if (!gb.IsValidTextbox(txtLoginName)) { return; }


            if (ckSaveUserName.Checked) {
                Settings.Default.LoginPassword = txtPassword.Text;
                Settings.Default.LoginUserName = txtLoginName.Text;
                Settings.Default.UserNameRemember = ckSaveUserName.Checked;
                Settings.Default.AutoLogin = ckAutologin.Checked;
                Settings.Default.Save();
            }
            DBManage.TBsysUser tbsys = new DBManage.TBsysUser();



            int _LogInID = tbsys.LogIn(txtLoginName.Text,txtPassword.Text);//2; // force
            this.loginID = _LogInID;
            if (_LogInID > 0)
            {
                
                if (!ckSaveUserName.Checked)
                {
                    gb.ResetChildControls(this);
                }
                lbInfo.Visible = false;

                var XF = new fmMainTerminal(txtLoginName.Text);
                Globals.sysUserID = _LogInID;
                XF.Show();
                this.Hide();
                GC.Collect();
            }
            else
            {
                lbInfo.Visible = true;
            }
           
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            if (fmMainTerminal.staticVar != null)
            {
                fmMainTerminal.staticVar.Dispose();
            }
            Close();
            Application.ExitThread();
            Application.Exit();
        }

        #endregion

        #region event

        #endregion

   
        private void btDBConfig_Click(object sender, EventArgs e)
        {
            fmDBConnectionConfig fm = new fmDBConnectionConfig();
            fm.ShowDialog();
            
        }

        private void fmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void txtLoginName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Login();
            }
        }

        private void fmLogin_Shown(object sender, EventArgs e)
        {
            autoLoginProcess();
            txtLoginName.Focus();
        }

        private void txtLoginName_Enter(object sender, EventArgs e)
        {
            General gb = new General();
            gb.SetKeyboardLayout("eng");

        }
        private void autoLoginProcess() {
            if (Settings.Default.UserNameRemember) {
                txtLoginName.Text = Settings.Default.LoginUserName;
                txtPassword.Text = Settings.Default.LoginPassword;
                ckSaveUserName.Checked = true;
            }
            
            if (Settings.Default.AutoLogin) {
                ckAutologin.Checked = true;
                Login();
            }
        }
        private void ckAutologin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAutologin.Checked) {
                ckSaveUserName.Checked = true;
            }
        }

        private void ckSaveUserName_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckSaveUserName.Checked) {
                ckAutologin.Checked = false;
                Settings.Default.LoginUserName = string.Empty;
                Settings.Default.LoginPassword = string.Empty;
                Settings.Default.UserNameRemember = false;
                Settings.Default.AutoLogin = false;
                Settings.Default.Save();
            }
        }

    }
}
