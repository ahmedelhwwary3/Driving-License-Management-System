using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
         => InitializeComponent();

        private void btnClose_Click(object sender, EventArgs e)
         => this.Close();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            clsGlobal.GetStoredCredentialsFromRegistry(ref UserName, ref Password);
            _LoadCredintialsInCTRLs(UserName, Password);
        }
        void _LoadCredintialsInCTRLs(string UserName, string Password)
        {
            txtUserName.Text = UserName;
            txtPassword.Text = Password;
            btnLogin.Focus();
            chkRemember.Checked = true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string HashedPassword = clsUtil.ComputeHash(this.txtPassword.Text.Trim().ToString());
            clsUser User = clsUser.GetByUserNameAndPassword(txtUserName.Text.Trim(), HashedPassword);
            if (User == null)
            {
                MessageBox.Show("Invalid User Name/Password !",
                  "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (User.IsActive == false)
            {
                MessageBox.Show("Error:User is not active ,Please contact admin !",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chkRemember.Checked)
                clsGlobal.RememberCredentialsToRegistry(txtUserName.Text, txtPassword.Text);
            else
                clsGlobal.RememberCredentialsToRegistry();
            clsGlobal.RegisterLoginData(User.UserID, DateTime.Now);
            clsGlobal.CurrentUser = User;
            this.Hide();//start up Form does not stop execution until closing like frm.ShowDialog()
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
            => txtPassword.PasswordChar = (chkShowPassword.Checked == true ? '\0' : '*');

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;

            }
        }

        
    }
}
