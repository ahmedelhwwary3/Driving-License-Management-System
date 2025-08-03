namespace PresentationLayer.AddLogin
{
    partial class frmListOperationAddLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListOperationAddLogs));
            txtFilterValue = new TextBox();
            dgvAddLogs = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            downloadAllRecordToolStripMenuItem = new ToolStripMenuItem();
            textToolStripMenuItem = new ToolStripMenuItem();
            excelToolStripMenuItem = new ToolStripMenuItem();
            wordToolStripMenuItem = new ToolStripMenuItem();
            downloadAllRecordsToolStripMenuItem = new ToolStripMenuItem();
            textToolStripMenuItem1 = new ToolStripMenuItem();
            excelToolStripMenuItem1 = new ToolStripMenuItem();
            wordToolStripMenuItem1 = new ToolStripMenuItem();
            lblTotalRecords = new Label();
            label3 = new Label();
            cbFilterBy = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            saveFileDialog1 = new SaveFileDialog();
            cbAction = new ComboBox();
            notifyIcon1 = new NotifyIcon(components);
            btncLose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAddLogs).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            // dgvAddLogs
            // 
            dgvAddLogs.AllowUserToAddRows = false;
            dgvAddLogs.AllowUserToDeleteRows = false;
            dgvAddLogs.Anchor = AnchorStyles.None;
            dgvAddLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAddLogs.ContextMenuStrip = contextMenuStrip1;
            dgvAddLogs.Location = new Point(7, 343);
            dgvAddLogs.Margin = new Padding(4, 3, 4, 3);
            dgvAddLogs.Name = "dgvAddLogs";
            dgvAddLogs.ReadOnly = true;
            dgvAddLogs.Size = new Size(1266, 396);
            dgvAddLogs.TabIndex = 74;
            dgvAddLogs.DataBindingComplete += dgvAddLogs_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { downloadAllRecordToolStripMenuItem, downloadAllRecordsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(258, 80);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // downloadAllRecordToolStripMenuItem
            // 
            downloadAllRecordToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { textToolStripMenuItem, excelToolStripMenuItem, wordToolStripMenuItem });
            downloadAllRecordToolStripMenuItem.Image = Properties.Resources.Notes_32;
            downloadAllRecordToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            downloadAllRecordToolStripMenuItem.Name = "downloadAllRecordToolStripMenuItem";
            downloadAllRecordToolStripMenuItem.Size = new Size(257, 38);
            downloadAllRecordToolStripMenuItem.Text = "Download Full Record Details";
            // 
            // textToolStripMenuItem
            // 
            textToolStripMenuItem.Name = "textToolStripMenuItem";
            textToolStripMenuItem.Size = new Size(180, 22);
            textToolStripMenuItem.Text = "Text";
            textToolStripMenuItem.Click += textDownloadFull_Click;
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            excelToolStripMenuItem.Size = new Size(180, 22);
            excelToolStripMenuItem.Text = "Excel";
            excelToolStripMenuItem.Click += excelDownloadFull_Click;
            // 
            // wordToolStripMenuItem
            // 
            wordToolStripMenuItem.Name = "wordToolStripMenuItem";
            wordToolStripMenuItem.Size = new Size(180, 22);
            wordToolStripMenuItem.Text = "Word";
            wordToolStripMenuItem.Click += wordDownloadFull_Click;
            // 
            // downloadAllRecordsToolStripMenuItem
            // 
            downloadAllRecordsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { textToolStripMenuItem1, excelToolStripMenuItem1, wordToolStripMenuItem1 });
            downloadAllRecordsToolStripMenuItem.Image = Properties.Resources.Notes_32;
            downloadAllRecordsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            downloadAllRecordsToolStripMenuItem.Name = "downloadAllRecordsToolStripMenuItem";
            downloadAllRecordsToolStripMenuItem.Size = new Size(257, 38);
            downloadAllRecordsToolStripMenuItem.Text = "Download Single Record Details";
            // 
            // textToolStripMenuItem1
            // 
            textToolStripMenuItem1.Name = "textToolStripMenuItem1";
            textToolStripMenuItem1.Size = new Size(180, 22);
            textToolStripMenuItem1.Text = "Text";
            textToolStripMenuItem1.Click += textDownloadSingle_Click;
            // 
            // excelToolStripMenuItem1
            // 
            excelToolStripMenuItem1.Name = "excelToolStripMenuItem1";
            excelToolStripMenuItem1.Size = new Size(180, 22);
            excelToolStripMenuItem1.Text = "Excel";
            excelToolStripMenuItem1.Click += excelDownloadSingle_Click;
            // 
            // wordToolStripMenuItem1
            // 
            wordToolStripMenuItem1.Name = "wordToolStripMenuItem1";
            wordToolStripMenuItem1.Size = new Size(180, 22);
            wordToolStripMenuItem1.Text = "Word";
            wordToolStripMenuItem1.Click += wordDownloadSingle_Click;
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
            cbFilterBy.Items.AddRange(new object[] { "None", "AddLog ID", "AddLogged User ID", "Action", "Table Name" });
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
            label1.Text = "Operation AddLogs";
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
            // cbAction
            // 
            cbAction.Anchor = AnchorStyles.Left;
            cbAction.FormattingEnabled = true;
            cbAction.Items.AddRange(new object[] { "All", "AddNew", "Update", "Delete" });
            cbAction.Location = new Point(497, 296);
            cbAction.Margin = new Padding(4, 3, 4, 3);
            cbAction.Name = "cbAction";
            cbAction.Size = new Size(162, 23);
            cbAction.TabIndex = 77;
            cbAction.SelectedIndexChanged += cbAction_SelectedIndexChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "AddLog FIle";
            notifyIcon1.BalloonTipTitle = "File Downloaded";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // btncLose
            // 
            btncLose.Image = Properties.Resources.Close_32;
            btncLose.Location = new Point(1138, 756);
            btncLose.Name = "btncLose";
            btncLose.Size = new Size(131, 39);
            btncLose.TabIndex = 78;
            btncLose.UseVisualStyleBackColor = true;
            btncLose.Click += btncLose_Click;
            // 
            // frmListOperationAddLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1281, 807);
            Controls.Add(btncLose);
            Controls.Add(cbAction);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvAddLogs);
            Controls.Add(lblTotalRecords);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "frmListOperationAddLogs";
            Tag = "MainTitle";
            Text = "frmListOperationAddLogs";
            Load += frmListOperationAddLogs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAddLogs).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private TextBox txtFilterValue;
        private DataGridView dgvAddLogs;
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
        private NotifyIcon notifyIcon1;
        private Button btncLose;
        private ToolStripMenuItem textToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
        private ToolStripMenuItem wordToolStripMenuItem;
        private ToolStripMenuItem textToolStripMenuItem1;
        private ToolStripMenuItem excelToolStripMenuItem1;
        private ToolStripMenuItem wordToolStripMenuItem1;
    }
}