using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentationLayer.Users
{
    public partial class frmAddEditUser : Form
    {
        private int _UserID;
        private clsUser _User = new clsUser();
        int? _PersonID = null;
        DataTable _dtAllPermissions = new DataTable();
        public enum enMode
        { AddNew, Update };
        private enMode Mode;
        public frmAddEditUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = enMode.Update;
        }
        void _SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlPersonCardWithFilter1.FindBtn;
            BeginInvoke(new Action(() => ctrlPersonCardWithFilter1.FilterFocus()));
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {

            _SetFocusOntxtFilter();
            _ResetDefaultValues();//2 Modes

            if (Mode == enMode.Update)
                _LoadData();

        }
         
        private void ChangeLabelAndText()
        {
            this.Text = (Mode == enMode.Update ? "Edit User" : "Add New User");
            lblAddEditUser.Text = (Mode == enMode.Update ? "Edit User" : "Add New User");
        }
        private void _ResetDefaultValues()
        {
            this.ctrlPersonCardWithFilter1.OnPersonSelected += (PersonID) =>
                {
                    _PersonID = PersonID;
                    AcceptButton = btnNext;
                };


            if (Mode == enMode.AddNew)
            {
                ctrlPersonCardWithFilter1.FilterFocus();
                btnSave.Enabled = false;
                tcAddNewUser.TabPages[1].Enabled = false;//Disable Login Info 
            }
            //In 2 Modes
            ChangeLabelAndText();
            _FillPermissionsCB();
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            chkIsActive.Checked = true;
        }
        void _FillPermissionsCB()
        {
            _dtAllPermissions = clsUsersPermissions.GetAllPermissions();
            foreach (DataRow permission in _dtAllPermissions.Rows)
                cbPermissions.Items.Add(permission["Access"]);
            cbPermissions.SelectedIndex = cbPermissions.FindString("Editor");
            if (clsGlobal.CurrentUser.PermissionsData.Access.Trim() != "Admin")
                cbPermissions.Enabled = false;
        }
        private void _LoadData()
        {
            _User = clsUser.GetByID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"Error:User with ID {_UserID.ToString()} is not found !",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID = _User.PersonID;
            ctrlPersonCardWithFilter1.LoadPerson(_PersonID.Value);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            btnSave.Enabled = true;
            txtUserName.Text = _User.UserName;
            txtUserName.Focus();
            tcAddNewUser.SelectedTab = tcAddNewUser.TabPages["tpLoginInfo"];
        }
         
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                MoveNextPage();
                return;
            }
            //AddNew
            if (_PersonID != null)
            {
                //Ensure that No User Existed with same PersonID
                if (clsUser.GetByPersonID(_PersonID) != null)
                {
                    MessageBox.Show("Error:This person is taken by another user " +
                        "! Please Use another one.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MoveNextPage();
                return;
            }
            else
                MessageBox.Show("Error:This person is not found", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void MoveNextPage()
        {
            BeginInvoke(new Action(() => AcceptButton = btnSave));
            tcAddNewUser.TabPages[1].Enabled = true;
            btnSave.Enabled = true;
            tcAddNewUser.SelectedTab = tcAddNewUser.TabPages["tpLoginInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error:Some Fields are not valid !" +
                    " Please Check the red icon messages"
                    , "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                //User is new with Data or Old with Updated data
                _User.LoggedUserID = clsGlobal.CurrentUser.UserID;
                _User.Permissions = clsUsersPermissions.GetByAccessType(cbPermissions.Text).Access;
                _User.UserName = txtUserName.Text.Trim();
                _User.Password = clsUtil.ComputeHash(txtPassword.Text.Trim());
                _User.PersonID = ctrlPersonCardWithFilter1.Person.PersonID;
                _User.IsActive = chkIsActive.Checked;
                _User.Permissions = clsUsersPermissions.GetByAccessType(cbPermissions.Text).Access;
                if (_User.PersonID == null || (_User.UserID == null && Mode == enMode.Update))
                {
                    MessageBox.Show("Error:An unexpected error occurred while saving. " +
                      "Please try again later.", "Save failed", MessageBoxButtons.OK);
                    return;
                }
                if (!_User.Save())
                    throw new Exception($"Save User with PersonID {(int)_User.PersonID} Failed.");

                ctrlPersonCardWithFilter1.FilterEnabled = false;
                Mode = enMode.Update;
                ChangeLabelAndText();
                MessageBox.Show("User Updated successfully", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                      "Please try again later.", "Save failed", MessageBoxButtons.OK
                      , MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }
        }





        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName,
                    "This field is required !");
                e.Cancel = true;
                return;

            }
            else
            {

                errorProvider1.SetError(txtUserName, null);
                e.Cancel = false;
            }
            //User Names are distinct in system
            if (Mode == enMode.AddNew && clsUser.IsExistedByUserName(txtUserName.Text.Trim()))
            {

                errorProvider1.SetError(txtUserName,
                    "This username is taken by another user !" +
                    " Plesase Choose another one.");
                e.Cancel = true;
            }
            else
            {

                errorProvider1.SetError(txtUserName, null);
                e.Cancel = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field is required !");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword,
                    "Passwords are not matched with each other !");
                errorProvider1.SetError(txtPassword,
                    "Passwords are not matched with each other !");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                e.Cancel = false;
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtConfirmPassword, "This field is required !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            this.Close();
        }
    }


}
        
    
        

