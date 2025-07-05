using BusinessLayer.Core;
using PresentationLayer.Global;
using PresentationLayer.Helpers.BaseUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PresentationLayer.Global.clsUtil;

namespace PresentationLayer.Login
{
    public partial class frmDocumentation : clsBaseForm
    {
        private Object _lockObject = new object();
        List<string> _lstAllClassesData = new List<string>();
        List<string> _lstDescriptionAttributes = new List<string>();
        List<string> _lstMethodsParameters = new List<string>();
        List<string> _lstProberties = new List<string>();
        List<string> _lstStoredProceduresInfo = new List<string>();
        DataTable _dtAllStoredProceduresInfo = new DataTable();
        public frmDocumentation()
        {
            InitializeComponent();
            SetTheme(this);
        }
        private void frmDocumentation_Load(object sender, EventArgs e)
        {
            this.btnAllSPInfo.Click +=
                (sender, e) => SetAllRadioButtonUnchecked();
            LoadClassesMetaDataInLists();
            lblTotalRecords.Text = _lstAllClassesData.Count.ToString();
            rbAll?.PerformClick();
            lbxCode.HorizontalScrollbar = true;
            btnFindSP.Enabled = false;
            txtSPName.Enabled = false;
        }
        void LoadClassesMetaDataInLists()
        {
            List<Type> classes = ListAllCustomClasses();
            Parallel.ForEach(classes, type =>
            {
                string DescriptionAttributes = "";
                string MethodsParameters = string.Join(" , ", GetClassMethodsParameters(type));
                string Proberties = string.Join(" , ", GetClassProberties(type));
                var lstDescriptionAttributes = GetClassDescriptionAttributeData(type);
                if (lstDescriptionAttributes.Count > 0)
                {
                    DescriptionAttributes = string.Join(" , ", lstDescriptionAttributes);
                    lock (_lockObject)
                    {
                        _lstDescriptionAttributes?.Add(DescriptionAttributes);
                    }
                }

                lock (_lockObject)
                {
                    _lstAllClassesData?.Add("DescriptionAttributes: " + DescriptionAttributes + "    " +
                    "MethodsParameters: " + MethodsParameters + "    " +
                   "Proberties: " + Proberties);
                    _lstMethodsParameters?.Add(MethodsParameters);
                    _lstProberties?.Add(Proberties);
                }

            });

        }
        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            lbxCode.DataSource = _lstAllClassesData;
            lblTotalRecords.Text = _lstAllClassesData.Count.ToString();
        }

        private void rbMethods_CheckedChanged(object sender, EventArgs e)
        {
            lbxCode.DataSource = _lstMethodsParameters;
            lblTotalRecords.Text = _lstMethodsParameters.Count.ToString();
        }

        private void rbProberties_CheckedChanged(object sender, EventArgs e)
        {
            lbxCode.DataSource = _lstProberties;
            lblTotalRecords.Text = _lstProberties.Count.ToString();
        }

        private void rbDescriptionAttributes_CheckedChanged(object sender, EventArgs e)
        {
            lbxCode.DataSource = _lstDescriptionAttributes;
            lblTotalRecords.Text = _lstDescriptionAttributes.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadAllStoredProceuresData()
        {
            _dtAllStoredProceduresInfo = clsStoredProceduresInfo.GetAllStoredProceduresInfo();
            _lstStoredProceduresInfo = clsStoredProceduresInfo.ConvertAllSPDataTableToList(_dtAllStoredProceduresInfo);
        }
        void SetRadioButtonUnchecked(RadioButton rb)
             => rb.Checked = false;
        void SetAllRadioButtonUnchecked()
        {
            SetRadioButtonUnchecked(rbAll);
            SetRadioButtonUnchecked(rbMethods);
            SetRadioButtonUnchecked(rbProberties);
            SetRadioButtonUnchecked(rbDescriptionAttributes);
        }
        private void btnAllSPInfo_Click(object sender, EventArgs e)
        {
            if (_dtAllStoredProceduresInfo.Rows.Count == 0)
                LoadAllStoredProceuresData();
            btnFindSP.Enabled = true;
            txtSPName.Enabled = true;
            lblTotalRecords.Text = _dtAllStoredProceduresInfo.Rows.Count.ToString()??"N/A";
            lbxCode.DataSource = _lstStoredProceduresInfo;
            lblTotalRecords.Refresh();
            lbxCode.Refresh();
        }

        private void btnFindSP_Click(object sender, EventArgs e)
        {
            string SPname = txtSPName.Text.Trim();
            if (string.IsNullOrEmpty(SPname))
                return;
            DataTable dt = clsStoredProceduresInfo.GetStoredProcedureInfoByName(SPname);
            List<string> spInfo = clsStoredProceduresInfo.ConvertSingleSPDataTableToList(dt);
            lbxCode.DataSource = spInfo;
            lblTotalRecords.Text = dt?.Rows.Count.ToString()??"N/A";
        }
    }
}
