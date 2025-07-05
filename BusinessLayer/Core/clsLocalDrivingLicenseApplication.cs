using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static BusinessLayer.Core.clsLicenseClass;
using static BusinessLayer.Core.clsTestType;

namespace BusinessLayer.Core
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        protected new enum enMode { AddNew, Update }
        protected new enMode Mode;

        public int? LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; } = (int)enLicenseClassID.Class3OrdinaryDrivingLicense;
        public clsLicenseClass LicenseClass { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            LoggedUserID = default;
            LocalDrivingLicenseApplicationID = default;
            LicenseClassID = (int)enLicenseClassID.Class3OrdinaryDrivingLicense;
            ApplicationID = default;

            Mode = enMode.AddNew;
        }

        protected clsLocalDrivingLicenseApplication(int? localDrivingLicenseApplicationID, enLicenseClassID licenseClassID,
            int applicationID, int applicantPersonID, DateTime applicationDate, enApplicationStatus applicationStatus,
            enApplicationType applicationTypeID, int createdByUserID, DateTime lastStatusDate, decimal paidFees)
            : base(applicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, createdByUserID, paidFees)
        {
            LoggedUserID = default;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LicenseClassID = (int)licenseClassID;
            LicenseClass = clsLicenseClass.GetByID((int)licenseClassID);

            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData
                .AddLocalDrivingLicenseApplication(
                    (int)LicenseClassID,
                    ApplicationID.Value,
                    LoggedUserID
                );

            return LocalDrivingLicenseApplicationID != null;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationByID(
                LocalDrivingLicenseApplicationID.Value,
                (int)LicenseClassID,
                ApplicationID.Value,
                LoggedUserID
            );
        }

        public new bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            return Mode switch
            {
                enMode.AddNew => _AddNewLocalDrivingLicenseApplication() ? (Mode = enMode.Update) == enMode.Update : false,
                enMode.Update => _UpdateLocalDrivingLicenseApplication(),
                _ => false,
            };
        }

        public static bool IsExistByID(int localDrivingLicenseApplicationID)
            => clsLocalDrivingLicenseApplicationData.IsExistByID(localDrivingLicenseApplicationID);

        public static clsLocalDrivingLicenseApplication GetLocalApplicationByID(int localDrivingLicenseApplicationID)
        {
            DataTable dt = clsLocalDrivingLicenseApplicationData.GetByID(localDrivingLicenseApplicationID);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

            return new clsLocalDrivingLicenseApplication(
                applicationID: (int)row["ApplicationID"],
                applicantPersonID: (int)row["ApplicantPersonID"],
                applicationDate: (DateTime)row["ApplicationDate"],
                applicationStatus: (enApplicationStatus)(int)row["ApplicationStatus"],
                applicationTypeID: (enApplicationType)(int)row["ApplicationTypeID"],
                createdByUserID: (int)row["CreatedByUserID"],
                lastStatusDate: (DateTime)row["LastStatusDate"],
                paidFees: row["PaidFees"].ToDecimal(),
                localDrivingLicenseApplicationID: (int)row["LocalDrivingLicenseApplicationID"],
                licenseClassID: (enLicenseClassID)(int)row["LicenseClassID"]
            );
        }

        public static clsLocalDrivingLicenseApplication GetLocalAplicationByApplicationID(int? applicationID)
        {
            if (!applicationID.HasValue)
                return null;
            DataTable dt = clsLocalDrivingLicenseApplicationData.GetByBaseApplicationID(applicationID.Value);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

            return new clsLocalDrivingLicenseApplication(
                applicationID: (int)row["ApplicationID"],
                applicantPersonID: (int)row["ApplicantPersonID"],
                applicationDate: (DateTime)row["ApplicationDate"],
                applicationStatus: (enApplicationStatus)(int)row["ApplicationStatus"],
                applicationTypeID: (enApplicationType)(int)row["ApplicationTypeID"],
                createdByUserID: (int)row["CreatedByUserID"],
                lastStatusDate: (DateTime)row["LastStatusDate"],
                paidFees: row["PaidFees"].ToDecimal(),
                localDrivingLicenseApplicationID: (int)row["LocalDrivingLicenseApplicationID"],
                licenseClassID: (enLicenseClassID)(int)row["LicenseClassID"]
            );
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationsList()
            => clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsList();

        public static bool DeleteByID(int localDrivingLicenseApplicationID, int loggedUserID)
            => clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplicationByID(localDrivingLicenseApplicationID, loggedUserID);

        public bool HasPassedTestType(enTestType testTypeID)
            => clsLocalDrivingLicenseApplicationData.HasLocaApplicationPassedTestType(LocalDrivingLicenseApplicationID.Value, (int)testTypeID);

        public int? GetActiveLicenseID()
            => clsLocalDrivingLicenseApplicationData.GetAnyActiveLicenseID(LocalDrivingLicenseApplicationID.Value);

        public static int? GetActiveLicenseID(int localDrivingLicenseApplicationID)
            => clsLocalDrivingLicenseApplicationData.GetActiveLocalLicenseID(localDrivingLicenseApplicationID);

        public static bool IsLicenseIssued(int localDrivingLicenseApplicationID)
            => GetActiveLicenseID(localDrivingLicenseApplicationID) != null;

        public bool IsLicenseIssued()
            => clsLocalDrivingLicenseApplicationData.GetActiveLocalLicenseID(LocalDrivingLicenseApplicationID.Value) != null;

        public int GetPassedTests()
            => clsLocalDrivingLicenseApplicationData.GetAllPassedTestsCount(LocalDrivingLicenseApplicationID.Value) ?? 0;

        public static int GetPassedTests(int localDrivingLicenseApplicationID)
            => clsLocalDrivingLicenseApplicationData.GetAllPassedTestsCount(localDrivingLicenseApplicationID) ?? 0;

        public int CountAllTestTrials(enTestType testTypeID)
            => clsLocalDrivingLicenseApplicationData.GetTotalTrialsPerTestType(LocalDrivingLicenseApplicationID.Value, (int)testTypeID) ?? 0;

        public bool HasActiveTestAppointment(enTestType testTypeID)
            => clsLocalDrivingLicenseApplicationData.HasActiveScheduledTestAppointment(LocalDrivingLicenseApplicationID.Value, (int)testTypeID);

        public bool HasAttentedTestType(enTestType testTypeID)
            => clsLocalDrivingLicenseApplicationData.HasAttendedTestType(LocalDrivingLicenseApplicationID.Value, (int)testTypeID);

        public bool IsThereActiveScheduledTestAppointment(enTestType testTypeID)
            => clsLocalDrivingLicenseApplicationData.HasActiveScheduledTestAppointment(LocalDrivingLicenseApplicationID.Value, (int)testTypeID);

        public bool HasAnyActiveLicense()
            => clsLocalDrivingLicenseApplicationData.GetAnyActiveLicenseID(LocalDrivingLicenseApplicationID.Value) != null;

        public static bool HasPassedAllTestTypes(int localDrivingLicenseApplicationID)
            => clsLocalDrivingLicenseApplicationData.DoesPassAllTestTypes(localDrivingLicenseApplicationID);

        public bool HasPassedAllTestTypes()
            => clsLocalDrivingLicenseApplicationData.DoesPassAllTestTypes(LocalDrivingLicenseApplicationID.Value);

        public int? IssueDrivingLicenseForFirstTime(int userID, string notes)
        {
            clsLicense lic = new clsLicense();
 
            lic.LicenseClass = LicenseClassID;
            lic.IssueDate = DateTime.Now;
            lic.ExpirationDate = DateTime.Now.AddYears((int)LicenseClass.DefaultValidityLength);
            lic.Notes = notes;
            lic.PaidFees = LicenseClass.ClassFees;
            lic.IsActive = true;
            lic.IssueReason = (int)clsLicense.enIssueReason.FirstTime;
            lic.CreatedByUserID = userID;
            lic.LoggedUserID = userID;
            return lic.IssueLicenseFirstTime(this.ApplicationID.Value,this.ApplicantPersonID, lic.LicenseClass,
            lic.IssueDate, lic.ExpirationDate, lic.Notes,
            lic.PaidFees, lic.IsActive, lic.CreatedByUserID, lic.LoggedUserID);
        }

        public int? GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(enTestType testTypeID)
            => clsTestData.GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(ApplicantPersonID, (int)LicenseClassID, (int)testTypeID);

        public clsTest GetLastTestAppointmentInfoPerTestType(enTestType testTypeID)
        {
            int? TestID = GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(testTypeID);
            return TestID.HasValue ? clsTest.GetByID(TestID.Value) : default;
        }
    }
}
