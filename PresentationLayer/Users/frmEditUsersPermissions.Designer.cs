namespace PresentationLayer.Users
{
    partial class frmEditUsersPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUsersPermissions));
            label2 = new Label();
            txtAddPermissions = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            btnRemove = new Button();
            lbxAddPermissions = new ListBox();
            btnAdd = new Button();
            imageList1 = new ImageList(components);
            label1 = new Label();
            chkDeletePermissions = new CheckedListBox();
            splitter1 = new Splitter();
            btnClose = new Button();
            btnSave = new Button();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(467, 26);
            label2.Name = "label2";
            label2.Size = new Size(230, 37);
            label2.TabIndex = 2;
            label2.Text = "Add permissions";
            // 
            // txtAddPermissions
            // 
            txtAddPermissions.Location = new Point(456, 92);
            txtAddPermissions.Name = "txtAddPermissions";
            txtAddPermissions.Size = new Size(190, 23);
            txtAddPermissions.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(192, 0, 0);
            label3.Location = new Point(160, 29);
            label3.Name = "label3";
            label3.Size = new Size(569, 47);
            label3.TabIndex = 4;
            label3.Tag = "MainTitle";
            label3.Text = "Manage Non-System Permissions";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemove);
            panel1.Controls.Add(lbxAddPermissions);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(chkDeletePermissions);
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(txtAddPermissions);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(46, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(789, 298);
            panel1.TabIndex = 5;
            // 
            // btnRemove
            // 
            btnRemove.Image = Properties.Resources.Close_32;
            btnRemove.Location = new Point(708, 87);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(41, 37);
            btnRemove.TabIndex = 41;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // lbxAddPermissions
            // 
            lbxAddPermissions.FormattingEnabled = true;
            lbxAddPermissions.ItemHeight = 15;
            lbxAddPermissions.Location = new Point(456, 141);
            lbxAddPermissions.Name = "lbxAddPermissions";
            lbxAddPermissions.Size = new Size(293, 94);
            lbxAddPermissions.TabIndex = 42;
            // 
            // btnAdd
            // 
            btnAdd.ImageKey = "plus.png";
            btnAdd.ImageList = imageList1;
            btnAdd.Location = new Point(656, 87);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(41, 37);
            btnAdd.TabIndex = 40;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "plus.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(62, 26);
            label1.Name = "label1";
            label1.Size = new Size(260, 37);
            label1.TabIndex = 6;
            label1.Text = "Delete Permissions";
            // 
            // chkDeletePermissions
            // 
            chkDeletePermissions.FormattingEnabled = true;
            chkDeletePermissions.Location = new Point(52, 105);
            chkDeletePermissions.Name = "chkDeletePermissions";
            chkDeletePermissions.ScrollAlwaysVisible = true;
            chkDeletePermissions.Size = new Size(281, 130);
            chkDeletePermissions.TabIndex = 5;
            chkDeletePermissions.Validating += chkDeletePermissions_Validating;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(391, 298);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(548, 454);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(133, 57);
            btnClose.TabIndex = 39;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.Save_32;
            btnSave.Location = new Point(702, 454);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 57);
            btnSave.TabIndex = 38;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmEditUsersPermissions
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(880, 535);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEditUsersPermissions";
            Text = "frmEditUsersPeramissions";
            Load += frmEditUsersPermissions_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label label2;
        private TextBox txtAddPermissions;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private CheckedListBox chkDeletePermissions;
        private Splitter splitter1;
        private Button btnClose;
        private Button btnSave;
        private ImageList imageList1;
        private ListBox lbxAddPermissions;
        private Button btnAdd;
        private Button btnRemove;
        private ErrorProvider errorProvider1;
    }
}