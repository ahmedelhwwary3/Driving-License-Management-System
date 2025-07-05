using BusinessLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.Helpers.Logger
{
    internal class clsDataBaseLog
    {
        internal static void RegisterLoginData(int? UserID, DateTime date)
        {
            try
            {
                if (!clsUser.RegisterLoginData(UserID.Value, date))
                    throw new Exception("Register User Login Failed .");
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }
        }
    }
}
