using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.People;
using PresentationLayer.Properties;
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
    public partial class frmUsersManagement : Form
    {
        private DataTable _dtUsersList = new DataTable();

        public frmUsersManagement()
        {
            InitializeComponent();
        }


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvUsers.CurrentRow.Cells[0].Value is int UserID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Parsing UserID from DGV Row."));
                return;
            }
            frmChangePassword frm = new frmChangePassword(UserID);
            frm.ShowDialog();
        }
        void _RefreshForm()
            => frmUsersManagement_Load(null, null);

        void _RefreshUsersListCount()
            => lblRecords.Text = dgvUsers.Rows.Count.ToString();
        private void frmUsersManagement_Load(object sender, EventArgs e)
        {
            _dtUsersList = clsUser.GetAllUsersList();
            dgvUsers.DataSource = _dtUsersList;
            SetComboBoxesAsDefault();
            _RefreshUsersListCount();
        }
        void SetComboBoxesAsDefault()
        {
            cbFilterColumn.Text = "None";
            cbIsActive.Visible = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
           => this.Close();


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



            txtFilterValue.Visible = (cbFilterColumn.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                cbIsActive.Visible = false;
            }
        }
        string _GetFilterColumnDBName()
        {
            switch (cbFilterColumn.Text)
            {
                case "Person ID":
                    {
                        return "PersonID";
                    }
                case "User ID":
                    {
                        return "UserID";
                    }
                case "User Name":
                    {
                        return "UserName";
                    }
                case "Full Name":
                    {
                        return "FullName";
                    }
                case "Permissions":
                    return "Permissions";
                default:
                    {
                        return "None";
                    }
            }

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            //It can not be (Is Active) as the logic we set in 'cbFilterColumn_SelectedIndexChanged' prevent this
            string FilterColumn = _GetFilterColumnDBName();
            if (txtFilterValue.Text.Trim() == "")
            {
                _dtUsersList.DefaultView.RowFilter = "";
                _RefreshUsersListCount();
                return;
            }
            switch (FilterColumn)
            {
                case "PersonID":
                case "UserID":
                    {
                        _dtUsersList.DefaultView.RowFilter =
                            string.Format("[{0}] = {1}",
                            FilterColumn, txtFilterValue.Text.Trim());
                        break;
                    }

                case "UserName":
                case "FullName":
                case "Permissions":
                    {
                        _dtUsersList.DefaultView.RowFilter =
                             string.Format("[{0}] LIKE '%{1}%'",
                             FilterColumn, txtFilterValue.Text.Trim());
                        break;
                    }
                default://None or another thing (safe)
                    {
                        _dtUsersList.DefaultView.RowFilter = "";
                        cbFilterColumn.SelectedIndex = cbFilterColumn.FindString("None");
                        break;
                    }
            }
            _RefreshUsersListCount();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            if (cbFilterColumn.Text == "Person ID" || cbFilterColumn.Text == "User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void addNewUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshForm();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading person details !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Person Details DGV."));
                return;
            }

            if (!(dgvUsers.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Parsing PersonID from DGV Row."));
                return;
            }


            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialog();
            _RefreshForm();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading User!", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading User Row in DGV."));
                return;
            }
            if (!(dgvUsers.CurrentRow.Cells[0].Value is int UserID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Parsing UserID from DGV Row."));
                return;
            }
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            if (MessageBox.Show(
                "Are you sure you want to delete this User?",
                "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)
                != DialogResult.OK)
            {
                return;
            }
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading User!", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading User Row in DGV."));
                return;
            }
            if (!(dgvUsers.CurrentRow.Cells[0].Value is int UserID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Parsing UserID from DGV Row."));
                return;
            }
            int LoggedUserID=clsGlobal.CurrentUser.UserID.Value;
            if (clsUser.Delete(UserID, LoggedUserID))
            {
                MessageBox.Show("User was deleted successfully",
                    "delete succeeded", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _RefreshForm();
            }
            else
                MessageBox.Show(
                    "User was not deleted successfully",
                    "delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        string _GetIsActiveCBFilterDBValue()
        {
            switch (cbIsActive.Text)
            {

                case "Yes":
                    {
                        return "1";

                    }
                case "No":
                    {
                        return "0";

                    }
                default:
                    { return "-1"; }
            }
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = _GetIsActiveCBFilterDBValue();

            if (FilterValue == "-1")//All or another thing
            {
                _dtUsersList.DefaultView.RowFilter = "";
                cbIsActive.SelectedIndex = 0;
                _RefreshUsersListCount();
                return;
            }

            _dtUsersList.DefaultView.RowFilter =
                  string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            _RefreshUsersListCount();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            MessageBox.Show("This method is not implemented yet", "Stup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
         

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            MessageBox.Show("This method is not implemented yet", "Stup",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvUsers.Columns.Count == 6)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 100;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 250;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 150;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 80;

                dgvUsers.Columns[5].HeaderText = "Permissions";
                dgvUsers.Columns[5].Width = 150;
            }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.Rows.Count == 0)
                e.Cancel = true;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditUser))
                return;
            frmAddEditUser frm=new frmAddEditUser();
            frm.ShowDialog();
            _RefreshForm();
        }
    }
}
