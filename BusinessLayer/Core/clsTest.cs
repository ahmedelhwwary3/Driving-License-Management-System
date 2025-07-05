using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    public class clsTest
    {
        public int? TestID { get; set; }  
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment { get; set; }
        public bool TestResult { get; set; } = false;
        public string Notes { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public int LoggedUserID { get; set; }

        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public clsTest()
        {
            TestID = null;
            TestAppointmentID = default;
            TestAppointment = new clsTestAppointment();
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = default;
            CreatedByUser = new clsUser();
            LoggedUserID = default;
            Mode = enMode.AddNew;
        }

        protected clsTest(int? TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes ?? string.Empty;
            this.CreatedByUserID = CreatedByUserID;
            this.LoggedUserID = default;

            TestAppointment = clsTestAppointment.GetByID(TestAppointmentID);
            CreatedByUser = clsUser.GetByID(CreatedByUserID);

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            TestID = clsTestData.AddNewTest(
                TestAppointmentID,
                TestResult,
                Notes,
                CreatedByUserID,
                LoggedUserID
            );
            return TestID != null;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTestByID(
                TestID.Value,
                TestAppointmentID,
                TestResult,
                Notes,
                CreatedByUserID,
                LoggedUserID
            );
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewTest())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Mode == enMode.Update)
            {
                return _UpdateTest();
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
                TestID: row["TestID"].ToInt32(),
                TestAppointmentID: row["TestAppointmentID"].ToInt32(),
                TestResult: row["TestResult"].ToBoolean(),
                Notes: row["Notes"]?.ToString() ?? string.Empty,
                CreatedByUserID: row["CreatedByUserID"].ToInt32()
            );
        }

        public static DataTable GetAllTestsList()
            => clsTestData.GetAllTestsList();

        public static bool DeleteTesByID(int? TestID, int? LoggedUserID)
            => TestID.HasValue && LoggedUserID.HasValue && clsTestData.DeleteTest(TestID.Value, LoggedUserID.Value);

        public static int GetLastTestInfoForPersonAndTestTypeAndLicenseClass(int PersonID, int LicenseClassID, int TestTypeID)
            => clsTestData.GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(PersonID, LicenseClassID, TestTypeID);

        public static int? GetPassedTestCount(int LocalDrivingLicenseApplicationID)
            => clsTestData.GetPassedTestCountPerLocalApplication(LocalDrivingLicenseApplicationID);

        public static bool IsPassedAllTestTypes(int LocalDrivingLicenseApplicationID)
        {
            var passedCount = GetPassedTestCount(LocalDrivingLicenseApplicationID);
            return passedCount.HasValue && passedCount.Value == 3;
        }
    }
}
