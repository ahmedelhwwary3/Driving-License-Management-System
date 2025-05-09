namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    partial class frmShowLocalDrivingLicenseApplicationInfo
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
            ctrlDrivingLicenesApplicationInfo1 = new ctrlDrivingLicenesApplicationInfo();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(950, 493);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(141, 51);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlDrivingLicenesApplicationInfo1
            // 
            ctrlDrivingLicenesApplicationInfo1.BackColor = Color.White;
            ctrlDrivingLicenesApplicationInfo1.Location = new Point(2, 2);
            ctrlDrivingLicenesApplicationInfo1.Margin = new Padding(5, 3, 5, 3);
            ctrlDrivingLicenesApplicationInfo1.Name = "ctrlDrivingLicenesApplicationInfo1";
            ctrlDrivingLicenesApplicationInfo1.Size = new Size(1133, 503);
            ctrlDrivingLicenesApplicationInfo1.TabIndex = 0;
            // 
            // frmShowLocalDrivingLicenseApplicationInfo
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1132, 557);
            Controls.Add(btnClose);
            Controls.Add(ctrlDrivingLicenesApplicationInfo1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmShowLocalDrivingLicenseApplicationInfo";
            Text = "frmShowLocalDrivingLicenseApplicationInfo";
            Load += frmShowLocalDrivingLicenseApplicationInfo_Load;
            ResumeLayout(false);
        }

        #endregion

        private ctrlDrivingLicenesApplicationInfo ctrlDrivingLicenesApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}