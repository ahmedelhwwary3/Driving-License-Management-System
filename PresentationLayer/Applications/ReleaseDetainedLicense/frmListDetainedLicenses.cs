using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.DetainLicense;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ReleaseDetainedLicense
{
    public partial class frmListDetainedLicenses : Form
    {

        private DataTable _dtDetainedLicenses=new DataTable();
 

        public frmListDetainedLicenses()
        {
            InitializeComponent();
           dgvDetainedLicenses.DataBindingComplete += (sender, e)
                => _FormatDGVColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        void _FormatDGVColumns()
        {
            if (dgvDetainedLicenses.Columns.Count ==9)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "Detain ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "Lisense ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "National No";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release Application ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }
        }



        

        void _RefreshForm() 
            => frmListDetainedLicenses_Load(null, null);



        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ReleaseDetainedLicense))
                return;
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvDetainedLicenses.CurrentRow.Cells[0].Value is int DetainID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Parsing DetainID from DGV Row."));
                return;
            }
            clsDetainedLicense DetainedLicense = clsDetainedLicense.GetByID(DetainID);
            if (DetainedLicense == null)
            {
                MessageBox.Show("Error:Detained License is not found !", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DetainedLicense.IsReleased)
            {
                MessageBox.Show("Error:License is not Detained !", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(DetainID);
            frm.ShowDialog();
            _RefreshForm();



        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            if(dgvDetainedLicenses.CurrentRow==null)
            {
                MessageBox.Show("Detained License is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Detained License through DGV"));
                return;
            }
            if (!(dgvDetainedLicenses.CurrentRow.Cells[3].Value is bool IsReleased))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing IsReleased Value To boolean ."));
                return;
            }
            releaseDetainedLicenseToolStripMenuItem.Enabled = IsReleased;

        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ReleaseDetainedLicense))
                return;
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            //refresh
            _RefreshForm();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.DetainLicense))
                return;
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            //refresh
            _RefreshForm();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;//None

            _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            _RefreshTotalCount();
        }
        void _RefreshTotalCount() 
            => lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        string _GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    return "DetainID";
 
                case "Is Released":
                    return "IsReleased";

                case "National No.":
                    return "NationalNo";
     


                case "Full Name":
                    return "FullName";
         

                case "Release Application ID":
                    return "ReleaseApplicationID";
    

                default:
                    return "None";
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumnDBName();
            if (FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                txtFilterValue.Visible = false;
                _RefreshTotalCount();
                return;
            }
            if(txtFilterValue.Text.Trim() == "")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                _RefreshTotalCount();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            _RefreshTotalCount();

        }
        void _HandleCBsVisibility()
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Released");
            cbIsReleased.Visible = cbFilterBy.Text == "Is Released";
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HandleCBsVisibility();
            if(cbIsReleased.Visible)//1.IsReleased
            {
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;//All Released Licenses
            }
            else if (txtFilterValue.Visible)//2.Other
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }
            //Else(None) , CBs Visibility Handeled First, no extra code .
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            if (dgvDetainedLicenses.CurrentRow== null)
            {
                MessageBox.Show("Detained License is not existed !", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Detained License through DGV"));
                return;
            }
            if (!(dgvDetainedLicenses.CurrentRow.Cells[1].Value is int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing LicenseID Value To int ."));
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
            _RefreshForm();
        }
 

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Detained License is not existed !", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Detained License through DGV"));
                return;
            }
            if (!(dgvDetainedLicenses.CurrentRow.Cells[1].Value is int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing LicenseID Value To int ."));
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            if (dgvDetainedLicenses.CurrentRow == null)
            {
                MessageBox.Show("Detained License is not existed !", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Detained License through DGV"));
                return;
            }
            if (!(dgvDetainedLicenses.CurrentRow.Cells[1].Value is int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException($"Error with parsing LicenseID Value To int ."));
                return;
            }
            clsLicense License=clsLicense.GetByID(LicenseID);
            if (License==null)
            {
                MessageBox.Show($"Error:License with ID {LicenseID} is not existed !"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)License.Application.ApplicantPersonID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.Text=="All")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                _RefreshTotalCount();
                return;
            }

            string FilterColumn = "IsReleased";
            string FilterValue = string.Empty;
            if (cbIsReleased.Text == "Yes")
                FilterValue = "1";
            else
                FilterValue = "0";
            _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            _RefreshTotalCount();
        }
    }
}
