using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
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
                _SetImageAndTitle();
            }
        }
        void _SetImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.Vision:
                    {
                        lblTestTypeTitle.Text = "Scheduled Vision Test";
                        pbTestType.Image = Resources.Vision_512;
                        break;
                    }
                case clsTestType.enTestType.Written:
                    {
                        lblTestTypeTitle.Text = "Scheduled Written Test";
                        pbTestType.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.Street:
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
        public ctrlScheduledTest()=> InitializeComponent();

        public void LoadScheduledTest(int TestAppointmentID,
            clsTestType.enTestType TestTypeID,int? TestID=null)
        {
            _TestID = TestID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID =TestAppointmentID;
            _TestAppointment = clsTestAppointment.GetByID((int)_TestAppointmentID);
            if(_TestAppointment==null)
            {
                MessageBox.Show($"Error:Test Appointment with ID" +
                    $" {_TestAppointmentID.ToString()} is not found !", "Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            lblClassName.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lblDate.Text = clsFormat.DateToShortString(_TestAppointment.AppointmentDate);
            lblFees.Text=_TestAppointment.PaidFees.ToString();
            lblLocalAppID.Text=_TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblName.Text = _TestAppointment.LocalDrivingLicenseApplication.Person.FullName;
            lblTestTypeTitle.Text = _TestAppointment.TestType.TestTypeTitle;
            lblTrials.Text = _TestAppointment.LocalDrivingLicenseApplication.CountAllTestTrials((clsTestType.enTestType)_TestAppointment.TestTypeID).ToString();
            //Update Mode
            lblTestID.Text = TestID==null?"N/A": TestID.ToString();
        }


    }
}
