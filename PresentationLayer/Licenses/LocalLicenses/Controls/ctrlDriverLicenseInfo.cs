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
using System.IO;
using BusinessLayer.Core;
using PresentationLayer.Helpers;
using static PresentationLayer.Global.clsFormat;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Licenses.LocalLicenses
{
    public partial class ctrlDriverLicenseInfo : clsBaseCtrl
    {
        private int? _LicenseID = null;
        private clsLicense _License=new clsLicense();

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
            SetTheme(this);
        }

        public int? LicenseID => _LicenseID;



        public clsLicense License => _License;



        private void LoadPersonImage()
        {
            if (_License.Driver.Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.Driver.Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation= ImagePath;
        
        }
        public void ResetCTRL()
        {
            lblClass.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblIsDetained.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblNotes.Text = "[????]";
            pbGendor.ImageLocation= string.Empty;
            pbPersonImage.ImageLocation = string.Empty;
        }
        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.GetByID(_LicenseID.Value);
            if (_License == null)
            {
                MessageBox.Show($"Error:Could not find License !",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = null;
                return;
            }
            lblLicenseID.Text = _LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsLicenseDetained() ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblFullName.Text = _License.Driver.Person.FullName;
            lblNationalNo.Text = _License.Driver.Person.NationalNo;
            lblGendor.Text = _License.Driver.Person.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = DateToShortString(_License.Driver.Person.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = DateToShortString(_License.IssueDate);
            lblExpirationDate.Text = DateToShortString(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "N/A" : _License.Notes;
            LoadPersonImage();
        }

    }
}
