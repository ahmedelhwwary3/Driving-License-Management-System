using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsOperationLogData
    {
        public static clsDBManager DBManager = new clsDBManager();
       
        
        public static DataTable GetAllUsersLogs()
            => DBManager.ExecuteDataTable("sp_GetAllLogs");

        public static DataTable GetLogByID(int  LogID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@LogID", LogID);
            return DBManager.ExecuteDataTable("sp_GetLogByID", map);
        }
        public static DataTable GetLogByLoggedUserID(int LoggedUserID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@LoggedUserID", LoggedUserID);
            return DBManager.ExecuteDataTable("sp_GetLogByLoggedUserID", map);
        }
        public static Boolean DeleteLogByID(int LogID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@LogID", LogID);
            return DBManager.ExecuteNonQuery("sp_DeleteLogByID", map).ToBoolean();

        }
    }
}
