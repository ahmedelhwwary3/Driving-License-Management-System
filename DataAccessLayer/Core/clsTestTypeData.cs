using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsTestTypeData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllTestTypesList()
            => DBManager?.ExecuteDataTable("sp_GetAllTestTypes");

        public static bool IsExistByID(int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);

            object result = DBManager?.ExecuteScalar("sp_IsTestTypeExistedByID", parameters);
            return result.ToBoolean();
        }

        public static bool IsExistedByTitle(string TestTypeTitle)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeTitle", TestTypeTitle);

            object result = DBManager?.ExecuteScalar("sp_IsTestTypeExistedByTitle", parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByID(int TestTypeID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);

            return DBManager?.ExecuteDataTable("sp_GetTestTypeByID", parameters);
        }

        public static int? AddTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeTitle", TestTypeTitle);
            parameters?.AddSQLParameter("@TestTypeDescription", TestTypeDescription);
            parameters?.AddSQLParameter("@TestTypeFees", TestTypeFees);
            parameters?.AddLoggedUserID(LoggedUserID);

            object id = DBManager?.ExecuteScalar("sp_AddTestType", parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateTestTypeByID(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters?.AddSQLParameter("@TestTypeID", TestTypeID);
            parameters?.AddSQLParameter("@TestTypeTitle", TestTypeTitle);
            parameters?.AddSQLParameter("@TestTypeDescription", TestTypeDescription);
            parameters?.AddSQLParameter("@TestTypeFees", TestTypeFees);
            parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateTestTypeByID", parameters) ?? false;
        }
    }
}
