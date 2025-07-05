using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BusinessLayer.Core
{
    public class clsStoredProceduresInfo
    {
        public int? RecordNumber { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string Name { get; set; } = string.Empty;

        public static DataTable GetAllStoredProceduresInfo()
            => clsStoredProceduresInfoData.GetAllStoredProceduresInfo();

        public static DataTable GetStoredProcedureInfoByName(string name)
            => clsStoredProceduresInfoData.GetStoredProcedureInfoByName(name);

        public static List<string> ConvertAllSPDataTableToList(DataTable data)
        {
            List<string> spList = new();

            foreach (DataRow row in data.Rows)
            {
                string lastModifyDate = row["LastModifyDate"]?.ToString() ?? string.Empty;
                string name = row["Name"]?.ToString() ?? string.Empty;

                string record = $"Last Modify Date: {lastModifyDate}   , Name: {name}";

                if (!spList.Contains(record))
                    spList.Add(record);
            }

            return spList;
        }

        public static List<string> ConvertSingleSPDataTableToList(DataTable data)
        {
            List<string> spTextList = new();

            foreach (DataRow row in data.Rows)
            {
                string text = row["Text"]?.ToString() ?? string.Empty;

                if (!spTextList.Contains(text))
                    spTextList.Add(text);
            }

            return spTextList;
        }
    }
}
