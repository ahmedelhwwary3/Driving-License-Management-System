using BusinessLayer.Core;
using PresentationLayer.Helpers.BaseUI;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.Licenses.LocalLicenses
{
    public partial class frmIssueDrivingLicenesForFirstTime : clsBaseForm
    {
        private int _LocalDrivingLicenseApplicationID = default;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication =new clsLocalDrivingLicenseApplication();

        public frmIssueDrivingLicenesForFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            SetTheme(this);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void RefreshForm()
        {
            ctrlDrivingLicenesApplicationInfo1.ResetDefaultValues();
            txtNotes.Enabled = false;
        }
        private void frmIssueDrivingLicenesForFirstTime_Load(object sender, EventArgs e)
        {
            SetTitle("Issue Driving License");
            txtNotes.Text = string.Empty;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"Error:Local Driving License Application with ID " +
                    $"{_LocalDrivingLicenseApplication} is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshForm();
                return;
            }
            ctrlDrivingLicenesApplicationInfo1?.LoadLocalApplication(_LocalDrivingLicenseApplicationID);
            txtNotes.Focus();
            txtNotes.Enabled = true;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int? LicenseID = _LocalDrivingLicenseApplication?.IssueDrivingLicenseForFirstTime(CurrentUser.UserID.Value, txtNotes.Text.Trim());
            if (LicenseID == null)
            {

                MessageBox.Show("Error:Error with saving New License", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnIssueLicense.Enabled = false;
            MessageBox.Show("Save succeeded", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
