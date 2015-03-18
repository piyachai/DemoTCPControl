namespace BackOffice
{
    partial class fmTicketAddGroup
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
            this.btAddTicket = new System.Windows.Forms.Button();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.txtTicketList = new System.Windows.Forms.ListBox();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbLastTicket = new System.Windows.Forms.Label();
            this.lbTicketNumber = new System.Windows.Forms.Label();
            this.lbExist = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rdTicketTypeFree = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdTicketTypeVisitor = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTicketCounter = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAddTicket
            // 
            this.btAddTicket.Image = global::BackOffice.Properties.Resources.plus32;
            this.btAddTicket.Location = new System.Drawing.Point(307, 3);
            this.btAddTicket.Name = "btAddTicket";
            this.btAddTicket.Size = new System.Drawing.Size(52, 35);
            this.btAddTicket.TabIndex = 0;
            this.btAddTicket.UseVisualStyleBackColor = true;
            this.btAddTicket.Click += new System.EventHandler(this.btAddTicket_Click);
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTicketNumber.Location = new System.Drawing.Point(100, 4);
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(201, 35);
            this.txtTicketNumber.TabIndex = 1;
            this.txtTicketNumber.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTicketNumber_PreviewKeyDown);
            // 
            // txtTicketList
            // 
            this.txtTicketList.FormattingEnabled = true;
            this.txtTicketList.Location = new System.Drawing.Point(100, 74);
            this.txtTicketList.Name = "txtTicketList";
            this.txtTicketList.Size = new System.Drawing.Size(249, 160);
            this.txtTicketList.TabIndex = 2;
            // 
            // btClose
            // 
            this.btClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btClose.Appearance.Options.UseFont = true;
            this.btClose.Image = global::BackOffice.Properties.Resources.Remove_32x32;
            this.btClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btClose.Location = new System.Drawing.Point(216, 346);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(69, 51);
            this.btClose.TabIndex = 123;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbLastTicket);
            this.flowLayoutPanel1.Controls.Add(this.lbTicketNumber);
            this.flowLayoutPanel1.Controls.Add(this.lbExist);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 25);
            this.flowLayoutPanel1.TabIndex = 122;
            // 
            // lbLastTicket
            // 
            this.lbLastTicket.AutoSize = true;
            this.lbLastTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbLastTicket.ForeColor = System.Drawing.Color.Blue;
            this.lbLastTicket.Location = new System.Drawing.Point(3, 0);
            this.lbLastTicket.Name = "lbLastTicket";
            this.lbLastTicket.Size = new System.Drawing.Size(95, 15);
            this.lbLastTicket.TabIndex = 121;
            this.lbLastTicket.Text = "หมายเลขบัตรล่าสุด";
            this.lbLastTicket.Visible = false;
            // 
            // lbTicketNumber
            // 
            this.lbTicketNumber.AutoSize = true;
            this.lbTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbTicketNumber.ForeColor = System.Drawing.Color.Blue;
            this.lbTicketNumber.Location = new System.Drawing.Point(104, 0);
            this.lbTicketNumber.Name = "lbTicketNumber";
            this.lbTicketNumber.Size = new System.Drawing.Size(28, 15);
            this.lbTicketNumber.TabIndex = 123;
            this.lbTicketNumber.Text = "000";
            this.lbTicketNumber.Visible = false;
            // 
            // lbExist
            // 
            this.lbExist.AutoSize = true;
            this.lbExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbExist.ForeColor = System.Drawing.Color.Red;
            this.lbExist.Location = new System.Drawing.Point(138, 0);
            this.lbExist.Name = "lbExist";
            this.lbExist.Size = new System.Drawing.Size(63, 15);
            this.lbExist.TabIndex = 122;
            this.lbExist.Text = "หมายเลขซ้ำ";
            this.lbExist.Visible = false;
            // 
            // btSave
            // 
            this.btSave.Image = global::BackOffice.Properties.Resources.Save_32x32;
            this.btSave.Location = new System.Drawing.Point(291, 346);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(68, 51);
            this.btSave.TabIndex = 120;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Tahoma", 10F);
            this.dtpEnd.CustomFormat = "ddMMMyy HH:mm";
            this.dtpEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(240, 310);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(116, 24);
            this.dtpEnd.TabIndex = 117;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(237, 293);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 14);
            this.label20.TabIndex = 116;
            this.label20.Text = "วันหมดอายุ";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CalendarFont = new System.Drawing.Font("Tahoma", 10F);
            this.dtpBegin.CustomFormat = "ddMMMyy HH:mm";
            this.dtpBegin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(101, 310);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(116, 24);
            this.dtpBegin.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(98, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 119;
            this.label4.Text = "วันเริ่ม";
            // 
            // rdTicketTypeFree
            // 
            this.rdTicketTypeFree.AutoSize = true;
            this.rdTicketTypeFree.BackColor = System.Drawing.Color.White;
            this.rdTicketTypeFree.Checked = true;
            this.rdTicketTypeFree.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.rdTicketTypeFree.Location = new System.Drawing.Point(3, 3);
            this.rdTicketTypeFree.Name = "rdTicketTypeFree";
            this.rdTicketTypeFree.Size = new System.Drawing.Size(63, 20);
            this.rdTicketTypeFree.TabIndex = 114;
            this.rdTicketTypeFree.TabStop = true;
            this.rdTicketTypeFree.Text = "บัตรฟรี";
            this.rdTicketTypeFree.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(98, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 113;
            this.label3.Text = "ชนิดบัตร";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "หมายเลขบัตร";
            // 
            // rdTicketTypeVisitor
            // 
            this.rdTicketTypeVisitor.AutoSize = true;
            this.rdTicketTypeVisitor.BackColor = System.Drawing.Color.White;
            this.rdTicketTypeVisitor.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.rdTicketTypeVisitor.Location = new System.Drawing.Point(72, 3);
            this.rdTicketTypeVisitor.Name = "rdTicketTypeVisitor";
            this.rdTicketTypeVisitor.Size = new System.Drawing.Size(62, 20);
            this.rdTicketTypeVisitor.TabIndex = 124;
            this.rdTicketTypeVisitor.Text = "Visitor";
            this.rdTicketTypeVisitor.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rdTicketTypeFree);
            this.flowLayoutPanel2.Controls.Add(this.rdTicketTypeVisitor);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(167, 266);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 24);
            this.flowLayoutPanel2.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(98, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 126;
            this.label2.Text = "จำนวนบัตร";
            // 
            // txtTicketCounter
            // 
            this.txtTicketCounter.AutoSize = true;
            this.txtTicketCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTicketCounter.ForeColor = System.Drawing.Color.Blue;
            this.txtTicketCounter.Location = new System.Drawing.Point(164, 235);
            this.txtTicketCounter.Name = "txtTicketCounter";
            this.txtTicketCounter.Size = new System.Drawing.Size(14, 15);
            this.txtTicketCounter.TabIndex = 127;
            this.txtTicketCounter.Text = "0";
            // 
            // fmTicketAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(387, 409);
            this.Controls.Add(this.txtTicketCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtTicketList);
            this.Controls.Add(this.dtpBegin);
            this.Controls.Add(this.btAddTicket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTicketNumber);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmTicketAddGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เพิ่มหมายเลขบัตร ... ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmTicketAddGroup_FormClosing);
            this.Shown += new System.EventHandler(this.fmTicketAddGroup_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddTicket;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.ListBox txtTicketList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdTicketTypeFree;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbLastTicket;
        private System.Windows.Forms.Label lbExist;
        private System.Windows.Forms.Label lbTicketNumber;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private System.Windows.Forms.RadioButton rdTicketTypeVisitor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTicketCounter;
    }
}