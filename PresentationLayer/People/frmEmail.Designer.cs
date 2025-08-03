namespace PresentationLayer.People
{
    partial class frmEmail
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
            btnSend = new Button();
            btnClose = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtBody = new TextBox();
            txtTitle = new Label();
            txtSubject = new TextBox();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Image = Properties.Resources.Email_32;
            btnSend.ImageAlign = ContentAlignment.MiddleLeft;
            btnSend.Location = new Point(665, 457);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(134, 48);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(513, 457);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(134, 48);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(56, 200);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 6;
            label1.Text = "Subject";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(65, 91);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 7;
            label2.Text = "From";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(78, 141);
            label3.Name = "label3";
            label3.Size = new Size(31, 25);
            label3.TabIndex = 8;
            label3.Text = "To";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label4.Location = new Point(66, 267);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 9;
            label4.Text = "Body";
            // 
            // txtBody
            // 
            txtBody.Location = new Point(159, 266);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.ScrollBars = ScrollBars.Vertical;
            txtBody.Size = new Size(640, 153);
            txtBody.TabIndex = 10;
            txtBody.KeyPress += txtBody_KeyPress;
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            txtTitle.ForeColor = Color.Red;
            txtTitle.Location = new Point(319, 26);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(179, 45);
            txtTitle.TabIndex = 11;
            txtTitle.Text = "Send Email";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(159, 202);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(528, 23);
            txtSubject.TabIndex = 12;
            txtSubject.Validating += txtSubject_Validating;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(159, 96);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(528, 23);
            txtFrom.TabIndex = 13;
            txtFrom.KeyPress += txtFrom_KeyPress;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(159, 146);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(528, 23);
            txtTo.TabIndex = 14;
            txtTo.KeyPress += txtTo_KeyPress;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(821, 527);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(txtSubject);
            Controls.Add(txtTitle);
            Controls.Add(txtBody);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnSend);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEmail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmEmail";
            Load += frmEmail_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private Button btnClose;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtBody;
        private Label txtTitle;
        private Label label5;
        private TextBox txtSubject;
        private TextBox txtFrom;
        private TextBox txtTo;
        private ErrorProvider errorProvider1;
    }
}