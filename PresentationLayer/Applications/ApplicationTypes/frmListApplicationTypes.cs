using BusinessLayer.Core;
using PresentationLayer.Global;
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
using static BusinessLayer.Core.clsUsersPermissions;
namespace PresentationLayer.Applications.ApplicationTypes
{
    public partial class frmListApplicationTypes : clsBaseForm
    {
        Thread thread;
        private DataTable _dtApplycationTypes=new DataTable();
        BindingSource _bsApplycationTypes=new BindingSource();
        public frmListApplicationTypes()
        {
            InitializeComponent();
            SetTheme(this);
        }
        

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        void RefreshTotalCount() 
            => lblRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        void RefreshForm()=>
            frmListApplicationTypes_Load(null, null);
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            thread = new Thread(() => _dtApplycationTypes = clsApplicationType.GetAllApplicationTypesList());
            thread.Start();
            SetTitle("List Application Types");
            thread.Join();
            _bsApplycationTypes.DataSource= _dtApplycationTypes;
            dgvApplicationTypes.DataSource = _bsApplycationTypes;
            RefreshTotalCount();            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            if (dgvApplicationTypes.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dgvApplicationTypes.CurrentRow.Cells[0].Value is int ApplicationTypeID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                   clsGlobalData.WindownsEventLog.Log(new Exception($"Error when Loading Parsing ApplicationTypeID from DGV Row."));
                return;
            }
            frmEditApplicationType frm = new frmEditApplicationType(ApplicationTypeID);
            frm.ShowDialogIfAuthorized(GetPermissions("Admin"),frm);
            RefreshForm();
        }

        private void dgvApplicationTypes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvApplicationTypes.Columns.Count == 3)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "BaseApplication Type ID";
                dgvApplicationTypes.Columns[0].Width = 180;

                dgvApplicationTypes.Columns[1].HeaderText = "BaseApplication Type Title";
                dgvApplicationTypes.Columns[1].Width = 400;

                dgvApplicationTypes.Columns[2].HeaderText = "BaseApplication Type Fees";
                dgvApplicationTypes.Columns[2].Width = 250;
            }
        }
    }
}
