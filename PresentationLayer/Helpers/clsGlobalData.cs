using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Runtime.Serialization.Json;
using BusinessLayer.Core;
using System.ComponentModel.DataAnnotations;
using PresentationLayer.Login;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection;
using static BusinessLayer.Core.clsUsersPermissions;
using System.Windows.Forms;
using PresentationLayer.Helpers.Logs;
using static PresentationLayer.Helpers.Logger.clsEventLogger;
using static PresentationLayer.Global.clsUtil;
using PresentationLayer.Helpers.Colors;

namespace PresentationLayer.Global
{
    public static class clsGlobalData
    {
        internal static clsUser CurrentUser=new clsUser();
        internal static clsLoggerManager WindownsEventLog = new clsLoggerManager(LogErrorInEventLog);
        internal static Object GlobalLockObject=new object();
        public enum enThemeMode
        { Default, Dark, Admin  }
        public static enThemeMode Theme =enThemeMode.Default;
        public static clsThemeManager CurrentTheme=new clsThemeManager();
       
       
       
     
    }
}
