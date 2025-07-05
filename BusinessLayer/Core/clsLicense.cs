using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using static BusinessLayer.Core.clsApplication;
using static BusinessLayer.Core.clsLicenseClass;

namespace BusinessLayer.Core
{
    public class clsLicense
    {
        public enum enIssueReason
        { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }

        public int? LicenseID { get; set; }  

        public int ApplicationID { get; set; } = default;
        public clsApplication Application { get; set; }

        public int DriverID { get; set; } = default;
        public clsDriver Driver { get; set; }

        public int LicenseClass { get; set; } = (int)enLicenseClassID.Class3OrdinaryDrivingLicense;
        public clsLicenseClass LicenseClassInfo { get; set; }

        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;

        public string Notes { get; set; } = string.Empty;
        public decimal PaidFees { get; set; } = default;
        public bool IsActive { get; set; } = false;

        public int IssueReason { get; set; } = (int)enIssueReason.FirstTime;

        public string IssueReasonText => GetIssueReasonText(IssueReason);

        public int CreatedByUserID { get; set; } = default;
        public clsUser User { get; set; }

        public int LoggedUserID { get; set; } = default;

        public enum enMode { AddNew, Update }
        protected enMode Mode;

        public static bool operator <(clsLicense license, DateTime date) => license.ExpirationDate < date;
        public static bool operator >(clsLicense license, DateTime date) => license.ExpirationDate > date;

        public clsLicense()
        {
            Application = new clsApplication();
            Driver = new clsDriver();
            LicenseClassInfo = new clsLicenseClass();
            User = new clsUser();
            Mode = enMode.AddNew;
        }

        protected clsLicense(int? licenseID, int applicationID, int driverID,
            enLicenseClassID licenseClass, DateTime issueDate,
            DateTime expirationDate, string notes, decimal paidFees, bool isActive,
            enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            Application = clsApplication.GetApplicationByID(ApplicationID);
            DriverID = driverID;
            Driver = clsDriver.GetByDriverID(DriverID);
            LicenseClass = (int)licenseClass;
            LicenseClassInfo = clsLicenseClass.GetByID((int)LicenseClass);
            IsActive = isActive;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IssueReason = (int)issueReason;
            Notes = notes;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            User = clsUser.GetByID(CreatedByUserID);

            Mode = enMode.Update;

        }

