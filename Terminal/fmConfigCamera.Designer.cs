namespace DparkTerminal
{
    partial class fmConfigCamera
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCamMode = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCamOut1 = new System.Windows.Forms.ComboBox();
            this.chCamIn1Save = new System.Windows.Forms.CheckBox();
            this.chCamIn2Save = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chCamIn3Save = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCamOut3 = new System.Windows.Forms.ComboBox();
            this.cbCamOut2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCamIn1 = new System.Windows.Forms.ComboBox();
            this.chCamOut1Save = new System.Windows.Forms.CheckBox();
            this.chCamOut2Save = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chCamOut3Save = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbt1 = new System.Windows.Forms.Label();
            this.cbCamIn3 = new System.Windows.Forms.ComboBox();
            this.cbCamIn2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkCamActive = new System.Windows.Forms.CheckBox();
            this.gpDVR = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDVRPort = new System.Windows.Forms.TextBox();
            this.txtDVRIP = new System.Windows.Forms.TextBox();
            this.txtDVRPasswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDVRUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInfo = new DparkTerminal.TextBoxBlink();
            this.bt_save = new DevExpress.XtraEditors.SimpleButton();
            this.bt_exit = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpDVR.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chkCamActive);
            this.tabPage2.Controls.Add(this.gpDVR);
            this.tabPage2.Controls.Add(this.txtInfo);
            this.tabPage2.Controls.Add(this.bt_save);
            this.tabPage2.Controls.Add(this.bt_exit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(563, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "กล้อง";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbCamMode);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(16, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 302);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "การบันทึกภาพ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "โหมดการบันทึก";
            // 
            // cmbCamMode
            // 
            this.cmbCamMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamMode.FormattingEnabled = true;
            this.cmbCamMode.Items.AddRange(new object[] {
            "ทางเข้า หรือ ทางออก",
            "ทางเข้า และ ทางออก"});
            this.cmbCamMode.Location = new System.Drawing.Point(301, 55);
            this.cmbCamMode.Name = "cmbCamMode";
            this.cmbCamMode.Size = new System.Drawing.Size(168, 21);
            this.cmbCamMode.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCamOut1);
            this.groupBox3.Controls.Add(this.chCamIn1Save);
            this.groupBox3.Controls.Add(this.chCamIn2Save);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chCamIn3Save);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbCamOut3);
            this.groupBox3.Controls.Add(this.cbCamOut2);
            this.groupBox3.Location = new System.Drawing.Point(13, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 131);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ขาออก";
            // 
            // cbCamOut1
            // 
            this.cbCamOut1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamOut1.FormattingEnabled = true;
            this.cbCamOut1.Location = new System.Drawing.Point(52, 32);
            this.cbCamOut1.Name = "cbCamOut1";
            this.cbCamOut1.Size = new System.Drawing.Size(121, 21);
            this.cbCamOut1.TabIndex = 3;
            // 
            // chCamIn1Save
            // 
            this.chCamIn1Save.AutoSize = true;
            this.chCamIn1Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamIn1Save.Location = new System.Drawing.Point(179, 35);
            this.chCamIn1Save.Name = "chCamIn1Save";
            this.chCamIn1Save.Size = new System.Drawing.Size(60, 20);
            this.chCamIn1Save.TabIndex = 0;
            this.chCamIn1Save.Text = "บันทึก";
            this.chCamIn1Save.UseVisualStyleBackColor = true;
            // 
            // chCamIn2Save
            // 
            this.chCamIn2Save.AutoSize = true;
            this.chCamIn2Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamIn2Save.Location = new System.Drawing.Point(179, 60);
            this.chCamIn2Save.Name = "chCamIn2Save";
            this.chCamIn2Save.Size = new System.Drawing.Size(60, 20);
            this.chCamIn2Save.TabIndex = 1;
            this.chCamIn2Save.Text = "บันทึก";
            this.chCamIn2Save.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "จอ 3 :";
            // 
            // chCamIn3Save
            // 
            this.chCamIn3Save.AutoSize = true;
            this.chCamIn3Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamIn3Save.Location = new System.Drawing.Point(179, 87);
            this.chCamIn3Save.Name = "chCamIn3Save";
            this.chCamIn3Save.Size = new System.Drawing.Size(60, 20);
            this.chCamIn3Save.TabIndex = 2;
            this.chCamIn3Save.Text = "บันทึก";
            this.chCamIn3Save.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "จอ 2 :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "จอ 1 :";
            // 
            // cbCamOut3
            // 
            this.cbCamOut3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamOut3.FormattingEnabled = true;
            this.cbCamOut3.Location = new System.Drawing.Point(52, 86);
            this.cbCamOut3.Name = "cbCamOut3";
            this.cbCamOut3.Size = new System.Drawing.Size(121, 21);
            this.cbCamOut3.TabIndex = 6;
            // 
            // cbCamOut2
            // 
            this.cbCamOut2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamOut2.FormattingEnabled = true;
            this.cbCamOut2.Location = new System.Drawing.Point(52, 59);
            this.cbCamOut2.Name = "cbCamOut2";
            this.cbCamOut2.Size = new System.Drawing.Size(121, 21);
            this.cbCamOut2.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCamIn1);
            this.groupBox2.Controls.Add(this.chCamOut1Save);
            this.groupBox2.Controls.Add(this.chCamOut2Save);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chCamOut3Save);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbt1);
            this.groupBox2.Controls.Add(this.cbCamIn3);
            this.groupBox2.Controls.Add(this.cbCamIn2);
            this.groupBox2.Location = new System.Drawing.Point(270, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 131);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ขาออก";
            // 
            // cbCamIn1
            // 
            this.cbCamIn1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamIn1.FormattingEnabled = true;
            this.cbCamIn1.Location = new System.Drawing.Point(52, 32);
            this.cbCamIn1.Name = "cbCamIn1";
            this.cbCamIn1.Size = new System.Drawing.Size(121, 21);
            this.cbCamIn1.TabIndex = 3;
            // 
            // chCamOut1Save
            // 
            this.chCamOut1Save.AutoSize = true;
            this.chCamOut1Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamOut1Save.Location = new System.Drawing.Point(179, 35);
            this.chCamOut1Save.Name = "chCamOut1Save";
            this.chCamOut1Save.Size = new System.Drawing.Size(60, 20);
            this.chCamOut1Save.TabIndex = 0;
            this.chCamOut1Save.Text = "บันทึก";
            this.chCamOut1Save.UseVisualStyleBackColor = true;
            // 
            // chCamOut2Save
            // 
            this.chCamOut2Save.AutoSize = true;
            this.chCamOut2Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamOut2Save.Location = new System.Drawing.Point(179, 60);
            this.chCamOut2Save.Name = "chCamOut2Save";
            this.chCamOut2Save.Size = new System.Drawing.Size(60, 20);
            this.chCamOut2Save.TabIndex = 1;
            this.chCamOut2Save.Text = "บันทึก";
            this.chCamOut2Save.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "จอ 3 :";
            // 
            // chCamOut3Save
            // 
            this.chCamOut3Save.AutoSize = true;
            this.chCamOut3Save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chCamOut3Save.Location = new System.Drawing.Point(179, 87);
            this.chCamOut3Save.Name = "chCamOut3Save";
            this.chCamOut3Save.Size = new System.Drawing.Size(60, 20);
            this.chCamOut3Save.TabIndex = 2;
            this.chCamOut3Save.Text = "บันทึก";
            this.chCamOut3Save.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "จอ 2 :";
            // 
            // lbt1
            // 
            this.lbt1.AutoSize = true;
            this.lbt1.Location = new System.Drawing.Point(6, 35);
            this.lbt1.Name = "lbt1";
            this.lbt1.Size = new System.Drawing.Size(36, 13);
            this.lbt1.TabIndex = 4;
            this.lbt1.Text = "จอ 1 :";
            // 
            // cbCamIn3
            // 
            this.cbCamIn3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamIn3.FormattingEnabled = true;
            this.cbCamIn3.Location = new System.Drawing.Point(52, 86);
            this.cbCamIn3.Name = "cbCamIn3";
            this.cbCamIn3.Size = new System.Drawing.Size(121, 21);
            this.cbCamIn3.TabIndex = 6;
            // 
            // cbCamIn2
            // 
            this.cbCamIn2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamIn2.FormattingEnabled = true;
            this.cbCamIn2.Location = new System.Drawing.Point(52, 59);
            this.cbCamIn2.Name = "cbCamIn2";
            this.cbCamIn2.Size = new System.Drawing.Size(121, 21);
            this.cbCamIn2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "หมายเลขจอแสดงผล";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DparkTerminal.Properties.Resources._26_ต_ค__2013_19_16_22;
            this.pictureBox1.Location = new System.Drawing.Point(60, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // chkCamActive
            // 
            this.chkCamActive.AutoSize = true;
            this.chkCamActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkCamActive.Location = new System.Drawing.Point(16, 12);
            this.chkCamActive.Name = "chkCamActive";
            this.chkCamActive.Size = new System.Drawing.Size(134, 21);
            this.chkCamActive.TabIndex = 0;
            this.chkCamActive.Text = "บันทึกภาพเข้าออก";
            this.chkCamActive.UseVisualStyleBackColor = true;
            this.chkCamActive.CheckedChanged += new System.EventHandler(this.chkCamActive_CheckedChanged);
            // 
            // gpDVR
            // 
            this.gpDVR.Controls.Add(this.label1);
            this.gpDVR.Controls.Add(this.txtDVRPort);
            this.gpDVR.Controls.Add(this.txtDVRIP);
            this.gpDVR.Controls.Add(this.txtDVRPasswd);
            this.gpDVR.Controls.Add(this.label2);
            this.gpDVR.Controls.Add(this.txtDVRUser);
            this.gpDVR.Controls.Add(this.label3);
            this.gpDVR.Controls.Add(this.label4);
            this.gpDVR.Location = new System.Drawing.Point(16, 38);
            this.gpDVR.Name = "gpDVR";
            this.gpDVR.Size = new System.Drawing.Size(317, 158);
            this.gpDVR.TabIndex = 142;
            this.gpDVR.TabStop = false;
            this.gpDVR.Text = "ตั้งค่าการเชื่อมต่อ เครื่องบันทึกภาพ (DVR)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 134;
            this.label1.Text = "IP:";
            // 
            // txtDVRPort
            // 
            this.txtDVRPort.Location = new System.Drawing.Point(93, 62);
            this.txtDVRPort.Name = "txtDVRPort";
            this.txtDVRPort.Size = new System.Drawing.Size(149, 21);
            this.txtDVRPort.TabIndex = 1;
            // 
            // txtDVRIP
            // 
            this.txtDVRIP.Location = new System.Drawing.Point(93, 29);
            this.txtDVRIP.Name = "txtDVRIP";
            this.txtDVRIP.Size = new System.Drawing.Size(149, 21);
            this.txtDVRIP.TabIndex = 0;
            // 
            // txtDVRPasswd
            // 
            this.txtDVRPasswd.Location = new System.Drawing.Point(93, 128);
            this.txtDVRPasswd.Name = "txtDVRPasswd";
            this.txtDVRPasswd.Size = new System.Drawing.Size(149, 21);
            this.txtDVRPasswd.TabIndex = 3;
            this.txtDVRPasswd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 136;
            this.label2.Text = "PORT:";
            // 
            // txtDVRUser
            // 
            this.txtDVRUser.Location = new System.Drawing.Point(93, 95);
            this.txtDVRUser.Name = "txtDVRUser";
            this.txtDVRUser.Size = new System.Drawing.Size(149, 21);
            this.txtDVRUser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 137;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 138;
            this.label4.Text = "Password:";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.Black;
            this.txtInfo.BlinkDelay = 1500;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtInfo.ForeColor = System.Drawing.Color.Lime;
            this.txtInfo.Location = new System.Drawing.Point(171, 7);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(162, 27);
            this.txtInfo.TabIndex = 133;
            this.txtInfo.Visible = false;
            // 
            // bt_save
            // 
            this.bt_save.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_save.Appearance.Options.UseFont = true;
            this.bt_save.Image = global::DparkTerminal.Properties.Resources.Save_32x32;
            this.bt_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_save.Location = new System.Drawing.Point(473, 38);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(70, 70);
            this.bt_save.TabIndex = 1;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_exit.Appearance.Options.UseFont = true;
            this.bt_exit.Image = global::DparkTerminal.Properties.Resources.Remove_32x321;
            this.bt_exit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_exit.Location = new System.Drawing.Point(473, 114);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 70);
            this.bt_exit.TabIndex = 2;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // fmConfigCamera
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 557);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmConfigCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ตั้งค่าการเชื่อมต่อ กล้องจับภาพ";
            this.Load += new System.EventHandler(this.fmIOController_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpDVR.ResumeLayout(false);
            this.gpDVR.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.SimpleButton bt_save;
        private DevExpress.XtraEditors.SimpleButton bt_exit;
        private TextBoxBlink txtInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDVRIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpDVR;
        private System.Windows.Forms.TextBox txtDVRPort;
        private System.Windows.Forms.TextBox txtDVRPasswd;
        private System.Windows.Forms.TextBox txtDVRUser;
        private System.Windows.Forms.CheckBox chkCamActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chCamOut3Save;
        private System.Windows.Forms.CheckBox chCamOut2Save;
        private System.Windows.Forms.CheckBox chCamOut1Save;
        private System.Windows.Forms.ComboBox cbCamIn1;
        private System.Windows.Forms.Label lbt1;
        private System.Windows.Forms.ComboBox cbCamIn2;
        private System.Windows.Forms.ComboBox cbCamIn3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCamOut1;
        private System.Windows.Forms.CheckBox chCamIn1Save;
        private System.Windows.Forms.CheckBox chCamIn2Save;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chCamIn3Save;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCamOut3;
        private System.Windows.Forms.ComboBox cbCamOut2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCamMode;

    }
}