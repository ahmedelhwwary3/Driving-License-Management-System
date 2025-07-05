using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;
using PresentationLayer.Properties;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using static BusinessLayer.Core.clsUsersPermissions;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.People
{
    public partial class ctrlPersonCard : clsBaseCtrl
    {
        private clsPerson _Person = new clsPerson();

        public ctrlPersonCard()
        {
            InitializeComponent();
            SetTheme(this);
        }

        public clsPerson Person => _Person;

        public void ResetDefaultValues()
        {
            lblAddress.Text = "[????]";
            lblCountry.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblEmail.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblPhone.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
            llEdit.Enabled = false;
        }

        public void LoadPerson(int PersonID)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;

            _Person = clsPerson.GetByID(PersonID);

            if (_Person == null)
            {
                ResetDefaultValues();
                MessageBox.Show("Error: Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEdit.Enabled = false;
                return;
            }

            LoadDataToCTRL();
        }

        public void LoadPerson(string NationalNo)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;

            _Person = clsPerson.GetByNationalNo(NationalNo);

            if (_Person == null)
            {
                ResetDefaultValues();
                MessageBox.Show("Error: Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEdit.Enabled = false;
                return;
            }

            LoadDataToCTRL();
        }

        private void LoadDataToCTRL()
        {
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.Country.CountryName;
            lblDateOfBirth.Text = clsFormat.DateToShortString(_Person.DateOfBirth);
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";

            pbPersonImage.Image = _Person.Gendor == 0 ?
                Resources.Male_512 : Resources.Female_512;

            if (!string.IsNullOrWhiteSpace(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;

            llEdit.Enabled = true;
        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmAddEditPerson(_Person.PersonID.Value);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);

            LoadPerson(_Person.PersonID.Value); // Refresh
        }
    }
}
