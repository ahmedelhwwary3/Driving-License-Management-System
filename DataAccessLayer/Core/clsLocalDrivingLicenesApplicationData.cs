using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllLocalDrivingLicenseApplicationsList()
            => DBManager?.ExecuteDataTable("sp_GetAllLocalDrivingLicenseApplicationsList");

        public static bool IsExistByID(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object result = DBManager?.ExecuteScalar("sp_IsLocalDrivingLicenseApplicationExistedByID", parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByID(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            return DBManager?.ExecuteDataTable("sp_GetLocalDrivingLicenseApplicationByID", parameters);
        }

        public static DataTable GetByBaseApplicationID(int ApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            return DBManager?.ExecuteDataTable("sp_GetLocalDrivingLicenseApplicationByApplicationID", parameters);
        }

        public static int? AddLocalDrivingLicenseApplication(int LicenseClassID, int ApplicationID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            parameters?.AddLoggedUserID(LoggedUserID);
            object id = DBManager?.ExecuteScalar("sp_AddLocalDrivingLicenseApplication", parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID,
            int LicenseClassID, int ApplicationID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_UpdateLocalDrivingLicenseApplicationByID", parameters) ?? false;
        }

        public static bool DeleteLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_DeleteLocalDrivingLicenseApplicationByID", parameters) ?? false;
        }

        public static bool HasLocaApplicationPassedTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            object result = DBManager?.ExecuteScalar("sp_HasLocalDrivingLicenseApplicationPassedTestType", parameters);
            return result.ToBoolean();
        }

        public static bool HasAttendedTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            object result = DBManager?.ExecuteScalar("sp_HasLocalDrivingLicenseApplicationAttendedTestType", parameters);
            return result.ToBoolean();
        }

        public static int? GetTotalTrialsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            object count = DBManager?.ExecuteScalar("sp_GetTotalTrialsPerTestType", parameters);
            return count.ToNullableInt32();
        }

        public static int? GetActiveScheduledTestID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            object id = DBManager?.ExecuteScalar("sp_GetActiveScheduledTestID", parameters);
            return id.ToNullableInt32();
        }

        public static bool HasActiveScheduledTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
            => GetActiveScheduledTestID(LocalDrivingLicenseApplicationID, TestTypeID) != null;

        public static int? GetAllPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object count = DBManager?.ExecuteScalar("sp_GetAllPassedTestCount", parameters);
            return count.ToNullableInt32();
        }

        public static bool DoesPassAllTestTypes(int LocalDrivingLicenseApplicationID)
            => GetAllPassedTestsCount(LocalDrivingLicenseApplicationID) == 3;

        public static int? GetAnyActiveLicenseID(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object id = DBManager?.ExecuteScalar("sp_GetAnyActiveLicenseIDByLocalApplicationID", parameters);
            return id.ToNullableInt32();
        }

        public static int? GetActiveLocalLicenseID(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object id = DBManager?.ExecuteScalar("sp_GetActiveLocalLicenseIDByLocalApplicationID", parameters);
            return id.ToNullableInt32();
        }
    }
}