        private bool _AddLicense()
        {
            LicenseID = clsLicenseData.AddLicenseExistedDriver(
                DriverID,
                (int)LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (int)IssueReason,
                CreatedByUserID,
                LoggedUserID
            );

            return LicenseID != null;
        }
        

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicenseByID(
                LicenseID.Value,
                Notes,
                IsActive,
                LoggedUserID
            );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateLicense();
                default:
                    return false;
            }
        }
        public static bool HasPersonActiveLicensePerLicenseClass(int PersonID, int LicenseClassID)
            => GetActiveLicenseIDByPersonIDForLicenseClass(PersonID, LicenseClassID) != null;
        public static int? GetActiveLicenseIDByPersonIDForLicenseClass(int PersonID, int LicenseClassID)
            => clsLicenseData.GetActiveLicenseIDByPersonIDPerLicenseClass(PersonID, LicenseClassID);
        public static bool IsExist(int? licenseID)
            => licenseID.HasValue && clsLicenseData.IsExistedByID(licenseID.Value);

        public static clsLicense GetByID(int? licenseID)
        {
            if (!licenseID.HasValue)
                return null;
            DataTable dt = clsLicenseData.GetByLicenseID(licenseID.Value);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            return new clsLicense(
                licenseID: row["LicenseID"].ToInt32(),
                applicationID: row["ApplicationID"].ToInt32(),
                driverID: row["DriverID"].ToInt32(),
                licenseClass: (enLicenseClassID)row["LicenseClass"].ToInt32(),
                issueDate: row["IssueDate"].ToDate(),
                expirationDate: row["ExpirationDate"].ToDate(),
                notes: row["Notes"].ToString() ?? string.Empty,
                paidFees: row["PaidFees"].ToDecimal(),
                isActive: row["IsActive"].ToBoolean(),
                issueReason: (enIssueReason)row["IssueReason"].ToInt32(),
                createdByUserID: row["CreatedByUserID"].ToInt32()
            );
        }

        public static DataTable GetAllLicensesList()
            => clsLicenseData.GetAllLicensesList();
        private int GetIssueReason(enApplicationType ApplicationTypeID)
        {
            switch (ApplicationTypeID)
            {
                case enApplicationType.RenewDrivingLicenseService:
                    {
                        return (int)enIssueReason.Renew;
                    }
                case enApplicationType.ReplacementForDamagedDrivingLicense:
                    {
                        return (int)enIssueReason.ReplacementForDamaged;
                    }
                case enApplicationType.ReplacementForLostDrivingLicense:
                    {
                        return (int)enIssueReason.ReplacementForLost;
                    }
                default:
                    return 2;
            }
        }
        private int? UpdateOldLicense(int ApplicationTypeID,
            int CreatedByUserID, int LoggedUserID, int PenaltyPoints)
        {
            ///Parameters are also for New License in addition to:
            int IssueReason = GetIssueReason((enApplicationType)ApplicationTypeID);
            decimal LicensePaidFees = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID);
            decimal ApplicationPaidFees = clsApplicationType.GetByID(ApplicationTypeID).ApplicationFees;
            DateTime ApplicationDate = DateTime.Now;
            DateTime ApplicationLastStatusDate = ApplicationDate;
            //All Application Types will be completed after performing this method::enum value = 3
            int ApplicationStatus = (int)enApplicationStatus.Completed;
            int DefaultValidityLength = (int)clsLicenseClass.GetByID((int)LicenseClass).DefaultValidityLength;
            string LicenseNotes = Notes;
            DateTime LicenseExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            int? OldLicenseID = clsLicenseData.RenewOrReplaceOldLicense(Application.ApplicantPersonID, ApplicationDate,
                ApplicationTypeID, ApplicationStatus, ApplicationLastStatusDate, ApplicationPaidFees, CreatedByUserID,
                LicenseExpirationDate, LicenseNotes, LicensePaidFees, DriverID,(int)LicenseClass, IssueReason, LoggedUserID,PenaltyPoints);
            return OldLicenseID.HasValue?OldLicenseID:null;
        }
        public int? IssueLicenseFirstTime(int ApplicationID,int PersonID, int LicenseClass,
           DateTime IssueDate, DateTime ExpirationDate, string Notes,
           decimal PaidFees, bool IsActive, int CreatedByUserID, int LoggedUserID)
        {
            return clsLicenseData.IssueLicenseFirstTime(ApplicationID, PersonID,  LicenseClass,
            IssueDate,  ExpirationDate,  Notes,
            PaidFees,  IsActive,  CreatedByUserID,  LoggedUserID);
        }

        public int? Renew(int CreatedByUserID, int PenaltyPoints)
        {
            LoggedUserID = CreatedByUserID;
            int ApplicationTypeID = (int)enApplicationType.RenewDrivingLicenseService;
            return UpdateOldLicense(ApplicationTypeID,
                CreatedByUserID, LoggedUserID, PenaltyPoints) ;
        }
        public int? ReplaceForLost(int CreatedByUserID, int PenaltyPoints)
        {
            LoggedUserID = CreatedByUserID;
            int ApplicationTypeID = (int)enApplicationType.ReplacementForLostDrivingLicense;
            return UpdateOldLicense( ApplicationTypeID,CreatedByUserID, LoggedUserID, PenaltyPoints) ;

        }
        public int? ReplaceForDamaged(int CreatedByUserID, int PenaltyPoints)
        {
            LoggedUserID = CreatedByUserID;
            int ApplicationTypeID = (int)enApplicationType.ReplacementForDamagedDrivingLicense;
            return  UpdateOldLicense(ApplicationTypeID,CreatedByUserID, LoggedUserID, PenaltyPoints);

        }
        public static string GetIssueReasonText(int reason)
        {
            return (enIssueReason)reason switch
            {
                enIssueReason.FirstTime => "FirstTime",
                enIssueReason.Renew => "UpdateOldLicense",
                enIssueReason.ReplacementForLost => "ReplacementForLost",
                _ => "ReplacementForDamaged",
            };
        }
        public int? Detain(decimal PaidFees, int CreatedByUserID)
        {
            clsDetainedLicense Detained = new clsDetainedLicense();
            Detained.DetainDate = DateTime.Now;
            Detained.FineFees = PaidFees;
            Detained.CreatedByUserID = CreatedByUserID;
            Detained.LicenseID = LicenseID.Value;
            Detained.IsReleased = false;
            Detained.LoggedUserID = CreatedByUserID;//Detain User
            return Detained.Save() ? Detained.DetainID : null;
        }

        public bool IsDateExpired() => this < DateTime.Now;
        public bool Activate() => clsLicenseData.ActivateLicenseByID(LicenseID.Value, LoggedUserID);
        public bool Deactivate() => clsLicenseData.DeactivateLicenseByID(LicenseID.Value, LoggedUserID);
        public bool IsLicenseDetained() => clsDetainedLicenseData.IsLicenseDetainedByID(LicenseID.Value);
        public bool HasIssuedActiveInternationalLicense() => clsLicenseData.HasIssuedActiveInternationalLicense(LicenseID.Value);
    }
}
