using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class clsApplicationTypeData
    {

        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static bool IsExistedByID(int ApplicationTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            object Result = DBManager.ExecuteScalar("sp_IsApplicationTypeExistedByID", map);
            return Result.ToBoolean();
        }

        public static DataTable GetByID(int ApplicationTypeID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationTypeID", ApplicationTypeID);

            return DBManager.ExecuteDataTable("sp_GetApplicationTypeByID", map);
        }

        public static DataTable GetAllApplicationTypesList()
        {

            return DBManager.ExecuteDataTable("sp_GetAllApplicationTypes");

        }

        public static int? AddNewApplicationType(string ApplicationTypeTitle
            , decimal ApplicationTypeFees,int LoggedUserID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationTypeTitle", ApplicationTypeTitle);
            map?.Add("@ApplicationFees", ApplicationTypeFees);
            map?.AddLoggedUserID(LoggedUserID);
            object ID = DBManager.ExecuteScalar("sp_AddApplicationType", map);
            return ID.ToNullableInt();
        }

        public static bool UpdateApplicationTypeByID(int ApplicationTypeID, 
            string ApplicationTypeTitle, decimal ApplicationFees,int LoggedUserID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@ApplicationTypeTitle", ApplicationTypeTitle);
            map?.Add("@ApplicationTypeID", ApplicationTypeID);
            map?.Add("@ApplicationFees", ApplicationFees);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdateApplicationTypeByID", map);
        }

        
    }
}
