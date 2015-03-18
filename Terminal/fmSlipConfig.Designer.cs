namespace DparkTerminal
{
    partial class fmSlipConfig
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
            this.cmPrinter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPrintTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_save = new DevExpress.XtraEditors.SimpleButton();
            this.bt_exit = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameCompany = new System.Windows.Forms.TextBox();
            this.txtSlipTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumberCompany = new System.Windows.Forms.TextBox();
            this.lbwordTax = new System.Windows.Forms.Label();
            this.txtInfo = new BackOffice.TextBoxBink();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmPrinter
            // 
            this.cmPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmPrinter.FormattingEnabled = true;
            this.cmPrinter.Location = new System.Drawing.Point(168, 127);
            this.cmPrinter.Name = "cmPrinter";
            this.cmPrinter.Size = new System.Drawing.Size(270, 21);
            this.cmPrinter.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumberCompany);
            this.groupBox1.Controls.Add(this.lbwordTax);
            this.groupBox1.Controls.Add(this.txtSlipTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNameCompany);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btPrintTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmPrinter);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 257);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            // 
            // btPrintTest
            // 
            this.btPrintTest.Location = new System.Drawing.Point(363, 190);
            this.btPrintTest.Name = "btPrintTest";
            this.btPrintTest.Size = new System.Drawing.Size(75, 37);
            this.btPrintTest.TabIndex = 2;
            this.btPrintTest.Text = "PrintTest";
            this.btPrintTest.UseVisualStyleBackColor = true;
            this.btPrintTest.Click += new System.EventHandler(this.btPrintTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(27, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "เครื่องพิมพ์สลิป";
            // 
            // bt_save
            // 
            this.bt_save.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_save.Appearance.Options.UseFont = true;
            this.bt_save.Image = global::DparkTerminal.Properties.Resources.Save_32x32;
            this.bt_save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_save.Location = new System.Drawing.Point(512, 12);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(70, 70);
            this.bt_save.TabIndex = 134;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_exit.Appearance.Options.UseFont = true;
            this.bt_exit.Image = global::DparkTerminal.Properties.Resources.Remove_32x321;
            this.bt_exit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_exit.Location = new System.Drawing.Point(604, 12);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 70);
            this.bt_exit.TabIndex = 133;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ชื่อบริษัท:";
            // 
            // txtNameCompany
            // 
            this.txtNameCompany.Location = new System.Drawing.Point(168, 26);
            this.txtNameCompany.Name = "txtNameCompany";
            this.txtNameCompany.Size = new System.Drawing.Size(270, 20);
            this.txtNameCompany.TabIndex = 4;
            // 
            // txtSlipTitle
            // 
            this.txtSlipTitle.Location = new System.Drawing.Point(168, 57);
            this.txtSlipTitle.Name = "txtSlipTitle";
            this.txtSlipTitle.Size = new System.Drawing.Size(270, 20);
            this.txtSlipTitle.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ชื่อรายการ:";
            // 
            // txtNumberCompany
            // 
            this.txtNumberCompany.Location = new System.Drawing.Point(168, 91);
            this.txtNumberCompany.Name = "txtNumberCompany";
            this.txtNumberCompany.Size = new System.Drawing.Size(270, 20);
            this.txtNumberCompany.TabIndex = 8;
            // 
            // lbwordTax
            // 
            this.lbwordTax.AutoSize = true;
            this.lbwordTax.Location = new System.Drawing.Point(27, 94);
            this.lbwordTax.Name = "lbwordTax";
            this.lbwordTax.Size = new System.Drawing.Size(114, 13);
            this.lbwordTax.TabIndex = 7;
            this.lbwordTax.Text = "เลขประจำตัวผู้เสียภาษี:";
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.Black;
            this.txtInfo.BlinkDelay = 1500;
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtInfo.ForeColor = System.Drawing.Color.Lime;
            this.txtInfo.Location = new System.Drawing.Point(512, 98);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(162, 27);
            this.txtInfo.TabIndex = 135;
            this.txtInfo.Visible = false;
            // 
            // fmSlipConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(681, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_exit);
            this.Name = "fmSlipConfig";
            this.Text = "ตั้งค่าการพิมพ์สลิป";
            this.Load += new System.EventHandler(this.fmSlipConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmPrinter;
        private BackOffice.TextBoxBink txtInfo;
        private DevExpress.XtraEditors.SimpleButton bt_save;
        private DevExpress.XtraEditors.SimpleButton bt_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrintTest;
        private System.Windows.Forms.TextBox txtNumberCompany;
        private System.Windows.Forms.Label lbwordTax;
        private System.Windows.Forms.TextBox txtSlipTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameCompany;
        private System.Windows.Forms.Label label2;


    }
}