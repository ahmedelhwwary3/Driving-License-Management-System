using BusinessLayer.Core;
using PresentationLayer.Applications.InternationalLicenseApplication;
using PresentationLayer.Global;
using PresentationLayer.Helpers.BaseUI;
using PresentationLayer.People;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.Core.clsUsersPermissions;

namespace PresentationLayer.Licenses.InternationalLicenses
{
    public partial class frmListInternationalLicenses : clsBaseForm
    {
        private DataTable _dtInternationalLicenseApplications=new DataTable();
        Task _task;
        public frmListInternationalLicenses()
        {
            InitializeComponent();
            SetTheme(this);
            dgvInternationalLicenses.DataBindingComplete += (sender, e)
                => FormatDGVColumns();
        }
        void FormatDGVColumns()
        {
            if(dgvInternationalLicenses.Columns.Count==8)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "International License ID";
                dgvInternationalLicenses.Columns[0].Width = 120;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 100;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 100;

                dgvInternationalLicenses.Columns[3].HeaderText = "Local License ID";
                dgvInternationalLicenses.Columns[3].Width = 100;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 110;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 110;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 100;

                dgvInternationalLicenses.Columns[7].HeaderText = "Created By User ID";
                dgvInternationalLicenses.Columns[7].Width = 100;

            }
        }
        void RefreshTotalCount()
            => lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _task= Task.Run(()=> _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses());
            cbFilterBy.SelectedIndex = 0;
            Task.WaitAll(_task);
            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            RefreshTotalCount();
            SetTitle("List International Licenses");
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {


            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    {
                        FilterColumn = "InternationalLicenseID";
                        break;
                    }
                   
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    {
                        FilterColumn = "DriverID";
                        break;
                    }
                   

                case "Local License ID":
                    {
                        FilterColumn = "IssuedUsingLocalLicenseID";
                        break;
                    }

                case "Is Active":
                    {
                        FilterColumn = "IsActive";
                        break;
                    }

                case "Created By User ID":
                    {
                        FilterColumn = "CreatedByUserID";
                        break;
                    }
                default:
                    {
                        FilterColumn = "None";
                        break;
                    }
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                RefreshTotalCount();
                return;
            }

            if(dgvInternationalLicenses.Rows.Count>0)
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            RefreshTotalCount();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                RefreshTotalCount();
                return;
            }
            if (dgvInternationalLicenses.Rows.Count > 0)
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            RefreshTotalCount();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsReleased.Visible = (cbFilterBy.Text== "Is Active");
            txtFilterValue.Visible = (cbFilterBy.Text!="None"&&cbFilterBy.Text!= "Is Active");
            if (cbFilterBy.Text == "Is Active")
            {
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
                return;
            }
            if(cbFilterBy.Text !="None")
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
             
            frmIssueInternationalLicense frm= new frmIssueInternationalLicense();
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            _RefreshForm();
        }
        void _RefreshForm()=> frmListInternationalLicenses_Load(null, null);
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (!(dgvInternationalLicenses.CurrentRow.Cells[2].Value is int DriverID))
            {
                MessageBox.Show("Error:An unexpected error happened !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                   clsGlobalData.WindownsEventLog.Log(new FormatException("An unexpected error happened" +
                    " while parsing DriverID from DGV Cell 2 to int."));
                return;
            }

            int PersonID = clsDriver.GetByDriverID(DriverID).PersonID;
            frmShowPersonCard frm=new frmShowPersonCard(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            _RefreshForm();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (!(dgvInternationalLicenses.CurrentRow.Cells[2].Value is int DriverID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                   clsGlobalData.WindownsEventLog.Log(new FormatException("An unexpected error happened" +
                    " while parsing DriverID from DGV Cell 2 to int."));
                return;
            }
            int PersonID = clsDriver.GetByDriverID(DriverID).PersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            _RefreshForm();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dgvInternationalLicenses.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvInternationalLicenses.CurrentRow.Cells[0].Value is int InternationalLicenseID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                   clsGlobalData.WindownsEventLog.Log(new Exception($"Error when Loading Parsing InternationalLicenseID from DGV Row."));
                return;
            }
            clsInternationalLicense InternationalLicense = clsInternationalLicense.GetInternationalLicenseByID(InternationalLicenseID);
            if (InternationalLicense == null)
            {
                MessageBox.Show($"Error:International License is not found !"
                    , "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmShowInternationaLicenseInfo frm = new frmShowInternationaLicenseInfo(InternationalLicenseID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

         

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

    }
}
