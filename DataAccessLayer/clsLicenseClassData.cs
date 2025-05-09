using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace DataAccessLayer
{
    public static class clsLicenseClassData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllLicenseClassesList()
        {


            return DBManager.ExecuteDataTable("sp_GetAllLicenseClassesData");
        }

        public static bool IsExistByID(int LicenseClassID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseClassID", LicenseClassID);
            object Result = DBManager.ExecuteScalar("sp_IsLicenseClassExistedByID", map);
            return Result.ToBoolean();

        }

        public static DataTable GetByName(string ClassName)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ClassName", ClassName);

            return DBManager.ExecuteDataTable("sp_GetLicenseClassDataByName", map);
        }

        public static DataTable GetByID(int LicenseClassID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseClassID", LicenseClassID);

            return DBManager.ExecuteDataTable("sp_GetLicenseClassDataByID", map);
        }

        public static int? AddLicenseClass(string ClassName, string ClassDescription, 
            int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ClassName", ClassName);
            map?.Add("@ClassDescription", ClassDescription);
            map?.Add("@MinimumAllowedAge", MinimumAllowedAge);
            map?.Add("@DefaultValidityLength", DefaultValidityLength);
            map?.Add("@ClassFees", ClassFees);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddLicenseClass", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string 
            ClassDescription, int MinimumAllowedAge, int DefaultValidityLength,
            decimal ClassFees, int LoggedUserID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ClassName", ClassName);
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.Add("@ClassDescription", ClassDescription);
            map?.Add("@MinimumAllowedAge", MinimumAllowedAge);
            map?.Add("@DefaultValidityLength", DefaultValidityLength);
            map?.Add("@ClassFees", ClassFees);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateLicenseClassByID", map);
        }

        public static bool DeleteLicenseClass(int LicenseClassID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeleteLicenseClassByID", map);
        }
    }
}
