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
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers.BaseUI;
namespace PresentationLayer.Users
{
    public partial class frmUserInfo : clsBaseForm
    {
        private int? _UserID = null;
        public frmUserInfo(int UserID)
        {
            SetTheme(this);
            InitializeComponent();
            _UserID=UserID; 
        }

        private void btnClose_Click(object sender, EventArgs e)
         => this.Close();

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            
            ctrlUserCard1.LoadUser(_UserID.Value);
            SetTitle("User Information");
        }
         
    }
}
