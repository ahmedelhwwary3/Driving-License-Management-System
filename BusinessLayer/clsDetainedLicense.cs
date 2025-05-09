using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static BusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;


namespace BusinessLayer
{
    public class clsDetainedLicense
    {
        //Does not inherit from License because this is not efficient as each entity has many different Fields
        protected enum enMode { AddNew = 0, Update = 1 };
        protected enMode Mode = enMode.AddNew;

        public int? LicenseID {  get; set; }
        public clsLicense License { get; set; }
        public int? DetainID { set; get; }     
        public DateTime DetainDate { set; get; }
        public decimal FineFees { set; get; }
        public int? CreatedByUserID {  set; get; }
        public clsUser CreatedByUser { set; get; }
        public bool IsReleased { set; get; }
        public DateTime? ReleaseDate { set; get; }
        public Nullable< int> ReleasedByUserID { set; get; }
        public clsUser ReleasedByUser { set; get; }
        public Nullable<int> ReleaseApplicationID { set; get; }
        public clsApplication ReleaseApplication { set; get; }

        public int? LoggedUserID {  set; get; }
        public clsDetainedLicense()

        {
            this.License = new clsLicense();
            this.DetainID = null;
            this.DetainDate = DateTime.Now;
            this.FineFees = default;
            this.CreatedByUserID = null;
            this.CreatedByUser=new clsUser();
            this.IsReleased = default;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleasedByUser=null;
            this.ReleaseApplicationID = null;
            this.ReleaseApplication = null;
            Mode = enMode.AddNew;

        }

        protected clsDetainedLicense(int? DetainID,
            int? LicenseID, DateTime DetainDate,
            decimal FineFees, int? CreatedByUserID,
            bool IsReleased, DateTime? ReleaseDate,
           Nullable<int> ReleasedByUserID,Nullable< int> ReleaseApplicationID)
      

        {
            var getLicense = new Func<int?, clsLicense>(clsLicense.GetByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);
            var getApplication = new Func<int?, clsApplication>(clsApplication.GetByID);

            this.License = getLicense.GetByNullableID(LicenseID);
            this.CreatedByUser = getUser.GetByNullableID(CreatedByUserID);
            this.ReleasedByUser = getUser.GetByNullableID(ReleasedByUserID);
            this.ReleaseApplication = getApplication.GetByNullableID(ReleaseApplicationID);

            this.ReleaseApplicationID = ReleaseApplicationID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            if (this.LicenseID.HasValue && this.CreatedByUserID.HasValue
                &&this.LoggedUserID.HasValue)
            {
                this.DetainID = clsDetainedLicenseData.AddDetainedLicense(
                    (int)this.LicenseID,
                    this.DetainDate,
                    this.FineFees,
                    (int)this.CreatedByUserID
                    ,this.LoggedUserID.Value
                );
            }
            return this.DetainID != null;
        }

        private bool _UpdateDetainedLicense()
        {
            if (this.DetainID.HasValue && this.LicenseID.HasValue && 
                this.CreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                return clsDetainedLicenseData.UpdateDetainedLicense(
                    this.DetainID.Value,
                    (int)this.LicenseID,
                    this.DetainDate,
                    this.FineFees,
                    (int)this.CreatedByUserID,
                    this.IsReleased,
                    this.ReleaseDate,
                    this.ReleasedByUserID,
                    this.ReleaseApplicationID,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }


        public static clsDetainedLicense GetByID(int? DetainID)
        {
            if (!DetainID.HasValue) return null;

            DataTable dt = clsDetainedLicenseData.GetDetainedLicenseByID(DetainID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsDetainedLicense(
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                LicenseID: row["LicenseID"].ToNullableInt32(),
                DetainDate: row["DetainDate"] != DBNull.Value ? Convert.ToDateTime(row["DetainDate"]) : DateTime.Now,
                DetainID: row["DetainID"].ToNullableInt32(),
                FineFees: row["FineFees"] != DBNull.Value ? Convert.ToDecimal(row["FineFees"]) : 0,
                IsReleased: row["IsReleased"] != DBNull.Value ? Convert.ToBoolean(row["IsReleased"]) : false,
                ReleaseApplicationID: row["ReleaseApplicationID"].ToNullableInt32(),
                ReleaseDate: row["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(row["ReleaseDate"]) : DateTime.Now,
                ReleasedByUserID: row["LicenseID"].ToNullableInt32());
        }

        public static DataTable GetAllDetainedLicenses()
            => clsDetainedLicenseData.GetAllDetainedLicensesFullData();

        public static clsDetainedLicense GetByLicenseID(int? LicenseID)
        {
            if (!LicenseID.HasValue) return null;

            DataTable dt = clsDetainedLicenseData.GetDetainedLicenseByLicenseID(LicenseID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsDetainedLicense(
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                LicenseID: row["LicenseID"].ToNullableInt32(),
                DetainDate: row["DetainDate"] .ToDate(),
                DetainID: row["DetainID"].ToNullableInt32(),
                FineFees: row["FineFees"].ToDecimal(),
                IsReleased: row["IsReleased"].ToBoolean(),
                ReleaseApplicationID: row["ReleaseApplicationID"].ToNullableInt32(),
                ReleaseDate: row["ReleaseDate"].ToDate(),
                ReleasedByUserID: row["LicenseID"].ToNullableInt32());
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }

        public bool IsDetained()
            => !this.IsReleased;

        public bool Release_BizLogic(decimal PaidFees, int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            if (!ActivateDetainedLicense(ReleasedByUserID))
                return false;

            clsApplication ReleaseApplication = new clsApplication();
            ReleaseApplication.PaidFees = PaidFees;
            ReleaseApplication.ApplicationDate = DateTime.Now;
            ReleaseApplication.LastStatusDate = DateTime.Now;
            ReleaseApplication.ApplicantPersonID = this.License.Application.ApplicantPersonID;
            ReleaseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            ReleaseApplication.ApplicationTypeID = clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            ReleaseApplication.CreatedByUserID = ReleasedByUserID;
            ReleaseApplication.LoggedUserID = ReleasedByUserID;
            if (!ReleaseApplication.Save())
            {
                DeactivateLicense();
                return false;
            }

            ReleaseApplicationID = ReleaseApplication.ApplicationID;
            this.ReleaseDate = DateTime.Now;
            this.ReleaseApplicationID = ReleaseApplication.ApplicationID;
            this.ReleasedByUserID = ReleasedByUserID;
            this.LoggedUserID= ReleasedByUserID;
            this.IsReleased = true;

            return this.Save();
        }

        // Same Functionality With 2 Ways
        public bool Release_DBLogic(decimal PaidFees, int? ReleasedByUserID, int? ReleaseApplicationID)
            => ReleasedByUserID.HasValue&&ReleaseApplicationID.HasValue&& clsDetainedLicenseData.ReleaseDetainedLicenseByID(this.DetainID.Value, DateTime.Now,
                ReleasedByUserID.Value, PaidFees, ReleaseApplicationID.Value,this.LoggedUserID.Value);
        public bool DeactivateLicense()
        {
            if (!this.LicenseID.HasValue)
                return false;
            clsLicense License = clsLicense.GetByID(this.LicenseID);
            return License.Deactivate(CreatedByUserID);
        }
        public bool ActivateDetainedLicense(int? LoggedUserID)
        {
            if (!this.LicenseID.HasValue)
                return false;
            clsLicense License = clsLicense.GetByID(this.LicenseID);
            return License.Activate(LoggedUserID.Value);
        }




    }
}
