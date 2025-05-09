using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsApplication//Base Application
    {
        //enApplicationStatus (1) :: Active
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType { NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2, ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6, RetakeTest = 7 };

        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public int? ApplicationID { get; set; }
        public int? ApplicantPersonID { get; set; }
        public clsPerson Person {  get; set; }//Composition
        public DateTime ApplicationDate { get; set; }
        public clsApplication.enApplicationType? ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationType;
        public clsApplication.enApplicationStatus? ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUser;
        public decimal PaidFees { get; set; }
        public int? LoggedUserID { get; set; }
        //Computed Property (Read Only)
        public string ApplicationStatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        {
                            return "New";
                        }
                    case enApplicationStatus.Completed:
                        {
                            return "Completed";
                        }
                    case enApplicationStatus.Cancelled:
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
            this.LoggedUserID = null;
            this.ApplicationID = null;
            this.ApplicantPersonID = null;
            this.Person = new clsPerson();
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = enApplicationType.NewLocalDrivingLicenseService;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.CreatedByUserID = null;
            this.CreatedByUser=new clsUser();
            this.PaidFees = 0;
      

            Mode = enMode.AddNew;
        }
        //protected For Inheritance
        protected clsApplication(int? ApplicationID, int? ApplicantPersonID, DateTime ApplicationDate, enApplicationType ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, int? CreatedByUserID, decimal PaidFees)
        {
            var getPerson = new Func<int?, clsPerson>(clsPerson.GetByID);
            var getType = new Func<int?, clsApplicationType>(clsApplicationType.GetByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);

            this.LoggedUserID = null;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.Person = getPerson.GetByNullableID(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = getType.GetByNullableID((int)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUser = getUser.GetByNullableID(CreatedByUserID);
            this.PaidFees = PaidFees;
            Mode = enMode.Update;
        }
        private bool _AddNewApplication()
        {
            if (this.ApplicantPersonID.HasValue
                 && this.CreatedByUserID.HasValue
                 && this.ApplicationTypeID.HasValue
                 && this.ApplicationStatus.HasValue
                 &&this.LoggedUserID.HasValue)
            {
                this.ApplicationID = clsApplicationData.AddApplication(
                    this.ApplicantPersonID.Value,
                    (int)this.ApplicationTypeID.Value,
                    this.ApplicationDate,
                    (int)this.ApplicationStatus.Value,
                    this.LastStatusDate,
                    this.CreatedByUserID.Value,
                    this.PaidFees,
                    this.LoggedUserID.Value
                );
            }

            return this.ApplicationID != null;
        }
        private bool _UpdateApplication()
        {
            if (this.ApplicationID.HasValue
                 && this.ApplicantPersonID.HasValue
                 && this.ApplicationTypeID.HasValue
                 && this.ApplicationStatus.HasValue
                 && this.CreatedByUserID.HasValue
                 &&this.LoggedUserID.HasValue)
            {
               return clsApplicationData.UpdateApplication(
                    this.ApplicationID.Value,
                    this.ApplicantPersonID.Value,
                    (int)this.ApplicationTypeID.Value,
                    this.ApplicationDate,
                    (int)this.ApplicationStatus.Value,
                    this.LastStatusDate,
                    this.CreatedByUserID.Value,
                    this.PaidFees,
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
            =>ApplicationID.HasValue&&clsApplicationData.IsExistedByID(ApplicationID.Value);

        public static clsApplication GetByID(int? ApplicationID)
        {
            if (!ApplicationID.HasValue)
                return null;

            DataTable dt = clsApplicationData.GetApplictionByID(ApplicationID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new clsApplication(
                ApplicationID: row["ApplicationID"].ToNullableInt32(),
                ApplicantPersonID: row["ApplicantPersonID"].ToNullableInt32(),
                ApplicationDate: row["ApplicationDate"].ToDate(),
                ApplicationStatus: row["ApplicationStatus"] != DBNull.Value ? (enApplicationStatus)Convert.ToInt32(row["ApplicationStatus"]) : enApplicationStatus.New,
                ApplicationTypeID: row["ApplicationTypeID"] != DBNull.Value ? (enApplicationType)Convert.ToInt32(row["ApplicationTypeID"]) : enApplicationType.NewLocalDrivingLicenseService,
                CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                LastStatusDate: row["LastStatusDate"] .ToDate(),
                PaidFees: row["PaidFees"].ToDecimal()
            );

        }
        public static DataTable GetAllApplicationsList()
        => clsApplicationData.GetAllApplicationsList();
        public static bool DeleteApplication(int? ApplicationID,int?LoggedUserID)
        => ApplicationID.HasValue && LoggedUserID.HasValue&&
            clsApplicationData.DeleteApplicationByID(ApplicationID.Value, LoggedUserID.Value);
        public static bool DoesPersonHaveActiveApplication(int? PersonID, clsApplication.enApplicationType ApplicationTypeID)
        => PersonID.HasValue && clsApplicationData.DoesPersonHaveActiveApplicationPerType(PersonID.Value, (int)ApplicationTypeID);
        public static bool DoesPersonHaveActiveApplicationForLicenseClass(int? PersonID,clsApplication.enApplicationType ApplicationTypeID,int LicenseClassID)
        => PersonID.HasValue && clsApplicationData.DoesPersonHaveActiveLocalApplicationIDForLicenseClass(PersonID.Value, (int)ApplicationTypeID, LicenseClassID);
        public bool UpdateStatus(int NewStatus,int? LoggedUserID)
        => this.ApplicationID.HasValue&& LoggedUserID.HasValue&& clsApplicationData.UpdateApplicationStatusByID(this.ApplicationID.Value, NewStatus, LoggedUserID.Value);
        public bool Cancel(int? LoggedUserID)
        => this.ApplicationID.HasValue &&LoggedUserID.HasValue&& 
            clsApplicationData.UpdateApplicationStatusByID(this.ApplicationID.Value, (int)enApplicationStatus.Cancelled,LoggedUserID.Value);
        public bool SetCompleted(int? LoggedUserID)
        => this.ApplicationID.HasValue &&LoggedUserID.HasValue&&
            clsApplicationData.UpdateApplicationStatusByID(this.ApplicationID.Value, (int)enApplicationStatus.Completed, LoggedUserID.Value);
        //Type:any type except Local Applications
        public static int? GetActiveApplicationIDPerType_NotLocal(int? PersonID,clsApplication.enApplicationType? ApplicationTypeID)
        => (PersonID.HasValue&& ApplicationTypeID.HasValue)? clsApplicationData.GetPersonActiveApplicationIDPerType(PersonID.Value, (int)ApplicationTypeID.Value):null;
        //Type:Only Local Applications
     


    }

}