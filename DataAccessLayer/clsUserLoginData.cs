using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUserIDLayer
{
    public class clsUserLoginData
    {
        public static clsDBManager DBManager = new clsDBManager();
        
        public static DataTable GetAllUsersLogins()
            => DBManager.ExecuteDataTable("sp_GetAllUsersLogins");

        public static DataTable GetLoginByID(int LoginID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@LoginID", LoginID);
            return DBManager.ExecuteDataTable("sp_GetLoginByID", map);
        }
        public static DataTable GetLoginByUserID(int UserID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@UserID", UserID);
            return DBManager.ExecuteDataTable("sp_GetLoginByUserID", map);
        }
        public static Boolean DeleteLoginByID(int LoginID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@LoginID", LoginID);
            return DBManager.ExecuteNonQuery("sp_DeleteLoginByID", map).ToBoolean();

        }
    }
}
