
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCountry
    {
        public int? CountryID { get; set; }
        public string CountryName { get; set; }
        public clsCountry()
        {
            this.CountryID = null;
            this.CountryName = string.Empty;
        }
        protected clsCountry(int? CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        
        public static DataTable GetAllCountriesList()
        => clsCountryData.GetAllCountriesList();
        public static clsCountry GetByID(int? CountryID)
        {
            if (!CountryID.HasValue) return null;

            DataTable dt = clsCountryData.GetCountryDataByID(CountryID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsCountry(
                CountryID: row["CountryID"].ToNullableInt32(),
                CountryName: row["CountryName"]?.ToString() ?? string.Empty
            );
        }

        public static clsCountry GetByName(string CountryName)
        {
            if (string.IsNullOrEmpty(CountryName)) return null;

            DataTable dt = clsCountryData.GetCountryDataByName(CountryName);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsCountry(
                CountryID: row["CountryID"].ToNullableInt32(),
                CountryName: row["CountryName"]?.ToString() ?? string.Empty
            );
        }


    }
}
