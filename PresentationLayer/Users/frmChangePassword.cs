using PresentationLayer.People;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using BusinessLayer.Core;
using static BusinessLayer.Core.clsUsersPermissions;
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Global.clsUtil;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Users
{
    public partial class frmChangePassword : clsBaseForm
    {
        private int? _UserID = null;
        private clsUser _User = null;
        bool _IsAdminModifyAnotherUser = false;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            SetTheme(this);
            _UserID = userID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.GetByID(_UserID.Value);
            if (_User == null)
            {
                ctrlUserCard1.ResetUserCard();
                MessageBox.Show($"Error: User with ID {_UserID?.ToString() ?? "N/A"} was not found.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool IsCurrentUserAdmin = CurrentUser.Permissions == GetPermissions("Admin");
            _IsAdminModifyAnotherUser = IsCurrentUserAdmin&&_User.UserID != CurrentUser.UserID;
            if (_IsAdminModifyAnotherUser)
            {
                txtCurrentPassword.Visible = false;
                lblPass.Visible = false;
                pbPass.Visible = false;
            }

            ctrlUserCard1.LoadUserInfo(_User);
            SetTitle("Change User Password");
            BeginInvoke(new Action(() => txtPassword.Focus()));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid. Please check the red icons.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_User == null)
                    throw new Exception("User object is null.");

                _User.LoggedUserID = CurrentUser.UserID ?? default;
                _User.Password = ComputeHash(txtConfirmPassword.Text.Trim());
                if (!_User.Save())
                    throw new Exception("Saving user failed.");

                MessageBox.Show("Password was changed successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Password change failed.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_IsAdminModifyAnotherUser)
                return;

            string input = txtCurrentPassword.Text.Trim();
            if(_User.Permissions!=GetPermissions("Admin"))
            {
                if (string.IsNullOrEmpty(input))
                {
                    errorProvider1.SetError(txtCurrentPassword, "This field is required!");
                    e.Cancel = true;
                    return;
                }

                if (_User != null && ComputeHash(input) != _User.Password)
                {
                    errorProvider1.SetError(txtCurrentPassword, "Password is not correct!");
                    e.Cancel = true;
                    return;
                }

                errorProvider1.SetError(txtCurrentPassword, string.Empty);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This field is required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(confirmPassword))
            {
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
                e.Cancel = true;
                return;
            }

            if (confirmPassword != password)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match!");
                errorProvider1.SetError(txtPassword, "Passwords do not match!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
                errorProvider1.SetError(txtPassword, string.Empty);
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
