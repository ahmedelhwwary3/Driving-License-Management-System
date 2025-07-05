using BusinessLayer.Core;
using PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Tests;
using static PresentationLayer.Global.clsUtil;
using static BusinessLayer.Core.clsUsersHierarcky;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Users
{
    public partial class frmAddEditUser : clsBaseForm
    {
        //There are many CEOs but only 1 Admin
        bool _IsGiveAdminButton = true;
        DataTable _dtUsersHierarcky = new DataTable();
        private int? _UserID;
        private clsUser _User = new clsUser();
        int _PersonID = default;
        DataTable _dtAllPermissions = new DataTable();
        bool _AdminModifiesHimself = false;
        public enum enMode
        { AddNew, Update };
        private enMode _Mode;
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            SetTheme(this);
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
            SetTheme(this);
        }
        void SetFocusOntxtFilter()
        {
            this.AcceptButton = ctrlPersonCardWithFilter1.FindBtn;
            ctrlPersonCardWithFilter1.FilterFocus();
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => LoadTreeViewNodes()));
            BeginInvoke(new Action(() => SetFocusOntxtFilter()));
            ResetDefaultValues();
            if (_Mode == enMode.Update)
                LoadData();

        }
        void LoadTreeViewNodes()
        {
            treePermissions?.Nodes.Clear();
            treePermissions.ImageList = imageList1;

            //Base
            TreeNode ndDelete = new TreeNode("Delete") { Checked = false };
            TreeNode ndAddEdit = new TreeNode("Modify") { Checked = false };
            TreeNode ndAdmin = new TreeNode("Admin") { Checked = false };
            TreeNode ndView = new TreeNode("View") { Checked = false };

            ndDelete.Name = "ndDelete";
            ndAddEdit.Name = "ndAddEdit";
            ndAdmin.Name = "ndAdmin";
            ndView.Name = "ndView";

            ndDelete.ImageKey = "bin.png";
            ndAddEdit.ImageKey = "updated.png";
            ndAdmin.ImageKey = "settings.png";
            ndView.ImageKey = "eye.png";
            //AddEdit & View
            TreeNode ndFrmFindPerson = new TreeNode("FindPerson");
            TreeNode ndFrmPeopleManagement = new TreeNode("PeopleManagement");
            TreeNode ndFrmShowPersonCard = new TreeNode("ShowPersonCard");
            TreeNode ndFrmUsersManagement = new TreeNode("UsersManagement");
            TreeNode ndFrmListSentEmails = new TreeNode("ListSentEmails");
            TreeNode ndFrmUserInfo = new TreeNode("UserInfo");
            TreeNode ndFrmListTestAppointments = new TreeNode("ListTestAppointments");
            TreeNode ndFrmListTestTypes = new TreeNode("ListTestTypes");
            TreeNode ndFrmShowInternationaLicenseInfo = new TreeNode("ShowInternationaLicenseInfo");
            TreeNode ndFrmShowLicenseHistory = new TreeNode("ShowLicenseHistory");
            TreeNode ndFrmListDrivers = new TreeNode("ListDrivers");
            TreeNode ndFrmListApplicationTypes = new TreeNode("ListApplicationTypes");
            TreeNode ndFrmListInternationalLicenses = new TreeNode("ListInternationalLicenses");
            TreeNode ndFrmListHighRiskApplicants = new TreeNode("ListHighRiskApplicants");
            TreeNode ndFrmListLocalDrivingLicenseApplications = new TreeNode("ListLocalDrivingLicenseApplications");
            TreeNode ndFrmShowLocalDrivingLicenseApplicationInfo = new TreeNode("ShowLocalDrivingLicenseApplicationInfo");
            TreeNode ndFrmListDetainedLicenses = new TreeNode("ListDetainedLicenses");
            //AddEdit only
            TreeNode ndFrmAddEditUser = new TreeNode("AddEditUser");
            TreeNode ndFrmChangePassword = new TreeNode("ChangePassword");
            TreeNode ndFrmEditUsersPermissions = new TreeNode("EditUsersPermissions");
            TreeNode ndFrmUpdateUsers = new TreeNode("UpdateUsers");
            TreeNode ndFrmScheduleTest = new TreeNode("ScheduleTest");
            TreeNode ndFrmTakeScheduledTest = new TreeNode("TakeScheduledTest");
            TreeNode ndFrmAddEditPerson = new TreeNode("AddEditPerson");
            TreeNode ndFrmDetainLicense = new TreeNode("DetainLicense");
            TreeNode ndFrmEditApplicationType = new TreeNode("EditApplicationType");
            TreeNode ndFrmIssueInternationalLicense = new TreeNode("IssueInternationalLicense");
            TreeNode ndFrmAddEditLocalDrivingLicenseApplication = new TreeNode("AddEditLocalDrivingLicenseApplication");
            TreeNode ndFrmReleaseDetainedLicense = new TreeNode("ReleaseDetainedLicense");
            TreeNode ndFrmRenewLocalLicense = new TreeNode("RenewLocalLicense");
            TreeNode ndFrmReplacementForDamagedOrLostLicenses = new TreeNode("ReplacementForDamagedOrLostLicenses");
            //Admin
            TreeNode ndfrmListLogins = new TreeNode("ListLogins");
            TreeNode ndfrmOperationLogs = new TreeNode("OperationLogs");
            TreeNode frmEditTestType = new TreeNode("EditTestType");
            //Filling Tree With Nodes....
            TreeNode[] BasicNodes = new TreeNode[] { ndAdmin, ndAddEdit, ndDelete, ndView };
            TreeNode[] ViewNodes = new TreeNode[]
            {  ndFrmFindPerson, ndFrmPeopleManagement, ndFrmShowPersonCard, ndFrmListTestAppointments
              ,ndFrmUsersManagement,ndFrmListSentEmails,ndFrmUserInfo,ndFrmListTestTypes,ndFrmShowInternationaLicenseInfo,
              ndFrmShowLicenseHistory,ndFrmListDrivers,ndFrmListApplicationTypes,ndFrmListInternationalLicenses,
              ndFrmListHighRiskApplicants,ndFrmListLocalDrivingLicenseApplications,ndFrmShowLocalDrivingLicenseApplicationInfo,ndFrmListDetainedLicenses
            };
            TreeNode[] AdminNodes = new TreeNode[] { frmEditTestType, ndfrmListLogins, ndfrmOperationLogs };
            TreeNode[] AddEditNodes = new TreeNode[]
            { ndFrmAddEditUser, ndFrmChangePassword, ndFrmEditUsersPermissions ,ndFrmUpdateUsers,ndFrmRenewLocalLicense,ndFrmReplacementForDamagedOrLostLicenses,
            ndFrmScheduleTest,ndFrmTakeScheduledTest,ndFrmAddEditPerson,ndFrmDetainLicense,ndFrmEditApplicationType
            ,ndFrmIssueInternationalLicense,ndFrmAddEditLocalDrivingLicenseApplication,ndFrmReleaseDetainedLicense};

            treePermissions?.Nodes?.AddRange(BasicNodes);
            ndView?.Nodes?.AddRange(ViewNodes);
            ndAddEdit?.Nodes?.AddRange(AddEditNodes);
            ndAdmin?.Nodes?.AddRange(AdminNodes);
        }
        private void ChangeLabelAndText()
        {
            this.Text = (_Mode == enMode.Update ? "Edit User" : "Add New User");
            lblAddEditUser.Text = (_Mode == enMode.Update ? "Edit User" : "Add New User");
        }
        private void ResetDefaultValues()
        {
            //In 2 Modes
            FillHierarckyComboBox();
            ChangeLabelAndText();
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            chkIsActive.Checked = true;
            //Only "Admin" can edit "another"
            if (_Mode == enMode.Update)
            {
                bool IsUserModifyAnotherOne = (_UserID.Value != CurrentUser.UserID.Value);
                bool IsLoggedUserAdmin = (CurrentUser.Permissions == GetPermissions("Admin"));
                _AdminModifiesHimself = IsLoggedUserAdmin && !IsUserModifyAnotherOne;
            }

            this.ctrlPersonCardWithFilter1.OnPersonSelected += (PersonID) =>
                {
                    _PersonID = PersonID;
                    AcceptButton = btnNext;
                };
            btnGiveAdministrator.Visible = false;
            if (_Mode == enMode.AddNew)
            {
                ctrlPersonCardWithFilter1.FilterFocus();
                btnSave.Enabled = false;
                tcAddNewUser.TabPages[1].Enabled = false;//Disable Login Info 
            }
        }
        void FillHierarckyComboBox()
        {
            _dtUsersHierarcky = clsUsersHierarcky.GetAllUsersHierarckyList();
            foreach (DataRow H in _dtUsersHierarcky.Rows)
            {
                cbHierarcky.Items?.Add(H["Hierarchy"]);
            }
            cbHierarcky.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _User = clsUser.GetByID(_UserID.Value);
            if (_User == null)
            {
                MessageBox.Show($"Error:User with ID {_UserID.ToString()} is not found !",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PersonID = _User.PersonID;
            ctrlPersonCardWithFilter1.LoadPerson(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            btnSave.Enabled = true;
            txtUserName.Text = _User.UserName;
            txtUserName.Focus();
            tcAddNewUser.SelectedTab = tcAddNewUser.TabPages["tpLoginInfo"];
            txtManagerID.Text = _User.ManagerID.ToString() ?? "N/A";
            cbHierarcky.SelectedIndex = cbHierarcky.FindString(clsUsersHierarcky.GetHierarchyNameByID(_User.HierarchyID));
            BeginInvoke(new Action(() => treePermissions.Nodes["ndAdmin"].Checked = _AdminModifiesHimself));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                MoveNextPage();
                return;
            }
            //AddNew
            if (_PersonID != default)
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
        byte CalculateUserPermissions()
        {
            //User Who Can AddEdit can always View
            if (treePermissions.Nodes["ndAdmin"].Checked)
                return GetPermissions("Admin");
            byte Permissions = 0;
            if (treePermissions.Nodes["ndAddEdit"].Checked)
                Permissions |= (byte)(GetPermissions("AddEdit")
                              | GetPermissions("View"));
            if (treePermissions.Nodes["ndDelete"].Checked)
                Permissions |= GetPermissions("Delete");
            if (treePermissions.Nodes["ndView"].Checked)
                Permissions |= GetPermissions("View");
            return Permissions;
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
                _User.LoggedUserID = CurrentUser.UserID.Value;
                _User.UserName = txtUserName.Text.Trim();
                _User.Password = ComputeHash(txtPassword.Text.Trim());
                _User.PersonID = ctrlPersonCardWithFilter1.Person.PersonID.Value;
                _User.IsActive = chkIsActive.Checked;
                _User.Permissions = CalculateUserPermissions();
                if (_User.PersonID == default || (_User.UserID == null && _Mode == enMode.Update))
                {
                    MessageBox.Show("Error:An unexpected error occurred while saving. " +
                      "Please try again later.", "Save failed", MessageBoxButtons.OK);
                    return;
                }
                if (_Mode == enMode.Update && !_User.ManagerID.HasValue)//CEO
                    _User.ManagerID = null;
                else
                    _User.ManagerID = Convert.ToInt32(txtManagerID.Text);

                _User.HierarchyID = Convert.ToInt32(GetHierarchyIDByName(cbHierarcky.Text));

                if (!_User.Save())
                    throw new Exception($"Save User with PersonID {_User.PersonID} Failed.");

                ctrlPersonCardWithFilter1.FilterEnabled = false;
                //If user updated his information (not add new) ,then he can undo changes

                _Mode = enMode.Update;
                ChangeLabelAndText();
                MessageBox.Show("User Updated successfully", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                      "Please try again later.", "Save failed", MessageBoxButtons.OK
                      , MessageBoxIcon.Error);
                WindownsEventLog?.Log(ex);
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
            if (_Mode == enMode.AddNew && clsUser.IsExistedByUserName(txtUserName.Text.Trim()))
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




        private void btnClose_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            this.Close();
        }


        void CheckTreeViewNodes(TreeNode parent)
        {
            if (parent == null)
                return;
            foreach (TreeNode child in parent.Nodes)
            {
                child.Checked = parent.Checked;

                child.ImageKey = parent.ImageKey;
                child.SelectedImageIndex = parent.SelectedImageIndex;
                if (child.Nodes.Count > 0)
                    CheckTreeViewNodes(child);
            }
        }
        Boolean IsNoNodeCheckedInRootNodes(TreeNode Root)
        {
            foreach (TreeNode item in Root.Nodes)
            {
                //Parents
                if (item.Checked)
                    return false;
                if (item.Nodes.Count > 0)
                {
                    //If Any Child Nodes is Checked
                    if (!IsNoNodeCheckedInRootNodes(item))
                        return false;
                }
            }
            return true;
        }
        Boolean IsNoParentNodeCheckedInTreeNodes()
        {
            foreach (TreeNode item in treePermissions.Nodes)
            {
                //If Any Parent Node is checked
                if (item.Checked)
                    return false;
            }
            return true;
        }




        private void cbHierarcky_SelectedIndexChanged(object sender, EventArgs e)
        {

            BeginInvoke(new Action(() =>
            {
                switch (cbHierarcky.SelectedItem)
                {
                    case "CEO":
                        {
                            
                            btnGiveAdministrator.Visible = true;
                            SetNodeChecked("ndAdmin", _AdminModifiesHimself);
                            SetNodeChecked("ndAddEdit", true);
                            SetNodeChecked("ndView", true);
                            SetNodeChecked("ndDelete", true);
                            break;
                        }
                    case "Branch Manager":
                        {
                            btnGiveAdministrator.Visible = false;
                            SetNodeChecked("ndAdmin", false);
                            SetNodeChecked("ndAddEdit", true);
                            SetNodeChecked("ndView", true);
                            SetNodeChecked("ndDelete", true);
                            break;
                        }
                    case "Officer":
                        {
                            btnGiveAdministrator.Visible = false;
                            SetNodeChecked("ndAdmin", false);
                            SetNodeChecked("ndDelete", false);
                            SetNodeChecked("ndAddEdit", true);
                            SetNodeChecked("ndView", true);
                            break;
                        }
                    case "Viewer":
                        {
                            btnGiveAdministrator.Visible = false;
                            SetNodeChecked("ndView", true);
                            SetNodeChecked("ndAdmin", false);
                            SetNodeChecked("ndDelete", false);
                            SetNodeChecked("ndAddEdit", false);
                            break;
                        }
                    default:
                        return;
                }
            }));

        }
        void SetNodeChecked(string NodeName, bool Checked)
            => treePermissions.Nodes[$"{NodeName}"].Checked = Checked;
        private void treePermissions_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand)
            {
                e.Cancel = false;
                return;
            }
            if(e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                e.Cancel = true;

        }

        private void btnGiveAdministrator_Click(object sender, EventArgs e)
        {
            if (_IsGiveAdminButton)
            {
                btnGiveAdministrator.Text = "Remove Administrator Access";
                _IsGiveAdminButton = false;
                SetNodeChecked("ndAdmin", true);
            }
            else
            {
                btnGiveAdministrator.Text = "Give Administrator Access";
                _IsGiveAdminButton = true;
                SetNodeChecked("ndAdmin", false);
            }
        }

        private void treePermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNodes(e.Node);
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
                errorProvider1.SetError(txtPassword, string.Empty);
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
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
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
                errorProvider1.SetError(txtConfirmPassword, string.Empty);
            }
        }

        private void cbHierarcky_Validating(object sender, CancelEventArgs e)
        {
            if (_AdminModifiesHimself)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbHierarcky, "Admin can not modify himself");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbHierarcky, "");
            }
        }

        private void txtManagerID_Validating(object sender, CancelEventArgs e)
        {
            if (_AdminModifiesHimself)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtManagerID, "Admin can not modify himself");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtManagerID, "");
            }

            if (string.IsNullOrEmpty(txtManagerID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(treePermissions,
                    "This field can not be empty !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtManagerID, string.Empty);
            }

            //Admin modifies himself
            int? HierarckyID = GetHierarchyIDByName(cbHierarcky.Text);
            int ManagerID = Convert.ToInt32(txtManagerID.Text.Trim());
            if (ManagerID < 1 || !clsUser.IsExistedByID(ManagerID))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtManagerID,
                    "Invalid Manager ID Or Not Existed !");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtManagerID, string.Empty);
            }
            if (HasManagerHigherHierarcky(ManagerID, HierarckyID.Value))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtManagerID,
                    "Manager must have higher Hierarcky than User !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtManagerID, string.Empty);
            }


        }



        private void txtManagerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        private void treePermissions_Validating(object sender, CancelEventArgs e)
        {
            if(IsNoParentNodeCheckedInTreeNodes())
            {
                e.Cancel = true;
                errorProvider1.SetError(treePermissions,"You must check any Permissions !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(treePermissions, string.Empty);
            }
        }
    }


}
        
    
        

