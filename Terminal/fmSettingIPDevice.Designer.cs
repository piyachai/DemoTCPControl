namespace DparkTerminal
{
    partial class fmSettingIPDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.device1 = new System.Windows.Forms.Label();
            this.ipDev1 = new System.Windows.Forms.TextBox();
            this.ipDev2 = new System.Windows.Forms.TextBox();
            this.ipDev3 = new System.Windows.Forms.TextBox();
            this.btnExitSetIP = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveSetIP = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.device1);
            this.panel1.Controls.Add(this.ipDev1);
            this.panel1.Controls.Add(this.ipDev2);
            this.panel1.Controls.Add(this.ipDev3);
            this.panel1.Controls.Add(this.btnExitSetIP);
            this.panel1.Controls.Add(this.btnSaveSetIP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 317);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "IP Address-3:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "IP Address-2:";
            // 
            // device1
            // 
            this.device1.AutoSize = true;
            this.device1.Location = new System.Drawing.Point(77, 38);
            this.device1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.device1.Name = "device1";
            this.device1.Size = new System.Drawing.Size(135, 24);
            this.device1.TabIndex = 46;
            this.device1.Text = "IP Address-1:";
            // 
            // ipDev1
            // 
            this.ipDev1.Location = new System.Drawing.Point(231, 33);
            this.ipDev1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ipDev1.Name = "ipDev1";
            this.ipDev1.Size = new System.Drawing.Size(236, 29);
            this.ipDev1.TabIndex = 43;
            this.ipDev1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ipDev2
            // 
            this.ipDev2.Location = new System.Drawing.Point(231, 105);
            this.ipDev2.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ipDev2.Name = "ipDev2";
            this.ipDev2.Size = new System.Drawing.Size(236, 29);
            this.ipDev2.TabIndex = 44;
            this.ipDev2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ipDev3
            // 
            this.ipDev3.Location = new System.Drawing.Point(231, 182);
            this.ipDev3.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ipDev3.Name = "ipDev3";
            this.ipDev3.Size = new System.Drawing.Size(236, 29);
            this.ipDev3.TabIndex = 45;
            this.ipDev3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExitSetIP
            // 
            this.btnExitSetIP.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExitSetIP.Appearance.Options.UseFont = true;
            this.btnExitSetIP.Image = global::DparkTerminal.Properties.Resources.Remove_32x321;
            this.btnExitSetIP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnExitSetIP.Location = new System.Drawing.Point(405, 229);
            this.btnExitSetIP.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnExitSetIP.Name = "btnExitSetIP";
            this.btnExitSetIP.Size = new System.Drawing.Size(62, 61);
            this.btnExitSetIP.TabIndex = 41;
            this.btnExitSetIP.Click += new System.EventHandler(this.btnExitSetIP_Click);
            // 
            // btnSaveSetIP
            // 
            this.btnSaveSetIP.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveSetIP.Appearance.Options.UseFont = true;
            this.btnSaveSetIP.Image = global::DparkTerminal.Properties.Resources.Save_32x32;
            this.btnSaveSetIP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSaveSetIP.Location = new System.Drawing.Point(326, 229);
            this.btnSaveSetIP.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSaveSetIP.Name = "btnSaveSetIP";
            this.btnSaveSetIP.Size = new System.Drawing.Size(65, 61);
            this.btnSaveSetIP.TabIndex = 40;
            this.btnSaveSetIP.Click += new System.EventHandler(this.btnSaveSetIP_Click);
            // 
            // fmSettingIPDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 317);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "fmSettingIPDevice";
            this.Text = "ตั้งค่าการเชื่อมต่อ";
            this.Load += new System.EventHandler(this.FormLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnExitSetIP;
        private DevExpress.XtraEditors.SimpleButton btnSaveSetIP;
        private System.Windows.Forms.Label device1;
        private System.Windows.Forms.TextBox ipDev1;
        private System.Windows.Forms.TextBox ipDev2;
        private System.Windows.Forms.TextBox ipDev3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}