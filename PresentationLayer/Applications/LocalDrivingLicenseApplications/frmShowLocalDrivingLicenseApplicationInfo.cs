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

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class frmShowLocalDrivingLicenseApplicationInfo : Form
    {
        private int? _LocalDrivingLicenseApplicationID =null;
        public frmShowLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void frmShowLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLocalApplicationInfo))
                return;
            ctrlDrivingLicenesApplicationInfo1.LoadLocalApplication(_LocalDrivingLicenseApplicationID.Value);
        }
           

    }
}
