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
    public static class clsDriverData
    {


        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllDriversList()
        {
     
            return DBManager.ExecuteDataTable("sp_GetAllDriversData");
        }
        public static bool IsExistByID(int DriverID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            object Result = DBManager.ExecuteScalar("sp_IsDriverExistByID", map);
            return Result.ToBoolean();
        }


        public static bool IsPersonDriver(int PersonID)
        {
             
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            object Result = DBManager.ExecuteScalar("sp_IsPersonDriver", map);
            return Result.ToBoolean();
        }

        public static int? AddDriver(int PersonID, int CreatedByUserID,
            DateTime CreatedDate,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@CreatedDate", CreatedDate);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddDriver", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateDriverByID(int DriverID, int PersonID,
            int CreatedByUserID, DateTime CreatedDate,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            map?.Add("@PersonID", PersonID);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@CreatedDate", CreatedDate);
            map?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdateDriverByID", map);
        }

        public static bool DeleteByID(int DriverID,int LoggedUserID)
        {
            

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            map?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeleteDriverByID", map);
        }

        public static DataTable GetByPersonID(int PersonID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            return DBManager.ExecuteDataTable("sp_GetDriverByPersonID", map);
        }

        public static DataTable GetByID(int DriverID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            return DBManager.ExecuteDataTable("sp_GetDriverByDriverID", map);
        }

        public static DataTable GetAllDriverLocalLicenses(int DriverID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            return DBManager.ExecuteDataTable("sp_GetDriverLocalLicensesData", map);
        }

        public static DataTable GetAllInternationalLicensesData(int DriverID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@DriverID", DriverID);
            return DBManager.ExecuteDataTable("sp_GetDriverInternationalLicensesData", map);
        }











    }


}



