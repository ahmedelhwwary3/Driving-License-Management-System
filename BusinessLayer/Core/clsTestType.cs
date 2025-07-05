using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    [Description("Vision, Written, Street")]
    public class clsTestType
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public enum enTestType { Vision = 1, Written = 2, Street = 3 }

        public int? TestTypeID { get; set; } = (int)enTestType.Vision;

        [MaxLength(50)]
        public string TestTypeTitle { get; set; }

        [MaxLength(100)]
        public string TestTypeDescription { get; set; }

        public decimal TestTypeFees { get; set; }

        public int LoggedUserID { get; set; }

        public clsTestType()
        {
            TestTypeTitle = string.Empty;
            TestTypeDescription = string.Empty;
            TestTypeFees = 0;
            LoggedUserID = 0;

            Mode = enMode.AddNew;
        }

        protected clsTestType(enTestType testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = (int)testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;

            LoggedUserID = 0;
            Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            if (!string.IsNullOrEmpty(TestTypeTitle) &&
                !string.IsNullOrEmpty(TestTypeDescription))
            {
                TestTypeID = clsTestTypeData.AddTestType(
                    TestTypeTitle,
                    TestTypeDescription,
                    TestTypeFees,
                    LoggedUserID
                );
                return TestTypeID.HasValue;
            }
            return false;
        }

        private bool _UpdateTestType()
        {
            return  clsTestTypeData.UpdateTestTypeByID(
                       (int)TestTypeID,
                       TestTypeTitle,
                       TestTypeDescription,
                       TestTypeFees,
                       LoggedUserID
                   );
        }


        public bool Save()
        {
            if (Mode == enMode.AddNew)
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
            else if (Mode == enMode.Update)
            {
                return _UpdateTestType();
            }

            return false;
        }

        public static clsTestType GetByID(int? testTypeID)
        {
            if (!testTypeID.HasValue)
                return null;
            DataTable dt = clsTestTypeData.GetByID(testTypeID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return new clsTestType(
                testTypeID: (enTestType)row["TestTypeID"].ToInt32(),
                testTypeTitle: row["TestTypeTitle"].ToString()??string.Empty,
                testTypeDescription: row["TestTypeDescription"].ToString() ?? string.Empty,
                testTypeFees: row["TestTypeFees"].ToDecimal()
            );
        }

        public static bool IsExistedByID(int testTypeID)
        {
            return clsTestTypeData.IsExistByID(testTypeID);
        }

        public static bool IsExisted(string testTypeName)
        {
            return !string.IsNullOrEmpty(testTypeName) &&
                   clsTestTypeData.IsExistedByTitle(testTypeName);
        }

        public static DataTable GetAllTestTypesList()
        {
            return clsTestTypeData.GetAllTestTypesList();
        }
    }
}
