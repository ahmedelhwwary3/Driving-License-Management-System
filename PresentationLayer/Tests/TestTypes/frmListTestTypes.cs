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

namespace PresentationLayer.Tests.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtTestTypesList=new DataTable();
        BindingSource _bsTestTypesList = new BindingSource();
        public frmListTestTypes()
        {
            InitializeComponent();
            this._bsTestTypesList.BindingComplete 
                += (sender, e) => _FormatDGVColumns();
        }
        void _FormatDGVColumns()
        {
            if (dgvTestTypes.Columns.Count == 4)
            {
                dgvTestTypes.Columns[0].HeaderText = "Test Type ID";
                dgvTestTypes.Columns[0].Width = 150;

                dgvTestTypes.Columns[1].HeaderText = "Test Type Title";
                dgvTestTypes.Columns[1].Width = 250;

                dgvTestTypes.Columns[2].HeaderText = "Test Type Description";
                dgvTestTypes.Columns[2].Width = 350;

                dgvTestTypes.Columns[3].HeaderText = "Test Type Fees";
                dgvTestTypes.Columns[3].Width = 130;
            }
        }
      

        private void btnClose_Click(object sender, EventArgs e) 
            => this.Close();

        void _RefreshTotalCount()
            => lblRecords.Text = dgvTestTypes.Rows.Count.ToString();
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtTestTypesList = clsTestType.GetAllTestTypesList();
            _bsTestTypesList.DataSource= _dtTestTypesList;
            dgvTestTypes.DataSource = _bsTestTypesList;
            _RefreshTotalCount();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.EditTestType))
                return;
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshForm();
        }
        void _RefreshForm() => frmListTestTypes_Load(null, null);
         
    }
}
