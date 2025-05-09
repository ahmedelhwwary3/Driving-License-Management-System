using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtApplycationTypes=new DataTable();
        BindingSource _bsApplycationTypes=new BindingSource();
        public frmListApplicationTypes()
        {
            InitializeComponent();
 
        }
        

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        void _RefreshTotalCount() 
            => lblRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        void _RefreshForm()=>
            frmListApplicationTypes_Load(null, null);
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplycationTypes = clsApplicationType.GetAllApplicationTypesList();
            _bsApplycationTypes.DataSource= _dtApplycationTypes;
            dgvApplicationTypes.DataSource = _bsApplycationTypes;
            _RefreshTotalCount();            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.EditApplicationType))
                return;
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
                clsGlobal.LogError(new Exception($"Error when Loading Parsing ApplicationTypeID from DGV Row."));
                return;
            }
            frmEditApplicationType frm = new frmEditApplicationType(ApplicationTypeID);
            frm.ShowDialog();
            _RefreshForm();
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
