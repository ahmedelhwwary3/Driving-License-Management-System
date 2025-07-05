using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using static BusinessLayer.Core.clsLocalDrivingLicenseApplication;
using static BusinessLayer.Core.clsApplication;
namespace BusinessLayer.Core
{
    public class clsTestAppointment
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public static DateTime TestMaxDate => DateTime.Now.AddMonths(3);

        public int? TestAppointmentID { get; set; }

        public int TestTypeID { get; set; } = (int)clsTestType.enTestType.Vision;
        public clsTestType TestType { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }

        public DateTime AppointmentDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser User { get; set; }

        public bool IsLocked { get; set; }

        [AllowNull]
        public int? RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }

        public int LoggedUserID { get; set; }

        public clsTestAppointment()
        {
            TestAppointmentID = null;
            TestType = new clsTestType();
            LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            User = new clsUser();
            IsLocked = false;
            RetakeTestApplicationID = null;
            RetakeTestApplicationInfo = null;

            Mode = enMode.AddNew;
        }

        protected clsTestAppointment(int? testAppointmentID, clsTestType.enTestType testTypeID,
            int localDrivingLicenseApplicationID, DateTime appointmentDate, decimal paidFees,
            int createdByUserID, bool isLocked, int? retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = (int)testTypeID;
            TestType = clsTestType.GetByID((int)testTypeID);
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LocalDrivingLicenseApplication = GetLocalApplicationByID(localDrivingLicenseApplicationID);
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            User = clsUser.GetByID(createdByUserID);
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            RetakeTestApplicationInfo = GetApplicationByID(RetakeTestApplicationID);

            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            TestAppointmentID = clsTestAppointmentData.AddTestAppointment(
                (int)TestTypeID,
                LocalDrivingLicenseApplicationID,
                AppointmentDate,
                PaidFees,
                CreatedByUserID,
                IsLocked,
                RetakeTestApplicationID,
                LoggedUserID
            );

            return TestAppointmentID.HasValue;
        }

        private bool _UpdateTestAppointment()
        {
            if (!TestAppointmentID.HasValue)
                return false;

            return clsTestAppointmentData.UpdateTestAppointmentByID(
                TestAppointmentID.Value,
                (int)TestTypeID,
                LocalDrivingLicenseApplicationID,
                AppointmentDate,
                PaidFees,
                CreatedByUserID,
                IsLocked,
                RetakeTestApplicationID,
                LoggedUserID
            );
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                bool result = _AddNewTestAppointment();
                if (result)
                {
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            }
            else if (Mode == enMode.Update)
            {
                return _UpdateTestAppointment();
            }

            return false;
        }

        public static bool IsExistedByID(int? testAppointmentID)
        {
            return testAppointmentID.HasValue && clsTestAppointmentData.IsExistedByID(testAppointmentID.Value);
        }

        public static clsTestAppointment GetByID(int? testAppointmentID)
        {
            if (!testAppointmentID.HasValue)
                return null;
            DataTable dt = clsTestAppointmentData.GetByID(testAppointmentID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsTestAppointment(
                testAppointmentID: row["TestAppointmentID"].ToInt32(),
                testTypeID: (clsTestType.enTestType)row["TestTypeID"].ToInt32(),
                localDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToInt32(),
                appointmentDate: row["AppointmentDate"].ToDate(),
                paidFees: row["PaidFees"].ToDecimal(),
                createdByUserID: row["CreatedByUserID"].ToInt32(),
                isLocked: row["IsLocked"].ToBoolean(),
                retakeTestApplicationID: row["RetakeTestApplicationID"].ToNullableInt32()
            );
        }

        public static DataTable GetAllTestAppointmentsListPerTestType(int? localAppID, clsTestType.enTestType? testTypeID)
        {
            if (testTypeID.HasValue && localAppID.HasValue)
            {
                return clsTestAppointmentData.GetAllTestAppointmentsForLocalApp_PerType(localAppID.Value, (int)testTypeID.Value);
            }

            return new DataTable();
        }

        public static DataTable GetAllTestAppointmentsList(int? localAppID)
        {
            return localAppID.HasValue
                ? clsTestAppointmentData.GetAllTestAppointmentsLForLocalApp_AllTypes(localAppID.Value)
                : new DataTable();
        }

        public static bool DeleteTestAppointment(int? testAppointmentID, int? loggedUserID)
        {
            if (!testAppointmentID.HasValue || !loggedUserID.HasValue)
                return false;

            return clsTestAppointmentData.DeleteTestAppointmentByID(testAppointmentID.Value, loggedUserID.Value);
        }

        public static clsTestAppointment FindLastTestAppointment(int localAppID, int? testTypeID)
        {
            if (!testTypeID.HasValue)
                return null;

            DataTable dt = clsTestAppointmentData.GetLastTestAppointmentDataByLocalAppID_PerType(localAppID, testTypeID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsTestAppointment(
                testAppointmentID: row["TestAppointmentID"].ToInt32(),
                testTypeID: (clsTestType.enTestType)row["TestTypeID"].ToInt32(),
                localDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToInt32(),
                appointmentDate: row["AppointmentDate"].ToDate(),
                paidFees: row["PaidFees"].ToDecimal(),
                createdByUserID: row["CreatedByUserID"].ToInt32(),
                isLocked: row["IsLocked"].ToBoolean(),
                retakeTestApplicationID: row["RetakeTestApplicationID"].ToNullableInt32()
            );
        }

        public int? GetTestID()
        {
            return TestAppointmentID.HasValue
                ? clsTestAppointmentData.GetTestIDByAppointmentID(TestAppointmentID.Value)
                : null;
        }
    }
}
