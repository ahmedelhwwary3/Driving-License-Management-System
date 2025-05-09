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
    public partial class frmShowPersonCard : Form
    {

        public frmShowPersonCard(int PersonID)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPerson(PersonID);
            _SetTitle();
        }
        public frmShowPersonCard(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPerson(NationalNo);
            _SetTitle();
        }
        void _SetTitle()
        {
            this.Text = "Show Person Details";
        }


        private void btnClose_Click(object sender, EventArgs e)
        => this.Close();

        private void frmShowPersonCard_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
        }
    }
}
