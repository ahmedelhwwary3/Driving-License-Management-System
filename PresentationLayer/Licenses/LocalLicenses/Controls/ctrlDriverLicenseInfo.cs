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
using System.IO;

namespace PresentationLayer.Licenses.LocalLicenses
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int? _LicenseID = null;
        private clsLicense _License=new clsLicense();

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();

        }

        public int? LicenseID => _LicenseID;



        public clsLicense License => _License;



        private void _LoadPersonImage()
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
            _License = clsLicense.GetByID(_LicenseID);
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
            lblDateOfBirth.Text = clsFormat.DateToShortString(_License.Driver.Person.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShortString(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShortString(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "N/A" : _License.Notes;
            _LoadPersonImage();
        }

    }
}
