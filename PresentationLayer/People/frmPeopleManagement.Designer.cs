namespace PresentationLayer.People
{
    partial class frmPeopleManagement
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
            txtFilterValue = new TextBox();
            dgvPeopleList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showPersonToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            addNewPersonToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            phoneCallToolStripMenuItem = new ToolStripMenuItem();
            lblTotalRecords = new Label();
            label3 = new Label();
            cbFilterBy = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnClose = new Button();
            btnAddNewPerson = new Button();
            cbGendor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPeopleList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtFilterValue
            // 
            txtFilterValue.Anchor = AnchorStyles.None;
            txtFilterValue.Location = new Point(427, 288);
            txtFilterValue.Margin = new Padding(4, 3, 4, 3);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(247, 23);
            txtFilterValue.TabIndex = 19;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // dgvPeopleList
            // 
            dgvPeopleList.AllowUserToAddRows = false;
            dgvPeopleList.AllowUserToDeleteRows = false;
            dgvPeopleList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPeopleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeopleList.ContextMenuStrip = contextMenuStrip1;
            dgvPeopleList.Location = new Point(7, 321);
            dgvPeopleList.Margin = new Padding(4, 3, 4, 3);
            dgvPeopleList.Name = "dgvPeopleList";
            dgvPeopleList.ReadOnly = true;
            dgvPeopleList.Size = new Size(1545, 419);
            dgvPeopleList.TabIndex = 18;
            dgvPeopleList.DataBindingComplete += dgvPeopleList_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showPersonToolStripMenuItem, toolStripMenuItem1, addNewPersonToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem, toolStripMenuItem2, sendEmailToolStripMenuItem, phoneCallToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(183, 244);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // showPersonToolStripMenuItem
            // 
            showPersonToolStripMenuItem.Image = Properties.Resources.PersonDetails_32;
            showPersonToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            showPersonToolStripMenuItem.Size = new Size(182, 38);
            showPersonToolStripMenuItem.Text = "Show Person Info";
            showPersonToolStripMenuItem.Click += showPersonToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(179, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            addNewPersonToolStripMenuItem.Image = Properties.Resources.AddPerson_32;
            addNewPersonToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            addNewPersonToolStripMenuItem.Size = new Size(182, 38);
            addNewPersonToolStripMenuItem.Text = "Add New Person";
            addNewPersonToolStripMenuItem.Click += addNewPersonToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_32;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(182, 38);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Delete_32_2;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(182, 38);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(179, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Image = Properties.Resources.Email_32;
            sendEmailToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(182, 38);
            sendEmailToolStripMenuItem.Text = "Send Email";
            sendEmailToolStripMenuItem.Click += sendEmailToolStripMenuItem_Click;
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Image = Properties.Resources.Phone_32;
            phoneCallToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(182, 38);
            phoneCallToolStripMenuItem.Text = "Phone Call";
            phoneCallToolStripMenuItem.Click += phoneCallToolStripMenuItem_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.Anchor = AnchorStyles.Left;
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRecords.Location = new Point(142, 780);
            lblTotalRecords.Margin = new Padding(4, 0, 4, 0);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(51, 25);
            lblTotalRecords.TabIndex = 17;
            lblTotalRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 780);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 16;
            label3.Text = "Records:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.Anchor = AnchorStyles.Left;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Person ID", "National No", "First Name", "Second Name", "Third Name", "Last Name", "Gendor Caption", "Address", "Phone", "Email", "Nationality" });
            cbFilterBy.Location = new Point(148, 288);
            cbFilterBy.Margin = new Padding(4, 3, 4, 3);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(247, 23);
            cbFilterBy.TabIndex = 13;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 284);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 12;
            label2.Text = "Filter By:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(615, 227);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(217, 33);
            label1.TabIndex = 11;
            label1.Text = "Manage People";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.People_400;
            pictureBox1.Location = new Point(616, 3);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_321;
            btnClose.Location = new Point(1395, 747);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 59);
            btnClose.TabIndex = 20;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClosing_Click;
            // 
            // btnAddNewPerson
            // 
            btnAddNewPerson.Anchor = AnchorStyles.Right;
            btnAddNewPerson.Image = Properties.Resources.AddPerson_321;
            btnAddNewPerson.Location = new Point(1458, 227);
            btnAddNewPerson.Name = "btnAddNewPerson";
            btnAddNewPerson.Size = new Size(86, 68);
            btnAddNewPerson.TabIndex = 21;
            btnAddNewPerson.UseVisualStyleBackColor = true;
            btnAddNewPerson.Click += btnAddNew_Click;
            // 
            // cbGendor
            // 
            cbGendor.Anchor = AnchorStyles.Left;
            cbGendor.FormattingEnabled = true;
            cbGendor.Items.AddRange(new object[] { "All", "Male", "Female" });
            cbGendor.Location = new Point(427, 286);
            cbGendor.Margin = new Padding(4, 3, 4, 3);
            cbGendor.Name = "cbGendor";
            cbGendor.Size = new Size(162, 23);
            cbGendor.TabIndex = 22;
            cbGendor.SelectedIndexChanged += cbGender_SelectedIndexChanged;
            // 
            // frmPeopleManagement
            // 
            AcceptButton = btnAddNewPerson;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1556, 818);
            Controls.Add(cbGendor);
            Controls.Add(btnAddNewPerson);
            Controls.Add(btnClose);
            Controls.Add(txtFilterValue);
            Controls.Add(dgvPeopleList);
            Controls.Add(lblTotalRecords);
            Controls.Add(label3);
            Controls.Add(cbFilterBy);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmPeopleManagement";
            Text = "frmPeopleManagement";
            Load += frmPeopleManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPeopleList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.DataGridView dgvPeopleList;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private Button btnClose;
        private Button btnAddPerson;
        private Button btnAddNewPerson;
        private ComboBox cbGendor;
    }
}