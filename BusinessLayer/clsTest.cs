using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using DataAccessLayer;
namespace BusinessLayer
{

    public class clsTest
    {

        public int? TestID { get; set; }
        public int? TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment { get; set; }
        public bool TestResult { get; set; } = false;
        public string Notes { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public int? LoggedUserID { get; set; }

        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public clsTest()
        {
            this.TestID = null;
            this.TestAppointmentID = null;
            this.TestAppointment =new clsTestAppointment();
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = null;
            this.CreatedByUser=new clsUser();
            this.LoggedUserID = null;
            Mode = enMode.AddNew;
        }
        protected clsTest(int? TestID, int? TestAppointmentID, bool TestResult, string Notes, int? CreatedByUserID)
        {
            this.LoggedUserID = null;
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            var getTestAppointment = new Func<int?, clsTestAppointment>(clsTestAppointment.GetByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);

            this.TestAppointment = getTestAppointment.GetByNullableID(TestAppointmentID);
            this.CreatedByUser = getUser.GetByNullableID(CreatedByUserID);

            Mode = enMode.Update;
        }
        private bool _AddNewTest()
        {
            if (this.TestAppointmentID.HasValue && this.CreatedByUserID.HasValue && this.LoggedUserID.HasValue)
            {
                this.TestID = clsTestData.AddNewTest(
                    this.TestAppointmentID.Value,
                    this.TestResult,
                    this.Notes,
                    this.CreatedByUserID.Value,
                    this.LoggedUserID.Value
                );
            }
            return this.TestID != null;
        }

        private bool _UpdateTest()
        {
            if (this.TestID.HasValue && this.TestAppointmentID.HasValue && this.CreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                return clsTestData.UpdateTestByID(
                    this.TestID.Value,
                    this.TestAppointmentID.Value,
                    this.TestResult,
                    this.Notes,
                    this.CreatedByUserID.Value,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }



        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTest())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateTest();
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool IsExist(int? TestID)
    => TestID.HasValue && clsTestData.IsExist(TestID.Value);

        public static clsTest GetByID(int? TestID)
        {
            if (!TestID.HasValue)
                return null;

            DataTable dt = clsTestData.GetTestByID(TestID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsTest(
                TestAppointmentID: row["TestAppointmentID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                Notes: row["Notes"] .ToString()??"",
                TestID: row["TestID"].ToNullableInt32(),
                TestResult: row["TestResult"] .ToBoolean()
            );
        }

        public static DataTable GetAllTestsList()
            => clsTestData.GetAllTestsList();

        public static bool DeleteTesByID(int? TestID,int? LoggedUserID)
        {
            if (!TestID.HasValue)
                return false;

            return clsTestData.DeleteTest(TestID.Value, LoggedUserID.Value);
        }

        public static int GetLastTestInfoForPersonAndTestTypeAndLicenseClass(int? PersonID, int? LicenseClassID, int? TestTypeID)
        {
            if (!PersonID.HasValue || !LicenseClassID.HasValue || !TestTypeID.HasValue)
                return 0;

            return clsTestData.GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(PersonID.Value, LicenseClassID.Value, TestTypeID.Value);
        }

        public static int? GetPassedTestCount(int? LocalDrivingLicenseApplicationID)
            => LocalDrivingLicenseApplicationID.HasValue ? clsTestData.GetPassedTestCountPerLocalApplication(LocalDrivingLicenseApplicationID.Value) : null;

        public static bool IsPassedAllTestTypes(int? LocalDrivingLicenseApplicationID)
        {
            var passedTestCount = GetPassedTestCount(LocalDrivingLicenseApplicationID);
            return passedTestCount.HasValue && passedTestCount.Value == 3;
        }






    }
}
    
