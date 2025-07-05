using BusinessLayer.Core;
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
using static BusinessLayer.Core.clsUsersPermissions;
using static PresentationLayer.Global.clsValidation;
using static PresentationLayer.Global.clsGlobalData;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Licenses.DetainLicense
{
    public partial class frmDetainLicense : clsBaseForm
    {
        private int? _LicenseID = null;
        clsLicense _License = new clsLicense();
        private int? _PersonID = null;

        decimal _FineFees => clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense);

        public frmDetainLicense()
        {
            InitializeComponent();
            SetTheme(this);
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.LicenseService = LocalLicenses.Controls
                .ctrlDriverLicenseInfoWithFilter.enLicenseService.Detain;
            SetFocusOntxtFilter();
            ResetGeneralValues();
        }

        void SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }

        void ResetGeneralValues()
        {
            llShowLicenseHistory.Enabled = false;
            EnableBtnLLs(false);
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            txtFineFees.Text = _FineFees.ToString("F2");
            lblCreatedByUser.Text = clsGlobalData.CurrentUser.UserName;
            lblDetainDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblDetainID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            txtFineFees.Text = "";
            SetTitle("Detain License");
        }

        void EnableBtnLLs(bool Enable)
        {
            llShowLicenseInfo.Enabled = Enable;
            llShowLicenseHistory.Enabled = Enable;
            btnDetain.Enabled = Enable;
        }

        void LoadLicenseData(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.GetByID((int)_LicenseID);
            this.AcceptButton = btnDetain;
            lblLicenseID.Text = _LicenseID.ToString();
            EnableBtnLLs(true);
            txtFineFees?.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID.Value);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = _License.Driver.PersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
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
                clsGlobalData.WindownsEventLog.Log(new FormatException("Error while parsing txtFineFees to decimal ."));
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

                DetainID = clsLicense.GetByID(_LicenseID.Value).Detain(Fees,CurrentUser.UserID.Value);
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
                WindownsEventLog?.Log(ex);
                MessageBox.Show("An unexpected error occurred.", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            LoadLicenseData(LicenseID);
            if (!_License.IsActive)
            {
                EnableBtnLLs(true);
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

            if (!IsNumber(txtFineFees.Text))
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
