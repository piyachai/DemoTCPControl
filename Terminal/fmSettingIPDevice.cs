using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DparkTerminal.Properties;

namespace DparkTerminal
{
    public partial class fmSettingIPDevice : Form
    {
        public fmSettingIPDevice()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            ipDev1.Text = Settings.Default.ServerIP1;
            ipDev2.Text = Settings.Default.ServerIP2;
            ipDev3.Text = Settings.Default.ServerIP3;
        }

        
        private void btnSaveSetIP_Click(object sender, EventArgs e)
        {

            System.Net.IPAddress ipAddress1 = null, ipAddress2 = null, ipAddress3 = null;

            bool isValidIp1 = System.Net.IPAddress.TryParse(ipDev1.Text, out ipAddress1);
            bool isValidIp2 = System.Net.IPAddress.TryParse(ipDev2.Text, out ipAddress2);
            bool isValidIp3 = System.Net.IPAddress.TryParse(ipDev3.Text, out ipAddress3);

            if (!isValidIp1 || !isValidIp2 || !isValidIp3)
            {
                MessageBox.Show("IP Format ไม่ถูกต้อง กรุณาครวจสอบอีกครั้ง", "Error[7832]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                ipDev1.Text = ipAddress1.ToString();
                ipDev2.Text = ipAddress2.ToString();
                ipDev3.Text = ipAddress3.ToString();
                DialogResult dialogResult = MessageBox.Show("ยืนยันความถูกต้อง", "ตรวจสอบ IP Address", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Settings.Default.ServerIP1 = ipDev1.Text;
                    Settings.Default.ServerIP2 = ipDev2.Text;
                    Settings.Default.ServerIP3 = ipDev3.Text;
                }
                
            }
            
        }

        

        private void btnExitSetIP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
