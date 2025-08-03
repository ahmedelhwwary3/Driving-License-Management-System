using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Helpers.BaseUI;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.Controls;
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
using static BusinessLayer.Core.clsPerson;
using static BusinessLayer.Core.clsUsersPermissions;
using static PresentationLayer.Global.clsGlobalData;
namespace PresentationLayer.Drivers
{
    public partial class frmListDrivers : clsBaseForm
    {

        Task task;
        DataTable _dtAllDriversList = new DataTable();
        void LoadAllDriversList()
        {
            lock (lockObject)
            {
                _dtAllDriversList = clsDriver.GetAllDriversList();
            }
        }

        public frmListDrivers()
        {
            InitializeComponent();
 
        }
           


        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        void RefreshTotalCount()
            => lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
        void RefreshForm()
            => frmListDrivers_Load(null, null);
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            task= Task.Run(LoadAllDriversList);
            SetTitle("List Drivers");
            cbFilterBy.SelectedIndex = 0;//DriverID
            HandleFilterValueTXTVisibility();
            Task.WaitAll(task);
            dgvDrivers.DataSource = _dtAllDriversList;
            RefreshTotalCount();
        }
        void HandleFilterValueTXTVisibility()
            => txtFilterValue.Visible = (cbFilterBy.Text != "None");

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
         => MessageBox.Show("Not implemented yet.");


        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
      
            if (dgvDrivers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvDrivers.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                logExceptions?.AddLog(new Exception($"Error when Loading Parsing PersonID from DGV Row."));
                return;
            }
            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            RefreshForm();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dgvDrivers.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvDrivers.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                logExceptions?.AddLog(new Exception($"Error when Loading Parsing PersonID from DGV Row."));
                return;
            }
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            RefreshForm();
        }
        string GetFilterColumnDBName()
        {
            return cbFilterBy.Text switch
            {
                "Driver ID" => "DriverID",
                "Person ID" => "PersonID",
                "National No." => "NationalNo",
                "Full Name" => "FullName",
                "Active Licenses" => "ActiveLicenses",
                "Penalty Points" => "PenaltyPoints",
                _ => "None"
            };
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnDBName();
            try
            {
                if (txtFilterValue.Text.Trim() == "")
                {
                    _dtAllDriversList.DefaultView.RowFilter = "";
                    RefreshTotalCount();
                    return;
                }
                if (txtFilterValue.Text.Trim() == "None")
                {
                    //Fire cb Event
                    cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                    _dtAllDriversList.DefaultView.RowFilter = "";
                    RefreshTotalCount();
                    return;
                }

                if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                    //in this case we deal with numbers not string.
                    _dtAllDriversList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                else
                    _dtAllDriversList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
                RefreshTotalCount();

            }
            catch (FormatException ex)
            {
                logExceptions?.AddLog(ex);
            }
            catch (Exception ex)
            {
                logExceptions?.AddLog(ex);
            }

            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleFilterValueTXTVisibility();
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (cbFilterBy.Text != "Full Name" && (cbFilterBy.Text != "National No"))
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void dgvDrivers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvDrivers.Columns.Count == 7)
            {

                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Create Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;

                dgvDrivers.Columns[6].HeaderText = "Penalty Points";
                dgvDrivers.Columns[6].Width = 100;
            }
        }

        private void cmsDrivers_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDrivers.CurrentRow == null || dgvDrivers.Rows.Count == 0)
                e.Cancel = true;
        }
    }
}

