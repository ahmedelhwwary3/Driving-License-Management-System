﻿using BusinessLayer.Core;
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

namespace PresentationLayer.Login
{
    public partial class frmListUserLogins : clsBaseForm
    {
        Task task;
        public frmListUserLogins()
        {
            InitializeComponent();
            SetTheme(this);
        }

        private static DataTable _dtAllUsersLogs = new DataTable();
        void RefreshList()
        {
            _dtAllUsersLogs = clsUserLogin.GetAllUsersLogins();
            dgvLogs.DataSource = _dtAllUsersLogs;
            RefreshListCount();

        }
        private void RefreshListCount()
            => lblTotalRecords.Text = dgvLogs.Rows.Count.ToString();
        string GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "Login ID":
                    {
                        return "LoginID";

                    }
                case "User ID":
                    {
                        return "UserID";

                    }
                case "User Name":
                    {
                        return "UserName";

                    }
                case "Login Date":
                    {
                        return "LoginDate";

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
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                RefreshListCount();
                return;
            }
            if (FilterColumn == "None")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                return;
            }
            if (FilterColumn != "UserName")
            {
                _dtAllUsersLogs.DefaultView.RowFilter =
                                    string.Format("[{0}] = {1}", FilterColumn,
                                     txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllUsersLogs.DefaultView.RowFilter =
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

        private void frmListLogins_Load(object sender, EventArgs e)
        {
            task = Task.Run(() => _dtAllUsersLogs = clsUserLogin.GetAllUsersLogins());
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            SetTitle("List Users Logins");
            Task.WaitAll(task);
            dgvLogs.DataSource = _dtAllUsersLogs;
            RefreshListCount();
        }

        private void dgvLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvLogs.Columns.Count == 4)
            {
                dgvLogs.Columns[0].Width = 110;
                dgvLogs.Columns[0].HeaderText = "Login ID";

                dgvLogs.Columns[1].Width = 110;
                dgvLogs.Columns[1].HeaderText = "User ID";

                dgvLogs.Columns[2].Width = 180;
                dgvLogs.Columns[2].HeaderText = "User Name";

                dgvLogs.Columns[3].Width = 170;
                dgvLogs.Columns[3].HeaderText = "Login Date";

                dgvLogs.Columns["LoginDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            }
        }

         
    }
}
