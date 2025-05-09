using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static BusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;
 

namespace BusinessLayer
{
    public class clsApplicationType
    {
        protected enum enMode { AddNew, Update };
        protected enMode Mode;
        public int? ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }
        public int? LoggedUserID { get; set; }
        public clsApplicationType()
        {
            this.LoggedUserID = null;
            this.ApplicationTypeID = null;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationFees = 0;

            Mode = enMode.AddNew;
        }
        protected clsApplicationType(int? ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            this.LoggedUserID = null;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationTypeFees;

            Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {
            if (!string.IsNullOrEmpty(this.ApplicationTypeTitle)&&this.LoggedUserID.HasValue)
            {
                this.ApplicationTypeID = clsApplicationTypeData.
                    AddNewApplicationType(this.ApplicationTypeTitle, 
                    this.ApplicationFees,this.LoggedUserID.Value);
                return this.ApplicationTypeID != null;
            }
            return false;
        }

        private bool _UpdateApplicationType()
        {
            if (this.ApplicationTypeID.HasValue &&this.LoggedUserID.HasValue&& !string.IsNullOrEmpty(this.ApplicationTypeTitle))
            {
                return clsApplicationTypeData.UpdateApplicationTypeByID(
                    this.ApplicationTypeID.Value,
                    this.ApplicationTypeTitle,
                    this.ApplicationFees,
                    this.LoggedUserID.Value
                );
            }
            return false;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplicationType())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplicationType();
                    }
                default:
                    break;
            }
            return false;
        }


        public static bool IsExist(int? ApplicationTypeID)
            => ApplicationTypeID.HasValue && clsApplicationTypeData.IsExistedByID(ApplicationTypeID.Value);

        public static clsApplicationType GetByID(int? ApplicationTypeID)
        {
            if (!ApplicationTypeID.HasValue) return null;

            DataTable dt = clsApplicationTypeData.GetByID(ApplicationTypeID.Value);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsApplicationType(
                ApplicationTypeID: row["ApplicationTypeID"].ToNullableInt32(),
                ApplicationTypeFees: row["ApplicationFees"] .ToDecimal(),
                ApplicationTypeTitle: row["ApplicationTypeTitle"].ToString()??""
            );
        }

        public static decimal GetApplicationTypeFees(int? ApplicationTypeID)
            => ApplicationTypeID.HasValue ? GetByID(ApplicationTypeID.Value)?.ApplicationFees??0 : 0;

        public static DataTable GetAllApplicationTypesList()
            => clsApplicationTypeData.GetAllApplicationTypesList();

    }
}
