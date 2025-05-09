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
    public class clsTestData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllTestsList()
        {
            return DBManager.ExecuteDataTable("sp_GetAllTests");
        }

        public static bool IsExist(int TestID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestID", TestID);
            object Result = DBManager.ExecuteScalar("sp_IsTestExistedByID", map);
            return Result.ToBoolean();
        }


        public static int GetLastTestIDByPersonIDPerTestTypeAndLicenseClass(int PersonID, int LicenseClassID, int TestTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.Add("@TestTypeID", TestTypeID);
            int? Result = DBManager.ExecuteScalar("sp_GetLastTestIDByPersonIDPerTestTypeAndLicenseClass", map) as Nullable<int>;
            return Result ?? -1;
        }
        public static DataTable GetTestByID(int TestID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestID", TestID);

            return DBManager.ExecuteDataTable("sp_GetTestByID", map);

        }

        public static int? AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestAppointmentID", TestAppointmentID);
            map?.Add("@TestResult", TestResult);
            map?.Add("@Notes", Notes);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);
            object ID = DBManager.ExecuteScalar("sp_AddTest", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateTestByID(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestID", TestID);
            map?.Add("@TestAppointmentID", TestAppointmentID);
            map?.Add("@TestResult", TestResult);
            map?.Add("@Notes", Notes);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateTestByID", map);
        }

        public static bool DeleteTest(int TestID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestID", TestID);
            map?.Add("@LoggedUserID", LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeleteTestByID", map);
        }

        public static int? GetPassedTestCountPerLocalApplication(int LocalDrivingLicenseApplicationID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
     
            int? Result = DBManager.ExecuteScalar("sp_GetPassedTestCountPerLocalApplication", map) as Nullable<int>;
            return Result.ToNullableInt();
        }
    }
}
