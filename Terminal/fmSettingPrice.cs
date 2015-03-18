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
    public partial class fmSettingPrice : Form
    {
        public fmSettingPrice()
        {
            InitializeComponent();
        }

        private void btnExitSetPrice_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveSetPrice_Click(object sender, EventArgs e)
        {
            Settings.Default.NamePrice1 = namePrice1.Text;
            Settings.Default.NamePrice2 = namePrice2.Text;
            Settings.Default.NamePrice3 = namePrice3.Text;
            Settings.Default.NamePrice4 = namePrice4.Text;
            Settings.Default.NamePrice5 = namePrice5.Text;


            Settings.Default.SetPrice1 = Convert.ToInt32(setPrice1.Text);
            Settings.Default.SetPrice2 = Convert.ToInt32(setPrice2.Text);
            Settings.Default.SetPrice3 = Convert.ToInt32(setPrice3.Text);
            Settings.Default.SetPrice4 = Convert.ToInt32(setPrice4.Text);
            Settings.Default.SetPrice5 = Convert.ToInt32(setPrice5.Text);

            txtStatusPriceSet.Text = "บันทึกราคาใหม่สมบูรณ์"; 

        }

       

        private void FormShow(object sender, EventArgs e)
        {
            namePrice1.Text = Settings.Default.NamePrice1;
            namePrice2.Text = Settings.Default.NamePrice2;
            namePrice3.Text = Settings.Default.NamePrice3;
            namePrice4.Text = Settings.Default.NamePrice4;
            namePrice5.Text = Settings.Default.NamePrice5;

            setPrice1.Text = Settings.Default.SetPrice1.ToString();
            setPrice2.Text = Settings.Default.SetPrice2.ToString();
            setPrice3.Text = Settings.Default.SetPrice3.ToString();
            setPrice4.Text = Settings.Default.SetPrice4.ToString();
            setPrice5.Text = Settings.Default.SetPrice5.ToString();

            txtStatusPriceSet.Text = ""; 

            GC.Collect();
        }
    }
}
