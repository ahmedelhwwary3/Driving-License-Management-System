using BusinessLayer.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.Core.clsUsersPermissions;
using static BusinessLayer.Core.clsUser;
using static PresentationLayer.Global.clsGlobalData;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Users
{
    public partial class frmUpdateUsers : clsBaseForm
    {
        private DataTable _dtUsers = new DataTable();
        private DataTable _dtPermissions = new DataTable();

        public frmUpdateUsers()
        {
            InitializeComponent();
        }

        private void frmUpdateUsers_Load(object sender, EventArgs e)
        {
            SetTheme(this);
            RefreshForm();
        }

        private void RefreshForm()
        {
            this.Text = "Update Users";
            rbDetails.Checked = true;

            Parallel.Invoke(
                () => _dtUsers = clsUser.GetAllUsersList(),
                () => _dtPermissions = GetAllPermissions()
            );

            FillUsersListView();
            RefreshTotalCount();
            SetPermisssionsDropDownItems();
            SetTitle("Update Users");
        }

        private void FillUsersListView()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            listView1.Columns.Add("UserName", 100);
            listView1.Columns.Add("UserID", 70);
            listView1.Columns.Add("FullName", 150);
            listView1.Columns.Add("IsActive", 70);
            listView1.Columns.Add("Permissions", 100);

            foreach (DataRow user in _dtUsers.Rows)
            {
                var item = new ListViewItem(user["UserName"]?.ToString() ?? string.Empty);
                item.SubItems.Add(user["UserID"]?.ToString() ?? string.Empty);
                item.SubItems.Add(user["FullName"]?.ToString() ?? string.Empty);
                item.SubItems.Add(user["IsActive"]?.ToString() ?? string.Empty);
                item.SubItems.Add(user["Permissions"]?.ToString() ?? string.Empty);
                item.ImageIndex = user["Gendor"]?.ToString() == "Male" ? 0 : 1;
                listView1.Items.Add(item);
            }
        }

        private void RefreshTotalCount()
            => lblRecords.Text = _dtUsers.Rows.Count.ToString();

        private void SetPermisssionsDropDownItems()
        {
            setPermissionsToToolStripMenuItem.DropDownItems.Clear();

            foreach (DataRow row in _dtPermissions.Rows)
                setPermissionsToToolStripMenuItem.DropDownItems.Add(row["Access"] as string);

            foreach (ToolStripItem item in setPermissionsToToolStripMenuItem.DropDownItems)
            {
                item.Click += (sender, e) =>
                {
                    try
                    {
                        string permissionText = (sender as ToolStripMenuItem)?.Text;
                        SetNewPermissions(permissionText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Error with modifying permissions!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        WindownsEventLog.Log(ex);
                    }
                };
            }
        }

        private void SetNewPermissions(string newPermissionsText)
        {
            if (MessageBox.Show("Are you sure you want to modify the selected user(s) permissions?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    int? userID = Convert.ToInt32(listView1.SelectedItems[i].SubItems[1].Text);
                    clsUser user = GetByID(userID.Value);

                    byte newPermissionsNumber = GetByAccessType(newPermissionsText).Permissions.Value;
                    user.Permissions = newPermissionsNumber;
                    user.LoggedUserID = CurrentUser.UserID.Value;

                    if (!user.Save())
                    {
                        MessageBox.Show($"Error: Modifying user permissions with ID {userID} failed!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("Error with modifying user permissions in listView.");
                    }
                }

                MessageBox.Show("Modify succeeded.", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }
            catch (Exception ex)
            {
                WindownsEventLog.Log(ex);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected user(s)?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    int? userID = Convert.ToInt32(listView1.SelectedItems[i].SubItems[1].Text);
                    if (!Delete(userID.Value, CurrentUser.UserID.Value))
                    {
                        MessageBox.Show($"Error: Delete user with ID {userID} failed!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("Error with deleting user in listView.");
                    }
                }

                MessageBox.Show("Delete succeeded.", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshForm();
            }
            catch (Exception ex)
            {
                WindownsEventLog.Log(ex);
            }
        }

        private void rbLargeIcon_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void rbDetails_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void rbSmallIcon_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void rbList_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void rbTile_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
