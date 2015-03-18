namespace BackOffice
{
    partial class fmCheckAccountingAll
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpTranChkIn = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtChkInFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtChkInToDate = new System.Windows.Forms.DateTimePicker();
            this.dtChkInFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtChkInToTime = new System.Windows.Forms.DateTimePicker();
            this.gpCarPlateNumber = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bt_find = new System.Windows.Forms.Button();
            this.btPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btExit = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gpTranChkIn.SuspendLayout();
            this.gpCarPlateNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 356);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 124);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหาข้อมูล";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.gpTranChkIn);
            this.flowLayoutPanel2.Controls.Add(this.gpCarPlateNumber);
            this.flowLayoutPanel2.Controls.Add(this.bt_find);
            this.flowLayoutPanel2.Controls.Add(this.btPrint);
            this.flowLayoutPanel2.Controls.Add(this.btExcel);
            this.flowLayoutPanel2.Controls.Add(this.btExit);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 18);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(936, 100);
            this.flowLayoutPanel2.TabIndex = 79;
            // 
            // gpTranChkIn
            // 
            this.gpTranChkIn.Controls.Add(this.label3);
            this.gpTranChkIn.Controls.Add(this.label4);
            this.gpTranChkIn.Controls.Add(this.dtChkInFromDate);
            this.gpTranChkIn.Controls.Add(this.dtChkInToDate);
            this.gpTranChkIn.Controls.Add(this.dtChkInFromTime);
            this.gpTranChkIn.Controls.Add(this.dtChkInToTime);
            this.gpTranChkIn.Location = new System.Drawing.Point(3, 3);
            this.gpTranChkIn.Name = "gpTranChkIn";
            this.gpTranChkIn.Size = new System.Drawing.Size(201, 86);
            this.gpTranChkIn.TabIndex = 77;
            this.gpTranChkIn.TabStop = false;
            this.gpTranChkIn.Text = "ช่วงเวลาบันทึก";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "To:";
            // 
            // dtChkInFromDate
            // 
            this.dtChkInFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtChkInFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInFromDate.Location = new System.Drawing.Point(36, 17);
            this.dtChkInFromDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtChkInFromDate.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtChkInFromDate.Name = "dtChkInFromDate";
            this.dtChkInFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtChkInFromDate.TabIndex = 66;
            this.dtChkInFromDate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInToTime_PreviewKeyDown);
            // 
            // dtChkInToDate
            // 
            this.dtChkInToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtChkInToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInToDate.Location = new System.Drawing.Point(36, 42);
            this.dtChkInToDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtChkInToDate.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtChkInToDate.Name = "dtChkInToDate";
            this.dtChkInToDate.Size = new System.Drawing.Size(100, 20);
            this.dtChkInToDate.TabIndex = 67;
            this.dtChkInToDate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInToTime_PreviewKeyDown);
            // 
            // dtChkInFromTime
            // 
            this.dtChkInFromTime.CustomFormat = "HH:mm";
            this.dtChkInFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInFromTime.Location = new System.Drawing.Point(139, 17);
            this.dtChkInFromTime.Name = "dtChkInFromTime";
            this.dtChkInFromTime.ShowUpDown = true;
            this.dtChkInFromTime.Size = new System.Drawing.Size(56, 20);
            this.dtChkInFromTime.TabIndex = 69;
            this.dtChkInFromTime.Value = new System.DateTime(2011, 7, 17, 0, 1, 0, 0);
            this.dtChkInFromTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInToTime_PreviewKeyDown);
            // 
            // dtChkInToTime
            // 
            this.dtChkInToTime.CustomFormat = "HH:mm";
            this.dtChkInToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInToTime.Location = new System.Drawing.Point(139, 42);
            this.dtChkInToTime.Name = "dtChkInToTime";
            this.dtChkInToTime.ShowUpDown = true;
            this.dtChkInToTime.Size = new System.Drawing.Size(56, 20);
            this.dtChkInToTime.TabIndex = 68;
            this.dtChkInToTime.Value = new System.DateTime(2011, 7, 17, 23, 59, 0, 0);
            this.dtChkInToTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInToTime_PreviewKeyDown);
            // 
            // gpCarPlateNumber
            // 
            this.gpCarPlateNumber.Controls.Add(this.comboBox2);
            this.gpCarPlateNumber.Controls.Add(this.comboBox1);
            this.gpCarPlateNumber.Location = new System.Drawing.Point(210, 3);
            this.gpCarPlateNumber.Name = "gpCarPlateNumber";
            this.gpCarPlateNumber.Size = new System.Drawing.Size(163, 86);
            this.gpCarPlateNumber.TabIndex = 78;
            this.gpCarPlateNumber.TabStop = false;
            this.gpCarPlateNumber.Text = "เงื่อนไขค้นหา";
            this.gpCarPlateNumber.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(20, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // bt_find
            // 
            this.bt_find.Image = global::BackOffice.Properties.Resources.Search;
            this.bt_find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_find.Location = new System.Drawing.Point(379, 3);
            this.bt_find.Name = "bt_find";
            this.bt_find.Size = new System.Drawing.Size(74, 70);
            this.bt_find.TabIndex = 73;
            this.bt_find.Text = "Find";
            this.bt_find.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_find.UseVisualStyleBackColor = true;
            this.bt_find.Click += new System.EventHandler(this.bt_find_Click);
            // 
            // btPrint
            // 
            this.btPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btPrint.Appearance.Options.UseFont = true;
            this.btPrint.Image = global::BackOffice.Properties.Resources.Print_32x32;
            this.btPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btPrint.Location = new System.Drawing.Point(459, 3);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(70, 70);
            this.btPrint.TabIndex = 57;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btExcel
            // 
            this.btExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btExcel.Appearance.Options.UseFont = true;
            this.btExcel.Image = global::BackOffice.Properties.Resources.logo_excel_48_48;
            this.btExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btExcel.Location = new System.Drawing.Point(535, 3);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(68, 70);
            this.btExcel.TabIndex = 76;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btExit
            // 
            this.btExit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btExit.Appearance.Options.UseFont = true;
            this.btExit.Image = global::BackOffice.Properties.Resources.Remove_32x32;
            this.btExit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btExit.Location = new System.Drawing.Point(609, 3);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(68, 70);
            this.btExit.TabIndex = 35;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "transactionTypeID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 133);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(872, 220);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // fmCheckAccountingAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 356);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "fmCheckAccountingAll";
            this.Text = "ตรวจสอบข้อมูลการเงิน";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmCheckAccountingAll_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gpTranChkIn.ResumeLayout(false);
            this.gpTranChkIn.PerformLayout();
            this.gpCarPlateNumber.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox gpTranChkIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtChkInFromDate;
        private System.Windows.Forms.DateTimePicker dtChkInToDate;
        private System.Windows.Forms.DateTimePicker dtChkInFromTime;
        private System.Windows.Forms.DateTimePicker dtChkInToTime;
        private System.Windows.Forms.GroupBox gpCarPlateNumber;
        private System.Windows.Forms.Button bt_find;
        private DevExpress.XtraEditors.SimpleButton btPrint;
        private DevExpress.XtraEditors.SimpleButton btExcel;
        private DevExpress.XtraEditors.SimpleButton btExit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}