using BusinessLayer;
using PresentationLayer.Applications.InternationalLicenseApplication;
using PresentationLayer.Global;
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

namespace PresentationLayer.Licenses.InternationalLicenses
{
    public partial class frmListInternationalLicenses : Form
    {
        private DataTable _dtInternationalLicenseApplications=new DataTable();
        public frmListInternationalLicenses()
        {
            InitializeComponent();
            dgvInternationalLicenses.DataBindingComplete += (sender, e)
                => _FormatDGVColumns();
        }
        void _FormatDGVColumns()
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
        void _RefreshTotalCount()
            => lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;
            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            _RefreshTotalCount();   
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
                _RefreshTotalCount();
                return;
            }

            if(dgvInternationalLicenses.Rows.Count>0)
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            _RefreshTotalCount();
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
                _RefreshTotalCount();
                return;
            }
            if (dgvInternationalLicenses.Rows.Count > 0)
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            _RefreshTotalCount();

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
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.IssueInternationalLicense))
                return;
            frmIssueInternationalLicense frm= new frmIssueInternationalLicense();
            frm.ShowDialog();
            _RefreshForm();
        }
        void _RefreshForm()=> frmListInternationalLicenses_Load(null, null);
        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            if (!(dgvInternationalLicenses.CurrentRow.Cells[2].Value is int DriverID))
            {
                MessageBox.Show("Error:An unexpected error happened !","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("An unexpected error happened" +
                    " while parsing DriverID from DGV Cell 2 to int."));
                return;
            }

            int PersonID = clsDriver.GetByDriverID(DriverID).PersonID.Value;
            frmShowPersonCard frm=new frmShowPersonCard(PersonID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            if (!(dgvInternationalLicenses.CurrentRow.Cells[2].Value is int DriverID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("An unexpected error happened" +
                    " while parsing DriverID from DGV Cell 2 to int."));
                return;
            }
            int PersonID = clsDriver.GetByDriverID(DriverID).PersonID.Value;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
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
                clsGlobal.LogError(new Exception($"Error when Loading Parsing InternationalLicenseID from DGV Row."));
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
            frm.ShowDialog();
        }

         

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

    }
}
