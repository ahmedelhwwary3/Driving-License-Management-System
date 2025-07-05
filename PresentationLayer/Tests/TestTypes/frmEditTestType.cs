using BusinessLayer.Core;
using static BusinessLayer.Core.clsTestType;
using static PresentationLayer.Global.clsGlobalData;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static PresentationLayer.Global.clsValidation;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.Tests.TestTypes
{
    public partial class frmEditTestType : clsBaseForm
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            SetTheme(this);
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.GetByID((int)_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Test Type is not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblID.Text = ((int)_TestType.TestTypeID).ToString("F2");
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString("F2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Please check red icon messages.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.LoggedUserID = CurrentUser.UserID.Value;
            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription = txtDescription.Text.Trim();

            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal fees))
            {
                MessageBox.Show("Error: Invalid number format!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog.Log(new FormatException("Test Fees Parsing failed."));
                return;
            }

            _TestType.TestTypeFees = fees;

            try
            {
                if (_TestType.Save())
                {
                    MessageBox.Show("Test Type was updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
                MessageBox.Show("An unexpected error occurred while saving. Please try again later.",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This field is required!");
                return;
            }

            if (!IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
