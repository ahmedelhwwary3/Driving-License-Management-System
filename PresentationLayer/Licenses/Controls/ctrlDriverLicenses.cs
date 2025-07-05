using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;
using PresentationLayer.Licenses.InternationalLicenses;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Licenses.Controls
{
    public partial class ctrlDriverLicenses : clsBaseCtrl
    {
        private clsDriver _Driver = new clsDriver();
        private DataTable _dtDriverLocalLicensesHistory=new DataTable();
        private DataTable _dtDriverInternationalLicensesHistory = new DataTable();
        
        public DataGridView dgvLocalLicenses => this.dgvLocalLicensesHistory;
        public DataGridView dgvInternationalLicenses=>this.dgvInternationalLicensesHistory;



        public ctrlDriverLicenses()
        {
            SetTheme(this);
            InitializeComponent();
        }
       
        

        void RefreshLocalLicensesTotalCount()
            => lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();
        void RefreshInternationalLicensesTotalCount()
            => lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

        void LoadLocalLicense()
        {

            _dtDriverLocalLicensesHistory = clsDriver.GetAllLocalLicenses((int)_Driver.DriverID);
            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            RefreshLocalLicensesTotalCount();    
        }

        void LoadInternationalLicense()
        {

            _dtDriverInternationalLicensesHistory = clsDriver.GetAllInternationalLicenses((int)_Driver.DriverID);
            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;
            RefreshInternationalLicensesTotalCount();          
        }

        public void LoadDriverData(int DriverID)
        {
            _Driver = clsDriver.GetByDriverID(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show($"Error:Driver is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Parallel.Invoke(LoadLocalLicense,LoadInternationalLicense);

        }

        public void LoadDriverDataByPersonID(int PersonID)
        {

            _Driver = clsDriver.GetByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show($"Error:Driver is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadLocalLicense();
            LoadInternationalLicense();
        }

        

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();
            RefreshInternationalLicensesTotalCount();
            RefreshLocalLicensesTotalCount();
        }

        private void dgvLocalLicensesHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvLocalLicensesHistory.Columns.Count == 6)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "License ID";
                dgvLocalLicensesHistory.Columns[0].Width = 120;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvLocalLicensesHistory.Columns[1].Width = 120;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 200;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 150;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 150;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 80;

            }
        }

        private void dgvInternationalLicensesHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvInternationalLicensesHistory.Columns.Count == 6)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "International License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 120;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 120;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "Local License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 120;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 150;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 150;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 100;
            }

        }
    }
}
