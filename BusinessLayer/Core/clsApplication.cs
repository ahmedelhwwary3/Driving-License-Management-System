using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    /// <summary>
    /// Base Application class
    /// This class will be inherited fron the other sub applications
    /// </summary>
    [Description("This class is for Any Application for any service.")]
    public class clsApplication
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2, ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6, RetakeTest = 7
        };

        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public int? ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson Person { get; set; }//Composition
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationType;
        public int ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser;
        public decimal PaidFees { get; set; }
        public int LoggedUserID { get; set; }
        /// <summary>
        /// Computed Property 
        /// Read Only
        /// </summary>
        public string ApplicationStatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case (int)enApplicationStatus.New:
                        {
                            return "New";
                        }
                    case (int)enApplicationStatus.Completed:
                        {
                            return "Completed";
                        }
                    case (int)enApplicationStatus.Cancelled:
                        {
                            return "Cancelled";
                        }
                    default:
                        return "Unknown";
                }

            }
        }

        public clsApplication()
        {
            LoggedUserID = default;
            ApplicationID = null;
            ApplicantPersonID = default;
            Person = new clsPerson();
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = (int)enApplicationType.NewLocalDrivingLicenseService;
            ApplicationStatus = (int)enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            CreatedByUserID = default;
            CreatedByUser = new clsUser();
            PaidFees = 0;


            Mode = enMode.AddNew;
        }
        //protected For Inheritance
        protected clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, int CreatedByUserID, decimal PaidFees)
        {
            LoggedUserID = default;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            Person = clsPerson.GetByID(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            ApplicationType = clsApplicationType.GetByID(this.ApplicationTypeID);
            this.ApplicationStatus = (int)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.CreatedByUserID = CreatedByUserID;
            CreatedByUser = clsUser.GetByID(CreatedByUserID);
            this.PaidFees = PaidFees;
            Mode = enMode.Update;
        }
        private bool _AddNewApplication()
        {

            {
                ApplicationID = clsApplicationData.AddApplication(
                    ApplicantPersonID,
                    (int)ApplicationTypeID,
                    ApplicationDate,
                    (int)ApplicationStatus,
                    LastStatusDate,
                    CreatedByUserID,
                    PaidFees,
                    LoggedUserID
                );
            }

            return ApplicationID.HasValue;
        }
        private bool _UpdateApplication()
        {
            if (!ApplicationID.HasValue)
            {
                return false;
            }

            return clsApplicationData.UpdateApplication(
                    ApplicationID.Value,
                    ApplicantPersonID,
                    (int)ApplicationTypeID,
                    ApplicationDate,
                    (int)ApplicationStatus,
                    LastStatusDate,
                    CreatedByUserID,
                    PaidFees,
                    LoggedUserID
               );
        }



        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }
                default:
                    break;
            }
            return false;
        }
        public static bool IsExistedByID(int? ApplicationID)
            => ApplicationID.HasValue && clsApplicationData.IsExistedByID(ApplicationID.Value);

        public static clsApplication GetApplicationByID(int? ApplicationID)
        {
            if (!ApplicationID.HasValue)
                return null;
            DataTable dt = clsApplicationData.GetApplictionByID(ApplicationID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new clsApplication(
                ApplicationID: row["ApplicationID"].ToInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToInt32(),
                ApplicationDate: row["ApplicationDate"].ToDate(),
                ApplicationStatus: (enApplicationStatus)row["ApplicationStatus"].ToInt32(),
                ApplicationTypeID: (enApplicationType)row["ApplicationTypeID"].ToInt32(),
                CreatedByUserID: row["CreatedByUserID"].ToInt32(),
                LastStatusDate: row["LastStatusDate"].ToDate(),
                PaidFees: row["PaidFees"].ToDecimal()
            );

        }
        public static DataTable GetAllApplicationsList()
            => clsApplicationData.GetAllApplicationsList();
        public static bool DeleteApplication(int ApplicationID, int LoggedUserID)
            => clsApplicationData.DeleteApplicationByID(ApplicationID, LoggedUserID);
        public static bool DoesPersonHaveActiveApplication(int PersonID, enApplicationType ApplicationTypeID)
            => clsApplicationData.DoesPersonHaveActiveApplicationPerType(PersonID, (int)ApplicationTypeID);
        public static bool HasActiveApplicationForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
            => clsApplicationData.DoesPersonHaveActiveLocalApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        public bool UpdateStatus(int NewStatus, int LoggedUserID)
            => ApplicationID.HasValue && clsApplicationData.UpdateApplicationStatusByID(ApplicationID.Value, NewStatus, LoggedUserID);
        public bool Cancel(int LoggedUserID)
            => ApplicationID.HasValue && clsApplicationData.UpdateApplicationStatusByID(
                ApplicationID.Value, (int)enApplicationStatus.Cancelled, LoggedUserID);
        
    }
}
