namespace BackOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLogin));
            this.lbInfo = new System.Windows.Forms.Label();
            this.btDBConfig = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_passwd = new System.Windows.Forms.TextBox();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.ckAutologin = new System.Windows.Forms.CheckBox();
            this.ckSaveUserName = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.BackColor = System.Drawing.Color.White;
            this.lbInfo.ForeColor = System.Drawing.Color.Red;
            this.lbInfo.Location = new System.Drawing.Point(187, 110);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(160, 13);
            this.lbInfo.TabIndex = 6;
            this.lbInfo.Text = "Username / Password ไม่ถูกต้อง";
            this.lbInfo.Visible = false;
            // 
            // btDBConfig
            // 
            this.btDBConfig.BackColor = System.Drawing.SystemColors.Control;
            this.btDBConfig.Image = global::BackOffice.Properties.Resources.Database_Active_icon;
            this.btDBConfig.Location = new System.Drawing.Point(161, 244);
            this.btDBConfig.Name = "btDBConfig";
            this.btDBConfig.Size = new System.Drawing.Size(64, 64);
            this.btDBConfig.TabIndex = 2;
            this.btDBConfig.UseVisualStyleBackColor = false;
            this.btDBConfig.Click += new System.EventHandler(this.btDBConfig_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.SystemColors.Control;
            this.btExit.Image = global::BackOffice.Properties.Resources.Exit;
            this.btExit.Location = new System.Drawing.Point(299, 244);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(64, 64);
            this.btExit.TabIndex = 4;
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btLogin.Image = global::BackOffice.Properties.Resources.login2;
            this.btLogin.Location = new System.Drawing.Point(230, 244);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(64, 64);
            this.btLogin.TabIndex = 3;
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(100, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(100, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "UserName:";
            // 
            // txt_passwd
            // 
            this.txt_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_passwd.Location = new System.Drawing.Point(190, 163);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(143, 26);
            this.txt_passwd.TabIndex = 1;
            this.txt_passwd.UseSystemPasswordChar = true;
            this.txt_passwd.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_userName_PreviewKeyDown);
            // 
            // txt_userName
            // 
            this.txt_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_userName.Location = new System.Drawing.Point(190, 126);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(143, 26);
            this.txt_userName.TabIndex = 0;
            this.txt_userName.Enter += new System.EventHandler(this.txt_userName_Enter);
            this.txt_userName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_userName_PreviewKeyDown);
            // 
            // ckAutologin
            // 
            this.ckAutologin.AutoSize = true;
            this.ckAutologin.BackColor = System.Drawing.Color.White;
            this.ckAutologin.ForeColor = System.Drawing.Color.Gray;
            this.ckAutologin.Location = new System.Drawing.Point(190, 221);
            this.ckAutologin.Name = "ckAutologin";
            this.ckAutologin.Size = new System.Drawing.Size(110, 17);
            this.ckAutologin.TabIndex = 17;
            this.ckAutologin.Text = "เข้าระบบ อัตโนมัติ";
            this.ckAutologin.UseVisualStyleBackColor = false;
            this.ckAutologin.CheckedChanged += new System.EventHandler(this.ckAutologin_CheckedChanged);
            // 
            // ckSaveUserName
            // 
            this.ckSaveUserName.AutoSize = true;
            this.ckSaveUserName.BackColor = System.Drawing.Color.White;
            this.ckSaveUserName.ForeColor = System.Drawing.Color.Gray;
            this.ckSaveUserName.Location = new System.Drawing.Point(190, 201);
            this.ckSaveUserName.Name = "ckSaveUserName";
            this.ckSaveUserName.Size = new System.Drawing.Size(170, 17);
            this.ckSaveUserName.TabIndex = 16;
            this.ckSaveUserName.Text = "บันทึก ชื่อผู้ใช้งาน และรหัสผ่าน";
            this.ckSaveUserName.UseVisualStyleBackColor = false;
            this.ckSaveUserName.CheckedChanged += new System.EventHandler(this.ckSaveUserName_CheckedChanged);
            // 
            // fmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BackOffice.Properties.Resources.loginBG;
            this.ClientSize = new System.Drawing.Size(461, 361);
            this.Controls.Add(this.ckAutologin);
            this.Controls.Add(this.ckSaveUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_passwd);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btDBConfig);
            this.Controls.Add(this.btLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เข้าสู่ระบบ";
            this.Shown += new System.EventHandler(this.fmLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_passwd;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Button btDBConfig;
        private System.Windows.Forms.Button btExit;
        public System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.CheckBox ckAutologin;
        private System.Windows.Forms.CheckBox ckSaveUserName;
    }
}