using PresentationLayer.Global;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static PresentationLayer.Global.clsGlobalData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Core;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers;
using static BusinessLayer.Core.clsTestType;
using static BusinessLayer.Core.clsTestAppointment;
using static PresentationLayer.Global.clsFormat;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduledTest : clsBaseCtrl
    {
        private int? _TestAppointmentID = null;
        private clsTestAppointment _TestAppointment;
        private clsTestType.enTestType? _TestTypeID = clsTestType.enTestType.Vision;
        public clsTestType.enTestType? TestTypeID
        {
            get => _TestTypeID;
            set
            { 
                _TestTypeID = value;
                SetImageAndTitle();
            }
        }
        void SetImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case enTestType.Vision:
                    {
                        lblTestTypeTitle.Text = "Scheduled Vision Test";
                        pbTestType.Image = Resources.Vision_512;
                        break;
                    }
                case enTestType.Written:
                    {
                        lblTestTypeTitle.Text = "Scheduled Written Test";
                        pbTestType.Image = Resources.Written_Test_512;
                        break;
                    }
                case enTestType.Street:
                    {
                        lblTestTypeTitle.Text = "Scheduled Street Test";
                        pbTestType.Image = Resources.driving_test_512;
                        break;
                    }


            }
        }

        public int? _TestID = null;//Update Mode
        public int?TestID
        {
            get => _TestID;
            set
            {
                _TestID = value;
                if (TestID == null)
                {
                    lblTestID.Text = "N/A";
                    this.Enabled = false;
                    return;
                }
                lblTestID.Text =TestID.ToString();
            }
        }
    
        public ctrlScheduledTest()
        {
            InitializeComponent();
            SetTheme(this);
        }

        public void LoadScheduledTest(int TestAppointmentID,
            enTestType TestTypeID,int? TestID=null)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            _TestID = TestID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID =TestAppointmentID;
            _TestAppointment =   clsTestAppointment.GetByID((int)_TestAppointmentID.Value);
            if(_TestAppointment==null)
            {
                MessageBox.Show($"Error:Test Appointment with ID" +
                    $" {_TestAppointmentID.ToString()} is not found !", "Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            lblClassName.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblDate.Text =DateToShortString(_TestAppointment.AppointmentDate);
            lblFees.Text=_TestAppointment.PaidFees.ToString();
            lblLocalAppID.Text=_TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = _TestAppointment.LocalDrivingLicenseApplication.Person.FullName;
            lblTestTypeTitle.Text = _TestAppointment.TestType.TestTypeTitle;
            lblTrials.Text = _TestAppointment.LocalDrivingLicenseApplication.CountAllTestTrials((enTestType)_TestAppointment.TestTypeID).ToString();
            //Update Mode
            lblTestID.Text =TestID?.ToString()?? "N/A";
        }


    }
}
