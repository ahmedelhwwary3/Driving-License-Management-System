using BusinessLayer.Core;
using PresentationLayer.Global;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsTestType;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Tests
{
    public partial class frmTakeScheduledTest : clsBaseForm
    {
        private enTestType _TestTypeID = enTestType.Vision;
        private int? _TestAppointmentID = null;
        private int _TestID = default;
        private clsTest _Test = new clsTest();

        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        public frmTakeScheduledTest(enTestType TestTypeID, int TestAppointmentID, int TestID = default)
        {
            InitializeComponent();
            SetTheme(this);

            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
            _TestID =TestID;
            _Mode = _TestID == default ? enMode.AddNew : enMode.Update;

            this.Load += (sender, e) =>
            {
                if (!CheckUserAccess(GetPermissions("AddEdit")))
                    return;

                LoadWithAllModes();

                if (_Mode == enMode.Update)
                    LoadInUpdateMode();
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void LoadInUpdateMode()
        {
            _Test = clsTest.GetByID(_TestID);

            if (_Test == null)
            {
                MessageBox.Show("Error: An unexpected error occurred while loading the test.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                ctrlScheduledTest1.Enabled = false;
                return;
            }

            if (_Test.TestResult != true)
            {
                MessageBox.Show("Error: Test result is not marked as passed.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                ctrlScheduledTest1.Enabled = false;
                return;
            }

            rbPass.Checked = true;
            txtNotes.Text = _Test.Notes;
            lblUserMessage.Visible = true;
            lblUserMessage.Text = "Note: You can only edit notes.";
            EnableModifingTestResult(false);
        }

        private void LoadWithAllModes()
        {
            var appointment = clsTestAppointment.GetByID(_TestAppointmentID.Value);

            if (appointment.IsLocked)
            {
                MessageBox.Show("Error: This test appointment is locked.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            SetTitle("Take Scheduled Test");
            btnSave.Enabled = true;
            lblUserMessage.Visible = false;
            LoadTestAppointmentCTRL();
        }

        private void LoadTestAppointmentCTRL()
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadScheduledTest(_TestAppointmentID.Value,_TestTypeID, _TestID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (MessageBox.Show("Are you sure you want to save the test?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
            }

            try
            {
                var appointment = clsTestAppointment.GetByID(_TestAppointmentID.Value);

                _Test.LoggedUserID = CurrentUser.UserID.Value;
                _Test.TestResult = rbPass.Checked;
                _Test.Notes = txtNotes?.Text?.Trim();
                _Test.CreatedByUserID = CurrentUser.UserID.Value;
                _Test.TestAppointmentID = _TestAppointmentID.Value;

                if (_Test == null && _Mode == enMode.Update)
                {
                    MessageBox.Show("Error: An unexpected error occurred while saving.",
                        "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (!_Test.Save())
                    throw new Exception($"Saving test failed (TestAppointmentID: {_TestAppointmentID})");

                ctrlScheduledTest1.TestID = _Test.TestID.Value;
                EnableModifingTestResult(false);
                _Mode = enMode.Update;

                MessageBox.Show("Test was saved successfully.",
                    "Save succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: An unexpected error occurred while saving.",
                    "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(ex);
            }
        }

        private void EnableModifingTestResult(bool enable)
        {
            rbFail.Enabled = enable;
            rbPass.Enabled = enable;
        }
    }
}
