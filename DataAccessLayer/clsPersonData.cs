using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;

namespace DataAccessLayer
{
    public static class clsPersonData
    {
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllPeopleList()
            => DBManager.ExecuteDataTable("sp_GetAllPeople");


        public static bool IsExistByID(int PersonID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            object Result = DBManager.ExecuteScalar("sp_IsPersonExistedByID", map);
            return Result.ToBoolean();
        }

        public static bool IsExistByNationalNO(string NationalNo)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@NationalNo", NationalNo);
            object Result = DBManager.ExecuteScalar("sp_IsPersonExistedByNationalNo", map);
            return Result.ToBoolean();

        }

        public static DataTable GetByID(int PersonID)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);

            return DBManager.ExecuteDataTable("sp_GetPersonByPersonID", map);
        }

        public static DataTable GetByNationalNo(string NationalNo)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@NationalNo", NationalNo);

            return DBManager.ExecuteDataTable("sp_GetPersonByNationalNo", map);
        }
        public static int? AddNewPerson(string NationalNo, string FirstName, 
            string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, int Gendor, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@NationalNo", NationalNo);
            map?.Add("@FirstName", FirstName);
            map?.Add("@SecondName", SecondName);
            map?.Add("@ThirdName", ThirdName);
            map?.Add("@LastName", LastName);
            map?.Add("@DateOfBirth", DateOfBirth);
            map?.Add("@Gendor", Gendor);
            map?.Add("@Address", Address);
            map?.Add("@Phone", Phone);
            map?.Add("@Email", Email);
            map?.Add("@NationalityCountryID", NationalityCountryID);
            map?.Add("@ImagePath", ImagePath);
            map?.AddLoggedUserID(LoggedUserID);
            Object ID= DBManager.ExecuteScalar("sp_AddPerson", map);
            return ID.ToNullableInt();
        }

        public static bool UpdatePersonByID(int PersonID, string NationalNo,
            string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, int Gendor, string Address,
            string Phone, string Email, int NationalityCountryID,
            string ImagePath,int LoggedUserID)
        {

            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@NationalNo", NationalNo);
            map?.Add("@FirstName", FirstName);
            map?.Add("@SecondName", SecondName);
            map?.Add("@ThirdName", ThirdName);
            map?.Add("@LastName", LastName);
            map?.Add("@DateOfBirth", DateOfBirth);
            map?.Add("@Gendor", Gendor);
            map?.Add("@Address", Address);
            map?.Add("@Phone", Phone);
            map?.Add("@Email", Email);
            map?.Add("@NationalityCountryID", NationalityCountryID);
            map?.Add("@ImagePath", ImagePath);
            map?.Add("@PersonID", PersonID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_UpdatePersonByID", map);

        }

        public static bool DeletePersonByID(int PersonID,int LoggedUserID)
        {
            
            Dictionary<string, object> map = new Dictionary<string, object>();
            map?.Add("@PersonID", PersonID);
            map?.AddLoggedUserID(LoggedUserID);
            return DBManager.ExecuteNonQuery("sp_DeletePersonByID", map);
        }

        













    }
}
