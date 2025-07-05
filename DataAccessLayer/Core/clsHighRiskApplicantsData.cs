using DataAccessLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Core
{
    public static class clsHighRiskApplicantsData
    {
        static readonly clsDBManager DBManager = clsDataAccessSettings.DBManager;

        public static DataTable GetAllHighRiskApplicantsList()
            => DBManager?.ExecuteDataTable("sp_GetAllHighRiskApplicants");
    }
}
