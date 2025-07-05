using PresentationLayer.Licenses;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static PresentationLayer.Global.clsGlobalData;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Core;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsApplication;
using static PresentationLayer.Global.clsFormat;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Applications.ReleaseDetainedLicense
{
    public partial class frmReleaseDetainedLicense : clsBaseForm
    {
        private int? _DetainID = null;
        public clsDetainedLicense _DetainedLicense = new clsDetainedLicense();
        int _LicenseID = default;
        enum enMode { Known,unKnown}
        enMode _Mode = enMode.unKnown;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            SetTheme(this);
            _Mode = enMode.unKnown;
        }
        public frmReleaseDetainedLicense(int DetainID)
        {
            InitializeComponent();
            _DetainID= DetainID;
            _Mode = enMode.Known;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             
            frmShowLicenseInfo frm = new frmShowLicenseInfo
                ((int)clsDetainedLicense.GetByDetainID(_DetainID.Value).LicenseID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        
            frmShowLicenseHistory frm = new frmShowLicenseHistory
                (clsDetainedLicense.GetByDetainID(_DetainID.Value).License.Driver.PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);

        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void SetTitle()
        {
            lblTitle.Text = "Release Detained License";
            base.SetTitle("Release Detained License");
        }
        void SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            SetFocusOntxtFilter();
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.
                ctrlDriverLicenseInfoWithFilter.enLicenseService.Release;
            ResetDefaultValues();
            if (_Mode == enMode.Known)
                LoadDetainedLicenseInKnownMode();
                

        }
       void LoadDetainedLicenseInKnownMode()
        {
            _DetainedLicense = clsDetainedLicense.GetByDetainID(_DetainID.Value);
            ctrlDriverLicenseInfoWithFilter1.PerformClickBtnFindLicense(_DetainedLicense.LicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }
        void ResetDefaultValues()
        {
            SetTitle();
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
            int? ApplicationID = default;
            bool IsReleased = false;
            clsDetainedLicense DetainedLicense = clsDetainedLicense.GetByDetainID(_DetainID.Value);
            try
            {
                IsReleased = DetainedLicense.Release(DetainedLicense.FineFees,
                    CurrentUser.UserID.Value, out ApplicationID);
                if (!IsReleased ||!CurrentUser.UserID.HasValue)
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
                MessageBox.Show("Error:Release Failed !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                  WindownsEventLog?.Log(ex);
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
            int ApplicationTypeID = (int)enApplicationType.ReleaseDetainedDrivingLicense;
            decimal ApplicationFees = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID);
            decimal FineFees = _DetainedLicense.FineFees;//Fine is fixed as the last detain calculated

            _DetainID = _DetainedLicense.DetainID;
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = DateToShortString(_DetainedLicense.DetainDate);
            lblApplicationFees.Text = ApplicationFees.ToString("F2") + " $";
            lblFineFees.Text = FineFees.ToString("F2") + " $";
            lblTotalFees.Text = (ApplicationFees + FineFees).ToString("F2") + " $";
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblCreatedByUser.Text = CurrentUser.UserName;
            lblApplicationID.Text = _DetainedLicense.License.ApplicationID.ToString();
        }



    }
}
