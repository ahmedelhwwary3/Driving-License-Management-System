using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsDriverPenaltyPoints
    {
        //No Modify 
        public int PenaltyPointsID { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationType { get; set; }
        public int Value { get; set; }

        public clsDriverPenaltyPoints()
        {
            PenaltyPointsID = default;
            ApplicationTypeID = default;
            ApplicationType = new clsApplicationType();
            Value = default;
        }

        protected clsDriverPenaltyPoints(int PenaltyPointsID, int ApplicationTypeID, int Value)
        {
            this.PenaltyPointsID = PenaltyPointsID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = clsApplicationType.GetByID(ApplicationTypeID);
            this.Value = Value;
        }

        public static clsDriverPenaltyPoints GetByApplicationTypeID(int? ApplicationTypeID)
        {
            if (!ApplicationTypeID.HasValue)
                return null;
            DataTable dt = clsDriverPenaltyPointsData.GetByApplicationTypeID(ApplicationTypeID.Value);
           

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new clsDriverPenaltyPoints(
                PenaltyPointsID: row["PenaltyPointsID"].ToInt32(),
                ApplicationTypeID: row["ApplicationTypeID"].ToInt32(),
                Value: row["Value"].ToInt32()
            );
        }

        public static int GetPenaltyPointsByApplicationTypeID(int ApplicationTypeID)
            => GetByApplicationTypeID(ApplicationTypeID)?.Value ??default;
    }
}
