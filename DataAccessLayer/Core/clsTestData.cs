using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsTestData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllTestsList()
            => DBManager?.ExecuteDataTable("sp_GetAllTests");

        public static bool IsExist(int TestID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestID", TestID);

            object result = DBManager?.ExecuteScalar("sp_IsTestExistedByID", parameters);
            return result.ToBoolean();
        }

        public static int GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(int PersonID, int LicenseClassID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@PersonID", PersonID);
            parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);

            int? result = DBManager?.ExecuteScalar("sp_GetLastTestIDByPersonIDPerTestTypeAndLicenseClass", parameters) as int?;
            return result ?? -1;
        }

        public static DataTable GetTestByID(int TestID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestID", TestID);

            return DBManager?.ExecuteDataTable("sp_GetTestByID", parameters);
        }

        public static int? AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);
            parameters?.AddSQLParameter("@TestResult", TestResult);
            parameters?.AddSQLParameter("@Notes", Notes);
            parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            parameters?.AddLoggedUserID(LoggedUserID);

            object id = DBManager?.ExecuteScalar("sp_AddTest", parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateTestByID(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestID", TestID);
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);
            parameters?.AddSQLParameter("@TestResult", TestResult);
            parameters?.AddSQLParameter("@Notes", Notes);
            parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateTestByID", parameters) ?? false;
        }

        public static bool DeleteTest(int TestID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestID", TestID);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_DeleteTestByID", parameters) ?? false;
        }

        public static int? GetPassedTestCountPerLocalApplication(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            object result = DBManager?.ExecuteScalar("sp_GetPassedTestCountPerLocalApplication", parameters);
            return result.ToNullableInt32();
        }
    }
}
