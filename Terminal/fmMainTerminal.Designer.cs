namespace DparkTerminal
{
    partial class fmMainTerminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMainTerminal));
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation1 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btSummitCar = new DevExpress.XtraBars.BarButtonItem();
            this.btShowTicketInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btClose = new DevExpress.XtraBars.BarButtonItem();
            this.btPrintReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.btHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btIOController = new DevExpress.XtraBars.BarButtonItem();
            this.btTerminalMode = new DevExpress.XtraBars.BarButtonItem();
            this.btSlipConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btCashierReport = new DevExpress.XtraBars.BarButtonItem();
            this.btShowAccounting = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettingPrice = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddSysUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettingIPDevice = new DevExpress.XtraBars.BarButtonItem();
            this.settingSystem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.settingpage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.btSetting = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSysUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.trayIconMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.ApplicationIcon = global::DparkTerminal.Properties.Resources.ticket_icon;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btSummitCar,
            this.btShowTicketInfo,
            this.btClose,
            this.btPrintReceipt,
            this.btHelp,
            this.btIOController,
            this.btTerminalMode,
            this.btSlipConfig,
            this.btCashierReport,
            this.btShowAccounting,
            this.btnHelp,
            this.btnSettingPrice,
            this.btnAddSysUser,
            this.btnSettingIPDevice,
            this.settingSystem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.settingpage});
            this.ribbonControl1.Size = new System.Drawing.Size(1008, 144);
            // 
            // btSummitCar
            // 
            this.btSummitCar.Caption = "รับรถเข้าออก [ F3 ]";
            this.btSummitCar.Id = 11;
            this.btSummitCar.LargeGlyph = global::DparkTerminal.Properties.Resources.barier_green;
            this.btSummitCar.Name = "btSummitCar";
            // 
            // btShowTicketInfo
            // 
            this.btShowTicketInfo.Caption = "แสดงข้อมูลในบัตร [ F6 ]";
            this.btShowTicketInfo.Id = 12;
            this.btShowTicketInfo.LargeGlyph = global::DparkTerminal.Properties.Resources.card22;
            this.btShowTicketInfo.Name = "btShowTicketInfo";
            // 
            // btClose
            // 
            this.btClose.Caption = "ออกจากระบบ [F8]";
            this.btClose.Id = 20;
            this.btClose.LargeGlyph = global::DparkTerminal.Properties.Resources.Close_32x32;
            this.btClose.Name = "btClose";
            this.btClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btClose_ItemClick);
            // 
            // btPrintReceipt
            // 
            this.btPrintReceipt.Caption = "พิมพ์ใบเสร็จรับเงินย้อนหลัง [F5]";
            this.btPrintReceipt.Id = 21;
            this.btPrintReceipt.LargeGlyph = global::DparkTerminal.Properties.Resources.Print_32x32;
            this.btPrintReceipt.Name = "btPrintReceipt";
            this.btPrintReceipt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btHelp
            // 
            this.btHelp.Caption = "ช่วยเหลือ [F7]";
            this.btHelp.Id = 22;
            this.btHelp.LargeGlyph = global::DparkTerminal.Properties.Resources.Help_32x32;
            this.btHelp.Name = "btHelp";
            this.btHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btIOController
            // 
            this.btIOController.Caption = "Controller";
            this.btIOController.Id = 25;
            this.btIOController.LargeGlyph = global::DparkTerminal.Properties.Resources._1313326142;
            this.btIOController.Name = "btIOController";
            // 
            // btTerminalMode
            // 
            this.btTerminalMode.Caption = "โหมดการทำงาน";
            this.btTerminalMode.Id = 29;
            this.btTerminalMode.LargeGlyph = global::DparkTerminal.Properties.Resources.CitiTechSystemsRoadwayFeaturesIcon;
            this.btTerminalMode.Name = "btTerminalMode";
            // 
            // btSlipConfig
            // 
            this.btSlipConfig.Caption = "สลิป";
            this.btSlipConfig.Glyph = ((System.Drawing.Image)(resources.GetObject("btSlipConfig.Glyph")));
            this.btSlipConfig.Id = 31;
            this.btSlipConfig.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btSlipConfig.LargeGlyph")));
            this.btSlipConfig.Name = "btSlipConfig";
            this.btSlipConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSlipConfig_ItemClick);
            // 
            // btCashierReport
            // 
            this.btCashierReport.Caption = "พิมพ์ใบปิดกะ";
            this.btCashierReport.Id = 37;
            this.btCashierReport.LargeGlyph = global::DparkTerminal.Properties.Resources.Print_32x32;
            this.btCashierReport.Name = "btCashierReport";
            this.btCashierReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btCashierReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btCashierReport_ItemClick);
            // 
            // btShowAccounting
            // 
            this.btShowAccounting.Caption = "รายงานยอดเงิน";
            this.btShowAccounting.Id = 41;
            this.btShowAccounting.LargeGlyph = global::DparkTerminal.Properties.Resources.calmoney;
            this.btShowAccounting.Name = "btShowAccounting";
            this.btShowAccounting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btShowAccounting_ItemClick);
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "ช่วยเหลือ";
            this.btnHelp.Id = 44;
            this.btnHelp.LargeGlyph = global::DparkTerminal.Properties.Resources._1403792617_Help;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHelp_ItemClick);
            // 
            // btnSettingPrice
            // 
            this.btnSettingPrice.Caption = "กำหนดราคาตั๋ว";
            this.btnSettingPrice.Id = 47;
            this.btnSettingPrice.LargeGlyph = global::DparkTerminal.Properties.Resources.Money1;
            this.btnSettingPrice.Name = "btnSettingPrice";
            this.btnSettingPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettingPrice_ItemClick);
            // 
            // btnAddSysUser
            // 
            this.btnAddSysUser.Caption = "จัดการผู้ใช้";
            this.btnAddSysUser.Id = 1;
            this.btnAddSysUser.LargeGlyph = global::DparkTerminal.Properties.Resources._54;
            this.btnAddSysUser.Name = "btnAddSysUser";
            this.btnAddSysUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddSysUser_ItemClick);
            // 
            // btnSettingIPDevice
            // 
            this.btnSettingIPDevice.Caption = "ตั้งค่าการเชื่อมต่อ";
            this.btnSettingIPDevice.Id = 2;
            this.btnSettingIPDevice.LargeGlyph = global::DparkTerminal.Properties.Resources._1404224235_network_transmit_receive;
            this.btnSettingIPDevice.Name = "btnSettingIPDevice";
            this.btnSettingIPDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettingIPDevice_ItemClick);
            // 
            // settingSystem
            // 
            this.settingSystem.Caption = "ตั้งค่าการพิมพ์ใบเสร็จ";
            this.settingSystem.Id = 3;
            this.settingSystem.LargeGlyph = global::DparkTerminal.Properties.Resources.Print_32x32;
            this.settingSystem.Name = "settingSystem";
            this.settingSystem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.settingSystem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.settingSystem_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup10});
            this.ribbonPage2.Name = "ribbonPage2";
            reduceOperation1.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation1.Group = null;
            reduceOperation1.ItemLinkIndex = 0;
            reduceOperation1.ItemLinksCount = 0;
            reduceOperation1.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.LargeButtons;
            this.ribbonPage2.ReduceOperations.Add(reduceOperation1);
            this.ribbonPage2.Text = "Home";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btCashierReport);
            this.ribbonPageGroup2.ItemLinks.Add(this.btShowAccounting);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "รายงานการปฏิบัติงาน";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btClose);
            this.ribbonPageGroup10.ItemLinks.Add(this.btnHelp);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "ระบบ";
            // 
            // settingpage
            // 
            this.settingpage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.btSetting,
            this.ribbonPageGroup3});
            this.settingpage.Name = "settingpage";
            this.settingpage.Text = "ตั้งค่า";
            // 
            // btSetting
            // 
            this.btSetting.ItemLinks.Add(this.btnSettingPrice);
            this.btSetting.ItemLinks.Add(this.btnSettingIPDevice);
            this.btSetting.ItemLinks.Add(this.settingSystem);
            this.btSetting.Name = "btSetting";
            this.btSetting.Text = "ตั้งค่าระบบ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnAddSysUser);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "จัดการผู้ใช้";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Application is still running";
            this.trayIcon.BalloonTipTitle = "DPARK Terminal";
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "DPARK Terminal";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_exit});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // ts_exit
            // 
            this.ts_exit.Name = "ts_exit";
            this.ts_exit.Size = new System.Drawing.Size(92, 22);
            this.ts_exit.Text = "Exit";
            this.ts_exit.Click += new System.EventHandler(this.ts_exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbSysUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 671);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 25);
            this.toolStripStatusLabel1.Text = "ชื่อผู้ใช้:  ";
            // 
            // lbSysUser
            // 
            this.lbSysUser.ActiveLinkColor = System.Drawing.Color.Red;
            this.lbSysUser.BackColor = System.Drawing.Color.Black;
            this.lbSysUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSysUser.ForeColor = System.Drawing.Color.Yellow;
            this.lbSysUser.Name = "lbSysUser";
            this.lbSysUser.Size = new System.Drawing.Size(0, 25);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSettingPrice);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ตั้งค่าระบบ";
            // 
            // fmMainTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "fmMainTerminal";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECash Cashier";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMainTerminal_FormClosing);
            this.Shown += new System.EventHandler(this.fmMainTerminal_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.trayIconMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btSummitCar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btShowTicketInfo;
        private DevExpress.XtraBars.BarButtonItem btClose;
        private DevExpress.XtraBars.BarButtonItem btPrintReceipt;
        private DevExpress.XtraBars.BarButtonItem btHelp;
        private DevExpress.XtraBars.BarButtonItem btIOController;
        private DevExpress.XtraBars.BarButtonItem btTerminalMode;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem ts_exit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btSlipConfig;
        private DevExpress.XtraBars.BarButtonItem btCashierReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPage settingpage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup btSetting;
        public System.Windows.Forms.ToolStripStatusLabel lbSysUser;
        private DevExpress.XtraBars.BarButtonItem btShowAccounting;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnSettingPrice;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnAddSysUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnSettingIPDevice;
        private DevExpress.XtraBars.BarButtonItem settingSystem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}