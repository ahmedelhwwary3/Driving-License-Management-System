using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Helpers;
using DataAccessLayer.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace DataAccessLayer.Core
{
    public static class clsUsersPermissionsData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static bool AddNewPermissions(byte Permissions, string Access, int LoggedUserID,bool IsSystem)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Permissions", Permissions);
            parameters.AddSQLParameter("@Access", Access);
            parameters.AddSQLParameter("@IsSystem", IsSystem);
            parameters.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_AddNewPermissions", parameters);
        }

        public static bool UpdatePermissionsByID(byte Permissions, string Access,
            int LoggedUserID, bool IsSystem)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Permissions", Permissions);
            parameters.AddSQLParameter("@Access", Access);
            parameters.AddSQLParameter("@IsSystem", IsSystem);
            parameters.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdatePermissionsByID", parameters);
        }

        public static bool UpdatePermissionsByAccess(string Access, byte Permissions,
            int LoggedUserID,bool IsSystem)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Permissions", Permissions);
            parameters.AddSQLParameter("@Access", Access);
            parameters.AddSQLParameter("@IsSystem", IsSystem);
            parameters.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdatePermissionsByAccess", parameters);
        }
        public static bool IsExistedByAccess(string Access)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@Access", Access);
            object result = DBManager?.ExecuteScalar("sp_IsPermissionsExistedByAccess", Parameters);
            return result.ToBoolean();
        }
        public static DataTable GetAllPermissions()
            => DBManager.ExecuteDataTable("sp_GetAllPermissions");

        public static DataTable GetPermissionsByID(byte Permissions)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Permissions", Permissions);

            return DBManager.ExecuteDataTable("sp_GetPermissionsByID", parameters);
        }

        public static DataTable GetPermissionsByAccessType(string Access)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Access", Access);

            return DBManager.ExecuteDataTable("sp_GetPermissionsByAccessType", parameters);
        }

        public static byte? GetLastPermissionsNumberBeforeAdmin()
        {
            object obj = DBManager.ExecuteScalar("sp_GetLastPermissionsNumberBeforeAdmin");
            return obj.ToNullableByte();
        }

        public static bool DeleteByPermissionsNumber(byte Permissions, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Permissions", Permissions);
            parameters.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeletePermissionsByNumber", parameters);
        }
    }
}
