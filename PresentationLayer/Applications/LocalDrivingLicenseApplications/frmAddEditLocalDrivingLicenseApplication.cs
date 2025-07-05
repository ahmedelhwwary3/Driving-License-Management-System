using PresentationLayer.Global;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static PresentationLayer.Global.clsGlobalData;
using System.Windows.Forms;
using BusinessLayer.Core;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsApplication;
using static PresentationLayer.Global.clsFormat;
using static BusinessLayer.Core.clsLicenseClass;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddEditLocalDrivingLicenseApplication : clsBaseForm
    {
        enum enMode { AddNew, Update };
        enMode _Mode = enMode.AddNew;

        clsLocalDrivingLicenseApplication _LocalApplication = new clsLocalDrivingLicenseApplication();
        int? _LocalDrivingLicenseApplicationID = null;
        int _PersonID = default;

        int? _LicenseClassID =>
            (int)clsLicenseClass.GetByClassName(cbLicenesClass.Text).LicenseClassID;

        enApplicationType _ApplicationTypeID = enApplicationType.NewLocalDrivingLicenseService;

        public frmAddEditLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            SetTheme(this);
            _Mode = enMode.AddNew;
        }

        public frmAddEditLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            SetTheme(this);
            _Mode = enMode.Update;
        }

        private void frmAddEditLocalDrivingLicenseApplication_Shown(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;

            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                LoadDataInUpdateMode();
        }

        private void _ResetDefaultValues()
        {
            FillLicenseClassesInComboBox();
            SetFormTitle();

            if (_Mode == enMode.AddNew)
            {
                this.AcceptButton = ctrlPersonCardWithFilter1.FindBtn;
                EnableForm(false);
                SetTCPage2DefaultValues();
                ctrlPersonCardWithFilter1.FilterFocus();
                return;
            }

            this.AcceptButton = this.btnNext;
            EnableForm(true);
        }

        void SetTCPage2DefaultValues()
        {
            int ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicenseService;

            lblApplicationFees.Text = clsApplicationType.GetApplicationTypeFees(ApplicationTypeID).ToString("F2");
            lblApplicationDate.Text = DateToShortString(DateTime.Now);
            lblCreatedByUserName.Text = CurrentUser.UserName;
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            cbLicenesClass.SelectedIndex = 2; // Ordinary class
        }

        void EnableForm(bool Enable)
        {
            btnSave.Enabled = Enable;
            tpApplicationInfo.Enabled = Enable;
        }

        void SetFormTitle()
        {
            if (_Mode == enMode.AddNew)
            {
                base.SetTitle("Add New Local Driving License Application");
                lblAddEditLocalDrivingLicenseApplication.Text = "Add New Local Driving License Application";
            }
            else
            {
                base.SetTitle("Update Local Driving License Application");
                lblAddEditLocalDrivingLicenseApplication.Text = "Update Local Driving License Application";
            }
        }

        private void LoadDataInUpdateMode()
        {
            _LocalApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(_LocalDrivingLicenseApplicationID.Value);
            if (_LocalApplication == null)
            {
                MessageBox.Show("Local Driving License Application is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCardWithFilter1.LoadPerson(_LocalApplication.ApplicantPersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            lblApplicationDate.Text = DateToShortString(_LocalApplication.ApplicationDate);
            lblApplicationFees.Text = _LocalApplication.PaidFees.ToString("F2");
            lblCreatedByUserName.Text = _LocalApplication.CreatedByUser.UserName;
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            cbLicenesClass.SelectedIndex = cbLicenesClass.FindString(_LocalApplication.LicenseClass.ClassName);
        }

        void MoveNext()
        {
            tcAddNewUser.SelectedTab = tpApplicationInfo;
            this.AcceptButton = btnSave;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                MoveNext();
                return;
            }

            if (_PersonID == null)
            {
                MessageBox.Show($"Error:Person with ID {_PersonID} is not found!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnableForm(true);
            MoveNext();
        }

        void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void FillLicenseClassesInComboBox()
        {
            DataTable LicenseClasses = clsLicenseClass.GetAllLicenseClasssList();
            foreach (DataRow r in LicenseClasses.Rows)
            {
                cbLicenesClass.Items.Add(r["ClassName"]);
            }
        }

        bool HandleChecksBeforeSave()
        {
            if (_Mode == enMode.AddNew)
            {
                if (clsLocalDrivingLicenseApplication.HasActiveApplicationForLicenseClass(_PersonID, clsApplication.enApplicationType.NewLocalDrivingLicenseService, (int)_LicenseClassID))
                {
                    MessageBox.Show("Error:This Person has an active Local Driving License Application with This License Class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (clsLicense.HasPersonActiveLicensePerLicenseClass(_PersonID, _LicenseClassID.Value))
                {
                    MessageBox.Show("Error:This Person has already a License with This License Class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!HandleChecksBeforeSave())
                return;

            if (!DateTime.TryParseExact(lblApplicationDate.Text, "dd/MM/yyyy",
                 System.Globalization.CultureInfo.InvariantCulture,
                 System.Globalization.DateTimeStyles.None,
                 out DateTime date))
            {
                MessageBox.Show("Error:An unexpected error happened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog?.Log(new FormatException("Error while parsing lblApplicationDate to date."));
                return;
            }

            try
            {
                _LocalApplication.ApplicationDate = date;
                _LocalApplication.ApplicationTypeID = (int)_ApplicationTypeID;
                _LocalApplication.ApplicationStatus =(int)enApplicationStatus.New;
                _LocalApplication.ApplicantPersonID = _PersonID;
                _LocalApplication.LastStatusDate = DateTime.Now;
                _LocalApplication.LicenseClassID = _LicenseClassID.Value;
                _LocalApplication.CreatedByUserID = CurrentUser.UserID.Value;
                _LocalApplication.PaidFees = clsApplicationType.GetApplicationTypeFees((int)_ApplicationTypeID);
                _LocalApplication.LoggedUserID = CurrentUser.UserID.Value;

                if (!_LocalApplication.Save())
                    throw new Exception("Save Local Application Failed.");

                MessageBox.Show("Local Driving License Application was Saved Successfully", 
                    "Confirm Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLocalDrivingLicenseApplicationID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                SetFormTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Local Driving License Application Save Failed!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog?.Log(ex);
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
            this.AcceptButton = btnNext;
        }
    }
}
