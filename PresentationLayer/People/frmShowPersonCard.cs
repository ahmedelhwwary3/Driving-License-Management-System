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
    public partial class frmShowPersonCard : clsBaseForm
    {

        public frmShowPersonCard(int PersonID)
        {
            InitializeComponent();
            SetTheme(this);
            ctrlPersonCard1.LoadPerson(PersonID);
            SetTitle("Show Person Details");
        }
        public frmShowPersonCard(string NationalNo)
        {
            InitializeComponent();
            SetTheme(this);
            ctrlPersonCard1?.LoadPerson(NationalNo);
            SetTitle("Show Person Details");
        }
        private void btnClose_Click(object sender, EventArgs e)
        => this.Close();

         
    }
}
