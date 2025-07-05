using BusinessLayer.Core;
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
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsTestType;
using static BusinessLayer.Core.clsApplication;
using static BusinessLayer.Core.clsUsersPermissions;
using static System.Formats.Asn1.AsnWriter;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduleTest : clsBaseCtrl
    {
        clsTestAppointment _TestAppointment = new clsTestAppointment();
        int? _TestAppointmentID = null;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        public Button SaveButton
        {
            get => btnSave;
            set => btnSave = value;
        }
        enTestType _TestTypeID = enTestType.Vision;
        public enTestType TestTypeID
        {
            get => _TestTypeID;
            set {
                _TestTypeID = value;
                switch(TestTypeID)
                {
                    
                    case enTestType.Vision:
                    default:
                        {
                            lblTestTypeTitle.Text = "Vision Test";
                            pbTestType.Image = Resources.Vision_512;
                            break;
                        }
                    case enTestType.Written:
                        {
                            lblTestTypeTitle.Text = "Written Test";
                            pbTestType.Image = Resources.Written_Test_512;
                            break;
                        }
                    case enTestType.Street:
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
         
        enCreationMode _CreationMode = enCreationMode.FirstTime;
    
        public ctrlScheduleTest()
        {
            InitializeComponent();
            SetTheme(this);
        }

    
        public void LoadTestAppointmentFullData(int LocalDrivingLicenseApplicationID,int? TestAppointmentID=null)
        {
            if (!CheckUserAccess(GetByAccessType("AddEdit").Permissions.Value))
                return;
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

            _Mode = TestAppointmentID.HasValue ? enMode.Update : enMode.AddNew;
            //Retake App is extra application linked with the LocalApp
            if (_LocalDrivingLicenseApplication.HasAttentedTestType((enTestType)_TestTypeID))
                _CreationMode = enCreationMode.RetakeTest;
            else
                _CreationMode = enCreationMode.FirstTime;

            if(_CreationMode==enCreationMode.FirstTime)
                ResetFirstTimeData();
            else
                LoadAddNewRetakeGBData();//In AddNew Mode , CreationMode may be Retake but the Retake app is still not created
                                         //Retake App will be created when Click Save

            LoadLocalAppData();

            if (_Mode==enMode.AddNew)
                LoadAddNewData();//Data is 1.Fees 2.Date
            else
            {
                ///Only Update Mode
                //Data is 1.Fees 2.Date 3.RetakeAppData
                if (!LoadUpdateModeData())
                    return;
            }

            //TotalFees In AddNew or Update Mode
            if (!(decimal.TryParse(lblFees.Text, out decimal TestFees) && 
                decimal.TryParse(lblRetakeAppFees.Text, out decimal RetakeFees)))
            {
                MessageBox.Show("Error:An unexpected error happened !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                   WindownsEventLog?.Log(new FormatException("Error while parsing lblFees or lblRetakeAppFees to decimal ."));
                return;
            }
            lblTotalFees.Text = (TestFees + RetakeFees).ToString();
            lblUserMessage.Visible = false;
            dtpScheduleDate.MaxDate = clsTestAppointment.TestMaxDate;
            HandleChecksBeforeCompletingLoad();
        }
        void HandleChecksBeforeCompletingLoad()
        {
            if (!HandleIfPersonHaveActiveAppointmentInAddNewMode())
                return;
            if (!HandleIfTestAppointmentIsLockedInUpdateMode())
                return;
            //Check here again for safety
            if (!HandleIfPersonPassThePreviousTestType())
                return;
        }
        void ResetFirstTimeData()
        {
            lblRetakeAppFees.Text = "0";
            lblRetakeTestAppID.Text = "N/A";
        }
        void LoadAddNewRetakeGBData()
        {
            lblRetakeAppFees.Text = clsApplicationType.GetApplicationTypeFees((int)enApplicationType.RetakeTest).ToString();
            lblTestTypeTitle.Text = "Schedule Retake Test";
            lblRetakeTestAppID.Text = "[????]";
        }
        void LoadUpdateRetakeGBData()
        {
            gbRetakeTestInfo.Enabled = true;
            lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();
            lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
        }
        void LoadLocalAppData()
        {
            lblTestTypeTitle.Text = (_CreationMode == enCreationMode.RetakeTest ? "Schedule Retake Test" : "Schedule Test First Time");
            lblClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblLocalAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = _LocalDrivingLicenseApplication.Person.FullName;
            lblTrials.Text = _LocalDrivingLicenseApplication.CountAllTestTrials((enTestType)TestTypeID).ToString();

        }
        void LoadAddNewData()
        {
            dtpScheduleDate.MinDate = DateTime.Now;
            lblFees.Text = clsTestType.GetByID((int)TestTypeID).TestTypeFees.ToString();
        }
        private bool LoadUpdateModeData()
        {
            _TestAppointment = clsTestAppointment.GetByID(_TestAppointmentID.Value);
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
            if (!_TestAppointment.RetakeTestApplicationID.HasValue)
                ResetFirstTimeData();
            else
                //Data is not the same as RetakeDataNewMode .. Fees may be modefied in DB and RetakeID is found 
                //but in AddNew RetakeID is created after Save
                LoadUpdateRetakeGBData();
            return true;
        }

        private bool HandleIfPersonHaveActiveAppointmentInAddNewMode()
        {
            //If User clicked the (add new appointment) button And there was an active test appointment
            if (_Mode == enMode.AddNew && _LocalDrivingLicenseApplication
                .HasActiveTestAppointment((clsTestType.enTestType)TestTypeID))
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
                case enTestType.Vision:
                    return true;

                case enTestType.Written:
                    {
                        if(_LocalDrivingLicenseApplication.HasPassedTestType(enTestType.Vision))
                            return true;
                        else
                        {
                            DisableFormLoading("You had not passed the vision Test yet !");
                            return false;
                        }
                    }
                case enTestType.Street:
                    {
                        if (_LocalDrivingLicenseApplication.HasPassedTestType(enTestType.Written))
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
        int? GetNewRetakeApplicationID()
        {
            clsApplication app = new clsApplication();
            app.ApplicationStatus = (int)enApplicationStatus.Completed;
            app.LastStatusDate= DateTime.Now;
            app.ApplicationDate= DateTime.Now;
            app.ApplicantPersonID = _TestAppointment.LocalDrivingLicenseApplication.ApplicantPersonID;
            app.ApplicationTypeID =(int) enApplicationType.RetakeTest;
            app.CreatedByUserID = CurrentUser.UserID.Value;
            app.PaidFees = clsApplicationType.GetApplicationTypeFees((int)enApplicationType.RetakeTest);
            app.LoggedUserID= CurrentUser.UserID.Value;
            return app.Save() ? app.ApplicationID:null;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(lblFees.Text, out decimal TestFees))
            {
                MessageBox.Show("Error:Some thing wrong happened !", "Error"
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                   WindownsEventLog?.Log(new FormatException(
                    "Error with Test Fees Parsing."));
                return;
            }
            if (!HandleSavingRetakeTestApplication())
                return;
            try
            {
                _TestAppointment.LoggedUserID = CurrentUser.UserID.Value;
                _TestAppointment.PaidFees = TestFees;
                _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.Value;
                _TestAppointment.AppointmentDate = dtpScheduleDate.Value;
                _TestAppointment.CreatedByUserID = CurrentUser.UserID.Value;
                _TestAppointment.IsLocked = false;
                _TestAppointment.TestTypeID = (int)TestTypeID;

                if (((_TestAppointment.TestAppointmentID == null) && _Mode == enMode.Update))
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
                if(_CreationMode==enCreationMode.RetakeTest)
                    lblRetakeTestAppID.Text=_TestAppointment?.RetakeTestApplicationID?.ToString();
                _TestAppointmentID = _TestAppointment.TestAppointmentID;
                MessageBox.Show("Test Appointment Was Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
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
                if (_CreationMode == enCreationMode.RetakeTest)
                {
                    NewRetakeApplication.ApplicationStatus = (int)enApplicationStatus.Completed;
                    NewRetakeApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                    NewRetakeApplication.ApplicationDate = DateTime.Now;
                    NewRetakeApplication.LastStatusDate = DateTime.Now;
                    NewRetakeApplication.ApplicationTypeID = (int)enApplicationType.RetakeTest;
                    NewRetakeApplication.CreatedByUserID = CurrentUser.UserID.Value;
                    NewRetakeApplication.PaidFees = clsApplicationType.GetApplicationTypeFees((int)enApplicationType.RetakeTest);
                    NewRetakeApplication.LoggedUserID= CurrentUser.UserID.Value;
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
