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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users
{
    public partial class frmChangePassword : Form
    {
        private int? _UserID = null;
        private clsUser _User = new clsUser();
        DataTable _dtAllPermissions=new DataTable();
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }
        void _FillPermissionsCB()
        {
            _dtAllPermissions = clsUsersPermissions.GetAllPermissions();
            foreach (DataRow permission in _dtAllPermissions.Rows)
                cbPermissions.Items.Add(permission["Access"]);
            cbPermissions.SelectedIndex = cbPermissions.FindString("Editor");
            if (_User.PermissionsData.Access!= "Admin")
                cbPermissions.Enabled = false;
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            
            _User = clsUser.GetByID(_UserID);
            if (_User == null)
            {
                this.ctrlUserCard1.ResetUserCard();
                MessageBox.Show($"Error:User with ID {_UserID.ToString()} is not found !",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPermissionsCB();
            BeginInvoke(new Action(()=>txtPassword.Focus()));
            ctrlUserCard1.LoadUserInfo(_User);//To Avoid Loading Again
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
                _User.Permissions = clsUsersPermissions.GetByAccessType(cbPermissions.Text).Access;
                _User.LoggedUserID=clsGlobal.CurrentUser.UserID;
                _User.Password = clsUtil.ComputeHash(txtConfirmPassword.Text.Trim());

                if (_User == null)
                {
                    MessageBox.Show("Error:Password change Failed", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!_User.Save())
                    throw new Exception($"Save User Failed.");

                MessageBox.Show("Password was changed successfully",
                   "succeeded", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Password change Failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                clsGlobal.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();




        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "This Field is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
                e.Cancel = false;
            }
            if (clsUtil.ComputeHash(txtCurrentPassword.Text.Trim()) != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Password is not correct !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "This Field is required !");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtConfirmPassword, "This Field is required !");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
                e.Cancel = false;
            }

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword,
                    "Passwords are not matched with each other !");
                errorProvider1.SetError(txtPassword,
                    "Passwords are not matched with each other !");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                e.Cancel = false;
            }

        }

        private void txtCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
