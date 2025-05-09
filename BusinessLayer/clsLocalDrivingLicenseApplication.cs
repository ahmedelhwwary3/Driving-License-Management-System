
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsLicenseClass;
using static BusinessLayer.clsTestType;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        protected new enum enMode { AddNew, Update }
        protected new enMode Mode;
        //public new int ApplicationID {  get; set; }
        public int? LocalDrivingLicenseApplicationID { get; set; }
        public clsLicenseClass.enLicenseClassID? LicenseClassID { get; set; }
        public clsLicenseClass LicenseClass { get; set; }
        public clsLocalDrivingLicenseApplication()
        {
            this.LoggedUserID= null;
            this.LocalDrivingLicenseApplicationID = null;
            this.LicenseClassID = clsLicenseClass.enLicenseClassID.Class3_ordinary_driving_license;
            //All Fileds will be initialized (Base)
            //Taking value from Base
            this.ApplicationID = base.ApplicationID;

            Mode = enMode.AddNew;
        }
        protected clsLocalDrivingLicenseApplication(int? LocalDrivingLicenseApplicationID, clsLicenseClass.enLicenseClassID? LicenseClassID, int? ApplicationID, int? ApplicantPersonID, DateTime ApplicationDate, clsApplication.enApplicationStatus? ApplicationStatus, clsApplication.enApplicationType? ApplicationTypeID, int? CreatedByUserID, DateTime LastStatusDate, decimal PaidFees)
            :base (ApplicationID, ApplicantPersonID, ApplicationDate, (enApplicationType)ApplicationTypeID,(enApplicationStatus)ApplicationStatus , LastStatusDate,CreatedByUserID, PaidFees)
        {
            this.LoggedUserID = null;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClass = new Func<int?, clsLicenseClass>(clsLicenseClass.GetByID).GetByNullableID((int)LicenseClassID);

            Mode = enMode.Update;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            if (this.LicenseClassID.HasValue && this.ApplicationID.HasValue&&
                this.LoggedUserID.HasValue)
            {
                this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData
                    .AddLocalDrivingLicenseApplication(
                    (int)this.LicenseClassID.Value,
                    this.ApplicationID.Value,
                    this.LoggedUserID.Value
                );
            }
            return this.LocalDrivingLicenseApplicationID != null;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            if (this.LocalDrivingLicenseApplicationID.HasValue &&
                this.LicenseClassID.HasValue && this.ApplicationID.HasValue
                &&this.LoggedUserID.HasValue)
            {
                return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationByID(
                    this.LocalDrivingLicenseApplicationID.Value,
                    (int)this.LicenseClassID.Value,
                    this.ApplicationID.Value,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }



        public new bool Save()
        {
            base.Mode = (clsApplication.enMode)this.Mode;
            if (!base.Save())
                return false;
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }
                default:
                    break;
            }
            return false;
        }


        public static bool IsExistByID(int? LocalDrivingLicenseApplicationID)
        => LocalDrivingLicenseApplicationID.HasValue&&clsLocalDrivingLicenseApplicationData.IsExistByID(LocalDrivingLicenseApplicationID.Value);

        public static clsLocalDrivingLicenseApplication GetLocalApplicationByID(int? LocalDrivingLicenseApplicationID)
        {
            if (!LocalDrivingLicenseApplicationID.HasValue)
                return null;
            DataTable dt = clsLocalDrivingLicenseApplicationData.GetByID(LocalDrivingLicenseApplicationID.Value);
            if (dt.Rows.Count==0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLocalDrivingLicenseApplication(
                ApplicationID: row["ApplicationID"].ToNullableInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToNullableInt32(),
                ApplicationDate: row["ApplicationDate"].ToDate(),
                ApplicationStatus: (enApplicationStatus?)row["ApplicationStatus"].ToNullableInt32(),
                ApplicationTypeID: (enApplicationType?)row["ApplicationTypeID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                LastStatusDate: row["LastStatusDate"].ToDate(),
                PaidFees: row["PaidFees"].ToDecimal(),

                LocalDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToNullableInt32(),
                LicenseClassID: (enLicenseClassID?)row["LicenseClassID"].ToNullableInt32()
           );
            
        }
 
        public static clsLocalDrivingLicenseApplication GetLocalAplicationByApplicationID(int? ApplicationID)
        {
            if (!ApplicationID.HasValue)
                return null;
            DataTable dt = clsLocalDrivingLicenseApplicationData.GetByBaseApplicationID(ApplicationID.Value);

            if (dt.Rows.Count == 0)
                return null;
         
            DataRow row = dt.Rows[0];

            return new clsLocalDrivingLicenseApplication(
                ApplicationID: row["ApplicationID"].ToNullableInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToNullableInt32(),
                ApplicationDate: row["ApplicationDate"] .ToDate(),
                ApplicationStatus:(enApplicationStatus?) row["ApplicationStatus"] .ToNullableInt32(),
                ApplicationTypeID:(enApplicationType?)row["ApplicationTypeID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                LastStatusDate: row["LastStatusDate"] .ToDate(),
                PaidFees: row["PaidFees"].ToDecimal(),

                LocalDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToNullableInt32(),
                LicenseClassID: (enLicenseClassID?)row["LicenseClassID"].ToNullableInt32()
           );

        }


        public static DataTable GetAllLocalDrivingLicenseApplicationsList()
        => clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsList();
        public static bool DeleteByID(int? LocalDrivingLicenseApplicationID,int? LoggedUserID)
        => LocalDrivingLicenseApplicationID.HasValue&& LoggedUserID.HasValue&&
            clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID.Value, LoggedUserID.Value);

        public bool HasPassedTestType(clsTestType.enTestType? TestTypeID)
        =>TestTypeID.HasValue&& this.LocalDrivingLicenseApplicationID.HasValue&& clsLocalDrivingLicenseApplicationData.HasLocalDrivingLicenseApplicationPassedTestTypeTestType(this.LocalDrivingLicenseApplicationID.Value, (int)TestTypeID.Value);

        public int? GetActiveLicenseID()
         => this.LocalDrivingLicenseApplicationID.HasValue?clsLocalDrivingLicenseApplicationData.GetAnyActiveLicenseID(this.LocalDrivingLicenseApplicationID.Value):null;
        public static int? GetActiveLicenseID(int? LocalDrivingLicenseApplicationID)
      => LocalDrivingLicenseApplicationID.HasValue ? clsLocalDrivingLicenseApplicationData.GetActiveLocalLicenseID(LocalDrivingLicenseApplicationID.Value):null;
        public static bool IsLicenseIssued(int? LocalDrivingLicenseApplicationID)
       => (GetActiveLicenseID(LocalDrivingLicenseApplicationID) != null);
        public bool IsLicenseIssued()
        =>  this.LocalDrivingLicenseApplicationID.HasValue&& IsLicenseIssued(this.LocalDrivingLicenseApplicationID.Value);
        public int? GetPassedTests()
        => this.LocalDrivingLicenseApplicationID.HasValue ?clsLocalDrivingLicenseApplicationData.GetAllPassedTestsCount( this.LocalDrivingLicenseApplicationID.Value):null;
        public static int? GetPassedTests(int? LocalDrivingLicenseApplicationID)
        => LocalDrivingLicenseApplicationID.HasValue ?clsLocalDrivingLicenseApplicationData.GetAllPassedTestsCount(LocalDrivingLicenseApplicationID.Value):null;
        public int? CountAllTestTrials(clsTestType.enTestType? TestTypeID)
         => TestTypeID.HasValue&&this.LocalDrivingLicenseApplicationID.HasValue?clsLocalDrivingLicenseApplicationData.GetTotalTrialsPerTestType(this.LocalDrivingLicenseApplicationID.Value, (int)TestTypeID.Value):null;
        

        public bool HasActiveTestAppointment(clsTestType.enTestType? TestTypeID)
        => TestTypeID.HasValue && this.LocalDrivingLicenseApplicationID.HasValue&&clsLocalDrivingLicenseApplicationData.HasActiveScheduledTestAppointment(this.LocalDrivingLicenseApplicationID.Value, (int)TestTypeID.Value);


        public bool HasAttentedTestType(clsTestType.enTestType? TestTypeID)
       => TestTypeID.HasValue && this.LocalDrivingLicenseApplicationID.HasValue && clsLocalDrivingLicenseApplicationData.HasAttendedTestType(this.LocalDrivingLicenseApplicationID.Value, (int)TestTypeID.Value);
        
        public bool IsThereActiveScheduledTestAppointment(clsTestType.enTestType? TestTypeID)
       => TestTypeID.HasValue && this.LocalDrivingLicenseApplicationID.HasValue && clsLocalDrivingLicenseApplicationData.HasActiveScheduledTestAppointment(this.LocalDrivingLicenseApplicationID.Value, (int)TestTypeID);
        public bool HasAnyActiveLicense()
            => this.LocalDrivingLicenseApplicationID.HasValue&&clsLocalDrivingLicenseApplicationData.GetAnyActiveLicenseID(this.LocalDrivingLicenseApplicationID.Value)!=null;
        public static bool HasPassedAllTestTypes(int? LocalDrivingLicenseApplicationID)
            => LocalDrivingLicenseApplicationID.HasValue&&clsLocalDrivingLicenseApplicationData.DoesPassAllTestTypes(LocalDrivingLicenseApplicationID.Value);
        public bool HasPassedAllTestTypes()
         => this.LocalDrivingLicenseApplicationID.HasValue&&clsLocalDrivingLicenseApplicationData.DoesPassAllTestTypes(this.LocalDrivingLicenseApplicationID.Value);
        public int? IssueDrivingLicenseForFirstTime(int? UserID,string Notes)
        {
            clsDriver Driver;
            clsLicense NewLicense=new clsLicense();
            if (!clsDriver.IsDriver(this.ApplicantPersonID.Value))
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = UserID;
                Driver.LoggedUserID= UserID;
                Driver.CreatedDate = DateTime.Now;
                if (!Driver.Save())
                {
                    return null;
                }
            }
            Driver = clsDriver.GetByPersonID(this.Person.PersonID.Value);

            NewLicense.DriverID = Driver.DriverID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears((int)this.LicenseClass?.DefaultValidityLength);
            NewLicense.CreatedByUserID = UserID;
            NewLicense.LoggedUserID= UserID;
            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.Notes = Notes;
            NewLicense.IssueReason = clsLicense.enIssueReason.FirstTime;
            NewLicense.IsActive = true;
            NewLicense.LicenseClass = this.LicenseClassID;
            NewLicense.PaidFees = this.LicenseClass.ClassFees;
            if(NewLicense.Save())
            {
                this.SetCompleted(UserID);
                return NewLicense.LicenseID;
            }
            else
                return null;

        }
        public int? GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(clsTestType.enTestType? TestTypeID)
            => (this.ApplicantPersonID.HasValue&&this.LicenseClassID.HasValue&& TestTypeID.HasValue)? clsTestData.GetLastTestIDByPersonIDPerTestTypeAndLicenseClass((int)this.ApplicantPersonID, (int)this.LicenseClassID, (int)TestTypeID):null;
        public clsTest GetLastTestAppointmentInfoPerTestType(clsTestType.enTestType? TestTypeID)
        {
            int? TestID = GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(TestTypeID.Value);
            return TestID != null ? clsTest.GetByID(TestID.Value) : default;
        }





    }
}
