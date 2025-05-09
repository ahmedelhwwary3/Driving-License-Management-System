using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Licenses;
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

namespace PresentationLayer.Applications.RenewLocalLicense
{
    public partial class frmRenewLocalLicense : Form
    {
 
        clsLicense _OldLicense = new clsLicense();
        int? _NewLicenseID = null;
        decimal _ApplicationTypeFees
            => clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.RenewDrivingLicenseService);
        decimal _LicenseFees
            => clsLicenseClass.GetByID(_OldLicense.LicenseID.Value).ClassFees;
        int? _DefaultValidityLength
            => (int)clsLicenseClass.GetByID((int)_OldLicense.LicenseClass).DefaultValidityLength;



        public frmRenewLocalLicense()
        {
            InitializeComponent();

        }



        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void _EnableBtnLLs(bool Enable)
        {
            llShowLicenseHistory.Enabled = Enable;
            btnRenewLicense.Enabled = Enable;
        }

        void _SetTitle()
        {
            this.Text = "Renew Old OldLicense";
            lblTitle.Text = "Renew Old OldLicense";
        }
        void _ResetGeneralValues()
        {
            _SetTitle();
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            _EnableBtnLLs(false);//will diable when Selecting in (Known Mode or Find Mode)
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            //Renew (ApplicationID,LicenseID)
            lblRenewLicenseID.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblExpirationDate.Text = "[????]";
            lblIssueDate.Text = lblApplicationDate.Text;
            lblOldLicenseID.Text = "[????]";
            lblApplicationFees.Text = _ApplicationTypeFees.ToString("F2");
            lblLicenseFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        void _LoadOldLicense(int LicenseID)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.RenewLocalLicense))
                return;
            _OldLicense = clsLicense.GetByID(LicenseID);
            _EnableBtnLLs(true);
            ctrlDriverLicenseInfoWithFilter1.Enabled = true;
            lblExpirationDate.Text = clsFormat.DateToShortString(DateTime.Now.AddYears((int)_DefaultValidityLength));
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lblLicenseFees.Text = _LicenseFees.ToString("F2");
            lblTotalFees.Text = (_LicenseFees + _ApplicationTypeFees).ToString("F2");
        }
        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls
                .ctrlDriverLicenseInfoWithFilter.enLicenseService.Renew;
            _ResetGeneralValues();
            _SetFocusOntxtFilter();
        }

        void _SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
        }
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            int? NewLicenseID = _OldLicense.RenewOldLicense(clsGlobal.CurrentUser.UserID.Value);
            clsLicense NewLicense = clsLicense.GetByID(NewLicenseID.Value);
            try
            {
                if (NewLicense == null)
                    throw new Exception($"Renewing Old License Failed.");

                lblRenewLicenseID.Text = NewLicenseID.ToString();
                lblApplicationID.Text = NewLicense.ApplicationID.ToString();
                _NewLicenseID = NewLicenseID;//for llShowNewLicense
                btnRenewLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                _OldLicense = NewLicense;
                MessageBox.Show($"Renew Old License succeeded with new License ID {NewLicenseID} ",
                    "Confirm",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Renewing Old License Failed", "Error",
                   MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_OldLicense.LicenseID.Value);
            frm.ShowDialog();
        }
        void _RefreshForm()
            => frmRenewLocalLicense_Load(null, null);

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_NewLicenseID.Value);
            frm.ShowDialog();
            _RefreshForm();
        }

       
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            _LoadOldLicense(LicenseID);
            this.AcceptButton = this.btnRenewLicense;
        }
    }
}

