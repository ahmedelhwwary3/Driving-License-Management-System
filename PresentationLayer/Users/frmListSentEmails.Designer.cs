namespace PresentationLayer.Users
{
    partial class frmListSentEmails
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
            dgvSentMails = new DataGridView();
            lblRecords = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvSentMails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvSentMails
            // 
            dgvSentMails.AllowUserToAddRows = false;
            dgvSentMails.AllowUserToDeleteRows = false;
            dgvSentMails.Anchor = AnchorStyles.None;
            dgvSentMails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSentMails.Location = new Point(13, 307);
            dgvSentMails.Margin = new Padding(4, 3, 4, 3);
            dgvSentMails.Name = "dgvSentMails";
            dgvSentMails.ReadOnly = true;
            dgvSentMails.Size = new Size(884, 369);
            dgvSentMails.TabIndex = 28;
            // 
            // lblRecords
            // 
            lblRecords.Anchor = AnchorStyles.None;
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecords.Location = new Point(127, 698);
            lblRecords.Margin = new Padding(4, 0, 4, 0);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(36, 20);
            lblRecords.TabIndex = 27;
            lblRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 698);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 26;
            label3.Text = "Records :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(361, 241);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(214, 39);
            label2.TabIndex = 30;
            label2.Tag = "MainTitle";
            label2.Text = "Sent Emails";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Users_2_400;
            pictureBox1.Location = new Point(339, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // frmListSentEmails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(911, 725);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(dgvSentMails);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmListSentEmails";
            Text = "frmListSentEmails";
            Load += frmListSentEmails_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSentMails).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSentMails;
        private Label lblRecords;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
    }
}