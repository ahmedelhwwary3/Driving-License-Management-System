using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsDriverData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllDriversList()
            => DBManager?.ExecuteDataTable("sp_GetAllDriversData");

        public static bool IsExistByID(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            object result = DBManager?.ExecuteScalar("sp_IsDriverExistByID", Parameters);
            return result.ToBoolean();
        }

        public static bool IsPersonDriver(int PersonID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            object result = DBManager?.ExecuteScalar("sp_IsPersonDriver", Parameters);
            return result.ToBoolean();
        }

        public static int? AddDriver(int PersonID, int CreatedByUserID,
            DateTime CreatedDate, int LoggedUserID, int PenaltyPoints)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@CreatedDate", CreatedDate);
            Parameters?.AddSQLParameter("@PenaltyPoints", PenaltyPoints);
            Parameters?.AddLoggedUserID(LoggedUserID);
            object id = DBManager?.ExecuteScalar("sp_AddDriver", Parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateDriverByID(int DriverID, int PersonID,
            int CreatedByUserID, DateTime CreatedDate, int LoggedUserID, int PenaltyPoints)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@CreatedDate", CreatedDate);
            Parameters?.AddSQLParameter("@PenaltyPoints", PenaltyPoints);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_UpdateDriverByID", Parameters) ?? false;
        }

        public static bool DeleteByID(int DriverID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_DeleteDriverByID", Parameters) ?? false;
        }

        public static DataTable GetByPersonID(int PersonID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            return DBManager?.ExecuteDataTable("sp_GetDriverByPersonID", Parameters);
        }

        public static DataTable GetByID(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            return DBManager?.ExecuteDataTable("sp_GetDriverByDriverID", Parameters);
        }

        public static DataTable GetAllDriverLocalLicenses(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            return DBManager?.ExecuteDataTable("sp_GetDriverLocalLicensesData", Parameters);
        }

        public static DataTable GetAllInternationalLicensesData(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            return DBManager?.ExecuteDataTable("sp_GetDriverInternationalLicensesData", Parameters);
        }
    }
}
