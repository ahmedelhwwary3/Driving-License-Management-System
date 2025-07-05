using PresentationLayer.Licenses.InternationalLicenses;
using PresentationLayer.Licenses.LocalLicenses;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using BusinessLayer.Core;
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Licenses
{
    public partial class frmShowLicenseHistory : clsBaseForm
    {
        private int _PersonID = default;

        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            SetTheme(this);
            _PersonID = PersonID;
        }

        public frmShowLicenseHistory()
        {
            InitializeComponent();
        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("View")))
                return;

            if (_PersonID == default)
            {
                ctrlPersonCardWithFilter1.FilterFocus();
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                MessageBox.Show("Error:Person is not found! Please choose another person.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetTitle("Show License History");
            LoadDriverData(_PersonID);
            ctrlDriverLicenses1.dgvLocalLicenses.ContextMenuStrip = cmsLocalLicenseHistory;
            ctrlDriverLicenses1.dgvInternationalLicenses.ContextMenuStrip = cmsInterenationalLicenseHistory;
        }

        private void LoadDriverData(int PersonID)
        {
            ctrlDriverLicenses1?.LoadDriverDataByPersonID(PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlPersonCardWithFilter1?.LoadPerson(PersonID);
        }

        private void btnExit_Click(object sender, EventArgs e)
            => this.Close();

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            _PersonID = PersonID;
            LoadDriverData(PersonID);
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenses1.dgvInternationalLicenses.CurrentRow == null)
            {
                MessageBox.Show("Error:International License is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(ctrlDriverLicenses1.dgvInternationalLicenses.CurrentRow.Cells[0].Value is int InternationalLicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new FormatException("Error while parsing " +
                    "InternationalLicenseID in dgvInternationalLicensesHistory cell[0] to int."));
                return;
            }

            frmShowInternationaLicenseInfo frm = new frmShowInternationaLicenseInfo(InternationalLicenseID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrlDriverLicenses1?.dgvLocalLicenses?.CurrentRow == null)
            {
                MessageBox.Show("Error:Local License is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(ctrlDriverLicenses1?.dgvLocalLicenses?.CurrentRow?.Cells[0]?.Value is int LicenseID))
            {
                MessageBox.Show("Error:An unexpected error happened!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new FormatException("Error while parsing LicenseID in dgvLocalLicensesHistory cell[0] to int."));
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
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
