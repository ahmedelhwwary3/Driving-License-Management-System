using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Core
{
    [Description("Any Information of the user logins.")]
    public class clsUserLogin
    {

        public int? LoginID { get; set; }
        public int UserID { get; set; }
        clsUser User { get; set; }
        public DateTime LoginDate { get; set; }
        protected enum enMode
        {
            AddNew, Update
        }
        protected enMode _Mode = enMode.AddNew;
        public clsUserLogin()
        {
            LoginDate = default;
            LoginID = null;
            UserID = default;
            User = new clsUser();

            _Mode = enMode.AddNew;
        }
        protected clsUserLogin(int LoginID, int UserID, DateTime LoginDate)
        {
            this.LoginDate = LoginDate;
            this.LoginID = LoginID;
            this.UserID = UserID;
            User = clsUser.GetByID(UserID);
            _Mode = enMode.Update;
        }



        public static bool DeleteByPermissionsNumber(int LoginID)
            => clsUserLoginData.DeleteLoginByID(LoginID);
        public static DataTable GetAllUsersLogins()
            => clsUserLoginData.GetAllUsersLogins();
        public static clsUserLogin GetByPermissionsNumber(int? LoginID)
        {
            if (!LoginID.HasValue)
                return null;
            DataTable dt = clsUserLoginData.GetLoginByID(LoginID.Value);
            DataRow row = dt.Rows[0];
            if (dt.Rows.Count > 0)
                return new clsUserLogin(
                    LoginID: row["LoginID"].ToInt32(),
                    UserID: row["UserID"].ToInt32(),
                    LoginDate: row["LoginDate"].ToDate()
                    );
            return null;
        }

    }
}
