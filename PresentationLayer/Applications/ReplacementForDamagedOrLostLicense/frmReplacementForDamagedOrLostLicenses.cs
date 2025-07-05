﻿using PresentationLayer.Licenses;
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
using static BusinessLayer.Core.clsUsersPermissions;
using System.Windows.Forms;
using BusinessLayer.Core;
using static PresentationLayer.Global.clsFormat;
using static BusinessLayer.Core.clsApplication;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Applications.ReplacementForDamagedOrLostLicense
{
    public partial class frmReplacementForDamagedOrLostLicenses : clsBaseForm
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
            SetTheme(this);
        }
        void SetFocusOntxtFilter()
        {
            this.BeginInvoke(new Action(() => ctrlDriverLicenseInfoWithFilter1.FilterFocus()));
            this.AcceptButton = ctrlDriverLicenseInfoWithFilter1.FindButton;
        }
        private void frmReplacementForDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            SetFocusOntxtFilter();
            ctrlDriverLicenseInfoWithFilter1.LicenseService = Licenses.LocalLicenses.Controls.
                ctrlDriverLicenseInfoWithFilter.enLicenseService.ReplaceForLostOrDamaged;
            ResetGeneralValues();
        }
        void EnableBtnLL(bool Enabled)
        {
            btnIssueReplacement.Enabled = Enabled;
            llShowLicenseHistory.Enabled = Enabled;
        }
        void ResetGeneralValues()
        {
            llShowNewLicenseInfo.Enabled = false;
            lblReplaceLicenseID.Text = "[????]";//New
            lblApplicationID.Text = "[????]";//New
            lblOldLicenseID.Text = "[????]";//It will be shown When Selecting License in Both Modes
            lblCreatedByUser.Text = CurrentUser.UserName;
            lblApplicationDate.Text = DateToShortString(DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.GetByID(_ApplicationTypeID).ApplicationFees.ToString("F2");
            rbDamagedLicense.PerformClick();//Set Title
            ctrlDriverLicenseInfoWithFilter1.ResetCTRL();
            EnableBtnLL(false);
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
                   WindownsEventLog?.Log(ex);
            }
        }
        int? _ReplaceAndGetNewLicenseID()
        {
            if(rbDamagedLicense.Checked)
            {
                int DamagedPenaltyPoints = clsDriverPenaltyPoints.GetPenaltyPointsByApplicationTypeID((int)enApplicationType.ReplacementForDamagedDrivingLicense);
                return _OldLicense.ReplaceForDamaged(CurrentUser.UserID.Value, DamagedPenaltyPoints);
            }
            int LostPenaltyPoints = clsDriverPenaltyPoints.GetPenaltyPointsByApplicationTypeID((int)enApplicationType.ReplacementForLostDrivingLicense);
            return _OldLicense.ReplaceForLost(CurrentUser.UserID.Value, LostPenaltyPoints);
        }
           
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID.Value);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_OldLicense.Application.ApplicantPersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
           base.SetTitle( "Replacement For Damaged License");
            lblTitle.Text = "Replacement For Damaged License";
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            base.SetTitle("Replacement For Lost License");
            lblTitle.Text = "Replacement For Lost License";
        }


        void LoadLicenseDataByLicenseID(int OldLicenseID)
        {
            _OldLicense = clsLicense.GetByID(OldLicenseID);
            EnableBtnLL(true);
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
        }
        

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int OldLicenseID)
        {
            LoadLicenseDataByLicenseID(OldLicenseID);
            this.AcceptButton = btnIssueReplacement;
        }
    }
}
