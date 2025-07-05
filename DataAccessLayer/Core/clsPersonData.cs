using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Helpers;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Core
{
    public static class clsPersonData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetSubPeopleList(int PageNumber, int RowsPerPage,
            out int TotalCount, int Ranking)
        {
            TotalCount = 0;
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@TotalCount", TotalCount,false);
            parameters.AddSQLParameter("@PageNumber", PageNumber);
            parameters.AddSQLParameter("@RowsPerPage", RowsPerPage);
            parameters.AddSQLParameter("@Ranking", Ranking);
            DataTable dt = DBManager.ExecuteDataTable("sp_GetSubPeopleList", parameters);
            object Outvalue = parameters.ElementAt(0).Value;
            if (Outvalue != DBNull.Value && Outvalue!=null)
                TotalCount = Convert.ToInt32(Outvalue);
            return dt;
        }
        public static DataTable GetAllPeopleList()
            => DBManager.ExecuteDataTable("sp_GetAllPeopleList");
        public static bool IsExistByID(int PersonID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@PersonID", PersonID);
            object result = DBManager.ExecuteScalar("sp_IsPersonExistedByID", parameters);
            return result.ToBoolean();
        }

        public static bool IsExistByNationalNO(string NationalNo)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@NationalNo", NationalNo);
            object result = DBManager.ExecuteScalar("sp_IsPersonExistedByNationalNo", parameters);
            return result.ToBoolean();
        }

        public static DataTable GetByID(int PersonID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@PersonID", PersonID);
            return DBManager.ExecuteDataTable("sp_GetPersonByPersonID", parameters);
        }

        public static DataTable GetByNationalNo(string NationalNo)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@NationalNo", NationalNo);
            return DBManager.ExecuteDataTable("sp_GetPersonByNationalNo", parameters);
        }

        public static int? AddNewPerson(string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, int Gendor, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@NationalNo", NationalNo);
            parameters.AddSQLParameter("@FirstName", FirstName);
            parameters.AddSQLParameter("@SecondName", SecondName);
            parameters.AddSQLParameter("@ThirdName", ThirdName);
            parameters.AddSQLParameter("@LastName", LastName);
            parameters.AddSQLParameter("@DateOfBirth", DateOfBirth);
            parameters.AddSQLParameter("@Gendor", Gendor);
            parameters.AddSQLParameter("@Address", Address);
            parameters.AddSQLParameter("@Phone", Phone);
            parameters.AddSQLParameter("@Email", Email);
            parameters.AddSQLParameter("@NationalityCountryID", NationalityCountryID);
            parameters.AddSQLParameter("@ImagePath", ImagePath);
            parameters.AddLoggedUserID(LoggedUserID);

            object ID = DBManager.ExecuteScalar("sp_AddPerson", parameters);
            return ID.ToNullableInt32();
        }

        public static bool UpdatePersonByID(int PersonID, string NationalNo,
            string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, int Gendor, string Address,
            string Phone, string Email, int NationalityCountryID,
            string ImagePath, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@NationalNo", NationalNo);
            parameters.AddSQLParameter("@FirstName", FirstName);
            parameters.AddSQLParameter("@SecondName", SecondName);
            parameters.AddSQLParameter("@ThirdName", ThirdName);
            parameters.AddSQLParameter("@LastName", LastName);
            parameters.AddSQLParameter("@DateOfBirth", DateOfBirth);
            parameters.AddSQLParameter("@Gendor", Gendor);
            parameters.AddSQLParameter("@Address", Address);
            parameters.AddSQLParameter("@Phone", Phone);
            parameters.AddSQLParameter("@Email", Email);
            parameters.AddSQLParameter("@NationalityCountryID", NationalityCountryID);
            parameters.AddSQLParameter("@ImagePath", ImagePath);
            parameters.AddSQLParameter("@PersonID", PersonID);
            parameters.AddLoggedUserID(LoggedUserID);

            return DBManager.ExecuteNonQuery("sp_UpdatePersonByID", parameters);
        }

        public static bool DeletePersonByID(int PersonID, int LoggedUserID)
        {
            var parameters = new HashSet<SqlParameter>();
            parameters.AddSQLParameter("@PersonID", PersonID);
            parameters.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeletePersonByID", parameters);
        }
    }
}
