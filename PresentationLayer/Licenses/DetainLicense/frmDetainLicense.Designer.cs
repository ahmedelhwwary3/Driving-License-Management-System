namespace PresentationLayer.Licenses.DetainLicense
{
    partial class frmDetainLicense
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            btnClose = new Button();
            llShowLicenseInfo = new LinkLabel();
            btnDetain = new Button();
            llShowLicenseHistory = new LinkLabel();
            gpDetain = new GroupBox();
            txtFineFees = new TextBox();
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
            errorProvider1 = new ErrorProvider(components);
            ctrlDriverLicenseInfoWithFilter1 = new LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter();
            gpDetain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(55, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(953, 45);
            lblTitle.TabIndex = 185;
            lblTitle.Tag = "MainTitle";
            lblTitle.Text = "Detain License";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(694, 820);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 187;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // llShowLicenseInfo
            // 
            llShowLicenseInfo.AutoSize = true;
            llShowLicenseInfo.Enabled = false;
            llShowLicenseInfo.Location = new Point(257, 834);
            llShowLicenseInfo.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseInfo.Name = "llShowLicenseInfo";
            llShowLicenseInfo.Size = new Size(107, 15);
            llShowLicenseInfo.TabIndex = 190;
            llShowLicenseInfo.TabStop = true;
            llShowLicenseInfo.Text = "Show Licenses Info";
            llShowLicenseInfo.LinkClicked += llShowLicenseInfo_LinkClicked;
            // 
            // btnDetain
            // 
            btnDetain.Enabled = false;
            btnDetain.FlatStyle = FlatStyle.Flat;
            btnDetain.Image = Properties.Resources.Detain_32;
            btnDetain.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetain.Location = new Point(850, 820);
            btnDetain.Margin = new Padding(4, 3, 4, 3);
            btnDetain.Name = "btnDetain";
            btnDetain.Size = new Size(147, 43);
            btnDetain.TabIndex = 188;
            btnDetain.Text = "Detain";
            btnDetain.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDetain.UseVisualStyleBackColor = true;
            btnDetain.Click += btnDetain_Click;
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Location = new Point(43, 834);
            llShowLicenseHistory.Margin = new Padding(4, 0, 4, 0);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(124, 15);
            llShowLicenseHistory.TabIndex = 189;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show Licenses History";
            llShowLicenseHistory.LinkClicked += llShowLicenseHistory_LinkClicked;
            // 
            // gpDetain
            // 
            gpDetain.Controls.Add(txtFineFees);
            gpDetain.Controls.Add(pictureBox8);
            gpDetain.Controls.Add(lblLicenseID);
            gpDetain.Controls.Add(label10);
            gpDetain.Controls.Add(pictureBox2);
            gpDetain.Controls.Add(pictureBox1);
            gpDetain.Controls.Add(label1);
            gpDetain.Controls.Add(lblCreatedByUser);
            gpDetain.Controls.Add(label2);
            gpDetain.Controls.Add(pictureBox3);
            gpDetain.Controls.Add(lblDetainDate);
            gpDetain.Controls.Add(pictureBox4);
            gpDetain.Controls.Add(label5);
            gpDetain.Controls.Add(lblDetainID);
            gpDetain.Controls.Add(label4);
            gpDetain.Location = new Point(16, 601);
            gpDetain.Margin = new Padding(4, 3, 4, 3);
            gpDetain.Name = "gpDetain";
            gpDetain.Padding = new Padding(4, 3, 4, 3);
            gpDetain.Size = new Size(992, 212);
            gpDetain.TabIndex = 186;
            gpDetain.TabStop = false;
            gpDetain.Text = "Detain Info";
            // 
            // txtFineFees
            // 
            txtFineFees.Location = new Point(267, 120);
            txtFineFees.Margin = new Padding(4, 3, 4, 3);
            txtFineFees.Name = "txtFineFees";
            txtFineFees.Size = new Size(118, 23);
            txtFineFees.TabIndex = 196;
            txtFineFees.TabStop = false;
            txtFineFees.KeyPress += txtFineFees_KeyPress;
            txtFineFees.Validating += txtFineFees_Validating;
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(756, 46);
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
            lblLicenseID.Location = new Point(800, 46);
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
            label10.Location = new Point(631, 46);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 20);
            label10.TabIndex = 190;
            label10.Text = "License ID:";
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
            pictureBox1.Location = new Point(756, 83);
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
            label1.Location = new Point(518, 83);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 20);
            label1.TabIndex = 181;
            label1.Text = "Created By User Name:";
            // 
            // lblCreatedByUser
            // 
            lblCreatedByUser.AutoSize = true;
            lblCreatedByUser.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedByUser.Location = new Point(800, 83);
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
            label2.Location = new Point(19, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 177;
            label2.Text = "Fine Fees:";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(218, 120);
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
            lblDetainDate.Location = new Point(262, 83);
            lblDetainDate.Margin = new Padding(5, 0, 5, 0);
            lblDetainDate.Name = "lblDetainDate";
            lblDetainDate.Size = new Size(109, 20);
            lblDetainDate.TabIndex = 176;
            lblDetainDate.Text = "[??/??/????]";
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
            label5.Size = new Size(111, 20);
            label5.TabIndex = 174;
            label5.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            lblDetainID.AutoSize = true;
            lblDetainID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetainID.Location = new Point(262, 46);
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
            label4.Location = new Point(19, 46);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 172;
            label4.Text = "Detain ID:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            ctrlDriverLicenseInfoWithFilter1.BackColor = Color.White;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            ctrlDriverLicenseInfoWithFilter1.Location = new Point(7, 83);
            ctrlDriverLicenseInfoWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            ctrlDriverLicenseInfoWithFilter1.Size = new Size(1011, 481);
            ctrlDriverLicenseInfoWithFilter1.TabIndex = 191;
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected;
            // 
            // frmDetainLicense
            // 
            AcceptButton = btnDetain;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1027, 873);
            Controls.Add(ctrlDriverLicenseInfoWithFilter1);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(llShowLicenseInfo);
            Controls.Add(btnDetain);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(gpDetain);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmDetainLicense";
            Text = "frmDetainLicense";
            Load += frmDetainLicense_Load;
            gpDetain.ResumeLayout(false);
            gpDetain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.GroupBox gpDetain;
        private System.Windows.Forms.TextBox txtFineFees;
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
    }
}