namespace BackOffice
{
    partial class fmEmergencyType
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
            this.ckGateOut = new System.Windows.Forms.CheckBox();
            this.ckGateIn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btNew = new DevExpress.XtraEditors.SimpleButton();
            this.btDel = new DevExpress.XtraEditors.SimpleButton();
            this.bt_close = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmerTypeName2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(831, 363);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(447, 271);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckGateOut);
            this.groupBox1.Controls.Add(this.ckGateIn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btNew);
            this.groupBox1.Controls.Add(this.btDel);
            this.groupBox1.Controls.Add(this.bt_close);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.txtEmerTypeName2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 108);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // ckGateOut
            // 
            this.ckGateOut.AutoSize = true;
            this.ckGateOut.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ckGateOut.Location = new System.Drawing.Point(236, 53);
            this.ckGateOut.Name = "ckGateOut";
            this.ckGateOut.Size = new System.Drawing.Size(75, 21);
            this.ckGateOut.TabIndex = 99;
            this.ckGateOut.Text = "ทางออก";
            this.ckGateOut.UseVisualStyleBackColor = true;
            // 
            // ckGateIn
            // 
            this.ckGateIn.AutoSize = true;
            this.ckGateIn.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ckGateIn.Location = new System.Drawing.Point(146, 53);
            this.ckGateIn.Name = "ckGateIn";
            this.ckGateIn.Size = new System.Drawing.Size(72, 21);
            this.ckGateIn.TabIndex = 98;
            this.ckGateIn.Text = "ทางเข้า";
            this.ckGateIn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 97;
            this.label1.Text = "นำไปใช้กับ:";
            // 
            // btNew
            // 
            this.btNew.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btNew.Appearance.Options.UseFont = true;
            this.btNew.Image = global::BackOffice.Properties.Resources.new_file_icon;
            this.btNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btNew.Location = new System.Drawing.Point(446, 18);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(70, 70);
            this.btNew.TabIndex = 94;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btDel
            // 
            this.btDel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btDel.Appearance.Options.UseFont = true;
            this.btDel.Image = global::BackOffice.Properties.Resources.bin323;
            this.btDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btDel.Location = new System.Drawing.Point(612, 18);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(70, 70);
            this.btDel.TabIndex = 95;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // bt_close
            // 
            this.bt_close.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_close.Appearance.Options.UseFont = true;
            this.bt_close.Image = global::BackOffice.Properties.Resources.Remove_32x32;
            this.bt_close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_close.Location = new System.Drawing.Point(733, 17);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(70, 70);
            this.bt_close.TabIndex = 96;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // btSave
            // 
            this.btSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btSave.Appearance.Options.UseFont = true;
            this.btSave.Image = global::BackOffice.Properties.Resources.Save_32x32;
            this.btSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btSave.Location = new System.Drawing.Point(524, 18);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(70, 70);
            this.btSave.TabIndex = 93;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // txtEmerTypeName2
            // 
            this.txtEmerTypeName2.BackColor = System.Drawing.Color.Khaki;
            this.txtEmerTypeName2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEmerTypeName2.Location = new System.Drawing.Point(146, 17);
            this.txtEmerTypeName2.Name = "txtEmerTypeName2";
            this.txtEmerTypeName2.Size = new System.Drawing.Size(273, 24);
            this.txtEmerTypeName2.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "เหตุผลยกไม้ฉุกเฉิน:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.richTextBox1);
            this.groupBox10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox10.Location = new System.Drawing.Point(859, 12);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(340, 477);
            this.groupBox10.TabIndex = 30;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "คำอธิบาย";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.richTextBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.richTextBox1.Location = new System.Drawing.Point(3, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(334, 454);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "\n\n\tข้อความมาตราฐานของเหตุผลการเปิดไม้ฉุกเฉิน";
            // 
            // fmEmergencyType
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 544);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Name = "fmEmergencyType";
            this.Text = "เหตุผลการยกไม้ฉุกเฉิน";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmerTypeName2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox10;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btNew;
        private DevExpress.XtraEditors.SimpleButton btDel;
        private DevExpress.XtraEditors.SimpleButton bt_close;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox ckGateOut;
        private System.Windows.Forms.CheckBox ckGateIn;
        private System.Windows.Forms.Label label1;
    }
}