using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
namespace PresentationLayer.Global
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser=new clsUser();
        [Flags]
        public enum enScreensPermission
        {
            //Admin
            AddEditUser = 1,                    // 2^0
            ChangePassword = 2,                 // 2^1
            ShowUserInfo = 4,                   // 2^2
            UserManagement = 8,                 // 2^3
            //_________________________________________                   
            ListTestAppointments = 16,          // 2^4
            ScheduleTest = 32,                  // 2^5
            TakeScheduledTest = 64,             // 2^6
            AddEditPerson = 128,                // 2^7
            FindPerson = 256,                   // 2^8
            PeopleManagement = 512,             // 2^9
            ShowPersonCard = 1024,              // 2^10
            DetainLicense = 2048,               // 2^11
            ShowInternationalLicenseInfo = 4096,// 2^12
            ShowLicenseHistory = 8192,          // 2^13
            ListDrivers = 16384,                // 2^14
            EditApplicationType = 32768,        // 2^15
            ListApplicationTypes = 65536,       // 2^16
            IssueInternationalLicense = 131072, // 2^17
            ListIntenationalLicenses = 262144,  // 2^18
            AddEditLocalApplication = 524288,   // 2^19
            ListLocalApplications = 1048576,    // 2^20
            ShowLocalApplicationInfo = 2097152, // 2^21
            ListDetainedLicenses = 4194304,     // 2^22
            ReleaseDetainedLicense = 8388608,   // 2^23
            RenewLocalLicense = 16777216,       // 2^24
            ReplaceLicense = 33554432,          // 2^25
            EditTestType = 67108864,            // 2^26
            ListTestTypes = 134217728,          // 2^27
            IssueDrivingLicenesForFirstTime = 268435456, // 2^28
            ShowLicenseInfo = 536870912 ,       // 2^29
            //_________________________________________     
            AllScreens = 1073741824             // 2^30
        }
        public static Boolean CheckUserAccess( enScreensPermission ScreenPermission)
        {
            if (((enScreensPermission)CurrentUser.PermissionsData.Permissions.Value == enScreensPermission.AllScreens)
                
                
                || (((enScreensPermission)CurrentUser.PermissionsData.Permissions.Value & ScreenPermission) == ScreenPermission))
                return true;
            ShowAccessDeniedScreen();
            return false;
        }
        public static void ShowAccessDeniedScreen()
        {
            MessageBox.Show("Access is Denied !\nPlease Contact Your Admin.","Error",
                MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        public static void GetStoredCredentialsFromFile(ref string UserName,ref string Password)
        {
            string FilePath = @"F:\Programming\C#\Course19 (Full Project)\Credentials.txt";
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            using (StreamReader sr=new StreamReader(FilePath))
            {
                UserName= sr.ReadLine();
                Password= sr.ReadLine();
                sr.Close();
            }         
        }
        public static bool GetStoredCredentialsFromRegistry(ref string UserName, ref string Password)
        {
            //Registry is small DB in windows
            string Path = @"HKEY_CURRENT_USER\Software\MyCredentials";
            try
            {
                string LoggedUserName = "LoggedUserName";
                string LoggedPassword = "LoggedPassword";
                UserName = Registry.GetValue(Path,LoggedUserName,"")as string;
                Password = Registry.GetValue(Path, LoggedPassword, "") as string;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool RememberCredentialsTotxtFile(string UserName, string Password)
        {
            string FilePath = @"F:\Programming\C#\Course19 (Full Project)\Credentials.txt";
            if (!File.Exists(FilePath))
            {
                return false;
            }
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                sw.WriteLine(UserName);
                sw.WriteLine(Password);
                sw.Close();
            }
            return  true;
        }
        public static bool RememberCredentialsToRegistry(string UserName="", string Password = "")
        {
            string Path = @"HKEY_CURRENT_USER\Software\MyCredentials";
            try
            {
                string LoggedPassword = "LoggedPassword";
                string LoggedUserName = "LoggedUserName";
                Registry.SetValue(Path,LoggedUserName, UserName, RegistryValueKind.String);
                Registry.SetValue(Path,LoggedPassword, Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void LogError(Exception ex)
        {
            string sourceName = "DVLD1";
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
            EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
        }

        public static void RegisterLoginData(int? UserID,DateTime date)
        {
            try
            {
                if(!clsUser.RegisterLoginData(UserID.Value, date))
                    throw new Exception("Register User Login Failed .");
            }
            catch(Exception ex)
            {
                LogError(ex);
            }
        }
        


    }
}
