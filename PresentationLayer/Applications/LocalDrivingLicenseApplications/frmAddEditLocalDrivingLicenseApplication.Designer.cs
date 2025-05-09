namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    partial class frmAddEditLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditLocalDrivingLicenseApplication));
            btnClose = new Button();
            btnSave = new Button();
            lblAddEditLocalDrivingLicenseApplication = new Label();
            tcAddNewUser = new TabControl();
            tpPersonInfo = new TabPage();
            ctrlPersonCardWithFilter1 = new People.ctrlPersonCardWithFilter();
            btnNext = new Button();
            tpApplicationInfo = new TabPage();
            pictureBox1 = new PictureBox();
            lblCreatedByUserName = new Label();
            lblApplicationFees = new Label();
            lblApplicationDate = new Label();
            cbLicenesClass = new ComboBox();
            pictureBox5 = new PictureBox();
            label1 = new Label();
            lblLocalDrivingLicenseApplicationID = new Label();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            errorProvider1 = new ErrorProvider(components);
            tcAddNewUser.SuspendLayout();
            tpPersonInfo.SuspendLayout();
            tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(835, 706);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(161, 48);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.Save_32;
            btnSave.Location = new Point(1015, 706);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(161, 48);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblAddEditLocalDrivingLicenseApplication
            // 
            lblAddEditLocalDrivingLicenseApplication.AutoSize = true;
            lblAddEditLocalDrivingLicenseApplication.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddEditLocalDrivingLicenseApplication.ForeColor = Color.FromArgb(192, 0, 0);
            lblAddEditLocalDrivingLicenseApplication.Location = new Point(215, 13);
            lblAddEditLocalDrivingLicenseApplication.Margin = new Padding(4, 0, 4, 0);
            lblAddEditLocalDrivingLicenseApplication.Name = "lblAddEditLocalDrivingLicenseApplication";
            lblAddEditLocalDrivingLicenseApplication.Size = new Size(660, 37);
            lblAddEditLocalDrivingLicenseApplication.TabIndex = 10;
            lblAddEditLocalDrivingLicenseApplication.Text = "Add Edit Local Driving License Application";
            // 
            // tcAddNewUser
            // 
            tcAddNewUser.Controls.Add(tpPersonInfo);
            tcAddNewUser.Controls.Add(tpApplicationInfo);
            tcAddNewUser.Location = new Point(9, 57);
            tcAddNewUser.Margin = new Padding(4, 3, 4, 3);
            tcAddNewUser.Name = "tcAddNewUser";
            tcAddNewUser.SelectedIndex = 0;
            tcAddNewUser.Size = new Size(1175, 640);
            tcAddNewUser.TabIndex = 9;
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
            tpPersonInfo.Size = new Size(1167, 612);
            tpPersonInfo.TabIndex = 0;
            tpPersonInfo.Text = "Person Info";
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.BackColor = Color.White;
            ctrlPersonCardWithFilter1.FilterEnabled = true;
            ctrlPersonCardWithFilter1.Location = new Point(6, 34);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.ShowAddPerson = true;
            ctrlPersonCardWithFilter1.Size = new Size(1153, 484);
            ctrlPersonCardWithFilter1.TabIndex = 2;
            ctrlPersonCardWithFilter1.OnPersonSelected += ctrlPersonCardWithFilter1_OnPersonSelected;
            // 
            // btnNext
            // 
            btnNext.Image = Properties.Resources.Next_32;
            btnNext.Location = new Point(955, 533);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(161, 48);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tpApplicationInfo
            // 
            tpApplicationInfo.BackColor = Color.White;
            tpApplicationInfo.Controls.Add(pictureBox1);
            tpApplicationInfo.Controls.Add(lblCreatedByUserName);
            tpApplicationInfo.Controls.Add(lblApplicationFees);
            tpApplicationInfo.Controls.Add(lblApplicationDate);
            tpApplicationInfo.Controls.Add(cbLicenesClass);
            tpApplicationInfo.Controls.Add(pictureBox5);
            tpApplicationInfo.Controls.Add(label1);
            tpApplicationInfo.Controls.Add(lblLocalDrivingLicenseApplicationID);
            tpApplicationInfo.Controls.Add(pictureBox4);
            tpApplicationInfo.Controls.Add(pictureBox3);
            tpApplicationInfo.Controls.Add(pictureBox2);
            tpApplicationInfo.Controls.Add(label5);
            tpApplicationInfo.Controls.Add(label4);
            tpApplicationInfo.Controls.Add(label3);
            tpApplicationInfo.Controls.Add(label2);
            tpApplicationInfo.Location = new Point(4, 24);
            tpApplicationInfo.Margin = new Padding(4, 3, 4, 3);
            tpApplicationInfo.Name = "tpApplicationInfo";
            tpApplicationInfo.Padding = new Padding(4, 3, 4, 3);
            tpApplicationInfo.Size = new Size(1167, 612);
            tpApplicationInfo.TabIndex = 1;
            tpApplicationInfo.Text = "Application Info";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(400, 148);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // lblCreatedByUserName
            // 
            lblCreatedByUserName.AutoSize = true;
            lblCreatedByUserName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreatedByUserName.ForeColor = Color.Black;
            lblCreatedByUserName.Location = new Point(524, 383);
            lblCreatedByUserName.Margin = new Padding(4, 0, 4, 0);
            lblCreatedByUserName.Name = "lblCreatedByUserName";
            lblCreatedByUserName.Size = new Size(36, 20);
            lblCreatedByUserName.TabIndex = 19;
            lblCreatedByUserName.Text = "???";
            // 
            // lblApplicationFees
            // 
            lblApplicationFees.AutoSize = true;
            lblApplicationFees.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApplicationFees.ForeColor = Color.Black;
            lblApplicationFees.Location = new Point(524, 317);
            lblApplicationFees.Margin = new Padding(4, 0, 4, 0);
            lblApplicationFees.Name = "lblApplicationFees";
            lblApplicationFees.Size = new Size(36, 20);
            lblApplicationFees.TabIndex = 18;
            lblApplicationFees.Text = "???";
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.AutoSize = true;
            lblApplicationDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApplicationDate.ForeColor = Color.Black;
            lblApplicationDate.Location = new Point(524, 202);
            lblApplicationDate.Margin = new Padding(4, 0, 4, 0);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(36, 20);
            lblApplicationDate.TabIndex = 17;
            lblApplicationDate.Text = "???";
            // 
            // cbLicenesClass
            // 
            cbLicenesClass.FormattingEnabled = true;
            cbLicenesClass.Location = new Point(470, 260);
            cbLicenesClass.Margin = new Padding(4, 3, 4, 3);
            cbLicenesClass.Name = "cbLicenesClass";
            cbLicenesClass.Size = new Size(316, 23);
            cbLicenesClass.TabIndex = 16;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(400, 373);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(37, 33);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(177, 383);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 13;
            label1.Text = "Created By User ID :";
            // 
            // lblLocalDrivingLicenseApplicationID
            // 
            lblLocalDrivingLicenseApplicationID.AutoSize = true;
            lblLocalDrivingLicenseApplicationID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocalDrivingLicenseApplicationID.ForeColor = Color.FromArgb(192, 0, 0);
            lblLocalDrivingLicenseApplicationID.Location = new Point(523, 148);
            lblLocalDrivingLicenseApplicationID.Margin = new Padding(4, 0, 4, 0);
            lblLocalDrivingLicenseApplicationID.Name = "lblLocalDrivingLicenseApplicationID";
            lblLocalDrivingLicenseApplicationID.Size = new Size(39, 20);
            lblLocalDrivingLicenseApplicationID.TabIndex = 8;
            lblLocalDrivingLicenseApplicationID.Text = "???";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(400, 317);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(37, 33);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(400, 260);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 33);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(400, 202);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 33);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(203, 317);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 3;
            label5.Text = "Application Fees :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(230, 257);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 2;
            label4.Text = "License Class :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(204, 202);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 20);
            label3.TabIndex = 1;
            label3.Text = "Application Date :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(227, 148);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 0;
            label2.Text = "Application ID :";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddEditLocalDrivingLicenseApplication
            // 
            AcceptButton = btnNext;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1197, 766);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(lblAddEditLocalDrivingLicenseApplication);
            Controls.Add(tcAddNewUser);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmAddEditLocalDrivingLicenseApplication";
            Text = "frmAddEditLocalDrivingLicenseApplication";
            Shown += frmAddEditLocalDrivingLicenseApplication_Shown;
            tcAddNewUser.ResumeLayout(false);
            tpPersonInfo.ResumeLayout(false);
            tpApplicationInfo.ResumeLayout(false);
            tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAddEditLocalDrivingLicenseApplication;
        private System.Windows.Forms.TabControl tcAddNewUser;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Label lblCreatedByUserName;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenesClass;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocalDrivingLicenseApplicationID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
    }
}