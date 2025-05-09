using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using DataAccessLayer;
namespace BusinessLayer
{
    public class clsTestType
    {

        protected enum enMode { AddNew, Update };
        protected enMode Mode;
        public enum enTestType 
        { Vision = 1, Written = 2, Street = 3 };

        public clsTestType.enTestType? TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public int? LoggedUserID { get; set; }
        public clsTestType()
        {
            this.LoggedUserID = null;
            this.TestTypeID = enTestType.Vision;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;

            Mode = enMode.AddNew;
        }
        protected clsTestType(enTestType? TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.LoggedUserID = null;
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            Mode = enMode.Update;
        }

        private bool _UpdateTestType()
        {
            if (this.TestTypeID.HasValue&& this.LoggedUserID.HasValue)
            {
                return clsTestTypeData.UpdateTestTypeByID(
                    (int)this.TestTypeID,
                    this.TestTypeTitle,
                    this.TestTypeDescription,
                    this.TestTypeFees,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }

        private bool _AddNewTestType()
        {
            if (!string.IsNullOrEmpty(this.TestTypeTitle) && !string.IsNullOrEmpty(this.TestTypeDescription)&& this.LoggedUserID.HasValue)
            {
                this.TestTypeID = (enTestType?)clsTestTypeData.AddTestType(
                    this.TestTypeTitle,
                    this.TestTypeDescription,
                    this.TestTypeFees,
                    this.LoggedUserID.Value
                );
            }
            return this.TestTypeID != null;
        }


        public bool Save()
        {
            switch (Mode)
            {

                case enMode.AddNew:
                    {
                        if (_AddNewTestType())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateTestType();
                    }
                default:
                    break;
            }
            return false;
        }


        public static clsTestType GetByID(int? TestTypeID)
        {
            if (!TestTypeID.HasValue)
                return null;

            DataTable dt = clsTestTypeData.GetByID(TestTypeID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new clsTestType(
                TestTypeID: (enTestType?)row["TestTypeID"].ToNullableInt32(),
                TestTypeDescription: row["TestTypeDescription"].ToString(),
                TestTypeFees: row["TestTypeFees"].ToDecimal(),
                TestTypeTitle: row["TestTypeTitle"].ToString()
            );
        }

        public static bool IsExistedByID(int? TestTypeID)
        {
            if (!TestTypeID.HasValue)
                return false;

            return clsTestTypeData.IsExistByID(TestTypeID.Value);
        }

        public static bool IsExisted(string TestTypeName)
            => clsTestTypeData.IsExistedByTitle(TestTypeName);

        public static DataTable GetAllTestTypesList()
            => clsTestTypeData.GetAllTestTypesList();




    }
}
