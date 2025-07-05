using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class frmShowLocalDrivingLicenseApplicationInfo : clsBaseForm
    {
        private int? _LocalDrivingLicenseApplicationID =null;
        public frmShowLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            SetTheme(this);
            _LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void frmShowLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            SetTitle("Show Local Driving License Application Info");
            if (!CheckUserAccess(GetPermissions("View")))
                return;
            ctrlDrivingLicenesApplicationInfo1.LoadLocalApplication(_LocalDrivingLicenseApplicationID.Value);
        }
           

    }
}
