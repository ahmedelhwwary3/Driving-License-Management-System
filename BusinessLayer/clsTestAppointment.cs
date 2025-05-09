using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using DataAccessLayer;
namespace BusinessLayer
{
    public class clsTestAppointment
    {


        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        public static DateTime TestMaxDate => DateTime.Now.AddMonths(3);//4 Months (As the current month is added to the period before)
        public int? TestAppointmentID { get; set; }
        public clsTestType.enTestType? TestTypeID { get; set; } 
            = clsTestType.enTestType.Vision;
        public clsTestType TestType { get; set; }
        public int? LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser User { get; set; }
        public bool IsLocked { get; set; }
        public Nullable<int> RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }
        public int? LoggedUserID    { get; set; }
        public clsTestAppointment()
        {
            this.LoggedUserID = null;
            this.TestAppointmentID = null;
            this.TestTypeID = clsTestType.enTestType.Vision;
            this.TestType = new clsTestType();
            this.LocalDrivingLicenseApplicationID = null;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = null;
            this.User=new clsUser();
            this.IsLocked = false;
            this.RetakeTestApplicationID =null;

            Mode = enMode.AddNew;
        }
        protected clsTestAppointment(int? TestAppointmentID, clsTestType.enTestType? TestTypeID, int? LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int? CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID)
        {
            var getTestType = new Func<int?, clsTestType>(clsTestType.GetByID);
            var getLocalDrivingLicenseApplication = new Func<int?, clsLocalDrivingLicenseApplication>(clsLocalDrivingLicenseApplication.GetLocalApplicationByID);
            var getUser = new Func<int?, clsUser>(clsUser.GetByID);
            var getApplication = new Func<int?, clsApplication>(clsApplication.GetByID);

            this.LoggedUserID = null;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.TestType = getTestType.GetByNullableID((int)TestTypeID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LocalDrivingLicenseApplication = getLocalDrivingLicenseApplication.GetByNullableID(LocalDrivingLicenseApplicationID);
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.User = getUser.GetByNullableID(CreatedByUserID);
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = RetakeTestApplicationID.HasValue ? getApplication.GetByNullableID((int)this.RetakeTestApplicationID) : null;

            Mode = enMode.Update;
        }
        private bool _AddNewTestAppointment()
        {
            if (this.TestTypeID.HasValue && this.LocalDrivingLicenseApplicationID.HasValue && this.CreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                this.TestAppointmentID = clsTestAppointmentData.AddTestAppointment(
                    (int)this.TestTypeID,
                    this.LocalDrivingLicenseApplicationID.Value,
                    this.AppointmentDate,
                    this.PaidFees,
                    this.CreatedByUserID.Value,
                    this.IsLocked,
                    this.RetakeTestApplicationID,
                    this.LoggedUserID.Value
                );
            }
            return this.TestAppointmentID != null;
        }

        private bool _UpdateTestAppointment()
        {
            if (this.TestAppointmentID.HasValue && this.TestTypeID.HasValue && this.LocalDrivingLicenseApplicationID.HasValue && this.CreatedByUserID.HasValue&&this.LoggedUserID.HasValue)
            {
                return clsTestAppointmentData.UpdateTestAppointmentByID(
                    this.TestAppointmentID.Value,
                     (int)this.TestTypeID,
                    this.LocalDrivingLicenseApplicationID.Value,
                    this.AppointmentDate,
                    this.PaidFees,
                    this.CreatedByUserID.Value,
                    this.IsLocked,
                    this.RetakeTestApplicationID,
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
                        if (_AddNewTestAppointment())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                 return _UpdateTestAppointment();
                default:
                    break;
            }
            return false;
        }


        public static bool IsExistedByID(int? TestAppointmentID)
         => TestAppointmentID.HasValue&& clsTestAppointmentData.IsExistedByID(TestAppointmentID.Value);
        public static clsTestAppointment GetByID(int? TestAppointmentID)
        {
            if (!TestAppointmentID.HasValue)
                return null;
            DataTable dt = clsTestAppointmentData.GetByID(TestAppointmentID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsTestAppointment(
                CreatedByUserID: row["CreatedByUserID"] .ToNullableInt32(),
                AppointmentDate: row["AppointmentDate"].ToDate(),
                IsLocked : row["IsLocked"].ToBoolean()  ,
                LocalDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToNullableInt32(),
                TestAppointmentID: row["TestAppointmentID"].ToNullableInt32(),
                PaidFees : row["PaidFees"] .ToDecimal(),
                RetakeTestApplicationID: row["RetakeTestApplicationID"].ToNullableInt32(),
                TestTypeID : (clsTestType.enTestType?)row["TestTypeID"].ToNullableInt32()
            );
             

        }
        public static DataTable GetAllTestAppointmentsListPerTestType(int? LocalDrivingLicenseApplicationID, clsTestType.enTestType? TestTypeID)
             => TestTypeID.HasValue && LocalDrivingLicenseApplicationID.HasValue
              ? clsTestAppointmentData.GetAllTestAppointmentsForLocalApp_PerType(LocalDrivingLicenseApplicationID.Value, (int)TestTypeID.Value) : new DataTable();

        public static DataTable GetAllTestAppointmentsList(int? LocalDrivingLicenseApplicationID)
            => LocalDrivingLicenseApplicationID.HasValue? clsTestAppointmentData.GetAllTestAppointmentsLForLocalApp_AllTypes(LocalDrivingLicenseApplicationID.Value):new DataTable();

        public static bool DeleteTestAppointment(int? TestAppointmentID,int? LoggedUserID)
        {
            if (!TestAppointmentID.HasValue)
                return false;

            return clsTestAppointmentData.DeleteTestAppointmentByID(TestAppointmentID.Value, LoggedUserID.Value);
        }

        public static clsTestAppointment FindLastTestAppointment(int LocalDrivingLicenseApplicationID, int? TestTypeID)
        {
            if (!TestTypeID.HasValue)
                return null;

            DataTable dt = clsTestAppointmentData.GetLastTestAppointmentDataByLocalAppID_PerType(LocalDrivingLicenseApplicationID, TestTypeID.Value);
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsTestAppointment(
                     CreatedByUserID: row["CreatedByUserID"].ToNullableInt32(),
                AppointmentDate: row["AppointmentDate"].ToDate(),
                IsLocked: row["IsLocked"].ToBoolean(),
                LocalDrivingLicenseApplicationID: row["LocalDrivingLicenseApplicationID"].ToNullableInt32(),
                TestAppointmentID: row["TestAppointmentID"].ToNullableInt32(),
                PaidFees: row["PaidFees"].ToDecimal(),
                RetakeTestApplicationID: row["RetakeTestApplicationID"].ToNullableInt32(),
                TestTypeID: (clsTestType.enTestType?)row["TestTypeID"].ToNullableInt32()
                );
        }

        public int? GetTestID()
        {
            if (!this.TestAppointmentID.HasValue)
                return null;

            return clsTestAppointmentData.GetTestIDByAppointmentID(this.TestAppointmentID.Value);
        }





    }
}
