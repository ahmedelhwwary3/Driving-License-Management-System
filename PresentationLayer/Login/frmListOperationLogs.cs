using BusinessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PresentationLayer.Login
{
    public partial class frmListOperationLogs : Form
    {
        public frmListOperationLogs()
        {
            InitializeComponent();
        }

        private DataTable _dtAllUsersLogs = new DataTable();
        private string _ConvertAllRecordsToTXTFile()
        {
            StringBuilder stBuilder = new StringBuilder();
            int count = 0;

            foreach (DataRow Row in _dtAllUsersLogs.Rows)
            {
                count++;
                clsOperationLog RecordLog = clsOperationLog.ConvertDataRowToObject(Row);
                stBuilder.Append($"__________________ Record[{count}] __________________\n");
                stBuilder.Append(RecordLog.ToString() ?? $" Record[{count}] N/A !\n\n");
                stBuilder.Append("________________________________________________\n\n");
            }
            return stBuilder.ToString();
        }

        void _RefreshList()
        {
            _dtAllUsersLogs = clsOperationLog.GetAllOperationLogs();
            dgvLogs.DataSource = _dtAllUsersLogs;
            _RefreshListCount();

        }
        private void _RefreshListCount()
            => lblTotalRecords.Text = dgvLogs.Rows.Count.ToString();
        string _GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "Log ID":
                    {
                        return "LogID";

                    }
                case "Logged User ID":
                    {
                        return "LoggedUserID";

                    }
                case "Action":
                    {
                        return "Action";

                    }
                case "Table Name":
                    {
                        return "TableName";

                    }
                default:
                    {
                        return "None";
                    }
            }
        }
        private void dgvLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvLogs.Columns.Count == 7)
            {
                dgvLogs.Columns[0].Width = 110;
                dgvLogs.Columns[0].HeaderText = "Log ID";

                dgvLogs.Columns[1].Width = 110;
                dgvLogs.Columns[1].HeaderText = "Logged User ID";

                dgvLogs.Columns[2].Width = 180;
                dgvLogs.Columns[2].HeaderText = "Action";

                dgvLogs.Columns[3].Width = 170;
                dgvLogs.Columns[3].HeaderText = "Create Date";

                dgvLogs.Columns[4].Width = 110;
                dgvLogs.Columns[4].HeaderText = "Table Name";
                dgvLogs.Columns[5].Visible = false;
                dgvLogs.Columns[6].Visible = false;
            }
        }
        void _ResetSFD()
        {
            saveFileDialog1.Title = "Save Log File";
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "LogFile";
            saveFileDialog1.InitialDirectory = "C:\\";
        }
        private void frmListOperationLogs_Load(object sender, EventArgs e)
        {
            this.Text = "Operation Logs";
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            cbAction.Visible = false;
            _dtAllUsersLogs = clsOperationLog.GetAllOperationLogs();
            dgvLogs.DataSource = _dtAllUsersLogs;

            _RefreshListCount();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumnDBName();


            if (txtFilterValue.Text.Trim() == "")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                _RefreshListCount();
                return;
            }
            if (FilterColumn == "None")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                return;
            }
            if (FilterColumn == "LogID" || FilterColumn == "LoggedUserID")
            {
                _dtAllUsersLogs.DefaultView.RowFilter =
                                    string.Format("[{0}] = {1}", FilterColumn,
                                     txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllUsersLogs.DefaultView.RowFilter =
                                string.Format("[{0}] like '%{1}%'", FilterColumn,
                                 txtFilterValue.Text.Trim());
            }
            _RefreshListCount();

        }
        void _CheckTXT_CBVisible()
        {
            txtFilterValue.Visible =
              (cbFilterBy.Text != "None" && cbFilterBy.Text != "Action" && this.dgvLogs.Rows.Count != 0);
            cbAction.Visible = (cbFilterBy.Text == "Action");
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            _RefreshList();
            _CheckTXT_CBVisible();
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            if (cbAction.Visible)
                cbAction.SelectedIndex = cbAction.FindString("All");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }
            if (cbFilterBy.Text == "Log ID" || cbFilterBy.Text == "Logged User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else e.Handled = false;
        }

        private void downloadAllRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLogs.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Log !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Log Row from DGV."));
                return;
            }

            if (!(dgvLogs.CurrentRow.Cells[0].Value is int LogID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Parsing LogID from DGV Row."));
                return;
            }
            clsOperationLog Log = clsOperationLog.GetByLogID(LogID);
            if (Log == null)
            {
                MessageBox.Show("Error:Log Record is not found !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ResetSFD();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //We overrided the ToString() for Log class
                try
                {
                    string path = saveFileDialog1.FileName;
                    File.WriteAllText(path, Log.ToString());
                    MessageBox.Show("File was saved successfully.", "Confirm save",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:An Unexpected Error happened while downloaing Log !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobal.LogError(ex);
                }

            }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLogs.CurrentRow == null || dgvLogs.Rows.Count == 0)
                return;
        }

        private void downloadAllRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLogs.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Log !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogError(new Exception($"Error when Loading Log Row from DGV."));
                return;
            }
            _ResetSFD();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //We overrided the ToString() for Log class
                try
                {
                    string path = saveFileDialog1.FileName;
                    File.WriteAllText(path, _ConvertAllRecordsToTXTFile());
                    MessageBox.Show("File was saved successfully.", "Confirm save",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:An Unexpected Error happened while downloaing Log !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobal.LogError(ex);
                }

            }
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Action";
            if (cbAction.Text == "All")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                _RefreshListCount();
                return;

            }
            _dtAllUsersLogs.DefaultView.RowFilter =
                        string.Format("[{0}] = '{1}'", FilterColumn,
                        cbAction.Text);
            _RefreshListCount();
        }
    }
}
