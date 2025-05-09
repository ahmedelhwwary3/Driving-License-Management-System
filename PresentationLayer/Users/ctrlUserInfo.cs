using BusinessLayer;
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
    public partial class ctrlUserCard : UserControl
    {

        private clsUser _User=new clsUser();
       

       
        public clsUser User => _User;
        public ctrlUserCard()
        {
            InitializeComponent();
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

            _FillUserInfo();
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

            _FillUserInfo();
        }
        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPerson(_User.PersonID.Value);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = _User.IsActive? "Yes" : "No";
            lblPermissions.Text = _User.PermissionsData.Access;
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
