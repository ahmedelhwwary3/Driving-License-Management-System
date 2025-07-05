namespace PresentationLayer.Licenses.InternationalLicenses
{
    partial class frmShowInternationaLicenseInfo
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
            label1 = new Label();
            btnClose = new Button();
            ctrlInternationalLicenseInfo2 = new ctrlInternationalLicenseInfo();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(304, 9);
            label1.Name = "label1";
            label1.Size = new Size(428, 39);
            label1.TabIndex = 1;
            label1.Text = "International License Info";
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(853, 383);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(167, 58);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlInternationalLicenseInfo2
            // 
            ctrlInternationalLicenseInfo2.BackColor = Color.White;
            ctrlInternationalLicenseInfo2.Location = new Point(0, 51);
            ctrlInternationalLicenseInfo2.Margin = new Padding(4, 3, 4, 3);
            ctrlInternationalLicenseInfo2.Name = "ctrlInternationalLicenseInfo2";
            ctrlInternationalLicenseInfo2.Size = new Size(1099, 336);
            ctrlInternationalLicenseInfo2.TabIndex = 0;
            // 
            // frmShowInternationaLicenseInfo
            // 
            AcceptButton = btnClose;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1097, 451);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(ctrlInternationalLicenseInfo2);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmShowInternationaLicenseInfo";
            Tag = "MainTitle";
            Load += frmShowInternationaLicenseInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private ctrlInternationalLicenseInfo ctrlInternationalLicenseInfo1;
        private ctrlInternationalLicenseInfo ctrlInternationalLicenseInfo2;
        private System.Windows.Forms.Label label1;

    }
}