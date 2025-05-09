namespace PresentationLayer.Licenses.LocalLicenses
{
    partial class frmShowLicenseInfo
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
            lblTitle = new Label();
            ctrlDriverLicenseInfo1 = new ctrlDriverLicenseInfo();
            btnClose = new Button();
            pbTestTypeImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(236, 130);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(514, 45);
            lblTitle.TabIndex = 138;
            lblTitle.Text = "Driver License Info";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfo1
            // 
            ctrlDriverLicenseInfo1.BackColor = Color.White;
            ctrlDriverLicenseInfo1.Location = new Point(14, 179);
            ctrlDriverLicenseInfo1.Margin = new Padding(5, 3, 5, 3);
            ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            ctrlDriverLicenseInfo1.Size = new Size(1016, 397);
            ctrlDriverLicenseInfo1.TabIndex = 140;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(763, 585);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 139;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pbTestTypeImage
            // 
            pbTestTypeImage.BackgroundImageLayout = ImageLayout.Zoom;
            pbTestTypeImage.Image = Properties.Resources.Driver_Main1;
            pbTestTypeImage.InitialImage = null;
            pbTestTypeImage.Location = new Point(433, 5);
            pbTestTypeImage.Margin = new Padding(5, 6, 5, 6);
            pbTestTypeImage.Name = "pbTestTypeImage";
            pbTestTypeImage.Size = new Size(132, 120);
            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbTestTypeImage.TabIndex = 137;
            pbTestTypeImage.TabStop = false;
            // 
            // frmShowLicenseInfo
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1020, 635);
            Controls.Add(ctrlDriverLicenseInfo1);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);
            Controls.Add(pbTestTypeImage);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmShowLicenseInfo";
            Text = "frmShowLicenseInfo";
            Load += frmShowLicenseInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}