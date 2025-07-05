using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsLicenseClassData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllLicenseClassesList()
            => DBManager?.ExecuteDataTable("sp_GetAllLicenseClassesData");

        public static bool IsExistByID(int LicenseClassID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            object result = DBManager?.ExecuteScalar("sp_IsLicenseClassExistedByID", Parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByName(string ClassName)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ClassName", ClassName);
            return DBManager?.ExecuteDataTable("sp_GetLicenseClassDataByName", Parameters);
        }

        public static DataTable GetByID(int LicenseClassID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            return DBManager?.ExecuteDataTable("sp_GetLicenseClassDataByID", Parameters);
        }

        public static int? AddLicenseClass(string ClassName, string ClassDescription,
            int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ClassName", ClassName);
            Parameters?.AddSQLParameter("@ClassDescription", ClassDescription);
            Parameters?.AddSQLParameter("@MinimumAllowedAge", MinimumAllowedAge);
            Parameters?.AddSQLParameter("@DefaultValidityLength", DefaultValidityLength);
            Parameters?.AddSQLParameter("@ClassFees", ClassFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            object id = DBManager?.ExecuteScalar("sp_AddLicenseClass", Parameters);
            return id.ToNullableInt32();
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            int MinimumAllowedAge, int DefaultValidityLength, decimal ClassFees, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ClassName", ClassName);
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            Parameters?.AddSQLParameter("@ClassDescription", ClassDescription);
            Parameters?.AddSQLParameter("@MinimumAllowedAge", MinimumAllowedAge);
            Parameters?.AddSQLParameter("@DefaultValidityLength", DefaultValidityLength);
            Parameters?.AddSQLParameter("@ClassFees", ClassFees);
            Parameters?.AddLoggedUserID(LoggedUserID);

            return DBManager?.ExecuteNonQuery("sp_UpdateLicenseClassByID", Parameters) ?? false;
        }

        public static bool DeleteLicenseClass(int LicenseClassID, int LoggedUserID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@LicenseClassID", LicenseClassID);
            Parameters?.AddLoggedUserID(LoggedUserID);
            return DBManager?.ExecuteNonQuery("sp_DeleteLicenseClassByID", Parameters) ?? false;
        }
    }
}
