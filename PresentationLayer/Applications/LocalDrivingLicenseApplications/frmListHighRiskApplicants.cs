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

namespace PresentationLayer.Applications.LocalDrivingLicenseApplications
{
    public partial class frmListHighRiskApplicants : clsBaseForm
    {
        DataTable _dtAllHighRiskApplicants = new DataTable();
        public frmListHighRiskApplicants()
        {
            InitializeComponent();
            SetTheme(this);
        }

        private void frmListHighRiskApplicants_Load(object sender, EventArgs e)
        {
            SetTitle("High Rish Applicants");
            Task task = Task.Run(() => { _dtAllHighRiskApplicants = clsHighRiskApplicants.GetAllHighRiskApplicantsList(); });
            Task.WaitAll(task);
            dgvListAplicants.DataSource = _dtAllHighRiskApplicants;
            lblCount.Text = dgvListAplicants.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListAplicants_BindingContextChanged(object sender, EventArgs e)
        {
            if (dgvListAplicants.Columns.Count == 7)
            {
                dgvListAplicants.Columns[0].HeaderText = "Risk ID";
                dgvListAplicants.Columns[0].Width = 60;

                dgvListAplicants.Columns[1].HeaderText = "Local Driving License Application ID";
                dgvListAplicants.Columns[1].Width = 150;
                
                dgvListAplicants.Columns[3].HeaderText = "National No";
                dgvListAplicants.Columns[3].Width = 200;
                
                dgvListAplicants.Columns[2].HeaderText = "Full Name";
                dgvListAplicants.Columns[2].Width = 220;



                dgvListAplicants.Columns[4].HeaderText = "Class Name";
                dgvListAplicants.Columns[4].Width = 250;

                dgvListAplicants.Columns[5].HeaderText = "Test Appointment ID";
                dgvListAplicants.Columns[5].Width = 130;

                dgvListAplicants.Columns[6].HeaderText = "AppointmentDate";
                dgvListAplicants.Columns[6].Width = 130;
            }
        }
    }
}
