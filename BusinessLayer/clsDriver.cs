using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using DataAccessLayer;
namespace BusinessLayer
{
    public class clsDriver
    {
        public int? DriverID { get; set; }
        public clsDriver Driver { get; set; }
        public int? PersonID { get; set; }
        public clsPerson Person { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LoggedUserID { get; set; }




        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public clsDriver()
        {
            this.DriverID = null;
            this.PersonID = null;
            this.Person=new clsPerson();
            this.CreatedDate = DateTime.Now;
            this.CreatedByUser = new clsUser();
            this.CreatedByUserID = null;
            this.LoggedUserID = null;
            Mode = enMode.AddNew;
        }
        private clsDriver(int? DriverID, int? PersonID, int? CreatedByUserID, DateTime CreatedDate)
        {
            var getPerson = new Func<int?, clsPerson>(clsPerson.GetByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);

            this.LoggedUserID = null;
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.Person = getPerson.GetByNullableID(PersonID);
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = getUser.GetByNullableID(CreatedByUserID);

            Mode = enMode.Update;
        }
        private bool _AddNewDriver()
        {
            if (this.PersonID.HasValue && this.CreatedByUserID.HasValue
                &&this.LoggedUserID.HasValue)
            {
                this.DriverID = clsDriverData.AddDriver(
                    this.PersonID.Value,
                    this.CreatedByUserID.Value,
                    this.CreatedDate,
                    this.LoggedUserID.Value
                );
            }
            return this.DriverID != null;
        }

        private bool _UpdateDriver()
        {
            if (this.DriverID.HasValue &&this.LoggedUserID.HasValue&&
                this.PersonID.HasValue && this.CreatedByUserID.HasValue)
            {
                return clsDriverData.UpdateDriverByID(
                    this.DriverID.Value,
                    this.PersonID.Value,
                    this.CreatedByUserID.Value,
                    this.CreatedDate,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDriver())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateDriver();
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool IsExist(int? DriverID)
    => DriverID.HasValue && clsDriverData.IsExistByID(DriverID.Value);

        public static bool IsDriver(int? PersonID)
            => PersonID.HasValue && clsDriverData.IsPersonDriver(PersonID.Value);

        public static clsDriver GetByDriverID(int? DriverID)
        {
            if (!DriverID.HasValue) return null;

            DataTable dt = clsDriverData.GetByID(DriverID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsDriver(
                DriverID: row["DriverID"].ToNullableInt32(),
                PersonID: row["PersonID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                CreatedDate: row["CreatedDate"] .ToDate()
            );
        }

        public static DataTable GetAllDriversList()
            => clsDriverData.GetAllDriversList();

        public static bool DeleteByID(int? DriverID,int? LoggedUserID)
        {
            if (!DriverID.HasValue) return false;
            return clsDriverData.DeleteByID(DriverID.Value, LoggedUserID.Value);
        }

        public static clsDriver GetByPersonID(int? PersonID)
        {
            if (!PersonID.HasValue) return null;

            DataTable dt = clsDriverData.GetByPersonID(PersonID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsDriver(
                DriverID: row["DriverID"].ToNullableInt32(),
                PersonID: row["PersonID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                CreatedDate: row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now
            );
        }

        public static DataTable GetAllLocalLicenses(int? DriverID)
        {
            if (!DriverID.HasValue) return null;
            return clsDriverData.GetAllDriverLocalLicenses(DriverID.Value);
        }

        public static DataTable GetAllInternationalLicenses(int? DriverID)
        {
            if (!DriverID.HasValue) return null;
            return clsDriverData.GetAllInternationalLicensesData(DriverID.Value);
        }







    }
}
