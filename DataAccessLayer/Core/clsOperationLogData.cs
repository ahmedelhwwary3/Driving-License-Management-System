using DataAccessLayer.Helpers;
using DataAccessLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Core
{
    public class clsOperationLogData
    {
        static readonly clsDBManager DBManager = new clsDBManager();

        public static DataTable GetAllUsersLogs()
            => DBManager?.ExecuteDataTable("sp_GetAllLogs");

        public static DataTable GetLogByID(int LogID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LogID", LogID);
            return DBManager?.ExecuteDataTable("sp_GetLogByID", parameters);
        }

        public static DataTable GetLogByLoggedUserID(int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteDataTable("sp_GetLogByLoggedUserID", parameters);
        }

        public static bool DeleteLogByID(int LogID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@LogID", LogID);
            return DBManager.ExecuteNonQuery("sp_DeleteLogByID", parameters);
        }
    }
}
