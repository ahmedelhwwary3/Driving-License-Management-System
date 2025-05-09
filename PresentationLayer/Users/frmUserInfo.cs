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

namespace PresentationLayer.Users
{
    public partial class frmUserInfo : Form
    {
        private int? _UserID = null;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID=UserID; 
        }

        private void btnClose_Click(object sender, EventArgs e)
         => this.Close();

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowUserInfo))
                return;
            ctrlUserCard1.LoadUser(_UserID.Value);
        }
         
    }
}
