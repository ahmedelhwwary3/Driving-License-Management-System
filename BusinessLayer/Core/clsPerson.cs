using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    [Serializable]
    public class clsPerson
    {
        public enum enGendor { Male = 0, Female = 1 }
        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public int? PersonID { get; set; }

        [MaxLength(50)]
        public string NationalNo { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string SecondName { get; set; }

        [MaxLength(50)]
        public string ThirdName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public enGendor Gendor { get; set; }

        public string GetGendorCaption()
            => Enum.GetName(typeof(enGendor), Gendor);

        public int NationalityCountryID { get; set; }

        public clsCountry Country { get; set; }

        public string FullName
            => FirstName + " " + SecondName + " " +
               (string.IsNullOrEmpty(ThirdName) ? "" : ThirdName + " ") + LastName;

        [DateToAgeBetween(18, 100, ErrorMessage = "Person age must be at least 18 years old.")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string ImagePath { get; set; }

        public int LoggedUserID { get; set; }

        public clsPerson()
        {
            PersonID = null;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            Gendor = enGendor.Male;
            NationalityCountryID = default;
            Country = new clsCountry();
            DateOfBirth = DateTime.Now;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
            LoggedUserID = default;

            Mode = enMode.AddNew;
        }

        public clsPerson(clsPerson other)
        {
            if (other == null)
                return;

            PersonID = other.PersonID;
            NationalNo = other.NationalNo;
            FirstName = other.FirstName;
            SecondName = other.SecondName;
            ThirdName = other.ThirdName;
            LastName = other.LastName;
            Gendor = other.Gendor;
            NationalityCountryID = other.NationalityCountryID;
            Country = other.Country;
            DateOfBirth = other.DateOfBirth;
            Address = other.Address;
            Phone = other.Phone;
            Email = other.Email;
            ImagePath = other.ImagePath;
            LoggedUserID = other.LoggedUserID;

            Mode = enMode.Update;
        }

        protected clsPerson(int? PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, int NationalityCountryID,
            DateTime DateOfBirth, enGendor Gendor, string Address, string Phone,
            string Email, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalityCountryID = NationalityCountryID;
            this.Country = clsCountry.GetByID(NationalityCountryID);
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.LoggedUserID = default;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(
                NationalNo, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, (int)Gendor, Address, Phone, Email,
                NationalityCountryID, ImagePath, LoggedUserID);

            return PersonID != null;
        }

        private bool _UpdatePerson()
        {
            if (!PersonID.HasValue) return false;

            return clsPersonData.UpdatePersonByID(
                PersonID.Value, NationalNo, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, (int)Gendor, Address, Phone, Email,
                NationalityCountryID, ImagePath, LoggedUserID);
        }

        public bool Save()
        {
            return Mode switch
            {
                enMode.AddNew => _AddNewPerson() ? (Mode = enMode.Update) == enMode.Update : false,
                enMode.Update => _UpdatePerson(),
                _ => false,
            };
        }

        public static bool IsExist(string NationalNo)
            => !string.IsNullOrEmpty(NationalNo) && clsPersonData.IsExistByNationalNO(NationalNo);

        public static bool IsExist(int? PersonID)
            => PersonID.HasValue && clsPersonData.IsExistByID(PersonID.Value);

        public static clsPerson GetByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo)) return null;

            DataTable dt = clsPersonData.GetByNationalNo(NationalNo);
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new clsPerson(
                PersonID: row["PersonID"].ToInt32(),
                FirstName: row["FirstName"]?.ToString() ?? string.Empty,
                SecondName: row["SecondName"]?.ToString() ?? string.Empty,
                ThirdName: row["ThirdName"]?.ToString() ?? string.Empty,
                LastName: row["LastName"]?.ToString() ?? string.Empty,
                NationalNo: row["NationalNo"]?.ToString() ?? string.Empty,
                Gendor: (enGendor)row["Gendor"].ToInt32(),
                DateOfBirth: row["DateOfBirth"].ToDate(),
                NationalityCountryID: row["NationalityCountryID"].ToInt32(),
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
            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new clsPerson(
                PersonID: row["PersonID"].ToInt32(),
                FirstName: row["FirstName"]?.ToString() ?? string.Empty,
                SecondName: row["SecondName"]?.ToString() ?? string.Empty,
                ThirdName: row["ThirdName"]?.ToString() ?? string.Empty,
                LastName: row["LastName"]?.ToString() ?? string.Empty,
                NationalNo: row["NationalNo"]?.ToString() ?? string.Empty,
                Gendor: (enGendor)row["Gendor"].ToInt32(),
                DateOfBirth: row["DateOfBirth"].ToDate(),
                NationalityCountryID: row["NationalityCountryID"].ToInt32(),
                Phone: row["Phone"]?.ToString() ?? string.Empty,
                Email: row["Email"]?.ToString() ?? string.Empty,
                Address: row["Address"]?.ToString() ?? string.Empty,
                ImagePath: row["ImagePath"]?.ToString() ?? string.Empty
            );
        }

        public static DataTable GetSubPeopleList(int PageNumber, int RowsPerPage, out int TotalCount, int Ranking)
            => clsPersonData.GetSubPeopleList(PageNumber, RowsPerPage, out TotalCount, Ranking);

        public static DataTable GetAllPeopleList()
            => clsPersonData.GetAllPeopleList();

        public static bool DeletePerson(int PersonID, int LoggedUserID)
            => clsPersonData.DeletePersonByID(PersonID, LoggedUserID);
    }
}
