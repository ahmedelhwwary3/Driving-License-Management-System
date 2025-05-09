using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
 

namespace BusinessLayer
{
    public class clsUser
    {
        protected enum enMode { AddNew, Update };
        protected enMode Mode;
        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int? LoggedUserID { get; set; }

        //Admin    => Full Access Even On Users
        //Editor   => Can Do Full CRUD Operations (but not on Users)
        //Viewer   => can view every thing

        public string Permissions { get; set; }
        public clsUsersPermissions PermissionsData { get; set; }
        public clsUser()
        {
            this.Permissions =null;
            this.UserID = null;
            this.PersonID = null;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.LoggedUserID = null;
            this.PermissionsData=new clsUsersPermissions();
            Mode = enMode.AddNew;
        }
        protected clsUser(int? UserID, int? PersonID, string UserName,
            string Password, bool IsActive,string Permissions)
        {
            var GetPersonMethod = new Func<int?, clsPerson>(clsPerson.GetByID);
            var GetPermissionsMethod = new Func<long?, clsUsersPermissions>(clsUsersPermissions.GetByPermissionsNumber);
            this.Permissions = Permissions;
            this.PermissionsData= new clsUsersPermissions();
            this.LoggedUserID = null;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.LoggedUserID = LoggedUserID;           
            this.PersonInfo = GetPersonMethod.GetByNullableID(PersonID);
            this.PermissionsData = clsUsersPermissions.GetByAccessType(Permissions);
            Mode = enMode.Update;
        }

        private bool _UpdateUser()
        {
            if (this.UserID.HasValue && this.PersonID.HasValue
                &&this.LoggedUserID.HasValue&&!string.IsNullOrEmpty(this.Permissions))
            {
                return clsUserData.UpdateUser(
                    this.UserID.Value,
                    this.PersonID.Value,
                    this.UserName,
                    this.Password,
                    this.IsActive,
                    this.LoggedUserID.Value,
                    this.Permissions
                );
            }
            return false;
        }

        private bool _AddNewUser()
        {
            if ( this.PersonID.HasValue
                  && this.LoggedUserID.HasValue && !string.IsNullOrEmpty(this.Permissions))
            {
                this.UserID = clsUserData.AddNewUser(
                    this.PersonID.Value,
                    this.UserName,
                    this.Password,
                    this.IsActive,
                    this.LoggedUserID.Value,
                    this.Permissions
                );
            }
            return this.UserID != null;
        }

        public bool Save()
        {
            switch (Mode)
            {

                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            Mode = enMode.Update;
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

        public static clsUser GetByUserNameAndPassword(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return null;

            DataTable dt = clsUserData.GetByUserNameAndPassword(UserName, Password);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsUser
            (
                Permissions:row["Permissions"].ToString()??"",
                UserID: row["UserID"].ToNullableInt32(),
                UserName:row["UserName"].ToString() ?? string.Empty,
                Password: row["Password"].ToString() ?? string.Empty,
                IsActive: row["IsActive"].ToBoolean(),
                PersonID: row["PersonID"].ToNullableInt32()
            );
        }

        public static clsUser GetByID(int? UserID)
        {
            if (UserID <= 0||!UserID.HasValue)
                return null;

            DataTable dt = clsUserData.GetByUserID(UserID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsUser
            (
             Permissions:row["Permissions"].ToString()??"",
                UserID: row["UserID"].ToNullableInt32(),
                UserName: row["UserName"].ToString() ?? string.Empty,
                Password: row["Password"].ToString() ?? string.Empty,
                IsActive: row["IsActive"].ToBoolean(),
                PersonID: row["PersonID"].ToNullableInt32()
            );
        }

        public static bool IsExistedByID(int? UserID)
        {
            if (UserID <= 0||!UserID.HasValue)
                return false;

            return clsUserData.IsExistedByID(UserID.Value);
        }

        public static bool IsExistedByUserName(string UserName)
        {
            if (string.IsNullOrEmpty(UserName))
                return false;

            return clsUserData.IsExistedByUserName(UserName);
        }

        public static bool Delete(int? UserID,int? LoggedUserID)
        {
            if (UserID <= 0 || !UserID.HasValue)
                return false;

            return clsUserData.DeleteUser(UserID.Value, LoggedUserID.Value);
        }

        public static DataTable GetAllUsersList()
            => clsUserData.GetAllUsersList();
        public static clsUser GetByPersonID(int? PersonID)
        {
            if (PersonID <= 0 || !PersonID.HasValue)
                return null;

            DataTable dt = clsUserData.GetByPersonID(PersonID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsUser
            (
             Permissions: row["Permissions"].ToString()??"",
                UserID: row["UserID"].ToNullableInt32(),
                UserName: row["UserName"].ToString() ?? string.Empty,
                Password: row["Password"].ToString() ?? string.Empty,
                IsActive: row["IsActive"].ToBoolean(),
                PersonID: row["PersonID"].ToNullableInt32()
            );
        }
        public static bool RegisterLoginData(int? UserID, DateTime LoginDate)
            => UserID.HasValue ? clsUserData.RegisterLoginData(UserID.Value, LoginDate) : false;




    }
}

