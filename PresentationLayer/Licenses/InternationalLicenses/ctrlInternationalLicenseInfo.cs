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
using System.IO;
using System.Windows.Forms;

namespace PresentationLayer.Licenses.InternationalLicenses
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
 
        private clsInternationalLicense _InternationalLicense=new clsInternationalLicense();
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }




        public clsInternationalLicense InternationalLicense => _InternationalLicense;

        private Boolean _LoadPersonImage()
        {
            pbPersonImage.Image = InternationalLicense.Driver.Person.Gendor == 0 ?
                Resources.Male_512 : Resources.Female_512;
            string ImagePath = _InternationalLicense.Driver.Person.ImagePath;

            try
            {
                if (ImagePath == string.Empty)
                    return true;
                if(!File.Exists(ImagePath))
                {
                    MessageBox.Show($"Error:Could not find ImagePath \n\" {ImagePath} \" !",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                pbPersonImage.Load(ImagePath);
            }
            catch (FileLoadException ex)
            {
                clsGlobal.LogError(ex);
                return false;
            }
            return false;
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            if (!_LoadPersonImage())
                return;
            _InternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(InternationalLicenseID);
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicense.InternationalApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblFullName.Text = _InternationalLicense.Driver.Person.FullName;
            lblNationalNo.Text = _InternationalLicense.Driver.Person.NationalNo;
            lblGendor.Text = _InternationalLicense.Driver.Person.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShortString(_InternationalLicense.Driver.Person.DateOfBirth);
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShortString(_InternationalLicense.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShortString(_InternationalLicense.ExpirationDate);
            



        }







    }
}
