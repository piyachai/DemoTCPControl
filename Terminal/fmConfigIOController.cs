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
namespace DparkTerminal
{
    public partial class fmConfigIOController : DevExpress.XtraEditors.XtraForm
    {   
        public fmConfigIOController()
        {
            InitializeComponent();
            populateComboboxComport();

        }

        private void populateComboboxComport(){
           List<String> tList = new List<String>();

           cmbComport.Items.Clear();

             foreach (string s in SerialPort.GetPortNames())
             {
                tList.Add(s);
             }

             tList.Sort();
             cmbComport.Items.AddRange(tList.ToArray());
             if (cmbComport.Items.Count != 0)
             {
                 cmbComport.SelectedIndex = 0;
             }
             cmbComport.Text  = Settings.Default.COMPORT;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            Settings.Default.COMPORT = cmbComport.Text;
            Settings.Default.Save();
            txtInfo.Text = "บันทึกแล้ว";
            txtInfo.BLink();

        }

        private void fmIOController_Load(object sender, EventArgs e)
        {
            cmbComport.Text = Settings.Default.COMPORT;

        }


    }
}