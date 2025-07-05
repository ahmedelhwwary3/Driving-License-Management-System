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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeopleManagement));
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
            btnNext = new Button();
            btnPrev = new Button();
            lblPageNumber = new Label();
            label5 = new Label();
            rbRowNumber = new RadioButton();
            rbRank = new RadioButton();
            rbDenseRank = new RadioButton();
            gbRankStyle = new GroupBox();
            imageList1 = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)dgvPeopleList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbRankStyle.SuspendLayout();
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
            contextMenuStrip1.Size = new Size(197, 266);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // showPersonToolStripMenuItem
            // 
            showPersonToolStripMenuItem.Image = Properties.Resources.PersonDetails_32;
            showPersonToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            showPersonToolStripMenuItem.Size = new Size(196, 38);
            showPersonToolStripMenuItem.Text = "Show Person Info";
            showPersonToolStripMenuItem.Click += showPersonToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(193, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            addNewPersonToolStripMenuItem.Image = Properties.Resources.AddPerson_32;
            addNewPersonToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            addNewPersonToolStripMenuItem.Size = new Size(196, 38);
            addNewPersonToolStripMenuItem.Text = "Add New Person";
            addNewPersonToolStripMenuItem.Click += addNewPersonToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Image = Properties.Resources.edit_32;
            editToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(196, 38);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Delete_32_2;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(196, 38);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(193, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Image = Properties.Resources.Email_32;
            sendEmailToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(196, 38);
            sendEmailToolStripMenuItem.Text = "Send Email";
            sendEmailToolStripMenuItem.Click += sendEmailToolStripMenuItem_Click;
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Image = Properties.Resources.Phone_32;
            phoneCallToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(196, 38);
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
            label1.Tag = "MainTitle";
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
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ImageIndex = 0;
            btnNext.ImageList = imageList1;
            btnNext.Location = new Point(1308, 236);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(100, 51);
            btnNext.TabIndex = 23;
            btnNext.Tag = "Fetch";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.Transparent;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.ImageIndex = 1;
            btnPrev.ImageList = imageList1;
            btnPrev.Location = new Point(1203, 236);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(99, 51);
            btnPrev.TabIndex = 24;
            btnPrev.Tag = "Fetch";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblPageNumber
            // 
            lblPageNumber.Anchor = AnchorStyles.Left;
            lblPageNumber.AutoSize = true;
            lblPageNumber.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageNumber.Location = new Point(488, 780);
            lblPageNumber.Margin = new Padding(4, 0, 4, 0);
            lblPageNumber.Name = "lblPageNumber";
            lblPageNumber.Size = new Size(51, 25);
            lblPageNumber.TabIndex = 26;
            lblPageNumber.Text = "???";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(396, 780);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 25);
            label5.TabIndex = 25;
            label5.Text = "Page:";
            // 
            // rbRowNumber
            // 
            rbRowNumber.AutoSize = true;
            rbRowNumber.Checked = true;
            rbRowNumber.Location = new Point(20, 26);
            rbRowNumber.Name = "rbRowNumber";
            rbRowNumber.Size = new Size(128, 19);
            rbRowNumber.TabIndex = 27;
            rbRowNumber.TabStop = true;
            rbRowNumber.Text = "Row Number On ID";
            rbRowNumber.UseVisualStyleBackColor = true;
            rbRowNumber.CheckedChanged += rbRowCount_CheckedChanged;
            // 
            // rbRank
            // 
            rbRank.AutoSize = true;
            rbRank.Location = new Point(20, 59);
            rbRank.Name = "rbRank";
            rbRank.Size = new Size(139, 19);
            rbRank.TabIndex = 28;
            rbRank.TabStop = true;
            rbRank.Text = "Rank On Year Of Birth";
            rbRank.UseVisualStyleBackColor = true;
            rbRank.CheckedChanged += rbRank_CheckedChanged;
            // 
            // rbDenseRank
            // 
            rbDenseRank.AutoSize = true;
            rbDenseRank.Location = new Point(20, 95);
            rbDenseRank.Name = "rbDenseRank";
            rbDenseRank.Size = new Size(174, 19);
            rbDenseRank.TabIndex = 29;
            rbDenseRank.TabStop = true;
            rbDenseRank.Text = "Dense Rank On Year Of Birth";
            rbDenseRank.UseVisualStyleBackColor = true;
            rbDenseRank.CheckedChanged += rbDenseRank_CheckedChanged;
            // 
            // gbRankStyle
            // 
            gbRankStyle.Controls.Add(rbDenseRank);
            gbRankStyle.Controls.Add(rbRank);
            gbRankStyle.Controls.Add(rbRowNumber);
            gbRankStyle.Location = new Point(933, 183);
            gbRankStyle.Name = "gbRankStyle";
            gbRankStyle.Size = new Size(210, 126);
            gbRankStyle.TabIndex = 30;
            gbRankStyle.TabStop = false;
            gbRankStyle.Text = "Rank Style";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "next.png");
            imageList1.Images.SetKeyName(1, "prev.png");
            // 
            // frmPeopleManagement
            // 
            AcceptButton = btnAddNewPerson;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1556, 818);
            Controls.Add(gbRankStyle);
            Controls.Add(lblPageNumber);
            Controls.Add(label5);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
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
            gbRankStyle.ResumeLayout(false);
            gbRankStyle.PerformLayout();
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
        private Button btnNext;
        private Button btnPrev;
        private Label lblPageNumber;
        private Label label5;
        private RadioButton rbRowNumber;
        private RadioButton rbRank;
        private RadioButton rbDenseRank;
        private GroupBox gbRankStyle;
        private ImageList imageList1;
    }
}