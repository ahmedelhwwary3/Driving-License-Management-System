using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsCountry
    {
        public int? CountryID { get; set; }

        [MaxLength(50)]
        public string CountryName { get; set; }

        public clsCountry()
        {
            CountryID = null;
            CountryName = string.Empty;
        }

        protected clsCountry(int? CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountriesList()
            => clsCountryData.GetAllCountriesList();

        public static clsCountry GetByID(int CountryID)
        {
            DataTable dt = clsCountryData.GetCountryDataByID(CountryID);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsCountry(
                CountryID: row["CountryID"].ToInt32(),
                CountryName: row["CountryName"]?.ToString() ?? string.Empty
            );
        }

        public static clsCountry GetByName(string CountryName)
        {
            if (string.IsNullOrWhiteSpace(CountryName))
                return null;

            DataTable dt = clsCountryData.GetCountryDataByName(CountryName);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsCountry(
                CountryID: row["CountryID"].ToInt32(),
                CountryName: row["CountryName"]?.ToString() ?? string.Empty
            );
        }
    }
}
