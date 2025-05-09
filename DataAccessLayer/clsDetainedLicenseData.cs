using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace DataAccessLayer
{
    public static class clsDetainedLicenseData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetDetainedLicenseByID(int DetainID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DetainID", DetainID);
         
            return DBManager.ExecuteDataTable("sp_GetDetainedLicenseDataByID", map);
        }

        public static DataTable GetDetainedLicenseByLicenseID(int LicenseID)
        {         
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            return DBManager.ExecuteDataTable("sp_GetDetainedLicenseDataByLicenseID", map);
        }

        public static DataTable GetAllDetainedLicensesFullData()
        {
            return DBManager.ExecuteDataTable("sp_GetAllDetainedLicensesFullData");
        }

        public static int? AddDetainedLicense(int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID,int LoggedUserID)
        {
             
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            map?.Add("@DetainDate", DetainDate);
            map?.Add("@FineFees", FineFees);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@ReleaseDate", DBNull.Value);
            map?.Add("@ReleasedByUserID", DBNull.Value);
            map?.Add("@ReleaseApplicationID", DBNull.Value);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddNewDetainedLicense", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID, bool IsReleased, 
            DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            map?.Add("@DetainID", DetainID);
            map?.Add("@DetainDate", DetainDate);
            map?.Add("@FineFees", FineFees);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@IsReleased", IsReleased);
            map?.Add("@ReleaseDate", ReleaseDate);
            map?.Add("@ReleasedByUserID", ReleasedByUserID);
            map?.Add("@ReleaseApplicationID", ReleaseApplicationID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateDetainedLicenseByID", map);
        }

        public static bool ReleaseDetainedLicenseByID(int DetainID,DateTime ReleaseDate,
                 int ReleasedByUserID,decimal PaidFees, int ReleaseApplicationID, int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DetainID", DetainID);
            map?.Add("@ReleasedByUserID", ReleasedByUserID);
            map?.Add("@ReleaseApplicationID", ReleaseApplicationID);
            map?.Add("@ReleaseDate", ReleaseDate);
            map?.Add("@PaidFees", PaidFees);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_ReleaseDetainedLicenseByID", map);
        }
        
        public static bool IsLicenseDetainedByID(int LicenseID)
        {
   
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            object Result = DBManager.ExecuteScalar("sp_IsLicenseDetainedByID", map);
            return Result.ToBoolean();
        }

        
    }
}
