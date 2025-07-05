using BusinessLayer.Core;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Core.clsUsersPermissions;
using System.Windows.Forms;
using PresentationLayer.Helpers;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.People
{
    public partial class ctrlPersonCardWithFilter : clsBaseCtrl
    {
        //(1) First Event of this Form(Publisher)
        #region OnPersonSelected event
        //ref for the objects that will be created when subscribing
        //Event of Action(Void)<int> Type
        //Some Forms will subscribe in event to get the PersonID value
        public event Action<int> OnPersonSelected;
        protected void FireOnPersonSelectedEvent(int PersonID)
        => OnPersonSelected?.Invoke(PersonID);
        #endregion

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get => _ShowAddPerson;
            set
            {
                _ShowAddPerson = value;
                btnAddNew.Visible = _ShowAddPerson;
            }
        }
        public Button FindBtn => btnFind;

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            SetTheme(this);
        }



        //I always get the Full person obj so i get the ID from it ..
        //..instead of cashing the PersonID (more Cleaner and readable)
        //All Object data are cashed on RAM (very fast)
        public clsPerson Person
            => ctrlPersonCard1.Person;
        public void LoadPerson(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;//PersonID
            txtFilterValue.Text = PersonID.ToString();
            FindNow();
        }
        public void LoadPerson(string NationalNo)
        {
            cbFilterBy.SelectedIndex = 0;//NationalNo
            txtFilterValue.Text = NationalNo;
            FindNow();
        }
        void FindNow()
        {
            //First Load Person to Mini CTRL
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    if (int.TryParse(txtFilterValue.Text, out int PersonID))
                        ctrlPersonCard1.LoadPerson(PersonID);
                    break;
                case "National No":
                    ctrlPersonCard1.LoadPerson(txtFilterValue.Text);
                    break;

                default:
                    MessageBox.Show("Error:Please Select Filter !", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            //Fire Event to pass PersonID to the subscribing Forms
            if (OnPersonSelected != null && FilterEnabled && Person != null)//if Find is enabled
                FireOnPersonSelectedEvent((int)ctrlPersonCard1.Person.PersonID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;//National No
        }

        //(2) Another Event , this form is a subscriber
        //This form will recieve the PersonID back from another form and implement this logic
        void RefreshCTRLWithDataBack(object sender, int PersonID)
        {
            cbFilterBy.SelectedText = "PersonID";
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPerson(PersonID);
        }

        public void FilterFocus()
            => txtFilterValue.Focus();





        bool ValidatetxtFilter()
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                errorProvider1.SetError(txtFilterValue, "This field is required !");
                return false;
            }
            else
                errorProvider1.SetError(txtFilterValue, null);

            return true;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {

            if (!ValidatetxtFilter())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valid !" +
                    "Please put the mouse over the red icon to see the errors."
                    , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm1 = new frmAddEditPerson();
            frm1.DataBack += RefreshCTRLWithDataBack;//Subscribe to the event
            frm1.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm1);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;//not allowed
                SystemSounds.Beep.Play();
            }
        }
        private void txtFilterValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;//Disable Beeb
                btnFind.PerformClick();
            }
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = string.Empty;
            FilterFocus();
        }





        private void InitializeComponent()
        {
            components = new Container();
            ctrlPersonCard1 = new ctrlPersonCard();
            label1 = new Label();
            txtFilterValue = new TextBox();
            cbFilterBy = new ComboBox();
            btnFind = new Button();
            btnAddNew = new Button();
            gbFilter = new GroupBox();
            errorProvider1 = new ErrorProvider(components);
            gbFilter.SuspendLayout();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            ctrlPersonCard1.BackColor = Color.White;
            ctrlPersonCard1.Location = new Point(2, 77);
            ctrlPersonCard1.Margin = new Padding(4, 3, 4, 3);
            ctrlPersonCard1.Name = "ctrlPersonCard1";
            ctrlPersonCard1.Size = new Size(1144, 404);
            ctrlPersonCard1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 29);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 1;
            label1.Text = "Filter By";
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(412, 28);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(238, 23);
            txtFilterValue.TabIndex = 2;
            txtFilterValue.KeyDown += txtFilterValue_KeyDown;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "National No", "Person ID" });
            cbFilterBy.Location = new Point(157, 28);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(232, 23);
            cbFilterBy.TabIndex = 3;
            cbFilterBy.Text = "National No";
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // btnFind
            // 
            btnFind.Image = Properties.Resources.SearchPerson;
            btnFind.Location = new Point(697, 19);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(48, 37);
            btnFind.TabIndex = 4;
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Image = Properties.Resources.AddPerson_32;
            btnAddNew.Location = new Point(754, 19);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(48, 37);
            btnAddNew.TabIndex = 5;
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(btnAddNew);
            gbFilter.Controls.Add(label1);
            gbFilter.Controls.Add(btnFind);
            gbFilter.Controls.Add(cbFilterBy);
            gbFilter.Controls.Add(txtFilterValue);
            gbFilter.Location = new Point(8, 3);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(978, 68);
            gbFilter.TabIndex = 6;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            BackColor = Color.White;
            Controls.Add(gbFilter);
            Controls.Add(ctrlPersonCard1);
            Name = "ctrlPersonCardWithFilter";
            Size = new Size(1146, 481);
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

      
    }
}
