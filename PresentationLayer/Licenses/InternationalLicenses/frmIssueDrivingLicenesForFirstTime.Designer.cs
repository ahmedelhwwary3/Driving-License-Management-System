namespace PresentationLayer.Licenses.LocalLicenses
{
    partial class frmIssueDrivingLicenesForFirstTime
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
            txtNotes = new TextBox();
            btnClose = new Button();
            ctrlDrivingLicenesApplicationInfo1 = new Applications.LocalDrivingLicenseApplications.Controls.ctrlDrivingLicenesApplicationInfo();
            pictureBox1 = new PictureBox();
            btnIssueLicense = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 530);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 179;
            label1.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(230, 534);
            txtNotes.Margin = new Padding(4, 3, 4, 3);
            txtNotes.MaxLength = 500;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(913, 146);
            txtNotes.TabIndex = 176;
            txtNotes.Text = "First Time";
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(840, 690);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 43);
            btnClose.TabIndex = 178;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlDrivingLicenesApplicationInfo1
            // 
            ctrlDrivingLicenesApplicationInfo1.BackColor = Color.White;
            ctrlDrivingLicenesApplicationInfo1.Location = new Point(14, 14);
            ctrlDrivingLicenesApplicationInfo1.Margin = new Padding(5, 3, 5, 3);
            ctrlDrivingLicenesApplicationInfo1.Name = "ctrlDrivingLicenesApplicationInfo1";
            ctrlDrivingLicenesApplicationInfo1.Size = new Size(1129, 503);
            ctrlDrivingLicenesApplicationInfo1.TabIndex = 181;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Notes_32;
            pictureBox1.Location = new Point(191, 533);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 180;
            pictureBox1.TabStop = false;
            // 
            // btnIssueLicense
            // 
            btnIssueLicense.Image = Properties.Resources.IssueDrivingLicense_32;
            btnIssueLicense.ImageAlign = ContentAlignment.MiddleLeft;
            btnIssueLicense.Location = new Point(995, 690);
            btnIssueLicense.Name = "btnIssueLicense";
            btnIssueLicense.Size = new Size(147, 43);
            btnIssueLicense.TabIndex = 182;
            btnIssueLicense.Text = "Issue";
            btnIssueLicense.UseVisualStyleBackColor = true;
            btnIssueLicense.Click += btnIssueLicense_Click;
            // 
            // frmIssueDrivingLicenesForFirstTime
            // 
            AcceptButton = btnIssueLicense;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1155, 743);
            Controls.Add(btnIssueLicense);
            Controls.Add(ctrlDrivingLicenesApplicationInfo1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(txtNotes);
            Controls.Add(btnClose);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmIssueDrivingLicenesForFirstTime";
            Text = "frmIssueDrivingLicenesForFirstTime";
            Load += frmIssueDrivingLicenesForFirstTime_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnClose;
        private Applications.LocalDrivingLicenseApplications.Controls.ctrlDrivingLicenesApplicationInfo ctrlDrivingLicenesApplicationInfo1;
        private Button btnIssueLicense;
    }
}