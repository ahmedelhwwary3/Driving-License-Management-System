using DataAccessLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsInternationalLicenseData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetInternationalLicenseDataByID(int InternationalLicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@InternationalLicenseID", InternationalLicenseID);
            return DBManager?.ExecuteDataTable("sp_GetInternationalLicenseDataByID", Parameters);
        }

        public static DataTable GetAllInternationalLicensesList()
            => DBManager?.ExecuteDataTable("sp_GetAllInternationalLicensesData");

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            return DBManager?.ExecuteDataTable("sp_GetInternationalLicenseDataByDriverID", Parameters);
        }

        public static int? AddInternationalLicense(int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive,
            int CreatedByUserID, decimal PaidFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddSQLParameter("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Parameters?.AddSQLParameter("@IssueDate", IssueDate);
            Parameters?.AddSQLParameter("@ExpirationDate", ExpirationDate);
            Parameters?.AddSQLParameter("@IsActive", IsActive);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager?.ExecuteScalar("sp_AddInternationalLicense", Parameters);
            return ID.ToNullableInt32();
        }

        public static int? GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            object Result = DBManager?.ExecuteScalar("sp_GetActiveInternationalLicenseIDByDriverID", Parameters);
            return Result.ToNullableInt32();
        }

        public static bool UpdateInternationalLicenseByID(int InternationalLicenseID, int ApplicationID,
            int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive,
            int CreatedByUserID, int LoggedUserID, decimal PaidFees)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@InternationalLicenseID", InternationalLicenseID);
            Parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddSQLParameter("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Parameters?.AddSQLParameter("@IssueDate", IssueDate);
            Parameters?.AddSQLParameter("@ExpirationDate", ExpirationDate);
            Parameters?.AddSQLParameter("@IsActive", IsActive);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateInternationalLicenseByID", Parameters) ?? false;
        }
    }
}
