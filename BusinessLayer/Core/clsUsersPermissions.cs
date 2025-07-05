using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System.Data;
namespace BusinessLayer.Core
{
    public class clsUsersPermissions:IComparable<clsUsersPermissions>
    {

        public byte? Permissions { get; set; }
        public string Access { get; set; }
        public int LoggedUserID { get; set; }
        public bool IsSystem {  get; set; }
        protected enum enMode
        {
            AddNew, Update
        }
        protected enMode _Mode = enMode.AddNew;
        public int CompareTo(clsUsersPermissions? other)
        {
            if(other == null) return 1;
            return this.Permissions.Value
                .CompareTo(other.Permissions.Value);
        }
        public clsUsersPermissions()
        {
            LoggedUserID = default;
            Permissions = null;
            Access = null;
            IsSystem = default;

            _Mode = enMode.AddNew;
        }
        protected clsUsersPermissions(byte? Permissions, string Access,bool IsSystem)
        {
            this.Permissions = Permissions;
            this.Access = Access;
            this.IsSystem = IsSystem;
            _Mode = enMode.Update;
        }


        private bool _UpdateUserPermissions()
        {
            if (!(Permissions.HasValue&& !string.IsNullOrEmpty(Access)))
                return false;

            return clsUsersPermissionsData.UpdatePermissionsByID(
                    Permissions.Value,
                    Access,
                    LoggedUserID,
                    IsSystem
                );
        }

        private bool _AddNewUserPermissions()
            =>clsUsersPermissionsData.AddNewPermissions(Permissions.Value, Access,LoggedUserID, IsSystem);

        public bool Save()
        {
            switch (_Mode)
            {

                case enMode.AddNew:
                    {
                        if (_AddNewUserPermissions())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateUserPermissions();
                    }
                default:
                    break;
            }
            return false;
        }
        public static bool DeleteByPermissionsNumber(byte Permissions, int LoggedUserID)
            => (clsUsersPermissionsData.DeleteByPermissionsNumber(Permissions,LoggedUserID));

        public static bool IsExistedByAccess(string Access)
            => clsUsersPermissionsData.IsExistedByAccess(Access);
        public static DataTable GetAllPermissions()
            => clsUsersPermissionsData.GetAllPermissions();
        public static SortedSet<clsUsersPermissions> GetAllPermissionsSet()
        {
            SortedSet<clsUsersPermissions>set= new SortedSet<clsUsersPermissions>();    
            DataTable dt = GetAllPermissions();
            string Access =string.Empty;
            byte? Permissions = 0;
            bool IsSystem = false;  
            foreach (DataRow p in dt.Rows)
            {
                Permissions= p["Permissions"].ToByte();
                Access= p["Access"].ToString() ?? string.Empty;
                set?.Add(new clsUsersPermissions(Permissions,Access,IsSystem));
            }
            return set;
        }
        public static clsUsersPermissions GetByPermissionsNumber(byte? Permissions)
        {
            if (!Permissions.HasValue)
                return null;
            DataTable dt = clsUsersPermissionsData.GetPermissionsByID(Permissions.Value);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new clsUsersPermissions(
                   Permissions: row["Permissions"].ToByte(),
                   Access: row["Access"].ToString() ?? string.Empty,
                   IsSystem: row["IsSystem"].ToBoolean()
                   );
            }
            return null;
        }
        public static clsUsersPermissions GetByAccessType(string Access)
        {
            if (string.IsNullOrEmpty(Access))
                return null;
            DataTable dt = clsUsersPermissionsData.GetPermissionsByAccessType(Access);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new clsUsersPermissions(
                   Permissions: row["Permissions"].ToByte(),
                   Access: row["Access"].ToString() ?? string.Empty,
                   IsSystem: row["IsSystem"].ToBoolean()
                   );
            }
            return null;
        }
        public static byte? GetLastPermissionsNumberBeforeAdmin()
            => clsUsersPermissionsData.GetLastPermissionsNumberBeforeAdmin();
        public static byte GetPermissions(string Access) 
            => GetByAccessType(Access).Permissions.Value;

        
    }
}
