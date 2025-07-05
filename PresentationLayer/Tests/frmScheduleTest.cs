using BusinessLayer.Core;
using PresentationLayer.Helpers.BaseUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.Core.clsTestType;

namespace PresentationLayer.Tests
{
    public partial class frmScheduleTest : clsBaseForm
    {   
        private int? _TestAppointmentID = null;
        private int _LocalDrivingLicenseApplicationID = default;
        private enTestType? _TestTypeID = enTestType.Vision;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, enTestType testTypeID,int? TestAppointmentID=null)
        {
            InitializeComponent();
            SetTheme(this);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            SetTitle("Schedule Test");
            this.AcceptButton = ctrlScheduleTest1.SaveButton;
            ctrlScheduleTest1.TestTypeID= _TestTypeID.Value;
            ctrlScheduleTest1.LoadTestAppointmentFullData(_LocalDrivingLicenseApplicationID,_TestAppointmentID);
        }
    }
}
