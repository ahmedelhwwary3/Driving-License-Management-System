using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    public class clsUser : IComparable<clsUser>
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public int? UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(300)]
        public string Password { get; set; }

        public bool IsActive { get; set; }
        public byte Permissions { get; set; }

        public int LoggedUserID { get; set; }
        public int HierarchyID { get; set; }
        public int? ManagerID { get; set; }

        public string PermissionsAccess
        {
            get
            {
                byte adminCode = clsUsersPermissions.GetByAccessType("Admin").Permissions.Value;
                if (Permissions == adminCode)
                    return "Admin";

                var accessList = new List<string>();
                foreach (var p in clsUsersPermissions.GetAllPermissionsSet())
                {
                    if ((Permissions & p.Permissions) ==p.Permissions && !accessList.Contains(p.Access))
                        accessList.Add(p.Access);
                }
                return string.Join(" , ", accessList);
            }
        }

      

        public int CompareTo(clsUser? other)
        {
            if (other == null) return 1;
            return Permissions.CompareTo(other.Permissions);
        }

        public clsUser()
        {
            UserID = null;
            PersonID = default;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            Permissions = default;
            LoggedUserID = default;
            HierarchyID = default;
            ManagerID = default;

            Mode = enMode.AddNew;
        }

        protected clsUser(int? userID, int personID, string userName,
            string password, bool isActive, byte permissions,
            int hierarchyID, int? managerID)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Permissions = permissions;
            LoggedUserID = default;
            PersonInfo = clsPerson.GetByID(personID);
            HierarchyID = hierarchyID;
            ManagerID = managerID;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            UserID = clsUserData.AddNewUser(
                PersonID,
                UserName,
                Password,
                IsActive,
                LoggedUserID,
                Permissions,
                HierarchyID,
                ManagerID
            );

            return UserID != null;
        }

        private bool _UpdateUser()
        {
            if (!UserID.HasValue)
                return false;

            return clsUserData.UpdateUser(
                UserID.Value,
                PersonID,
                UserName,
                Password,
                IsActive,
                LoggedUserID,
                Permissions,
                HierarchyID,
                ManagerID
            );
        }


        public bool Save()
        {
            if (Mode == enMode.AddNew)
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
            else if (Mode == enMode.Update)
            {
                return _UpdateUser();
            }

            return false;
        }


        public static clsUser GetByID(int? userID)
        {
            if (!userID.HasValue)
                return null;
            DataTable dt = clsUserData.GetByUserID(userID.Value);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            return new clsUser(
                   userID: row["UserID"].ToInt32(),
                   personID: row["PersonID"].ToInt32(),
                   userName: row["UserName"].ToString()??string.Empty,
                   password: row["Password"].ToString() ?? string.Empty,
                   isActive: row["IsActive"].ToBoolean(),
                   permissions: row["Permissions"].ToByte(),
                   hierarchyID: row["HierarchyID"].ToInt32(),
                   managerID: row["ManagerID"].ToNullableInt32()
               );
        }

        public static clsUser GetByPersonID(int? personID)
        {
            if (!personID.HasValue || personID <= 0)
                return null;

            DataTable dt = clsUserData.GetByPersonID(personID.Value);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            return new clsUser(
              userID: row["UserID"].ToInt32(),
              personID: row["PersonID"].ToInt32(),
              userName: row["UserName"].ToString() ?? string.Empty,
              password: row["Password"].ToString() ?? string.Empty,
              isActive: row["IsActive"].ToBoolean(),
              permissions: row["Permissions"].ToByte(),
              hierarchyID: row["HierarchyID"].ToInt32(),
              managerID: row["ManagerID"].ToNullableInt32()
          );
        }

        public static clsUser GetByUserNameAndPassword(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            DataTable dt = clsUserData.GetByUserNameAndPassword(userName, password);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return new clsUser(
             userID: row["UserID"].ToInt32(),
             personID: row["PersonID"].ToInt32(),
             userName: row["UserName"].ToString() ?? string.Empty,
             password: row["Password"].ToString() ?? string.Empty,
             isActive: row["IsActive"].ToBoolean(),
             permissions: row["Permissions"].ToByte(),
             hierarchyID: row["HierarchyID"].ToInt32(),
             managerID: row["ManagerID"].ToNullableInt32()
         );
        }

   
        public static bool IsExistedByID(int userID)
            => clsUserData.IsExistedByID(userID);

        public static bool IsExistedByUserName(string userName)
            => !string.IsNullOrEmpty(userName) && clsUserData.IsExistedByUserName(userName);

        public static bool Delete(int userID, int loggedUserID)
            => clsUserData.DeleteUser(userID, loggedUserID);

        public static DataTable GetAllUsersList()
            => clsUserData.GetAllUsersList();

        public static DataTable SendEmailToAllPeopleOrAllUsers(bool allPeopleOrUsersOnly, string message)
            => clsUserData.SendEmailToAllPeopleOrAllUsers(allPeopleOrUsersOnly, message);

        public static int RefreshHighRiskApplicants()
            => clsUserData.RefreshAllApplicantsRisk();

        public static bool RegisterLoginData(int userID, DateTime loginDate)
            => clsUserData.RegisterLoginData(userID, loginDate);
    }
}
