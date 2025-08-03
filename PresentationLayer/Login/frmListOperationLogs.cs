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
using static PresentationLayer.Global.clsGlobalData;
using static PresentationLayer.Global.clsUtil;
using System.Net;

namespace PresentationLayer.AddLogin
{
    public partial class frmListOperationAddLogs : clsBaseForm
    {
        Task task;
        List<clsOperationLog> _lstOperationAddLogs = new List<clsOperationLog>();
        public enum enDownloadStyle
        { Text, Word, Excel }
        public enum enDownloadQuantity
        { SingleRow, FullRows }
        public frmListOperationAddLogs()
        {
            InitializeComponent();
 
        }
        string path;

        private DataTable _dtAllUsersAddLogs = new DataTable();
        private async Task<string> ConvertAllRecordsToTXTFile()
        {
            StringBuilder stBuilder = new StringBuilder();
            int count = 0;

            foreach (DataRow Row in _dtAllUsersAddLogs.Rows)
            {
                count++;
                clsOperationLog RecordAddLog = await clsOperationLog.ConvertDataRowToObjectAsync(Row);
                stBuilder.Append($"__________________ Record[{count}] __________________\n");
                stBuilder.Append(RecordAddLog.ToString() ?? $" Record[{count}] N/A !\n\n");
                stBuilder.Append("________________________________________________\n\n");
            }
            return stBuilder.ToString();
        }
        private async void ConvertAllRecordsToOperationAddLogObjects()
        {
            foreach (DataRow Row in _dtAllUsersAddLogs.Rows)
            {
                clsOperationLog RecordAddLog = await clsOperationLog.ConvertDataRowToObjectAsync(Row);
                _lstOperationAddLogs?.Add(RecordAddLog);
            }
        }

