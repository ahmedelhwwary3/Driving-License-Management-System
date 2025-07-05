namespace PresentationLayer.Users
{
    partial class frmUserInfo
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
            ctrlUserCard1 = new ctrlUserCard();
            btnClose = new Button();
            SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.BackColor = Color.White;
            ctrlUserCard1.Location = new Point(4, 3);
            ctrlUserCard1.Margin = new Padding(5, 3, 5, 3);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new Size(1147, 578);
            ctrlUserCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.Location = new Point(965, 583);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(164, 63);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmUserInfo
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(1152, 658);
            Controls.Add(btnClose);
            Controls.Add(ctrlUserCard1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmUserInfo";
            Text = "frmUserInfo";
            Load += frmUserInfo_Load;
            ResumeLayout(false);
        }

        #endregion

        private ctrlUserCard ctrlUserCard1;
        private System.Windows.Forms.Button btnClose;
    }
}