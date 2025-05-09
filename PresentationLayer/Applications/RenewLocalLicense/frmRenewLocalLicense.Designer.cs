namespace PresentationLayer.Applications.RenewLocalLicense
{
    partial class frmRenewLocalLicense
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
            btnClose = new Button();
            gbApplicationInfo = new GroupBox();
            pictureBox11 = new PictureBox();
            label3 = new Label();
            txtNotes = new TextBox();
            lblTotalFees = new Label();
            label9 = new Label();
            pictureBox10 = new PictureBox();
            lblLicenseFees = new Label();
            label7 = new Label();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            lblOldLicenseID = new Label();
            label12 = new Label();
            pictureBox7 = new PictureBox();
            lblRenewLicenseID = new Label();
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
            lblApplicationFees = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            lblApplicationDate = new Label();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            lblApplicationID = new Label();
            label4 = new Label();
            lblTitle = new Label();
            ctrlDriverLicenseInfoWithFilter1 = new Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter();
            btnRenewLicense = new Button();
            gbApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
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
            llShowLicenseInfo.Location = new Point(251, 913);
            llShowLicenseInfo.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseInfo.Name = "llShowLicenseInfo";
            llShowLicenseInfo.Size = new Size(134, 15);
            llShowLicenseInfo.TabIndex = 188;
            llShowLicenseInfo.TabStop = true;
            llShowLicenseInfo.Text = "Show New Licenses Info";
            llShowLicenseInfo.LinkClicked += llShowLicenseInfo_LinkClicked;
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Location = new Point(37, 913);
            llShowLicenseHistory.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(124, 15);
            llShowLicenseHistory.TabIndex = 187;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show Licenses History";
            llShowLicenseHistory.LinkClicked += llShowLicenseHistory_LinkClicked;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(720, 907);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 185;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // gbApplicationInfo
            // 
            gbApplicationInfo.Controls.Add(pictureBox11);
            gbApplicationInfo.Controls.Add(label3);
            gbApplicationInfo.Controls.Add(txtNotes);
            gbApplicationInfo.Controls.Add(lblTotalFees);
            gbApplicationInfo.Controls.Add(label9);
            gbApplicationInfo.Controls.Add(pictureBox10);
            gbApplicationInfo.Controls.Add(lblLicenseFees);
            gbApplicationInfo.Controls.Add(label7);
            gbApplicationInfo.Controls.Add(pictureBox9);
            gbApplicationInfo.Controls.Add(pictureBox8);
            gbApplicationInfo.Controls.Add(lblOldLicenseID);
            gbApplicationInfo.Controls.Add(label12);
            gbApplicationInfo.Controls.Add(pictureBox7);
            gbApplicationInfo.Controls.Add(lblRenewLicenseID);
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
            gbApplicationInfo.Controls.Add(lblApplicationFees);
            gbApplicationInfo.Controls.Add(label2);
            gbApplicationInfo.Controls.Add(pictureBox3);
            gbApplicationInfo.Controls.Add(lblApplicationDate);
            gbApplicationInfo.Controls.Add(pictureBox4);
            gbApplicationInfo.Controls.Add(label5);
            gbApplicationInfo.Controls.Add(lblApplicationID);
            gbApplicationInfo.Controls.Add(label4);
            gbApplicationInfo.Location = new Point(41, 572);
            gbApplicationInfo.Margin = new Padding(4, 3, 4, 3);
            gbApplicationInfo.Name = "gbApplicationInfo";
            gbApplicationInfo.Padding = new Padding(4, 3, 4, 3);
            gbApplicationInfo.Size = new Size(986, 328);
            gbApplicationInfo.TabIndex = 184;
            gbApplicationInfo.TabStop = false;
            gbApplicationInfo.Text = "Base Application  for New License ";
            // 
            // pictureBox11
            // 
            pictureBox11.Location = new Point(255, 230);
            pictureBox11.Margin = new Padding(4, 3, 4, 3);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(36, 30);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.TabIndex = 204;
            pictureBox11.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 230);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 203;
            label3.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(309, 232);
            txtNotes.Margin = new Padding(4, 3, 4, 3);
            txtNotes.MaxLength = 500;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(598, 73);
            txtNotes.TabIndex = 202;
            // 
            // lblTotalFees
            // 
            lblTotalFees.AutoSize = true;
            lblTotalFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFees.Location = new Point(758, 193);
            lblTotalFees.Margin = new Padding(5, 0, 5, 0);
            lblTotalFees.Name = "lblTotalFees";
            lblTotalFees.Size = new Size(49, 20);
            lblTotalFees.TabIndex = 201;
            lblTotalFees.Text = "[$$$]";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(500, 193);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 199;
            label9.Text = "Total  Fees:";
            // 
            // pictureBox10
            // 
            pictureBox10.Location = new Point(716, 193);
            pictureBox10.Margin = new Padding(4, 3, 4, 3);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(36, 30);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 200;
            pictureBox10.TabStop = false;
            // 
            // lblLicenseFees
            // 
            lblLicenseFees.AutoSize = true;
            lblLicenseFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLicenseFees.Location = new Point(300, 193);
            lblLicenseFees.Margin = new Padding(5, 0, 5, 0);
            lblLicenseFees.Name = "lblLicenseFees";
            lblLicenseFees.Size = new Size(49, 20);
            lblLicenseFees.TabIndex = 198;
            lblLicenseFees.Text = "[$$$]";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 193);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(126, 20);
            label7.TabIndex = 196;
            label7.Text = "License  Fees:";
            // 
            // pictureBox9
            // 
            pictureBox9.Location = new Point(255, 193);
            pictureBox9.Margin = new Padding(4, 3, 4, 3);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(36, 30);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 197;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(716, 81);
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
            lblOldLicenseID.Location = new Point(761, 81);
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
            label12.Location = new Point(500, 81);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(132, 20);
            label12.TabIndex = 193;
            label12.Text = "Old License ID:";
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(716, 44);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(36, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 192;
            pictureBox7.TabStop = false;
            // 
            // lblRenewLicenseID
            // 
            lblRenewLicenseID.AutoSize = true;
            lblRenewLicenseID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRenewLicenseID.Location = new Point(761, 44);
            lblRenewLicenseID.Margin = new Padding(5, 0, 5, 0);
            lblRenewLicenseID.Name = "lblRenewLicenseID";
            lblRenewLicenseID.Size = new Size(49, 20);
            lblRenewLicenseID.TabIndex = 191;
            lblRenewLicenseID.Text = "[???]";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(500, 44);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(180, 20);
            label10.TabIndex = 190;
            label10.Text = "Renewed License ID:";
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpirationDate.Location = new Point(761, 118);
            lblExpirationDate.Margin = new Padding(5, 0, 5, 0);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(109, 20);
            lblExpirationDate.TabIndex = 189;
            lblExpirationDate.Text = "[??/??/????]";
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(716, 118);
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
            label8.Location = new Point(500, 118);
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
            lblIssueDate.Location = new Point(300, 118);
            lblIssueDate.Margin = new Padding(5, 0, 5, 0);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(109, 20);
            lblIssueDate.TabIndex = 186;
            lblIssueDate.Text = "[??/??/????]";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(255, 118);
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
            label6.Location = new Point(14, 118);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 184;
            label6.Text = "Issue Date:";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(255, 44);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 183;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(716, 155);
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
            label1.Location = new Point(500, 155);
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
            lblCreatedByUser.Location = new Point(761, 155);
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
            lblApplicationFees.Location = new Point(300, 155);
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
            label2.Location = new Point(14, 155);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(189, 20);
            label2.TabIndex = 177;
            label2.Text = "BaseApplication Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(255, 155);
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
            lblApplicationDate.Location = new Point(300, 81);
            lblApplicationDate.Margin = new Padding(5, 0, 5, 0);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(109, 20);
            lblApplicationDate.TabIndex = 176;
            lblApplicationDate.Text = "[??/??/????]";
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(255, 81);
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
            label5.Location = new Point(14, 81);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(188, 20);
            label5.TabIndex = 174;
            label5.Text = "BaseApplication Date:";
            // 
            // lblApplicationID
            // 
            lblApplicationID.AutoSize = true;
            lblApplicationID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApplicationID.Location = new Point(300, 44);
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
            label4.Location = new Point(14, 44);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(173, 20);
            label4.TabIndex = 172;
            label4.Text = "Base Application ID:";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1021, 45);
            lblTitle.TabIndex = 183;
            lblTitle.Text = "Renew Old License ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            ctrlDriverLicenseInfoWithFilter1.BackColor = Color.White;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            ctrlDriverLicenseInfoWithFilter1.Location = new Point(26, 77);
            ctrlDriverLicenseInfoWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            ctrlDriverLicenseInfoWithFilter1.Size = new Size(1018, 481);
            ctrlDriverLicenseInfoWithFilter1.TabIndex = 189;
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // btnRenewLicense
            // 
            btnRenewLicense.Enabled = false;
            btnRenewLicense.FlatStyle = FlatStyle.Flat;
            btnRenewLicense.Image = Properties.Resources.Renew_Driving_License_321;
            btnRenewLicense.ImageAlign = ContentAlignment.MiddleLeft;
            btnRenewLicense.Location = new Point(876, 907);
            btnRenewLicense.Margin = new Padding(4, 3, 4, 3);
            btnRenewLicense.Name = "btnRenewLicense";
            btnRenewLicense.Size = new Size(147, 43);
            btnRenewLicense.TabIndex = 186;
            btnRenewLicense.Text = " Renew";
            btnRenewLicense.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRenewLicense.UseVisualStyleBackColor = true;
            btnRenewLicense.Click += btnRenewLicense_Click;
            // 
            // frmRenewLocalLicense
            // 
            AcceptButton = btnRenewLicense;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1077, 959);
            Controls.Add(ctrlDriverLicenseInfoWithFilter1);
            Controls.Add(llShowLicenseInfo);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(btnRenewLicense);
            Controls.Add(btnClose);
            Controls.Add(gbApplicationInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmRenewLocalLicense";
            Text = "Renew Local License";
            Load += frmRenewLocalLicense_Load;
            gbApplicationInfo.ResumeLayout(false);
            gbApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
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
        private System.Windows.Forms.Button btnRenewLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblRenewLicenseID;
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
        private System.Windows.Forms.Label lblApplicationFees;
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