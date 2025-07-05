using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PresentationLayer.Global.clsGlobalData;
namespace PresentationLayer.Helpers.Logger
{
    internal class clsEventLogger
    {

        internal static void LogErrorInEventLog(Exception ex)
        {
            string sourceName = "MyDVLD1";
            if (!EventLog.SourceExists(sourceName))
                EventLog.CreateEventSource(sourceName, "Application");

            EventLog.WriteEntry(sourceName, $"{ex.Message}", EventLogEntryType.Error);
        }


        [Conditional("TestEventLog")]
        internal static void TestEventLog()
        {
            try
            {
                if (EventLog.Exists("DVLD1"))
                    EventLog.Delete("DVLD1");
                if (EventLog.SourceExists("DVLD1"))
                    EventLog.DeleteEventSource("DVLD1");
                throw new Exception("Hi i am exception..........");
            }
            catch (Exception ex)
            {
                WindownsEventLog?.Log(ex);
            }

        }











    }
}
