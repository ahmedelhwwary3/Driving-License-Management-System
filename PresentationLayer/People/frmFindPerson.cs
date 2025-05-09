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
 

namespace PresentationLayer.People
{
    public partial class frmFindPerson : Form
    {
        //Note:frmAddEditPerson also has another DataBack event
        public event Action<object, int> DataBack;



        public frmFindPerson()
        {
            InitializeComponent();
            this.Load += (sender, e) =>
            {
                if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.FindPerson))
                    return;
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
         => DataBack?.Invoke(this, (int)ctrlPersonCardWithFilter1.Person.PersonID);
    }
}
