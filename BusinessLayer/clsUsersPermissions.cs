using DataAccessLayer;
using System.Data;
namespace BusinessLayer
{
    public  class clsUsersPermissions
    {

        public long? Permissions {  get; set; }
        public string Access {  get; set; }
        public int? LoggedUserID { get; set; }
        protected enum enMode
        {
            AddNew,Update
        }
        protected enMode _Mode = enMode.AddNew;
        public clsUsersPermissions()
        {
            this.LoggedUserID = null;
            this.Permissions = null;
            this.Access = null;

            _Mode = enMode.AddNew;
        }
        protected clsUsersPermissions(long? Permissions,string Access)
        {
            this.LoggedUserID = null;
            this.Permissions=Permissions;
            this.Access=Access;

            _Mode = enMode.Update;
        }
         

        private bool _UpdateUser()
        {
            if (this.LoggedUserID.HasValue && this.Permissions.HasValue
                && !string.IsNullOrEmpty(this.Access))
            {
                return clsUsersPermissionsData.UpdatePermissionsByID(
                    this.Permissions.Value,
                    this.Access,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }

        private bool _AddNewUser()
        {
            if (this.LoggedUserID.HasValue && this.Permissions.HasValue
                  && !string.IsNullOrEmpty(this.Access))
            {
                return clsUsersPermissionsData.
                      AddNewPermissions(this.Permissions.Value, this.Access,
                      this.LoggedUserID.Value
                      );
            }
            return false;
        }

        public bool Save()
        {
            switch (_Mode)
            {

                case enMode.AddNew:
                    {
                        if (_AddNewUser())
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
                        return _UpdateUser();
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool DeleteByPermissionsNumber(long? Permissions
            , int? LoggedUserID)
            => Permissions.HasValue && LoggedUserID.HasValue && 
            clsUsersPermissionsData.DeleteByPermissionsNumber(Permissions.Value,LoggedUserID.Value);
        public static DataTable GetAllPermissions()
            =>clsUsersPermissionsData.GetAllPermissions();
        public static clsUsersPermissions GetByPermissionsNumber(long? Permissions)
        {
            if (!Permissions.HasValue)
                return null;
            DataTable dt= clsUsersPermissionsData.GetPermissionsByID(Permissions.Value);
            DataRow row = dt.Rows[0];
            if(dt.Rows.Count > 0)
                return new clsUsersPermissions(
                    Permissions: row["Permissions"].ToNullableInt64(),
                    Access: row["Access"].ToString()??""
                    );
            return null;
        }
        public static clsUsersPermissions GetByAccessType(string Access)
        {
            if (string.IsNullOrEmpty(Access))
                return null;
            DataTable dt = clsUsersPermissionsData.GetPermissionsByAccessType(Access);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count > 0)
                return new clsUsersPermissions(
                    Permissions:row["Permissions"].ToNullableInt64(),
                    Access: row["Access"].ToString() ?? ""
                    );
            return null;
        }





    }
}
