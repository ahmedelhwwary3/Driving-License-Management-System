namespace PresentationLayer.Users
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblIsActive = new Label();
            label2 = new Label();
            lblUserName = new Label();
            lblUserID = new Label();
            label4 = new Label();
            label1 = new Label();
            ctrlPersonCard1 = new People.ctrlPersonCard();
            label3 = new Label();
            lblPermissions = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPermissions);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblIsActive);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblUserName);
            groupBox1.Controls.Add(lblUserID);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 410);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1134, 99);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Information";
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIsActive.ForeColor = Color.Green;
            lblIsActive.Location = new Point(690, 45);
            lblIsActive.Margin = new Padding(5, 0, 5, 0);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(39, 20);
            lblIsActive.TabIndex = 140;
            lblIsActive.Text = "???";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 0);
            label2.Location = new Point(556, 45);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 139;
            label2.Text = "Is Active : ";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.Green;
            lblUserName.Location = new Point(431, 45);
            lblUserName.Margin = new Padding(5, 0, 5, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(39, 20);
            lblUserName.TabIndex = 138;
            lblUserName.Text = "???";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.ForeColor = Color.Green;
            lblUserID.Location = new Point(161, 45);
            lblUserID.Margin = new Padding(5, 0, 5, 0);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(39, 20);
            lblUserID.TabIndex = 137;
            lblUserID.Text = "???";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(64, 64, 0);
            label4.Location = new Point(35, 45);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 136;
            label4.Text = "User ID : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 0);
            label1.Location = new Point(285, 45);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 130;
            label1.Text = "User Name:";
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(4, 3);
            ctrlPersonCard1.Margin = new Padding(5, 3, 5, 3);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(1143, 410);
            ctrlPersonCard1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(192, 0, 0);
            label3.Location = new Point(842, 42);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(141, 24);
            label3.TabIndex = 141;
            label3.Text = "Permissions : ";
            // 
            // lblPermissions
            // 
            lblPermissions.AutoSize = true;
            lblPermissions.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPermissions.ForeColor = Color.FromArgb(255, 128, 128);
            lblPermissions.Location = new Point(993, 46);
            lblPermissions.Margin = new Padding(5, 0, 5, 0);
            lblPermissions.Name = "lblPermissions";
            lblPermissions.Size = new Size(39, 20);
            lblPermissions.TabIndex = 142;
            lblPermissions.Text = "???";
            // 
            // ctrlUserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ctrlPersonCard1);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ctrlUserCard";
            Size = new Size(1152, 523);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private People.ctrlPersonCard ctrlPersonCard1;
        private Label lblPermissions;
        private Label label3;
    }
}
