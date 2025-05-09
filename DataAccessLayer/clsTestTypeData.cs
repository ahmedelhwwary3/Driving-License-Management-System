using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class clsTestTypeData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllTestTypesList()
        {
            return DBManager.ExecuteDataTable("sp_GetAllTestTypes");

        }

        public static bool IsExistByID(int TestTypeID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeID", TestTypeID);
            object Result = DBManager.ExecuteScalar("sp_IsTestTypeExistedByID", map);
            return Result.ToBoolean();
        }

        public static bool IsExistedByTitle(string TestTypeTitle)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeTitle", TestTypeTitle);
            object Result = DBManager.ExecuteScalar("sp_IsTestTypeExistedByTitle", map);
            return Result.ToBoolean();
        }

        public static DataTable GetByID(int TestTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeID", TestTypeID);

            return DBManager.ExecuteDataTable("sp_GetTestTypeByID", map);
        }

        public static int? AddTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeTitle", TestTypeTitle);
            map?.Add("@TestTypeDescription", TestTypeDescription);
            map?.Add("@TestTypeFees", TestTypeFees);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddTestType", map);
            return ID.ToNullableInt();
        }
        public static bool UpdateTestTypeByID(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeID", TestTypeID);
            map?.Add("@TestTypeTitle", TestTypeTitle);
            map?.Add("@TestTypeDescription", TestTypeDescription);
            map?.Add("@TestTypeFees", TestTypeFees);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateTestTypeByID", map);
        }
    }
}
