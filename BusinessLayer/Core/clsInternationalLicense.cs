using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Data;
using static BusinessLayer.Core.clsLicenseClass;

namespace BusinessLayer.Core
{
    public class clsInternationalLicense : clsApplication
    {
        protected new enum enMode { AddNew = 0, Update = 1 };
        protected new enMode Mode = enMode.AddNew;

        public int? InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDriver Driver { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense IssuedUsingLocalLicense { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public clsInternationalLicense()
        {
            //here we set the applicaiton type to New International License.
            this.ApplicationTypeID = (int)enApplicationType.NewInternationalLicense;

            this.InternationalLicenseID = null;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = default;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            this.IsActive = true;


            Mode = enMode.AddNew;
        }
        protected clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)

        {
            // this is for the base class
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = (int)ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.DriverID = DriverID;
            this.Driver = clsDriver.GetByDriverID(DriverID);
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssuedUsingLocalLicense = clsLicense.GetByID(IssuedUsingLocalLicenseID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;

        }
        private bool AddNewInternationalLicense()
        {
            InternationalLicenseID = clsInternationalLicenseData.AddInternationalLicense(
                 DriverID,
                 IssuedUsingLocalLicenseID,
                 IssueDate,
                 ExpirationDate,
                 IsActive,
                 base.CreatedByUserID,
                 PaidFees,
                 LoggedUserID
             );

            return InternationalLicenseID.HasValue;
        }

        private bool UpdateInternationalLicense()
        {
            if (!InternationalLicenseID.HasValue)
                return false;

            return clsInternationalLicenseData.UpdateInternationalLicenseByID(
                InternationalLicenseID.Value,
                base.ApplicationID.Value,
                DriverID,
                IssuedUsingLocalLicenseID,
                IssueDate,
                ExpirationDate,
                IsActive,
                base.CreatedByUserID,
                LoggedUserID,
                PaidFees
            );
        }

        

        public new bool Save()
        {
            //base.Mode = (clsApplication.enMode)Mode;
            //Transaction & Rollback of save base Application Hadnedled in Data Base
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewInternationalLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return UpdateInternationalLicense();
                    }
                default:
                    break;
            }
            return false;
        }

        public static clsInternationalLicense GetInternationalLicenseByID(int? InternationalLicenseID)
        {
            if (!InternationalLicenseID.HasValue)
                return null;
            DataTable dt = clsInternationalLicenseData.GetInternationalLicenseDataByID(InternationalLicenseID.Value);
            
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsInternationalLicense(
                InternationalLicenseID: row["InternationalLicenseID"].ToInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToInt32(),
                ApplicationDate: row["ApplicationDate"].ToDate(),
                ApplicationStatus: (enApplicationStatus)row["ApplicationStatus"].ToInt32(),
                LastStatusDate: row["LastStatusDate"].ToDate(),
                PaidFees: row["PaidFees"].ToDecimal(),
                DriverID: row["DriverID"].ToInt32(),
                IssuedUsingLocalLicenseID: row["IssuedUsingLocalLicenseID"].ToInt32(),
                IsActive: row["IsActive"].ToBoolean(),
                ExpirationDate: row["ExpirationDate"].ToDate(),
                IssueDate: row["IssueDate"].ToDate(),
                ApplicationID: row["ApplicationID"].ToInt32()
            );
        }

        public static DataTable GetAllInternationalLicenses()
            => clsInternationalLicenseData.GetAllInternationalLicensesList();

        public static int? GetActiveInternationalLicenseIDByDriverID(int DriverID)
            => clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        public static DataTable GetDriverInternationalLicenses(int DriverID)
            => clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
    }
}
