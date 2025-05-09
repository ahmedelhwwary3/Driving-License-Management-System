namespace PresentationLayer.Drivers
{
    partial class frmListDrivers
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
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            label1 = new Label();
            lblTitle = new Label();
            lblRecordsCount = new Label();
            label2 = new Label();
            dgvDrivers = new DataGridView();
            cmsDrivers = new ContextMenuStrip(components);
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            btnClose = new Button();
            pbDriverImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            cmsDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDriverImage).BeginInit();
            SuspendLayout();
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Left;
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Driver ID", "Person ID", "National No.", "Full Name" });
            cbFilterBy.Location = new Point(104, 351);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(244, 23);
            cbFilterBy.TabIndex = 135;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Anchor = AnchorStyles.None;
            txtFilterValue.BorderStyle = BorderStyle.FixedSingle;
            txtFilterValue.Location = new Point(357, 351);
            txtFilterValue.Margin = new Padding(5, 6, 5, 6);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(298, 23);
            txtFilterValue.TabIndex = 134;
            txtFilterValue.Visible = false;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 354);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 133;
            label1.Text = "Filter By:";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(424, 273);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(520, 45);
            lblTitle.TabIndex = 132;
            lblTitle.Text = "Manage Drivers";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Anchor = AnchorStyles.Left;
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Location = new Point(126, 819);
            lblRecordsCount.Margin = new Padding(4, 0, 4, 0);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(17, 15);
            lblRecordsCount.TabIndex = 130;
            lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 819);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 129;
            label2.Text = "# Records:";
            // 
            // dgvDrivers
            // 
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AllowUserToDeleteRows = false;
            dgvDrivers.AllowUserToResizeRows = false;
            dgvDrivers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDrivers.BackgroundColor = Color.White;
            dgvDrivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrivers.ContextMenuStrip = cmsDrivers;
            dgvDrivers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDrivers.Location = new Point(5, 393);
            dgvDrivers.Margin = new Padding(5, 6, 5, 6);
            dgvDrivers.MultiSelect = false;
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDrivers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrivers.Size = new Size(1280, 408);
            dgvDrivers.TabIndex = 128;
            dgvDrivers.TabStop = false;
            dgvDrivers.DataBindingComplete += dgvDrivers_DataBindingComplete;
            // 
            // cmsDrivers
            // 
            cmsDrivers.Items.AddRange(new ToolStripItem[] { showDetailsToolStripMenuItem, toolStripSeparator2, showPersonLicenseHistoryToolStripMenuItem });
            cmsDrivers.Name = "contextMenuStrip1";
            cmsDrivers.Size = new Size(242, 86);
            cmsDrivers.Opening += cmsDrivers_Opening;
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = Properties.Resources.Person_32;
            showDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(241, 38);
            showDetailsToolStripMenuItem.Text = "&Show Person Info";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click_1;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(238, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = Properties.Resources.PersonLicenseHistory_32;
            showPersonLicenseHistoryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(241, 38);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.AutoEllipsis = true;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(1127, 811);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(158, 42);
            btnClose.TabIndex = 127;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // pbDriverImage
            // 
            pbDriverImage.Anchor = AnchorStyles.None;
            pbDriverImage.BackgroundImageLayout = ImageLayout.Zoom;
            pbDriverImage.Image = Properties.Resources.Driver_Main;
            pbDriverImage.InitialImage = null;
            pbDriverImage.Location = new Point(505, 16);
            pbDriverImage.Margin = new Padding(5, 6, 5, 6);
            pbDriverImage.Name = "pbDriverImage";
            pbDriverImage.Size = new Size(359, 252);
            pbDriverImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbDriverImage.TabIndex = 131;
            pbDriverImage.TabStop = false;
            // 
            // frmListDrivers
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1294, 860);
            Controls.Add(cbFilterBy);
            Controls.Add(txtFilterValue);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(lblRecordsCount);
            Controls.Add(label2);
            Controls.Add(dgvDrivers);
            Controls.Add(pbDriverImage);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmListDrivers";
            Text = "frmListDrivers";
            Load += frmListDrivers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            cmsDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbDriverImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.PictureBox pbDriverImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsDrivers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}