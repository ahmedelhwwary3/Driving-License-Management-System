namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    partial class frmListHighRiskApplicants
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
            lblCount = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dgvListAplicants = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvListAplicants).BeginInit();
            SuspendLayout();
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCount.Location = new Point(129, 768);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(40, 30);
            lblCount.TabIndex = 1;
            lblCount.Text = "???";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(50, 768);
            label2.Name = "label2";
            label2.Size = new Size(73, 30);
            label2.TabIndex = 2;
            label2.Text = "Count";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Local_Driving_License_512;
            pictureBox1.Location = new Point(440, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 196);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(389, 238);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(356, 39);
            label1.TabIndex = 14;
            label1.Tag = "MainTitle";
            label1.Text = "High Risk Applicants";
            // 
            // dgvListAplicants
            // 
            dgvListAplicants.AllowUserToAddRows = false;
            dgvListAplicants.AllowUserToDeleteRows = false;
            dgvListAplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListAplicants.Location = new Point(25, 296);
            dgvListAplicants.Name = "dgvListAplicants";
            dgvListAplicants.ReadOnly = true;
            dgvListAplicants.Size = new Size(1057, 458);
            dgvListAplicants.TabIndex = 15;
            dgvListAplicants.BindingContextChanged += dgvListAplicants_BindingContextChanged;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(997, 242);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(85, 46);
            btnClose.TabIndex = 16;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmListHighRiskApplicants
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1108, 807);
            Controls.Add(btnClose);
            Controls.Add(dgvListAplicants);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(lblCount);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmListHighRiskApplicants";
            Text = "frmListHighRiskApplicants";
            Load += frmListHighRiskApplicants_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvListAplicants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCount;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridView dgvListAplicants;
        private Button btnClose;
    }
}