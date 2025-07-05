namespace PresentationLayer.Users
{
    partial class frmChangePassword
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
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtCurrentPassword = new TextBox();
            label8 = new Label();
            label9 = new Label();
            lblPass = new Label();
            errorProvider1 = new ErrorProvider(components);
            btnClose = new Button();
            btnSave = new Button();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pbPass = new PictureBox();
            ctrlUserCard1 = new ctrlUserCard();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPass).BeginInit();
            SuspendLayout();
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(353, 726);
            txtConfirmPassword.Margin = new Padding(4, 3, 4, 3);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(236, 23);
            txtConfirmPassword.TabIndex = 2;
            txtConfirmPassword.KeyPress += txtConfirmPassword_KeyPress;
            txtConfirmPassword.Validating += txtConfirmPassword_Validating;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(353, 666);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(236, 23);
            txtPassword.TabIndex = 1;
            txtPassword.KeyPress += txtPassword_KeyPress;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(353, 613);
            txtCurrentPassword.Margin = new Padding(4, 3, 4, 3);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(236, 23);
            txtCurrentPassword.TabIndex = 0;
            txtCurrentPassword.KeyPress += txtCurrentPassword_KeyPress;
            txtCurrentPassword.Validating += txtCurrentPassword_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(112, 726);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(163, 20);
            label8.TabIndex = 29;
            label8.Text = "Confirm Password :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(145, 666);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(135, 20);
            label9.TabIndex = 28;
            label9.Text = "New Password :";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPass.Location = new Point(114, 613);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(161, 20);
            lblPass.TabIndex = 27;
            lblPass.Text = "Current Password :";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(801, 783);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(133, 57);
            btnClose.TabIndex = 37;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.Save_32;
            btnSave.Location = new Point(955, 783);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 57);
            btnSave.TabIndex = 36;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Password_32;
            pictureBox4.Location = new Point(309, 726);
            pictureBox4.Margin = new Padding(4, 3, 4, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(37, 33);
            pictureBox4.TabIndex = 32;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Password_32;
            pictureBox3.Location = new Point(309, 666);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 33);
            pictureBox3.TabIndex = 31;
            pictureBox3.TabStop = false;
            // 
            // pbPass
            // 
            pbPass.Image = Properties.Resources.Password_321;
            pbPass.Location = new Point(309, 611);
            pbPass.Margin = new Padding(4, 3, 4, 3);
            pbPass.Name = "pbPass";
            pbPass.Size = new Size(37, 33);
            pbPass.TabIndex = 30;
            pbPass.TabStop = false;
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.BackColor = Color.White;
            ctrlUserCard1.ForeColor = Color.FromArgb(30, 30, 30);
            ctrlUserCard1.Location = new Point(2, 2);
            ctrlUserCard1.Margin = new Padding(5, 3, 5, 3);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new Size(1148, 590);
            ctrlUserCard1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1158, 884);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pbPass);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(lblPass);
            Controls.Add(ctrlUserCard1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmChangePassword";
            Text = "frmChangePassword";
            Load += frmChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Label lblPass;
        private PictureBox pbPass;
    }
}