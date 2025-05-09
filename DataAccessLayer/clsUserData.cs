using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class clsUserData
    {
        static clsDBManager DBManager=clsDataAccessSettings.DBManager;
        public static DataTable GetAllUsersList()
        {
            return DBManager.ExecuteDataTable("sp_GetAllUsersFullData");
        }

        public static bool IsExistedByID(int UserID)
        {
            

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserID", UserID);
            object Result = DBManager.ExecuteScalar("sp_IsUserExistedByID", map);
            return Result.ToBoolean();
        }

        public static bool IsExistedByUserName(string UserName)
        {
     
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserName", UserName);
            object Result = DBManager.ExecuteScalar("sp_IsUserExistedByUserName", map);
            return Result.ToBoolean();
        }

        public static DataTable GetByUserID(int UserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserID", UserID);

            return DBManager.ExecuteDataTable("sp_GetUserByID", map);
        }

        public static DataTable GetByUserNameAndPassword(string UserName,string Password)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserName", UserName);
            map?.Add("@Password", Password);
            return DBManager.ExecuteDataTable("sp_GetUserByUserNameAndPassword", map);
        }
        public static int? AddNewUser(int PersonID, string UserName, string Password, 
            bool IsActive,int LoggedUserID,string Permissions)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            map?.Add("@UserName", UserName);
            map?.Add("@Password", Password);
            map?.Add("@IsActive", IsActive);
            map?.Add("@Permissions", Permissions);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddNewUser", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName,
            string Password, bool IsActive,int LoggedUserID,string Permissions)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserID", UserID);
            map?.Add("@PersonID", PersonID);
            map?.Add("@UserName", UserName);
            map?.Add("@Password", Password);
            map?.Add("@IsActive", IsActive);
            map?.Add("@Permissions", Permissions);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateUserByID", map);
        }

        public static bool DeleteUser(int UserID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@UserID", UserID);
            map?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeleteUserByID", map);
        }

        public static DataTable GetByPersonID( int PersonID)
        {
            

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);

            return DBManager.ExecuteDataTable("sp_GetUserByPersonID", map);
        }
        public static bool RegisterLoginData(int UserID,DateTime LoginDate)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LoginDate", LoginDate);
            map?.Add("@UserID", UserID);
            return DBManager.ExecuteNonQuery("sp_RegisterUserLogin", map);
        }
    }
}
