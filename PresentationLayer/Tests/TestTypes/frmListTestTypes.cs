using BusinessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Core.clsUsersPermissions;
using System.Windows.Forms;
using static BusinessLayer.Core.clsTestType;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Tests.TestTypes
{
    public partial class frmListTestTypes : clsBaseForm
    {
        private DataTable _dtTestTypesList=new DataTable();
        BindingSource _bsTestTypesList = new BindingSource();
        public frmListTestTypes()
        {
            InitializeComponent();
            SetTheme(this);
            this._bsTestTypesList.BindingComplete 
                += (sender, e) => FormatDGVColumns();
        }
        void FormatDGVColumns()
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

        void RefreshTotalCount()
            => lblRecords.Text = dgvTestTypes.Rows.Count.ToString();
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtTestTypesList = clsTestType.GetAllTestTypesList();
            _bsTestTypesList.DataSource= _dtTestTypesList;
            dgvTestTypes.DataSource = _bsTestTypesList;
            RefreshTotalCount();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            frmEditTestType frm = new frmEditTestType((enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialogIfAuthorized(GetPermissions("Admin"), frm);
            RefreshForm();
        }
        void RefreshForm() => frmListTestTypes_Load(null, null);
         
    }
}
