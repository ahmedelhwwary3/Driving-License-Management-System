namespace PresentationLayer.People
{
    partial class frmAddEditPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditPerson));
            lblPersonID = new Label();
            lblTitle = new Label();
            label13 = new Label();
            btnSave = new Button();
            txtAddress = new TextBox();
            label5 = new Label();
            txtPhone = new TextBox();
            dtpBirth = new DateTimePicker();
            txtLast = new TextBox();
            txtThird = new TextBox();
            txtSecond = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbCountries = new ComboBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            llRemove = new LinkLabel();
            llSetImage = new LinkLabel();
            txtFirst = new TextBox();
            txtNationalNo = new TextBox();
            panel1 = new Panel();
            btnClose = new Button();
            txtEmail = new TextBox();
            pictureBox11 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pbPersonImage = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblPersonID
            // 
            lblPersonID.AutoSize = true;
            lblPersonID.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersonID.Location = new Point(178, 50);
            lblPersonID.Margin = new Padding(4, 0, 4, 0);
            lblPersonID.Name = "lblPersonID";
            lblPersonID.Size = new Size(42, 24);
            lblPersonID.TabIndex = 96;
            lblPersonID.Text = "N/A";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(497, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 37);
            lblTitle.TabIndex = 95;
            lblTitle.Text = "Add Edit Person";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(28, 53);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(99, 20);
            label13.TabIndex = 93;
            label13.Text = "Person ID :";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.Save_32;
            btnSave.Location = new Point(889, 371);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 45);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(248, 312);
            txtAddress.Margin = new Padding(4, 3, 4, 3);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(746, 109);
            txtAddress.TabIndex = 7;
            txtAddress.KeyPress += txtBoxes_KeyPress;
            txtAddress.PreviewKeyDown += txtAddress_PreviewKeyDown;
            txtAddress.Validating += txtAddress_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(611, 269);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 89;
            label5.Text = "Country :";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(762, 226);
            txtPhone.Margin = new Padding(4, 3, 4, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(233, 23);
            txtPhone.TabIndex = 5;
            txtPhone.KeyPress += txtBoxes_KeyPress;
            txtPhone.Validating += txtPhone_Validating;
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(762, 181);
            dtpBirth.Margin = new Padding(4, 3, 4, 3);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(233, 23);
            dtpBirth.TabIndex = 5;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(1018, 135);
            txtLast.Margin = new Padding(4, 3, 4, 3);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(233, 23);
            txtLast.TabIndex = 3;
            txtLast.KeyPress += txtBoxes_KeyPress;
            txtLast.Validating += txtLast_Validating;
            // 
            // txtThird
            // 
            txtThird.Location = new Point(762, 135);
            txtThird.Margin = new Padding(4, 3, 4, 3);
            txtThird.Name = "txtThird";
            txtThird.Size = new Size(233, 23);
            txtThird.TabIndex = 2;
            txtThird.KeyPress += txtBoxes_KeyPress;
            // 
            // txtSecond
            // 
            txtSecond.Location = new Point(505, 135);
            txtSecond.Margin = new Padding(4, 3, 4, 3);
            txtSecond.Name = "txtSecond";
            txtSecond.Size = new Size(233, 23);
            txtSecond.TabIndex = 1;
            txtSecond.KeyPress += txtBoxes_KeyPress;
            txtSecond.Validating += txtSecond_Validating;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(1105, 102);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(43, 24);
            label11.TabIndex = 82;
            label11.Text = "Last";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(853, 102);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(54, 24);
            label12.TabIndex = 81;
            label12.Text = "Third";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(575, 102);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(76, 24);
            label10.TabIndex = 80;
            label10.Text = "Second";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(334, 102);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(45, 24);
            label9.TabIndex = 79;
            label9.Text = "First";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(624, 226);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 77;
            label7.Text = "Phone :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(560, 181);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(125, 20);
            label8.TabIndex = 76;
            label8.Text = "Date Of Birth :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(28, 312);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 75;
            label6.Text = "Address :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 269);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 74;
            label3.Text = "Email :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 226);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 73;
            label4.Text = "Gendor :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 181);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 72;
            label2.Text = "National No :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 133);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 71;
            label1.Text = "Name :";
            // 
            // cbCountries
            // 
            cbCountries.FormattingEnabled = true;
            cbCountries.ItemHeight = 15;
            cbCountries.Location = new Point(762, 269);
            cbCountries.Margin = new Padding(4, 3, 4, 3);
            cbCountries.Name = "cbCountries";
            cbCountries.Size = new Size(233, 23);
            cbCountries.TabIndex = 10;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(413, 230);
            rbFemale.Margin = new Padding(4, 3, 4, 3);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(63, 19);
            rbFemale.TabIndex = 7;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(290, 230);
            rbMale.Margin = new Padding(4, 3, 4, 3);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(51, 19);
            rbMale.TabIndex = 6;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // llRemove
            // 
            llRemove.AutoSize = true;
            llRemove.Location = new Point(1108, 459);
            llRemove.Margin = new Padding(4, 0, 4, 0);
            llRemove.Name = "llRemove";
            llRemove.Size = new Size(50, 15);
            llRemove.TabIndex = 12;
            llRemove.TabStop = true;
            llRemove.Text = "Remove";
            llRemove.LinkClicked += llRemove_LinkClicked;
            // 
            // llSetImage
            // 
            llSetImage.AutoSize = true;
            llSetImage.Location = new Point(1104, 422);
            llSetImage.Margin = new Padding(4, 0, 4, 0);
            llSetImage.Name = "llSetImage";
            llSetImage.Size = new Size(59, 15);
            llSetImage.TabIndex = 12;
            llSetImage.TabStop = true;
            llSetImage.Text = "Set Image";
            llSetImage.LinkClicked += llSetImage_LinkClicked;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(248, 135);
            txtFirst.Margin = new Padding(4, 3, 4, 3);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(233, 23);
            txtFirst.TabIndex = 0;
            txtFirst.KeyPress += txtBoxes_KeyPress;
            txtFirst.Validating += txtFirst_Validating;
            // 
            // txtNationalNo
            // 
            txtNationalNo.Location = new Point(248, 181);
            txtNationalNo.Margin = new Padding(4, 3, 4, 3);
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.Size = new Size(233, 23);
            txtNationalNo.TabIndex = 4;
            txtNationalNo.KeyPress += txtBoxes_KeyPress;
            txtNationalNo.Validating += txtNationalNo_Validating;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(btnSave);
            panel1.Location = new Point(9, 88);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1273, 442);
            panel1.TabIndex = 78;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(769, 371);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(97, 45);
            btnClose.TabIndex = 98;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(239, 179);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(233, 23);
            txtEmail.TabIndex = 6;
            txtEmail.KeyPress += txtBoxes_KeyPress;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // pictureBox11
            // 
            pictureBox11.Location = new Point(373, 224);
            pictureBox11.Margin = new Padding(4, 3, 4, 3);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(31, 28);
            pictureBox11.TabIndex = 92;
            pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Location = new Point(248, 224);
            pictureBox10.Margin = new Padding(4, 3, 4, 3);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(31, 28);
            pictureBox10.TabIndex = 91;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(723, 267);
            pictureBox9.Margin = new Padding(4, 3, 4, 3);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(31, 28);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 90;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(723, 224);
            pictureBox8.Margin = new Padding(4, 3, 4, 3);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(31, 28);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 88;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(723, 179);
            pictureBox7.Margin = new Padding(4, 3, 4, 3);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(31, 28);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 87;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(183, 312);
            pictureBox6.Margin = new Padding(4, 3, 4, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(31, 28);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 86;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(183, 267);
            pictureBox5.Margin = new Padding(4, 3, 4, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(31, 28);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 85;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(183, 224);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(31, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 84;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(183, 179);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(31, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 83;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(183, 135);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            // 
            // pbPersonImage
            // 
            pbPersonImage.Image = Properties.Resources.Female_512;
            pbPersonImage.Location = new Point(1018, 187);
            pbPersonImage.Margin = new Padding(4, 3, 4, 3);
            pbPersonImage.Name = "pbPersonImage";
            pbPersonImage.Size = new Size(233, 212);
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonImage.TabIndex = 63;
            pbPersonImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddEditPerson
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1291, 538);
            Controls.Add(lblPersonID);
            Controls.Add(lblTitle);
            Controls.Add(label13);
            Controls.Add(pictureBox11);
            Controls.Add(pictureBox10);
            Controls.Add(txtAddress);
            Controls.Add(pictureBox9);
            Controls.Add(label5);
            Controls.Add(txtPhone);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(dtpBirth);
            Controls.Add(txtLast);
            Controls.Add(txtThird);
            Controls.Add(txtSecond);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbCountries);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(pictureBox2);
            Controls.Add(pbPersonImage);
            Controls.Add(llRemove);
            Controls.Add(llSetImage);
            Controls.Add(txtFirst);
            Controls.Add(txtNationalNo);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmAddEditPerson";
            Text = "frmAddEditPerson";
            Load += frmAddEditPerson_Load;
            KeyPress += frmAddEditPerson_KeyPress;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPersonImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.TextBox txtThird;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.LinkLabel llRemove;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Button btnClose;
    }
}