using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Core.clsLicenseClass;

namespace BusinessLayer.Core
{
    public class clsLicenseClass
    {
        protected enum enMode { AddNew, Update }
        protected enMode Mode;

        public enum enLicenseClassID
        {
            Class1SmallMotorcycle = 1,
            Class2HeavyMotorcycle = 2,
            Class3OrdinaryDrivingLicense = 3,
            Class4Commercial = 4,
            Class5Agricaltural = 5,
            Class6SmallMediumBus = 6,
            Class7TruckHeavyVehicle = 7
        }

        public int? LicenseClassID { get; set; } = (int)enLicenseClassID.Class3OrdinaryDrivingLicense;
        [MaxLength(50)]
        public string ClassName { get; set; }
        [MaxLength(100)]
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public enDefaultValidityLength DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        public int LoggedUserID { get; set; }

        public enum enDefaultValidityLength
        {
            Class1_Small_Motorcycle = 5,
            Class2_Heavy_motorcycle = 10,
            Class3_ordinary_driving_license = 10,
            Class4_Commercial = 8,
            Class5_Agricaltural = 8,
            Class6_Small_and_Medium_Bus = 5,
            Class7_Truck_and_Heavy_vehicle = 5
        }

        public clsLicenseClass()
        {
            LicenseClassID = (int)enLicenseClassID.Class3OrdinaryDrivingLicense;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = default;
            DefaultValidityLength = enDefaultValidityLength.Class3_ordinary_driving_license;
            ClassFees = default;
            LoggedUserID = default;
            Mode = enMode.AddNew;
        }

        protected clsLicenseClass(enLicenseClassID licenseClassID, string className, string classDescription,
            int minimumAllowedAge, enDefaultValidityLength defaultValidityLength, decimal classFees)
        {
            LicenseClassID = (int)licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
            LoggedUserID = default;
            Mode = enMode.Update;

        }

        private bool _AddNewLicenseClass()
        {
            LicenseClassID = clsLicenseClassData.AddLicenseClass(
                ClassName,
                ClassDescription,
                MinimumAllowedAge,
                (int)DefaultValidityLength,
                ClassFees,
                LoggedUserID
            );

            return LicenseClassID.HasValue;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(
                (int)LicenseClassID,
                ClassName,
                ClassDescription,
                MinimumAllowedAge,
                (int)DefaultValidityLength,
                ClassFees,
                LoggedUserID
            );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }

        public static bool IsExist(int licenseClassID)
            => clsLicenseClassData.IsExistByID(licenseClassID);

        public static clsLicenseClass GetByID(int? licenseClassID)
        {
            if (!licenseClassID.HasValue)
                return null;
            DataTable dt = clsLicenseClassData.GetByID(licenseClassID.Value);
 
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicenseClass(
                licenseClassID: (enLicenseClassID)(int)row["LicenseClassID"],
                className: row["ClassName"].ToString(),
                classDescription: row["ClassDescription"].ToString(),
                minimumAllowedAge: (int)row["MinimumAllowedAge"],
                defaultValidityLength: (enDefaultValidityLength)(int)row["DefaultValidityLength"],
                classFees: row["ClassFees"].ToDecimal()
            );
        }

        public static clsLicenseClass GetByClassName(string className)
        {
            DataTable dt = clsLicenseClassData.GetByName(className);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsLicenseClass(
                licenseClassID: (enLicenseClassID)(int)row["LicenseClassID"],
                className: row["ClassName"].ToString(),
                classDescription: row["ClassDescription"].ToString(),
                minimumAllowedAge: (int)row["MinimumAllowedAge"],
                defaultValidityLength: (enDefaultValidityLength)(int)row["DefaultValidityLength"],
                classFees: row["ClassFees"].ToDecimal()
            );
        }

        public static DataTable GetAllLicenseClasssList()
            => clsLicenseClassData.GetAllLicenseClassesList();

        public static bool DeleteLicenseClass(int licenseClassID, int loggedUserID)
            => clsLicenseClassData.DeleteLicenseClass(licenseClassID, loggedUserID);
    }
}
