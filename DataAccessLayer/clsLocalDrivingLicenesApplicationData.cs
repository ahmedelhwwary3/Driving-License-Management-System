using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// The Most Logic is here ......
    /// </summary>
    public static class clsLocalDrivingLicenseApplicationData
    {
        static clsDBManager DBManager=clsDataAccessSettings.DBManager;
        public static DataTable GetAllLocalDrivingLicenseApplicationsList()
        {
        
            return DBManager.ExecuteDataTable("sp_GetAllLocalDrivingLicenseApplicationsList");

        }

        public static bool IsExistByID(int LocalDrivingLicenseApplicationID)
        {

            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object Result = DBManager.ExecuteScalar("sp_IsLocalDrivingLicenseApplicationExistedByID", map);
            return Result.ToBoolean();
        }

        public static DataTable GetByID(int LocalDrivingLicenseApplicationID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            return DBManager.ExecuteDataTable("sp_GetLocalDrivingLicenseApplicationByID", map);
        }

        public static DataTable GetByBaseApplicationID(int ApplicationID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationID", ApplicationID);

            return DBManager.ExecuteDataTable("sp_GetLocalDrivingLicenseApplicationByApplicationID", map);

        }

        public static int? AddLocalDrivingLicenseApplication(int LicenseClassID,
            int ApplicationID,int LoggedUserID)
        {   
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.Add("@ApplicationID", ApplicationID);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID = DBManager.ExecuteScalar("sp_AddLocalDrivingLicenseApplication", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID,
            int LicenseClassID, int ApplicationID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@LicenseClassID", LicenseClassID);
            map?.Add("@ApplicationID", ApplicationID);
            map?.Add("@LoggedUserID", LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateLocalDrivingLicenseApplicationByID", map);
        }

        public static bool DeleteLocalDrivingLicenseApplicationByID(
            int LocalDrivingLicenseApplicationID,int LoggedUserID)
        {

            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@LoggedUserID", LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeleteLocalDrivingLicenseApplicationByID", map);

        }

        public static bool HasLocalDrivingLicenseApplicationPassedTestTypeTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            Object Result = DBManager.ExecuteScalar("sp_HasLocalDrivingLicenseApplicationPassedTestType", map);
            return Result.ToBoolean();

        }

        public static bool HasAttendedTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            Object Result = DBManager.ExecuteScalar("sp_HasLocalDrivingLicenseApplicationAttendedTestType", map);
            return Result.ToBoolean();

        }

        public static int? GetTotalTrialsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            object Count = DBManager.ExecuteScalar("sp_GetTotalTrialsPerTestType", map);
            return Count.ToNullableInt();

        }

        public static int? GetActiveScheduledTestID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            object ID = DBManager.ExecuteScalar("sp_GetActiveScheduledTestID", map);
            return ID.ToNullableInt();

        }
        //No need to create new SP as the result is (ID int) so small in size (not full object)
        public static bool HasActiveScheduledTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return (GetActiveScheduledTestID(LocalDrivingLicenseApplicationID, TestTypeID) !=null);
        }

        public static int? GetAllPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
             
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            object Count = DBManager.ExecuteScalar("sp_GetAllPassedTestCount", map);
            return Count.ToNullableInt();
        }

        public static bool DoesPassAllTestTypes(int LocalDrivingLicenseApplicationID)
        {
            return (GetAllPassedTestsCount(LocalDrivingLicenseApplicationID) == 3);
        }

        public static int? GetAnyActiveLicenseID(int LocalDrivingLicenseApplicationID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();

            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Object ID = DBManager.ExecuteScalar("[sp_GetAnyActiveLicenseIDByLocalApplicationID]", map);
            return ID.ToNullableInt();
        }
        public static int? GetActiveLocalLicenseID(int LocalDrivingLicenseApplicationID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Object ID = DBManager.ExecuteScalar("sp_GetActiveLocalLicenseIDByLocalApplicationID", map);
            return ID.ToNullableInt();
        }











    }
}
