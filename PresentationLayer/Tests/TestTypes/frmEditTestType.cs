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
using static BusinessLayer.clsTestType;

namespace PresentationLayer.Tests.TestTypes
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;
        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not valid ! " +
                    "Please check red icon messages", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestType.LoggedUserID=clsGlobal.CurrentUser.UserID;
            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription = txtDescription.Text.Trim();
            if (decimal.TryParse(txtFees.Text.Trim(), out decimal Fees))
                _TestType.TestTypeFees = Fees;
            else
            {
                MessageBox.Show("Error:Some thing wrong happened !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new FormatException("Test Fees Parsing failed."));
                return;
            }
            try
            {
                if (_TestType.Save())
                {
                    MessageBox.Show("Test Type was updated successfully", "Succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsGlobal.LogError(ex);
                MessageBox.Show("Error:An unexpected error occurred while saving. " +
                    "Please try again later.", "Save failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.EditTestType))
                return;
            _TestType = clsTestType.GetByID((int)_TestTypeID);
            if (_TestType == null)
            {
                MessageBox.Show($"Test Type is not found !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = ((int)_TestType.TestTypeID).ToString("F2");
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = ((int)_TestType.TestTypeFees).ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
        }






        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            //e.Handled False means=> allow pressing
            e.Handled = !char.IsDigit(e.KeyChar);

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This Field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This Field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDescription, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This Field is required!");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
            //Like the  KeyPress Event But after User Enters Full Value
            //with KeyPress you can not set extra validation code like errorProvider
            //No need here for KeyPres
            //s as no Exception will be thrown if Value is not number like the cbFilter does
            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
        }
    }

}
