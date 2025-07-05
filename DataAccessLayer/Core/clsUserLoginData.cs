using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsUserLoginData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllUsersLogins()
            => DBManager.ExecuteDataTable("sp_GetAllUsersLogins");

        public static DataTable GetLoginByID(int LoginID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@LoginID", LoginID);

            return DBManager.ExecuteDataTable("sp_GetLoginByID", parameters);
        }

        public static DataTable GetLoginByUserID(int UserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@UserID", UserID);

            return DBManager.ExecuteDataTable("sp_GetLoginByUserID", parameters);
        }

        public static bool DeleteLoginByID(int LoginID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@LoginID", LoginID);

            return DBManager.ExecuteNonQuery("sp_DeleteLoginByID", parameters);
        }
    }
}
