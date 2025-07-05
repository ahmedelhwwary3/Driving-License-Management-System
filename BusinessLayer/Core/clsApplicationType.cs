using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BusinessLayer.Helpers;
using DataAccessLayer.Core;

namespace BusinessLayer.Core
{
    public class clsApplicationType
    {
        protected enum enMode { AddNew, Update };
        protected enMode Mode;

        public int? ApplicationTypeID { get; set; }

        [MaxLength(50)]
        public string ApplicationTypeTitle { get; set; }

        public decimal ApplicationFees { get; set; }
        public int LoggedUserID { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = null;
            ApplicationTypeTitle = string.Empty;
            ApplicationFees = 0;
            LoggedUserID = default;

            Mode = enMode.AddNew;
        }

        protected clsApplicationType(int? ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            LoggedUserID = default;

            Mode = enMode.Update;
        }

        private bool Add()
        {
            if (!string.IsNullOrWhiteSpace(ApplicationTypeTitle))
            {
                ApplicationTypeID = clsApplicationTypeData.AddNewApplicationType(
                    ApplicationTypeTitle,
                    ApplicationFees,
                    LoggedUserID
                );

                return ApplicationTypeID.HasValue;
            }
            return false;
        }

        private bool Update()
        {
            if (ApplicationTypeID.HasValue && !string.IsNullOrWhiteSpace(ApplicationTypeTitle))
            {
                return clsApplicationTypeData.UpdateApplicationTypeByID(
                    ApplicationTypeID.Value,
                    ApplicationTypeTitle,
                    ApplicationFees,
                    LoggedUserID
                );
            }

            return false;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return Update();

                default:
                    return false;
            }
        }

        public static bool IsExist(int ApplicationTypeID)
            => clsApplicationTypeData.IsExistedByID(ApplicationTypeID);

        public static clsApplicationType GetByID(int? ApplicationTypeID)
        {
            DataTable dt = clsApplicationTypeData.GetByID(ApplicationTypeID.Value);

            if (!ApplicationTypeID.HasValue)
                return null;
            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsApplicationType(
                ApplicationTypeID: row["ApplicationTypeID"].ToInt32(),
                ApplicationFees: row["ApplicationFees"].ToDecimal(),
                ApplicationTypeTitle: row["ApplicationTypeTitle"]?.ToString() ?? string.Empty
            );
        }

        public static decimal GetApplicationTypeFees(int ApplicationTypeID)
            => GetByID(ApplicationTypeID)?.ApplicationFees ??0;

        public static DataTable GetAllApplicationTypesList()
            => clsApplicationTypeData.GetAllApplicationTypesList();
    }
}
