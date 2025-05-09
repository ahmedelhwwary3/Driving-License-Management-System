using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Tests
{
    public partial class frmTakeScheduledTest : Form
    {
        private clsTestType.enTestType? _TestTypeID = clsTestType.enTestType.Vision;
        private int? _TestAppointmentID = null;
        private int? _TestID = null;
        private clsTest _Test=new clsTest();
        enum enMode
        { AddNew,Update}
        enMode _Mode = enMode.AddNew;
        public frmTakeScheduledTest(clsTestType.enTestType TestTypeID,int TestAppointmentID, int? TestID=null)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
            _TestID = TestID;
            _Mode=_TestID==null ? enMode.AddNew : enMode.Update;
            this.Load += (sender, e) => 
            {
                if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.TakeScheduledTest))
                    return;
                _LoadWithAllModes();
                if(_Mode==enMode.Update)
                    _LoadInUpdateMode();
            };
        }

        private void btnClose_Click(object sender, EventArgs e) 
            => this.Close();
        //Load is implemented in ctor
        void _LoadInUpdateMode()
        {
            _Test = clsTest.GetByID(_TestID.Value);
            if (_Test == null)
            {
                MessageBox.Show("Error:An unexpected error occurred while Loading Test ."
                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                ctrlScheduledTest1.Enabled = false;
                return;
            }
            if(_Test.TestResult!=true)
            {
                MessageBox.Show("Error:Test Result is not Passed !"
                  , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                ctrlScheduledTest1.Enabled = false;
                return;
            }
            rbPass.Checked = _Test.TestResult ? true : false;
            txtNotes.Text = _Test.Notes;
            lblUserMessage.Visible = true;
            lblUserMessage.Text = "Note:You can only edit Notes.";
            rbFail.Enabled = false;
            rbPass.Enabled = false;
        }
        void _LoadWithAllModes()
        {
            if (clsTestAppointment.GetByID((int)_TestAppointmentID).IsLocked)
            {
                MessageBox.Show("Error:This Test Appointment is locked", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
            lblUserMessage.Visible = false;
            _LoadTestAppointmentCTRL();
        }
        void _LoadTestAppointmentCTRL()
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadScheduledTest((int)_TestAppointmentID,(clsTestType.enTestType)_TestTypeID, _TestID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)//If User wants to update Test Result (Important to ask)
            {
                if (MessageBox.Show("Are you sure you want to Save Test?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                != DialogResult.Yes)
                    return;
            }
            try
            {
                clsTestAppointment Appointment = clsTestAppointment.GetByID(_TestAppointmentID);
                //If Edit Mode Notes only can be changed And TestID !=null

                //if (DateTime.Now!= Appointment.AppointmentDate)
                //{
                //    MessageBox.Show($"Error:Appoitment date is still on {Appointment.AppointmentDate}" +
                //        $" !", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                _Test.LoggedUserID=clsGlobal.CurrentUser.UserID;
                _Test.TestResult = rbPass.Checked ? true : false;
                _Test.Notes = txtNotes.Text.Trim();
                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Test.TestAppointmentID = _TestAppointmentID;
                if (_Test.CreatedByUserID == null || (_Test==null&&_Mode==enMode.Update))
                {
                    MessageBox.Show("Error:An unexpected error occurred while saving. " +
                     "Please try again later.", "Save failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!_Test.Save())
                    throw new Exception($"Test Failed with TestAppointmentID");

                //to prevent from editing Result
                ctrlScheduledTest1.TestID =_Test.TestID.Value;
                _EnableModifingTestResult(false);
                _Mode = enMode.Update;
                MessageBox.Show("Test was saved successfully", "Save succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                   "Please try again later.", "Save failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
               clsGlobal.LogError(ex);
            }
        }

        void _EnableModifingTestResult(bool Enable)
        {
            rbFail.Enabled = Enable;
            rbPass.Enabled = Enable;
        }
    }
}
