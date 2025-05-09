namespace PresentationLayer.Tests
{
    partial class frmListTestAppointments
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
            lblRecords = new Label();
            lblTitle = new Label();
            dgvTestAppointments = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            takeTestToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            ctrlDrivingLicenesApplicationInfo1 = new Applications.LocalDrivingLicenseApplications.Controls.ctrlDrivingLicenesApplicationInfo();
            btnAddNewAppointment = new Button();
            btnClose = new Button();
            pbTestTypeImage = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTestAppointments).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).BeginInit();
            SuspendLayout();
            // 
            // lblRecords
            // 
            lblRecords.AutoSize = true;
            lblRecords.Location = new Point(121, 1067);
            lblRecords.Margin = new Padding(4, 0, 4, 0);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(22, 15);
            lblRecords.TabIndex = 17;
            lblRecords.Text = "???";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(394, 234);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(324, 39);
            lblTitle.TabIndex = 16;
            lblTitle.Text = "Test Appointments";
            // 
            // dgvTestAppointments
            // 
            dgvTestAppointments.AllowUserToAddRows = false;
            dgvTestAppointments.AllowUserToDeleteRows = false;
            dgvTestAppointments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTestAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTestAppointments.ContextMenuStrip = contextMenuStrip1;
            dgvTestAppointments.Location = new Point(15, 852);
            dgvTestAppointments.Margin = new Padding(4, 3, 4, 3);
            dgvTestAppointments.Name = "dgvTestAppointments";
            dgvTestAppointments.ReadOnly = true;
            dgvTestAppointments.Size = new Size(1105, 148);
            dgvTestAppointments.TabIndex = 15;
            dgvTestAppointments.DataBindingComplete += dgvTestAppointments_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, takeTestToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(137, 80);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_32;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(136, 38);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // takeTestToolStripMenuItem
            // 
            takeTestToolStripMenuItem.Image = Properties.Resources.Test_32;
            takeTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            takeTestToolStripMenuItem.Size = new Size(136, 38);
            takeTestToolStripMenuItem.Text = "Take Test";
            takeTestToolStripMenuItem.Click += takeTestToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 1059);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 13;
            label2.Text = "Records :";
            // 
            // ctrlDrivingLicenesApplicationInfo1
            // 
            ctrlDrivingLicenesApplicationInfo1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ctrlDrivingLicenesApplicationInfo1.BackColor = Color.White;
            ctrlDrivingLicenesApplicationInfo1.Location = new Point(0, 280);
            ctrlDrivingLicenesApplicationInfo1.Margin = new Padding(5, 3, 5, 3);
            ctrlDrivingLicenesApplicationInfo1.Name = "ctrlDrivingLicenesApplicationInfo1";
            ctrlDrivingLicenesApplicationInfo1.Size = new Size(1129, 503);
            ctrlDrivingLicenesApplicationInfo1.TabIndex = 18;
            // 
            // btnAddNewAppointment
            // 
            btnAddNewAppointment.Anchor = AnchorStyles.Right;
            btnAddNewAppointment.Image = Properties.Resources.Test_321;
            btnAddNewAppointment.Location = new Point(1039, 801);
            btnAddNewAppointment.Margin = new Padding(4, 3, 4, 3);
            btnAddNewAppointment.Name = "btnAddNewAppointment";
            btnAddNewAppointment.Size = new Size(80, 44);
            btnAddNewAppointment.TabIndex = 14;
            btnAddNewAppointment.Text = "Add";
            btnAddNewAppointment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddNewAppointment.UseVisualStyleBackColor = true;
            btnAddNewAppointment.Click += btnAddNewAppointment_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(950, 1010);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(169, 44);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pbTestTypeImage
            // 
            pbTestTypeImage.Anchor = AnchorStyles.None;
            pbTestTypeImage.Image = Properties.Resources.TestType_5121;
            pbTestTypeImage.Location = new Point(464, 7);
            pbTestTypeImage.Margin = new Padding(4, 3, 4, 3);
            pbTestTypeImage.Name = "pbTestTypeImage";
            pbTestTypeImage.Size = new Size(252, 209);
            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbTestTypeImage.TabIndex = 11;
            pbTestTypeImage.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(159, 1025);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 21;
            label1.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(51, 1025);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 20;
            label3.Text = "Records :";
            // 
            // frmListTestAppointments
            // 
            AcceptButton = btnAddNewAppointment;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1133, 1061);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(ctrlDrivingLicenesApplicationInfo1);
            Controls.Add(lblRecords);
            Controls.Add(lblTitle);
            Controls.Add(dgvTestAppointments);
            Controls.Add(btnAddNewAppointment);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(pbTestTypeImage);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmListTestAppointments";
            Text = "frmListTestAppointments";
            Load += frmListTestAppointments_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTestAppointments).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTestAppointments;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private Applications.LocalDrivingLicenseApplications.Controls.ctrlDrivingLicenesApplicationInfo ctrlDrivingLicenesApplicationInfo1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private Label label1;
        private Label label3;
    }
}