using BusinessLayer;
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
using System.Windows.Forms;

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        
        private clsApplication _Application = new clsApplication();
        public ctrlApplicationBasicInfo()
            => InitializeComponent();

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
            _Application = clsApplication.GetByID(ApplicationID);
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
            lblDate.Text = clsFormat.DateToShortString(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShortString(_Application.LastStatusDate);
            lblType.Text = clsApplicationType.GetByID((int)_Application.ApplicationTypeID.Value).ApplicationTypeTitle;
            lblFees.Text = _Application.PaidFees.ToString("F2");
            lblID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = (_Application.ApplicationStatusText);


        }

        

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            int PersonID = _Application.ApplicantPersonID.Value;
            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialog();
            //No need to refresh because PersonID shown in CTRL can not be changed

        }
    }
}
