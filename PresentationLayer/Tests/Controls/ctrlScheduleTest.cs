using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        clsTestAppointment _TestAppointment = new clsTestAppointment();
        int? _TestAppointmentID = null;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        clsTestType.enTestType? _TestTypeID = clsTestType.enTestType.Vision;
        public Button SaveButton
        {
            get => btnSave;
            set => btnSave = value;
        }
        public clsTestType.enTestType? TestTypeID
        {
            get => _TestTypeID;
            set {
                _TestTypeID = value;
                switch(_TestTypeID)
                {
                    case clsTestType.enTestType.Vision:
                        {
                            lblTestTypeTitle.Text = "Vision Test";
                            pbTestType.Image = Resources.Vision_512;
                            break;
                        }
                    case clsTestType.enTestType.Written:
                        {
                            lblTestTypeTitle.Text = "Written Test";
                            pbTestType.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.Street:
                        {
                            lblTestTypeTitle.Text = "Street Test";
                            pbTestType.Image = Resources.driving_test_512;
                            break;
                        }



                }
            }

        }
        enum enMode { AddNew,Update}
        enMode _Mode= enMode.AddNew;
        enum enCreationMode
        {FirstTime,RetakeTest}
         
        enCreationMode CreationMode = enCreationMode.FirstTime;

        public ctrlScheduleTest()=> InitializeComponent();

    
        public void LoadTestAppointmentFullData(int LocalDrivingLicenseApplicationID,int? TestAppointmentID=null)
        {
            ///All these steps applied on All Modes (Add,Update) , (First,Retake)
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalDrivingLicenseApplicationID);
            _TestAppointmentID= TestAppointmentID;
            if (_LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show($"Error: Local Driving License Application with ID {LocalDrivingLicenseApplicationID} " +
                    "was not found !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            _Mode = TestAppointmentID == null ? enMode.AddNew : enMode.Update;
            //Retake App is extra application linked with the LocalApp
            if (_LocalDrivingLicenseApplication.HasAttentedTestType((clsTestType.enTestType)this.TestTypeID))
                CreationMode = enCreationMode.RetakeTest;
            else
                CreationMode = enCreationMode.FirstTime;

            if(CreationMode==enCreationMode.FirstTime)
                _ResetRetakeGB();
            else
                //In AddNew Mode , CreationMode may be Retake but the Retake app is still not created
                //Retake App will be created when Click Save
                _LoadAddNewRetakeGBData();

            _LoadLocalAppData();

            if (_Mode==enMode.AddNew)
                _LoadAddNewData();//Data is 1.Fees 2.Date
            else
            {
                ///Only Update Mode
                //Data is 1.Fees 2.Date 3.RetakeAppData
                if (!LoadUpdateModeData())
                    return;
            }

            //TotalFees In AddNew or Update Mode
            if (!(decimal.TryParse(lblFees.Text, out decimal TestFees) && decimal.TryParse(lblRetakeAppFees.Text, out decimal RetakeFees)))
            {
                MessageBox.Show("Error:An unexpected error happened !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing lblFees or lblRetakeAppFees to decimal ."));
                return;
            }
            lblTotalFees.Text = (TestFees + RetakeFees).ToString();
            lblUserMessage.Visible = false;
            dtpScheduleDate.MaxDate = clsTestAppointment.TestMaxDate;
            _HandleChecksBeforeCompletingLoad();
        }
        void _HandleChecksBeforeCompletingLoad()
        {
            if (!HandleIfPersonHaveActiveAppointmentInAddNewMode())
                return;
            if (!HandleIfTestAppointmentIsLockedInUpdateMode())
                return;
            //Check here again for safety
            if (!HandleIfPersonPassThePreviousTestType())
                return;
        }
        void _ResetRetakeGB()
        {
            lblRetakeAppFees.Text = "0";
            lblRetakeTestAppID.Text = "N/A";
        }
        void _LoadAddNewRetakeGBData()
        {
            lblRetakeAppFees.Text = clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.RetakeTest).ToString();
            lblTestTypeTitle.Text = "Schedule Retake Test";
            lblRetakeTestAppID.Text = "[????]";
        }
        void _LoadUpdateRetakeGBData()
        {
            gbRetakeTestInfo.Enabled = true;
            lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();
            lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
        }
        void _LoadLocalAppData()
        {
            lblTestTypeTitle.Text = (CreationMode == enCreationMode.RetakeTest ? "Schedule Retake Test" : "Schedule Test First Time");
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblLocalAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = _LocalDrivingLicenseApplication.Person.FullName;
            lblTrials.Text = _LocalDrivingLicenseApplication.CountAllTestTrials((clsTestType.enTestType)_TestTypeID).ToString();

        }
        void _LoadAddNewData()
        {
            dtpScheduleDate.MinDate = DateTime.Now;
            lblFees.Text = clsTestType.GetByID((int)_TestTypeID.Value).TestTypeFees.ToString();
        }
        private bool LoadUpdateModeData()
        {
            _TestAppointment = clsTestAppointment.GetByID(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show($"Error:Test Appointment is not found !", "Error"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //1.If AppointmentDate >= Now (Now or After) , MinDate=Now
            //2.If AppointmentDate < Now (Before), MinDate=AppointmentDate
            ///1.I am sure that Date will not be Before Now (Validation)
            ///2.I am now sure that Date will be Modefied so i did not change MinDate but I am sure that it can not be before AppointmentDate
            dtpScheduleDate.Value = _TestAppointment.AppointmentDate;
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpScheduleDate.MinDate = DateTime.Now;
            else
                dtpScheduleDate.MinDate = _TestAppointment.AppointmentDate;

            lblFees.Text = _TestAppointment.PaidFees.ToString();
            if (_TestAppointment.RetakeTestApplicationID ==null)
                _ResetRetakeGB();
            else
                //Data is not the same as RetakeDataNewMode .. Fees may be modefied in DB and RetakeID is found 
                //but in AddNew RetakeID is created after Save
                _LoadUpdateRetakeGBData();
            return true;
        }

        private bool HandleIfPersonHaveActiveAppointmentInAddNewMode()
        {
            //If User clicked the (add new appointment) button And there was an active test appointment
            if (_Mode == enMode.AddNew && _LocalDrivingLicenseApplication.HasActiveTestAppointment((clsTestType.enTestType)_TestTypeID))
            {
                DisableFormLoading("You Can not Schedule a new test appointment\n" +
                "as you already have an active one");
                return false;
            }
                return true;
        }
        private bool HandleIfTestAppointmentIsLockedInUpdateMode()
        {
            //it will only work with update mode (testAppointment!=null) else will return true
            if (_Mode==enMode.Update&&_TestAppointment.IsLocked)
            {
                DisableFormLoading("You Can not Update This  test appointment " +
                    "\nas It is Locked");
                return false;
            }
            return true;
        }
        private bool HandleIfPersonPassThePreviousTestType()
        {
            switch(TestTypeID)
            {
                case clsTestType.enTestType.Vision:
                    return true;

                case clsTestType.enTestType.Written:
                    {
                        if(_LocalDrivingLicenseApplication.HasPassedTestType(clsTestType.enTestType.Vision))
                            return true;
                        else
                        {
                            DisableFormLoading("You had not passed the vision Test yet !");
                            return false;
                        }
                    }
                case clsTestType.enTestType.Street:
                    {
                        if (_LocalDrivingLicenseApplication.HasPassedTestType(clsTestType.enTestType.Written))
                            return true;
                        else
                        {
                            DisableFormLoading("You had not passed the written Test yet !");
                            return false;
                        }
                    }
                default:
                    return false;
            }
            
        }
        void DisableFormLoading(string Message)
        {
            lblUserMessage.Visible = true;
            lblUserMessage.Text = Message;
            dtpScheduleDate.Enabled = false;
            btnSave.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(lblFees.Text, out decimal TestFees))
            {
                MessageBox.Show("Error:Some thing wrong happened !", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException(
                    "Error with Test Fees Parsing."));
                return;
            }
            if (!HandleSavingRetakeTestApplication())
                return;


            try
            {
                //RollBack if Any Save Failed
                using (TransactionScope scope = new TransactionScope())
                {
                    _TestAppointment.LoggedUserID=clsGlobal.CurrentUser.UserID;
                    _TestAppointment.PaidFees = TestFees;
                    _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                    _TestAppointment.AppointmentDate = dtpScheduleDate.Value;
                    _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    _TestAppointment.IsLocked = false;
                    _TestAppointment.TestTypeID = _TestTypeID;
                    if ((_TestAppointment.CreatedByUserID == null || _TestAppointment.LocalDrivingLicenseApplicationID == null||_TestTypeID==null
                        ||(_TestAppointment.TestAppointmentID== null)&&_Mode==enMode.Update))
                    {
                        MessageBox.Show("Error:An unexpected error occurred while saving because if Missed Data. " +
                          "Please try again later.", "Save failed", MessageBoxButtons.OK
                         , MessageBoxIcon.Error);
                        return;
                    }
                    if (!_TestAppointment.Save())
                        throw new Exception($"Save Test Appointment with LocalDrivingLicenseApplicationID {_TestAppointment.LocalDrivingLicenseApplicationID} Failed.");
                    //All Succeeded
                    _Mode = enMode.Update;
                    _TestAppointmentID = _TestAppointment.TestAppointmentID;
                    MessageBox.Show("Test Appointment Was Saved Successfully", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                 "Please try again later.", "Save failed", MessageBoxButtons.OK
                , MessageBoxIcon.Error);
                return;
            }
        }

        
        private bool HandleSavingRetakeTestApplication()
        {
            clsApplication NewRetakeApplication = new clsApplication();
            //As if the mood was update .. you must not add a new application (it is already exists)
            if (_Mode == enMode.AddNew)
            {
                if (CreationMode == enCreationMode.RetakeTest)
                {
                    NewRetakeApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                    NewRetakeApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                    NewRetakeApplication.ApplicationDate = DateTime.Now;
                    NewRetakeApplication.LastStatusDate = DateTime.Now;
                    NewRetakeApplication.ApplicationTypeID = clsApplication.enApplicationType.RetakeTest;
                    NewRetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    NewRetakeApplication.PaidFees = clsApplicationType.GetByID((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;

                    if (!NewRetakeApplication.Save())
                    {
                        MessageBox.Show("Error:An unexpected error occurred while saving. " +
                            "Please try again later.", "Save failed", MessageBoxButtons.OK
                             , MessageBoxIcon.Error);
                        return false;
                    }
                    _TestAppointment.RetakeTestApplicationID = NewRetakeApplication.ApplicationID;
                }
                else//AddNew_FirstTime
                    _TestAppointment.RetakeTestApplicationID = null;

            }
            //If UpdateMode , RetakeTestApplicationID will be the same state(null/same RetakeID)
            return true;
        }
    }
}
