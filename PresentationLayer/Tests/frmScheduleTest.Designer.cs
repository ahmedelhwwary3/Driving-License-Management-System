namespace PresentationLayer.Tests
{
    partial class frmScheduleTest
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
            btnClose = new Button();
            ctrlScheduleTest1 = new Controls.ctrlScheduleTest();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(308, 909);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(119, 46);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ctrlScheduleTest1
            // 
            ctrlScheduleTest1.BackColor = Color.White;
            ctrlScheduleTest1.Location = new Point(4, 2);
            ctrlScheduleTest1.Margin = new Padding(5, 3, 5, 3);
            ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            ctrlScheduleTest1.Size = new Size(666, 907);
            ctrlScheduleTest1.TabIndex = 0;
            ctrlScheduleTest1.TestTypeID = BusinessLayer.clsTestType.enTestType.Vision;
            // 
            // frmScheduleTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(680, 969);
            Controls.Add(btnClose);
            Controls.Add(ctrlScheduleTest1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmScheduleTest";
            Text = "frmScheduleTest";
            Load += frmScheduleTest_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controls.ctrlScheduleTest ctrlScheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}