using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    public partial class frmScheduleTest : Form
    {   
        private int? _TestAppointmentID = null;
        private int? _LocalDrivingLicenseApplicationID = null;
        private clsTestType.enTestType? _TestTypeID = clsTestType.enTestType.Vision;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType testTypeID,int? TestAppointmentID=null)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ScheduleTest))
                return;
            this.AcceptButton = ctrlScheduleTest1.SaveButton;
            ctrlScheduleTest1.TestTypeID= _TestTypeID;
            ctrlScheduleTest1.LoadTestAppointmentFullData(_LocalDrivingLicenseApplicationID.Value,_TestAppointmentID);
        }
    }
}
