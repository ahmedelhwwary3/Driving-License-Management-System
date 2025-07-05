using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Core
{
    public static class clsApplicationData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllApplicationsList()
             => DBManager?.ExecuteDataTable("sp_GetAllApplicationsData");
        //SqlParameter is (1 or Null) and this is so better than Bringing the Full SqlParameter       
        public static bool IsExistedByID(int ApplicationID)
        {
            var Parameters=new HashSet<SqlParameter>();
            Parameters.AddSQLParameter("@ApplicationID", ApplicationID);
            object Result = DBManager?.ExecuteScalar("sp_IsApplicationExisted", Parameters);

            return Result.ToBoolean();
        }
        //SqlParameter is better than ref params (maintainable,Flixible,cleaner,readable) but costs a little overhead as you must create SqlParameter of Entity to catch it instead of getting it directly..but this overhead is negligible and SqlParameter only used for OnTheFly small Apps for learning
        public static DataTable GetApplictionByID(int ApplicationID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters.AddSQLParameter("@ApplicationID", ApplicationID);

            return DBManager?.ExecuteDataTable("sp_GetApplicationByID", Parameters);
        }
        //If you do not want to get ID => use NonQuery() for AffRows only
        public static int? AddApplication(int ApplicantPersonID, int ApplicationTypeID,
            DateTime ApplicationDate, int ApplicationStatus, DateTime LastStatusDate,
            int CreatedByUserID, decimal PaidFees, int LoggedUserID)
        {

            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicantPersonID", ApplicantPersonID);
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            Parameters?.AddSQLParameter("@ApplicationDate", ApplicationDate);
            Parameters?.AddSQLParameter("@ApplicationStatus", ApplicationStatus);
            Parameters?.AddSQLParameter("@LastStatusDate", LastStatusDate);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddLoggedUserID(LoggedUserID);
            object ID= DBManager?.ExecuteScalar("sp_AddApplication", Parameters);
            return ID.ToNullableInt32();
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID,
            int ApplicationTypeID, DateTime ApplicationDate, int ApplicationStatus,
            DateTime LastStatusDate, int CreatedByUserID, decimal PaidFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            Parameters?.AddSQLParameter("@ApplicantPersonID", ApplicantPersonID);
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            Parameters?.AddSQLParameter("@ApplicationDate", ApplicationDate);
            Parameters?.AddSQLParameter("@ApplicationStatus", ApplicationStatus);
            Parameters?.AddSQLParameter("@LastStatusDate", LastStatusDate);
            Parameters?.AddSQLParameter("@CreatedByUserID", CreatedByUserID);
            Parameters?.AddSQLParameter("@PaidFees", PaidFees);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateApplicationByID", Parameters);
        }
        public static bool DeleteApplicationByID(int ApplicationID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateApplicationByID", Parameters);
        }
        //For any Application Type(NewLocal-Renew-Retake-Release...)
        public static int? GetPersonActiveApplicationIDPerType(int ApplicantPersonID, int ApplicationTypeID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicantPersonID", ApplicantPersonID);
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            object Result = DBManager?.ExecuteScalar("sp_GetActiveApplicationIDPerType", Parameters);
            return Result.ToNullableInt32();
        }
        //General Application Type (Local,Renew,Release...) :: not used with Local as Local can have many Active Applications with different Class Types
        public static bool DoesPersonHaveActiveApplicationPerType(int PersonID, int ApplicationTypeID)
            => GetPersonActiveApplicationIDPerType(PersonID, ApplicationTypeID) != null;
        //Specefied Application Type (Local Only) but for Specefied Class
        public static int? GetActiveApplicationIDForLicenseClass_Local(int ApplicantPersonID, int LicenseClassID)
        {

            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicantPersonID", ApplicantPersonID);
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            Parameters?.AddSQLParameter("@ApplicationTypeID", 1);
            object Result = DBManager?.ExecuteScalar("sp_GetActivePersonLocalApplicationIDForLicenseClass", Parameters);
            return Result.ToNullableInt32();

        }
        //For Only Application Type=(NewLocal)
        public static bool DoesPersonHaveActiveLocalApplicationIDForLicenseClass(int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID)
            => GetActiveApplicationIDForLicenseClass_Local(ApplicantPersonID, LicenseClassID) != null;
        public static bool UpdateApplicationStatusByID(int ApplicationID, int NewStatus, int LoggedUserID)
        {

            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationStatus", NewStatus);
            Parameters?.AddSQLParameter("@ApplicationID", ApplicationID);
            Parameters?.AddSQLParameter("@LastStatusDate", DateTime.Now);
            Parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdateApplicationStatusByID", Parameters);
        }




    }
}
