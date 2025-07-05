using PresentationLayer.People;
using PresentationLayer.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Core;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Users
{
    public partial class frmUsersManagement : clsBaseForm
    {
        DataTable _SentEmails = new DataTable();
        DataTable _dtUsersList = new DataTable();
        Task task;

        public frmUsersManagement()
        {
            InitializeComponent();
        }

        void LoadUsersList()
        {
            lock (GlobalLockObject)
                _dtUsersList = clsUser.GetAllUsersList();
        }

        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            SetTheme(this);
            btnView.Visible = false;
            task = Task.Run(() => LoadUsersList());
            SetComboBoxesAsDefault();
            SetTitle("Users Management");
            Task.WaitAll(task);
            dgvUsers.DataSource = _dtUsersList;
            RefreshUsersListCount();
        }

        void SetComboBoxesAsDefault()
        {
            cbFilterColumn.Text = "None";
            cbIsActive.Visible = false;
        }

        void RefreshUsersListCount()
            => lblRecords.Text = dgvUsers.Rows.Count.ToString();

        void RefreshForm()
            => frmUsersManagement_Load(null, null);

        string GetFilterColumnDBName()
        {
            return cbFilterColumn.Text switch
            {
                "Person ID" => "PersonID",
                "User ID" => "UserID",
                "User Name" => "UserName",
                "Full Name" => "FullName",
                "Permissions" => "Permissions",
                _ => "None"
            };
        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterColumn.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return;
            }

            txtFilterValue.Visible = cbFilterColumn.Text != "None";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                cbIsActive.Visible = false;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnDBName();

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                _dtUsersList.DefaultView.RowFilter = "";
                RefreshUsersListCount();
                return;
            }

            switch (FilterColumn)
            {
                case "PersonID":
                case "UserID":
                case "Permissions":
                    _dtUsersList.DefaultView.RowFilter = $"[{FilterColumn}] = {txtFilterValue.Text.Trim()}";
                    break;

                case "UserName":
                case "FullName":
                    _dtUsersList.DefaultView.RowFilter = $"[{FilterColumn}] LIKE '%{txtFilterValue.Text.Trim()}%'";
                    break;

                default:
                    _dtUsersList.DefaultView.RowFilter = "";
                    cbFilterColumn.SelectedIndex = cbFilterColumn.FindString("None");
                    break;
            }

            RefreshUsersListCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;

            if (cbFilterColumn.Text is "Person ID" or "User ID" or "Permissions")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbIsActive.Text switch
            {
                "Yes" => "1",
                "No" => "0",
                _ => "-1"
            };

            if (FilterValue == "-1")
            {
                _dtUsersList.DefaultView.RowFilter = "";
                cbIsActive.SelectedIndex = 0;
                RefreshUsersListCount();
                return;
            }

            _dtUsersList.DefaultView.RowFilter = $"[IsActive] = {FilterValue}";
            RefreshUsersListCount();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.Rows.Count == 0)
                e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => Close();

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialogIfAuthorized(GetPermissions("Admin"), frm);
            RefreshForm();
        }

        private void addNewUserToolStripMenuItem1_Click(object sender, EventArgs e)
            => btnAddNewUser_Click(sender, e);

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.Cells[0].Value is not int userID)
            {
                MessageBox.Show("Error: Cannot read UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception("UserID parsing failed"));
                return;
            }

            var frm = new frmChangePassword(userID);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshForm();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.Cells[1].Value is not int personID)
            {
                MessageBox.Show("Error: Cannot read PersonID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception("PersonID parsing failed"));
                return;
            }

            var frm = new frmShowPersonCard(personID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            RefreshForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow?.Cells[0].Value is not int userID)
            {
                MessageBox.Show("Error: Cannot read UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception("UserID parsing failed"));
                return;
            }

            var frm = new frmAddEditUser(userID);
            frm.ShowDialogIfAuthorized(GetPermissions("Admin"), frm);
            RefreshForm();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("Admin"))) return;

            if (MessageBox.Show("Are you sure you want to delete this User?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                != DialogResult.OK) return;

            if (dgvUsers.CurrentRow?.Cells[0].Value is not int userID)
            {
                MessageBox.Show("Error: Cannot read UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new Exception("UserID parsing failed"));
                return;
            }

            int loggedUserID = CurrentUser.UserID.Value;

            if (clsUser.Delete(userID, loggedUserID))
            {
                MessageBox.Show("User deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }
            else
            {
                MessageBox.Show("Failed to delete user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendEmailToAll_Click(object sender, EventArgs e)
        {
            string msg = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("Error: No message to send!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool allPeople = rbPeople.Checked;
            _SentEmails = clsUser.SendEmailToAllPeopleOrAllUsers(allPeople, msg);

            if (_SentEmails.Rows.Count > 0)
            {
                MessageBox.Show("Message sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnView.Visible = true;
            }
            else
            {
                MessageBox.Show("Message failed to send!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtEmail.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var frm = new frmListSentEmails(_SentEmails);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This method is not implemented yet", "Stub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This method is not implemented yet", "Stub", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvUsers.Columns.Count != 12) return;

            dgvUsers.Columns[0].HeaderText = "User ID"; dgvUsers.Columns[0].Width = 80;
            dgvUsers.Columns[1].HeaderText = "Person ID"; dgvUsers.Columns[1].Width = 80;
            dgvUsers.Columns[2].HeaderText = "User Name"; dgvUsers.Columns[2].Width = 120;
            dgvUsers.Columns[3].HeaderText = "Full Name"; dgvUsers.Columns[3].Width = 260;
            dgvUsers.Columns[4].HeaderText = "Is Active"; dgvUsers.Columns[4].Width = 70;
            dgvUsers.Columns[5].HeaderText = "Permissions"; dgvUsers.Columns[5].Width = 80;
            dgvUsers.Columns[6].HeaderText = "Gender"; dgvUsers.Columns[6].Width = 70;
            dgvUsers.Columns[7].HeaderText = "Hierarchy"; dgvUsers.Columns[7].Width = 250;
            dgvUsers.Columns[8].HeaderText = "Level"; dgvUsers.Columns[8].Width = 60;
            dgvUsers.Columns[9].HeaderText = "Manager ID"; dgvUsers.Columns[9].Width = 80;
            dgvUsers.Columns[10].HeaderText = "User Permissions Rank \nWith Same Value"; dgvUsers.Columns[10].Width = 70;
            dgvUsers.Columns[11].HeaderText = "Max Rank"; dgvUsers.Columns[11].Width = 70;
        }

        private void rbUsers_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
