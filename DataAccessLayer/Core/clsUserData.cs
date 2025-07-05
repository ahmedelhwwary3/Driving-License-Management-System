using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsUserData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllUsersList()
            => DBManager?.ExecuteDataTable("sp_GetAllUsersFullData");

        public static DataTable SendEmailToAllPeopleOrAllUsers(bool AllPeopleOrUsersOnly, string Message)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@AllPeopleOrUsersOnly", AllPeopleOrUsersOnly);
            parameters?.AddSQLParameter("@Message", Message);
            return DBManager?.ExecuteDataTable("sp_SendMail", parameters);
        }
        public static string GetUserFullHierarchyByUserID(int UserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserID", UserID);
            var obj = DBManager?.ExecuteScalar("sp_GetUserFullHierarchyByUserID", parameters);
            return obj.ToString()??"";
        }
        public static int RefreshAllApplicantsRisk()
        {
            object totalCount = DBManager?.ExecuteScalar("sp_RefreshAllApplicantsRisk");
            return Convert.ToInt32(totalCount);
        }

        public static bool IsExistedByID(int UserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserID", UserID);
            object result = DBManager?.ExecuteScalar("sp_IsUserExistedByID", parameters);
            return result.ToBoolean();
        }

        public static bool IsExistedByUserName(string UserName)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserName", UserName);
            object result = DBManager?.ExecuteScalar("sp_IsUserExistedByUserName", parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByUserID(int UserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserID", UserID);
            return DBManager?.ExecuteDataTable("sp_GetUserByID", parameters);
        }

        public static DataTable GetByUserNameAndPassword(string UserName, string Password)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserName", UserName);
            parameters?.AddSQLParameter("@Password", Password);
            return DBManager?.ExecuteDataTable("sp_GetUserByUserNameAndPassword", parameters);
        }

        public static int? AddNewUser(int PersonID, string UserName, string Password, bool IsActive, int LoggedUserID, byte Permissions, int HierarchyID, int? ManagerID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@PersonID", PersonID);
            parameters?.AddSQLParameter("@UserName", UserName);
            parameters?.AddSQLParameter("@Password", Password);
            parameters?.AddSQLParameter("@IsActive", IsActive);
            parameters?.AddSQLParameter("@Permissions", Permissions);
            parameters?.AddSQLParameter("@HierarchyID", HierarchyID);
            parameters?.AddSQLParameter("@ManagerID", ManagerID.HasValue ? (object)ManagerID : DBNull.Value);
            parameters?.AddLoggedUserID(LoggedUserID);

            object id = DBManager?.ExecuteScalar("sp_AddNewUser", parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive, int LoggedUserID, byte Permissions, int HierarchyID, int? ManagerID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserID", UserID);
            parameters?.AddSQLParameter("@PersonID", PersonID);
            parameters?.AddSQLParameter("@UserName", UserName);
            parameters?.AddSQLParameter("@Password", Password);
            parameters?.AddSQLParameter("@IsActive", IsActive);
            parameters?.AddSQLParameter("@Permissions", Permissions);
            parameters?.AddSQLParameter("@HierarchyID", HierarchyID);
            parameters?.AddSQLParameter("@ManagerID", ManagerID.HasValue ? (object)ManagerID : DBNull.Value);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateUserByID", parameters) ?? false;
        }

        public static bool DeleteUser(int UserID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@UserID", UserID);
            parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeleteUserByID", parameters) ;
        }

        public static DataTable GetByPersonID(int PersonID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@PersonID", PersonID);
            return DBManager?.ExecuteDataTable("sp_GetUserByPersonID", parameters);
        }

        public static bool RegisterLoginData(int UserID, DateTime LoginDate)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LoginDate", LoginDate);
            parameters?.AddSQLParameter("@UserID", UserID);
            return DBManager.ExecuteNonQuery("sp_RegisterUserLogin", parameters) ;
        }
    }
}
