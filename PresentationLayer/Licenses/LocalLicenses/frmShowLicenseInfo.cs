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

namespace PresentationLayer.Licenses.LocalLicenses
{
    public partial class frmShowLicenseInfo : clsBaseForm
    {
        private int _LicenseID = default;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            SetTheme(this);
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            SetTitle("Show License Information");
            ctrlDriverLicenseInfo1?.LoadInfo(_LicenseID);
        }
    }
}
