using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace DataAccessLayer
{
    public static class clsInternationalLicenseData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetInternationalLicenseDataByID(int InternationalLicenseID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@InternationalLicenseID", InternationalLicenseID);

            return DBManager.ExecuteDataTable("sp_GetInternationalLicenseDataByID", map);
        }

        public static DataTable GetAllInternationalLicensesList()
        {
            

            return DBManager.ExecuteDataTable("sp_GetAllInternationalLicensesData");
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);

            return DBManager.ExecuteDataTable("sp_GetInternationalLicenseDataByDriverID", map);
        }

        public static int? AddInternationalLicense(int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive,
             int CreatedByUserID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@DriverID", DriverID);
            map?.Add("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            map?.Add("@IssueDate", IssueDate);
            map?.Add("@ExpirationDate", ExpirationDate);
            map?.Add("@IsActive", IsActive);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);

            object ID = DBManager.ExecuteScalar("sp_AddInternationalLicense", map);
            return ID.ToNullableInt();
        }
        public static int? GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
          

            int? Result = DBManager.ExecuteScalar("sp_GetActiveInternationalLicenseIDByDriverID", map) as Nullable<int>;
            return Result.ToNullableInt();
        }
        public static bool UpdateInternationalLicenseByID(
              int InternationalLicenseID, int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive,
             int CreatedByUserID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@InternationalLicenseID", InternationalLicenseID);
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@DriverID", DriverID);
            map?.Add("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            map?.Add("@IssueDate", IssueDate);
            map?.Add("@ExpirationDate", ExpirationDate);
            map?.Add("@IsActive", IsActive);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateInternationalLicenseByID", map);
        }
    }
}
