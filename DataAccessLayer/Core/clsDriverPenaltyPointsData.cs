using DataAccessLayer.Helpers;
using DataAccessLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Core
{
    public static class clsDriverPenaltyPointsData
    {
        internal static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetByApplicationTypeID(int ApplicationTypeID)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters?.AddSQLParameter("@ApplicationTypeID", ApplicationTypeID);
            return DBManager?.ExecuteDataTable("sp_GetDriverPenaltyPointsByApplicationTypeID", Parameters);
        }
    }
}
