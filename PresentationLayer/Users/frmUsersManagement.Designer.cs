namespace PresentationLayer.Users
{
    partial class frmUsersManagement
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
            label2 = new Label();
            dgvUsers = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            addNewUserToolStripMenuItem = new ToolStripSeparator();
            addNewUserToolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            sendSMSToolStripMenuItem = new ToolStripMenuItem();
            btnClose = new Button();
            lblRecords = new Label();
            label3 = new Label();
            label1 = new Label();
            cbFilterColumn = new ComboBox();
            cbIsActive = new ComboBox();
            txtFilterValue = new TextBox();
            pictureBox1 = new PictureBox();
            btnAddNewUser = new Button();
            btnSendEmailToAll = new Button();
            txtEmail = new TextBox();
            rbUsers = new RadioButton();
            rbPeople = new RadioButton();
            groupBox2 = new GroupBox();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(580, 242);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(254, 39);
            label2.TabIndex = 22;
            label2.Tag = "MainTitle";
            label2.Text = "Manage Users";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.ContextMenuStrip = contextMenuStrip1;
            dgvUsers.Location = new Point(12, 336);
            dgvUsers.Margin = new Padding(4, 3, 4, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.Size = new Size(1352, 376);
            dgvUsers.TabIndex = 21;
            dgvUsers.DataBindingComplete += dgvUsers_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showDetailsToolStripMenuItem, addNewUserToolStripMenuItem, addNewUserToolStripMenuItem1, editToolStripMenuItem, deleteToolStripMenuItem, changePasswordToolStripMenuItem, toolStripMenuItem1, sendEmailToolStripMenuItem, sendSMSToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(185, 282);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = Properties.Resources.PersonDetails_321;
            showDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(184, 38);
            showDetailsToolStripMenuItem.Text = "Show Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // addNewUserToolStripMenuItem
            // 
            addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            addNewUserToolStripMenuItem.Size = new Size(181, 6);
            // 
            // addNewUserToolStripMenuItem1
            // 
            addNewUserToolStripMenuItem1.Image = Properties.Resources.Add_New_User_32;
            addNewUserToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            addNewUserToolStripMenuItem1.Name = "addNewUserToolStripMenuItem1";
            addNewUserToolStripMenuItem1.Size = new Size(184, 38);
            addNewUserToolStripMenuItem1.Text = "Add New User";
            addNewUserToolStripMenuItem1.Click += addNewUserToolStripMenuItem1_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_32;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(184, 38);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Delete_32_2;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(184, 38);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Image = Properties.Resources.Password_32;
            changePasswordToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(184, 38);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(181, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Image = Properties.Resources.Email_32;
            sendEmailToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(184, 38);
            sendEmailToolStripMenuItem.Text = "Send Email";
            sendEmailToolStripMenuItem.Click += sendEmailToolStripMenuItem_Click;
            // 
            // sendSMSToolStripMenuItem
            // 
            sendSMSToolStripMenuItem.Image = Properties.Resources.send_email_32;
            sendSMSToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendSMSToolStripMenuItem.Name = "sendSMSToolStripMenuItem";
            sendSMSToolStripMenuItem.Size = new Size(184, 38);
            sendSMSToolStripMenuItem.Text = "Send SMS";
            sendSMSToolStripMenuItem.Click += sendSMSToolStripMenuItem_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(1226, 730);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(138, 47);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblRecords
            // 
            lblRecords.Anchor = AnchorStyles.Left;
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecords.Location = new Point(138, 741);
            lblRecords.Margin = new Padding(4, 0, 4, 0);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(36, 20);
            lblRecords.TabIndex = 19;
            lblRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 741);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 18;
            label3.Text = "Records :";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 307);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 17;
            label1.Text = "Filter By :";
            // 
            // cbFilterColumn
            // 
            cbFilterColumn.Anchor = AnchorStyles.Left;
            cbFilterColumn.FormattingEnabled = true;
            cbFilterColumn.Items.AddRange(new object[] { "None", "User ID", "Person ID", "User Name", "Is Active", "Full Name", "Permissions" });
            cbFilterColumn.Location = new Point(125, 302);
            cbFilterColumn.Margin = new Padding(4, 3, 4, 3);
            cbFilterColumn.Name = "cbFilterColumn";
            cbFilterColumn.Size = new Size(284, 23);
            cbFilterColumn.TabIndex = 16;
            cbFilterColumn.SelectedIndexChanged += cbFilterColumn_SelectedIndexChanged;
            // 
            // cbIsActive
            // 
            cbIsActive.Anchor = AnchorStyles.Right;
            cbIsActive.FormattingEnabled = true;
            cbIsActive.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsActive.Location = new Point(490, 302);
            cbIsActive.Margin = new Padding(4, 3, 4, 3);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(167, 23);
            cbIsActive.TabIndex = 15;
            cbIsActive.SelectedIndexChanged += cbIsActive_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Anchor = AnchorStyles.None;
            txtFilterValue.Location = new Point(508, 302);
            txtFilterValue.Margin = new Padding(4, 3, 4, 3);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(294, 23);
            txtFilterValue.TabIndex = 14;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Users_2_400;
            pictureBox1.Location = new Point(597, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.Anchor = AnchorStyles.Right;
            btnAddNewUser.Image = Properties.Resources.Add_New_User_321;
            btnAddNewUser.Location = new Point(1293, 264);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.Size = new Size(71, 63);
            btnAddNewUser.TabIndex = 23;
            btnAddNewUser.UseVisualStyleBackColor = true;
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // btnSendEmailToAll
            // 
            btnSendEmailToAll.Location = new Point(348, 26);
            btnSendEmailToAll.Name = "btnSendEmailToAll";
            btnSendEmailToAll.Size = new Size(111, 38);
            btnSendEmailToAll.TabIndex = 28;
            btnSendEmailToAll.Text = "Send";
            btnSendEmailToAll.UseVisualStyleBackColor = true;
            btnSendEmailToAll.Click += btnSendEmailToAll_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(21, 67);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.ScrollBars = ScrollBars.Both;
            txtEmail.Size = new Size(312, 85);
            txtEmail.TabIndex = 29;
            // 
            // rbUsers
            // 
            rbUsers.AutoSize = true;
            rbUsers.Checked = true;
            rbUsers.Location = new Point(21, 36);
            rbUsers.Name = "rbUsers";
            rbUsers.Size = new Size(85, 19);
            rbUsers.TabIndex = 30;
            rbUsers.TabStop = true;
            rbUsers.Text = "To All Users";
            rbUsers.UseVisualStyleBackColor = true;
            rbUsers.CheckedChanged += rbUsers_CheckedChanged;
            // 
            // rbPeople
            // 
            rbPeople.AutoSize = true;
            rbPeople.Location = new Point(161, 36);
            rbPeople.Name = "rbPeople";
            rbPeople.Size = new Size(93, 19);
            rbPeople.TabIndex = 31;
            rbPeople.Text = "To All People";
            rbPeople.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnView);
            groupBox2.Controls.Add(rbPeople);
            groupBox2.Controls.Add(rbUsers);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(btnSendEmailToAll);
            groupBox2.Location = new Point(30, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(476, 175);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "Send Mail";
            // 
            // btnView
            // 
            btnView.Location = new Point(348, 101);
            btnView.Name = "btnView";
            btnView.Size = new Size(111, 37);
            btnView.TabIndex = 33;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // frmUsersManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1378, 787);
            Controls.Add(groupBox2);
            Controls.Add(btnAddNewUser);
            Controls.Add(label2);
            Controls.Add(dgvUsers);
            Controls.Add(btnClose);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cbFilterColumn);
            Controls.Add(cbIsActive);
            Controls.Add(txtFilterValue);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmUsersManagement";
            Text = "frmUsersManagement";
            Load += frmUsersManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSMSToolStripMenuItem;
        private Button btnAddNewUser;
        private Button btnSendEmailToAll;
        private TextBox txtEmail;
        private RadioButton rbUsers;
        private RadioButton rbPeople;
        private GroupBox groupBox2;
        private Button btnView;
    }
}