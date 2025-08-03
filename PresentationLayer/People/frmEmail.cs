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
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Global.clsUtil;
namespace PresentationLayer.People
{
    public partial class frmEmail : clsBaseForm
    {
        string _ToEmail="";
 
        public frmEmail(string ToEmail)
        {
            InitializeComponent();
 
            _ToEmail = ToEmail;
        }


        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            SetTitle("Send Email");
            string FromEmail= CurrentUser.PersonInfo.Email.Trim();
            txtFrom.Text = FromEmail;
            txtTo.Text = _ToEmail;
            txtSubject?.Focus();
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBody_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtSubject.AppendText(Environment.NewLine);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid ! Please check red icon messages",
                                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Subject = txtSubject.Text.Trim();
            string To = _ToEmail;
            string Body=txtBody.Text.Trim();

            if(!SendEmailViaOutlook(Subject, To, Body))
                MessageBox.Show("Error:Error with Microsoft Out Look Program !",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Email Was Sent Successfully.",
                            "Send Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSubject_Validating(object sender, CancelEventArgs e)
        {
            if(txtSubject.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSubject,"This Field is required !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSubject, null);
            }
        }
    }
}
