using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DparkTerminal.Properties;
using System.IO.Ports;
using System.Linq;
namespace DparkTerminal
{
    public partial class fmConfigCamera : DevExpress.XtraEditors.XtraForm
    {
        public fmConfigCamera()
        {
            InitializeComponent();

        }

        const int MaxDVRChannel = 4;
        private void bt_exit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            Settings.Default.DVRIP = txtDVRIP.Text;
            Settings.Default.DVRPassword = txtDVRPasswd.Text;
            Settings.Default.DVREnable = chkCamActive.Checked;
            Settings.Default.DVRPort =Convert.ToInt32(txtDVRPort.Text);
            Settings.Default.DVRUser = txtDVRUser.Text;

            Settings.Default.CamIn1Save = chCamIn1Save.Checked;
            Settings.Default.CamIn2Save = chCamIn2Save.Checked;
            Settings.Default.CamIn3Save = chCamIn3Save.Checked;

            Settings.Default.CamOut1Save = chCamOut1Save.Checked;
            Settings.Default.CamOut2Save = chCamOut2Save.Checked;
            Settings.Default.CamOut3Save = chCamOut3Save.Checked;

            Settings.Default.ScreenIn1DVRMap = cbCamIn1.SelectedItem.ToString();
            Settings.Default.ScreenIn2DVRMap = cbCamIn2.SelectedItem.ToString();
            Settings.Default.ScreenIn3DVRMap = cbCamIn3.SelectedItem.ToString();

            Settings.Default.ScreenOut1DVRMap = cbCamOut1.SelectedItem.ToString();
            Settings.Default.ScreenOut2DVRMap = cbCamOut2.SelectedItem.ToString();
            Settings.Default.ScreenOut3DVRMap = cbCamOut3.SelectedItem.ToString();

            Settings.Default.CamMode = cmbCamMode.SelectedIndex;

            Settings.Default.Save();
            txtInfo.Text = "บันทึกแล้ว";
            txtInfo.BLink();

        }
        private void populateDVRMapChannel(int maxChannel) {
            cbCamIn1.Items.Add("None");
            cbCamIn2.Items.Add("None");
            cbCamIn3.Items.Add("None");
            cbCamOut1.Items.Add("None");
            cbCamOut2.Items.Add("None");
            cbCamOut3.Items.Add("None");


            for(int i = 1; i <= maxChannel; i++)
            {
                    cbCamIn1.Items.Add(i);
                    cbCamIn2.Items.Add(i);
                    cbCamIn3.Items.Add(i);

                    cbCamOut1.Items.Add(i);
                    cbCamOut2.Items.Add(i);
                    cbCamOut3.Items.Add(i);
            }

        }
        private void fmIOController_Load(object sender, EventArgs e)
        {
             populateDVRMapChannel(MaxDVRChannel);

             txtDVRIP.Text=Settings.Default.DVRIP ;
             txtDVRPasswd.Text=Settings.Default.DVRPassword;
             chkCamActive.Checked =Settings.Default.DVREnable ;
             txtDVRPort.Text = Settings.Default.DVRPort.ToString();
             txtDVRUser.Text= Settings.Default.DVRUser ;
             gpDVR.Enabled = Settings.Default.DVREnable;

             chCamIn1Save.Checked  = Settings.Default.CamIn1Save ;
             chCamIn2Save.Checked= Settings.Default.CamIn2Save;
             chCamIn3Save.Checked = Settings.Default.CamIn3Save;

             chCamOut1Save.Checked = Settings.Default.CamOut1Save;
             chCamOut2Save.Checked = Settings.Default.CamOut2Save;
             chCamOut3Save.Checked = Settings.Default.CamOut3Save;

             cbCamIn1.Text= Settings.Default.ScreenIn1DVRMap;
             cbCamIn2.Text = Settings.Default.ScreenIn2DVRMap;
             cbCamIn3.Text = Settings.Default.ScreenIn3DVRMap;

             cbCamOut1.Text = Settings.Default.ScreenOut1DVRMap;
             cbCamOut2.Text = Settings.Default.ScreenOut2DVRMap;
             cbCamOut3.Text = Settings.Default.ScreenOut3DVRMap;

             cmbCamMode.SelectedIndex = Settings.Default.CamMode;
        }

        private void chkCamActive_CheckedChanged(object sender, EventArgs e)
        {
            gpDVR.Enabled = chkCamActive.Checked;
        }

    }
}