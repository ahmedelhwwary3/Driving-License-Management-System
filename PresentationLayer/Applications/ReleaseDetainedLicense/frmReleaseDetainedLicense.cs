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

namespace PresentationLayer.Applications.ReleaseDetainedLicense
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int? _DetainID = null;
        public clsDetainedLicense _DetainedLicense = new clsDetainedLicense();
        int? _LicenseID = null;
        enum enMode { Known,unKnown}
        enMode _Mode = enMode.unKnown;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            _Mode= enMode.unKnown;
        }
        public frmReleaseDetainedLicense(int DetainID)
        {
            InitializeComponent();
            _DetainID= DetainID;
            _Mode = enMode.Known;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo
                ((int)clsDetainedLicense.GetByID(_DetainID).LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            frmShowLicenseHistory frm = new frmShowLicenseHistory
                (clsDetainedLicense.GetByID(_DetainID).License.Driver.PersonID.Value);
            frm.ShowDialog();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void _SetTitle()
        {
            lblTitle.Text = "Release Detained License";
            this.Text = "Release Detained License";
        }
        void _SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ReleaseDetainedLicense))
                return;
            _SetFocusOntxtFilter();
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.
                ctrlDriverLicenseInfoWithFilter.enLicenseService.Release;
            _ResetDefaultValues();
            if (_Mode == enMode.Known)
                _LoadDetainedLicenseInKnownMode();
                

        }
       void _LoadDetainedLicenseInKnownMode()
        {
            _DetainedLicense = clsDetainedLicense.GetByID(_DetainID.Value);
            ctrlDriverLicenseInfoWithFilter1.PerformClickBtnFindLicense(_DetainedLicense.LicenseID.Value);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }
        void _ResetDefaultValues()
        {
            _SetTitle();
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            lblApplicationFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            lblFineFees.Text = "[$$$$]";
            lblApplicationID.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblDetainDate.Text = "[????]";
            lblDetainID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            ///Release will be allowed only if :-
            //1.Find License by ID (OnLicenseSelected)-> FindByID Mode
            //(or)
            //2.License Loaded successfully ->Known Mode
            btnRelease.Enabled = false;
        }

       
        private void btnRelease_Click(object sender, EventArgs e)
        {
            int? ApplicationID = null;
            bool IsReleased = false;
            clsDetainedLicense DetainedLicense = clsDetainedLicense.GetByID(_DetainID.Value);
            try
            {
                IsReleased = DetainedLicense.Release_BizLogic(DetainedLicense.FineFees, clsGlobal.CurrentUser.UserID, ref ApplicationID);
                if (!IsReleased || _LicenseID == null || clsGlobal.CurrentUser.UserID == null || ApplicationID == null)
                    throw new Exception($"Release License Failed.");

                lblApplicationID.Text = ApplicationID.ToString();
                MessageBox.Show("Release License succeeded", "Released",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnRelease.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Release Failed because some data is missing !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }
        }
         
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)

        {
            this.AcceptButton = btnRelease;

            _LicenseID = LicenseID;
            this._DetainedLicense = clsDetainedLicense.GetByLicenseID(_LicenseID);
            btnRelease.Enabled = true;
            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            int ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            decimal ApplicationFees = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID);
            decimal FineFees = _DetainedLicense.FineFees;//Fine is fixed as the last detain calculated

            _DetainID = _DetainedLicense.DetainID;
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = clsFormat.DateToShortString(_DetainedLicense.DetainDate);
            lblApplicationFees.Text = ApplicationFees.ToString("F2") + " $";
            lblFineFees.Text = FineFees.ToString("F2") + " $";
            lblTotalFees.Text = (ApplicationFees + FineFees).ToString("F2") + " $";
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationID.Text = _DetainedLicense.License.ApplicationID.ToString();
        }



    }
}
