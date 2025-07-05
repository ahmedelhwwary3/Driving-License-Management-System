namespace PresentationLayer.Login
{
    partial class frmDocumentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentation));
            lbxCode = new ListBox();
            lblTitle = new Label();
            rbAll = new RadioButton();
            rbMethods = new RadioButton();
            rbProberties = new RadioButton();
            rbDescriptionAttributes = new RadioButton();
            btnClose = new Button();
            lblTotalRecords = new Label();
            label3 = new Label();
            btnAllSPInfo = new Button();
            btnFindSP = new Button();
            panel1 = new Panel();
            txtSPName = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbxCode
            // 
            lbxCode.FormattingEnabled = true;
            lbxCode.ItemHeight = 15;
            lbxCode.Location = new Point(60, 231);
            lbxCode.Name = "lbxCode";
            lbxCode.Size = new Size(1130, 574);
            lbxCode.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblTitle.Location = new Point(457, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(336, 37);
            lblTitle.TabIndex = 7;
            lblTitle.Tag = "MainTitle";
            lblTitle.Text = "Code Documentation";
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Location = new Point(59, 26);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(96, 19);
            rbAll.TabIndex = 8;
            rbAll.TabStop = true;
            rbAll.Text = "All Meta Data";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.CheckedChanged += rbAll_CheckedChanged;
            // 
            // rbMethods
            // 
            rbMethods.AutoSize = true;
            rbMethods.Location = new Point(265, 26);
            rbMethods.Name = "rbMethods";
            rbMethods.Size = new Size(72, 19);
            rbMethods.TabIndex = 9;
            rbMethods.TabStop = true;
            rbMethods.Text = "Methods";
            rbMethods.UseVisualStyleBackColor = true;
            rbMethods.CheckedChanged += rbMethods_CheckedChanged;
            // 
            // rbProberties
            // 
            rbProberties.AutoSize = true;
            rbProberties.Location = new Point(59, 86);
            rbProberties.Name = "rbProberties";
            rbProberties.Size = new Size(78, 19);
            rbProberties.TabIndex = 10;
            rbProberties.TabStop = true;
            rbProberties.Text = "Proberties";
            rbProberties.UseVisualStyleBackColor = true;
            rbProberties.CheckedChanged += rbProberties_CheckedChanged;
            // 
            // rbDescriptionAttributes
            // 
            rbDescriptionAttributes.AutoSize = true;
            rbDescriptionAttributes.Location = new Point(265, 86);
            rbDescriptionAttributes.Name = "rbDescriptionAttributes";
            rbDescriptionAttributes.Size = new Size(140, 19);
            rbDescriptionAttributes.TabIndex = 11;
            rbDescriptionAttributes.TabStop = true;
            rbDescriptionAttributes.Text = "Description Attributes";
            rbDescriptionAttributes.UseVisualStyleBackColor = true;
            rbDescriptionAttributes.CheckedChanged += rbDescriptionAttributes_CheckedChanged;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(1067, 815);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(123, 53);
            btnClose.TabIndex = 34;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.Anchor = AnchorStyles.Left;
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRecords.Location = new Point(177, 824);
            lblTotalRecords.Margin = new Padding(4, 0, 4, 0);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(51, 25);
            lblTotalRecords.TabIndex = 33;
            lblTotalRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(58, 824);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 32;
            label3.Text = "Records:";
            // 
            // btnAllSPInfo
            // 
            btnAllSPInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAllSPInfo.Location = new Point(610, 145);
            btnAllSPInfo.Name = "btnAllSPInfo";
            btnAllSPInfo.Size = new Size(183, 71);
            btnAllSPInfo.TabIndex = 35;
            btnAllSPInfo.Text = "Get All Stored Procedures Info";
            btnAllSPInfo.UseVisualStyleBackColor = true;
            btnAllSPInfo.Click += btnAllSPInfo_Click;
            // 
            // btnFindSP
            // 
            btnFindSP.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFindSP.Location = new Point(610, 69);
            btnFindSP.Name = "btnFindSP";
            btnFindSP.Size = new Size(183, 70);
            btnFindSP.TabIndex = 36;
            btnFindSP.Text = "Find Stored Procedure Data By Name";
            btnFindSP.UseVisualStyleBackColor = true;
            btnFindSP.Click += btnFindSP_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbDescriptionAttributes);
            panel1.Controls.Add(rbProberties);
            panel1.Controls.Add(rbMethods);
            panel1.Controls.Add(rbAll);
            panel1.Location = new Point(60, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 126);
            panel1.TabIndex = 37;
            // 
            // txtSPName
            // 
            txtSPName.Location = new Point(813, 81);
            txtSPName.Name = "txtSPName";
            txtSPName.Size = new Size(325, 23);
            txtSPName.TabIndex = 38;
            // 
            // frmDocumentation
            // 
            AcceptButton = btnFindSP;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1256, 881);
            Controls.Add(txtSPName);
            Controls.Add(panel1);
            Controls.Add(btnFindSP);
            Controls.Add(btnAllSPInfo);
            Controls.Add(btnClose);
            Controls.Add(lblTotalRecords);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(lbxCode);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmDocumentation";
            Text = "frmDocumentation";
            Load += frmDocumentation_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxCode;
        private Label lblTitle;
        private RadioButton rbAll;
        private RadioButton rbMethods;
        private RadioButton rbProberties;
        private RadioButton rbDescriptionAttributes;
        private Button btnClose;
        private Label lblTotalRecords;
        private Label label3;
        private Button btnAllSPInfo;
        private Button btnFindSP;
        private Panel panel1;
        private TextBox txtSPName;
    }
}