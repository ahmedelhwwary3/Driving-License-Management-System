using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using static PresentationLayer.Global.clsGlobalData;
using PresentationLayer.Global;
using System.Drawing.Imaging;
using System.IO;
using static BusinessLayer.Core.clsPerson;
using Microsoft.VisualBasic.ApplicationServices;
using BusinessLayer.Core;
using PresentationLayer.Helpers.BaseUI;

using static PresentationLayer.Global.clsUtil;
using static PresentationLayer.Global.clsValidation;    

namespace PresentationLayer.People
{

    public partial class frmAddEditPerson : clsBaseForm
    {
        //First we fill _stkUndo with person states from Load() &  Save()
        //Then we use _stkUndo with _stkRedo together <->


        clsPerson _DeserializedPerson;
        Stack<MemoryStream> _stkUndo = new Stack<MemoryStream>();
        Stack<MemoryStream> _stkRedo = new Stack<MemoryStream>();

        Image OriginalImage;
        private int? _PersonID;
        private clsPerson _CurrentPerson = new clsPerson();
        private enum enMode
        { AddNew, Update };
        enMode _Mode;


        public frmAddEditPerson()
        {
            InitializeComponent();
            SetTheme(this);
            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            SetTheme(this);
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        #region DataBack Event 
        public event Action<object, int> DataBack;
        #endregion
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            ResetDefaultAddNewValues();
            if (_Mode == enMode.Update)
                LoadPersonData();
        }
        private void ResetDefaultAddNewValues()
        {

            SetTitle();
            this.FormClosed += (sender, e) =>
            {
                _stkUndo.Clear();
                _stkRedo.Clear();
            };
            btnUndo.Visible = false;
            btnRedo.Visible = false;
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
            FillCountriesInComboBox();
            cbCountries.SelectedIndex = cbCountries.FindString("Egypt");//Flexibility
            lblBrightness.Text = (10 * trackBar1.Value).ToString() + " %";
        }
        void SetTitle()
        {
            lblTitle.Text = _Mode == enMode.Update ? "Update Person" : "Add New Person";
            this.Text = _Mode == enMode.Update ? "Update Person" : "Add New Person";
        }
        private void LoadPersonData()
        {

            _CurrentPerson = clsPerson.GetByID(_PersonID.Value);
            if (_CurrentPerson == null)
            {
                MessageBox.Show($"Person with ID {_PersonID.ToString()} is not found",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;//To ensure that no code will run after 
            }

            SetTitle();
            try
            {
                if (_CurrentPerson.ImagePath != "")
                {
                    if (File.Exists(_CurrentPerson.ImagePath))
                    {
                        pbPersonImage.ImageLocation = _CurrentPerson.ImagePath;
                    }

                }
            }
            catch (Exception ex)
            {
                WindownsEventLog.Log(ex);
            }
            llRemove.Visible = (_CurrentPerson.ImagePath != "");

            dtpBirth.Value = _CurrentPerson.DateOfBirth;
            if (_CurrentPerson.Gendor == 0)
                rbMale.PerformClick();
            else
                rbFemale.PerformClick();
            txtEmail.Text = _CurrentPerson.Email;
            txtFirst.Text = _CurrentPerson.FirstName;
            txtSecond.Text = _CurrentPerson.SecondName;
            txtThird.Text = _CurrentPerson.ThirdName;
            txtLast.Text = _CurrentPerson.LastName;
            txtNationalNo.Text = _CurrentPerson.NationalNo;
            txtPhone.Text = _CurrentPerson.Phone;
            txtAddress.Text = _CurrentPerson.Address;
            cbCountries.SelectedIndex = cbCountries.FindString(_CurrentPerson.Country.CountryName);
            //Serialize Loaded Person .. First Undo
            clsPerson person = new(_CurrentPerson);
            MemoryStream stream = SerializeCurrentPersonState(person);
            _stkUndo?.Push(stream);


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
                FillCurrentPersonData();
                if (!ValidateDateToAge(_CurrentPerson))
                    return;
                if (_CurrentPerson.NationalityCountryID == null || (_CurrentPerson.PersonID == null && _Mode == enMode.Update))
                {
                    MessageBox.Show("Error:An unexpected error occurred while saving. " +
                     "Please try again later.", "Save failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!_CurrentPerson.Save())
                    throw new Exception("Person Save Failed.");

                //Send PersonID to Subscribed Forms
                DataBack?.Invoke(this, _CurrentPerson.PersonID.Value);
                //Fill Stack For Undo & Redo
                //Ensure that User did not save the same State
                clsPerson person = new clsPerson(_CurrentPerson);
                MemoryStream stream = SerializeCurrentPersonState(person);
                _stkUndo?.Push(stream);
                //If the stack history changed , the Redo not make sense 
                btnRedo.Visible = false;
                _stkRedo?.Clear();
                btnUndo.Visible = (_Mode == enMode.Update);

                _Mode = enMode.Update;
                SetTitle();
                lblPersonID.Text = _CurrentPerson?.PersonID.ToString();
                MessageBox.Show(" Person was saved successfully", "Confirm Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
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
            if (_CurrentPerson.ImagePath != pbPersonImage.ImageLocation)
            {
                //Delete the old image from disk if changed or removed
                if (!string.IsNullOrEmpty(_CurrentPerson.ImagePath))
                    DeleteImageFile();
                ///Handle 1.removed
                //If Image was "removed" , so the Image is already handeled => "" ::return true;
                //Here we ensure for safety that Compiler will understand that :
                //If ImageLocation==null <-- is the same as --> ImageLocation==""
                if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                {
                    _CurrentPerson.ImagePath = string.Empty;
                    return true;
                }
                ///Handle 2.Change or 3.Added
                string SourceFilePath = pbPersonImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToImagesFile(ref SourceFilePath))
                {
                    _CurrentPerson.ImagePath = SourceFilePath;
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
        void DeleteImageFile()
        {
            try
            {
                if (File.Exists(_CurrentPerson.ImagePath))
                    File.Delete(_CurrentPerson.ImagePath);
            }
            catch (FileNotFoundException ex)
            {
                WindownsEventLog.Log(ex);
            }
        }
        void FillCountriesInComboBox()
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
            string NationalNo = txtNationalNo.Text.Trim();
            if (string.IsNullOrEmpty(NationalNo))
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
            if (clsPerson.IsExist(NationalNo))
            {
                if(_Mode == enMode.AddNew||(_Mode == enMode.Update && _CurrentPerson.NationalNo != NationalNo))
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


        public Image SetImageBrightness(Image image, float brightness)
        {
            float[][] ptsArray = {
              new float[] {1, 0, 0, 0, 0},
              new float[] {0, 1, 0, 0, 0},
              new float[] {0, 0, 1, 0, 0},
              new float[] {0, 0, 0, 1, 0},
              new float[] {brightness, brightness, brightness, 0, 1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            Bitmap newBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(image, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return newBitmap;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                return;
            //Original Image will not be changed
            using (var temp = Image.FromFile(pbPersonImage.ImageLocation))
                OriginalImage = new Bitmap(temp);//To solve pbox Lock Problem
            lblBrightness.Text = (trackBar1.Value * 10).ToString() + " $";
            pbPersonImage.Image = SetImageBrightness(OriginalImage, trackBar1.Value / 10f);
        }




        clsPerson DeserializeCurrentPersonState(MemoryStream stream)
            => _DeserializedPerson = DeserializeObjectJSONformat<clsPerson>(stream);
        void DisplayDerserializedPersonState(clsPerson person)
        {
            if (person == null)
            {
                MessageBox.Show("Error:Person Previous State was not saved !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            llRemove.Visible = (person.ImagePath != "");
            dtpBirth.Value = person.DateOfBirth;
            if (person.Gendor == 0)
                rbMale.PerformClick();
            else
                rbFemale.PerformClick();
            txtEmail.Text = person.Email;
            txtFirst.Text = person.FirstName;
            txtSecond.Text = person.SecondName;
            txtThird.Text = person.ThirdName;
            txtLast.Text = person.LastName;
            txtNationalNo.Text = person.NationalNo;
            txtPhone.Text = person.Phone;
            txtAddress.Text = person.Address;
            cbCountries.SelectedIndex = cbCountries.FindString(person.Country.CountryName);
            try
            {
                if (person.ImagePath != "")
                {
                    if (File.Exists(person.ImagePath))
                    {
                        pbPersonImage.ImageLocation = person.ImagePath;
                    }

                }
            }
            catch (Exception ex)
            {
                WindownsEventLog.Log(ex);
            }
        }


        void FillCurrentPersonData()
        {
            _CurrentPerson.LoggedUserID = CurrentUser.UserID.Value;
            _CurrentPerson.Email = txtEmail.Text.Trim();
            _CurrentPerson.NationalNo = txtNationalNo.Text.ToUpper().Trim();
            _CurrentPerson.NationalityCountryID = clsCountry.GetByName(cbCountries.Text).CountryID.Value;
            _CurrentPerson.Address = txtAddress.Text.Trim();
            _CurrentPerson.FirstName = txtFirst.Text.Trim();
            _CurrentPerson.SecondName = txtSecond.Text.Trim();
            _CurrentPerson.ThirdName = txtThird.Text.Trim();
            _CurrentPerson.LastName = txtLast.Text.Trim();
            if (rbMale.Checked)
                _CurrentPerson.Gendor = enGendor.Male;
            else
                _CurrentPerson.Gendor = enGendor.Female;

            _CurrentPerson.Phone = txtPhone.Text.Trim();
            _CurrentPerson.DateOfBirth = dtpBirth.Value;
        }

        MemoryStream SerializeCurrentPersonState(clsPerson person)
            => SerializeObjectJSONformat<clsPerson>(person);
        private void btnUndo_Click(object sender, EventArgs e)
        {
            btnRedo.Visible = true;
            UpdatePersonStacks(IsUndo: true);
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            UpdatePersonStacks(IsUndo: false);
        }

        void UpdatePersonStacks(bool IsUndo)
        {
            clsPerson person = new clsPerson(_CurrentPerson);
            MemoryStream CurrentStream = SerializeCurrentPersonState(person);
            //1.Push the Current State
            if (IsUndo)
                _stkRedo?.Push(CurrentStream);
            else
                _stkUndo?.Push(CurrentStream);

            MemoryStream PrevStream = IsUndo ? _stkUndo?.Pop() : _stkRedo?.Pop();
            //2.Get Previous Stream Person for Deserialization (from Stack) and Display
            //It will be the Current PersonState
            _CurrentPerson = DeserializeCurrentPersonState(PrevStream);
            DisplayDerserializedPersonState(_CurrentPerson);
            //3.Check if There is no Person States remainded
            btnUndo.Enabled = _stkUndo.Count > 0;
            btnRedo.Enabled = _stkRedo.Count > 0;
        }

    }
}
 