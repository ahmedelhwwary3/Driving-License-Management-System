using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int? _LocalDrivingLicenseApplicationID = null;
        private DataTable _dtTestAppointmentsList = new DataTable();
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.Vision;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void _RefreshTotalCount() =>
            lblRecords.Text = dgvTestAppointments.Rows.Count.ToString();
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImage();
            ctrlDrivingLicenesApplicationInfo1.LoadLocalApplication(_LocalDrivingLicenseApplicationID.Value);
            _dtTestAppointmentsList = clsTestAppointment.GetAllTestAppointmentsListPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvTestAppointments.DataSource = _dtTestAppointmentsList;
            _RefreshTotalCount();
        }
        private void _LoadTestTypeImage()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.Vision:
                    {
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }
                case clsTestType.enTestType.Written:
                    {
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.Street:
                    {
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
                default:
                    break;
            }
        }
        void _RefreshForm()
            => frmListTestAppointments_Load(null, null);
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ScheduleTest))
                return;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(_LocalDrivingLicenseApplicationID);
            if (LocalDrivingLicenseApplication.IsThereActiveScheduledTestAppointment(_TestTypeID))
            {
                //Handeled also in CTRL for safety
                MessageBox.Show("Error:There is already an active scheduled " +
                    "Test appointment !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsTest LastTest = LocalDrivingLicenseApplication.GetLastTestAppointmentInfoPerTestType(_TestTypeID);
            //If The Person did not have any Test appointment For this type before
            ///Modes:AddNew & First Time 
            if (LastTest == null)
            {
                //open form in AddNew Mode
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID);
                frm.ShowDialog();
                _RefreshForm();
                return;
            }
            //Passed
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("Error:This Person already Passed this test type before !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Failed 
            ///Modes:AddNew & Retake
            frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID);
            frm1.ShowDialog();
            _RefreshForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ScheduleTest))
                return;
            if (dgvTestAppointments.CurrentRow == null)
            {
                MessageBox.Show("Local Driving License Application is not existed !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Local Driving License Application through DGV"));
                return;
            }
            if (!(dgvTestAppointments.CurrentRow.Cells[0].Value is int TestAppointmentID))
            {

                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing TestAppointmentID Value To int ."));
                return;
            }
            clsTestAppointment TestAppointment = clsTestAppointment.GetByID(TestAppointmentID);
            if (TestAppointment == null)
            {
                MessageBox.Show("Error:This Test Appointment is not existed !\nYou can not update it"
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TestAppointment.IsLocked)
            {
                MessageBox.Show("Error:This Test Appointment is locked !\nYou can not update it"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID.Value, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.TakeScheduledTest))
                return;
            if (!(dgvTestAppointments.CurrentRow.Cells[0].Value is int TestAppointmentID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing TestAppointmentID Value To int ."));
                return;
            }

            clsTestAppointment TestAppointment = clsTestAppointment.GetByID(TestAppointmentID);
            //If No Test is Attached to TestAppointment yet (Take NewTest ):- 
            //1.TestAppointemnt.TestID = null , 2.frmTakeScheduledTest will open in New Mode
            if (TestAppointment.IsLocked)
            {
                MessageBox.Show("Error:This Test Appointment is locked !\nYou can not update it"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Local Driving License Application through DGV"));
                return;
            }
            int? TestID = TestAppointment.GetTestID();
            if (TestAppointment == null)
            {
                MessageBox.Show("Error:This Test Appointment is not existed !\nYou can not update it"
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmTakeScheduledTest frm = new frmTakeScheduledTest(_TestTypeID, TestAppointmentID, TestID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void dgvTestAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvTestAppointments.Columns.Count == 8)
            {
                dgvTestAppointments.Columns[0].HeaderText = "Test Appointment ID";
                dgvTestAppointments.Columns[0].Width = 100;

                dgvTestAppointments.Columns[1].HeaderText = "Local Application ID";
                dgvTestAppointments.Columns[0].Width = 150;

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
    }
}
