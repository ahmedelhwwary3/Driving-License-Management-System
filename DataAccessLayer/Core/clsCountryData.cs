using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Core
{
    public static class clsCountryData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllCountriesList()
            => DBManager?.ExecuteDataTable("sp_GetAllCountriesData");

        public static int? AddNewCountry(string CountryName)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@CountryName", CountryName);
            object ID = DBManager?.ExecuteScalar("sp_AddNewCountry", Parameters);
            return ID.ToNullableInt32();

        }
        public static DataTable GetCountryDataByID(int CountryID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@CountryID", CountryID);

            return DBManager?.ExecuteDataTable("sp_GetCountryDataByID", Parameters);
        }

        public static DataTable GetCountryDataByName(string CountryName)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@CountryName", CountryName);

            return DBManager?.ExecuteDataTable("sp_GetCountryDataByName", Parameters);
        }
    }
}
