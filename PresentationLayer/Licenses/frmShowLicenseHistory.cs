using BusinessLayer;
using PresentationLayer.Global;
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

namespace PresentationLayer.Licenses
{
    public partial class frmShowLicenseHistory : Form
    {
        private int? _PersonID = null;

        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        void _OpenShowLicenseForm()
        {
            int? LicenseID = clsLicense.GetByPersonID(_PersonID).LicenseID;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID.Value);
            frm.ShowDialog();
        }
        public frmShowLicenseHistory()
        {
            InitializeComponent();
        }
        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseHistory))
                return;
            if (_PersonID == null)
            {
                ctrlPersonCardWithFilter1.FilterFocus();
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                MessageBox.Show($"Error:Person is not found" +
                    $" ! Please choose another person.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDriverData(_PersonID.Value);
            ctrlDriverLicenses1.dgvLocalLicenses.ContextMenuStrip = cmsLocalLicenseHistory;
            ctrlDriverLicenses1.dgvInternationalLicenses.ContextMenuStrip = cmsInterenationalLicenseHistory;


        }
        void _LoadDriverData(int PersonID)
        {
            ctrlDriverLicenses1.LoadDriverDataByPersonID(PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlPersonCardWithFilter1.LoadPerson(PersonID);
        }

        private void btnExit_Click(object sender, EventArgs e)
            => this.Close();

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            _PersonID = PersonID;
            _LoadDriverData((int)_PersonID);
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            if (ctrlDriverLicenses1.dgvInternationalLicenses.CurrentRow == null)
            {
                MessageBox.Show("Error:International License is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ctrlDriverLicenses1.dgvInternationalLicenses.CurrentRow.Cells[0].Value is int InternationalLicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing InternationalLicenseID in dgvInternationalLicensesHistory cell[0] to int."));
                return;
            }
            frmShowInternationaLicenseInfo frm = new frmShowInternationaLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowLicenseInfo))
                return;
            if (ctrlDriverLicenses1.dgvLocalLicenses.CurrentRow == null)
            {
                MessageBox.Show("Error:Local License is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(ctrlDriverLicenses1.dgvLocalLicenses.CurrentRow.Cells[0].Value is int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Error while parsing LicenseID in dgvLocalLicensesHistory cell[0] to int."));
                return;
            }
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void cmsInterenationalLicenseHistory_Opening(object sender, CancelEventArgs e)
        {
            if (ctrlDriverLicenses1.dgvInternationalLicenses.CurrentRow == null || ctrlDriverLicenses1.dgvInternationalLicenses.Rows.Count == 0)
                e.Cancel = true;
        }

        private void cmsLocalLicenseHistory_Opening(object sender, CancelEventArgs e)
        {
            if (ctrlDriverLicenses1.dgvLocalLicenses.CurrentRow == null || ctrlDriverLicenses1.dgvLocalLicenses.Rows.Count == 0)
                e.Cancel = true;
        }
    }
}
