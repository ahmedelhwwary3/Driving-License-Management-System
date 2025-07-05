using BusinessLayer.Core;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;
using PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users
{
    public partial class ctrlUserCard : clsBaseCtrl
    {

        private clsUser _User=new clsUser();
       

       
        public clsUser User => _User;
        public ctrlUserCard()
        {
            InitializeComponent();
            SetTheme(this);
        }

        public void LoadUser(int UserID)
        {
            _User = clsUser.GetByID(UserID);
            if (_User == null)
            {
                ResetUserCard();
                MessageBox.Show($"Error:User with UserID {UserID.ToString()} is not Existed !"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillUserInfo();
        }
        public void LoadUserInfo(clsUser User)
        {
            _User = User;
            if (_User == null)
            {
                ResetUserCard();
                MessageBox.Show($"Error:User with UserID {User.UserID.ToString()} is not Existed !"
                         , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillUserInfo();
        }
        private void FillUserInfo()
        {
            ctrlPersonCard1.LoadPerson(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = _User.IsActive? "Yes" : "No";
            lblPermissions.Text = _User.PermissionsAccess;
            lblHierarchy.Text = clsUsersHierarcky.GetHierarchyNameByID(_User.HierarchyID);
            string ManagerID = _User.ManagerID?.ToString()??"N/A";
            lblManagerID.Text = ManagerID;
        }

        public void ResetUserCard()
        {

            ctrlPersonCard1.ResetDefaultValues();
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
        }
    }
}
