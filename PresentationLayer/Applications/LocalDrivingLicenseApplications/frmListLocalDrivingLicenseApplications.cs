using BusinessLayer;
using PresentationLayer.Applications.LocalDrivingLicenseApplications.Controls;
using PresentationLayer.Global;
using PresentationLayer.Licenses;
using PresentationLayer.Licenses.LocalLicenses;
using PresentationLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtLocalDrivingLicenseApplications=new DataTable();
        BindingSource _bsLocalDrivingLicenseApplications=new BindingSource();
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
            dgvLocalApplications.DataBindingComplete += (sender,e)
                => _FormatDGV();
        }
        void _FormatDGV()
        {
            dgvLocalApplications.Sort(dgvLocalApplications.Columns["ApplicationDate"],ListSortDirection.Ascending);
            if(dgvLocalApplications.Columns.Count==7)
            {
                dgvLocalApplications.Columns[0].HeaderText = "Local Application ID";
                dgvLocalApplications.Columns[0].Width = 120;

                dgvLocalApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalApplications.Columns[1].Width = 190;

                dgvLocalApplications.Columns[2].HeaderText = "National No";
                dgvLocalApplications.Columns[2].Width = 150;

                dgvLocalApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalApplications.Columns[3].Width = 280;

                dgvLocalApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalApplications.Columns[4].Width = 170;

                dgvLocalApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalApplications.Columns[5].Width = 100;

                dgvLocalApplications.Columns[6].HeaderText = "Status";
                dgvLocalApplications.Columns[6].Width = 100;
            }
        }
        private void btnClose_Click(object sender, EventArgs e) 
            => this.Close();

        void _RefreshForm()
            => frmListLocalDrivingLicenseApplications_Load(null, null);

        private void btnAddNewLocalApp_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditLocalApplication))
                return;
            frmAddEditLocalDrivingLicenseApplication frm=new frmAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshForm();
        }
        void _RefreshTotalCount()
            => lblRecords.Text = dgvLocalApplications.Rows.Count.ToString();
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
      
            _dtLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationsList();
            _bsLocalDrivingLicenseApplications.DataSource= _dtLocalDrivingLicenseApplications;
            dgvLocalApplications.DataSource = _bsLocalDrivingLicenseApplications;
            _RefreshTotalCount();
            cbFilterColumn.Text = "None";
            cbFilterColumn_SelectedIndexChanged(null,null);
            
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLocalApplicationInfo))
                return;
            frmShowLocalDrivingLicenseApplicationInfo frm=new frmShowLocalDrivingLicenseApplicationInfo((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditLocalApplication))
                return;
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterColumn.Text != "None");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }
        string _GetFitlerColumnDBName()
        {
            switch (cbFilterColumn.Text)
            {
                case "Local Driving License Application ID":
                    {
                        return "LocalApplication";
   
                    }
                case "Driving Class":
                    {
                        return "ClassName";
 
                    }
                case "National No":
                    {
                        return "NationalNo";
             
                    }
                case "Full Name":
                    {
                        return "FullName";
                     
                    }
                case "Passed Tests":
                    {
                        return "PassedTests";
          
                    }
                case "Status":
                    {
                        return "Status";
           
                    }
                default:
                    {
                        return "None";
                    }
                    
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = _GetFitlerColumnDBName();
            if (FilterColumn == "None" )
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                txtFilterValue.Visible = false;
                _RefreshTotalCount();
                return;
            }
            if( txtFilterValue.Text.Trim() == "")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                _RefreshTotalCount();
                return;
            }
            if (FilterColumn== "PassedTests" || FilterColumn== "LocalApplication")
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            _RefreshTotalCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Back)
            {
                e.Handled = false;
            }
            if (cbFilterColumn.Text == "Passed Tests" || cbFilterColumn.Text == "Local Driving License Application ID"||cbFilterColumn.Text== "ApplicationDate")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditLocalApplication))
                return;
            if (dgvLocalApplications.CurrentRow==null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (MessageBox.Show("Are you sure you want to Delete this application?", "Confirm Delete"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                == DialogResult.OK)
            {
                if(!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
                {
                    MessageBox.Show($"Error:An unexpected error happened !", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                    return;
                }
                if(!clsLocalDrivingLicenseApplication.IsExistByID(LocalApplicationID))
                {
                    MessageBox.Show($"Error:Local Driving License Application with ID{LocalApplicationID}" +
                        $" is not existed !", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);  
                    return;
                }
                if(!clsLocalDrivingLicenseApplication.DeleteByID(LocalApplicationID,clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show("Application delete Failed " +
                          "Because The Local Driving License Application already has an appointment",
                          "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MessageBox.Show("Application was deleted successfully", "Confirm Delete",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshForm();

            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditLocalApplication))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalApplicationID);

            if (LocalApp==null)
            {
                MessageBox.Show($"Error:Driving License Application with ID " +
                    $"{LocalApplicationID} is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application ID {LocalApplicationID} through DGV"));
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this Application ?", "Confirm Cancel",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (!LocalApp.Cancel(clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show("Error:Local Driving License Application cancel Failed", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Local Driving License Application was cancelled successfully", "Confirm",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshForm();
            }

        }







        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
            if(dgvLocalApplications.CurrentRow==null||dgvLocalApplications.Rows.Count==0)
            {
                e.Cancel = true;
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !",
                    "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing dgvLocalApplications_LocalApplicationID to int."));
                e.Cancel = true;
                return;
            }
            clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.GetLocalApplicationByID(LocalApplicationID);
            if (LocalApplication==null)
            {
                MessageBox.Show($"Error:Local Driving License Application was not found with ID" +
                    $" {LocalApplicationID.ToString()}", "Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            if(!(dgvLocalApplications.CurrentRow.Cells[5].Value is int PassedTestsCount))
            {
                MessageBox.Show($"Error:An unexpected error happened !",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing dgvLocalApplications_PassedTestCount to int."));
                e.Cancel = true;
                return;
            }

            bool HasPassedVisionTest = LocalApplication.HasPassedTestType(clsTestType.enTestType.Vision);
            bool HasPassedWrittenTest = LocalApplication.HasPassedTestType(clsTestType.enTestType.Written);
            bool HasPassedStreetTest = LocalApplication.HasPassedTestType(clsTestType.enTestType.Street);

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled=
                ( LocalApplication.ApplicationStatus==clsApplication.enApplicationStatus.New&&PassedTestsCount==3);
            //User can not edit the LocalApplication.ClassType if the person passed the StreetTest as this Test depends on the ClassType
            editApplicationToolStripMenuItem.Enabled = 
                (LocalApplication.ApplicationStatus==clsApplication.enApplicationStatus.New&&!HasPassedStreetTest);
             
            cancelApplicationToolStripMenuItem.Enabled = editApplicationToolStripMenuItem.Enabled;
            showLicenseToolStripMenuItem1.Enabled =LocalApplication.IsLicenseIssued();
            deleteApplicationToolStripMenuItem.Enabled = !LocalApplication.IsLicenseIssued();
            showPersonLicenseHistoryToolStripMenuItem.Enabled = LocalApplication.HasAnyActiveLicense();

            scheduleTestsToolStripMenuItem.Enabled = (PassedTestsCount < 3&& LocalApplication.ApplicationStatus==clsApplication.enApplicationStatus.New);
            if(scheduleTestsToolStripMenuItem.Enabled)
            {
                //I organized the code as i need using && to get 1 result in each Line 
                visionTestToolStripMenuItem.Enabled = (!HasPassedVisionTest);
                writtenTestToolStripMenuItem.Enabled= (HasPassedVisionTest&&!HasPassedWrittenTest);
                streetTestToolStripMenuItem.Enabled = (HasPassedVisionTest && HasPassedWrittenTest && !HasPassedStreetTest);
                //The 1st way is cleaner and simple
                //the 2nd is better when you want to add extra code or to avoid unnessecary boolean checks (like a Boolean method:Over head)
                //Both are effictive here and same performance
                #region Another Way_Nested If
                //visionTestToolStripMenuItem.Enabled = !HasPassedVisionTest;
                //if(HasPassedVisionTest)
                //{
                //    writtenTestToolStripMenuItem.Enabled = !HasPassedWrittenTest;
                //    if(HasPassedWrittenTest)
                //    {
                //        streetTestToolStripMenuItem.Enabled = !HasPassedStreetTest;
                //    }
                //} 
                #endregion



            }


        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ListTestAppointments))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm=new frmListTestAppointments(LocalApplicationID,clsTestType.enTestType.Vision);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ListTestAppointments))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm = new frmListTestAppointments(LocalApplicationID, clsTestType.enTestType.Written);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ListTestAppointments))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            frmListTestAppointments frm = new frmListTestAppointments(LocalApplicationID, clsTestType.enTestType.Street);
            frm.ShowDialog();
            _RefreshForm();
        }

         

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.IssueDrivingLicenesForFirstTime))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }
            if(!clsLocalDrivingLicenseApplication.HasPassedAllTestTypes(LocalApplicationID))
            {
                MessageBox.Show("Error:Driving License Applicant Hasn't Passed All Test Types !", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmIssueDrivingLicenesForFirstTime frm = new frmIssueDrivingLicenesForFirstTime(LocalApplicationID);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            clsLocalDrivingLicenseApplication LocalApplication = clsLocalDrivingLicenseApplication.
                GetLocalApplicationByID(LocalApplicationID);
            frmShowLicenseHistory frm=new frmShowLicenseHistory(LocalApplication.ApplicantPersonID.Value);
            frm.ShowDialog();
            _RefreshForm();
        }

        private void showLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            if (dgvLocalApplications.CurrentRow == null)
            {
                MessageBox.Show("Error:Driving License Application is not existed !", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Driving License Application through DGV"));
                return;
            }
            if (!(dgvLocalApplications.CurrentRow.Cells[0].Value is int LocalApplicationID))
            {
                MessageBox.Show($"Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error with parsing LocalApplicationID in DGV Row."));
                return;
            }

            int? LicenseID = clsLocalDrivingLicenseApplication.
                GetLocalApplicationByID(LocalApplicationID).GetActiveLicenseID();

            if (LicenseID == null)
            {
                MessageBox.Show($"Error:License is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)LicenseID);
            frm.ShowDialog();
            //NO refresh need as the License Form does not allow modify
        }
    }
}
