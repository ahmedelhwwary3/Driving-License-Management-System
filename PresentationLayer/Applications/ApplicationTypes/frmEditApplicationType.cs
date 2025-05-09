using BusinessLayer;
using PresentationLayer.Global;
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

namespace PresentationLayer.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int? _ApplicationTypeID = null;
        private clsApplicationType _ApplicationType = new clsApplicationType();
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }



        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.GetByID(_ApplicationTypeID);
            if (_ApplicationType == null)
            {
                MessageBox.Show($"Application Type with is not found", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtFees.Text = (_ApplicationType.ApplicationFees).ToString("F2");
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not valid ! " +
                    "Please chech the rec icon messages!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ApplicationType.ApplicationTypeTitle = txtTitle.Text.Trim();
            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal Fees))
            {
                MessageBox.Show("Error:An unexpected error occurred ! ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("ApplicationTypeFees Parsing Error."));
                return;
            }
            _ApplicationType.ApplicationFees = Fees;
            try
            {
                _ApplicationType.LoggedUserID = clsGlobal.CurrentUser.UserID;
                if (!_ApplicationType.Save())
                    throw new Exception("Save Application Type Failed.");

                MessageBox.Show("Application Type was updated successfully", "succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Application Type update Failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(ex);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();


        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                errorProvider1.SetError(txtTitle, "This Field can not be empty");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {

                errorProvider1.SetError(txtFees, "This Field can not be empty");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
            if (!clsValidation.IsNumber(txtFees.Text.Trim()))
            {

                errorProvider1.SetError(txtFees, "Invalid Number!");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
        }
    }
}
