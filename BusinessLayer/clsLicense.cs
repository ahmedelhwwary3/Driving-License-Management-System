using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static BusinessLayer.clsLicenseClass;
using static BusinessLayer.clsApplication;
 
using System.Data.Common;

namespace BusinessLayer
{
    public class clsLicense
    {

        public enum enIssueReason
        { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 };
        public int? LicenseID { get; set; }
        public int? ApplicationID { get; set; }
        public clsApplication Application { get; set; }
        public int? DriverID { get; set; }
        public clsDriver Driver { get; set; }
        public Nullable<clsLicenseClass.enLicenseClassID> LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason? IssueReason { get; set; }
        public string IssueReasonText
            => GetIssueReasonText(IssueReason);
        public int? CreatedByUserID { get; set; }
        public clsUser User { get; set; }
        public int?LoggedUserID { get; set; }
        public enum enMode { AddNew, Update }
        protected enMode Mode;

         
        public clsLicense()
        {
            this.LoggedUserID = null;
            this.LicenseID = null;
            this.ApplicationID = null;
            this.DriverID = null;
            this.LicenseClass = enLicenseClassID.Class3_ordinary_driving_license;
            this.IsActive = false;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IssueReason = enIssueReason.FirstTime;
            this.Notes = "";
            this.PaidFees = 0;
            this.CreatedByUserID = null;
            Mode = enMode.AddNew;
        }
        protected clsLicense(int? LicenseID, int? ApplicationID, int? DriverID, 
            clsLicenseClass.enLicenseClassID? LicenseClass, DateTime IssueDate, 
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, 
            enIssueReason IssueReason, int? CreatedByUserID)
        {
            var getApplication = new Func<int?, clsApplication>(clsApplication.GetByID);
            var getDriver = new Func<int?, clsDriver>(clsDriver.GetByDriverID);
            var getLicenseClass = new Func<int?, clsLicenseClass>(clsLicenseClass.GetByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);

            this.LoggedUserID = null;
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.Application = getApplication.GetByNullableID(ApplicationID);
            this.DriverID = DriverID;
            this.Driver = getDriver.GetByNullableID(DriverID);
            this.LicenseClass = LicenseClass;
            this.LicenseClassInfo = getLicenseClass.GetByNullableID((int)LicenseClass);
            this.IsActive = IsActive;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.User = getUser.GetByNullableID(CreatedByUserID);



            Mode = enMode.Update;
        }
        private bool _AddNewLicense()
        {
            if (this.ApplicationID.HasValue && this.DriverID.HasValue && 
                this.LicenseClass.HasValue && this.CreatedByUserID.HasValue
                &&this.LoggedUserID.HasValue)
            {
                this.LicenseID = clsLicenseData.AddLicense(
                    this.ApplicationID.Value,
                    this.DriverID.Value,
                    (int)this.LicenseClass.Value,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.Notes,
                    this.PaidFees,
                    this.IsActive,
                    (int)this.IssueReason,
                    this.CreatedByUserID.Value,
                    this.LoggedUserID.Value
                );
            }
            return this.LicenseID != null;
        }

