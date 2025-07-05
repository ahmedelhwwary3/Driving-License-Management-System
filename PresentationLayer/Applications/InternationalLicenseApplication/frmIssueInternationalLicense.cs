using BusinessLayer.Core;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.Core.clsLicenseClass;
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Global.clsFormat;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsApplication;
using static PresentationLayer.Licenses.LocalLicenses.Controls.ctrlDriverLicenseInfoWithFilter;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Applications.InternationalLicenseApplication
{
    public partial class frmIssueInternationalLicense : clsBaseForm
    {
        //Person can get 2 Licenses (Local,International)
        //But person must first have Local License OrdinaryClass then he can have International License
        //2 Liceses are not attached to the same application , LocalApp + NewInternationalApp
        //But LocalLicenseID is attached in the NewInternationalLicense Table (just ID not Application)
        private int _LocalLicenseID = default;
        clsLicense _LocalLicense = new clsLicense();
        private int? _InternationalLicenseID = null;
 
        int _DefaultValidityLength =
            (int)clsLicenseClass.enDefaultValidityLength.Class3_ordinary_driving_license;
        int? _ApplicationTypeID = (int?)clsApplication.enApplicationType.NewInternationalLicense;
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
            SetTheme(this);
        }
        void SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            ctrlDriverLicenseInfoWithFilter1.LicenseService =enLicenseService.IssueInternational;
            SetFocusOntxtFilter();
            ResetGeneralValues();

        }
        void ResetGeneralValues()
        {
            ctrlDriverLicenseInfoWithFilter1.Enabled = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            SetTitle(("Issue International License"));
            lblApplicationDate.Text = DateToShortString(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text; ;
            lblExpirationDate.Text = DateToShortString(DateTime.Now.AddYears(_DefaultValidityLength));
            lblFees.Text = clsApplicationType.GetApplicationTypeFees((int)_ApplicationTypeID).ToString("F2");
            lblCreatedByUser.Text = CurrentUser.UserName;
            lblLocalLicenseID.Text = "[????]";
            lblLocalLicenseID.Text = "[????]";
            lblApplicationID.Text = "[????]";
        }

        public new void SetTitle(string Title)
        {
            base.SetTitle(Title);
            this.Text = $"{Title}";
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)_LocalLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            int? PersonID = clsLicense.GetByID(_LocalLicenseID).Driver.PersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);

        }
        void EnableBtnLLs(bool Enabled)
        {
            btnIssueLicense.Enabled = Enabled;
            llShowLicenseInfo.Enabled = Enabled;
            llShowLicenseHistory.Enabled = Enabled;
        }
        void LoadLicense(int LicenseID)
        {
            _LocalLicenseID = LicenseID;
            _LocalLicense = clsLicense.GetByID(LicenseID);
            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            lblLocalLicenseID.Text = _LocalLicense.LicenseID.ToString();
            EnableBtnLLs(true);
        }





        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            try
            {

                clsInternationalLicense InternationalLicense = new clsInternationalLicense();

                InternationalLicense.DriverID = _LocalLicense.DriverID;
                InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicense.LicenseID.Value;
                InternationalLicense.IssueDate = DateTime.Now;
                InternationalLicense.ExpirationDate = DateTime.Now.AddYears(_DefaultValidityLength);
                InternationalLicense.IsActive = true;
                InternationalLicense.CreatedByUserID = CurrentUser.UserID.Value;
                InternationalLicense.PaidFees = clsApplicationType.GetApplicationTypeFees((int)enApplicationType.NewInternationalLicense);
                InternationalLicense.LoggedUserID = CurrentUser.UserID.Value;
                if (!InternationalLicense.Save())
                    throw new Exception($"Save InternationalLicense Failed.");

                _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID?.ToString();
                MessageBox.Show($"International License Issued Successfully with ID{lblInternationalLicenseID.Text}",
                    "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssueLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:Issue International License Failed !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                   WindownsEventLog?.Log(ex);
            }

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            LoadLicense(LicenseID);
            this.AcceptButton = btnIssueLicense;
        }
    }
}
