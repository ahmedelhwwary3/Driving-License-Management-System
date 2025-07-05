namespace PresentationLayer.Applications.ReleaseDetainedLicense
{
    partial class frmListDetainedLicenses
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
            btnReleaseDetainedLicense = new Button();
            cbIsReleased = new ComboBox();
            btnDetainLicense = new Button();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            label1 = new Label();
            btnClose = new Button();
            lblTotalRecords = new Label();
            label5 = new Label();
            dgvDetainedLicenses = new DataGridView();
            cmsApplications = new ContextMenuStrip(components);
            PesonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            releaseDetainedLicenseToolStripMenuItem = new ToolStripMenuItem();
            lblTitle = new Label();
            pbPersonImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetainedLicenses).BeginInit();
            cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            SuspendLayout();
            // 
            // btnReleaseDetainedLicense
            // 
            btnReleaseDetainedLicense.FlatStyle = FlatStyle.Flat;
            btnReleaseDetainedLicense.Image = Properties.Resources.Release_Detained_License_321;
            btnReleaseDetainedLicense.Location = new Point(1387, 280);
            btnReleaseDetainedLicense.Margin = new Padding(4, 3, 4, 3);
            btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            btnReleaseDetainedLicense.Size = new Size(103, 87);
            btnReleaseDetainedLicense.TabIndex = 172;
            btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            btnReleaseDetainedLicense.Click += btnReleaseDetainedLicense_Click;
            // 
            // cbIsReleased
            // 
            cbIsReleased.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsReleased.FormattingEnabled = true;
            cbIsReleased.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsReleased.Location = new Point(349, 335);
            cbIsReleased.Margin = new Padding(4, 3, 4, 3);
            cbIsReleased.Name = "cbIsReleased";
            cbIsReleased.Size = new Size(140, 23);
            cbIsReleased.TabIndex = 171;
            cbIsReleased.Visible = false;
            cbIsReleased.SelectedIndexChanged += cbIsReleased_SelectedIndexChanged;
            // 
            // btnDetainLicense
            // 
            btnDetainLicense.FlatStyle = FlatStyle.Flat;
            btnDetainLicense.Image = Properties.Resources.Detain_641;
            btnDetainLicense.Location = new Point(1497, 280);
            btnDetainLicense.Margin = new Padding(4, 3, 4, 3);
            btnDetainLicense.Name = "btnDetainLicense";
            btnDetainLicense.Size = new Size(103, 87);
            btnDetainLicense.TabIndex = 167;
            btnDetainLicense.UseVisualStyleBackColor = true;
            btnDetainLicense.Click += btnDetainLicense_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Detain ID", "Is Released", "National No.", "Full Name", "Release Application ID" });
            cbFilterBy.Location = new Point(97, 335);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(244, 23);
            cbFilterBy.TabIndex = 165;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BorderStyle = BorderStyle.FixedSingle;
            txtFilterValue.Location = new Point(350, 335);
            txtFilterValue.Margin = new Padding(5, 6, 5, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(298, 23);
            txtFilterValue.TabIndex = 164;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 338);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 163;
            label1.Text = "Filter By:";
            // 
            // btnClose
            // 
            btnClose.AutoEllipsis = true;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1442, 778);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(158, 42);
            btnClose.TabIndex = 161;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRecords.Location = new Point(122, 779);
            lblTotalRecords.Margin = new Padding(4, 0, 4, 0);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(24, 21);
            lblTotalRecords.TabIndex = 170;
            lblTotalRecords.Text = "??";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 779);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 169;
            label5.Text = " Records:";
            // 
            // dgvDetainedLicenses
            // 
            dgvDetainedLicenses.AllowUserToAddRows = false;
            dgvDetainedLicenses.AllowUserToDeleteRows = false;
            dgvDetainedLicenses.AllowUserToResizeRows = false;
            dgvDetainedLicenses.BackgroundColor = Color.White;
            dgvDetainedLicenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetainedLicenses.ContextMenuStrip = cmsApplications;
            dgvDetainedLicenses.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDetainedLicenses.Location = new Point(13, 376);
            dgvDetainedLicenses.Margin = new Padding(5, 6, 5, 6);
            dgvDetainedLicenses.MultiSelect = false;
            dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            dgvDetainedLicenses.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetainedLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetainedLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetainedLicenses.Size = new Size(1587, 392);
            dgvDetainedLicenses.TabIndex = 168;
            dgvDetainedLicenses.TabStop = false;
            // 
            // cmsApplications
            // 
            cmsApplications.Items.AddRange(new ToolStripItem[] { PesonDetailsToolStripMenuItem, showDetailsToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem, toolStripMenuItem1, releaseDetainedLicenseToolStripMenuItem });
            cmsApplications.Name = "contextMenuStrip1";
            cmsApplications.Size = new Size(242, 162);
            // 
            // PesonDetailsToolStripMenuItem
            // 
            PesonDetailsToolStripMenuItem.Image = Properties.Resources.Person_32;
            PesonDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            PesonDetailsToolStripMenuItem.Name = "PesonDetailsToolStripMenuItem";
            PesonDetailsToolStripMenuItem.Size = new Size(241, 38);
            PesonDetailsToolStripMenuItem.Text = "Show Person Details";
            PesonDetailsToolStripMenuItem.Click += PesonDetailsToolStripMenuItem_Click;
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = Properties.Resources.License_View_32;
            showDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(241, 38);
            showDetailsToolStripMenuItem.Text = "&Show License Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.License_Type_32;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(241, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(238, 6);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            releaseDetainedLicenseToolStripMenuItem.Image = Properties.Resources.Release_Detained_License_32;
            releaseDetainedLicenseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            releaseDetainedLicenseToolStripMenuItem.Size = new Size(241, 38);
            releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            releaseDetainedLicenseToolStripMenuItem.Click += releaseDetainedLicenseToolStripMenuItem_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(526, 228);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(663, 45);
            lblTitle.TabIndex = 162;
            lblTitle.Tag = "MainTitle";
            lblTitle.Text = "List Detained Licenses";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbPersonImage
            // 
            pbPersonImage.BackgroundImageLayout = ImageLayout.Zoom;
            pbPersonImage.Image = Properties.Resources.Detain_512;
            pbPersonImage.InitialImage = null;
            pbPersonImage.Location = new Point(738, 5);
            pbPersonImage.Margin = new Padding(5, 6, 5, 6);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(257, 218);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 166;
            pbPersonImage.TabStop = false;
            // 
            // frmListDetainedLicenses
            // 
            AcceptButton = btnDetainLicense;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1611, 832);
            Controls.Add(btnReleaseDetainedLicense);
            Controls.Add(cbIsReleased);
            Controls.Add(btnDetainLicense);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(pbPersonImage);
            Controls.Add(lblTotalRecords);
            Controls.Add(label5);
            Controls.Add(dgvDetainedLicenses);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmListDetainedLicenses";
            Text = "frmListDetainedLicenses";
            Load += frmListDetainedLicenses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetainedLicenses).EndInit();
            cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem PesonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}