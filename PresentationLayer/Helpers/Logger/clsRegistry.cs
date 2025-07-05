using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;

namespace PresentationLayer.Helpers.Logger
{
    internal class clsRegistry
    {


        internal static bool RememberCredentialsToRegistry((string UserNameValue, string PasswordValue) Credentials)
        {
#if DEBUG
            if (!Environment.Is64BitProcess)
                return false;
#endif
            string KeyName = @"Software\MyCredentials";
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey subKey = baseKey.OpenSubKey(KeyName, writable: true))
                {
                    var Values = (UserValueName: "LoggedUserName", PassValueName: "LoggedPassword");
                    subKey.SetValue(Values.UserValueName, Credentials.UserNameValue, RegistryValueKind.String);
                    subKey.SetValue(Values.PassValueName, Credentials.PasswordValue, RegistryValueKind.String);
                }
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                WindownsEventLog?.Log(ex);
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }
            return false;
        }
        internal static bool GetUserThemeFromRegistry(out enThemeMode mode)
        {
            string KeyName = @"Software\MyTheme";
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey subKey = baseKey.OpenSubKey(KeyName, writable: true))
                {
                    mode = (enThemeMode)Convert.ToInt32(subKey.GetValue("Theme"));
                }
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                WindownsEventLog?.Log(ex);
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }
            mode = enThemeMode.Default;
            return false;
        }
        internal static bool SetUserThemeInRegistry(int mode)
        {
            string KeyName = @"Software\MyTheme";
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey subKey = baseKey.OpenSubKey(KeyName, writable: true))
                {
                    subKey.SetValue("Theme", mode);
                }
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                WindownsEventLog?.Log(ex);
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }
            return false;
        }

        internal static bool GetStoredCredentialsFromRegistry(ref string UserName, ref string Password)
        {
#if DEBUG
            if (!Environment.Is64BitProcess)
                return false;
#endif
            string KeyName = @"Software\MyCredentials";
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (RegistryKey subKey = baseKey.OpenSubKey(KeyName, writable: false))
                {
                    const string UserValueName = "LoggedUserName";
                    const string PasswordValueName = "LoggedPassword";
                    UserName = subKey.GetValue(UserValueName) as string;
                    Password = subKey.GetValue(PasswordValueName) as string;
                }

                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                WindownsEventLog?.Log(ex);
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }
            return false;
        }



    }
}
