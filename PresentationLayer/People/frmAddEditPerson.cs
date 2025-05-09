using BusinessLayer;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
 
using PresentationLayer.Global;
 
 

namespace PresentationLayer.People
{
    public partial class frmAddEditPerson : Form
    {
        private int? _PersonID;
        private clsPerson _Person = new clsPerson();
        private enum enMode
        { AddNew, Update };
        enMode _Mode;
        enum enGendor
        { Male = 0, Female = 1 }

        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        #region DataBack Event 
        //public event Action<object, int> DataBack;//Same
        public delegate void DataBackEventHandler(object sender, int PersonID);//Class Type
        public DataBackEventHandler DataBack;//Reference 
        #endregion
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            this.BeginInvoke(new Action(() => txtFirst.Focus()));
            _ResetDefaultAddNewValues();
            if (_Mode == enMode.Update)
                _LoadPersonData();
        }
        private void _ResetDefaultAddNewValues()
        {
            //AddNew      
            _SetTitle();
            txtAddress.Multiline = true;
            lblPersonID.Text = "N/A";
            txtFirst.Text = "";
            txtSecond.Text = "";
            txtThird.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            dtpBirth.MaxDate = DateTime.Now.AddYears(-18);//Person age must be >= 18
            dtpBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpBirth.Value = dtpBirth.MaxDate;//Age=18
            rbMale.Checked = true;
            txtAddress.Text = "";
            llRemove.Visible = false;
            _FillCountriesInComboBox();
            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");//Flexibility

        }
        void _SetTitle()
        {
            lblTitle.Text = _Mode == enMode.Update ? "Update Person" : "Add New Person";
            this.Text = _Mode == enMode.Update ? "Update Person" : "Add New Person";
        }
        private void _LoadPersonData()
        {

            _Person = clsPerson.GetByID(_PersonID.Value);
            if (_Person == null)
            {
                MessageBox.Show($"Person with ID {_PersonID.ToString()} is not found",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;//To ensure that no code will run after 
            }
            _SetTitle();
            llRemove.Visible = (_Person.ImagePath != "");
            dtpBirth.Value = _Person.DateOfBirth;
            if (_Person.Gendor == 0)
                rbMale.PerformClick();
            else
                rbFemale.PerformClick();
            txtEmail.Text = _Person.Email;
            txtFirst.Text = _Person.FirstName;
            txtSecond.Text = _Person.SecondName;
            txtThird.Text = _Person.ThirdName;
            txtLast.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.Country.CountryName);
            try
            {
                if (_Person.ImagePath != "")
                {
                    if (File.Exists(_Person.ImagePath))
                    {
                        pbPersonImage.ImageLocation = _Person.ImagePath;
                    }

                }
            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
            }

        }


