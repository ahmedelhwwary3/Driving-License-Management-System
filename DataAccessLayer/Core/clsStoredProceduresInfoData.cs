using DataAccessLayer.Helpers;
using DataAccessLayer.Infrastructure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Core
{
    public static class clsStoredProceduresInfoData
    {
        
        static clsDBManager DBManager = clsDataAccessSettings.DBManager;
        public static DataTable GetAllStoredProceduresInfo()
            => DBManager?.ExecuteDataTable("sp_GetAllStoredProceduresInfo");
        public static DataTable GetStoredProcedureInfoByName(string Name)
        {
            var Parameters = new HashSet<SqlParameter>();
            Parameters.AddSQLParameter("@Name",Name);
            return DBManager?.ExecuteDataTable("sp_GetStoredProcedureInfoByName",Parameters);
        }
    }
}
