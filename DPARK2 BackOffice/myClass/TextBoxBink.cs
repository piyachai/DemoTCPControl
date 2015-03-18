using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BackOffice
{
    public partial class TextBoxBink : TextBox
    {
        public TextBoxBink()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.ForeColor = Color.Lime;
            this.BlinkDelay = 1500;
            this.Visible = false;
        }
        Thread thInfo;
        public int BlinkDelay{set; get;}
        private void txtInfoDisplay()
        {
            try
            {
                this.Invoke(new EventHandler(delegate
                {
                    // try
                    //  {
                    this.Visible = true;
                    //  }
                    //  catch { }
                }));
                Thread.Sleep(BlinkDelay);
                if (!this.IsHandleCreated) { return; }
                this.Invoke(new EventHandler(delegate
                 {
                     try
                     {
                         this.Visible = false;
                         
                     }
                     catch { }
                 }));
                //try
                //{
                //    if (this.IsHandleCreated)
                //    {
                //        thInfo.Abort();
                //    }
                //}
                //catch { Thread.ResetAbort();
                //}
            }
            catch { }
            thInfo = null;
            GC.Collect();
        }
        public void BLink()
        {
            thInfo = new Thread(txtInfoDisplay);
            thInfo.Start();
        }
    }
}
