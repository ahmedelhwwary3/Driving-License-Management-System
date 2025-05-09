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
    //We can inherit also from License but here Inhrtiting from Application is more efficient
    public class clsInternationalLicense : clsApplication
    {

        protected new enum enMode { AddNew = 0, Update = 1 };
        protected new enMode Mode = enMode.AddNew;

        public int? InternationalLicenseID { set; get; }
        public new int? InternationalApplicationID { get; set; }
        public clsApplication BaseApplication {  get; set; }
        public int? DriverID { set; get; }
        public clsDriver Driver { get; set; }
        public int? IssuedUsingLocalLicenseID { set; get; }
        public clsLicense IssuedUsingLocalLicense { get; set; }
        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }
        public int? InterntaionalCreatedByUserID { get; set; }
      
        public new int? LoggedUserID    { set; get; }
   



        public clsInternationalLicense()
        {
            this.LoggedUserID = null;
            base.LoggedUserID = null;
            this.IssuedUsingLocalLicense = new clsLicense();
            this.IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicense.LicenseID;

            this.InternationalLicenseID = null;
            this.ExpirationDate = DateTime.Now.AddYears((int)clsLicenseClass.enDefaultValidityLength.Class3_ordinary_driving_license);
            this.IsActive = true;

            this.IssueDate = DateTime.Now;
            this.InterntaionalCreatedByUserID = null;

            this.Driver = new clsDriver();
            this.DriverID = Driver.DriverID;

            this.BaseApplication = new clsApplication();
            this.InternationalApplicationID = null;
            base.ApplicationID = null;
            base.ApplicationTypeID = enApplicationType.NewInternationalLicense;

            Mode = enMode.AddNew;

        }

        protected clsInternationalLicense(
            int? LocalApplicationID, int? ApplicantPersonID,
            DateTime ApplicationDate, enApplicationStatus ApplicationStatus, 
            DateTime LastStatusDate,decimal PaidFees, int? LocalLicenseCreatedByUserID,
            int? InternationalLicenseID,int? DriverID, 
            int? IssuedUsingLocalLicenseID,  DateTime IssueDate,
             DateTime ExpirationDate, bool IsActive,int? InternationalLicenseCreatedByUserID,int? InternationalApplicationID) :

            base( LocalApplicationID,  ApplicantPersonID, ApplicationDate,enApplicationType.NewInternationalLicense
                , (enApplicationStatus) ApplicationStatus, LastStatusDate, LocalLicenseCreatedByUserID, PaidFees)
        {
            Func<int?, clsDriver> getDriverMethod = new Func<int?, clsDriver>(clsDriver.GetByDriverID);
            Func<int?, clsApplication> getBaseAppMethod = new Func<int?, clsApplication>(clsApplication.GetByID);
            Func<int?, clsLicense> getLicenseAppMethod = new Func<int?, clsLicense>(clsLicense.GetByID);

            this.LoggedUserID = null;
            base.LoggedUserID = null;
            this.InternationalLicenseID = InternationalLicenseID;
            this.InternationalApplicationID = LocalApplicationID;
            this.BaseApplication = getBaseAppMethod.GetByNullableID(LocalApplicationID);
            this.DriverID = DriverID;
            this.Driver = getDriverMethod.GetByNullableID(DriverID);
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssuedUsingLocalLicense = getLicenseAppMethod.GetByNullableID(IssuedUsingLocalLicenseID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.InterntaionalCreatedByUserID = InternationalLicenseCreatedByUserID;
            this.InternationalApplicationID= InternationalApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            if (this.InternationalApplicationID.HasValue 
                && this.DriverID.HasValue && this.IssuedUsingLocalLicenseID.HasValue 
                && this.InterntaionalCreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                this.InternationalLicenseID = clsInternationalLicenseData.AddInternationalLicense(
                    this.InternationalApplicationID.Value,
                    this.DriverID.Value,
                    this.IssuedUsingLocalLicenseID.Value,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.IsActive,
                    this.InterntaionalCreatedByUserID.Value,
                    this.LoggedUserID.Value
                );
            }
            return this.InternationalLicenseID != null;
        }

        private bool _UpdateInternationalLicense()
        {
            if (this.InternationalLicenseID.HasValue && 
                this.InternationalApplicationID.HasValue && 
                this.DriverID.HasValue && this.IssuedUsingLocalLicenseID.HasValue && 
                this.InterntaionalCreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                return clsInternationalLicenseData.UpdateInternationalLicenseByID(
                    this.InternationalLicenseID.Value,
                    this.InternationalApplicationID.Value,
                    this.DriverID.Value,
                    this.IssuedUsingLocalLicenseID.Value,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.IsActive,
                    this.InterntaionalCreatedByUserID.Value,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }
        public static clsInternationalLicense GetInternationalLicenseByID(int? InternationalLicenseID)
        {
            if (!InternationalLicenseID.HasValue) return null;

            DataTable dt = clsInternationalLicenseData.GetInternationalLicenseDataByID(InternationalLicenseID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsInternationalLicense(
                InternationalApplicationID: row["InternationalApplicationID"].ToNullableInt32(),
                InternationalLicenseCreatedByUserID: row["InternationalLicenseCreatedByUserID"].ToNullableInt32(),
                LocalApplicationID: row["LocalApplicationID"].ToNullableInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToNullableInt32(),
                ApplicationDate: row["ApplicationDate"].ToDate(),
                ApplicationStatus: row["ApplicationStatus"] != DBNull.Value ? (enApplicationStatus)Convert.ToInt32(row["ApplicationStatus"]) : enApplicationStatus.New,
                LastStatusDate: row["LastStatusDate"].ToDate(),
                PaidFees: row["PaidFees"].ToDecimal(),
                LocalLicenseCreatedByUserID: row["LocalLicenseCreatedByUserID"] .ToNullableInt32(),
                InternationalLicenseID: row["InternationalLicenseID"].ToNullableInt32(),
                DriverID: row["DriverID"].ToNullableInt32(),
                IssuedUsingLocalLicenseID: row["IssuedUsingLocalLicenseID"].ToNullableInt32(),
                IsActive: row["IsActive"].ToBoolean(),
                ExpirationDate: row["ExpirationDate"].ToDate(),
                IssueDate: row["IssueDate"].ToDate()
            );
        }

        public static DataTable GetAllInternationalLicenses()
            => clsInternationalLicenseData.GetAllInternationalLicensesList();

        public new bool Save()
        {
            // Call the base class save method first to handle the application table
            base.Mode = (clsApplication.enMode)Mode;
            base.LoggedUserID = this.LoggedUserID;
            if (!base.Save())
                return false;
            this.InternationalApplicationID= base.ApplicationID;
            this.LoggedUserID = base.LoggedUserID;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();
            }

            return false;
        }


        public static int? GetActiveInternationalLicenseIDByDriverID(int? DriverID)
            => DriverID.HasValue?clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID.Value):null;

        public static DataTable GetDriverInternationalLicenses(int? DriverID)
            => DriverID.HasValue? clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID.Value):null;

    }
}
