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
    public static class clsTestAppointmentData
    {


        static clsDBManager DBManager=clsDataAccessSettings.DBManager;
        public static DataTable GetAllTestAppointmentsLForLocalApp_AllTypes(int LocalDrivingLicenseApplicationID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            return DBManager.ExecuteDataTable("sp_GetAllTestAppointmentsLForLocalApp_AllTypes",map);

        }

        public static DataTable GetAllTestAppointmentsForLocalApp_PerType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            return DBManager.ExecuteDataTable("sp_GetAllTestAppointmentsLForLocalApp_PerType",map);

        }

        public static DataTable GetLastTestAppointmentDataByLocalAppID_PerType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            return DBManager.ExecuteDataTable("sp_GetLastTestAppointmentDataByLocalAppID_PerType", map);
        }

        public static bool IsExistedByID(int TestAppointmentID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestAppointmentID", TestAppointmentID);
            object Result = DBManager.ExecuteScalar("sp_IsAppointmentExistedByID", map);
            return Result.ToBoolean();
        }
        public static DataTable GetByID(int TestAppointmentID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestAppointmentID", TestAppointmentID);

            return DBManager.ExecuteDataTable("sp_FindTestAppointmentByID", map);
        }

        public static int? AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, 
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID,
            bool IsLocked, Nullable <int >RetakeTestApplicationID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestTypeID", TestTypeID);
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@AppointmentDate", AppointmentDate);
            map?.Add("@PaidFees", PaidFees);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@IsLocked", IsLocked);
            if(RetakeTestApplicationID.HasValue)
                map?.Add("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                map?.Add("@RetakeTestApplicationID", DBNull.Value);
            map?.AddLoggedUserID(LoggedUserID);
            object ID = DBManager.ExecuteScalar("sp_AddTestAppointment", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateTestAppointmentByID(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, 
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            map?.Add("@TestTypeID", TestTypeID);
            map?.Add("@AppointmentDate", AppointmentDate);
            map?.Add("@PaidFees", PaidFees);
            map?.Add("@CreatedByUserID", CreatedByUserID);
            map?.Add("@IsLocked", IsLocked);
            if (RetakeTestApplicationID.HasValue)
                map?.Add("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                map?.Add("@RetakeTestApplicationID", DBNull.Value);
            map?.Add("@TestAppointmentID", TestAppointmentID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateTestAppointmentByID", map);
        }

        public static bool DeleteTestAppointmentByID(int TestAppointmentID,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@LocalDrivingLicenseApplicationID", TestAppointmentID);
            map?.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_DeleteTestAppointmentByID", map);
        }
        //Test is much High level than Appointment ..Test has Appointment + another Details
        public static int? GetTestIDByAppointmentID(int TestAppointmentID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@TestAppointmentID", TestAppointmentID);         

            Object Result = DBManager.ExecuteScalar("sp_GetTestIDByAppointmentID", map);
            return Result.ToNullableInt();
        }






    }
}
