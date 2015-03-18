namespace DparkTerminal
{
    partial class fmCashierReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_find = new DevExpress.XtraEditors.SimpleButton();
            this.btPrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtChkInFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtChkInToDate = new System.Windows.Forms.DateTimePicker();
            this.dtChkInFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtChkInToTime = new System.Windows.Forms.DateTimePicker();
            this.bt_exit = new DevExpress.XtraEditors.SimpleButton();
            this.docView = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.docView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 479);
            this.tableLayoutPanel1.TabIndex = 130;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_find);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.bt_exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 94);
            this.panel1.TabIndex = 129;
            // 
            // bt_find
            // 
            this.bt_find.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_find.Appearance.Options.UseFont = true;
            this.bt_find.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_find.Image = global::DparkTerminal.Properties.Resources._1386862036_document_preview;
            this.bt_find.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_find.Location = new System.Drawing.Point(213, 9);
            this.bt_find.Name = "bt_find";
            this.bt_find.Size = new System.Drawing.Size(70, 70);
            this.bt_find.TabIndex = 131;
            this.bt_find.Click += new System.EventHandler(this.bt_find_Click);
            // 
            // btPrint
            // 
            this.btPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btPrint.Appearance.Options.UseFont = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrint.Image = global::DparkTerminal.Properties.Resources.Print_32x32;
            this.btPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btPrint.Location = new System.Drawing.Point(289, 9);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(70, 70);
            this.btPrint.TabIndex = 130;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtChkInFromDate);
            this.groupBox1.Controls.Add(this.dtChkInToDate);
            this.groupBox1.Controls.Add(this.dtChkInFromTime);
            this.groupBox1.Controls.Add(this.dtChkInToTime);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 87);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ช่วงเวลา";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 76;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = "To:";
            // 
            // dtChkInFromDate
            // 
            this.dtChkInFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtChkInFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInFromDate.Location = new System.Drawing.Point(38, 29);
            this.dtChkInFromDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtChkInFromDate.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtChkInFromDate.Name = "dtChkInFromDate";
            this.dtChkInFromDate.Size = new System.Drawing.Size(100, 21);
            this.dtChkInFromDate.TabIndex = 72;
            this.dtChkInFromDate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInFromDate_PreviewKeyDown);
            // 
            // dtChkInToDate
            // 
            this.dtChkInToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtChkInToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInToDate.Location = new System.Drawing.Point(38, 54);
            this.dtChkInToDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtChkInToDate.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtChkInToDate.Name = "dtChkInToDate";
            this.dtChkInToDate.Size = new System.Drawing.Size(100, 21);
            this.dtChkInToDate.TabIndex = 73;
            this.dtChkInToDate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInFromDate_PreviewKeyDown);
            // 
            // dtChkInFromTime
            // 
            this.dtChkInFromTime.CustomFormat = "HH:mm";
            this.dtChkInFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInFromTime.Location = new System.Drawing.Point(141, 29);
            this.dtChkInFromTime.Name = "dtChkInFromTime";
            this.dtChkInFromTime.ShowUpDown = true;
            this.dtChkInFromTime.Size = new System.Drawing.Size(56, 21);
            this.dtChkInFromTime.TabIndex = 75;
            this.dtChkInFromTime.Value = new System.DateTime(2011, 7, 17, 0, 1, 0, 0);
            this.dtChkInFromTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInFromDate_PreviewKeyDown);
            // 
            // dtChkInToTime
            // 
            this.dtChkInToTime.CustomFormat = "HH:mm";
            this.dtChkInToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChkInToTime.Location = new System.Drawing.Point(141, 54);
            this.dtChkInToTime.Name = "dtChkInToTime";
            this.dtChkInToTime.ShowUpDown = true;
            this.dtChkInToTime.Size = new System.Drawing.Size(56, 21);
            this.dtChkInToTime.TabIndex = 74;
            this.dtChkInToTime.Value = new System.DateTime(2011, 7, 17, 23, 59, 0, 0);
            this.dtChkInToTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtChkInFromDate_PreviewKeyDown);
            // 
            // bt_exit
            // 
            this.bt_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_exit.Appearance.Options.UseFont = true;
            this.bt_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_exit.Image = global::DparkTerminal.Properties.Resources.Remove_32x321;
            this.bt_exit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bt_exit.Location = new System.Drawing.Point(365, 9);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(70, 70);
            this.bt_exit.TabIndex = 128;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // docView
            // 
            this.docView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docView.IsMetric = true;
            this.docView.Location = new System.Drawing.Point(3, 103);
            this.docView.Name = "docView";
            this.docView.Size = new System.Drawing.Size(599, 373);
            this.docView.TabIndex = 130;
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.DocumentSource = typeof(BackOffice.reportCashierLogout);
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(3, 83);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(444, 247);
            this.documentViewer1.TabIndex = 129;
            // 
            // fmCashierReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(605, 479);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "fmCashierReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เลือกช่วงเวลา";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bt_exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer docView;
        private DevExpress.XtraEditors.SimpleButton btPrint;
        private DevExpress.XtraEditors.SimpleButton bt_find;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtChkInFromDate;
        private System.Windows.Forms.DateTimePicker dtChkInToDate;
        private System.Windows.Forms.DateTimePicker dtChkInFromTime;
        private System.Windows.Forms.DateTimePicker dtChkInToTime;

    }
}