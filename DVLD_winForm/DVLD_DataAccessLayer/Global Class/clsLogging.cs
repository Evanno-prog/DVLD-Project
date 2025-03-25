using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer.Global_Class
{
    public class clsLogging
    {
        public static void LogExceptionToTheEventLog(string Message)
        {
            // Specify the source name for the event log
            string sourceName = "DVLD";
            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
            // Log an information event
            EventLog.WriteEntry(sourceName, Message,EventLogEntryType.Error);
        }

    }
}

