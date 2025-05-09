using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class clsApplicationData
    {
        static readonly clsDBManager DBManager=clsDataAccessSettings.DBManager;
        public static DataTable GetAllApplicationsList()
        {
            return DBManager.ExecuteDataTable("sp_GetAllApplicationsData");
        }
        //object is (1 or Null) and this is so better than Bringing the Full object       
        public static bool IsExistedByID(int ApplicationID)
        {
            Dictionary<string,object>map= new Dictionary<string,object>();
            map?.Add("@ApplicationID", ApplicationID);
            object Result = DBManager.ExecuteScalar("sp_IsApplicationExisted", map);
            return Result.ToBoolean();
        }
        //object is better than ref params (maintainable,Flixible,cleaner,readable) but costs a little overhead as you must create object of Entity to catch it instead of getting it directly..but this overhead is negligible and object only used for OnTheFly small Apps for learning
        public static DataTable GetApplictionByID(int ApplicationID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);
         
            return DBManager.ExecuteDataTable("sp_GetApplicationByID", map);
        }
        //If you do not want to get ID => use NonQuery() for AffRows only
        public static Nullable<int> AddApplication(int ApplicantPersonID, int ApplicationTypeID,
            DateTime ApplicationDate, int ApplicationStatus, DateTime LastStatusDate,
            int CreatedByUserID,decimal PaidFees,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicantPersonID", ApplicantPersonID);
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            map?.Add("@ApplicationDate", ApplicationDate);
            map?.Add("@ApplicationStatus", ApplicationStatus);
            map?.Add("@LastStatusDate", LastStatusDate);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@PaidFees", PaidFees);
            map?.AddLoggedUserID(LoggedUserID);
            object ID = DBManager.ExecuteScalar("sp_AddApplication", map);
            return ID.ToNullableInt();
        }
        public static Boolean UpdateApplication(int ApplicationID, int ApplicantPersonID,
            int ApplicationTypeID, DateTime ApplicationDate, int ApplicationStatus,
            DateTime LastStatusDate, int CreatedByUserID, decimal PaidFees, int LoggedUserID )
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicantPersonID", ApplicantPersonID);
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            map?.Add("@ApplicationDate", ApplicationDate);
            map?.Add("@ApplicationStatus", ApplicationStatus);
            map?.Add("@LastStatusDate", LastStatusDate);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@PaidFees", PaidFees);
            map?.AddLoggedUserID(LoggedUserID);
            map?.Add("@ApplicationID",ApplicationID);
            return DBManager.ExecuteNonQuery("sp_UpdateApplicationByID", map);
        }
        public static bool DeleteApplicationByID(int ApplicationID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateApplicationByID", map);
        }
        //For any Application Type(NewLocal-Renew-Retake-Release...)
        public static Nullable<int> GetPersonActiveApplicationIDPerType(int ApplicantPersonID, int ApplicationTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicantPersonID", ApplicantPersonID);
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            
            int? Result = DBManager.ExecuteScalar("sp_GetActiveApplicationIDPerType", map) as Nullable<int>;
            return Result.ToNullableInt();
        }
        //General Application Type (Local,Renew,Release...) :: not used with Local as Local can have many Active Applications with different Class Types
        public static bool DoesPersonHaveActiveApplicationPerType(int PersonID, int ApplicationTypeID)
        {
            return (GetPersonActiveApplicationIDPerType(PersonID,ApplicationTypeID)!=null);
        }
        //Specefied Application Type (Local Only) but for Specefied Class
        public static int? GetActiveApplicationIDForLicenseClass_Local(int ApplicantPersonID,int LicenseClassID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicantPersonID", ApplicantPersonID);
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.Add("@ApplicationTypeID", 1);
            int? Result = DBManager.ExecuteScalar("sp_GetActivePersonLocalApplicationIDForLicenseClass", map) as Nullable<int>;
            return Result.ToNullableInt();

        }
        //For Only Application Type=(NewLocal)
        public static bool DoesPersonHaveActiveLocalApplicationIDForLicenseClass(int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return (GetActiveApplicationIDForLicenseClass_Local(ApplicantPersonID,LicenseClassID) != null);
        }
        public static bool UpdateApplicationStatusByID(int ApplicationID,int NewStatus,int LoggedUserID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationStatus", NewStatus);
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@LastStatusDate", DateTime.Now);
            map?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdateApplicationStatusByID", map);
        }




    }
}
