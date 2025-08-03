using BusinessLayer.Core;
using PresentationLayer.Helpers.BaseUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer.AddLogin
{
    public partial class frmListUserAddLogins : clsBaseForm
    {
        Task task;
        public frmListUserAddLogins()
        {
            InitializeComponent();
 
        }

        private static DataTable _dtAllUsersAddLogs = new DataTable();
        void RefreshList()
        {
            _dtAllUsersAddLogs = clsUserLogin.GetAllUsersLogins();
            dgvAddLogs.DataSource = _dtAllUsersAddLogs;
            RefreshListCount();

        }
        private void RefreshListCount()
            => lblTotalRecords.Text = dgvAddLogs.Rows.Count.ToString();
        string GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "AddLogin ID":
                    {
                        return "AddLoginID";

                    }
                case "User ID":
                    {
                        return "UserID";

                    }
                case "User Name":
                    {
                        return "UserName";

                    }
                case "AddLogin Date":
                    {
                        return "AddLoginDate";

                    }

                default:
                    {
                        return "None";
                    }
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnDBName();


            if (txtFilterValue.Text.Trim() == "")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter = "";
                RefreshListCount();
                return;
            }
            if (FilterColumn == "None")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter = "";
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                return;
            }
            if (FilterColumn != "UserName")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter =
                                    string.Format("[{0}] = {1}", FilterColumn,
                                     txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter =
                                string.Format("[{0}] like '%{1}%'", FilterColumn,
                                 txtFilterValue.Text.Trim());
            }
            RefreshListCount();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (cbFilterBy.Text != "User Name")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else e.Handled = false;

        }

        private void frmListAddLogins_Load(object sender, EventArgs e)
        {
            task = Task.Run(() => _dtAllUsersAddLogs = clsUserLogin.GetAllUsersLogins());
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            SetTitle("List Users AddLogins");
            Task.WaitAll(task);
            dgvAddLogs.DataSource = _dtAllUsersAddLogs;
            RefreshListCount();
        }

        private void dgvAddLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAddLogs.Columns.Count == 4)
            {
                dgvAddLogs.Columns[0].Width = 110;
                dgvAddLogs.Columns[0].HeaderText = "AddLogin ID";

                dgvAddLogs.Columns[1].Width = 110;
                dgvAddLogs.Columns[1].HeaderText = "User ID";

                dgvAddLogs.Columns[2].Width = 180;
                dgvAddLogs.Columns[2].HeaderText = "User Name";

                dgvAddLogs.Columns[3].Width = 170;
                dgvAddLogs.Columns[3].HeaderText = "AddLogin Date";

                dgvAddLogs.Columns["AddLoginDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }
        }

         
    }
}
