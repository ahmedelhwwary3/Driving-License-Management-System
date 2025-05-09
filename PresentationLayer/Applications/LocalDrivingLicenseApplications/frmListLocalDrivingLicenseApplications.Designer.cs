namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    partial class frmListLocalDrivingLicenseApplications
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
            label3 = new Label();
            txtFilterValue = new TextBox();
            cbFilterColumn = new ComboBox();
            lblRecords = new Label();
            label2 = new Label();
            btnClose = new Button();
            label1 = new Label();
            dgvLocalApplications = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            editApplicationToolStripMenuItem = new ToolStripMenuItem();
            deleteApplicationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            cancelApplicationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            scheduleTestsToolStripMenuItem = new ToolStripMenuItem();
            visionTestToolStripMenuItem = new ToolStripMenuItem();
            writtenTestToolStripMenuItem = new ToolStripMenuItem();
            streetTestToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            issueDrivingLicenseFirstTimeToolStripMenuItem = new ToolStripMenuItem();
            showLicenseToolStripMenuItem1 = new ToolStripMenuItem();
            showLicenseToolStripMenuItem = new ToolStripSeparator();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            btnAddNewLocalApp = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvLocalApplications).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 294);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 20;
            label3.Text = "Filter By :";
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(449, 298);
            txtFilterValue.Margin = new Padding(4, 3, 4, 3);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(306, 23);
            txtFilterValue.TabIndex = 19;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterColumn
            // 
            cbFilterColumn.Anchor = AnchorStyles.Left;
            cbFilterColumn.FormattingEnabled = true;
            cbFilterColumn.Items.AddRange(new object[] { "None", "Local Driving License Application ID", "Driving Class", "National No", "Full Name", "Passed Tests", "Status" });
            cbFilterColumn.Location = new Point(121, 297);
            cbFilterColumn.Margin = new Padding(4, 3, 4, 3);
            cbFilterColumn.Name = "cbFilterColumn";
            cbFilterColumn.Size = new Size(310, 23);
            cbFilterColumn.TabIndex = 18;
            cbFilterColumn.SelectedIndexChanged += cbFilterColumn_SelectedIndexChanged;
            // 
            // lblRecords
            // 
            lblRecords.Anchor = AnchorStyles.Left;
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecords.Location = new Point(100, 888);
            lblRecords.Margin = new Padding(4, 0, 4, 0);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(36, 20);
            lblRecords.TabIndex = 17;
            lblRecords.Text = "???";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 888);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 16;
            label2.Text = "Records";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(1202, 865);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 46);
            btnClose.TabIndex = 15;
            btnClose.Text = " Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(254, 228);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(728, 39);
            label1.TabIndex = 13;
            label1.Text = "Manage Local Driving License Applications ";
            // 
            // dgvLocalApplications
            // 
            dgvLocalApplications.AllowUserToAddRows = false;
            dgvLocalApplications.AllowUserToDeleteRows = false;
            dgvLocalApplications.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLocalApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocalApplications.ContextMenuStrip = contextMenuStrip1;
            dgvLocalApplications.Location = new Point(9, 338);
            dgvLocalApplications.Margin = new Padding(4, 3, 4, 3);
            dgvLocalApplications.Name = "dgvLocalApplications";
            dgvLocalApplications.ReadOnly = true;
            dgvLocalApplications.Size = new Size(1328, 520);
            dgvLocalApplications.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, toolStripMenuItem1, editApplicationToolStripMenuItem, deleteApplicationToolStripMenuItem, toolStripMenuItem2, cancelApplicationToolStripMenuItem, toolStripMenuItem3, scheduleTestsToolStripMenuItem, toolStripMenuItem4, issueDrivingLicenseFirstTimeToolStripMenuItem, showLicenseToolStripMenuItem1, showLicenseToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(259, 338);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_322;
            showApplicationDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(258, 38);
            showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            showApplicationDetailsToolStripMenuItem.Click += showApplicationDetailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(255, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            editApplicationToolStripMenuItem.Image = Properties.Resources.edit_32;
            editApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            editApplicationToolStripMenuItem.Size = new Size(258, 38);
            editApplicationToolStripMenuItem.Text = "Edit Application";
            editApplicationToolStripMenuItem.Click += editApplicationToolStripMenuItem_Click;
            // 
            // deleteApplicationToolStripMenuItem
            // 
            deleteApplicationToolStripMenuItem.Image = Properties.Resources.Delete_32_2;
            deleteApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            deleteApplicationToolStripMenuItem.Size = new Size(258, 38);
            deleteApplicationToolStripMenuItem.Text = "Delete Application";
            deleteApplicationToolStripMenuItem.Click += deleteApplicationToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(255, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            cancelApplicationToolStripMenuItem.Image = Properties.Resources.Close_32;
            cancelApplicationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            cancelApplicationToolStripMenuItem.Size = new Size(258, 38);
            cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            cancelApplicationToolStripMenuItem.Click += cancelApplicationToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(255, 6);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { visionTestToolStripMenuItem, writtenTestToolStripMenuItem, streetTestToolStripMenuItem });
            scheduleTestsToolStripMenuItem.Image = Properties.Resources.Test_32;
            scheduleTestsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            scheduleTestsToolStripMenuItem.Size = new Size(258, 38);
            scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // visionTestToolStripMenuItem
            // 
            visionTestToolStripMenuItem.Image = Properties.Resources.Vision_Test_32;
            visionTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            visionTestToolStripMenuItem.Size = new Size(152, 38);
            visionTestToolStripMenuItem.Text = "Vision Test";
            visionTestToolStripMenuItem.Click += visionTestToolStripMenuItem_Click;
            // 
            // writtenTestToolStripMenuItem
            // 
            writtenTestToolStripMenuItem.Image = Properties.Resources.Written_Test_32;
            writtenTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            writtenTestToolStripMenuItem.Size = new Size(152, 38);
            writtenTestToolStripMenuItem.Text = "Written Test";
            writtenTestToolStripMenuItem.Click += writtenTestToolStripMenuItem_Click;
            // 
            // streetTestToolStripMenuItem
            // 
            streetTestToolStripMenuItem.Image = Properties.Resources.Street_Test_32;
            streetTestToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            streetTestToolStripMenuItem.Size = new Size(152, 38);
            streetTestToolStripMenuItem.Text = "Street Test";
            streetTestToolStripMenuItem.Click += streetTestToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(255, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Image = Properties.Resources.IssueDrivingLicense_32;
            issueDrivingLicenseFirstTimeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new Size(258, 38);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License(First Time)";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Click += issueDrivingLicenseFirstTimeToolStripMenuItem_Click;
            // 
            // showLicenseToolStripMenuItem1
            // 
            showLicenseToolStripMenuItem1.Image = Properties.Resources.License_View_32;
            showLicenseToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            showLicenseToolStripMenuItem1.Name = "showLicenseToolStripMenuItem1";
            showLicenseToolStripMenuItem1.Size = new Size(258, 38);
            showLicenseToolStripMenuItem1.Text = "Show License";
            showLicenseToolStripMenuItem1.Click += showLicenseToolStripMenuItem1_Click;
            // 
            // showLicenseToolStripMenuItem
            // 
            showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            showLicenseToolStripMenuItem.Size = new Size(255, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.License_Type_32;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(258, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // btnAddNewLocalApp
            // 
            btnAddNewLocalApp.Anchor = AnchorStyles.Right;
            btnAddNewLocalApp.Image = Properties.Resources.AddPerson_321;
            btnAddNewLocalApp.Location = new Point(1281, 285);
            btnAddNewLocalApp.Margin = new Padding(4, 3, 4, 3);
            btnAddNewLocalApp.Name = "btnAddNewLocalApp";
            btnAddNewLocalApp.Size = new Size(56, 46);
            btnAddNewLocalApp.TabIndex = 14;
            btnAddNewLocalApp.Text = " ";
            btnAddNewLocalApp.UseVisualStyleBackColor = true;
            btnAddNewLocalApp.Click += btnAddNewLocalApp_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Local_Driving_License_512;
            pictureBox1.Location = new Point(548, 7);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 218);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            AcceptButton = btnAddNewLocalApp;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1348, 915);
            Controls.Add(label3);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterColumn);
            Controls.Add(lblRecords);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(btnAddNewLocalApp);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(dgvLocalApplications);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmListLocalDrivingLicenseApplications";
            Text = "frmListLocalDrivingLicenseApplications";
            Load += frmListLocalDrivingLicenseApplications_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLocalApplications).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewLocalApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvLocalApplications;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem1;
    }
}