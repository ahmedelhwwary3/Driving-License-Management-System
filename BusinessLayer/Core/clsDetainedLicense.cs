using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsDetainedLicense
    {
        protected enum enMode { AddNew, Update };
        protected enMode Mode;

        public int? DetainID { get; set; }
        public int LicenseID { get; set; }
        public clsLicense License { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }

        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public int? ReleasedByUserID { get; set; }
        public clsUser ReleasedByUser { get; set; }

        public int? ReleaseApplicationID { get; set; }
        public clsApplication ReleaseApplication { get; set; }

        public int LoggedUserID { get; set; }

        public clsDetainedLicense()
        {
            DetainID = default;
            LicenseID = default;
            License = new clsLicense();

            DetainDate = DateTime.Now;
            FineFees = default;

            CreatedByUserID = default;
            CreatedByUser = new clsUser();

            IsReleased = false;
            ReleaseDate = default;
            ReleasedByUserID = default;
            ReleasedByUser = new clsUser();

            ReleaseApplicationID = default;
            ReleaseApplication = new clsApplication();

            LoggedUserID = default;
            Mode = enMode.AddNew;
        }

        protected clsDetainedLicense(int? DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            License = clsLicense.GetByID(LicenseID);

            this.DetainDate = DetainDate;
            this.FineFees = FineFees;

            this.CreatedByUserID = CreatedByUserID;
            CreatedByUser = clsUser.GetByID(CreatedByUserID);

            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;

            this.ReleasedByUserID = ReleasedByUserID;
            ReleasedByUser = clsUser.GetByID(ReleasedByUserID);

            this.ReleaseApplicationID = ReleaseApplicationID;
            ReleaseApplication = clsApplication.GetApplicationByID(this.ReleaseApplicationID);

            LoggedUserID = default;
            Mode = enMode.Update;

        }

        private bool _Add()
        {
            DetainID = clsDetainedLicenseData.AddDetainedLicense(
                LicenseID, DetainDate, FineFees, CreatedByUserID, LoggedUserID
            );

            return DetainID.HasValue;
        }

        private bool _Update()
        {
            if (!DetainID.HasValue)
                return false;

            return clsDetainedLicenseData.UpdateDetainedLicense(
                    DetainID.Value,
                    (int)LicenseID,
                    DetainDate,
                    FineFees,
                    (int)CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID,
                    LoggedUserID
                );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }
        public bool Release(decimal PaidFees, int ReleasedByUserID, out int? ReleaseApplicationID)
        {
            ReleaseApplicationID = null;
            if (!DetainID.HasValue)
                return false;
            if (!clsDetainedLicenseData.ReleaseDetainedLicenseByID(this.DetainID.Value, DateTime.Now,
                ReleasedByUserID, PaidFees, out ReleaseApplicationID, ReleasedByUserID))
                return false;
            //Refresh Object
            clsDetainedLicense NewInfo = clsDetainedLicense.GetByDetainID(this.DetainID.Value);
            this.FineFees = NewInfo.FineFees;
            this.CreatedByUserID = NewInfo.CreatedByUserID;
            this.DetainDate = NewInfo.DetainDate;
            this.ReleaseDate = NewInfo.ReleaseDate;
            this.ReleasedByUserID = NewInfo.ReleasedByUserID;
            this.ReleaseApplicationID = NewInfo.ReleaseApplicationID;
            return true;
        }
        public static clsDetainedLicense GetByDetainID(int? DetainID)
        {
            if (!DetainID.HasValue)
                return null;
            var dt = clsDetainedLicenseData.GetDetainedLicenseByDetainID(DetainID.Value);
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];

            return new clsDetainedLicense(
                DetainID: row["DetainID"].ToInt32(),
                LicenseID: row["LicenseID"].ToInt32(),
                DetainDate: row["DetainDate"].ToDate(),
                FineFees: row["FineFees"].ToDecimal(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                IsReleased: row["IsReleased"].ToBoolean(),
                ReleaseDate: row["ReleaseDate"].ToNullableDate(),
                ReleasedByUserID: row["ReleasedByUserID"].ToInt32(),
                ReleaseApplicationID: row["ReleaseApplicationID"].ToInt32()
            );
        }
        public static DataTable GetAllDetainedLicenses()
            => clsDetainedLicenseData.GetAllDetainedLicensesFullData();
        public static clsDetainedLicense GetByLicenseID(int LicenseID)
        {

            var dt = clsDetainedLicenseData.GetDetainedLicenseByLicenseID(LicenseID);
            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];

            return new clsDetainedLicense(
                DetainID: row["DetainID"].ToInt32(),
                LicenseID: row["LicenseID"].ToInt32(),
                DetainDate: row["DetainDate"].ToDate(),
                FineFees: row["FineFees"].ToDecimal(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                IsReleased: row["IsReleased"].ToBoolean(),
                ReleaseDate: row["ReleaseDate"].ToNullableDate(),
                ReleasedByUserID: row["ReleasedByUserID"].ToNullableInt32(),
                ReleaseApplicationID: row["ReleaseApplicationID"].ToNullableInt32()
            );
        }
        public static bool IsExist(int DetainID)
            => clsDetainedLicenseData.IsLicenseDetainedByID(DetainID);
    }
}
