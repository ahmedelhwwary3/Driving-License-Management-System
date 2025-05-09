namespace PresentationLayer.Applications.InternationalLicenseApplication
{
    partial class frmIssueInternationalLicense
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
            llShowLicenseInfo = new LinkLabel();
            llShowLicenseHistory = new LinkLabel();
            btnIssueLicense = new Button();
            btnClose = new Button();
            gbApplicationInfo = new GroupBox();
            pictureBox8 = new PictureBox();
            lblLocalLicenseID = new Label();
            label12 = new Label();
            pictureBox7 = new PictureBox();
            lblInternationalLicenseID = new Label();
            label10 = new Label();
            lblExpirationDate = new Label();
            pictureBox6 = new PictureBox();
            label8 = new Label();
            lblIssueDate = new Label();
            pictureBox5 = new PictureBox();
            label6 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblCreatedByUser = new Label();
            lblFees = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            lblApplicationDate = new Label();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            lblApplicationID = new Label();
            label4 = new Label();
            lblTitle = new Label();
            ctrlDriverLicenseInfoWithFilter1 = new Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter();
            gbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // llShowLicenseInfo
            // 
            llShowLicenseInfo.AutoSize = true;
            llShowLicenseInfo.Enabled = false;
            llShowLicenseInfo.Location = new Point(251, 796);
            llShowLicenseInfo.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseInfo.Name = "llShowLicenseInfo";
            llShowLicenseInfo.Size = new Size(107, 15);
            llShowLicenseInfo.TabIndex = 183;
            llShowLicenseInfo.TabStop = true;
            llShowLicenseInfo.Text = "Show Licenses Info";
            llShowLicenseInfo.LinkClicked += llShowLicenseInfo_LinkClicked;
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Location = new Point(37, 796);
            llShowLicenseHistory.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(124, 15);
            llShowLicenseHistory.TabIndex = 182;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show Licenses History";
            llShowLicenseHistory.LinkClicked += llShowLicenseHistory_LinkClicked;
            // 
            // btnIssueLicense
            // 
            btnIssueLicense.Enabled = false;
            btnIssueLicense.FlatStyle = FlatStyle.Flat;
            btnIssueLicense.Image = Properties.Resources.IssueDrivingLicense_32;
            btnIssueLicense.ImageAlign = ContentAlignment.MiddleLeft;
            btnIssueLicense.Location = new Point(876, 796);
            btnIssueLicense.Margin = new Padding(4, 3, 4, 3);
            btnIssueLicense.Name = "btnIssueLicense";
            btnIssueLicense.Size = new Size(147, 43);
            btnIssueLicense.TabIndex = 181;
            btnIssueLicense.Text = "Issue";
            btnIssueLicense.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIssueLicense.UseVisualStyleBackColor = true;
            btnIssueLicense.Click += btnIssueLicense_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(720, 796);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 180;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // gbApplicationInfo
            // 
            gbApplicationInfo.Controls.Add(pictureBox8);
            gbApplicationInfo.Controls.Add(lblLocalLicenseID);
            gbApplicationInfo.Controls.Add(label12);
            gbApplicationInfo.Controls.Add(pictureBox7);
            gbApplicationInfo.Controls.Add(lblInternationalLicenseID);
            gbApplicationInfo.Controls.Add(label10);
            gbApplicationInfo.Controls.Add(lblExpirationDate);
            gbApplicationInfo.Controls.Add(pictureBox6);
            gbApplicationInfo.Controls.Add(label8);
            gbApplicationInfo.Controls.Add(lblIssueDate);
            gbApplicationInfo.Controls.Add(pictureBox5);
            gbApplicationInfo.Controls.Add(label6);
            gbApplicationInfo.Controls.Add(pictureBox2);
            gbApplicationInfo.Controls.Add(pictureBox1);
            gbApplicationInfo.Controls.Add(label1);
            gbApplicationInfo.Controls.Add(lblCreatedByUser);
            gbApplicationInfo.Controls.Add(lblFees);
            gbApplicationInfo.Controls.Add(label2);
            gbApplicationInfo.Controls.Add(pictureBox3);
            gbApplicationInfo.Controls.Add(lblApplicationDate);
            gbApplicationInfo.Controls.Add(pictureBox4);
            gbApplicationInfo.Controls.Add(label5);
            gbApplicationInfo.Controls.Add(lblApplicationID);
            gbApplicationInfo.Controls.Add(label4);
            gbApplicationInfo.Location = new Point(37, 575);
            gbApplicationInfo.Margin = new Padding(4, 3, 4, 3);
            gbApplicationInfo.Name = "gbApplicationInfo";
            gbApplicationInfo.Padding = new Padding(4, 3, 4, 3);
            gbApplicationInfo.Size = new Size(986, 212);
            gbApplicationInfo.TabIndex = 179;
            gbApplicationInfo.TabStop = false;
            gbApplicationInfo.Text = "New International Application Info";
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(678, 83);
            pictureBox8.Margin = new Padding(4, 3, 4, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(36, 30);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 195;
            pictureBox8.TabStop = false;
            // 
            // lblLocalLicenseID
            // 
            lblLocalLicenseID.AutoSize = true;
            lblLocalLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocalLicenseID.Location = new Point(722, 83);
            lblLocalLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblLocalLicenseID.Name = "lblLocalLicenseID";
            lblLocalLicenseID.Size = new Size(49, 20);
            lblLocalLicenseID.TabIndex = 194;
            lblLocalLicenseID.Text = "[???]";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(478, 83);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(148, 20);
            label12.TabIndex = 193;
            label12.Text = "Local License ID:";
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(678, 46);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(36, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 192;
            pictureBox7.TabStop = false;
            // 
            // lblInternationalLicenseID
            // 
            lblInternationalLicenseID.AutoSize = true;
            lblInternationalLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInternationalLicenseID.Location = new Point(722, 46);
            lblInternationalLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblInternationalLicenseID.Name = "lblInternationalLicenseID";
            lblInternationalLicenseID.Size = new Size(49, 20);
            lblInternationalLicenseID.TabIndex = 191;
            lblInternationalLicenseID.Text = "[???]";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(478, 46);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 20);
            label10.TabIndex = 190;
            label10.Text = "License ID:";
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpirationDate.Location = new Point(722, 120);
            lblExpirationDate.Margin = new Padding(5, 0, 5, 0);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(109, 20);
            lblExpirationDate.TabIndex = 189;
            lblExpirationDate.Text = "[??/??/????]";
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(678, 120);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(36, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 188;
            pictureBox6.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(478, 120);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(138, 20);
            label8.TabIndex = 187;
            label8.Text = "Expiration Date:";
            // 
            // lblIssueDate
            // 
            lblIssueDate.AutoSize = true;
            lblIssueDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueDate.Location = new Point(262, 120);
            lblIssueDate.Margin = new Padding(5, 0, 5, 0);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(109, 20);
            lblIssueDate.TabIndex = 186;
            lblIssueDate.Text = "[??/??/????]";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(217, 120);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(36, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 185;
            pictureBox5.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 120);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 184;
            label6.Text = "Issue Date:";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(218, 46);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 183;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(678, 157);
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
            label1.Location = new Point(478, 157);
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
            lblCreatedByUser.Location = new Point(722, 157);
            lblCreatedByUser.Margin = new Padding(5, 0, 5, 0);
            lblCreatedByUser.Name = "lblCreatedByUser";
            lblCreatedByUser.Size = new Size(59, 20);
            lblCreatedByUser.TabIndex = 180;
            lblCreatedByUser.Text = "[????]";
            // 
            // lblFees
            // 
            lblFees.AutoSize = true;
            lblFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFees.Location = new Point(262, 157);
            lblFees.Margin = new Padding(5, 0, 5, 0);
            lblFees.Name = "lblFees";
            lblFees.Size = new Size(49, 20);
            lblFees.TabIndex = 179;
            lblFees.Text = "[$$$]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 157);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 177;
            label2.Text = "Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(218, 157);
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
            lblApplicationDate.Location = new Point(262, 83);
            lblApplicationDate.Margin = new Padding(5, 0, 5, 0);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(109, 20);
            lblApplicationDate.TabIndex = 176;
            lblApplicationDate.Text = "[??/??/????]";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(218, 83);
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
            label5.Location = new Point(19, 83);
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
            lblApplicationID.Location = new Point(262, 46);
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
            label4.Location = new Point(19, 46);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 172;
            label4.Text = "Application ID:";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1021, 45);
            lblTitle.TabIndex = 178;
            lblTitle.Text = "Issue International License";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            ctrlDriverLicenseInfoWithFilter1.BackColor = Color.White;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            ctrlDriverLicenseInfoWithFilter1.Location = new Point(27, 81);
            ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            ctrlDriverLicenseInfoWithFilter1.Size = new Size(1009, 469);
            ctrlDriverLicenseInfoWithFilter1.TabIndex = 184;
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // frmIssueInternationalLicense
            // 
            AcceptButton = btnIssueLicense;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1071, 852);
            Controls.Add(ctrlDriverLicenseInfoWithFilter1);
            Controls.Add(llShowLicenseInfo);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(btnIssueLicense);
            Controls.Add(btnClose);
            Controls.Add(gbApplicationInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmIssueInternationalLicense";
            Text = "frmIssueInternationalLicense";
            Load += frmIssueInternationalLicense_Load;
            gbApplicationInfo.ResumeLayout(false);
            gbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblLocalLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblInternationalLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitle;
        private Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}