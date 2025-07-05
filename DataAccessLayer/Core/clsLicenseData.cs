using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsLicenseData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllLicensesList()
            => DBManager?.ExecuteDataTable("sp_GetAllDetainedLicensesFullData");

        public static DataTable GetAllLicensesFullDataByDriverID(int DriverID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            return DBManager?.ExecuteDataTable("sp_GetAllLicensesFullDataByDriverID", Parameters);
        }

        public static bool IsExistedByID(int LicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            object result = DBManager?.ExecuteScalar("sp_IsLicenseExistedByID", Parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByPersonID(int PersonID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            return DBManager?.ExecuteDataTable("sp_GetLicenseByPersonID", Parameters);
        }

        public static int? AddLicenseExistedDriver(int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            decimal PaidFees, bool IsActive, int IssueReason,
            int CreatedByUserID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddSQLParameter("@LicenseClass", LicenseClass);
            Parameters?.AddSQLParameter("@IssueDate", IssueDate);
            Parameters?.AddSQLParameter("@ExpirationDate", ExpirationDate);
            Parameters?.AddSQLParameter("@Notes", Notes);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddSQLParameter("@IsActive", IsActive);
            Parameters?.AddSQLParameter("@IssueReason", IssueReason);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager?.ExecuteScalar("sp_AddLicenseExistedDriver", Parameters);
            return ID.ToNullableInt32();
        }
        public static int? IssueLicenseFirstTime(int ApplicationID,int PersonID, int LicenseClass,
           DateTime IssueDate, DateTime ExpirationDate, string Notes,
           decimal PaidFees, bool IsActive,int CreatedByUserID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            Parameters?.AddSQLParameter("@LicenseClass", LicenseClass);
            Parameters?.AddSQLParameter("@IssueDate", IssueDate);
            Parameters?.AddSQLParameter("@ExpirationDate", ExpirationDate);
            Parameters?.AddSQLParameter("@Notes", Notes);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddSQLParameter("@IsActive", IsActive);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager?.ExecuteScalar("sp_AddLicenseFirstTime", Parameters);
            return ID.ToNullableInt32();
        }
        public static bool UpdateLicenseByID(int LicenseID,
            string Notes, bool IsActive, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            Parameters?.AddSQLParameter("@Notes", Notes);
            Parameters?.AddSQLParameter("@IsActive", IsActive);
            Parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateLicenseByID", Parameters) ?? false;
        }

        public static bool DeleteByID(int LicenseID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_DeleteLicenseByID", Parameters) ?? false;
        }

        public static DataTable GetByLicenseID(int LicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            return DBManager?.ExecuteDataTable("sp_GetLicenseByLicenseID", Parameters);
        }

        public static bool ActivateLicenseByID(int LicenseID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_ActivateLicenseByID", Parameters) ?? false;
        }

        public static bool DeactivateLicenseByID(int LicenseID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_DeactivateLicenseByID", Parameters) ?? false;
        }

        public static int? GetActiveLicenseIDByPersonIDPerLicenseClass(int PersonID, int LicenseClassID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@PersonID", PersonID);
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            object ID = DBManager?.ExecuteScalar("sp_GetActiveLicenseIDByPersonIDPerLicenseClass", Parameters);
            return ID.ToNullableInt32();
        }

        public static int? RenewOrReplaceOldLicense(int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate,
            decimal ApplicationPaidFees, int CreatedByUserID, DateTime LicenseExpirationDate,
            string LicenseNotes, decimal LicensePaidFees, int DriverID, int LicenseClass, 
            int IssueReason, int LoggedUserID,int PenaltyPoints)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicantPersonID", ApplicantPersonID);
            Parameters?.AddSQLParameter("@ApplicationDate", ApplicationDate);
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            Parameters?.AddSQLParameter("@ApplicationStatus", ApplicationStatus);
            Parameters?.AddSQLParameter("@LastStatusDate", LastStatusDate);
            Parameters?.AddSQLParameter("@ApplicationPaidFees", ApplicationPaidFees);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@LicenseExpirationDate", LicenseExpirationDate);
            Parameters?.AddSQLParameter("@LicenseNotes", LicenseNotes);
            Parameters?.AddSQLParameter("@LicensePaidFees", LicensePaidFees);
            Parameters?.AddSQLParameter("@DriverID", DriverID);
            Parameters?.AddSQLParameter("@LicenseClass", LicenseClass);
            Parameters?.AddSQLParameter("@IssueReason", IssueReason);
            Parameters?.AddSQLParameter("@PenaltyPoints", PenaltyPoints);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager?.ExecuteScalar("sp_RenewOrReplaceOldLicense", Parameters);
            return ID.ToNullableInt32();
        }

        public static bool HasIssuedActiveInternationalLicense(int LicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            object result = DBManager?.ExecuteScalar("sp_HasLicenseIssuedActiveInternationalLicense", Parameters);
            return result.ToBoolean();
        }
    }
}
