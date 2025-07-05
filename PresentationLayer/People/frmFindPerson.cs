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


namespace PresentationLayer.People
{
    public partial class frmFindPerson : clsBaseForm
    {
        //Note:frmAddEditPerson also has another DataBack event
        public event Action<object, int> DataBack;



        public frmFindPerson()
        {
            InitializeComponent();
            SetTheme(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
         => DataBack?.Invoke(this,ctrlPersonCardWithFilter1.Person.PersonID.Value);

        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            SetTitle("Find Person");
        }
    }
}
