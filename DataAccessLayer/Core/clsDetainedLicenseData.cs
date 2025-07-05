using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsDetainedLicenseData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetDetainedLicenseByDetainID(int DetainID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DetainID", DetainID);

            return DBManager?.ExecuteDataTable("sp_GetDetainedLicenseDataByID", Parameters);
        }

        public static DataTable GetDetainedLicenseByLicenseID(int LicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);

            return DBManager?.ExecuteDataTable("sp_GetDetainedLicenseDataByLicenseID", Parameters);
        }

        public static DataTable GetAllDetainedLicensesFullData()
            => DBManager?.ExecuteDataTable("sp_GetAllDetainedLicensesFullData");

        public static int? AddDetainedLicense(int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);
            Parameters?.AddSQLParameter("@DetainDate", DetainDate);
            Parameters?.AddSQLParameter("@FineFees", FineFees);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@ReleaseDate", DBNull.Value);
            Parameters?.AddSQLParameter("@ReleasedByUserID", DBNull.Value);
            Parameters?.AddSQLParameter("@ReleaseApplicationID", DBNull.Value);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object id = DBManager?.ExecuteScalar("sp_AddNewDetainedLicense", Parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID, bool IsReleased,
            DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID, int LoggedUserID)
        {
            ReleaseApplicationID = 0;

            var Parameters = new HashSet<SqlParameter>();

            Parameters?.AddSQLParameter("@DetainID", DetainID);
            Parameters?.AddSQLParameter("@ReleasedByUserID", ReleasedByUserID);
            Parameters?.AddSQLParameter("@ReleaseApplicationID", ReleaseApplicationID, false);
            Parameters?.AddSQLParameter("@ReleaseDate", ReleaseDate);
            Parameters?.AddSQLParameter("@FineFees", FineFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            bool result = DBManager.ExecuteNonQuery("sp_ReleaseDetainedLicenseByID", Parameters);

            object outputParam = Parameters.ElementAt(2).Value;
            if (outputParam != DBNull.Value && outputParam != null)
                ReleaseApplicationID = Convert.ToInt32(outputParam);
            return result;
        }

        public static bool ReleaseDetainedLicenseByID(int DetainID, DateTime ReleaseDate,
            int ReleasedByUserID, decimal PaidFees, out int? ReleaseApplicationID, int LoggedUserID)
        {
            //Output Param Must be returned with value
            ReleaseApplicationID = 0;
            
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@DetainID", DetainID);
            Parameters?.AddSQLParameter("@ReleasedByUserID", ReleasedByUserID);
            Parameters?.AddSQLParameter("@ReleaseApplicationID",ReleaseApplicationID,false);
            Parameters?.AddSQLParameter("@ReleaseDate", ReleaseDate);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddLoggedUserID(LoggedUserID);
            bool result = DBManager?.ExecuteNonQuery("sp_ReleaseDetainedLicenseByID", Parameters) ?? false;
            object OutValue = Parameters.ElementAt(2).Value;
            if (OutValue != DBNull.Value && OutValue != null)
                ReleaseApplicationID = Convert.ToInt32(OutValue);
            ReleaseApplicationID = Convert.ToInt32(OutValue);
            return result;
        }

        public static bool IsLicenseDetainedByID(int LicenseID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseID", LicenseID);

            object result = DBManager?.ExecuteScalar("sp_IsLicenseDetainedByID", Parameters);
            return result.ToBoolean();
        }
    }
}
