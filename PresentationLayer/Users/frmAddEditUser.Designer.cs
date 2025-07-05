namespace PresentationLayer.Users
{
    partial class frmAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            lblAddEditUser = new Label();
            tcAddNewUser = new TabControl();
            tpPersonInfo = new TabPage();
            ctrlPersonCardWithFilter1 = new People.ctrlPersonCardWithFilter();
            btnNext = new Button();
            tpLoginInfo = new TabPage();
            btnGiveAdministrator = new Button();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            label5 = new Label();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            txtManagerID = new TextBox();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            cbHierarcky = new ComboBox();
            treePermissions = new TreeView();
            imageList1 = new ImageList(components);
            label1 = new Label();
            pictureBox5 = new PictureBox();
            chkIsActive = new CheckBox();
            txtUserName = new TextBox();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            btnClose = new Button();
            btnSave = new Button();
            tcAddNewUser.SuspendLayout();
            tpPersonInfo.SuspendLayout();
            tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblAddEditUser
            // 
            lblAddEditUser.AutoSize = true;
            lblAddEditUser.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEditUser.ForeColor = Color.FromArgb(192, 0, 0);
            lblAddEditUser.Location = new Point(499, 10);
            lblAddEditUser.Margin = new Padding(4, 0, 4, 0);
            lblAddEditUser.Name = "lblAddEditUser";
            lblAddEditUser.Size = new Size(228, 37);
            lblAddEditUser.TabIndex = 6;
            lblAddEditUser.Tag = "MainTitle";
            lblAddEditUser.Text = "Add Edit User";
            // 
            // tcAddNewUser
            // 
            tcAddNewUser.Controls.Add(tpPersonInfo);
            tcAddNewUser.Controls.Add(tpLoginInfo);
            tcAddNewUser.Location = new Point(22, 57);
            tcAddNewUser.Margin = new Padding(4, 3, 4, 3);
            tcAddNewUser.Name = "tcAddNewUser";
            tcAddNewUser.SelectedIndex = 0;
            tcAddNewUser.Size = new Size(1210, 661);
            tcAddNewUser.TabIndex = 5;
            // 
            // tpPersonInfo
            // 
            tpPersonInfo.BackColor = Color.White;
            tpPersonInfo.Controls.Add(ctrlPersonCardWithFilter1);
            tpPersonInfo.Controls.Add(btnNext);
            tpPersonInfo.Location = new Point(4, 24);
            tpPersonInfo.Margin = new Padding(4, 3, 4, 3);
            tpPersonInfo.Name = "tpPersonInfo";
            tpPersonInfo.Padding = new Padding(4, 3, 4, 3);
            tpPersonInfo.Size = new Size(1202, 633);
            tpPersonInfo.TabIndex = 0;
            tpPersonInfo.Text = "Person Info";
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.BackColor = Color.White;
            ctrlPersonCardWithFilter1.FilterEnabled = true;
            ctrlPersonCardWithFilter1.Location = new Point(22, 57);
            ctrlPersonCardWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.ShowAddPerson = true;
            ctrlPersonCardWithFilter1.Size = new Size(1150, 503);
            ctrlPersonCardWithFilter1.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Image = Properties.Resources.Next_32;
            btnNext.Location = new Point(932, 563);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(161, 48);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tpLoginInfo
            // 
            tpLoginInfo.BackColor = Color.White;
            tpLoginInfo.Controls.Add(btnGiveAdministrator);
            tpLoginInfo.Controls.Add(txtConfirmPassword);
            tpLoginInfo.Controls.Add(txtPassword);
            tpLoginInfo.Controls.Add(label5);
            tpLoginInfo.Controls.Add(label4);
            tpLoginInfo.Controls.Add(pictureBox4);
            tpLoginInfo.Controls.Add(pictureBox3);
            tpLoginInfo.Controls.Add(txtManagerID);
            tpLoginInfo.Controls.Add(label8);
            tpLoginInfo.Controls.Add(pictureBox7);
            tpLoginInfo.Controls.Add(label7);
            tpLoginInfo.Controls.Add(pictureBox6);
            tpLoginInfo.Controls.Add(cbHierarcky);
            tpLoginInfo.Controls.Add(treePermissions);
            tpLoginInfo.Controls.Add(label1);
            tpLoginInfo.Controls.Add(pictureBox5);
            tpLoginInfo.Controls.Add(chkIsActive);
            tpLoginInfo.Controls.Add(txtUserName);
            tpLoginInfo.Controls.Add(label6);
            tpLoginInfo.Controls.Add(label3);
            tpLoginInfo.Controls.Add(label2);
            tpLoginInfo.Controls.Add(pictureBox2);
            tpLoginInfo.Controls.Add(pictureBox1);
            tpLoginInfo.Location = new Point(4, 24);
            tpLoginInfo.Margin = new Padding(4, 3, 4, 3);
            tpLoginInfo.Name = "tpLoginInfo";
            tpLoginInfo.Padding = new Padding(4, 3, 4, 3);
            tpLoginInfo.Size = new Size(1202, 633);
            tpLoginInfo.TabIndex = 1;
            tpLoginInfo.Text = "Login Info";
            // 
            // btnGiveAdministrator
            // 
            btnGiveAdministrator.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGiveAdministrator.ForeColor = Color.Red;
            btnGiveAdministrator.Location = new Point(600, 376);
            btnGiveAdministrator.Name = "btnGiveAdministrator";
            btnGiveAdministrator.Size = new Size(196, 62);
            btnGiveAdministrator.TabIndex = 36;
            btnGiveAdministrator.Text = "Give Administrator Access";
            btnGiveAdministrator.UseVisualStyleBackColor = true;
            btnGiveAdministrator.Click += btnGiveAdministrator_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(276, 338);
            txtConfirmPassword.Margin = new Padding(4, 3, 4, 3);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(301, 23);
            txtConfirmPassword.TabIndex = 31;
            txtConfirmPassword.Validating += txtConfirmPassword_Validating;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(276, 278);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(301, 23);
            txtPassword.TabIndex = 30;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 340);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(163, 20);
            label5.TabIndex = 33;
            label5.Text = "Confirm Password :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(89, 279);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 32;
            label4.Text = "Password :";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Password_321;
            pictureBox4.Location = new Point(214, 338);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(37, 23);
            pictureBox4.TabIndex = 35;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Password_32;
            pictureBox3.Location = new Point(214, 278);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 23);
            pictureBox3.TabIndex = 34;
            pictureBox3.TabStop = false;
            // 
            // txtManagerID
            // 
            txtManagerID.Location = new Point(275, 461);
            txtManagerID.Name = "txtManagerID";
            txtManagerID.Size = new Size(302, 23);
            txtManagerID.TabIndex = 29;
            txtManagerID.KeyPress += txtManagerID_KeyPress;
            txtManagerID.Validating += txtManagerID_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(77, 460);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 27;
            label8.Text = "ManagerID :";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.Password_321;
            pictureBox7.Location = new Point(214, 457);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(37, 23);
            pictureBox7.TabIndex = 28;
            pictureBox7.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(90, 399);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 25;
            label7.Text = "Hierarchy :";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Password_321;
            pictureBox6.Location = new Point(214, 396);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(37, 23);
            pictureBox6.TabIndex = 26;
            pictureBox6.TabStop = false;
            // 
            // cbHierarcky
            // 
            cbHierarcky.FormattingEnabled = true;
            cbHierarcky.Location = new Point(276, 399);
            cbHierarcky.Name = "cbHierarcky";
            cbHierarcky.Size = new Size(301, 23);
            cbHierarcky.TabIndex = 24;
            cbHierarcky.SelectedIndexChanged += cbHierarcky_SelectedIndexChanged;
            cbHierarcky.Validating += cbHierarcky_Validating;
            // 
            // treePermissions
            // 
            treePermissions.CheckBoxes = true;
            treePermissions.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            treePermissions.ImageIndex = 0;
            treePermissions.ImageList = imageList1;
            treePermissions.Location = new Point(805, 160);
            treePermissions.Name = "treePermissions";
            treePermissions.SelectedImageIndex = 0;
            treePermissions.Size = new Size(354, 324);
            treePermissions.TabIndex = 16;
            treePermissions.TabStop = false;
            treePermissions.BeforeCheck += treePermissions_BeforeCheck;
            treePermissions.AfterCheck += treePermissions_AfterCheck;
            treePermissions.Validating += treePermissions_Validating;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "bin.png");
            imageList1.Images.SetKeyName(1, "updated.png");
            imageList1.Images.SetKeyName(2, "settings.png");
            imageList1.Images.SetKeyName(3, "eye.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(622, 167);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 15;
            label1.Text = "Permissions :";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(766, 160);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 33);
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(322, 530);
            chkIsActive.Margin = new Padding(4, 3, 4, 3);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(70, 19);
            chkIsActive.TabIndex = 12;
            chkIsActive.Text = "Is Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(277, 217);
            txtUserName.Margin = new Padding(4, 3, 4, 3);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(301, 23);
            txtUserName.TabIndex = 0;
            txtUserName.KeyPress += txtUserName_KeyPress;
            txtUserName.Validating += txtUserName_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 0);
            label6.Location = new Point(360, 161);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 8;
            label6.Text = "???";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(78, 216);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 1;
            label3.Text = "User Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(105, 161);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 0;
            label2.Text = "User ID :";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.User_32__22;
            pictureBox2.Location = new Point(215, 214);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 23);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.User_32__21;
            pictureBox1.Location = new Point(215, 160);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 23);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(887, 728);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(161, 48);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.Save_32;
            btnSave.Location = new Point(1055, 728);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(161, 48);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmAddEditUser
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1258, 790);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(lblAddEditUser);
            Controls.Add(tcAddNewUser);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmAddEditUser";
            Text = "frmAddEditUser";
            Load += frmAddEditUser_Load;
            tcAddNewUser.ResumeLayout(false);
            tpPersonInfo.ResumeLayout(false);
            tpLoginInfo.ResumeLayout(false);
            tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAddEditUser;
        private System.Windows.Forms.TabControl tcAddNewUser;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private PictureBox pictureBox5;
        private Label label1;
        private TreeView treePermissions;
        private ImageList imageList1;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private Label label5;
        private Label label4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private TextBox txtManagerID;
        private Label label8;
        private PictureBox pictureBox7;
        private Label label7;
        private PictureBox pictureBox6;
        private ComboBox cbHierarcky;
        private Button btnGiveAdministrator;
    }
}