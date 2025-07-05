using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Helpers.BaseUI;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.Core.clsUsersPermissions;

namespace PresentationLayer.Users
{
    public partial class frmEditUsersPermissions : clsBaseForm
    {
        private DataTable _dtUsersPermissions = new DataTable();
        private Task _Task;

        public frmEditUsersPermissions()
        {
            InitializeComponent();
        }

        private void frmEditUsersPermissions_Load(object sender, EventArgs e)
        {
            SetTheme(this);
            ResetDefaultValues();
        }

        private void ResetDefaultValues()
        {
            SetTitle("Manage Permissions");
            _Task = Task.Run(() =>_dtUsersPermissions = GetAllPermissions());
            Task.WaitAll(_Task);

            FillPermissionsInCheckedListBox();
            lbxAddPermissions?.Items?.Clear();
            txtAddPermissions?.Clear();
        }

        private void FillPermissionsInCheckedListBox()
        {
            chkDeletePermissions?.Items?.Clear();

            foreach (DataRow row in _dtUsersPermissions.Rows)
            {
                if (!row["IsSystem"].ToBoolean())
                    chkDeletePermissions?.Items?.Add(row["Access"]?.ToString() ?? string.Empty);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string permission = txtAddPermissions.Text.Trim();

            if (string.IsNullOrEmpty(permission))
                return;

            foreach (var item in lbxAddPermissions.Items)
            {
                if (item?.ToString() == permission)
                    return;
            }

            if (GetByAccessType(permission) == null)
                lbxAddPermissions?.Items?.Add(permission);

            txtAddPermissions.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int count = lbxAddPermissions.Items.Count;
            if (count > 0)
                lbxAddPermissions.Items.RemoveAt(count - 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error: Some fields are not valid!\nPlease check the red icon messages.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isChanged = false;

                // Delete selected permissions
                if (chkDeletePermissions.Items.Count != _dtUsersPermissions.Rows.Count)
                {
                    for (int i = 0; i < chkDeletePermissions.Items.Count; i++)
                    {
                        if (chkDeletePermissions.GetItemChecked(i))
                        {
                            string access = chkDeletePermissions.Items[i].ToString();
                            var permission = GetByAccessType(access);
                            if (permission == null)
                                continue;

                            if (!DeleteByPermissionsNumber(
                                    permission.Permissions ?? 0,
                                    clsGlobalData.CurrentUser.UserID.Value))
                                throw new Exception("Delete Permissions Failed.");

                            isChanged = true;
                        }
                    }
                }

                // Add new permissions
                foreach (var item in lbxAddPermissions.Items)
                {
                    var permission = new clsUsersPermissions
                    {
                        Access = item?.ToString(),
                        LoggedUserID = clsGlobalData.CurrentUser.UserID.Value,
                        Permissions = (byte)(GetLastPermissionsNumberBeforeAdmin() << 1)
                    };

                    if (!permission.Save())
                        throw new Exception("Add Permissions Failed.");

                    isChanged = true;
                }

                if (isChanged)
                {
                    MessageBox.Show("Save succeeded.", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsGlobalData.WindownsEventLog.Log(ex);
                MessageBox.Show("Error: Save Failed!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResetDefaultValues();
        }

        private void chkDeletePermissions_Validating(object sender, CancelEventArgs e)
        {
            for (byte i = 0; i < chkDeletePermissions.Items.Count; i++)
            {
                string item = chkDeletePermissions.Items[i].ToString();

                bool isProtected = item.Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                                   || item.Equals("View", StringComparison.InvariantCultureIgnoreCase)
                                   || item.Equals("AddEdit", StringComparison.InvariantCultureIgnoreCase)
                                   || item.Equals("Delete", StringComparison.InvariantCultureIgnoreCase);

                if (isProtected && chkDeletePermissions.GetItemChecked(i))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(chkDeletePermissions, "You cannot delete this permission!");
                    chkDeletePermissions.SetItemChecked(i, false);
                    return;
                }
            }

            e.Cancel = false;
            errorProvider1.SetError(chkDeletePermissions, string.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
