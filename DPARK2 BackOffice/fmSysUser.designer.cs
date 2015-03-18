namespace BackOffice
{
    partial class fmSysUser
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbsysUserType1 = new BackOffice.cbsysUserType();
            this.dtpUserExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btUserName = new DevExpress.XtraEditors.SimpleButton();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.chk_UserActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_loginName = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_passwdConfirm = new System.Windows.Forms.TextBox();
            this.txt_addr = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbOwnerCompany = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btUserDel = new DevExpress.XtraEditors.SimpleButton();
            this.bt_close = new DevExpress.XtraEditors.SimpleButton();
            this.btUserSave = new DevExpress.XtraEditors.SimpleButton();
            this.img_userImg = new DevExpress.XtraEditors.PictureEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_userImg.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1348, 266);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1342, 246);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbsysUserType1);
            this.groupBox1.Controls.Add(this.dtpUserExpiryDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btUserName);
            this.groupBox1.Controls.Add(this.txt_email);
            this.groupBox1.Controls.Add(this.chk_UserActive);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_loginName);
            this.groupBox1.Controls.Add(this.txt_phone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_passwdConfirm);
            this.groupBox1.Controls.Add(this.txt_addr);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txt_tel);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbOwnerCompany);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btUserDel);
            this.groupBox1.Controls.Add(this.bt_close);
            this.groupBox1.Controls.Add(this.btUserSave);
            this.groupBox1.Controls.Add(this.img_userImg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 266);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // cbsysUserType1
            // 
            this.cbsysUserType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsysUserType1.FormattingEnabled = true;
            this.cbsysUserType1.Location = new System.Drawing.Point(217, 208);
            this.cbsysUserType1.Name = "cbsysUserType1";
            this.cbsysUserType1.Size = new System.Drawing.Size(203, 21);
            this.cbsysUserType1.TabIndex = 119;
            // 
            // dtpUserExpiryDate
            // 
            this.dtpUserExpiryDate.CalendarFont = new System.Drawing.Font("Tahoma", 10F);
            this.dtpUserExpiryDate.Location = new System.Drawing.Point(217, 177);
            this.dtpUserExpiryDate.MinDate = new System.DateTime(2013, 9, 20, 0, 0, 0, 0);
            this.dtpUserExpiryDate.Name = "dtpUserExpiryDate";
            this.dtpUserExpiryDate.Size = new System.Drawing.Size(202, 21);
            this.dtpUserExpiryDate.TabIndex = 6;
            this.dtpUserExpiryDate.Value = new System.DateTime(2013, 9, 20, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(118, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 118;
            this.label4.Text = "วันหมดอายุ:";
            // 
            // btUserName
            // 
            this.btUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btUserName.Appearance.Options.UseFont = true;
            this.btUserName.Image = global::BackOffice.Properties.Resources.new_file_icon;
            this.btUserName.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btUserName.Location = new System.Drawing.Point(748, 13);
            this.btUserName.Name = "btUserName";
            this.btUserName.Size = new System.Drawing.Size(70, 70);
            this.btUserName.TabIndex = 14;
            this.btUserName.Click += new System.EventHandler(this.btUserName_Click);
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_email.Location = new System.Drawing.Point(502, 205);
            this.txt_email.MaxLength = 50;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(222, 24);
            this.txt_email.TabIndex = 12;
            // 
            // chk_UserActive
            // 
            this.chk_UserActive.AutoSize = true;
            this.chk_UserActive.Checked = true;
            this.chk_UserActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_UserActive.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chk_UserActive.Location = new System.Drawing.Point(218, 113);
            this.chk_UserActive.Name = "chk_UserActive";
            this.chk_UserActive.Size = new System.Drawing.Size(64, 21);
            this.chk_UserActive.TabIndex = 4;
            this.chk_UserActive.Text = "Active";
            this.chk_UserActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(435, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 69;
            this.label5.Text = "เบอร์โทร:";
            // 
            // txt_loginName
            // 
            this.txt_loginName.BackColor = System.Drawing.Color.Khaki;
            this.txt_loginName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_loginName.Location = new System.Drawing.Point(217, 15);
            this.txt_loginName.MaxLength = 20;
            this.txt_loginName.Name = "txt_loginName";
            this.txt_loginName.Size = new System.Drawing.Size(202, 24);
            this.txt_loginName.TabIndex = 1;
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_phone.Location = new System.Drawing.Point(502, 174);
            this.txt_phone.MaxLength = 12;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(222, 24);
            this.txt_phone.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(118, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 113;
            this.label2.Text = "ชื่อผู้ใช้";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.Location = new System.Drawing.Point(435, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 71;
            this.label6.Text = "มือถือ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.Location = new System.Drawing.Point(435, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 73;
            this.label7.Text = "Email:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label25.Location = new System.Drawing.Point(118, 208);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 17);
            this.label25.TabIndex = 111;
            this.label25.Text = "สิทธิการใช้งาน:";
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.Khaki;
            this.txt_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_name.Location = new System.Drawing.Point(502, 16);
            this.txt_name.MaxLength = 20;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(221, 24);
            this.txt_name.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(435, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 92;
            this.label1.Text = "ชื่อ-สกุล:";
            // 
            // txt_passwdConfirm
            // 
            this.txt_passwdConfirm.BackColor = System.Drawing.Color.Khaki;
            this.txt_passwdConfirm.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_passwdConfirm.Location = new System.Drawing.Point(218, 74);
            this.txt_passwdConfirm.MaxLength = 20;
            this.txt_passwdConfirm.Name = "txt_passwdConfirm";
            this.txt_passwdConfirm.PasswordChar = '*';
            this.txt_passwdConfirm.Size = new System.Drawing.Size(202, 24);
            this.txt_passwdConfirm.TabIndex = 3;
            this.txt_passwdConfirm.UseSystemPasswordChar = true;
            // 
            // txt_addr
            // 
            this.txt_addr.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_addr.Location = new System.Drawing.Point(501, 48);
            this.txt_addr.MaxLength = 50;
            this.txt_addr.Multiline = true;
            this.txt_addr.Name = "txt_addr";
            this.txt_addr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_addr.Size = new System.Drawing.Size(222, 86);
            this.txt_addr.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label20.Location = new System.Drawing.Point(118, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 17);
            this.label20.TabIndex = 104;
            this.label20.Text = "ยืนยันรหัสผ่าน:";
            // 
            // txt_tel
            // 
            this.txt_tel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_tel.Location = new System.Drawing.Point(502, 142);
            this.txt_tel.MaxLength = 12;
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(222, 24);
            this.txt_tel.TabIndex = 10;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.Khaki;
            this.txt_password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_password.Location = new System.Drawing.Point(217, 44);
            this.txt_password.MaxLength = 20;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(202, 24);
            this.txt_password.TabIndex = 2;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label19.Location = new System.Drawing.Point(435, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 17);
            this.label19.TabIndex = 98;
            this.label19.Text = "ที่อยู่";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.Location = new System.Drawing.Point(118, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 102;
            this.label9.Text = "รหัสผ่าน:";
            // 
            // cbOwnerCompany
            // 
            this.cbOwnerCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOwnerCompany.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbOwnerCompany.FormattingEnabled = true;
            this.cbOwnerCompany.Location = new System.Drawing.Point(217, 141);
            this.cbOwnerCompany.Name = "cbOwnerCompany";
            this.cbOwnerCompany.Size = new System.Drawing.Size(202, 24);
            this.cbOwnerCompany.TabIndex = 5;
            this.cbOwnerCompany.Visible = false;
            this.cbOwnerCompany.DropDown += new System.EventHandler(this.cbOwnerCompany_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.Location = new System.Drawing.Point(118, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 17);
            this.label10.TabIndex = 79;
            this.label10.Text = "สถานะ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(118, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "ต้นสังกัด:";
            this.label3.Visible = false;
            // 
            // btUserDel
            // 
            this.btUserDel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btUserDel.Appearance.Options.UseFont = true;
            this.btUserDel.Image = global::BackOffice.Properties.Resources.bin323;
            this.btUserDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btUserDel.Location = new System.Drawing.Point(748, 89);
            this.btUserDel.Name = "btUserDel";
            this.btUserDel.Size = new System.Drawing.Size(70, 70);
            this.btUserDel.TabIndex = 15;
            this.btUserDel.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_close
            // 
            this.bt_close.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_close.Appearance.Options.UseFont = true;
            this.bt_close.Image = global::BackOffice.Properties.Resources.Remove_32x32;
            this.bt_close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_close.Location = new System.Drawing.Point(955, 12);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(70, 70);
            this.bt_close.TabIndex = 16;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // btUserSave
            // 
            this.btUserSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btUserSave.Appearance.Options.UseFont = true;
            this.btUserSave.Image = global::BackOffice.Properties.Resources.Save_32x32;
            this.btUserSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btUserSave.Location = new System.Drawing.Point(826, 13);
            this.btUserSave.Name = "btUserSave";
            this.btUserSave.Size = new System.Drawing.Size(70, 70);
            this.btUserSave.TabIndex = 13;
            this.btUserSave.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // img_userImg
            // 
            this.img_userImg.EditValue = global::BackOffice.Properties.Resources._1351994560_People_MSN;
            this.img_userImg.Location = new System.Drawing.Point(6, 12);
            this.img_userImg.Name = "img_userImg";
            this.img_userImg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.img_userImg.Size = new System.Drawing.Size(100, 115);
            this.img_userImg.TabIndex = 0;
            this.img_userImg.TabStop = true;
            this.img_userImg.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1354, 544);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // fmSysUser
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 544);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "fmSysUser";
            this.Text = "ข้อมูลผู้ใช้ระบบ";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_userImg.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_passwdConfirm;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_tel;
        private System.Windows.Forms.ComboBox cbOwnerCompany;
        private System.Windows.Forms.TextBox txt_addr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btUserDel;
        private DevExpress.XtraEditors.SimpleButton bt_close;
        private DevExpress.XtraEditors.SimpleButton btUserSave;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox chk_UserActive;
        private System.Windows.Forms.TextBox txt_loginName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PictureEdit img_userImg;
        private DevExpress.XtraEditors.SimpleButton btUserName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpUserExpiryDate;
        private cbsysUserType cbsysUserType1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}