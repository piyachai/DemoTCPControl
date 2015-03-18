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
using BackOffice;
namespace DparkTerminal
{

   
    public partial class fmConfigTerminalMode : DevExpress.XtraEditors.XtraForm
    {
        BackOffice.General gb;
        BackOffice.TerminalWorkingMode mode;
        
        public fmConfigTerminalMode()
        {
            InitializeComponent();
            gb = new General();
            populateControl();
        }
        private void populateControl(){
          switch (Settings.Default.terminalWorkingMode){
              case (int)TerminalWorkingMode.GateIn: 
                  rdGateIn.Checked = true;
                  mode = TerminalWorkingMode.GateIn;
                  break;

              case (int)TerminalWorkingMode.GateOut: 
                  rdGateOut.Checked = true;
                  mode = TerminalWorkingMode.GateOut;
                  break;
          }
          ckAutoStart.Checked = Settings.Default.AutoStart;
          chkAutoOpenForMember.Checked = Settings.Default.BarrierAutoOpenForMember;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (rdGateOut.Checked) { mode = TerminalWorkingMode.GateOut; }
            else if (rdGateIn.Checked) { mode = TerminalWorkingMode.GateIn; }
            Settings.Default.terminalWorkingMode = (int)mode;
            Settings.Default.BarrierAutoOpenForMember = chkAutoOpenForMember.Checked;
            Settings.Default.AutoStart = ckAutoStart.Checked;
            AutoStart start = new AutoStart();
            string KeyName = "DparkTerminal";
            if (ckAutoStart.Checked)
            {
                //  BackOffice.autod

               
              
                start.SetAutoStart(KeyName, Application.ExecutablePath);

            }
            else {
                if (start.IsAutoStartEnabled(KeyName, Application.ExecutablePath))
                {
                    start.UnSetAutoStart(KeyName);
                }
            }
            Settings.Default.Save();
            txtInfo.Text = "บันทึกแล้ว";
            txtInfo.BLink();

        }

        private void bySyncTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show( gb.SyncTimeFormServer().ToString(),"ปรับเวลาแล้ว");
        }
    }
}