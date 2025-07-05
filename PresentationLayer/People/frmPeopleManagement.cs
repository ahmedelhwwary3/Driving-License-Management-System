using BusinessLayer.Core;
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
using static PresentationLayer.Global.clsGlobalData;
using static BusinessLayer.Core.clsUsersPermissions;
using PresentationLayer.Helpers.BaseUI;

namespace PresentationLayer.People
{
    public partial class frmPeopleManagement : clsBaseForm
    {
        int _PageNumber = 1;
        int _RowsPerPage = 10;
        int _TotalCount = 0;
        enum enRanking
        { RowNumber = 1, Rank = 2, DenseRank = 3 }
        enRanking _Rank = enRanking.RowNumber;

        DataTable _dtSubPeopleList = new DataTable();
        DataTable _dtAllPeopleList = new DataTable();
        void LoadSubPeopleList(int PageNumber, int RowsPerPage, out int TotalCount, int Ranking)
        {
            _dtSubPeopleList = clsPerson.GetSubPeopleList(PageNumber, RowsPerPage, out TotalCount, Ranking);
        }
        public frmPeopleManagement()
        {
            InitializeComponent();
            SetTheme(this);
        }
        void RefreshPageNumber()
            => lblPageNumber.Text = _PageNumber.ToString();
        void RefreshSubList()

        {
            LoadSubPeopleList(_PageNumber, _RowsPerPage, out _TotalCount, (int)_Rank);
            dgvPeopleList.DataSource = _dtSubPeopleList;
            RefreshPageNumber();
            _TotalCount = _dtSubPeopleList.Rows.Count;
        }
        void SetTitle()
            => this.Text = "People Management";

        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            LoadSubPeopleList(_PageNumber, _RowsPerPage, out _TotalCount, (int)_Rank);
            RefreshPageNumber();
            SetTitle();
            dgvPeopleList.DataSourceChanged += (sender, e) =>
            {
                if (dgvPeopleList.DataSource == _dtAllPeopleList)
                {
                    btnNext.Enabled = false;
                    btnPrev.Enabled = false;
                    rbDenseRank.Enabled = false;
                    rbRank.Enabled = false;
                    rbRowNumber.Enabled = false;
                    lblPageNumber.Text = "N/A";
                    _TotalCount = _dtAllPeopleList.Rows.Count;
                    RefreshListCount();
                }
                else
                {
                    _TotalCount = _dtSubPeopleList.Rows.Count;
                    RefreshListCount();
                    rbDenseRank.Enabled = true;
                    rbRank.Enabled = true;
                    rbRowNumber.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                    lblPageNumber.Text = _PageNumber.ToString();
                }
            };
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.BorderSize = 0;

            //we added Bsource to trace the List using (events) 
            //because dgv doesn't have ListChangeEvent
            //We do this to make CB is not visible when dgv.Rows.Count==0
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            cbGendor.Visible = false;
            _dtSubPeopleList = _dtSubPeopleList.DefaultView.ToTable(false, "RowNumber", "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "Nationality",
            "Phone", "Email");//Not All columns
            dgvPeopleList.DataSource = _dtSubPeopleList;
            //_bsPeppleList.ResetBindings(false);//Fire Event
            RefreshListCount();
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


        string GetFilterColumnDBName()
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
            string FilterColumn = GetFilterColumnDBName();
            string FilterValue = txtFilterValue.Text.Trim();
            if (FilterColumn == "None")
            {
                _PageNumber = 1;
                _dtSubPeopleList.DefaultView.RowFilter = "";
                dgvPeopleList.DataSource = _dtSubPeopleList;//will refresh subList using event
                _TotalCount = _dtSubPeopleList.Rows.Count;
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                RefreshListCount();
                return;

            }
            if (FilterValue == string.Empty)
            {
                dgvPeopleList.DataSource = _dtSubPeopleList;//will refresh subList using event
                _TotalCount = _dtSubPeopleList.Rows.Count;
                _dtSubPeopleList.DefaultView.RowFilter = "";
                RefreshListCount();
                return;
            }

            if (_dtAllPeopleList.Rows.Count == 0)
                _dtAllPeopleList = clsPerson.GetAllPeopleList();

