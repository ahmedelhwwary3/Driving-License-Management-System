using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsDriver : IComparable<clsDriver>
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public int? DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson Person { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LoggedUserID { get; set; }

        public int PenaltyPoints { get; set; }

        public clsDriver()
        {
            DriverID = default;
            PersonID = default;
            Person = new clsPerson();
            CreatedByUserID = default;
            CreatedByUser = new clsUser();
            CreatedDate = DateTime.Now;
            LoggedUserID = default;
            PenaltyPoints = 0;

            Mode = enMode.AddNew;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID,
            DateTime CreatedDate, int PenaltyPoints)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            Person = clsPerson.GetByID(PersonID);

            this.CreatedByUserID = CreatedByUserID;
            CreatedByUser = clsUser.GetByID(CreatedByUserID);

            this.CreatedDate = CreatedDate;
            this.PenaltyPoints = PenaltyPoints;

            LoggedUserID = default;
            Mode = enMode.Update;

        }

        private bool Add()
        {
            DriverID = clsDriverData.AddDriver(
                    PersonID,
                    CreatedByUserID,
                    CreatedDate,
                    LoggedUserID,
                    PenaltyPoints
                );
            return DriverID.HasValue;
        }

        private bool Update()
        {
            if (!DriverID.HasValue)
                return false;

            return clsDriverData.UpdateDriverByID(
                DriverID.Value,
                PersonID,
                CreatedByUserID,
                CreatedDate,
                LoggedUserID,
                PenaltyPoints
            );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return Update();

                default:
                    return false;
            }
        }

        public static bool IsExist(int DriverID)
            => clsDriverData.IsExistByID(DriverID);

        public static bool IsDriver(int PersonID)
            => clsDriverData.IsPersonDriver(PersonID);

        public static clsDriver GetByDriverID(int? DriverID)
        {
            if (!DriverID.HasValue)
                return null;

            var dt = clsDriverData.GetByID(DriverID.Value);
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];

            return new clsDriver(
                DriverID: row["DriverID"].ToInt32(),
                PersonID: row["PersonID"].ToInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                CreatedDate: row["CreatedDate"].ToDate(),
                PenaltyPoints: row["PenaltyPoints"].ToInt32()
            );
        }

        public static clsDriver GetByPersonID(int? PersonID)
        {
            if (!PersonID.HasValue)
                return null;
            var dt = clsDriverData.GetByPersonID(PersonID.Value);
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];

            return new clsDriver(
                DriverID: row["DriverID"].ToInt32(),
                PersonID: row["PersonID"].ToInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                CreatedDate: row["CreatedDate"].ToDate(),
                PenaltyPoints: row["PenaltyPoints"].ToInt32()
            );
        }

        public static bool DeleteByID(int DriverID, int LoggedUserID)
            => clsDriverData.DeleteByID(DriverID, LoggedUserID);

        public static DataTable GetAllDriversList()
            => clsDriverData.GetAllDriversList();

        public static DataTable GetAllLocalLicenses(int DriverID)
            => clsDriverData.GetAllDriverLocalLicenses(DriverID);

        public static DataTable GetAllInternationalLicenses(int DriverID)
            =>  clsDriverData.GetAllInternationalLicensesData(DriverID);

        public static clsDriver operator +(clsDriver driver, int points)
        {
            driver.PenaltyPoints += points;
            return driver;
        }

        public static clsDriver operator -(clsDriver driver, int points)
        {
            driver.PenaltyPoints -= points;
            return driver;
        }

        public int CompareTo(clsDriver other)
        {
            if (other == null) return 1;
            return PenaltyPoints.CompareTo(other.PenaltyPoints);
        }
    }
}
