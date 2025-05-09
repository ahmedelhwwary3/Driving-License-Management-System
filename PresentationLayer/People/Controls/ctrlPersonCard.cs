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

namespace PresentationLayer.People
{
    public partial class ctrlPersonCard : UserControl
    {
        clsPerson _Person = new clsPerson();
        public ctrlPersonCard()
        {
            InitializeComponent();
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
            //Check Existence First
            _Person = clsPerson.GetByID(PersonID);

            if (_Person == null)
            {
                this.ResetDefaultValues();
                MessageBox.Show("Error:Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEdit.Enabled = false;
                return;
            }
            _LoadDataToCTRL();
        }
        private void _LoadDataToCTRL()
        {
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.Country.CountryName;
            lblEmail.Text = _Person.Email;      
                 lblDateOfBirth.Text = clsFormat.DateToShortString(_Person.DateOfBirth);
            lblNationalNo.Text = _Person.NationalNo;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblPhone.Text = _Person.Phone;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            //Better than ImageLoading to avoid Locking when deleting
            if (_Person.ImagePath != string.Empty && File.Exists(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;
            llEdit.Enabled = true;
        }
        public void LoadPerson(string NationalNo)
        {
            _Person = clsPerson.GetByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetDefaultValues();
                MessageBox.Show("Error:Person is not found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEdit.Enabled = false;
                return;

            }
            _LoadDataToCTRL();
        }
        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            frmAddEditPerson frm = new frmAddEditPerson((int)_Person.PersonID);
            frm.ShowDialog();
            LoadPerson((int)_Person.PersonID);//Refresh
        }
    }
}
