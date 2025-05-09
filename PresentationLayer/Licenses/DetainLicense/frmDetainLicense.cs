using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Licenses.DetainLicense
{
    public partial class frmDetainLicense : Form
    {
        private int? _LicenseID = null;
        clsLicense _License = new clsLicense();
        private int? _PersonID = null;

        decimal _FineFees => clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense);
        public frmDetainLicense()
        {
            InitializeComponent();
        }


        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
         
            ctrlDriverLicenseInfoWithFilter1.LicenseService = LocalLicenses.Controls
                .ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            _SetFocusOntxtFilter();
            _ResetGeneralValues();


        }
        void _SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        void _ResetGeneralValues()
        {
            llShowLicenseHistory.Enabled = false;
            _EnableBtnLLs(false);
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            txtFineFees.Text = _FineFees.ToString("F2");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblDetainID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            txtFineFees.Text = "";
        }
        void _EnableBtnLLs(bool Enable)
        {
            llShowLicenseInfo.Enabled = Enable;
            llShowLicenseHistory.Enabled = Enable;
            btnDetain.Enabled = Enable;
        }
        void _LoadLicenseData(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.GetByID((int)_LicenseID);
            this.AcceptButton = btnDetain;
            lblLicenseID.Text = _LicenseID.ToString();
            _EnableBtnLLs(true);
            txtFineFees.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();





        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID.Value);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            int PersonID = _License.Driver.PersonID.Value;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        
        private void btnDetain_Click(object sender, EventArgs e)
        {
            int? DetainID = null;
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error:Some fileds are not valid ! Please check the red icons.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtFineFees.Text.Trim(), out decimal Fees))
            {
                MessageBox.Show("An unexpected Error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing txtFineFees to decimal ."));
                return;
            }
            try
            {
                if (_LicenseID == null)
                {
                    MessageBox.Show($"Error:License is not found !",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DetainID = clsLicense.GetByID(_LicenseID).Detain(Fees, clsGlobal.CurrentUser.UserID);
                if (DetainID == null)
                    throw new Exception($"Detain for License Failed.");



                lblDetainID.Text = DetainID.ToString();
                MessageBox.Show("Detaind succeeded", "Detain",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFineFees.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                btnDetain.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Detain Failed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }
        }




        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {

            _LoadLicenseData(LicenseID);
            if (!_License.IsActive)
            {
                _EnableBtnLLs(true);
                this.AcceptButton = btnDetain;
            }
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {

                errorProvider1.SetError(txtFineFees, "This Field is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }
            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees must be Numeric !");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }
        }
    }
}
