namespace DparkTerminal
{
    partial class fmEmergencyOpenBarier
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbTranID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lyQuickComment = new System.Windows.Forms.FlowLayoutPanel();
            this.btCM1 = new System.Windows.Forms.Button();
            this.btCM6 = new System.Windows.Forms.Button();
            this.btCM5 = new System.Windows.Forms.Button();
            this.btCM2 = new System.Windows.Forms.Button();
            this.btCM3 = new System.Windows.Forms.Button();
            this.btCM4 = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.lyQuickComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbTranID);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.lyQuickComment);
            this.groupBox4.Controls.Add(this.btSave);
            this.groupBox4.Controls.Add(this.lbName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtComment);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(630, 275);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // lbTranID
            // 
            this.lbTranID.AutoSize = true;
            this.lbTranID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbTranID.ForeColor = System.Drawing.Color.Gray;
            this.lbTranID.Location = new System.Drawing.Point(149, 43);
            this.lbTranID.Name = "lbTranID";
            this.lbTranID.Size = new System.Drawing.Size(42, 17);
            this.lbTranID.TabIndex = 13;
            this.lbTranID.Text = "[trID]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Transaction ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DparkTerminal.Properties.Resources.Alert_Icon_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lyQuickComment
            // 
            this.lyQuickComment.Controls.Add(this.btCM1);
            this.lyQuickComment.Controls.Add(this.btCM6);
            this.lyQuickComment.Controls.Add(this.btCM5);
            this.lyQuickComment.Controls.Add(this.btCM2);
            this.lyQuickComment.Controls.Add(this.btCM3);
            this.lyQuickComment.Controls.Add(this.btCM4);
            this.lyQuickComment.Location = new System.Drawing.Point(428, 34);
            this.lyQuickComment.Name = "lyQuickComment";
            this.lyQuickComment.Size = new System.Drawing.Size(183, 235);
            this.lyQuickComment.TabIndex = 10;
            this.lyQuickComment.Visible = false;
            // 
            // btCM1
            // 
            this.btCM1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM1.ForeColor = System.Drawing.Color.Red;
            this.btCM1.Location = new System.Drawing.Point(3, 3);
            this.btCM1.Name = "btCM1";
            this.btCM1.Size = new System.Drawing.Size(170, 28);
            this.btCM1.TabIndex = 0;
            this.btCM1.Text = "เหตุการณ์ฉุกเฉิน";
            this.btCM1.UseVisualStyleBackColor = true;
            this.btCM1.Visible = false;
            this.btCM1.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btCM6
            // 
            this.btCM6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM6.ForeColor = System.Drawing.Color.Red;
            this.btCM6.Location = new System.Drawing.Point(3, 37);
            this.btCM6.Name = "btCM6";
            this.btCM6.Size = new System.Drawing.Size(170, 28);
            this.btCM6.TabIndex = 5;
            this.btCM6.Text = "พนักงานทั่วไป";
            this.btCM6.UseVisualStyleBackColor = true;
            this.btCM6.Visible = false;
            this.btCM6.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btCM5
            // 
            this.btCM5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM5.ForeColor = System.Drawing.Color.Red;
            this.btCM5.Location = new System.Drawing.Point(3, 71);
            this.btCM5.Name = "btCM5";
            this.btCM5.Size = new System.Drawing.Size(170, 28);
            this.btCM5.TabIndex = 4;
            this.btCM5.Text = "แม่บ้าน";
            this.btCM5.UseVisualStyleBackColor = true;
            this.btCM5.Visible = false;
            this.btCM5.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btCM2
            // 
            this.btCM2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM2.ForeColor = System.Drawing.Color.Red;
            this.btCM2.Location = new System.Drawing.Point(3, 105);
            this.btCM2.Name = "btCM2";
            this.btCM2.Size = new System.Drawing.Size(170, 28);
            this.btCM2.TabIndex = 1;
            this.btCM2.Text = "ซ่อมบำรุง";
            this.btCM2.UseVisualStyleBackColor = true;
            this.btCM2.Visible = false;
            this.btCM2.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btCM3
            // 
            this.btCM3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM3.ForeColor = System.Drawing.Color.Red;
            this.btCM3.Location = new System.Drawing.Point(3, 139);
            this.btCM3.Name = "btCM3";
            this.btCM3.Size = new System.Drawing.Size(170, 28);
            this.btCM3.TabIndex = 2;
            this.btCM3.Text = "ลูกค้าไม่จ่ายเงิน";
            this.btCM3.UseVisualStyleBackColor = true;
            this.btCM3.Visible = false;
            this.btCM3.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btCM4
            // 
            this.btCM4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btCM4.ForeColor = System.Drawing.Color.Red;
            this.btCM4.Location = new System.Drawing.Point(3, 173);
            this.btCM4.Name = "btCM4";
            this.btCM4.Size = new System.Drawing.Size(170, 28);
            this.btCM4.TabIndex = 3;
            this.btCM4.Text = "ลูกค้าไม่ยอมคืนบัตร";
            this.btCM4.UseVisualStyleBackColor = true;
            this.btCM4.Visible = false;
            this.btCM4.Click += new System.EventHandler(this.btComment_Click);
            // 
            // btSave
            // 
            this.btSave.Image = global::DparkTerminal.Properties.Resources.Save_32x321;
            this.btSave.Location = new System.Drawing.Point(334, 205);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 64);
            this.btSave.TabIndex = 9;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbName.ForeColor = System.Drawing.Color.Gray;
            this.lbName.Location = new System.Drawing.Point(149, 18);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(52, 17);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "[name]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "พนักงานผู้ดำเนินการ :";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtComment.Location = new System.Drawing.Point(115, 91);
            this.txtComment.MaxLength = 15;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(294, 108);
            this.txtComment.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(7, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "เหตุผล:";
            // 
            // fmEmergencyOpenBarier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 299);
            this.Controls.Add(this.groupBox4);
            this.Name = "fmEmergencyOpenBarier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ฟังก์ชั่น : การยกไม่กั้นรถในกรณีฉุกเฉิน";
            this.Shown += new System.EventHandler(this.frmxEmergencyOpenBarier_Shown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.lyQuickComment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel lyQuickComment;
        private System.Windows.Forms.Button btCM1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCM2;
        private System.Windows.Forms.Label lbTranID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCM5;
        private System.Windows.Forms.Button btCM6;
        private System.Windows.Forms.Button btCM3;
        private System.Windows.Forms.Button btCM4;
    }
}