namespace DparkTerminal
{
    partial class fmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLogin));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.btLogin = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btDBConfig = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.ckSaveUserName = new System.Windows.Forms.CheckBox();
            this.ckAutologin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::DparkTerminal.Properties.Resources.logo;
            this.pictureEdit1.Location = new System.Drawing.Point(101, 43);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(261, 59);
            this.pictureEdit1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Location = new System.Drawing.Point(97, 129);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 18);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "ชื่อผู้ใช้งาน :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Location = new System.Drawing.Point(113, 167);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "รหัสผ่าน :";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::DparkTerminal.Properties.Resources.person;
            this.pictureEdit2.Location = new System.Drawing.Point(87, 260);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Size = new System.Drawing.Size(57, 53);
            this.pictureEdit2.TabIndex = 7;
            // 
            // alertControl1
            // 
            this.alertControl1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.alertControl1.AppearanceText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.alertControl1.AppearanceText.Options.UseFont = true;
            this.alertControl1.AppearanceText.Options.UseForeColor = true;
            this.alertControl1.AutoFormDelay = 2000;
            // 
            // btLogin
            // 
            this.btLogin.Image = global::DparkTerminal.Properties.Resources.login2;
            this.btLogin.Location = new System.Drawing.Point(228, 238);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(64, 64);
            this.btLogin.TabIndex = 8;
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btExit
            // 
            this.btExit.Image = global::DparkTerminal.Properties.Resources.Exit;
            this.btExit.Location = new System.Drawing.Point(298, 238);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(64, 64);
            this.btExit.TabIndex = 9;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtLoginName
            // 
            this.txtLoginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLoginName.Location = new System.Drawing.Point(179, 121);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(172, 30);
            this.txtLoginName.TabIndex = 10;
            this.txtLoginName.Enter += new System.EventHandler(this.txtLoginName_Enter);
            this.txtLoginName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtLoginName_PreviewKeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPassword.Location = new System.Drawing.Point(179, 159);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(172, 30);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtLoginName_PreviewKeyDown);
            // 
            // btDBConfig
            // 
            this.btDBConfig.Image = global::DparkTerminal.Properties.Resources.Database_Active_icon;
            this.btDBConfig.Location = new System.Drawing.Point(158, 238);
            this.btDBConfig.Name = "btDBConfig";
            this.btDBConfig.Size = new System.Drawing.Size(64, 64);
            this.btDBConfig.TabIndex = 12;
            this.btDBConfig.UseVisualStyleBackColor = true;
            this.btDBConfig.Click += new System.EventHandler(this.btDBConfig_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.BackColor = System.Drawing.Color.White;
            this.lbInfo.ForeColor = System.Drawing.Color.Red;
            this.lbInfo.Location = new System.Drawing.Point(191, 105);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(160, 13);
            this.lbInfo.TabIndex = 13;
            this.lbInfo.Text = "Username / Password ไม่ถูกต้อง";
            this.lbInfo.Visible = false;
            // 
            // ckSaveUserName
            // 
            this.ckSaveUserName.AutoSize = true;
            this.ckSaveUserName.BackColor = System.Drawing.Color.White;
            this.ckSaveUserName.ForeColor = System.Drawing.Color.Gray;
            this.ckSaveUserName.Location = new System.Drawing.Point(179, 195);
            this.ckSaveUserName.Name = "ckSaveUserName";
            this.ckSaveUserName.Size = new System.Drawing.Size(170, 17);
            this.ckSaveUserName.TabIndex = 14;
            this.ckSaveUserName.Text = "บันทึก ชื่อผู้ใช้งาน และรหัสผ่าน";
            this.ckSaveUserName.UseVisualStyleBackColor = false;
            this.ckSaveUserName.CheckedChanged += new System.EventHandler(this.ckSaveUserName_CheckedChanged);
            // 
            // ckAutologin
            // 
            this.ckAutologin.AutoSize = true;
            this.ckAutologin.BackColor = System.Drawing.Color.White;
            this.ckAutologin.ForeColor = System.Drawing.Color.Gray;
            this.ckAutologin.Location = new System.Drawing.Point(179, 215);
            this.ckAutologin.Name = "ckAutologin";
            this.ckAutologin.Size = new System.Drawing.Size(110, 17);
            this.ckAutologin.TabIndex = 15;
            this.ckAutologin.Text = "เข้าระบบ อัตโนมัติ";
            this.ckAutologin.UseVisualStyleBackColor = false;
            this.ckAutologin.CheckedChanged += new System.EventHandler(this.ckAutologin_CheckedChanged);
            // 
            // fmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DparkTerminal.Properties.Resources.logbg01;
            this.ClientSize = new System.Drawing.Size(461, 361);
            this.Controls.Add(this.ckAutologin);
            this.Controls.Add(this.ckSaveUserName);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btDBConfig);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D P A R K   T E R M I N A L";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmLogin_FormClosed);
            this.Shown += new System.EventHandler(this.fmLogin_Shown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtLoginName_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btDBConfig;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.CheckBox ckSaveUserName;
        private System.Windows.Forms.CheckBox ckAutologin;
    }
}