        private bool _UpdateLicense()
        {
            if (this.LicenseID.HasValue && this.ApplicationID.HasValue &&
                this.DriverID.HasValue && this.LicenseClass.HasValue
                &&this.LoggedUserID.HasValue )
            {
                return clsLicenseData.UpdateLicenseByID(
                    this.LicenseID.Value,
                    this.ApplicationID.Value,
                    this.DriverID.Value,
                    (int)this.LicenseClass.Value,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.Notes,
                    this.PaidFees,
                    this.IsActive,
                    (int)this.IssueReason,
                    this.CreatedByUserID.Value,
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
                        if (_AddNewLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateLicense();
                    }
                default:
                    break;
            }
            return false;
        }


        public static bool IsExist(int? LicenseID)
        => LicenseID.HasValue&&clsLicenseData.IsExistedByID(LicenseID.Value);
        public static clsLicense GetByID(int? LicenseID)
        {
            if (!LicenseID.HasValue)
                return null;
            DataTable dt = clsLicenseData.GetByLicenseID(LicenseID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicense(
                PaidFees: row["PaidFees"].ToDecimal(),
                IssueDate: row["IssueDate"] != DBNull.Value ? Convert.ToDateTime(row["IssueDate"]) : DateTime.Now,
                ExpirationDate: row["ExpirationDate"] != DBNull.Value ? Convert.ToDateTime(row["ExpirationDate"]) : DateTime.Now,
                ApplicationID: row["ApplicationID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                DriverID: row["DriverID"].ToNullableInt32(),
                IsActive: row["IsActive"].ToBoolean(),
                IssueReason: row["IssueReason"] != DBNull.Value ? (enIssueReason)Convert.ToInt32(row["IssueReason"]) : enIssueReason.FirstTime,
                LicenseClass: (enLicenseClassID?)row["LicenseClass"].ToNullableInt32(),
                LicenseID: row["LicenseID"].ToNullableInt32(),
                Notes: row["Notes"].ToString() ?? ""
            );

        }

        public static clsLicense GetByPersonID(int? PersonID)
        {
            if (!PersonID.HasValue)
                return null;
            DataTable dt = clsLicenseData.GetByPersonID(PersonID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicense(

                PaidFees: row["PaidFees"].ToDecimal(),
                IssueDate: row["IssueDate"] != DBNull.Value ? Convert.ToDateTime(row["IssueDate"]) : DateTime.Now,
                ExpirationDate: row["ExpirationDate"] != DBNull.Value ? Convert.ToDateTime(row["ExpirationDate"]) : DateTime.Now,
                ApplicationID: row["ApplicationID"].ToNullableInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                DriverID: row["DriverID"].ToNullableInt32(),
                IsActive: row["IsActive"].ToBoolean(),
                IssueReason: row["IssueReason"] != DBNull.Value ? (enIssueReason)Convert.ToInt32(row["IssueReason"]) : enIssueReason.FirstTime,
                LicenseClass: (enLicenseClassID?)row["LicenseClass"].ToNullableInt32(),
                LicenseID: row["LicenseID"].ToNullableInt32(),
                Notes: row["Notes"].ToString()??""
            );

        }


        public static DataTable GetAllLicensesList()
        => clsLicenseData.GetAllLicensesList();
        public static DataTable GetAllLicensesFullDataForDriver(int? DriverID)
        => DriverID.HasValue? clsLicenseData.GetAllLicensesFullDataByDriverID(DriverID.Value):null;
        public static bool DeleteLicense(int? LicenseID,int? LoggedUserID)
        => LicenseID.HasValue && clsLicenseData.DeleteByID(LicenseID.Value, LoggedUserID.Value);
        public static bool IsThereActiveLicenseForPersonPerLicenseClass(int? PersonID, int? LicenseClassID)
        => LicenseClassID.HasValue && PersonID.HasValue&&(GetActiveLicenseIDByPersonIDForLicenseClass(PersonID.Value, LicenseClassID.Value) != null);
        public static int? GetActiveLicenseIDByPersonIDForLicenseClass(int? PersonID, int? LicenseClassID)
        => PersonID.HasValue&&LicenseClassID.HasValue? clsLicenseData.GetActiveLicenseIDByPersonIDPerLicenseClass(PersonID.Value, LicenseClassID.Value):null;
        public bool Deactivate(int? LoggedUserID)
         => this.LicenseID.HasValue&& LoggedUserID.HasValue &&
            clsLicenseData.DeactivateLicenseByID(this.LicenseID.Value, LoggedUserID.Value);
        
        public static bool Deactivate(int? LicenseID,int? LoggedUserID)
            => LicenseID.HasValue && LoggedUserID.HasValue&&
            clsLicenseData.DeactivateLicenseByID(LicenseID.Value, LoggedUserID.Value);
        public Boolean IsDateExpirated()
         => (this.ExpirationDate <= DateTime.Now);
        public static string GetIssueReasonText(enIssueReason? Reason)
        {
            switch (Reason)
            {
                case enIssueReason.FirstTime:
                    return "FirstTime";
                case enIssueReason.Renew:
                    return "UpdateOldLicense";
                case enIssueReason.ReplacementForLost:
                    return "ReplacementForLost";
                default:
                    return "ReplacementForDamaged";
            }
        }

        //RenewDrivingLicenseService = 2, ReplacementForLostDrivingLicense = 3,
        //ReplacementForDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5
        ///Generic Method for All Status Changes
        #region Code Handling
        ////1.Create new Application (Renew)
        //clsApplication RenewApplication = new clsApplication();
        //RenewApplication.ApplicantPersonID = this.Driver.Person.PersonID;
        //RenewApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
        //RenewApplication.ApplicationDate = DateTime.Now;
        //RenewApplication.ApplicationTypeID = clsApplication.enApplicationType.RenewDrivingLicenseService;
        //RenewApplication.CreatedByUserID = CreatedByUserID;
        //RenewApplication.PaidFees = clsApplicationType.GetApplicationTypeFees((int)clsApplication.enApplicationType.RenewDrivingLicenseService);
        //RenewApplication.LastStatusDate = DateTime.Now;
        ////2.Save Application
        //if (!RenewApplication.Save())
        //{
        //    return null;
        //}
        ////3.Issue License 
        //clsLicense IssuedLicense = new clsLicense();
        //IssuedLicense.ApplicationID = RenewApplication.ApplicationID;
        //IssuedLicense.Notes = Notes;
        //IssuedLicense.CreatedByUserID = CreatedByUserID;
        //IssuedLicense.IsActive = true;
        //IssuedLicense.IssueDate = DateTime.Now;
        //IssuedLicense.IssueReason = enIssueReason.Renew;


        //IssuedLicense.LicenseClass = this.LicenseClass;
        //IssuedLicense.PaidFees = this.LicenseClassInfo.ClassFees;
        //IssuedLicense.DriverID = this.DriverID;
        //IssuedLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
        ////4.Save License
        //if (!IssuedLicense.Save())
        //{
        //    return null;
        //}
        ////5.Deactivate Old License
        //Deactivate();
        //return IssuedLicense; 
        #endregion
        ///Logical Steps:-
        //1.Create Renew Application and Save it
        //2.Issue New License
        //3.Diactivate old License

        //Users for Release Application and Issue License are the same User
        //We can handle all these steps in Code but we handeled it in DB for enabling
        //RollBack (Easier)
        private int? UpdateOldLicense(int? ApplicationTypeID,
            int? CreatedByUserID,int? LoggedUserID)
        {
            #region NewLicenseData
            ///Parameters are also for New License in addition to:
            int IssueReason=2;//by default => Renew
            switch (ApplicationTypeID)
            {
                case (int)clsApplication.enApplicationType.RenewDrivingLicenseService:
                    {
                        IssueReason = (int)clsLicense.enIssueReason.Renew;
                        break;
                    }
                case (int)clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense:
                    {
                        IssueReason = (int)clsLicense.enIssueReason.ReplacementForDamaged;
                        break;
                    }
                case (int)clsApplication.enApplicationType.ReplacementForLostDrivingLicense:
                    {
                        IssueReason = (int)clsLicense.enIssueReason.ReplacementForLost;
                        break;
                    }
                    default: 
                    return 2;
            }
            decimal? LicensePaidFees = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID);
            #endregion
            #region NewApplicationData
            decimal ApplicationPaidFees = clsApplicationType.GetByID(ApplicationTypeID).ApplicationFees;
            DateTime ApplicationDate = DateTime.Now;
            DateTime ApplicationLastStatusDate = ApplicationDate;
            //All Application Types will be completed after performing this method::enum value = 3
            int ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;

            #endregion
            #region OldLicenseData
            int DefaultValidityLength =(int) clsLicenseClass.GetByID((int)this.LicenseClass).DefaultValidityLength;
            string LicenseNotes=this.Notes;
            DateTime LicenseExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            #endregion
            
            return clsLicenseData.RenewOrReplaceOldLicense(this.Application.ApplicantPersonID.Value, ApplicationDate,
                ApplicationTypeID.Value, ApplicationStatus, ApplicationLastStatusDate,ApplicationPaidFees, CreatedByUserID.Value, LicenseExpirationDate, LicenseNotes
                , LicensePaidFees.Value,  this.DriverID.Value,(int) this.LicenseClass.Value, IssueReason,LoggedUserID.Value
                );
            // int ReleaseApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicenseService;
        }

        public int? RenewOldLicense(int? CreatedByUserID)
        {
            this.LoggedUserID = CreatedByUserID;
            int? ApplicationTypeID =(int) clsApplication.enApplicationType.RenewDrivingLicenseService;
            return CreatedByUserID.HasValue &&this.LoggedUserID.HasValue&& ApplicationTypeID.HasValue ? this.UpdateOldLicense(ApplicationTypeID,
                CreatedByUserID, this.LoggedUserID.Value) :null;
        }
        public int? ReplaceForLost( int? CreatedByUserID)
        {
            this.LoggedUserID = CreatedByUserID;
            int? ApplicationTypeID = (int)clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
            return CreatedByUserID.HasValue && this.LoggedUserID.HasValue && ApplicationTypeID.HasValue ? this.UpdateOldLicense(ApplicationTypeID,
                CreatedByUserID,this.LoggedUserID.Value):null;

        }
        public int? ReplaceForDamaged(int? CreatedByUserID)
        {
            this.LoggedUserID = CreatedByUserID;
            int? ApplicationTypeID = (int)clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense;
            return CreatedByUserID.HasValue&&this.LoggedUserID.HasValue&& ApplicationTypeID.HasValue? this.UpdateOldLicense(ApplicationTypeID,
                CreatedByUserID, this.LoggedUserID.Value) :null;

        }
        public int? Detain(decimal PaidFees,int? CreatedByUserID)
        {
            if (!Deactivate(CreatedByUserID))
                return null;
            clsDetainedLicense Detained = new clsDetainedLicense();
            Detained.DetainDate = DateTime.Now;
            Detained.FineFees = PaidFees;
            Detained.CreatedByUserID = CreatedByUserID;
            Detained.LicenseID = this.LicenseID;
            Detained.IsReleased = false;
            Detained.LoggedUserID = CreatedByUserID;//Detain User
            if (!Detained.Save())
            {
                Activate(CreatedByUserID);
                return null;
            }
            return Detained.LicenseID;
        }
        public bool Activate(int? LoggedUserID)
            => this.LicenseID.HasValue && LoggedUserID.HasValue &&
            clsLicenseData.ActivateLicenseByID(this.LicenseID.Value, LoggedUserID.Value);
        public bool IsLicenseDetained()
         => this.LicenseID.HasValue&& clsDetainedLicenseData.
            IsLicenseDetainedByID(this.LicenseID.Value);

        public bool HasIssuedActiveInternationalLicense()
            => this.LicenseID.HasValue&& clsLicenseData.
            HasIssuedActiveInternationalLicense(this.LicenseID.Value);







    }
}



    

