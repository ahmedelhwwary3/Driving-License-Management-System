namespace PresentationLayer.Licenses.Controls
{
    partial class ctrlDriverLicenses
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tcDriverLicenses = new TabControl();
            tpLocalLicenses = new TabPage();
            label1 = new Label();
            lblLocalLicensesRecords = new Label();
            label2 = new Label();
            dgvLocalLicensesHistory = new DataGridView();
            tbInternationalLicenses = new TabPage();
            label3 = new Label();
            lblInternationalLicensesRecords = new Label();
            label5 = new Label();
            dgvInternationalLicensesHistory = new DataGridView();
            tcDriverLicenses.SuspendLayout();
            tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocalLicensesHistory).BeginInit();
            tbInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicensesHistory).BeginInit();
            SuspendLayout();
            // 
            // tcDriverLicenses
            // 
            tcDriverLicenses.Controls.Add(tpLocalLicenses);
            tcDriverLicenses.Controls.Add(tbInternationalLicenses);
            tcDriverLicenses.Location = new Point(4, 3);
            tcDriverLicenses.Margin = new Padding(4, 3, 4, 3);
            tcDriverLicenses.Name = "tcDriverLicenses";
            tcDriverLicenses.SelectedIndex = 0;
            tcDriverLicenses.Size = new Size(1204, 332);
            tcDriverLicenses.TabIndex = 132;
            // 
            // tpLocalLicenses
            // 
            tpLocalLicenses.BackColor = Color.White;
            tpLocalLicenses.Controls.Add(label1);
            tpLocalLicenses.Controls.Add(lblLocalLicensesRecords);
            tpLocalLicenses.Controls.Add(label2);
            tpLocalLicenses.Controls.Add(dgvLocalLicensesHistory);
            tpLocalLicenses.Location = new Point(4, 24);
            tpLocalLicenses.Margin = new Padding(4, 3, 4, 3);
            tpLocalLicenses.Name = "tpLocalLicenses";
            tpLocalLicenses.Padding = new Padding(4, 3, 4, 3);
            tpLocalLicenses.Size = new Size(1196, 304);
            tpLocalLicenses.TabIndex = 0;
            tpLocalLicenses.Text = "Local";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(194, 20);
            label1.TabIndex = 135;
            label1.Text = "Local Licenses History:";
            // 
            // lblLocalLicensesRecords
            // 
            lblLocalLicensesRecords.AutoSize = true;
            lblLocalLicensesRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocalLicensesRecords.Location = new Point(121, 254);
            lblLocalLicensesRecords.Margin = new Padding(4, 0, 4, 0);
            lblLocalLicensesRecords.Name = "lblLocalLicensesRecords";
            lblLocalLicensesRecords.Size = new Size(27, 20);
            lblLocalLicensesRecords.TabIndex = 134;
            lblLocalLicensesRecords.Text = "??";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 253);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 133;
            label2.Text = "# Records:";
            // 
            // dgvLocalLicensesHistory
            // 
            dgvLocalLicensesHistory.AllowUserToAddRows = false;
            dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            dgvLocalLicensesHistory.AllowUserToResizeRows = false;
            dgvLocalLicensesHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLocalLicensesHistory.BackgroundColor = Color.White;
            dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocalLicensesHistory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvLocalLicensesHistory.Location = new Point(13, 53);
            dgvLocalLicensesHistory.Margin = new Padding(5, 6, 5, 6);
            dgvLocalLicensesHistory.MultiSelect = false;
            dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            dgvLocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLocalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLocalLicensesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocalLicensesHistory.Size = new Size(1162, 194);
            dgvLocalLicensesHistory.TabIndex = 132;
            dgvLocalLicensesHistory.TabStop = false;
            dgvLocalLicensesHistory.DataBindingComplete += dgvLocalLicensesHistory_DataBindingComplete;
            // 
            // tbInternationalLicenses
            // 
            tbInternationalLicenses.BackColor = Color.White;
            tbInternationalLicenses.Controls.Add(label3);
            tbInternationalLicenses.Controls.Add(lblInternationalLicensesRecords);
            tbInternationalLicenses.Controls.Add(label5);
            tbInternationalLicenses.Controls.Add(dgvInternationalLicensesHistory);
            tbInternationalLicenses.Location = new Point(4, 24);
            tbInternationalLicenses.Margin = new Padding(4, 3, 4, 3);
            tbInternationalLicenses.Name = "tbInternationalLicenses";
            tbInternationalLicenses.Padding = new Padding(4, 3, 4, 3);
            tbInternationalLicenses.Size = new Size(1196, 304);
            tbInternationalLicenses.TabIndex = 1;
            tbInternationalLicenses.Text = "International";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 20);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(253, 20);
            label3.TabIndex = 139;
            label3.Text = "International Licenses History:";
            // 
            // lblInternationalLicensesRecords
            // 
            lblInternationalLicensesRecords.AutoSize = true;
            lblInternationalLicensesRecords.Location = new Point(126, 252);
            lblInternationalLicensesRecords.Margin = new Padding(4, 0, 4, 0);
            lblInternationalLicensesRecords.Name = "lblInternationalLicensesRecords";
            lblInternationalLicensesRecords.Size = new Size(17, 15);
            lblInternationalLicensesRecords.TabIndex = 138;
            lblInternationalLicensesRecords.Text = "??";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 252);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 137;
            label5.Text = "# Records:";
            // 
            // dgvInternationalLicensesHistory
            // 
            dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            dgvInternationalLicensesHistory.AllowUserToResizeRows = false;
            dgvInternationalLicensesHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInternationalLicensesHistory.BackgroundColor = Color.White;
            dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInternationalLicensesHistory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInternationalLicensesHistory.Location = new Point(16, 52);
            dgvInternationalLicensesHistory.Margin = new Padding(5, 6, 5, 6);
            dgvInternationalLicensesHistory.MultiSelect = false;
            dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            dgvInternationalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInternationalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInternationalLicensesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInternationalLicensesHistory.Size = new Size(1162, 194);
            dgvInternationalLicensesHistory.TabIndex = 136;
            dgvInternationalLicensesHistory.TabStop = false;
            dgvInternationalLicensesHistory.DataBindingComplete += dgvInternationalLicensesHistory_DataBindingComplete;
            // 
            // ctrlDriverLicenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tcDriverLicenses);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ctrlDriverLicenses";
            Size = new Size(1209, 337);
            tcDriverLicenses.ResumeLayout(false);
            tpLocalLicenses.ResumeLayout(false);
            tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocalLicensesHistory).EndInit();
            tbInternationalLicenses.ResumeLayout(false);
            tbInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicensesHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tcDriverLicenses;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocalLicensesRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.TabPage tbInternationalLicenses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
    }
}
