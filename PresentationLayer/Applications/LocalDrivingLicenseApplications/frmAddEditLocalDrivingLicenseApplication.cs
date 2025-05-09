using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {

        enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;
        clsLocalDrivingLicenseApplication _LocalApplication
            = new clsLocalDrivingLicenseApplication();
        int? _LocalDrivingLicenseApplicationID = null;
        int? _PersonID = null;
        int? _LicenseClassID =>
            (int)clsLicenseClass.GetByClassName(cbLicenesClass.Text).LicenseClassID;
        clsApplication.enApplicationType _ApplicationTypeID
            = clsApplication.enApplicationType.NewLocalDrivingLicenseService;
        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }
        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _Mode = enMode.Update;
        }


        private void frmAddEditLocalDrivingLicenseApplication_Shown(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditLocalApplication))
                return;
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadDataInUpdateMode();
        }
        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();
            _SetFormTitle();
            if (_Mode == enMode.AddNew)
            {
                this.AcceptButton = ctrlPersonCardWithFilter1.FindBtn;
                _EnableForm(false);
                _SetTCPage2DefaultValues();
                ///this.BeginInvoke(new Action(() => ctrlPersonCardWithFilter1.FilterFocus()));
                //BeginInvoke() makes the FilterFocus() as the last method called
                //FilterFocus() must be the last method called after frmLoad event or Focus will be stoled
                ///Or you can use frmShown (It happened After frmLoad)
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }
            this.AcceptButton = this.btnNext;
            _EnableForm(true);
        }
        void _SetTCPage2DefaultValues()
        {
            int ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicenseService;

            lblApplicationFees.Text = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID).ToString("F2");
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            cbLicenesClass.SelectedIndex = 2;//ordinary class
        }
        void _EnableForm(bool Enable)
        {
            btnSave.Enabled = Enable;
            tpApplicationInfo.Enabled = Enable;
        }
        void _SetFormTitle()
        {
            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Local Driving License Application";
                lblAddEditLocalDrivingLicenseApplication.Text = "Add New Local Driving License Application";
            }
            else
            {
                this.Text = "Update Local Driving License Application";
                lblAddEditLocalDrivingLicenseApplication.Text = "Update Local Driving License Application";

            }
        }
        private void _LoadDataInUpdateMode()
        {
            _LocalApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(_LocalDrivingLicenseApplicationID);
            if (_LocalApplication == null)
            {
                MessageBox.Show($"Local Driving License Application is not found !"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCardWithFilter1.LoadPerson(_LocalApplication.ApplicantPersonID.Value);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            lblApplicationDate.Text = clsFormat.DateToShortString(_LocalApplication.ApplicationDate);
            lblApplicationFees.Text = _LocalApplication.PaidFees.ToString("F2");
            lblCreatedByUserName.Text = _LocalApplication.CreatedByUser.UserName;
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            cbLicenesClass.SelectedIndex = cbLicenesClass.FindString(_LocalApplication.LicenseClass.ClassName);
        }
        void _MoveNext()
        {
            tcAddNewUser.SelectedTab = tpApplicationInfo;
            this.AcceptButton = btnSave;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                _MoveNext();
                return;
            }
            if (_PersonID == null)
            {
                MessageBox.Show($"Error:Person with ID {_PersonID} is not found !",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _EnableForm(true);
            _MoveNext();
        }



        void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void _FillLicenseClassesInComboBox()
        {

            DataTable LicenseClasses = clsLicenseClass.GetAllLicenseClasssList();
            foreach (DataRow r in LicenseClasses.Rows)
            {
                cbLicenesClass.Items.Add(r["ClassName"]);
            }

        }




        Boolean _HandleChecksBeforeSave()
        {
            if (_Mode == enMode.AddNew)
            {

                if (clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplicationForLicenseClass(_PersonID, clsApplication.enApplicationType.NewLocalDrivingLicenseService, (int)_LicenseClassID))
                {
                    MessageBox.Show("Error:This Person has an active Local Driving License Application " +
                        "with This License Class !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                if (clsLicense.IsThereActiveLicenseForPersonPerLicenseClass(_PersonID, _LicenseClassID))
                {
                    MessageBox.Show("Error:This Person has already a License with This License Class !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleChecksBeforeSave())
                return;

            if (!DateTime.TryParseExact(lblApplicationDate.Text, "dd/MM/yyyy",
                 System.Globalization.CultureInfo.InvariantCulture,
                 System.Globalization.DateTimeStyles.None,
                 out DateTime date))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing lblApplicationDate to date."));
                return;
            }
            try
            {
                _LocalApplication.ApplicationDate = date;
                _LocalApplication.ApplicationTypeID = _ApplicationTypeID;
                _LocalApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalApplication.ApplicantPersonID = _PersonID;
                _LocalApplication.LastStatusDate = DateTime.Now;
                _LocalApplication.LicenseClassID = (clsLicenseClass.enLicenseClassID)this._LicenseClassID;
                _LocalApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _LocalApplication.PaidFees = clsApplicationType.GetApplicationTypeFees((int)_ApplicationTypeID);
                _LocalApplication.LoggedUserID = clsGlobal.CurrentUser.UserID;
                if (!_LocalApplication.Save())
                    throw new Exception("Save Local Application Failed.");


                MessageBox.Show("Local Driving License Application was Saved Successfully", "Confirm Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLocalDrivingLicenseApplicationID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                _SetFormTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Local Driving License Application Save Failed !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            this.AcceptButton = btnNext;
        }
    }
}
