using PresentationLayer.Global;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static PresentationLayer.Global.clsGlobalData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Core;
using static BusinessLayer.Core.clsUsersPermissions;
using DataAccessLayer.Core;
using static PresentationLayer.Global.clsFormat;
using static BusinessLayer.Core.clsApplication;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Applications.RenewLocalLicense
{
    public partial class frmRenewLocalLicense : clsBaseForm
    {
 
        clsLicense _OldLicense = new clsLicense();
        int? _NewLicenseID = null;
        decimal _ApplicationTypeFees
            => clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.RenewDrivingLicenseService);
        decimal _LicenseFees
            => clsLicenseClass.GetByID(_OldLicense.LicenseID.Value).ClassFees;
        int _DefaultValidityLength
            => (int)clsLicenseClass.GetByID((int)_OldLicense.LicenseClass).DefaultValidityLength;



        public frmRenewLocalLicense()
        {
            InitializeComponent();
            SetTheme(this);

        }



        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void EnableBtnLLs(bool Enable)
        {
            llShowLicenseHistory.Enabled = Enable;
            btnRenewLicense.Enabled = Enable;
        }

        void SetTitle()
        {
            base.SetTitle("Renew Old OldLicense");
            lblTitle.Text = "Renew Old OldLicense";
        }
        void ResetGeneralValues()
        {
            SetTitle();
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            EnableBtnLLs(false);//will diable when Selecting in (Known Mode or Find Mode)
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            //Renew (ApplicationID,LicenseID)
            lblRenewLicenseID.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblCreatedByUser.Text = clsGlobalData.CurrentUser.UserName;
            lblExpirationDate.Text = "[????]";
            lblIssueDate.Text = lblApplicationDate.Text;
            lblOldLicenseID.Text = "[????]";
            lblApplicationFees.Text = _ApplicationTypeFees.ToString("F2");
            lblLicenseFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        void LoadOldLicense(int LicenseID)
        {
            if (!CheckUserAccess(GetByAccessType("AddEdit").Permissions.Value))
                return;
            _OldLicense = clsLicense.GetByID(LicenseID);
            EnableBtnLLs(true);
            ctrlDriverLicenseInfoWithFilter1.Enabled = true;
            lblExpirationDate.Text = DateToShortString(DateTime.Now.AddYears((int)_DefaultValidityLength));
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lblLicenseFees.Text = _LicenseFees.ToString("F2");
            lblTotalFees.Text = (_LicenseFees + _ApplicationTypeFees).ToString("F2");
        }
        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls
                .ctrlDriverLicenseInfoWithFilter.enLicenseService.Renew;
            ResetGeneralValues();
            SetFocusOntxtFilter();
        }

        void SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
        }
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            int PenaltyPoints = clsDriverPenaltyPoints.GetPenaltyPointsByApplicationTypeID((int)enApplicationType.RenewDrivingLicenseService);
            int? NewLicenseID = _OldLicense.Renew(CurrentUser.UserID.Value,PenaltyPoints);
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
                WindownsEventLog?.Log(ex);
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_OldLicense.LicenseID.Value);
            frm.ShowDialog();
        }


        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;
            int? PersonID = _OldLicense.Driver.PersonID;
            if(!PersonID.HasValue)
            {
                MessageBox.Show("Error:Person is not Existed !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID.Value);
            frm.ShowDialog();
        }

       
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            LoadOldLicense(LicenseID);
            this.AcceptButton = this.btnRenewLicense;
        }
    }
}

