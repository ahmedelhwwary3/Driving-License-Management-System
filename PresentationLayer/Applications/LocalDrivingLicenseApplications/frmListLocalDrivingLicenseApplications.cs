using BusinessLayer.Core;
using PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.LocalLicenses;
using PresentationLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsTestType;
using static BusinessLayer.Core.clsApplication;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    public partial class frmListLocalDrivingLicenseApplications : clsBaseForm
    {
        Task task;
        DataTable _dtLocalDrivingLicenseApplications = new DataTable();


        void LoadLocalDrivingLicenseApplications()
        {
            lock (GlobalLockObject)
            {
                _dtLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationsList();
            }
        }


        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            SetTheme(this);
            dgvLocalApplications.DataBindingComplete += (sender, e)
                => FormatDGV();
        }
        void FormatDGV()
        {
            dgvLocalApplications.Sort(dgvLocalApplications
                .Columns["ApplicationDate"], ListSortDirection.Ascending);
            if (dgvLocalApplications.Columns.Count == 7)
            {
                dgvLocalApplications.Columns[0].HeaderText = "Local Application ID";
                dgvLocalApplications.Columns[0].Width = 120;

                dgvLocalApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalApplications.Columns[1].Width = 190;

                dgvLocalApplications.Columns[2].HeaderText = "National No";
                dgvLocalApplications.Columns[2].Width = 150;

                dgvLocalApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalApplications.Columns[3].Width = 280;

                dgvLocalApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalApplications.Columns[4].Width = 170;

                dgvLocalApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalApplications.Columns[5].Width = 100;

                dgvLocalApplications.Columns[6].HeaderText = "Status";
                dgvLocalApplications.Columns[6].Width = 100;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        void RefreshForm()
            => frmListLocalDrivingLicenseApplications_Load(null, null);

        private void btnAddNewLocalApp_Click(object sender, EventArgs e)
        {

            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm); RefreshForm();
        }
        void RefreshTotalCount()
            => lblRecords.Text = dgvLocalApplications.Rows.Count.ToString();
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            task = Task.Run(LoadLocalDrivingLicenseApplications);
            SetTitle("List Local Driving License Applications");
            cbFilterColumn.Text = "None";
            cbStatus.Visible = false;
            Task.WaitAll(task);
            dgvLocalApplications.DataSource = _dtLocalDrivingLicenseApplications;
            RefreshTotalCount();
            cbFilterColumn_SelectedIndexChanged(null, null);

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowLocalDrivingLicenseApplicationInfo frm = new frmShowLocalDrivingLicenseApplicationInfo((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterColumn.Text != "None" && cbFilterColumn.Text != "Status");
            cbStatus.Visible = cbFilterColumn.Text == "Status";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                return;
            }
           
            if (cbStatus.Visible)
                cbStatus.SelectedIndex = cbStatus.FindString("All");

        }
        string GetFitlerColumnDBName()
        {
            switch (cbFilterColumn.Text)
            {
                case "Local Driving License Application ID":
                    {
                        return "LocalDrivingLicenseApplicationID";

                    }
                case "Driving Class":
                    {
                        return "ClassName";

                    }
                case "National No":
                    {
                        return "NationalNo";

                    }
                case "Full Name":
                    {
                        return "FullName";

                    }
                case "Passed Tests":
                    {
                        return "PassedTests";

                    }
                case "Status":
                    {
                        return "Status";

                    }
                default:
                    {
                        return "None";
                    }

            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = GetFitlerColumnDBName();
            if (FilterColumn == "None")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                txtFilterValue.Visible = false;
                RefreshTotalCount();
                return;
            }
            if (txtFilterValue.Text.Trim() == "")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                RefreshTotalCount();
                return;
            }
            if (FilterColumn == "PassedTests" || FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            RefreshTotalCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            if (cbFilterColumn.Text == "Passed Tests" || cbFilterColumn.Text == "Local Driving License Application ID" || cbFilterColumn.Text == "ApplicationDate")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (MessageBox.Show("Are you sure you want to Delete this application?", "Confirm Delete"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.OK)
            {
                if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
                {
                    MessageBox.Show($"Error:An unexpected error happened !", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                    return;
                }
                if (!clsLocalDrivingLicenseApplication.IsExistByID(LocalApplicationID))
                {
                    MessageBox.Show($"Error:Local Driving License Application with ID{LocalApplicationID}" +
                        $" is not existed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!clsLocalDrivingLicenseApplication.DeleteByID(LocalApplicationID, CurrentUser.UserID.Value))
                {
                    MessageBox.Show("Application delete Failed " +
                          "Because The Local Driving License Application already has an appointment",
                          "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MessageBox.Show("Application was deleted successfully", "Confirm Delete",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();

            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalApplicationID);

            if (LocalApp == null)
            {
                MessageBox.Show($"Error:Driving License Application with ID " +
                    $"{LocalApplicationID} is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application ID {LocalApplicationID} through DGV"));
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this Application ?", "Confirm Cancel",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (!LocalApp.Cancel(CurrentUser.UserID.Value))
                {
                    MessageBox.Show("Error:Local Driving License Application cancel Failed", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Local Driving License Application was cancelled successfully", "Confirm",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }

        }







        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null || dgvLocalApplications.Rows.Count == 0)
            {
                e.Cancel = true;
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error while parsing dgvLocalApplications_LocalApplicationID to int."));
                e.Cancel = true;
                return;
            }
            clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalApplicationID);
            if (LocalApplication == null)
            {
                MessageBox.Show($"Error:Local Driving License Application was not found with ID" +
                    $" {LocalApplicationID.ToString()}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[5].Value is int PassedTestsCount))
            {
                MessageBox.Show($"Error:An unexpected error happened !",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error while parsing dgvLocalApplications_PassedTestCount to int."));
                e.Cancel = true;
                return;
            }

            bool HasPassedVisionTest = LocalApplication.HasPassedTestType(enTestType.Vision);
            bool HasPassedWrittenTest = LocalApplication.HasPassedTestType(enTestType.Written);
            bool HasPassedStreetTest = LocalApplication.HasPassedTestType(enTestType.Street);

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled =
                (LocalApplication.ApplicationStatus == (int)clsApplication.enApplicationStatus.New && PassedTestsCount == 3);
            //User can not edit the LocalApplication.ClassType if the person passed the StreetTest as this Test depends on the ClassType
            editApplicationToolStripMenuItem.Enabled =
                (LocalApplication.ApplicationStatus == (int)enApplicationStatus.New && !HasPassedStreetTest);

            cancelApplicationToolStripMenuItem.Enabled = editApplicationToolStripMenuItem.Enabled;
            showLicenseToolStripMenuItem1.Enabled = LocalApplication.IsLicenseIssued();
            deleteApplicationToolStripMenuItem.Enabled = !LocalApplication.IsLicenseIssued();
            showPersonLicenseHistoryToolStripMenuItem.Enabled = LocalApplication.HasAnyActiveLicense();

            scheduleTestsToolStripMenuItem.Enabled = (PassedTestsCount < 3 &&
                LocalApplication.ApplicationStatus == (int)enApplicationStatus.New);
            if (scheduleTestsToolStripMenuItem.Enabled)
            {
                visionTestToolStripMenuItem.Enabled = (!HasPassedVisionTest);
                writtenTestToolStripMenuItem.Enabled = (HasPassedVisionTest && !HasPassedWrittenTest);
                streetTestToolStripMenuItem.Enabled = (HasPassedVisionTest && HasPassedWrittenTest && !HasPassedStreetTest);
            }


        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm = new frmListTestAppointments(LocalApplicationID, clsTestType.enTestType.Vision);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm = new frmListTestAppointments(LocalApplicationID, clsTestType.enTestType.Written);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm = new frmListTestAppointments(LocalApplicationID, enTestType.Street);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }



        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }
            if (!clsLocalDrivingLicenseApplication.HasPassedAllTestTypes(LocalApplicationID))
            {
                MessageBox.Show("Error:Driving License Applicant Hasn't Passed All Test Types !", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmIssueDrivingLicenesForFirstTime frm = new frmIssueDrivingLicenesForFirstTime(LocalApplicationID);
            frm.ShowDialogIfAuthorized(GetByAccessType("AddEdit").Permissions, frm);
            RefreshForm();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.
                GetLocalApplicationByID(LocalApplicationID);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(LocalApplication.ApplicantPersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            RefreshForm();
        }

        private void showLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            int? LicenseID = clsLocalDrivingLicenseApplication.
                GetLocalApplicationByID(LocalApplicationID).GetActiveLicenseID();

            if (LicenseID == null)
            {
                MessageBox.Show($"Error:License is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)LicenseID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            //NO refresh need as the License Form does not allow modify
        }

        private void btnHighRiskApplicants_Click(object sender, EventArgs e)
        {
            frmListHighRiskApplicants frm = new frmListHighRiskApplicants();
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
        }

        private void btnRefreshHighRiskApplicants_Click(object sender, EventArgs e)
        {
            int TotalCount = clsUser.RefreshHighRiskApplicants();
            if (TotalCount > 0)
                MessageBox.Show($"Done successfully. Total Count {TotalCount} Applicants.", "Confirm",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No new Applicants are high risk!", "No Update",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
 
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //new,2 can
            string FilterColumn = "Status";
            string FilterValue=cbStatus.Text;
            if (FilterValue == "All")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                RefreshTotalCount();
                return;
            }
            _dtLocalDrivingLicenseApplications.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}'", FilterColumn, FilterValue);
            RefreshTotalCount();
        }
    }
}
