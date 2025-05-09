namespace PresentationLayer.Applications.ReplacementForDamagedOrLostLicense
{
    partial class frmReplacementForDamagedOrLostLicenses
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
            gbReplacementFor = new GroupBox();
            rbLostLicense = new RadioButton();
            rbDamagedLicense = new RadioButton();
            lblTitle = new Label();
            llShowNewLicenseInfo = new LinkLabel();
            llShowLicenseHistory = new LinkLabel();
            gpApplicationInfo = new GroupBox();
            pictureBox8 = new PictureBox();
            lblOldLicenseID = new Label();
            label12 = new Label();
            pictureBox7 = new PictureBox();
            lblReplaceLicenseID = new Label();
            label10 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblCreatedByUser = new Label();
            lblApplicationFees = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            lblApplicationDate = new Label();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            lblApplicationID = new Label();
            label4 = new Label();
            btnClose = new Button();
            ctrlDriverLicenseInfoWithFilter1 = new Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter();
            btnIssueReplacement = new Button();
            gbReplacementFor.SuspendLayout();
            gpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // gbReplacementFor
            // 
            gbReplacementFor.Controls.Add(rbLostLicense);
            gbReplacementFor.Controls.Add(rbDamagedLicense);
            gbReplacementFor.Location = new Point(749, 44);
            gbReplacementFor.Margin = new Padding(4, 3, 4, 3);
            gbReplacementFor.Name = "gbReplacementFor";
            gbReplacementFor.Padding = new Padding(4, 3, 4, 3);
            gbReplacementFor.Size = new Size(276, 108);
            gbReplacementFor.TabIndex = 198;
            gbReplacementFor.TabStop = false;
            gbReplacementFor.Text = "Repalcement For:";
            // 
            // rbLostLicense
            // 
            rbLostLicense.AutoSize = true;
            rbLostLicense.Location = new Point(10, 63);
            rbLostLicense.Margin = new Padding(4, 3, 4, 3);
            rbLostLicense.Name = "rbLostLicense";
            rbLostLicense.Size = new Size(175, 19);
            rbLostLicense.TabIndex = 1;
            rbLostLicense.Text = "ReplacementForLost License";
            rbLostLicense.UseVisualStyleBackColor = true;
            rbLostLicense.CheckedChanged += rbLostLicense_CheckedChanged;
            // 
            // rbDamagedLicense
            // 
            rbDamagedLicense.AutoSize = true;
            rbDamagedLicense.Location = new Point(9, 31);
            rbDamagedLicense.Margin = new Padding(4, 3, 4, 3);
            rbDamagedLicense.Name = "rbDamagedLicense";
            rbDamagedLicense.Size = new Size(204, 19);
            rbDamagedLicense.TabIndex = 0;
            rbDamagedLicense.Text = "ReplacementForDamaged License";
            rbDamagedLicense.UseVisualStyleBackColor = true;
            rbDamagedLicense.CheckedChanged += rbDamagedLicense_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1021, 45);
            lblTitle.TabIndex = 192;
            lblTitle.Text = "License Replacement";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // llShowNewLicenseInfo
            // 
            llShowNewLicenseInfo.AutoSize = true;
            llShowNewLicenseInfo.Enabled = false;
            llShowNewLicenseInfo.Location = new Point(336, 740);
            llShowNewLicenseInfo.Margin = new Padding(4, 0, 4, 0);
            llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            llShowNewLicenseInfo.Size = new Size(134, 15);
            llShowNewLicenseInfo.TabIndex = 197;
            llShowNewLicenseInfo.TabStop = true;
            llShowNewLicenseInfo.Text = "Show New Licenses Info";
            llShowNewLicenseInfo.LinkClicked += llShowLicenseInfo_LinkClicked;
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Location = new Point(122, 740);
            llShowLicenseHistory.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(124, 15);
            llShowLicenseHistory.TabIndex = 196;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show Licenses History";
            llShowLicenseHistory.LinkClicked += llShowLicenseHistory_LinkClicked;
            // 
            // gpApplicationInfo
            // 
            gpApplicationInfo.Controls.Add(pictureBox8);
            gpApplicationInfo.Controls.Add(lblOldLicenseID);
            gpApplicationInfo.Controls.Add(label12);
            gpApplicationInfo.Controls.Add(pictureBox7);
            gpApplicationInfo.Controls.Add(lblReplaceLicenseID);
            gpApplicationInfo.Controls.Add(label10);
            gpApplicationInfo.Controls.Add(pictureBox2);
            gpApplicationInfo.Controls.Add(pictureBox1);
            gpApplicationInfo.Controls.Add(label1);
            gpApplicationInfo.Controls.Add(lblCreatedByUser);
            gpApplicationInfo.Controls.Add(lblApplicationFees);
            gpApplicationInfo.Controls.Add(label2);
            gpApplicationInfo.Controls.Add(pictureBox3);
            gpApplicationInfo.Controls.Add(lblApplicationDate);
            gpApplicationInfo.Controls.Add(pictureBox4);
            gpApplicationInfo.Controls.Add(label5);
            gpApplicationInfo.Controls.Add(lblApplicationID);
            gpApplicationInfo.Controls.Add(label4);
            gpApplicationInfo.Location = new Point(34, 560);
            gpApplicationInfo.Margin = new Padding(4, 3, 4, 3);
            gpApplicationInfo.Name = "gpApplicationInfo";
            gpApplicationInfo.Padding = new Padding(4, 3, 4, 3);
            gpApplicationInfo.Size = new Size(992, 164);
            gpApplicationInfo.TabIndex = 193;
            gpApplicationInfo.TabStop = false;
            gpApplicationInfo.Text = "BaseApplication Info for License Replacement";
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(681, 81);
            pictureBox8.Margin = new Padding(4, 3, 4, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(36, 30);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 195;
            pictureBox8.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            lblOldLicenseID.AutoSize = true;
            lblOldLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOldLicenseID.Location = new Point(726, 81);
            lblOldLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblOldLicenseID.Name = "lblOldLicenseID";
            lblOldLicenseID.Size = new Size(49, 20);
            lblOldLicenseID.TabIndex = 194;
            lblOldLicenseID.Text = "[???]";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(465, 81);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(132, 20);
            label12.TabIndex = 193;
            label12.Text = "Old License ID:";
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(681, 44);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(36, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 192;
            pictureBox7.TabStop = false;
            // 
            // lblReplaceLicenseID
            // 
            lblReplaceLicenseID.AutoSize = true;
            lblReplaceLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReplaceLicenseID.Location = new Point(726, 44);
            lblReplaceLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblReplaceLicenseID.Name = "lblReplaceLicenseID";
            lblReplaceLicenseID.Size = new Size(49, 20);
            lblReplaceLicenseID.TabIndex = 191;
            lblReplaceLicenseID.Text = "[???]";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(465, 44);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(171, 20);
            label10.TabIndex = 190;
            label10.Text = "Replace License ID:";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(194, 44);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 183;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(681, 118);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 182;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(465, 118);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 181;
            label1.Text = "Created By:";
            // 
            // lblCreatedByUser
            // 
            lblCreatedByUser.AutoSize = true;
            lblCreatedByUser.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedByUser.Location = new Point(726, 118);
            lblCreatedByUser.Margin = new Padding(5, 0, 5, 0);
            lblCreatedByUser.Name = "lblCreatedByUser";
            lblCreatedByUser.Size = new Size(59, 20);
            lblCreatedByUser.TabIndex = 180;
            lblCreatedByUser.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            lblApplicationFees.AutoSize = true;
            lblApplicationFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationFees.Location = new Point(238, 118);
            lblApplicationFees.Margin = new Padding(5, 0, 5, 0);
            lblApplicationFees.Name = "lblApplicationFees";
            lblApplicationFees.Size = new Size(49, 20);
            lblApplicationFees.TabIndex = 179;
            lblApplicationFees.Text = "[$$$]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 118);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 177;
            label2.Text = "Application Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(194, 118);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 178;
            pictureBox3.TabStop = false;
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.AutoSize = true;
            lblApplicationDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationDate.Location = new Point(238, 81);
            lblApplicationDate.Margin = new Padding(5, 0, 5, 0);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(109, 20);
            lblApplicationDate.TabIndex = 176;
            lblApplicationDate.Text = "[??/??/????]";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(194, 81);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(36, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 175;
            pictureBox4.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 81);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 174;
            label5.Text = "Application Date:";
            // 
            // lblApplicationID
            // 
            lblApplicationID.AutoSize = true;
            lblApplicationID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationID.Location = new Point(238, 44);
            lblApplicationID.Margin = new Padding(5, 0, 5, 0);
            lblApplicationID.Name = "lblApplicationID";
            lblApplicationID.Size = new Size(49, 20);
            lblApplicationID.TabIndex = 173;
            lblApplicationID.Text = "[???]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 44);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 172;
            label4.Text = "Application ID:";
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(645, 730);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 194;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            ctrlDriverLicenseInfoWithFilter1.BackColor = Color.White;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            ctrlDriverLicenseInfoWithFilter1.Location = new Point(23, 59);
            ctrlDriverLicenseInfoWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            ctrlDriverLicenseInfoWithFilter1.Size = new Size(1011, 481);
            ctrlDriverLicenseInfoWithFilter1.TabIndex = 199;
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // btnIssueReplacement
            // 
            btnIssueReplacement.Enabled = false;
            btnIssueReplacement.FlatStyle = FlatStyle.Flat;
            btnIssueReplacement.Image = Properties.Resources.IssueDrivingLicense_322;
            btnIssueReplacement.ImageAlign = ContentAlignment.MiddleLeft;
            btnIssueReplacement.Location = new Point(800, 730);
            btnIssueReplacement.Margin = new Padding(4, 3, 4, 3);
            btnIssueReplacement.Name = "btnIssueReplacement";
            btnIssueReplacement.Size = new Size(225, 43);
            btnIssueReplacement.TabIndex = 195;
            btnIssueReplacement.Text = "Issue Replacement";
            btnIssueReplacement.TextAlign = ContentAlignment.MiddleRight;
            btnIssueReplacement.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIssueReplacement.UseVisualStyleBackColor = true;
            btnIssueReplacement.Click += btnIssueReplacement_Click;
            // 
            // frmReplacementForDamagedOrLostLicenses
            // 
            AcceptButton = btnIssueReplacement;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1057, 785);
            Controls.Add(gbReplacementFor);
            Controls.Add(ctrlDriverLicenseInfoWithFilter1);
            Controls.Add(lblTitle);
            Controls.Add(llShowNewLicenseInfo);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(btnIssueReplacement);
            Controls.Add(gpApplicationInfo);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmReplacementForDamagedOrLostLicenses";
            Text = "frmReplacementForDamagedOrLostLicenses";
            Load += frmReplacementForDamagedOrLostLicenses_Load;
            gbReplacementFor.ResumeLayout(false);
            gbReplacementFor.PerformLayout();
            gpApplicationInfo.ResumeLayout(false);
            gpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblReplaceLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}