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

namespace PresentationLayer.Applications.ReplacementForDamagedOrLostLicense
{
    public partial class frmReplacementForDamagedOrLostLicenses : Form
    {
        private int? _OldLicenseID = null;
        clsLicense _OldLicense = new clsLicense();
        int? _NewLicenseID = null;

        int _ApplicationTypeID => rbDamagedLicense.Enabled ?
            (int)clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense :
            (int)clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
        public frmReplacementForDamagedOrLostLicenses()
        {
            InitializeComponent();
        }
        void _SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        private void frmReplacementForDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ReplaceLicense))
                return;
            _SetFocusOntxtFilter();
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.
                ctrlDriverLicenseInfoWithFilter.enLicenseService.ReplaceForLostOrDamaged;
            _ResetGeneralValues();
        }
        void _EnableBtnLL(bool Enabled)
        {
            btnIssueReplacement.Enabled = Enabled;
            llShowLicenseHistory.Enabled = Enabled;
        }
        void _ResetGeneralValues()
        {
            llShowNewLicenseInfo.Enabled = false;
            lblReplaceLicenseID.Text = "[????]";//New
            lblApplicationID.Text = "[????]";//New
            lblOldLicenseID.Text = "[????]";//It will be shown When Selecting License in Both Modes
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.GetByID(_ApplicationTypeID).ApplicationFees.ToString("F2");
            rbDamagedLicense.PerformClick();//Set Title
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            _EnableBtnLL(false);
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            int? NewLicenseID = _ReplaceAndGetNewLicenseID();
            try
            {
                if (NewLicenseID == null)
                    throw new Exception($"Replace License Failed.");
                _NewLicenseID = NewLicenseID;
                lblReplaceLicenseID.Text = _NewLicenseID.ToString();
                llShowNewLicenseInfo.Enabled = true;
                btnIssueReplacement.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                gbReplacementFor.Enabled = false;
                MessageBox.Show("License Replacement succeeded", "succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:License Replacement Failed !", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }
        }
        int? _ReplaceAndGetNewLicenseID()
            => rbDamagedLicense.Checked ? _OldLicense.ReplaceForDamaged(clsGlobal.CurrentUser.UserID) :
            _OldLicense.ReplaceForLost(clsGlobal.CurrentUser.UserID);
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID.Value);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_OldLicense.Application.ApplicantPersonID.Value);
            frm.ShowDialog();
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Damaged License";
            lblTitle.Text = "Replacement For Damaged License";
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Lost License";
            lblTitle.Text = "Replacement For Lost License";
        }


        void _LoadLicenseDataByLicenseID(int OldLicenseID)
        {
            _OldLicense = clsLicense.GetByID(OldLicenseID);
            _EnableBtnLL(true);
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
        }
        

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int OldLicenseID)
        {
            _LoadLicenseDataByLicenseID(OldLicenseID);
            this.AcceptButton = btnIssueReplacement;
        }
    }
}
