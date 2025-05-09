using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsOperationLog
    {

        public int? LogID { get; set; }
        public int? LoggedUserID { get; set; }
        public string Action {  get; set; }
        DateTime? CreateDate {  get; set; }
        string TableName {  get; set; }
        string OldValues {  get; set; }
        public string NewValues { get; set; }

        protected enum enMode
        {
            AddNew, Update
        }
        protected enMode _Mode = enMode.AddNew;
        public clsOperationLog()
        {
          
            this.LogID = null;
            this.LoggedUserID = null;
            this.Action = null;
            this.CreateDate = null;
            this.TableName = null;
            this.OldValues = null;
            this.NewValues = null;

            _Mode = enMode.AddNew;
        }
        protected clsOperationLog(int? LogID,int? LoggedUserID,string Action
            ,DateTime? CreateDate,string TableName,string OldValues,string NewValues)
        {
            this.LoggedUserID = LoggedUserID;
            this.LogID = LogID;
            this.Action = Action;
            this.CreateDate = CreateDate;
            this.TableName = TableName;
            this.OldValues = OldValues;
            this.NewValues = NewValues;

            _Mode = enMode.Update;
        }


        public override string ToString()
        { string NewValues = string.IsNullOrEmpty(this.NewValues) ? "N/A" : this.NewValues;
          string OldValues = string.IsNullOrEmpty(this.OldValues) ? "N/A": this.OldValues;    
          return $"Log ID:{this.LogID}\nLogged User ID:{this.LoggedUserID}\nAction:{this.Action}" +
           $"\nCreateDate:{this.CreateDate}\nTableName:{this.TableName}\nOldValues:{OldValues}" +
           $"\nNewValues:{NewValues}";
        }



        public static bool DeleteByOperationLogNumber(int? LogID)
            => LogID.HasValue&&
            clsOperationLogData.DeleteLogByID(LogID.Value);
        public static DataTable GetAllOperationLogs()
            => clsOperationLogData.GetAllUsersLogs();
        public static clsOperationLog GetByLogID(int? LogID)
        {
            if (!LogID.HasValue)
                return null;
            DataTable dt = clsOperationLogData.GetLogByID(LogID.Value);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count > 0)
                return new clsOperationLog(
                    LoggedUserID: row["LoggedUserID"].ToNullableInt32(),
                    LogID: row["LogID"].ToNullableInt32(),
                    Action: row["Action"].ToString()??"",
                    CreateDate: row["CreateDate"].ToDate(),
                    TableName: row["TableName"].ToString()??"",
                    OldValues: row["OldValues"].ToString() ?? "",
                    NewValues: row["NewValues"].ToString() ?? ""
                    );
            return null;
        }
        public static clsOperationLog GetByAccessType(int? LoggedUserID)
        {
            if (LoggedUserID.HasValue)
                return null;
            DataTable dt = clsOperationLogData.GetLogByLoggedUserID(LoggedUserID.Value);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count > 0)
                return new clsOperationLog(
                    LoggedUserID: row["LoggedUserID"].ToNullableInt32(),
                    LogID: row["LogID"].ToNullableInt32(),
                    Action: row["Action"].ToString() ?? "",
                    CreateDate: row["CreateDate"].ToDate(),
                    TableName: row["TableName"].ToString() ?? "",
                    OldValues: row["OldValues"].ToString() ?? "",
                    NewValues: row["NewValues"].ToString() ?? ""
                    );
            return null;
        }
        public static clsOperationLog ConvertDataRowToObject(DataRow row)
        {
            if (row == null)
                return null;
            return new clsOperationLog(
                    LoggedUserID: row["LoggedUserID"].ToNullableInt32(),
                    LogID: row["LogID"].ToNullableInt32(),
                    Action: row["Action"].ToString() ?? "",
                    CreateDate: row["CreateDate"].ToDate(),
                    TableName: row["TableName"].ToString() ?? "",
                    OldValues: row["OldValues"].ToString() ?? "",
                    NewValues: row["NewValues"].ToString() ?? ""
                    );
        }
    }
}
