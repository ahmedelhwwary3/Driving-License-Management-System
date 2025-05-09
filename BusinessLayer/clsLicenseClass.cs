 
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class clsLicenseClass
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public enum enLicenseClassID
        {
            Class1_Small_Motorcycle = 1, Class2_Heavy_motorcycle = 2, Class3_ordinary_driving_license =3
                , Class4_Commercial = 4, Class5_Agricaltural =5, Class6_Small_and_Medium_Bus = 6
                , Class7_Truck_and_Heavy_vehicle = 7
        }
        public enLicenseClassID? LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int? MinimumAllowedAge { get; set; }
        public enDefaultValidityLength DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        public int? LoggedUserID    { get; set; }
        public enum enDefaultValidityLength
        {
            Class1_Small_Motorcycle=5, Class2_Heavy_motorcycle=10, Class3_ordinary_driving_license=10
                , Class4_Commercial=8, Class5_Agricaltural=8, Class6_Small_and_Medium_Bus=5
                , Class7_Truck_and_Heavy_vehicle=5
        }
        public clsLicenseClass()
        {
            this.LoggedUserID = null;
            this.LicenseClassID = enLicenseClassID.Class3_ordinary_driving_license;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength =enDefaultValidityLength.Class3_ordinary_driving_license;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }
        protected clsLicenseClass(enLicenseClassID? LicenseClassID, string ClassName, string ClassDescription, int? MinimumAllowedAge, enDefaultValidityLength DefaultValidityLength, decimal ClassFees)
        {
            this.LoggedUserID = null;
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }
        private bool _AddNewLicenseClass()
        {
            if (this.LicenseClassID.HasValue &&  !string.IsNullOrEmpty(this.ClassName)
                && this.MinimumAllowedAge.HasValue
                && !string.IsNullOrEmpty(this.ClassDescription))
            {
                this.LicenseClassID = (enLicenseClassID?)clsLicenseClassData.AddLicenseClass(
                    this.ClassName,
                    this.ClassDescription,
                    this.MinimumAllowedAge.Value,
                    (int)this.DefaultValidityLength,
                    this.ClassFees,
                    this.LoggedUserID.Value
                );
            }
            return this.LicenseClassID != null;
        }

        private bool _UpdateLicenseClass()
        {
            if (this.LicenseClassID.HasValue && !string.IsNullOrEmpty(this.ClassName)
                &&this.MinimumAllowedAge.HasValue
             && !string.IsNullOrEmpty(this.ClassDescription))
            {
                return clsLicenseClassData.UpdateLicenseClass(
                    (int)this.LicenseClassID.Value,
                    this.ClassName,
                    this.ClassDescription,
                    this.MinimumAllowedAge.Value,
                    (int)this.DefaultValidityLength,
                    this.ClassFees,
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
                        if (_AddNewLicenseClass())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateLicenseClass();
                    }
                default:
                    break;
            }
            return false;
        }

        public static bool IsExist(int? LicenseClassID)
    => LicenseClassID.HasValue && clsLicenseClassData.IsExistByID(LicenseClassID.Value);

        public static clsLicenseClass GetByID(int? LicenseClassID)
        {
            if (!LicenseClassID.HasValue)
                return null;

            DataTable dt = clsLicenseClassData.GetByID(LicenseClassID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicenseClass(
                ClassDescription: row["ClassDescription"] .ToString()??"",
                ClassFees: row["ClassFees"] .ToDecimal(),
                ClassName: row["ClassName"].ToString()??"",
                DefaultValidityLength: (enDefaultValidityLength)row["DefaultValidityLength"].ToNullableInt32(),
                LicenseClassID: (enLicenseClassID?)row["LicenseClassID"].ToNullableInt32(),
                MinimumAllowedAge:row["MinimumAllowedAge"] .ToNullableInt32()
            );
        }

        public static clsLicenseClass GetByClassName(string ClassName)
        {
            DataTable dt = clsLicenseClassData.GetByName(ClassName);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicenseClass(
                ClassDescription: row["ClassDescription"].ToString() ?? "",
                ClassFees: row["ClassFees"].ToDecimal(),
                ClassName: row["ClassName"].ToString() ?? "",
                DefaultValidityLength: (enDefaultValidityLength)row["DefaultValidityLength"].ToNullableInt32(),
                LicenseClassID: (enLicenseClassID?)row["LicenseClassID"].ToNullableInt32(),
                MinimumAllowedAge: row["MinimumAllowedAge"].ToNullableInt32()
                );
        }

        public static DataTable GetAllLicenseClasssList()
            => clsLicenseClassData.GetAllLicenseClassesList();

        public static bool DeleteLicenseClass(int? LicenseClassID,int?  LoggedUserID)
            => LicenseClassID.HasValue && LoggedUserID.HasValue&& 
            clsLicenseClassData.DeleteLicenseClass(LicenseClassID.Value,LoggedUserID.Value);

    }
}