        void RefreshList()
        {
            _dtAllUsersAddLogs = clsOperationLog.GetAllOperationLogs();
            dgvAddLogs.DataSource = _dtAllUsersAddLogs;
            RefreshListCount();

        }
        private void RefreshListCount()
            => lblTotalRecords.Text = dgvAddLogs.Rows.Count.ToString();
        string GetFilterColumnDBName()
        {
            switch (cbFilterBy.Text)
            {
                case "AddLog ID":
                    {
                        return "AddLogID";

                    }
                case "AddLogged User ID":
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
        private void dgvAddLogs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAddLogs.Columns.Count == 7)
            {
                dgvAddLogs.Columns[0].Width = 110;
                dgvAddLogs.Columns[0].HeaderText = "AddLog ID";

                dgvAddLogs.Columns[1].Width = 110;
                dgvAddLogs.Columns[1].HeaderText = "AddLogged User ID";

                dgvAddLogs.Columns[2].Width = 180;
                dgvAddLogs.Columns[2].HeaderText = "Action";

                dgvAddLogs.Columns[3].Width = 170;
                dgvAddLogs.Columns[3].HeaderText = "Create Date";

                dgvAddLogs.Columns[4].Width = 110;
                dgvAddLogs.Columns[4].HeaderText = "Table Name";
                dgvAddLogs.Columns[5].Visible = false;
                dgvAddLogs.Columns[6].Visible = false;
            }
        }
        void ResetSaveFileDialog(enDownloadStyle style)
        {
            saveFileDialog1.Title = "Save AddLog File";
            saveFileDialog1.FileName = "AddLogFile";
            saveFileDialog1.InitialDirectory = "F:\\";
            saveFileDialog1.Filter =
                "Text Files (*.txt)|*.txt|" +
                "Word Documents (*.docx)|*.docx|" +
                "Excel Files (*.xlsx)|*.xlsx";
            switch (style)
            {
                case enDownloadStyle.Text:
                default:
                    {
                        saveFileDialog1.DefaultExt = "txt";
                        saveFileDialog1.FilterIndex = 1;
                        break;
                    }
                case enDownloadStyle.Word:
                    {
                        saveFileDialog1.DefaultExt = "docx";
                        saveFileDialog1.FilterIndex = 2;
                        break;
                    }
                case enDownloadStyle.Excel:
                    {
                        saveFileDialog1.DefaultExt = "xlsx";
                        saveFileDialog1.FilterIndex = 3;
                        break;
                    }
            }
  
             
        }
        private void frmListOperationAddLogs_Load(object sender, EventArgs e)
        {
            task = Task.Run(() => _dtAllUsersAddLogs = clsOperationLog.GetAllOperationLogs());
            SetTitle("Operation AddLogs");
            cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
            cbAction.Visible = false;
            Task.WaitAll(task);
            dgvAddLogs.DataSource = _dtAllUsersAddLogs;
            RefreshListCount();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = GetFilterColumnDBName();


            if (txtFilterValue.Text.Trim() == "")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter = "";
                RefreshListCount();
                return;
            }
            if (FilterColumn == "None")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter = "";
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("None");
                return;
            }
            if (FilterColumn == "AddLogID" || FilterColumn == "LoggedUserID")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter =
                                    string.Format("[{0}] = {1}", FilterColumn,
                                     txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter =
                                string.Format("[{0}] like '%{1}%'", FilterColumn,
                                 txtFilterValue.Text.Trim());
            }
            RefreshListCount();

        }
        void CheckTXT_CBVisible()
        {
            txtFilterValue.Visible =
              (cbFilterBy.Text != "None" && cbFilterBy.Text != "Action" && this.dgvAddLogs.Rows.Count != 0);
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
            if (cbFilterBy.Text == "AddLog ID" || cbFilterBy.Text == "AddLogged User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else e.Handled = false;
        }



        async void Download(enDownloadStyle style, enDownloadQuantity quantity)
        {
            clsOperationLog AddLog = new clsOperationLog();
            if (dgvAddLogs.CurrentRow == null)
            {
                MessageBox.Show("Error:An Unexpected Error happened while loading AddLog !", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                logExceptions?.AddLog(new Exception($"Error when Loading AddLog Row from DGV."));
                return;
            }

            if (quantity == enDownloadQuantity.SingleRow)
            {
                if (!(dgvAddLogs.CurrentRow.Cells[0].Value is int AddLogID))
                {
                    MessageBox.Show("Error:An Unexpected Error happened !", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logExceptions?.AddLog(new Exception($"Error when Parsing AddLogID from DGV Row."));
                    return;
                }
                AddLog = clsOperationLog.GetByLogID(AddLogID);
                if (AddLog == null)
                {
                    MessageBox.Show("Error:AddLog Record is not found !", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ResetSaveFileDialog(style);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    path = saveFileDialog1.FileName;
                    string data = "";
                    if (quantity == enDownloadQuantity.SingleRow)
                        data = AddLog.ToString();//I overrided ToString()
                    else
                        data = await ConvertAllRecordsToTXTFile();

                    switch (style)
                    {
                        case enDownloadStyle.Text:
                        default:
                            {
                                File.WriteAllText(path, data);
                                break;
                            }
                        case enDownloadStyle.Word:
                            {
                                SaveDataAsWordFile(data,path);
                                break;
                            }
                        case enDownloadStyle.Excel:
                            {
                                if(quantity == enDownloadQuantity.SingleRow)
                                {
                                    SaveDataAsExcelSheet(AddLog, path);
                                }
                                else
                                {
                                    ConvertAllRecordsToOperationAddLogObjects();
                                    SaveDataAsExcelSheet(_lstOperationAddLogs, path);
                                }
                                break;
                            }

                    }
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(3);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:An Unexpected Error happened while downloaing AddLog !"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logExceptions?.AddLog(ex);
                }

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAddLogs.CurrentRow == null || dgvAddLogs.Rows.Count == 0)
                return;
        }


        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Action";
            if (cbAction.Text == "All")
            {
                _dtAllUsersAddLogs.DefaultView.RowFilter = "";
                RefreshListCount();
                return;

            }
            _dtAllUsersAddLogs.DefaultView.RowFilter =
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
                logExceptions?.AddLog(ex);
                MessageBox.Show("Error with openning File !", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDownloadFull_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Text, quantity: enDownloadQuantity.FullRows);
        }

        private void excelDownloadFull_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Excel, quantity: enDownloadQuantity.FullRows);
        }

        private void wordDownloadFull_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Word, quantity: enDownloadQuantity.FullRows);
        }

        private void textDownloadSingle_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Text, quantity: enDownloadQuantity.SingleRow);
        }

        private void excelDownloadSingle_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Excel, quantity: enDownloadQuantity.SingleRow);
        }

        private void wordDownloadSingle_Click(object sender, EventArgs e)
        {
            Download(style: enDownloadStyle.Word, quantity: enDownloadQuantity.SingleRow);
        }
    }
}
