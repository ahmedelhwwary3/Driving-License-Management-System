using BusinessLayer.Core;
using PresentationLayer.Global;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PresentationLayer.Login
{
    public partial class frmListOperationLogs : clsBaseForm
    {
        Task task;
        public frmListOperationLogs()
        {
            InitializeComponent();
            SetTheme(this);
        }
        string path;

        private DataTable _dtAllUsersLogs = new DataTable();
        private async Task<string> ConvertAllRecordsToTXTFile()
        {
            StringBuilder stBuilder = new StringBuilder();
            int count = 0;

            foreach (DataRow Row in _dtAllUsersLogs.Rows)
            {
                count++;
                clsOperationLog RecordLog = await clsOperationLog.ConvertDataRowToObjectAsync(Row);
                stBuilder.Append($"__________________ Record[{count}] __________________\n");
                stBuilder.Append(RecordLog.ToString() ?? $" Record[{count}] N/A !\n\n");
                stBuilder.Append("________________________________________________\n\n");
            }
            return stBuilder.ToString();
        }

        void RefreshList()
        {
            _dtAllUsersLogs = clsOperationLog.GetAllOperationLogs();
            dgvLogs.DataSource = _dtAllUsersLogs;
            RefreshListCount();

        }
        private void RefreshListCount()
            => lblTotalRecords.Text = dgvLogs.Rows.Count.ToString();
        string GetFilterColumnDBName()
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
        void ResetSaveFileDialog()
        {
            saveFileDialog1.Title = "Save Log File";
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "LogFile";
            saveFileDialog1.InitialDirectory = "C:\\";
        }
        private void frmListOperationLogs_Load(object sender, EventArgs e)
        {
            task = Task.Run(() => _dtAllUsersLogs = clsOperationLog.GetAllOperationLogs());
            SetTitle("Operation Logs");
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            cbAction.Visible = false;
            Task.WaitAll(task);
            dgvLogs.DataSource = _dtAllUsersLogs;
            RefreshListCount();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnDBName();


            if (txtFilterValue.Text.Trim() == "")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                RefreshListCount();
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
            RefreshListCount();

        }
        void CheckTXT_CBVisible()
        {
            txtFilterValue.Visible =
              (cbFilterBy.Text != "None" && cbFilterBy.Text != "Action" && this.dgvLogs.Rows.Count != 0);
            cbAction.Visible = (cbFilterBy.Text == "Action");
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            RefreshList();
            CheckTXT_CBVisible();
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
                clsGlobalData.WindownsEventLog.Log(new Exception($"Error when Loading Log Row from DGV."));
                return;
            }

            if (!(dgvLogs.CurrentRow.Cells[0].Value is int LogID))
            {
                MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog.Log(new Exception($"Error when Parsing LogID from DGV Row."));
                return;
            }
            clsOperationLog Log = clsOperationLog.GetByLogID(LogID);
            if (Log == null)
            {
                MessageBox.Show("Error:Log Record is not found !", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ResetSaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //We overrided the ToString() for Log class
                try
                {
                    path = saveFileDialog1.FileName;
                    File.WriteAllText(path, Log.ToString());
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(3);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:An Unexpected Error happened while downloaing Log !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobalData.WindownsEventLog.Log(ex);
                }

            }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLogs.CurrentRow == null || dgvLogs.Rows.Count == 0)
                return;
        }

        private async void downloadAllRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLogs.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading Log !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobalData.WindownsEventLog.Log(new Exception($"Error when Loading Log Row from DGV."));
                return;
            }
            ResetSaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //We overrided the ToString() for Log class
                try
                {
                    string data = await ConvertAllRecordsToTXTFile();
                    path = saveFileDialog1.FileName;
                    notifyIcon1.Visible = true;
                    File.WriteAllText(path, data);
                    notifyIcon1.ShowBalloonTip(3);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:An Unexpected Error happened while downloaing Log !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsGlobalData.WindownsEventLog.Log(ex);
                }

            }
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Action";
            if (cbAction.Text == "All")
            {
                _dtAllUsersLogs.DefaultView.RowFilter = "";
                RefreshListCount();
                return;

            }
            _dtAllUsersLogs.DefaultView.RowFilter =
                        string.Format("[{0}] = '{1}'", FilterColumn,
                        cbAction.Text);
            RefreshListCount();
        }


        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            try
            {
                if (File.Exists(path))
                    File.Open(path, FileMode.Open);
                else
                    MessageBox.Show("Error:File is not existed !", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsGlobalData.WindownsEventLog.Log(ex);
                MessageBox.Show("Error with openning File !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
