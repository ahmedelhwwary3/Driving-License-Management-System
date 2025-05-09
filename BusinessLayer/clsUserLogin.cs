using DataUserIDLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUserLogin
    {

        public int? LoginID { get; set; }
        public int? UserID { get; set; }
        clsUser User { get; set; }
        public DateTime? LoginDate { get; set; }
        protected enum enMode
        {
            AddNew, Update
        }
        protected enMode _Mode = enMode.AddNew;
        public clsUserLogin()
        {
            this.LoginDate = null;
            this.LoginID = null;
            this.UserID = null;
            this.User=new clsUser();
            _Mode = enMode.AddNew;
        }
        protected clsUserLogin(int? LoginID, int? UserID,DateTime? LoginDate)
        {
            this.LoginDate = LoginDate;
            this.LoginID = LoginID;
            this.UserID = UserID;
            this.User = new Func<int?, clsUser>(clsUser.GetByID).GetByNullableID(UserID);
            _Mode = enMode.Update;
        }


     
        
        

        public static bool DeleteByPermissionsNumber(int? LoginID)
            => LoginID.HasValue&&clsUserLoginData.DeleteLoginByID(LoginID.Value);
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
                    LoginID: row["LoginID"].ToNullableInt32(),
                    UserID: row["UserID"].ToNullableInt32(),
                    LoginDate: row["LoginDate"].ToDate()
                    );
            return null;
        }
         
    }
}
