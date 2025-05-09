namespace PresentationLayer.Login
{
    partial class frmListOperationLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListOperationLogs));
            btnClose = new Button();
            txtFilterValue = new TextBox();
            dgvLogs = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            downloadAllRecordToolStripMenuItem = new ToolStripMenuItem();
            downloadAllRecordsToolStripMenuItem = new ToolStripMenuItem();
            lblTotalRecords = new Label();
            label3 = new Label();
            cbFilterBy = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            saveFileDialog1 = new SaveFileDialog();
            cbAction = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(1137, 740);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 59);
            btnClose.TabIndex = 76;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Anchor = AnchorStyles.None;
            txtFilterValue.Location = new Point(507, 296);
            txtFilterValue.Margin = new Padding(4, 3, 4, 3);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(247, 23);
            txtFilterValue.TabIndex = 75;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.Anchor = AnchorStyles.None;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.ContextMenuStrip = contextMenuStrip1;
            dgvLogs.Location = new Point(7, 343);
            dgvLogs.Margin = new Padding(4, 3, 4, 3);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.Size = new Size(1266, 396);
            dgvLogs.TabIndex = 74;
            dgvLogs.DataBindingComplete += dgvLogs_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { downloadAllRecordToolStripMenuItem, downloadAllRecordsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(245, 80);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // downloadAllRecordToolStripMenuItem
            // 
            downloadAllRecordToolStripMenuItem.Image = Properties.Resources.Notes_32;
            downloadAllRecordToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            downloadAllRecordToolStripMenuItem.Name = "downloadAllRecordToolStripMenuItem";
            downloadAllRecordToolStripMenuItem.Size = new Size(244, 38);
            downloadAllRecordToolStripMenuItem.Text = "Download Full Record Details";
            downloadAllRecordToolStripMenuItem.Click += downloadAllRecordToolStripMenuItem_Click;
            // 
            // downloadAllRecordsToolStripMenuItem
            // 
            downloadAllRecordsToolStripMenuItem.Image = Properties.Resources.Notes_32;
            downloadAllRecordsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            downloadAllRecordsToolStripMenuItem.Name = "downloadAllRecordsToolStripMenuItem";
            downloadAllRecordsToolStripMenuItem.Size = new Size(244, 38);
            downloadAllRecordsToolStripMenuItem.Text = "Download All Records Details";
            downloadAllRecordsToolStripMenuItem.Click += downloadAllRecordsToolStripMenuItem_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.Anchor = AnchorStyles.None;
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRecords.Location = new Point(136, 769);
            lblTotalRecords.Margin = new Padding(4, 0, 4, 0);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(51, 25);
            lblTotalRecords.TabIndex = 73;
            lblTotalRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 769);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 72;
            label3.Text = "Records:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.None;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Log ID", "Logged User ID", "Action", "Table Name" });
            cbFilterBy.Location = new Point(166, 296);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(247, 23);
            cbFilterBy.TabIndex = 71;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 294);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 70;
            label2.Text = "Filter By:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(540, 233);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(214, 33);
            label1.TabIndex = 69;
            label1.Text = "Operation Logs";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Users_2_400;
            pictureBox1.Location = new Point(516, 7);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 68;
            pictureBox1.TabStop = false;
            // 
            // cbGender
            // 
            cbAction.Anchor = AnchorStyles.Left;
            cbAction.FormattingEnabled = true;
            cbAction.Items.AddRange(new object[] { "All", "AddNew", "Update", "Delete" });
            cbAction.Location = new Point(497, 296);
            cbAction.Margin = new Padding(4, 3, 4, 3);
            cbAction.Name = "cbGender";
            cbAction.Size = new Size(162, 23);
            cbAction.TabIndex = 77;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;
            // 
            // frmListOperationLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1281, 807);
            Controls.Add(cbAction);
            Controls.Add(btnClose);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvLogs);
            Controls.Add(lblTotalRecords);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "frmListOperationLogs";
            Text = "frmListOperationLogs";
            Load += frmListOperationLogs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private TextBox txtFilterValue;
        private DataGridView dgvLogs;
        private Label lblTotalRecords;
        private Label label3;
        private ComboBox cbFilterBy;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private SaveFileDialog saveFileDialog1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem downloadAllRecordToolStripMenuItem;
        private ToolStripMenuItem downloadAllRecordsToolStripMenuItem;
        private ComboBox cbAction;
    }
}