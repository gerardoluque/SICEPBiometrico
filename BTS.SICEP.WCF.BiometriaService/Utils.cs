using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BTS.SICEP.WCF.BiometriaService
{
    public static class Utils
    {
        public static void LogEvent(string texto)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(texto, EventLogEntryType.Error);
            }
        }

        public static void LogEvent(Exception exToLog)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(exToLog.ToString(), EventLogEntryType.Error);
            }
        }
    }
}