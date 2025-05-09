namespace PresentationLayer.Licenses.InternationalLicenses
{
    partial class frmListInternationalLicenses
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            cbIsReleased = new ComboBox();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            label1 = new Label();
            lblInternationalLicensesRecords = new Label();
            label5 = new Label();
            dgvInternationalLicenses = new DataGridView();
            cmsApplications = new ContextMenuStrip(components);
            PesonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            btnNewApplication = new Button();
            btnClose = new Button();
            pbPersonImage = new PictureBox();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicenses).BeginInit();
            cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            SuspendLayout();
            // 
            // cbIsReleased
            // 
            cbIsReleased.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsReleased.FormattingEnabled = true;
            cbIsReleased.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsReleased.Location = new Point(359, 335);
            cbIsReleased.Margin = new Padding(4, 3, 4, 3);
            cbIsReleased.Name = "cbIsReleased";
            cbIsReleased.Size = new Size(140, 23);
            cbIsReleased.TabIndex = 175;
            cbIsReleased.Visible = false;
            cbIsReleased.SelectedIndexChanged += cbIsReleased_SelectedIndexChanged;
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Left;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "International License ID", "Application ID", "Driver ID", "Local License ID", "Is Active", "Created By User ID" });
            cbFilterBy.Location = new Point(107, 335);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(244, 23);
            cbFilterBy.TabIndex = 174;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Anchor = AnchorStyles.None;
            txtFilterValue.BorderStyle = BorderStyle.FixedSingle;
            txtFilterValue.Location = new Point(360, 335);
            txtFilterValue.Margin = new Padding(5, 6, 5, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(298, 23);
            txtFilterValue.TabIndex = 173;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 338);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 172;
            label1.Text = "Filter By:";
            // 
            // lblInternationalLicensesRecords
            // 
            lblInternationalLicensesRecords.Anchor = AnchorStyles.Left;
            lblInternationalLicensesRecords.AutoSize = true;
            lblInternationalLicensesRecords.Location = new Point(124, 779);
            lblInternationalLicensesRecords.Margin = new Padding(4, 0, 4, 0);
            lblInternationalLicensesRecords.Name = "lblInternationalLicensesRecords";
            lblInternationalLicensesRecords.Size = new Size(17, 15);
            lblInternationalLicensesRecords.TabIndex = 171;
            lblInternationalLicensesRecords.Text = "??";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 779);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 170;
            label5.Text = "# Records:";
            // 
            // dgvInternationalLicenses
            // 
            dgvInternationalLicenses.AllowUserToAddRows = false;
            dgvInternationalLicenses.AllowUserToDeleteRows = false;
            dgvInternationalLicenses.AllowUserToResizeRows = false;
            dgvInternationalLicenses.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInternationalLicenses.BackgroundColor = Color.White;
            dgvInternationalLicenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInternationalLicenses.ContextMenuStrip = cmsApplications;
            dgvInternationalLicenses.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInternationalLicenses.Location = new Point(14, 376);
            dgvInternationalLicenses.Margin = new Padding(5, 6, 5, 6);
            dgvInternationalLicenses.MultiSelect = false;
            dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            dgvInternationalLicenses.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInternationalLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInternationalLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInternationalLicenses.Size = new Size(1286, 392);
            dgvInternationalLicenses.TabIndex = 169;
            dgvInternationalLicenses.TabStop = false;
            // 
            // cmsApplications
            // 
            cmsApplications.Items.AddRange(new ToolStripItem[] { PesonDetailsToolStripMenuItem, showDetailsToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            cmsApplications.Name = "contextMenuStrip1";
            cmsApplications.Size = new Size(242, 118);
            // 
            // PesonDetailsToolStripMenuItem
            // 
            PesonDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_32;
            PesonDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            PesonDetailsToolStripMenuItem.Name = "PesonDetailsToolStripMenuItem";
            PesonDetailsToolStripMenuItem.Size = new Size(241, 38);
            PesonDetailsToolStripMenuItem.Text = "Show Person Details";
            PesonDetailsToolStripMenuItem.Click += PesonDetailsToolStripMenuItem_Click;
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = Properties.Resources.License_Type_32;
            showDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(241, 38);
            showDetailsToolStripMenuItem.Text = "&Show License Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.License_View_32;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(241, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.International_32;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(766, 93);
            pictureBox1.Margin = new Padding(5, 6, 5, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 168;
            pictureBox1.TabStop = false;
            // 
            // btnNewApplication
            // 
            btnNewApplication.Anchor = AnchorStyles.Right;
            btnNewApplication.FlatStyle = FlatStyle.Flat;
            btnNewApplication.Image = Properties.Resources.IssueDrivingLicense_322;
            btnNewApplication.Location = new Point(1197, 280);
            btnNewApplication.Margin = new Padding(4, 3, 4, 3);
            btnNewApplication.Name = "btnNewApplication";
            btnNewApplication.Size = new Size(103, 87);
            btnNewApplication.TabIndex = 167;
            btnNewApplication.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewApplication.UseVisualStyleBackColor = true;
            btnNewApplication.Click += btnIssueInternationalLicense_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.AutoEllipsis = true;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1142, 778);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(158, 42);
            btnClose.TabIndex = 164;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pbPersonImage
            // 
            pbPersonImage.BackgroundImageLayout = ImageLayout.Zoom;
            pbPersonImage.Image = Properties.Resources.LicenseView_400;
            pbPersonImage.InitialImage = null;
            pbPersonImage.Location = new Point(561, 16);
            pbPersonImage.Margin = new Padding(5, 6, 5, 6);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(257, 218);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 166;
            pbPersonImage.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(349, 240);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(663, 45);
            lblTitle.TabIndex = 165;
            lblTitle.Text = "International License Applications";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmListInternationalLicenses
            // 
            AcceptButton = btnNewApplication;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1314, 832);
            Controls.Add(cbIsReleased);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(label1);
            Controls.Add(lblInternationalLicensesRecords);
            Controls.Add(label5);
            Controls.Add(dgvInternationalLicenses);
            Controls.Add(pictureBox1);
            Controls.Add(btnNewApplication);
            Controls.Add(btnClose);
            Controls.Add(pbPersonImage);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmListInternationalLicenses";
            Text = "frmListInternationalLicenses";
            Load += frmListInternationalLicenses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicenses).EndInit();
            cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInternationalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNewApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem PesonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}