            dgvPeopleList.DataSource = _dtAllPeopleList;
            _TotalCount = _dtAllPeopleList.Rows.Count;
            if (cbFilterBy.Text == "Person ID")
            {
                _dtAllPeopleList.DefaultView.RowFilter =
                        string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtAllPeopleList.DefaultView.RowFilter =
                  string.Format("[{0}] LIKE '%{1}%'", FilterColumn, FilterValue);
            }
            RefreshListCount();
        }
        private void RefreshListCount()
            => lblTotalRecords.Text = _TotalCount.ToString();
        private void CheckCBTXTVisible()
        {
            txtFilterValue.Visible =
              (cbFilterBy.Text != "None" && cbFilterBy.Text != "Gendor Caption");
            cbGendor.Visible = (cbFilterBy.Text == "Gendor Caption");
        }
        void RefreshDGV()
        {
            _dtSubPeopleList.DefaultView.RowFilter = "";
            RefreshListCount();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "None")
            {
                if (_dtAllPeopleList.Rows.Count == 0)
                    _dtAllPeopleList = clsPerson.GetAllPeopleList();
                dgvPeopleList.DataSource = _dtAllPeopleList;
                _TotalCount = _dtAllPeopleList.Rows.Count;
            }
            else
            {
                _PageNumber = 1;
                dgvPeopleList.DataSource = _dtSubPeopleList;
                _TotalCount = _dtSubPeopleList.Rows.Count;
            }
            RefreshDGV();
            CheckCBTXTVisible();
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                return;
            }
            if (cbGendor.Visible)
                cbGendor.SelectedIndex = cbGendor.FindString("All");
        }
        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "GendorCaption";
            string FilterValue = cbGendor.Text == "Male" ? "Male" : "Female";
            dgvPeopleList.DataSource = _dtAllPeopleList;
            if (cbGendor.Text == "All")
            {
                _dtAllPeopleList.DefaultView.RowFilter = "";
                RefreshListCount();
                return;

            }
            if (_dtAllPeopleList.Rows.Count == 0)
                _dtAllPeopleList = clsPerson.GetAllPeopleList();
            dgvPeopleList.DataSource = _dtAllPeopleList;
            _dtAllPeopleList.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            RefreshListCount();

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

            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading User!", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }

            if (!(dgvPeopleList.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;
            }



            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("View"), frm);
            RefreshSubList();
            RefreshListCount();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            btnAddNewPerson.PerformClick();
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Person !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }
            if (!(dgvPeopleList.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;

            }


            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshSubList();
            RefreshListCount();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("Delete")))
                return;
            if (dgvPeopleList.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Person !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Loading Person Row from DGV."));
                return;
            }

            if (!(dgvPeopleList.CurrentRow.Cells[1].Value is int PersonID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindownsEventLog?.Log(new Exception($"Error when Parsing PersonID from DGV Row."));
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this Person ?",
                "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;
            int LoggedUserID = clsGlobalData.CurrentUser.UserID.Value;
            if (clsPerson.DeletePerson(PersonID, LoggedUserID))
            {
                RefreshSubList();
                RefreshListCount();
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
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            MessageBox.Show("This Method is not implemented", "Stup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckUserAccess(GetPermissions("AddEdit")))
                return;
            MessageBox.Show("This Method is not implemented", "Stup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void bsPeppleList_ListChanged(object sender, ListChangedEventArgs e)
        => CheckCBTXTVisible();

        private void dgvPeopleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPeopleList.DataSource == _dtSubPeopleList && dgvPeopleList.Rows.Count == 11)
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
                return;
            }
            if (dgvPeopleList.DataSource == _dtSubPeopleList && dgvPeopleList.Columns.Count == 12)
            {
                dgvPeopleList.Columns[0].Width = 110;
                dgvPeopleList.Columns[0].HeaderText = "Row Number";

                dgvPeopleList.Columns[1].Width = 110;
                dgvPeopleList.Columns[1].HeaderText = "PersonID";

                dgvPeopleList.Columns[2].Width = 110;
                dgvPeopleList.Columns[2].HeaderText = "National No";

                dgvPeopleList.Columns[3].Width = 110;
                dgvPeopleList.Columns[3].HeaderText = "First Name";

                dgvPeopleList.Columns[4].Width = 110;
                dgvPeopleList.Columns[4].HeaderText = "Second Name";

                dgvPeopleList.Columns[5].Width = 100;
                dgvPeopleList.Columns[5].HeaderText = "Third Name";

                dgvPeopleList.Columns[6].Width = 100;
                dgvPeopleList.Columns[6].HeaderText = "Last Name";

                dgvPeopleList.Columns[7].Width = 100;
                dgvPeopleList.Columns[7].HeaderText = "Gendor";

                dgvPeopleList.Columns[8].Width = 120;
                dgvPeopleList.Columns[8].HeaderText = "Date Of Birth";

                dgvPeopleList.Columns[9].Width = 140;
                dgvPeopleList.Columns[9].HeaderText = "Country Name";

                dgvPeopleList.Columns[10].Width = 150;
                dgvPeopleList.Columns[10].HeaderText = "Phone";

                dgvPeopleList.Columns[11].Width = 200;
                dgvPeopleList.Columns[11].HeaderText = "Email";
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

            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialogIfAuthorized(GetPermissions("AddEdit"), frm);
            RefreshSubList();
            RefreshListCount();
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_dtSubPeopleList.Rows.Count < _RowsPerPage)
                return;
            ++_PageNumber;
            RefreshSubList();
            RefreshListCount();

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_PageNumber == 1)
                return;

            _PageNumber--;
            RefreshSubList();
            RefreshListCount();

        }

        private void rbRowCount_CheckedChanged(object sender, EventArgs e)
        {
            _Rank = enRanking.RowNumber;
            RefreshSubList();
        }

        private void rbRank_CheckedChanged(object sender, EventArgs e)
        {
            _Rank = enRanking.Rank;
            RefreshSubList();
        }

        private void rbDenseRank_CheckedChanged(object sender, EventArgs e)
        {
            _Rank = enRanking.DenseRank;
            RefreshSubList();
        }
    }
}
