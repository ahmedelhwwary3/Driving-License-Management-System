using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class clsCountryData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllCountriesList()
        {
            //sp_GetAllCountries
            return DBManager.ExecuteDataTable("sp_GetAllCountriesData");
        }

        public static DataTable GetCountryDataByID(int CountryID)
        {
 
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@CountryID", CountryID);

            return DBManager.ExecuteDataTable("sp_GetCountryDataByID", map);

        }
        public static DataTable GetCountryDataByName(string CountryName)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@CountryName", CountryName);
           
            return DBManager.ExecuteDataTable("sp_GetCountryDataByName", map);
        }
    }
}
