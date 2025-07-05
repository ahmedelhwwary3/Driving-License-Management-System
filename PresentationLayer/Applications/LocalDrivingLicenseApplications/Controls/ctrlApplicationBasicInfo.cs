using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Core.clsUsersPermissions;
using static PresentationLayer.Global.clsFormat;
using System.Windows.Forms;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class ctrlApplicationBasicInfo : clsBaseCtrl
    {
        
        private clsApplication _Application = new clsApplication();
        public ctrlApplicationBasicInfo()  
        {
            InitializeComponent();
            SetTheme(this);
        }

        public clsApplication Application=> _Application;
        void EnableDisable(bool TrueFalse)
        {
            gbApplication.Enabled = TrueFalse?true:false;
            llViewPersonInfo.Enabled = TrueFalse ? true : false;
        }

        public void ResetDefaultValues()
        {
            EnableDisable(false);
            lblApplicant.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblDate.Text = "[????]";
            lblFees.Text = "[????]";
            lblID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblType.Text = "[????]";
        }
        
        public void LoadApplication(int ApplicationID)
        {
            _Application = clsApplication.GetApplicationByID(ApplicationID);
            if (_Application == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"Error:Application was not found !",
                    "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnableDisable(true);
            lblApplicant.Text = _Application.ApplicantPersonID.ToString();
            lblCreatedByUser.Text = _Application.CreatedByUser.UserName;
            lblDate.Text = DateToShortString(_Application.ApplicationDate);
            lblStatusDate.Text = DateToShortString(_Application.LastStatusDate);
            lblType.Text = clsApplicationType.GetByID((int)_Application.ApplicationTypeID).ApplicationTypeTitle;
            lblFees.Text = _Application.PaidFees.ToString("F2");
            lblID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = (_Application.ApplicationStatusText);


        }

        

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            int PersonID = _Application.ApplicantPersonID;
            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            //No need to refresh because PersonID shown in CTRL can not be changed

        }
    }
}
