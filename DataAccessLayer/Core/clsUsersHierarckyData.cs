using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsUsersHierarckyData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllUsersHierarckyList()
            => DBManager.ExecuteDataTable("sp_GetAllUsersHierarcky");

        public static int? GetHierarchyIDByName(string Hierarchy)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@Hierarchy", Hierarchy);

            object ID = DBManager.ExecuteScalar("sp_GetHierarchyIDByName", parameters);
            return ID.ToNullableInt32();
        }

        public static string GetHierarchyNameByID(int HierarchyID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@HierarchyID", HierarchyID);

            object result = DBManager.ExecuteScalar("sp_GetHierarchyNameByID", parameters);
            return result?.ToString() ?? string.Empty;
        }

        public static bool HasManagerHigherHierarcky(int ManagerID, int HierarchyID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@HierarchyID", HierarchyID);
            parameters.AddSQLParameter("@ManagerID", ManagerID);

            return DBManager.ExecuteNonQuery("sp_HasManagerHigherHierarcky", parameters);
        }
    }
}
