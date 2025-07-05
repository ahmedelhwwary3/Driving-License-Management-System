using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Data;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Core
{
    public class clsOperationLog
    {
        public int? LogID { get; set; }
        public int LoggedUserID { get; set; }
        public string Action { get; set; }
        public DateTime CreateDate { get; set; }
        public string TableName { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }

        protected enum enMode { AddNew, Update }
        protected enMode _Mode = enMode.AddNew;

        public clsOperationLog()
        {
            LogID = null;
            LoggedUserID = default;
            Action = string.Empty;
            CreateDate = default;
            TableName = string.Empty;
            OldValues = string.Empty;
            NewValues = string.Empty;

            _Mode = enMode.AddNew;
        }

        protected clsOperationLog(int? logID, int loggedUserID, string action,
            DateTime createDate, string tableName, string oldValues, string newValues)
        {
            LogID = logID;
            LoggedUserID = loggedUserID;
            Action = action;
            CreateDate = createDate;
            TableName = tableName;
            OldValues = oldValues;
            NewValues = newValues;

            _Mode = enMode.Update;
        }

        public override string ToString()
        {
            string newVals = string.IsNullOrEmpty(NewValues) ? "N/A" : NewValues;
            string oldVals = string.IsNullOrEmpty(OldValues) ? "N/A" : OldValues;

            return $"Log ID:{LogID}\nLogged User ID:{LoggedUserID}\nAction:{Action}" +
                   $"\nCreateDate:{CreateDate}\nTableName:{TableName}\nOldValues:{oldVals}" +
                   $"\nNewValues:{newVals}";
        }

        public static bool DeleteByOperationLogNumber(int logID)
            => clsOperationLogData.DeleteLogByID(logID);

        public static DataTable GetAllOperationLogs()
            => clsOperationLogData.GetAllUsersLogs();

        public static clsOperationLog GetByLogID(int? logID)
        {
            if (!logID.HasValue)
                return null;
            DataTable dt = clsOperationLogData.GetLogByID(logID.Value);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            return new clsOperationLog(
                logID: row["LogID"].ToInt32(),
                loggedUserID: row["LoggedUserID"].ToInt32(),
                action: row["Action"].ToString() ?? "",
                createDate: row["CreateDate"].ToDate(),
                tableName: row["TableName"].ToString() ?? "",
                oldValues: row["OldValues"].ToString() ?? "",
                newValues: row["NewValues"].ToString() ?? ""
            );
        }

        public static clsOperationLog GetByAccessType(int? loggedUserID)
        {
            if (!loggedUserID.HasValue)
                return null;
            DataTable dt = clsOperationLogData.GetLogByLoggedUserID(loggedUserID.Value);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            return new clsOperationLog(
                logID: row["LogID"].ToInt32(),
                loggedUserID: row["LoggedUserID"].ToInt32(),
                action: row["Action"].ToString() ?? string.Empty,
                createDate: row["CreateDate"].ToDate(),
                tableName: row["TableName"].ToString() ?? string.Empty,
                oldValues: row["OldValues"].ToString() ?? string.Empty,
                newValues: row["NewValues"].ToString() ?? string.Empty
            );
        }

        public static async Task<clsOperationLog> ConvertDataRowToObjectAsync(DataRow row)
        {
            if (row == null)
                return null;

            return new clsOperationLog(
                logID: row["LogID"].ToInt32(),
                loggedUserID: row["LoggedUserID"].ToInt32(),
                action: row["Action"].ToString() ?? string.Empty,
                createDate: row["CreateDate"].ToDate(),
                tableName: row["TableName"].ToString() ?? string.Empty,
                oldValues: row["OldValues"].ToString() ?? string.Empty,
                newValues: row["NewValues"].ToString() ?? string.Empty
            );
        }
    }
}
