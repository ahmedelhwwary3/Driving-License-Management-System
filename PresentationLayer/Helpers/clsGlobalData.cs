using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

using BusinessLayer.Core;
using static PresentationLayer.Helpers.AddLogs.Exceptions.AddLogTypes.clsEventLog;

using PresentationLayer.Helpers.Colors;
using PresentationLayer.Helpers.AddLogger;
using PresentationLayer.Helpers.AddLogger.Exceptions;
using PresentationLayer.Helpers.AddLogs.Theme_Mode;
using PresentationLayer.Helpers.AddLogs.Credentials;
using PresentationLayer.Helpers.AddLogs.Credentials.AddLogTypes;
using PresentationLayer.Helpers.AddLogs.Exceptions.AddLogTypes;
using PresentationLayer.Helpers.AddLogs.AddLogin_Data;


namespace PresentationLayer.Global
{
    internal static class clsGlobalData
    {
        internal static clsUser CurrentUser;

        internal static Object lockObject;


      
        internal static clsExceptionLogManager logExceptions;
        internal static clsCredentialsLogManager logUsersCredentials;
        internal static clsThemeLogManager logThemeModes;
        internal static clsLoginLogManager logUsersLogins;



        public enum enThemeMode
        { Default, Dark, Admin }
        internal static enThemeMode Theme = enThemeMode.Default;
        internal static clsThemeManager CurrentTheme;
        /// <summary>
        /// To Control The Initialization Order
        /// </summary>
        static clsGlobalData()
        {
            try
            {
                logExceptions = new clsExceptionLogManager(clsEventLog.AddLogStatic);
                logUsersCredentials = new clsCredentialsLogManager(new clsRegCredentialsLog());
                logThemeModes = new clsThemeLogManager(new clsRegThemeLog());
                logUsersLogins = new clsLoginLogManager(new clsLoginDBLog());


                CurrentTheme = new clsThemeManager();
                CurrentUser = new clsUser();
                lockObject = new object();
            }
            catch (Exception ex)
            {
                AddLogStatic(ex);
            }
        }
    }


}
