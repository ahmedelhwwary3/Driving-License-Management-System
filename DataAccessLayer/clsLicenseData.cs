using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class clsLicenseData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllLicensesList()
        {
            return DBManager.ExecuteDataTable("sp_GetAllDetainedLicensesFullData");
        }

        public static DataTable GetAllLicensesFullDataByDriverID(int DriverID)
        {
            return DBManager.ExecuteDataTable("sp_GetAllLicensesFullDataByDriverID");
        }

        public static bool IsExistedByID(int LicenseID)
        {
            //sp_IsLicenseExistedByID
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            object Result = DBManager.ExecuteScalar("sp_IsLicenseExistedByID", map);
            return Result.ToBoolean();
        }

        public static DataTable GetByPersonID(int PersonID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);

            return DBManager.ExecuteDataTable("sp_GetLicenseByPersonID", map);
        }
        public static int? AddLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate,string Notes, 
            decimal PaidFees, bool IsActive, int IssueReason,
            int CreatedByUserID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@DriverID", DriverID);
            map?.Add("@LicenseClass", LicenseClass);
            map?.Add("@IssueDate", IssueDate);
            map?.Add("@ExpirationDate", ExpirationDate);
            map?.Add("@Notes", Notes);
            map?.Add("@PaidFees", PaidFees);
            map?.Add("@IsActive", IsActive);
            map?.Add("@IssueReason", IssueReason);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);

            object ID= DBManager.ExecuteScalar("sp_AddLicense", map);
            return ID.ToNullableInt();
        }
        public static bool UpdateLicenseByID(int LicenseID, int ApplicationID,
            int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate
            , string Notes, decimal PaidFees, bool IsActive, int IssueReason,
            int CreatedByUserID,int LoggedUserID)
        { 
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@DriverID", DriverID);
            map?.Add("@LicenseClass", LicenseClass);
            map?.Add("@IssueDate", IssueDate);
            map?.Add("@ExpirationDate", ExpirationDate);
            map?.Add("@Notes", Notes);
            map?.Add("@PaidFees", PaidFees);
            map?.Add("@IsActive", IsActive);
            map?.Add("@IssueReason", IssueReason);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateLicenseByID", map);
        }
        public static bool DeleteByID(int LicenseID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            map?.Add("@LoggedUserID", LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeleteLicenseByID", map);
        }

        public static DataTable GetByLicenseID(int LicenseID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            return DBManager.ExecuteDataTable("sp_GetLicenseByLicenseID", map);
        }
        public static bool ActivateLicenseByID(int LicenseID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_ActivateLicenseByID", map);
            
        }
        
        public static bool DeactivateLicenseByID(int LicenseID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeactivateLicenseByID", map);

        }
        
        public static int? GetActiveLicenseIDByPersonIDPerLicenseClass(int PersonID,int LicenseClassID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            map?.Add("@LicenseClassID", LicenseClassID);
             

            int? ID = DBManager.ExecuteScalar("sp_GetActiveLicenseIDByPersonIDPerLicenseClass", map) as Nullable<int>;
            return ID.ToNullableInt();

        }

        public static int? RenewOrReplaceOldLicense(int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate,
            decimal ApplicationPaidFees, int CreatedByUserID, DateTime LicenseExpirationDate,
            string LicenseNotes, decimal LicensePaidFees, int DriverID, int LicenseClass,int IssueReason,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicantPersonID", ApplicantPersonID);
            map?.Add("@ApplicationDate", ApplicationDate);
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            map?.Add("@ApplicationStatus", ApplicationStatus);
            map?.Add("@LastStatusDate", LastStatusDate);
            map?.Add("@ApplicationPaidFees", ApplicationPaidFees);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@LicenseExpirationDate", LicenseExpirationDate);
            map?.Add("@LicenseNotes", LicenseNotes);
            map?.Add("@LicensePaidFees", LicensePaidFees);
            map?.Add("@DriverID", DriverID);
            map?.Add("@LicenseClass", LicenseClass);
            map?.Add("@IssueReason", LicenseClass);
            map?.AddLoggedUserID(LoggedUserID);
            object ID = DBManager.ExecuteScalar("sp_RenewOrReplaceOldLicense", map);
            return ID.ToNullableInt();
        }
        public static Boolean HasIssuedActiveInternationalLicense(int LicenseID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseID", LicenseID);
            object Result = DBManager.ExecuteScalar("sp_HasLicenseIssuedActiveInternationalLicense", map);
            return Result.ToBoolean();
        }










    }
}
