namespace DparkTerminal
{
    partial class fmConfigTerminalMode
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutoOpenForMember = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rdGateOut = new System.Windows.Forms.RadioButton();
            this.rdGateIn = new System.Windows.Forms.RadioButton();
            this.txtInfo = new BackOffice.TextBoxBink();
            this.bt_save = new DevExpress.XtraEditors.SimpleButton();
            this.bt_exit = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bySyncTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(522, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.txtInfo);
            this.tabPage2.Controls.Add(this.bt_save);
            this.tabPage2.Controls.Add(this.bt_exit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(514, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ตั้งค่าการทำงาน";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckAutoStart);
            this.groupBox3.Location = new System.Drawing.Point(32, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 66);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "เริ่มโปรแกรมอัตโนมัติ";
            // 
            // ckAutoStart
            // 
            this.ckAutoStart.AutoSize = true;
            this.ckAutoStart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ckAutoStart.Location = new System.Drawing.Point(26, 29);
            this.ckAutoStart.Name = "ckAutoStart";
            this.ckAutoStart.Size = new System.Drawing.Size(237, 21);
            this.ckAutoStart.TabIndex = 0;
            this.ckAutoStart.Text = "เปิดโปรแกรมอัตโนมัติ เมื่อเข้าวินโดว์";
            this.ckAutoStart.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoOpenForMember);
            this.groupBox2.Location = new System.Drawing.Point(32, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 66);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บัตรสมาชิก";
            // 
            // chkAutoOpenForMember
            // 
            this.chkAutoOpenForMember.AutoSize = true;
            this.chkAutoOpenForMember.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkAutoOpenForMember.Location = new System.Drawing.Point(26, 29);
            this.chkAutoOpenForMember.Name = "chkAutoOpenForMember";
            this.chkAutoOpenForMember.Size = new System.Drawing.Size(224, 21);
            this.chkAutoOpenForMember.TabIndex = 0;
            this.chkAutoOpenForMember.Text = "ยกไม้อัตโนมัติ เมื่อสมาชิกทาบบัตร";
            this.chkAutoOpenForMember.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.rdGateOut);
            this.groupBox1.Controls.Add(this.rdGateIn);
            this.groupBox1.Location = new System.Drawing.Point(32, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 147);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ทิศทาง";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.Silver;
            this.richTextBox1.Location = new System.Drawing.Point(16, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(243, 32);
            this.richTextBox1.TabIndex = 131;
            this.richTextBox1.Text = "- สำหรับทางเข้าแบบ 2หัวอ่าน ทั้งเข้าทั้งออก ระบบจะทำการเลือกอัตโนมัติให้เอง";
            // 
            // rdGateOut
            // 
            this.rdGateOut.AutoSize = true;
            this.rdGateOut.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rdGateOut.Location = new System.Drawing.Point(16, 56);
            this.rdGateOut.Name = "rdGateOut";
            this.rdGateOut.Size = new System.Drawing.Size(74, 21);
            this.rdGateOut.TabIndex = 130;
            this.rdGateOut.TabStop = true;
            this.rdGateOut.Text = "ทางออก";
            this.rdGateOut.UseVisualStyleBackColor = true;
            // 
            // rdGateIn
            // 
            this.rdGateIn.AutoSize = true;
            this.rdGateIn.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rdGateIn.Location = new System.Drawing.Point(16, 20);
            this.rdGateIn.Name = "rdGateIn";
            this.rdGateIn.Size = new System.Drawing.Size(71, 21);
            this.rdGateIn.TabIndex = 129;
            this.rdGateIn.TabStop = true;
            this.rdGateIn.Text = "ทางเข้า";
            this.rdGateIn.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.Black;
            this.txtInfo.BlinkDelay = 1500;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtInfo.ForeColor = System.Drawing.Color.Lime;
            this.txtInfo.Location = new System.Drawing.Point(335, 94);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(162, 27);
            this.txtInfo.TabIndex = 132;
            this.txtInfo.Visible = false;
            // 
            // bt_save
            // 
            this.bt_save.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_save.Appearance.Options.UseFont = true;
            this.bt_save.Image = global::DparkTerminal.Properties.Resources.Save_32x32;
            this.bt_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_save.Location = new System.Drawing.Point(335, 8);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(70, 70);
            this.bt_save.TabIndex = 128;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_exit.Appearance.Options.UseFont = true;
            this.bt_exit.Image = global::DparkTerminal.Properties.Resources.Remove_32x321;
            this.bt_exit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_exit.Location = new System.Drawing.Point(427, 8);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 70);
            this.bt_exit.TabIndex = 127;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.bySyncTime);
            this.groupBox4.Location = new System.Drawing.Point(32, 305);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 66);
            this.groupBox4.TabIndex = 136;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ปรับเวลาอัตโนมัติ";
            // 
            // bySyncTime
            // 
            this.bySyncTime.Image = global::DparkTerminal.Properties.Resources.GenerateData_32x32;
            this.bySyncTime.Location = new System.Drawing.Point(26, 20);
            this.bySyncTime.Name = "bySyncTime";
            this.bySyncTime.Size = new System.Drawing.Size(40, 40);
            this.bySyncTime.TabIndex = 1;
            this.bySyncTime.UseVisualStyleBackColor = true;
            this.bySyncTime.Click += new System.EventHandler(this.bySyncTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(71, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ปรับเวลาเครื่องให้ตรงกับระบบ";
            // 
            // fmConfigTerminalMode
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(539, 493);
            this.Controls.Add(this.tabControl1);
            this.Name = "fmConfigTerminalMode";
            this.Text = "โหมดการทำงาน";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.SimpleButton bt_save;
        private DevExpress.XtraEditors.SimpleButton bt_exit;
        private System.Windows.Forms.RadioButton rdGateOut;
        private System.Windows.Forms.RadioButton rdGateIn;
        private BackOffice.TextBoxBink txtInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkAutoOpenForMember;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckAutoStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bySyncTime;
        private System.Windows.Forms.Label label1;



    }
}