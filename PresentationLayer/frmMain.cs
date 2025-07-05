using BusinessLayer.Core;
using Microsoft.VisualBasic.ApplicationServices;
using PresentationLayer.Applications.ApplicationTypes;
using PresentationLayer.Applications.InternationalLicenseApplication;
using PresentationLayer.Applications.LocalDrivingLicenseApplications;
using PresentationLayer.Applications.ReleaseDetainedLicense;
using PresentationLayer.Applications.RenewLocalLicense;
using PresentationLayer.Applications.ReplacementForDamagedOrLostLicense;
using PresentationLayer.Drivers;
using PresentationLayer.Global;
using PresentationLayer.Licenses.DetainLicense;
using PresentationLayer.Licenses.InternationalLicenses;
using PresentationLayer.Login;
using PresentationLayer.People;
using PresentationLayer.Tests;
using PresentationLayer.Tests.TestTypes;
using PresentationLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using static BusinessLayer.Core.clsUsersPermissions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Helpers.Logger.clsRegistry;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer
{
    public partial class frmMain : clsBaseForm
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            SetTheme(this);
            _frmLogin = frmLogin;
            this.FormClosed += (sender, e) => _frmLogin.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsPerson.IsExist(CurrentUser?.PersonID))
            {
                MessageBox.Show("Error:Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmUserInfo frm = new frmUserInfo(CurrentUser.UserID.Value);
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            this.Close();
            //Login Handled using FormClosed event
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsPerson.IsExist(CurrentUser?.PersonID))
            {
                MessageBox.Show("Error:Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmChangePassword frm = new frmChangePassword(CurrentUser.UserID.Value);
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUsersManagement frm = new frmUsersManagement();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPeopleManagement frm = new frmPeopleManagement();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmReplacementForDamagedOrLostLicenses frm = new frmReplacementForDamagedOrLostLicenses();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void releaseDetainedDriToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit")?.Permissions, frm);
        }

        private void rerakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialogIfAuthorized(GetByAccessType("View")?.Permissions, frm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Access Level :{CurrentUser.PermissionsAccess}";
            DataTable dtPermissions = GetAllPermissions();
            byte UserPermissionsCount = 0;
            foreach (DataRow row in dtPermissions.Rows)
            {
                byte? P = row["Permissions"].ToNullableByte();
                if ((CurrentUser.Permissions & P) == P)
                    UserPermissionsCount++;
            }
            if (CurrentUser.Permissions == GetByAccessType("Admin").Permissions)
                UserPermissionsCount--;//Admin is not counted  

            progressBar1.Value = 0;
            progressBar1.Maximum = dtPermissions.Rows.Count - 1;//Admin is not counted
            for (int i = 0; i < UserPermissionsCount; i++)
            {
                progressBar1.Value += 1;
                lblPercent.Text = (progressBar1.Value * 100.00 / progressBar1.Maximum).ToString("F2") + " %";
                Thread.Sleep(300);
                progressBar1.Refresh();
            }
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmListUserLogins frm = new frmListUserLogins();
            frm.ShowDialogIfAuthorized(GetByAccessType("Admin")?.Permissions, frm);
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListOperationLogs frm = new frmListOperationLogs();
            frm.ShowDialogIfAuthorized(GetByAccessType("Admin")?.Permissions, frm);
        }

        private void manageUsersPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmEditUsersPermissions frm = new frmEditUsersPermissions();
            frm.ShowDialogIfAuthorized(GetByAccessType("Admin")?.Permissions, frm);
        }

        private void updateUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUpdateUsers frm = new frmUpdateUsers();
            frm.ShowDialogIfAuthorized(GetByAccessType("Admin")?.Permissions, frm);
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTheme?.LoadTheme(enThemeMode.Default);
            SetUserThemeInRegistry((int)enThemeMode.Default);
            base.SetTheme(this);

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTheme?.LoadTheme(enThemeMode.Dark);
            SetUserThemeInRegistry((int)enThemeMode.Dark);
            base.SetTheme(this);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTheme?.LoadTheme(enThemeMode.Admin);
            SetUserThemeInRegistry((int)enThemeMode.Admin);
            base.SetTheme(this);
        }
        
    }
}
