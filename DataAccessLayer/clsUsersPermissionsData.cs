using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUsersPermissionsData
    {
        public static clsDBManager DBManager=new clsDBManager();
        public static bool AddNewPermissions(long Permissions,string Access,int LoggedUserID)
        {
            Dictionary<string,Object>map = new Dictionary<string,Object>();
            map?.Add("@Permissions", Permissions);
            map?.Add("@Access", Access);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_AddNewPermissions", map).ToBoolean();
        }
        public static bool UpdatePermissionsByID(long Permissions
            , string Access,int LoggedUserID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@Permissions", Permissions);
            map?.Add("@Access", Access);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdatePermissionsByID", map).ToBoolean();
        }
        public static DataTable GetAllPermissions()
            => DBManager.ExecuteDataTable("sp_GetAllPermissions");

        public static DataTable GetPermissionsByID(long Permissions)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@Permissions", Permissions);
            return DBManager.ExecuteDataTable("sp_GetPermissionsByID", map);
        }
        public static DataTable GetPermissionsByAccessType(string Access)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@Access", Access);
            return DBManager.ExecuteDataTable("sp_GetPermissionsByAccessType", map);
        }
        public static Boolean DeleteByPermissionsNumber(long Permissions, int LoggedUserID)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map?.Add("@Permissions", Permissions);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeletePermissionsByID", map).ToBoolean();

        }
    }
}
