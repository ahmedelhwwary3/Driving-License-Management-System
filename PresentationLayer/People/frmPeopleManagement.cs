using BusinessLayer;
using PresentationLayer.Global;
using PresentationLayer.Users;
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
    public partial class frmPeopleManagement : Form
    {

        public frmPeopleManagement()
        {
            InitializeComponent();

        }
        private static DataTable _dtAllPeopleFullData = new DataTable();
        void _RefreshList()
        {
            _dtAllPeopleFullData = clsPerson.GetAllPeopleList();
            dgvPeopleList.DataSource = _dtAllPeopleFullData;
            _RefreshListCount();

        }
        void _SetTitle()
            => this.Text = "People Management";

        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            _SetTitle();
            //we added Bsource to trace the List using (events) 
            //because dgv doesn't have ListChangeEvent
            //We do this to make CB is not visible when dgv.Rows.Count==0
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            cbGendor.Visible = false;
            _dtAllPeopleFullData = clsPerson.GetAllPeopleList();
            _dtAllPeopleFullData = _dtAllPeopleFullData.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "Nationality",
            "Phone", "Email");//Not All columns
            dgvPeopleList.DataSource = _dtAllPeopleFullData;
            //_bsPeppleList.ResetBindings(false);//Fire Event
            _RefreshListCount();
            #region Formatting
            //Check Rows Because if dbSource is null , no Cols will be created
            //but if not null the cols by default (even if no Rows) will be created depending on the object info
            //so we make safe code , or we can use ///bsPeopleList_DataBindingComplete()
            //if (dgvPeopleList.Rows.Count > 0)
            //{
            //    //Format Code ...
            //} 
            #endregion
        }


        private void btnClose_Click(object sender, EventArgs e)
        => this.Close();


        string _GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        return "PersonID";

                    }
                case "National No":
                    {
                        return "NationalNo";

                    }
                case "First Name":
                    {
                        return "FirstName";

                    }
                case "Second Name":
                    {
                        return "SecondName";

                    }
                case "Third Name":
                    {
                        return "ThirdName";

                    }
                case "Last Name":
                    {
                        return "LastName";

                    }

                case "Gendor Caption":
                    {
                        return "GendorCaption";

                    }
                case "Address":
                    {
                        return "Address";


                    }
                case "Phone":
                    {
                        return "Phone";

                    }
                case "Email":
                    {
                        return "Email";

                    }
                case "Nationality":
                    {
                        return "Nationality";

                    }
                default:
                    {
                        return "None";
                    }
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumnDBName();


            if (txtFilterValue.Text.Trim() == "")
            {
                //Disable Filteration, not hiding txtFilter
                _dtAllPeopleFullData.DefaultView.RowFilter = "";
                return;
            }
            if (txtFilterValue.Text.Trim() == string.Empty)
            {
                _dtAllPeopleFullData.DefaultView.RowFilter = "";
                _RefreshListCount();
                return;
            }
            else if (FilterColumn == "None")
            {
                _dtAllPeopleFullData.DefaultView.RowFilter = "";
                //Selcted Index Changed Event will fire and Handle txtFilter Visibie
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                return;

            }


            if (cbFilterBy.Text == "Person ID")
            {
                _dtAllPeopleFullData.DefaultView.RowFilter =
                        string.Format("[{0}] = {1}", FilterColumn,
                         txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllPeopleFullData.DefaultView.RowFilter =
                  string.Format("[{0}] LIKE '%{1}%'", FilterColumn,
                  txtFilterValue.Text.Trim());
            }
            _RefreshListCount();

        }
        private void _RefreshListCount()
            => lblTotalRecords.Text = dgvPeopleList.Rows.Count.ToString();
        private void CheckCBTXTVisible()
        {
            txtFilterValue.Visible =
              (cbFilterBy.Text != "None" && cbFilterBy.Text != "Gendor Caption" && this.dgvPeopleList.Rows.Count != 0);
            cbGendor.Visible = (cbFilterBy.Text == "Gendor Caption");
        }
        void _RefreshDGV()
        {
            _dtAllPeopleFullData.DefaultView.RowFilter = "";
            _RefreshListCount();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshDGV();
            CheckCBTXTVisible();
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                return;
            }
            if(cbGendor.Visible)
                cbGendor.SelectedIndex = cbGendor.FindString("All");
        }
        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "GendorCaption";
            string FilterValue = cbGendor.Text == "Male" ? "Male" : "Female";
            if (cbGendor.Text == "All")
            {
                _dtAllPeopleFullData.DefaultView.RowFilter = "";
                _RefreshListCount();
                return;

            }
            _dtAllPeopleFullData.DefaultView.RowFilter =
                        string.Format("[{0}] = '{1}'", FilterColumn,
                        FilterValue);
            _RefreshListCount();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.ShowPersonCard))
                return;
            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading User!", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }

            if (!(dgvPeopleList.CurrentRow.Cells[0].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;
            }



            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialog();
            _RefreshList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            btnAddNewPerson.PerformClick();
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Person !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }
            if (!(dgvPeopleList.CurrentRow.Cells[0].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;

            }


            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.ShowDialog();
            _RefreshList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Person !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }

            if (!(dgvPeopleList.CurrentRow.Cells[0].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this Person ?",
                "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;
            int LoggedUserID = clsGlobal.CurrentUser.UserID.Value;
            if (clsPerson.DeletePerson(PersonID, LoggedUserID))
            {
                _RefreshList();
                MessageBox.Show("Person was deleted successfully",
                    "Delete succeeded", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error:Person delete Failed as he is linked with application in system",
                        "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }





        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            MessageBox.Show("This Method is not implemented", "Stup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            MessageBox.Show("This Method is not implemented", "Stup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void bsPeppleList_ListChanged(object sender, ListChangedEventArgs e)
        => CheckCBTXTVisible();

        private void dgvPeopleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPeopleList.Columns.Count == 11)
            {
                dgvPeopleList.Columns[0].Width = 110;
                dgvPeopleList.Columns[0].HeaderText = "PersonID";

                dgvPeopleList.Columns[1].Width = 110;
                dgvPeopleList.Columns[1].HeaderText = "National No";

                dgvPeopleList.Columns[2].Width = 110;
                dgvPeopleList.Columns[2].HeaderText = "First Name";

                dgvPeopleList.Columns[3].Width = 110;
                dgvPeopleList.Columns[3].HeaderText = "Second Name";

                dgvPeopleList.Columns[4].Width = 100;
                dgvPeopleList.Columns[4].HeaderText = "Third Name";

                dgvPeopleList.Columns[5].Width = 100;
                dgvPeopleList.Columns[5].HeaderText = "Last Name";

                dgvPeopleList.Columns[6].Width = 100;
                dgvPeopleList.Columns[6].HeaderText = "Gendor";

                dgvPeopleList.Columns[7].Width = 120;
                dgvPeopleList.Columns[7].HeaderText = "Date Of Birth";

                dgvPeopleList.Columns[8].Width = 140;
                dgvPeopleList.Columns[8].HeaderText = "Country Name";

                dgvPeopleList.Columns[9].Width = 150;
                dgvPeopleList.Columns[9].HeaderText = "Phone";

                dgvPeopleList.Columns[10].Width = 200;
                dgvPeopleList.Columns[10].HeaderText = "Email";
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPeopleList.CurrentRow == null || dgvPeopleList.Rows.Count == 0)
                e.Cancel = true;
        }



        private void btnClosing_Click(object sender, EventArgs e)
            => this.Close();

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckUserAccess(clsGlobal.enScreensPermission.AddEditPerson))
                return;
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshList();
        }

        
    }
}
