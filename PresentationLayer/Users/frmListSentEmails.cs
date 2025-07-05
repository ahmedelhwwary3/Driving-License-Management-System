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

namespace PresentationLayer.Users
{
    public partial class frmListSentEmails : clsBaseForm
    {
        DataTable _dtSentMails;
        public frmListSentEmails(DataTable dtSentMails)
        {
            InitializeComponent();
            _dtSentMails = dtSentMails;
        }

        private void frmListSentEmails_Load(object sender, EventArgs e)
        {
            SetTheme(this);
            dgvSentMails.DataSource = _dtSentMails;
            lblRecords.Text=dgvSentMails?.Rows?.Count.ToString()??string.Empty;
        }
    }
}
