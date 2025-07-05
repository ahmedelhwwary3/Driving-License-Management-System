namespace PresentationLayer.Applications.ReleaseDetainedLicense
{
    partial class frmReleaseDetainedLicense
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
            btnClose = new Button();
            btnRelease = new Button();
            lblTitle = new Label();
            llShowLicenseHistory = new LinkLabel();
            llShowLicenseInfo = new LinkLabel();
            gbDetain = new GroupBox();
            pictureBox7 = new PictureBox();
            lblApplicationID = new Label();
            lblTotalFees = new Label();
            label8 = new Label();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            lblApplicationFees = new Label();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            lblFineFees = new Label();
            pictureBox8 = new PictureBox();
            lblLicenseID = new Label();
            label10 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblCreatedByUser = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            lblDetainDate = new Label();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            lblDetainID = new Label();
            label4 = new Label();
            ctrlDriverLicenseInfoWithFilter1 = new Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter();
            gbDetain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(726, 813);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 194;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRelease
            // 
            btnRelease.Enabled = false;
            btnRelease.FlatStyle = FlatStyle.Flat;
            btnRelease.Image = Properties.Resources.Release_Detained_License_32;
            btnRelease.ImageAlign = ContentAlignment.MiddleLeft;
            btnRelease.Location = new Point(882, 813);
            btnRelease.Margin = new Padding(4, 3, 4, 3);
            btnRelease.Name = "btnRelease";
            btnRelease.Size = new Size(147, 43);
            btnRelease.TabIndex = 195;
            btnRelease.Text = "Release";
            btnRelease.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRelease.UseVisualStyleBackColor = true;
            btnRelease.Click += btnRelease_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1015, 45);
            lblTitle.TabIndex = 192;
            lblTitle.Tag = "MainTitle";
            lblTitle.Text = "Release Detained License";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Location = new Point(37, 816);
            llShowLicenseHistory.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(124, 15);
            llShowLicenseHistory.TabIndex = 196;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show Licenses History";
            llShowLicenseHistory.LinkClicked += llShowLicenseHistory_LinkClicked;
            // 
            // llShowLicenseInfo
            // 
            llShowLicenseInfo.AutoSize = true;
            llShowLicenseInfo.Enabled = false;
            llShowLicenseInfo.Location = new Point(251, 816);
            llShowLicenseInfo.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseInfo.Name = "llShowLicenseInfo";
            llShowLicenseInfo.Size = new Size(107, 15);
            llShowLicenseInfo.TabIndex = 197;
            llShowLicenseInfo.TabStop = true;
            llShowLicenseInfo.Text = "Show Licenses Info";
            llShowLicenseInfo.LinkClicked += llShowLicenseInfo_LinkClicked;
            // 
            // gbDetain
            // 
            gbDetain.Controls.Add(pictureBox7);
            gbDetain.Controls.Add(lblApplicationID);
            gbDetain.Controls.Add(lblTotalFees);
            gbDetain.Controls.Add(label8);
            gbDetain.Controls.Add(label7);
            gbDetain.Controls.Add(pictureBox6);
            gbDetain.Controls.Add(lblApplicationFees);
            gbDetain.Controls.Add(label6);
            gbDetain.Controls.Add(pictureBox5);
            gbDetain.Controls.Add(lblFineFees);
            gbDetain.Controls.Add(pictureBox8);
            gbDetain.Controls.Add(lblLicenseID);
            gbDetain.Controls.Add(label10);
            gbDetain.Controls.Add(pictureBox2);
            gbDetain.Controls.Add(pictureBox1);
            gbDetain.Controls.Add(label1);
            gbDetain.Controls.Add(lblCreatedByUser);
            gbDetain.Controls.Add(label2);
            gbDetain.Controls.Add(pictureBox3);
            gbDetain.Controls.Add(lblDetainDate);
            gbDetain.Controls.Add(pictureBox4);
            gbDetain.Controls.Add(label5);
            gbDetain.Controls.Add(lblDetainID);
            gbDetain.Controls.Add(label4);
            gbDetain.Location = new Point(37, 594);
            gbDetain.Margin = new Padding(4, 3, 4, 3);
            gbDetain.Name = "gbDetain";
            gbDetain.Padding = new Padding(4, 3, 4, 3);
            gbDetain.Size = new Size(992, 212);
            gbDetain.TabIndex = 193;
            gbDetain.TabStop = false;
            gbDetain.Text = "Detain Info";
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(678, 149);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(36, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 203;
            pictureBox7.TabStop = false;
            // 
            // lblApplicationID
            // 
            lblApplicationID.AutoSize = true;
            lblApplicationID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationID.Location = new Point(722, 149);
            lblApplicationID.Margin = new Padding(5, 0, 5, 0);
            lblApplicationID.Name = "lblApplicationID";
            lblApplicationID.Size = new Size(59, 20);
            lblApplicationID.TabIndex = 202;
            lblApplicationID.Text = "[????]";
            // 
            // lblTotalFees
            // 
            lblTotalFees.AutoSize = true;
            lblTotalFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFees.Location = new Point(262, 149);
            lblTotalFees.Margin = new Padding(5, 0, 5, 0);
            lblTotalFees.Name = "lblTotalFees";
            lblTotalFees.Size = new Size(59, 20);
            lblTotalFees.TabIndex = 202;
            lblTotalFees.Text = "[$$$$]";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(478, 149);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(127, 20);
            label8.TabIndex = 200;
            label8.Text = "Application ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(19, 149);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 200;
            label7.Text = "Total Fees:";
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(218, 149);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(36, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 201;
            pictureBox6.TabStop = false;
            // 
            // lblApplicationFees
            // 
            lblApplicationFees.AutoSize = true;
            lblApplicationFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationFees.Location = new Point(262, 108);
            lblApplicationFees.Margin = new Padding(5, 0, 5, 0);
            lblApplicationFees.Name = "lblApplicationFees";
            lblApplicationFees.Size = new Size(59, 20);
            lblApplicationFees.TabIndex = 199;
            lblApplicationFees.Text = "[$$$$]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 108);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(148, 20);
            label6.TabIndex = 197;
            label6.Text = "Application Fees:";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(218, 108);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(36, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 198;
            pictureBox5.TabStop = false;
            // 
            // lblFineFees
            // 
            lblFineFees.AutoSize = true;
            lblFineFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFineFees.Location = new Point(722, 108);
            lblFineFees.Margin = new Padding(5, 0, 5, 0);
            lblFineFees.Name = "lblFineFees";
            lblFineFees.Size = new Size(59, 20);
            lblFineFees.TabIndex = 196;
            lblFineFees.Text = "[$$$$]";
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(678, 28);
            pictureBox8.Margin = new Padding(4, 3, 4, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(36, 30);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 195;
            pictureBox8.TabStop = false;
            // 
            // lblLicenseID
            // 
            lblLicenseID.AutoSize = true;
            lblLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseID.Location = new Point(722, 28);
            lblLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblLicenseID.Name = "lblLicenseID";
            lblLicenseID.Size = new Size(49, 20);
            lblLicenseID.TabIndex = 191;
            lblLicenseID.Text = "[???]";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(478, 28);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 20);
            label10.TabIndex = 190;
            label10.Text = "License ID:";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(218, 28);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 183;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(678, 65);
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
            label1.Location = new Point(478, 65);
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
            lblCreatedByUser.Location = new Point(722, 65);
            lblCreatedByUser.Margin = new Padding(5, 0, 5, 0);
            lblCreatedByUser.Name = "lblCreatedByUser";
            lblCreatedByUser.Size = new Size(59, 20);
            lblCreatedByUser.TabIndex = 180;
            lblCreatedByUser.Text = "[????]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(478, 108);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 177;
            label2.Text = "Fine Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(678, 108);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 178;
            pictureBox3.TabStop = false;
            // 
            // lblDetainDate
            // 
            lblDetainDate.AutoSize = true;
            lblDetainDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetainDate.Location = new Point(262, 65);
            lblDetainDate.Margin = new Padding(5, 0, 5, 0);
            lblDetainDate.Name = "lblDetainDate";
            lblDetainDate.Size = new Size(109, 20);
            lblDetainDate.TabIndex = 176;
            lblDetainDate.Text = "[??/??/????]";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(218, 65);
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
            label5.Location = new Point(19, 65);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 174;
            label5.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            lblDetainID.AutoSize = true;
            lblDetainID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetainID.Location = new Point(262, 28);
            lblDetainID.Margin = new Padding(5, 0, 5, 0);
            lblDetainID.Name = "lblDetainID";
            lblDetainID.Size = new Size(49, 20);
            lblDetainID.TabIndex = 173;
            lblDetainID.Text = "[???]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(19, 28);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 172;
            label4.Text = "Detain ID:";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            ctrlDriverLicenseInfoWithFilter1.BackColor = Color.White;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            ctrlDriverLicenseInfoWithFilter1.Location = new Point(24, 93);
            ctrlDriverLicenseInfoWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            ctrlDriverLicenseInfoWithFilter1.Size = new Size(1011, 481);
            ctrlDriverLicenseInfoWithFilter1.TabIndex = 198;
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // frmReleaseDetainedLicense
            // 
            AcceptButton = btnRelease;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1063, 871);
            Controls.Add(ctrlDriverLicenseInfoWithFilter1);
            Controls.Add(btnClose);
            Controls.Add(btnRelease);
            Controls.Add(lblTitle);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(llShowLicenseInfo);
            Controls.Add(gbDetain);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmReleaseDetainedLicense";
            Text = "frmReleaseDetainedLicense";
            Load += frmReleaseDetainedLicense_Load;
            gbDetain.ResumeLayout(false);
            gbDetain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.GroupBox gbDetain;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label4;
        private Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}