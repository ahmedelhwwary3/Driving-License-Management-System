using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsApplicationTypeData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static bool IsExistedByID(int ApplicationTypeID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);

            object result = DBManager?.ExecuteScalar("sp_IsApplicationTypeExistedByID", Parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByID(int ApplicationTypeID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);

            return DBManager?.ExecuteDataTable("sp_GetApplicationTypeByID", Parameters);
        }

        public static DataTable GetAllApplicationTypesList()
            => DBManager?.ExecuteDataTable("sp_GetAllApplicationTypes");

        public static int? AddNewApplicationType(string ApplicationTypeTitle, decimal ApplicationTypeFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();       
            Parameters?.AddSQLParameter("@ApplicationTypeTitle", ApplicationTypeTitle);
            Parameters?.AddSQLParameter("@ApplicationFees", ApplicationTypeFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object result = DBManager?.ExecuteScalar("sp_AddApplicationType", Parameters);
            return result.ToNullableInt32();
        }

        public static bool UpdateApplicationTypeByID(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationTypeTitle", ApplicationTypeTitle);
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            Parameters?.AddSQLParameter("@ApplicationFees", ApplicationFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateApplicationTypeByID", Parameters) ?? false;
        }
    }
}
