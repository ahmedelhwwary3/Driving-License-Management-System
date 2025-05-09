
using System.Diagnostics;
using System.Configuration;

namespace DataAccessLayer
{
    public static class clsDataAccessSettings
    {
        //EventLog works only with (Windows)
        //App.Config must be in the Main Project (exe file)..avoid multiple app.configs
        //Trust Server Certificate is with EF only not ADO
        public static string CN = ConfigurationManager.ConnectionStrings["DVLD1_CN"]?.ConnectionString;
        //First Time must be Administrator when opening the program
        public static void LogError(Exception ex)
        {
            string sourceName = "DVLD1";
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "DVLD1");
            }
            EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
        }
        public static readonly clsDBManager DBManager= new clsDBManager();  


    }
}
