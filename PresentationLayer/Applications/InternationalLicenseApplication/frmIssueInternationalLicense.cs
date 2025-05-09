using BusinessLayer;
using PresentationLayer.Global;
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
using static BusinessLayer.clsLicenseClass;

namespace PresentationLayer.Applications.InternationalLicenseApplication
{
    public partial class frmIssueInternationalLicense : Form
    {
        //Person can get 2 Licenses (Local,International)
        //But person must first have Local License OrdinaryClass then he can have International License
        //2 Liceses are not attached to the same application , LocalApp + NewInternationalApp
        //But LocalLicenseID is attached in the NewInternationalLicense Table (just ID not Application)
        private int? _LocalLicenseID = null;
        clsLicense _LocalLicense = new clsLicense();
        private int? _InternationalLicenseID = null;
 
        int _DefaultValidityLength =
            (int)clsLicenseClass.enDefaultValidityLength.Class3_ordinary_driving_license;
        int? _ApplicationTypeID = (int?)clsApplication.enApplicationType.NewInternationalLicense;
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
     
        }
        void _SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.IssueInternationalLicense))
                return;
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.
                ctrlDriverLicenseInfoWithFilter.enLicenseService.IssueInternational;
            _SetFocusOntxtFilter();
            _ResetGeneralValues();

        }
        void _ResetGeneralValues()
        {
            ctrlDriverLicenseInfoWithFilter1.Enabled = true;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            _SetTitle();
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text; ;
            lblExpirationDate.Text = clsFormat.DateToShortString(DateTime.Now.AddYears(_DefaultValidityLength));
            lblFees.Text = clsApplicationType.GetApplicationTypeFees((int)_ApplicationTypeID).ToString("F2");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblLocalLicenseID.Text = "[????]";
            lblLocalLicenseID.Text = "[????]";
            lblApplicationID.Text = "[????]";
        }

        void _SetTitle()
        {
            lblTitle.Text = "Issue International License";
            this.Text = "Issue International License";
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)_LocalLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            int? PersonID = clsLicense.GetByID(_LocalLicenseID).Driver.PersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)PersonID);
            frm.ShowDialog();

        }
        void _EnableBtnLLs(bool Enabled)
        {
            btnIssueLicense.Enabled = Enabled;
            llShowLicenseInfo.Enabled = Enabled;
            llShowLicenseHistory.Enabled = Enabled;
        }
        void _LoadLicense(int LicenseID)
        {
            _LocalLicenseID = LicenseID;
            _LocalLicense = clsLicense.GetByID(LicenseID);
            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            lblLocalLicenseID.Text = _LocalLicense.LicenseID.ToString();
            _EnableBtnLLs(true);
        }





        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            try
            {

                clsInternationalLicense InternationalLicense = new clsInternationalLicense();
                //those are the information for the base application, because it inhirts from application, they are part of the sub class.

                InternationalLicense.ApplicantPersonID = _LocalLicense.Driver.PersonID;
                InternationalLicense.ApplicationDate = DateTime.Now;
                InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                InternationalLicense.LastStatusDate = DateTime.Now;
                InternationalLicense.PaidFees = clsApplicationType.
                    GetApplicationTypeFees((int)clsApplication.enApplicationType.NewInternationalLicense);
                InternationalLicense.InterntaionalCreatedByUserID = clsGlobal.CurrentUser.UserID;
                InternationalLicense.DriverID = _LocalLicense.DriverID;
                InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicense.LicenseID;
                InternationalLicense.IssueDate = DateTime.Now;
                InternationalLicense.ExpirationDate = DateTime.Now.AddYears(_DefaultValidityLength);
                InternationalLicense.InterntaionalCreatedByUserID = clsGlobal.CurrentUser.UserID;
                InternationalLicense.CreatedByUserID = _LocalLicense.CreatedByUserID;
                InternationalLicense.IsActive = true;
                InternationalLicense.LoggedUserID = clsGlobal.CurrentUser.UserID;
                if (!InternationalLicense.Save())
                    throw new Exception($"Save InternationalLicense Failed.");

                _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
                lblApplicationID.Text = InternationalLicense.InternationalApplicationID.ToString();
                lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                MessageBox.Show($"International License Issued Successfully with ID " +
                    $"{InternationalLicense.InternationalLicenseID.ToString()}",
                    "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssueLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:Issue International License Failed !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            _LoadLicense(LicenseID);
            this.AcceptButton = btnIssueLicense;
        }
    }
}
