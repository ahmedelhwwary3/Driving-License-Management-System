using BusinessLayer.Helpers;
using DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Core
{
    [Description("There are many CEOs but only 1 Admin in the system")]
    public class clsUsersHierarcky
    {

        public int? HierarchyID { get; set; }
        public string Hierarchy { get; set; }

        
        public static DataTable GetAllUsersHierarckyList()
            => clsUsersHierarckyData.GetAllUsersHierarckyList();
        public static int? GetHierarchyIDByName(string Hierarchy)
            => clsUsersHierarckyData.GetHierarchyIDByName(Hierarchy);
        public static string GetHierarchyNameByID(int HierarchyID)
            => clsUsersHierarckyData.GetHierarchyNameByID(HierarchyID);

     
   
        public static bool HasManagerHigherHierarcky(int ManagerID,int HierarchyID)
            => clsUsersHierarckyData.HasManagerHigherHierarcky(ManagerID,HierarchyID);
    }
}
