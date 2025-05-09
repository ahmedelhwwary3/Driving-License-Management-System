using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Licenses.LocalLicenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }


        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
            => OnLicenseSelected?.Invoke(LicenseID);


        public Button FindButton => this.btnFind;
        public enum enLicenseService
        {
            Detain, Release, IssueInternational,
            Renew, ReplaceForLostOrDamaged
        }
        enLicenseService _LicenseService;
        public enLicenseService LicenseService
        {
            get => _LicenseService;
            set => _LicenseService = value;
        }
        int? _LicenseID = null;
        bool _FilterEnabled = false;
        public bool FilterEnabled
        {
            get => _FilterEnabled;
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        private clsLicense _License = new clsLicense();
        public void PerformClickBtnFindLicense(int LicenseID)
        {
            txtLicenseID.Text= LicenseID.ToString();
            btnFind_Click(null, null);
        }
        public void ResetCTRL() => ctrlDriverLicenseInfo1.ResetCTRL();

        public void FilterFocus() => txtLicenseID.Focus();
        private void btnFind_Click(object sender, EventArgs e)
        {
           
            if (!int.TryParse(txtLicenseID.Text, out int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing txtLicenseID to int ."));
                return;
            }
            _LicenseID = LicenseID;
            _License = clsLicense.GetByID(LicenseID);
            if (!_ValidateEmptyOrNull())
            {
                MessageBox.Show("Error:Check the red icon messages", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            if (!_ValidateLicenseServiceChecks())
                return;
            _LoadLicense();

        }
        void _LoadLicense()
        {
            //with out Click Find 
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID.Value);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            txtLicenseID.Text = _LicenseID.ToString();
            //We will need LicenseID to select it in the form to complete Form Functionality
            if (FilterEnabled && OnLicenseSelected != null)
                OnLicenseSelected(_LicenseID.Value);
        }


        bool _ValidateEmptyOrNull()
        {
            //Check for All Modes :-
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                errorProvider1.SetError(txtLicenseID, "This field can not be empty !");
                return false;
            }
            else
                errorProvider1.SetError(txtLicenseID, null);

            //We ensured that input is Digit using KeyPress event
            if (_License == null)
            {
                errorProvider1.SetError(txtLicenseID, "This license is not found !");
                return false;
            }
            else
                errorProvider1.SetError(txtLicenseID, null);
            return true;
        }
        bool _ValidateLicenseServiceChecks()
        {

            switch (_LicenseService)
            {
                case enLicenseService.IssueInternational:
                    {
                        if (_License.HasIssuedActiveInternationalLicense())
                        {
                            MessageBox.Show($"Error:This Lisense Has Issued An Active" +
                                $" International License Before !", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (_License.LicenseClass != clsLicenseClass.enLicenseClassID.Class3_ordinary_driving_license)
                        {
                            MessageBox.Show("Error:License should be Class 3 Ordinary Class !" +
                                " Please select another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        int? ActiveInternaionalLicenseID = clsInternationalLicense.
                             GetActiveInternationalLicenseIDByDriverID(_License.DriverID);
                        if (ActiveInternaionalLicenseID != null)
                        {
                            MessageBox.Show($"Error:Person already have an active international license ", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                case enLicenseService.Detain:
                case enLicenseService.Renew:
                case enLicenseService.ReplaceForLostOrDamaged:
                    {
                        //Renew & Detain
                        if (_License.IsLicenseDetained())
                        {
                            MessageBox.Show($"Error:License is detained !"
                                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        //Detain or ReplaceForLostOrDamaged
                        if (_LicenseService == enLicenseService.Detain || _LicenseService == enLicenseService.ReplaceForLostOrDamaged)
                            return true;
                        //Renew (Additional Check)
                        if (!_License.IsDateExpirated())
                        {
                            MessageBox.Show("Error:Old License is not Expirated !", "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                case enLicenseService.Release:
                    {

                        if (!_License.IsLicenseDetained())
                        {
                            MessageBox.Show($"Error:License is not Detained !", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
            }
            return false;
        }






      

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;//not allowed
                SystemSounds.Beep.Play();
            }

        }

        private void txtLicenseID_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyDown runs before KeyPress and handles the unexpected actions of Enter
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;//Disable Beeb
                btnFind.PerformClick();
            }
        }
        private void InitializeComponent()
        {
            components = new Container();
            gbFilter = new GroupBox();
            btnFind = new Button();
            txtLicenseID = new TextBox();
            label1 = new Label();
            ctrlDriverLicenseInfo1 = new ctrlDriverLicenseInfo();
            errorProvider1 = new ErrorProvider(components);
            gbFilter.SuspendLayout();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(btnFind);
            gbFilter.Controls.Add(txtLicenseID);
            gbFilter.Controls.Add(label1);
            gbFilter.Location = new Point(15, 1);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(429, 71);
            gbFilter.TabIndex = 1;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // btnFind
            // 
            btnFind.Image = Properties.Resources.SearchPerson;
            btnFind.Location = new Point(367, 19);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(40, 41);
            btnFind.TabIndex = 2;
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // txtLicenseID
            // 
            txtLicenseID.Location = new Point(130, 28);
            txtLicenseID.Name = "txtLicenseID";
            txtLicenseID.Size = new Size(217, 23);
            txtLicenseID.TabIndex = 1;
            txtLicenseID.KeyDown += txtLicenseID_KeyDown;
            txtLicenseID.KeyPress += txtLicenseID_KeyPress;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 26);
            label1.Name = "label1";
            label1.Size = new Size(95, 24);
            label1.TabIndex = 0;
            label1.Text = "License ID";
            // 
            // ctrlDriverLicenseInfo1
            // 
            ctrlDriverLicenseInfo1.BackColor = Color.White;
            ctrlDriverLicenseInfo1.Location = new Point(0, 78);
            ctrlDriverLicenseInfo1.Margin = new Padding(4, 3, 4, 3);
            ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            ctrlDriverLicenseInfo1.Size = new Size(1009, 391);
            ctrlDriverLicenseInfo1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            BackColor = Color.White;
            Controls.Add(ctrlDriverLicenseInfo1);
            Controls.Add(gbFilter);
            Name = "ctrlDriverLicenseInfoWithFilter";
            Size = new Size(1010, 472);
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }
    }
}