        void _SetImageToDefault()
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.DefaultExt = ".JPG";
            openFileDialog1.Filter = "All files (*.*)|*.*| (*.PNG)|*.PNG| (*.JPG)|*.JPG|  (*.JPEG)|*.JPEG";
            openFileDialog1.FilterIndex = 1;//Start from 1 (not 0)
            openFileDialog1.Title = "Choose Image";
            openFileDialog1.InitialDirectory = $"F:\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = ImagePath;//Load image
                if (pbPersonImage.ImageLocation != null)
                    llRemove.Visible = true;//Default is false (Add New)
            }
        }
        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _SetImageToDefault();
            llRemove.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid ! Please check red icon messages",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!HandlePersonImage())
                return;
            try
            {

                //if AddNew , PersonID is not needed
                //if Update , PersonID is Loaded in the object
                _Person.LoggedUserID=clsGlobal.CurrentUser.UserID;
                _Person.Email = txtEmail.Text.Trim();
                _Person.NationalNo = txtNationalNo.Text.ToUpper().Trim();
                _Person.NationalityCountryID = clsCountry.GetByName(cbCountries.Text).CountryID;
                _Person.Address = txtAddress.Text.Trim();
                _Person.DateOfBirth = dtpBirth.Value;
                _Person.FirstName = txtFirst.Text.Trim();
                _Person.SecondName = txtSecond.Text.Trim();
                _Person.ThirdName = txtThird.Text.Trim();
                _Person.LastName = txtLast.Text.Trim();
                if (rbMale.Checked)
                    _Person.Gendor = (int)enGendor.Male;
                else
                    _Person.Gendor = (int)enGendor.Female;

                _Person.Phone = txtPhone.Text.Trim();
                if (_Person.NationalityCountryID == null || (_Person.PersonID == null && _Mode == enMode.Update))
                {
                    MessageBox.Show("Error:An unexpected error occurred while saving. " +
                     "Please try again later.", "Save failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!_Person.Save())
                    throw new Exception("Person Save Failed.");

                //Send PersonID to Subscribed Forms
                DataBack?.Invoke(this, _Person.PersonID.Value);
                _Mode = enMode.Update;
                _SetTitle();
                lblPersonID.Text = _Person.PersonID.ToString();
                MessageBox.Show(" Person was saved successfully", "Confirm Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                    "Please try again later.", "Save failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool HandlePersonImage()
        {
            //Image has been (removed or changed or Added)
            //if AddNew::_PersonImage=""

            ///3 expected cases:
            //1.Person has Image and Location does not have (Remove)
            //2.Person has Image and Location has another one(Changed)
            //3.Person does not have image and Location has (Added)
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                //Delete the old image from disk if changed or removed
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                    _DeleteImageFile();
                ///Handle 1.removed
                //If Image was "removed" , so the Image is already handeled => "" ::return true;
                //Here we ensure for safety that Compiler will understand that :
                //If ImageLocation==null <-- is the same as --> ImageLocation==""
                if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                {
                    _Person.ImagePath = string.Empty;
                    return true;
                }
                ///Handle 2.Change or 3.Added
                string SourceFilePath = pbPersonImage.ImageLocation.ToString();
                if (clsUtil.CopyImageToImagesFile(ref SourceFilePath))
                {
                    _Person.ImagePath = SourceFilePath;
                    return true;
                }
                else
                    return false;
            }
            else
                //Image was not changed or removed or added
                //(Same Image State will be saved)
                return true;
        }
        void _DeleteImageFile()
        {
            try
            {
                if (File.Exists(_Person.ImagePath))
                    File.Delete(_Person.ImagePath);
            }
            catch (FileNotFoundException ex)
            {
                clsGlobal.LogError(ex);
            }
        }
        void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountriesList();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }





        private void rbMale_CheckedChanged(object sender, EventArgs e)
            => pbPersonImage.Image = Resources.Male_512;
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
            => pbPersonImage.Image = Resources.Female_512;

        private void frmAddEditPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSave.PerformClick();
        }

        private void txtAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAddress.Multiline)
                e.IsInputKey = true; //Disable (Accept Button in this CTRL)
        }

        private void txtBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }



        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void txtFirst_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirst.Text.Trim()))
            {

                errorProvider1.SetError(txtFirst, "This Field is required !");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirst, null);
            }
        }

        private void txtSecond_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtSecond.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSecond, "This Field is required !");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSecond, null);
            }
        }

        private void txtLast_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLast.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLast, "This Field is required !");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLast, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {

                errorProvider1.SetError(txtNationalNo, "This Field is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }

            //Another person has the same National No
            if (_Mode == enMode.AddNew && clsPerson.IsExist(txtNationalNo.Text.Trim()))
            {

                errorProvider1.SetError(txtNationalNo, "There is a person already having this national No !");
                e.Cancel = true;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }


        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {

                errorProvider1.SetError(txtPhone, "This Field is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, null);

            }
            if (!clsValidation.IsValidEgyptianNumber(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Invalid Egyptian Phone Number !");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {

                errorProvider1.SetError(txtEmail, "This Filed is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }

            if (!clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email is not valid");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "This Field is required !");
 
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, null);
            }
        }
    }
}
