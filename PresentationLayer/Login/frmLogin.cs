//#define TestEventLog
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
using BusinessLayer.Core;
using System.Diagnostics.Eventing.Reader;
using static PresentationLayer.Global.clsGlobalData;
using System.Diagnostics;
using Microsoft.Win32;
using static PresentationLayer.Helpers.Logger.clsEventLogger;
using static PresentationLayer.Global.clsUtil;
using static PresentationLayer.Helpers.Logger.clsDataBaseLog;
using static PresentationLayer.Helpers.Logger.clsRegistry;
using PresentationLayer.Helpers.Logger;
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
#if DEBUG
            if (MessageBox.Show("Do you want to view code documentaion ?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.OK)
            {
                ShowDocumentationScreen();
            }
            TestEventLog();//Conditional Attribute
#endif
            var Credentials = (UserName:"",Password:"");
            GetStoredCredentialsFromRegistry(ref Credentials.UserName, ref Credentials.Password);
            LoadCredintialsInCTRLs(Credentials);
        }
        void LoadCredintialsInCTRLs((string UserName, string Password)Credentials)
        {
            txtUserName.Text = Credentials.UserName;
            txtPassword.Text = Credentials.Password;
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
                RememberCredentialsToRegistry((txtUserName.Text.Trim(), txtPassword.Text.Trim()));
            else
                RememberCredentialsToRegistry((string.Empty,string.Empty));
            RegisterLoginData(User.UserID, DateTime.Now);
            CurrentUser = User;
            if(GetUserThemeFromRegistry(out enThemeMode mode))
                CurrentTheme.LoadTheme(mode);//else => default theme (ctor)
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
