using DataAccessLayer.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsHighRiskApplicants
    {
        public int? RiskID { get; set; }

        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }

        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointment { get; set; }

        public clsHighRiskApplicants()
        {
            RiskID = null;
            LocalDrivingLicenseApplicationID = default;
            LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            TestAppointmentID = default;
            TestAppointment = new clsTestAppointment();
        }

        protected clsHighRiskApplicants(int? RiskID, 
            int LocalDrivingLicenseApplicationID, int TestAppointmentID)
        {
            this.RiskID = RiskID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalDrivingLicenseApplicationID);
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointment = clsTestAppointment.GetByID(TestAppointmentID);

        }

        public static DataTable GetAllHighRiskApplicantsList()
            => clsHighRiskApplicantsData.GetAllHighRiskApplicantsList();
    }
}
