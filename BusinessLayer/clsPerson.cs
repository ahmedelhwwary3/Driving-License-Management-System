using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
 
 
namespace BusinessLayer
{
    public class clsPerson
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public int? PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int Gendor { get; set; }
        public string GendorCaption
            => Gendor == 0 ? "Male" : "Female";
        public int? NationalityCountryID { get; set; }
        public clsCountry Country {  get; set; }
        public string FullName
            => (this.FirstName + " " + this.SecondName + 
            " " + (string.IsNullOrEmpty(this.ThirdName) ? "" 
            : this.ThirdName + " ") + this.LastName);

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int? LoggedUserID    { get; set; }
        public clsPerson()
        {
            this.LoggedUserID = null;
            this.PersonID = null;
            this.Gendor = 0;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalityCountryID = null;
            this.Country = new clsCountry();
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }
        protected clsPerson(int? PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, int? NationailtyCountryID, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, string ImagePath)
        {
            this.LoggedUserID = null;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ThirdName = ThirdName;
            this.SecondName = SecondName;
            this.NationalityCountryID = NationailtyCountryID;
            var getCountry = new Func<int?, clsCountry>(clsCountry.GetByID);
            this.Country = getCountry.GetByNullableID(NationailtyCountryID);
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.Gendor = Gendor;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        private bool _AddNewPerson()
        {
            if (this.NationalityCountryID.HasValue&&this.LoggedUserID.HasValue)
            {
                this.PersonID = clsPersonData.AddNewPerson(
                    this.NationalNo,
                    this.FirstName,
                    this.SecondName,
                    this.ThirdName,
                    this.LastName,
                    this.DateOfBirth,
                    this.Gendor,
                    this.Address,
                    this.Phone,
                    this.Email,
                    this.NationalityCountryID.Value,
                    this.ImagePath,
                    this.LoggedUserID.Value
                );
            }
            return this.PersonID != null;
        }

        private bool _UpdatePerson()
        {
            if (this.PersonID.HasValue && this.NationalityCountryID.HasValue)
            {
                return clsPersonData.UpdatePersonByID(
                    this.PersonID.Value,
                    this.NationalNo,
                    this.FirstName,
                    this.SecondName,
                    this.ThirdName,
                    this.LastName,
                    this.DateOfBirth,
                    this.Gendor,
                    this.Address,
                    this.Phone,
                    this.Email,
                    this.NationalityCountryID.Value,
                    this.ImagePath,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }
                default:
                    break;
            }
            return false;
        }
        public static bool IsExist(string NationalNo)
           =>!string.IsNullOrEmpty(NationalNo)&& clsPersonData.IsExistByNationalNO(NationalNo);

        public static bool IsExist(int? PersonID)
            => PersonID.HasValue && clsPersonData.IsExistByID(PersonID.Value);

        public static clsPerson GetByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
                return null;
            DataTable dt = clsPersonData.GetByNationalNo(NationalNo);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsPerson(
                PersonID: row["PersonID"] .ToNullableInt32(),
                FirstName: row["FirstName"]?.ToString() ?? string.Empty,
                SecondName: row["SecondName"]?.ToString() ?? string.Empty,
                ThirdName: row["ThirdName"]?.ToString() ?? string.Empty,
                LastName: row["LastName"]?.ToString() ?? string.Empty,
                NationalNo: row["NationalNo"]?.ToString() ?? string.Empty,
                Gendor: row["Gendor"] != DBNull.Value ? Convert.ToInt32(row["Gendor"]) : 0,
                DateOfBirth: row["DateOfBirth"].ToDate(),
                NationailtyCountryID: row["NationalityCountryID"] .ToNullableInt32(),
                Phone: row["Phone"]?.ToString() ?? string.Empty,
                Email: row["Email"]?.ToString() ?? string.Empty,
                Address: row["Address"]?.ToString() ?? string.Empty,
                ImagePath: row["ImagePath"]?.ToString() ?? string.Empty
            );
        }

        public static clsPerson GetByID(int? PersonID)
        {
            if (!PersonID.HasValue)
                return null;

            DataTable dt = clsPersonData.GetByID(PersonID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsPerson(
               PersonID: row["PersonID"].ToNullableInt32(),
                FirstName: row["FirstName"]?.ToString() ?? string.Empty,
                SecondName: row["SecondName"]?.ToString() ?? string.Empty,
                ThirdName: row["ThirdName"]?.ToString() ?? string.Empty,
                LastName: row["LastName"]?.ToString() ?? string.Empty,
                NationalNo: row["NationalNo"]?.ToString() ?? string.Empty,
                Gendor: row["Gendor"] != DBNull.Value ? Convert.ToInt32(row["Gendor"]) : 0,
                DateOfBirth: row["DateOfBirth"].ToDate(),
                NationailtyCountryID: row["NationalityCountryID"].ToNullableInt32(),
                Phone: row["Phone"]?.ToString() ?? string.Empty,
                Email: row["Email"]?.ToString() ?? string.Empty,
                Address: row["Address"]?.ToString() ?? string.Empty,
                ImagePath: row["ImagePath"]?.ToString() ?? string.Empty
            );
        }

        public static DataTable GetAllPeopleList()
            => clsPersonData.GetAllPeopleList();

        public static bool DeletePerson(int? PersonID,int? LoggedUserID)
        {
            if (!PersonID.HasValue)
                return false;
            return clsPersonData.DeletePersonByID(PersonID.Value, LoggedUserID.Value);
        }

    }
}
