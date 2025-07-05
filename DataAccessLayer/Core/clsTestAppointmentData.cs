using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsTestAppointmentData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllTestAppointmentsLForLocalApp_AllTypes(int LocalDrivingLicenseApplicationID)
        {
            var parameters = new HashSet<SqlParameter> ();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            return DBManager?.ExecuteDataTable("sp_GetAllTestAppointmentsLForLocalApp_AllTypes", parameters);
        }

        public static DataTable GetAllTestAppointmentsForLocalApp_PerType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);

            return DBManager?.ExecuteDataTable("sp_GetAllTestAppointmentsLForLocalApp_PerType", parameters);
        }

        public static DataTable GetLastTestAppointmentDataByLocalAppID_PerType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);

            return DBManager?.ExecuteDataTable("sp_GetLastTestAppointmentDataByLocalAppID_PerType", parameters);
        }

        public static bool IsExistedByID(int TestAppointmentID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);

            object result = DBManager?.ExecuteScalar("sp_IsAppointmentExistedByID", parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByID(int TestAppointmentID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);

            return DBManager?.ExecuteDataTable("sp_FindTestAppointmentByID", parameters);
        }

        public static int? AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID,
            bool IsLocked, int? RetakeTestApplicationID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@AppointmentDate", AppointmentDate);
            parameters?.AddSQLParameter("@PaidFees", PaidFees);
            parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            parameters?.AddSQLParameter("@IsLocked", IsLocked);
            if(RetakeTestApplicationID.HasValue)
                parameters?.AddSQLParameter("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            else
                parameters?.AddSQLParameter("@RetakeTestApplicationID", DBNull.Value);
            parameters?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager?.ExecuteScalar("sp_AddTestAppointment", parameters);
            return ID.ToNullableInt32();
        }

        public static bool UpdateTestAppointmentByID(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID,
            bool IsLocked, int? RetakeTestApplicationID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            parameters?.AddSQLParameter("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            parameters?.AddSQLParameter("@AppointmentDate", AppointmentDate);
            parameters?.AddSQLParameter("@PaidFees", PaidFees);
            parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            parameters?.AddSQLParameter("@IsLocked", IsLocked);
            if (RetakeTestApplicationID.HasValue)
                parameters?.AddSQLParameter("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            else
                parameters?.AddSQLParameter("@RetakeTestApplicationID", DBNull.Value);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdateTestAppointmentByID", parameters) ;
        }

        public static bool DeleteTestAppointmentByID(int TestAppointmentID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeleteTestAppointmentByID", parameters);
        }

        public static int? GetTestIDByAppointmentID(int TestAppointmentID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestAppointmentID", TestAppointmentID);

            object result = DBManager?.ExecuteScalar("sp_GetTestIDByAppointmentID", parameters);
            return result.ToNullableInt32();
        }
    }
}
