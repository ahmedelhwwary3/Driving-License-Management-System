namespace PresentationLayer.Licenses
{
    partial class frmShowLicenseHistory
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
            lblTitle = new Label();
            btnExit = new Button();
            cmsInterenationalLicenseHistory = new ContextMenuStrip(components);
            InternationalLicenseHistorytoolStripMenuItem = new ToolStripMenuItem();
            cmsLocalLicenseHistory = new ContextMenuStrip(components);
            showLicenseInfoToolStripMenuItem = new ToolStripMenuItem();
            ctrlDriverLicenses1 = new Controls.ctrlDriverLicenses();
            ctrlPersonCardWithFilter1 = new People.ctrlPersonCardWithFilter();
            cmsInterenationalLicenseHistory.SuspendLayout();
            cmsLocalLicenseHistory.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(20, 5);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1239, 45);
            lblTitle.TabIndex = 132;
            lblTitle.Tag = "MainTitle";
            lblTitle.Text = "License History";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            btnExit.Image = Properties.Resources.Close_32;
            btnExit.Location = new Point(1041, 894);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(177, 52);
            btnExit.TabIndex = 137;
            btnExit.Text = "Close";
            btnExit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cmsInterenationalLicenseHistory
            // 
            cmsInterenationalLicenseHistory.Items.AddRange(new ToolStripItem[] { InternationalLicenseHistorytoolStripMenuItem });
            cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            cmsInterenationalLicenseHistory.Size = new Size(186, 42);
            cmsInterenationalLicenseHistory.Opening += cmsInterenationalLicenseHistory_Opening;
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            InternationalLicenseHistorytoolStripMenuItem.Image = Properties.Resources.License_Type_32;
            InternationalLicenseHistorytoolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            InternationalLicenseHistorytoolStripMenuItem.Size = new Size(185, 38);
            InternationalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            InternationalLicenseHistorytoolStripMenuItem.Click += InternationalLicenseHistorytoolStripMenuItem_Click;
            // 
            // cmsLocalLicenseHistory
            // 
            cmsLocalLicenseHistory.Items.AddRange(new ToolStripItem[] { showLicenseInfoToolStripMenuItem });
            cmsLocalLicenseHistory.Name = "cmsLocalLicenseHistory";
            cmsLocalLicenseHistory.Size = new Size(186, 42);
            cmsLocalLicenseHistory.Opening += cmsLocalLicenseHistory_Opening;
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            showLicenseInfoToolStripMenuItem.Image = Properties.Resources.License_Type_32;
            showLicenseInfoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            showLicenseInfoToolStripMenuItem.Size = new Size(185, 38);
            showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            showLicenseInfoToolStripMenuItem.Click += showLicenseInfoToolStripMenuItem_Click;
            // 
            // ctrlDriverLicenses1
            // 
            ctrlDriverLicenses1.BackColor = Color.White;
            ctrlDriverLicenses1.Location = new Point(50, 586);
            ctrlDriverLicenses1.Margin = new Padding(5, 3, 5, 3);
            ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            ctrlDriverLicenses1.Size = new Size(1209, 337);
            ctrlDriverLicenses1.TabIndex = 136;
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.BackColor = Color.White;
            ctrlPersonCardWithFilter1.FilterEnabled = true;
            ctrlPersonCardWithFilter1.Location = new Point(97, 83);
            ctrlPersonCardWithFilter1.Margin = new Padding(4, 3, 4, 3);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.ShowAddPerson = true;
            ctrlPersonCardWithFilter1.Size = new Size(1144, 496);
            ctrlPersonCardWithFilter1.TabIndex = 135;
            // 
            // frmShowLicenseHistory
            // 
            AcceptButton = btnExit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnExit;
            ClientSize = new Size(1293, 959);
            Controls.Add(btnExit);
            Controls.Add(ctrlDriverLicenses1);
            Controls.Add(ctrlPersonCardWithFilter1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmShowLicenseHistory";
            Text = "frmShowLicenseHistory";
            Load += frmShowLicenseHistory_Load;
            cmsInterenationalLicenseHistory.ResumeLayout(false);
            cmsLocalLicenseHistory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private People.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Controls.ctrlDriverLicenses ctrlDriverLicenses1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}