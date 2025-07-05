using BusinessLayer.Core;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;
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

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class ctrlDrivingLicenesApplicationInfo : clsBaseCtrl
    {
        clsApplication _BaseApplication=new clsApplication();
        clsLocalDrivingLicenseApplication _LocalApplication
            =new clsLocalDrivingLicenseApplication();
        public ctrlDrivingLicenesApplicationInfo()
        {
            InitializeComponent();
            SetTheme(this);
        }
            


        public clsLocalDrivingLicenseApplication LocalApplication 
            => _LocalApplication;
        public clsApplication BaseApplication
            => _BaseApplication;
        public void ResetDefaultValues()
        {
            ctrlApplicationBasicInfo1.ResetDefaultValues();
            lblAppliedForLicenseClass.Text = "[????]";
            lblLocalID.Text = "[????]";
            lblPassedTests.Text = "[????]";
            llShowLicenseInfo.Enabled = false;
        }
        public void LoadLocalApplication(int LocalDrivingLicenseApplicationID)
        {
             
            _LocalApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalDrivingLicenseApplicationID);
            if (_LocalApplication == null)
            {
                MessageBox.Show($"Local driving license application is not found "
                    ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }

            ctrlApplicationBasicInfo1.LoadApplication((int)_LocalApplication.ApplicationID);
            lblAppliedForLicenseClass.Text = _LocalApplication.LicenseClass.ClassName;
            lblLocalID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblPassedTests.Text = (_LocalApplication.GetPassedTests()).ToString();
            llShowLicenseInfo.Enabled = clsLicense.HasPersonActiveLicensePerLicenseClass((int)_LocalApplication.ApplicantPersonID,(int)_LocalApplication.LicenseClassID);
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int? LicenseID = _LocalApplication.GetActiveLicenseID();
            if (LicenseID != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo((int)LicenseID);
                frm.ShowDialog();
                //This form does not allow modify .. no need to refresh
            }
            else
                MessageBox.Show("Error:This Person Does not have an active license !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
