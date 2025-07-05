using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsTestType;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Tests
{
    public partial class frmListTestAppointments : clsBaseForm
    {
        private int? _LocalDrivingLicenseApplicationID = null;
        private DataTable _dtTestAppointmentsList = new DataTable();
        private enTestType _TestTypeID = enTestType.Vision;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, enTestType TestTypeID)
        {
            InitializeComponent();
            SetTheme(this);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnAddNewAppointment;
            LoadTestTypeImage();
            SetTitle("List Test Appointments");

            ctrlDrivingLicenesApplicationInfo1.LoadLocalApplication(_LocalDrivingLicenseApplicationID.Value);

            _dtTestAppointmentsList =
                clsTestAppointment.GetAllTestAppointmentsListPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);

            dgvTestAppointments.DataSource = _dtTestAppointmentsList;
            RefreshTotalCount();
        }

        private void LoadTestTypeImage()
        {
            switch (_TestTypeID)
            {
                case enTestType.Vision:
                    pbTestTypeImage.Image = Resources.Vision_512;
                    break;
                case enTestType.Written:
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    break;
                case enTestType.Street:
                    pbTestTypeImage.Image = Resources.driving_test_512;
                    break;
            }
        }

        private void RefreshTotalCount()
            => lblRecords.Text = dgvTestAppointments.Rows.Count.ToString();

        private void RefreshForm()
            => frmListTestAppointments_Load(null, null);

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            var localApp = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(_LocalDrivingLicenseApplicationID.Value);

            if (localApp.IsThereActiveScheduledTestAppointment(_TestTypeID))
            {
                MessageBox.Show("There is already an active scheduled test appointment!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lastTest = localApp.GetLastTestAppointmentInfoPerTestType(_TestTypeID);

            // First Time
            if (lastTest == null)
            {
                var frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID);
                frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
                RefreshForm();
                return;
            }

            // Already Passed
            if (lastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test type!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retake
            var frmRetake = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID);
            frmRetake.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frmRetake);
            RefreshForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestAppointments.CurrentRow == null)
            {
                MessageBox.Show("Application not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog.Log(new Exception("Loading Application failed from DGV"));
                return;
            }

            if (!(dgvTestAppointments.CurrentRow.Cells[0].Value is int testAppointmentID))
            {
                MessageBox.Show("Unexpected error occurred!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog.Log(new FormatException("Parsing TestAppointmentID failed."));
                return;
            }

            var testApp = clsTestAppointment.GetByID(testAppointmentID);
            if (testApp == null)
            {
                MessageBox.Show("Test Appointment not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (testApp.IsLocked)
            {
                MessageBox.Show("This Test Appointment is locked!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID, testAppointmentID);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(dgvTestAppointments.CurrentRow.Cells[0].Value is int testAppointmentID))
            {
                MessageBox.Show("Unexpected error occurred!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog.Log(new FormatException("Parsing TestAppointmentID failed."));
                return;
            }

            var testApp = clsTestAppointment.GetByID(testAppointmentID);

            if (testApp == null)
            {
                MessageBox.Show("Test Appointment not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (testApp.IsLocked)
            {
                MessageBox.Show("This Test Appointment is locked!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? testID = testApp.GetTestID();
            var frm = new frmTakeScheduledTest(_TestTypeID, testAppointmentID, testID??default);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void dgvTestAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTestAppointments.Columns.Count == 8)
            {
                dgvTestAppointments.Columns[0].HeaderText = "Test Appointment ID";
                dgvTestAppointments.Columns[0].Width = 100;

                dgvTestAppointments.Columns[1].HeaderText = "Local Application ID";
                dgvTestAppointments.Columns[1].Width = 150;

                dgvTestAppointments.Columns[2].HeaderText = "Test Type Title";
                dgvTestAppointments.Columns[2].Width = 110;

                dgvTestAppointments.Columns[3].HeaderText = "Class Name";
                dgvTestAppointments.Columns[3].Width = 160;

                dgvTestAppointments.Columns[4].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns[4].Width = 150;

                dgvTestAppointments.Columns[5].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns[5].Width = 60;

                dgvTestAppointments.Columns[6].HeaderText = "Full Name";
                dgvTestAppointments.Columns[6].Width = 180;

                dgvTestAppointments.Columns[7].HeaderText = "Is Locked";
                dgvTestAppointments.Columns[7].Width = 100;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTestAppointments.CurrentRow == null || dgvTestAppointments.Rows.Count == 0)
                e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
    }
}
