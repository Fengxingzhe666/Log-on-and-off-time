using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Threading;
namespace Log_On_and_Off_time
{
    public class Program
    {
        private static string logName = "System";
        private static int eventID_on = 7001;
        private static int eventID_off = 7002;
        public static void LogTime_All()
        {
            Sub_Window_01 frm = new Sub_Window_01();
            frm.Show();
            string OutputString = null;
            EventLog eventLog = new EventLog(logName);
            foreach (EventLogEntry entry in eventLog.Entries)
            {
                if (entry.InstanceId == eventID_on)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "开机时间：" + timeCreated+"\n";
                }
                if (entry.InstanceId == eventID_off)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "关机时间：" + timeCreated+"\n";
                }
            }
            eventLog.Close();
            frm.TextBox_01.Text = OutputString;
        }
        public static void LogTime_All_Re()
        {
            Sub_Window_01 frm = new Sub_Window_01();
            frm.Show();
            string OutputString = null;
            EventLog eventLog = new EventLog(logName);
            var sortedEntries = eventLog.Entries.Cast<EventLogEntry>().OrderByDescending(abc => abc.TimeGenerated);
            foreach (EventLogEntry entry in sortedEntries)
            {
                if (entry.InstanceId == eventID_on)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "开机时间：" + timeCreated + "\n";
                }
                if (entry.InstanceId == eventID_off)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "关机时间：" + timeCreated + "\n";
                }
            }
            eventLog.Close();
            frm.TextBox_01.Text = OutputString;
        }
        public static void LogTime_Partial()
        {
            Sub_Window_01 frm = new Sub_Window_01();
            frm.Show();
            string OutputString = null;
            EventLog eventLog = new EventLog(logName);
            var sortedEntries = eventLog.Entries.Cast<EventLogEntry>().OrderByDescending(entry => entry.TimeGenerated);
            int i = 1, j = 1;
            foreach (EventLogEntry entry in sortedEntries) 
            {
                if (entry.InstanceId == eventID_on && i<=10)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "开机时间：" + timeCreated + "\n";
                    i++;
                }
                if (entry.InstanceId == eventID_off &&j<=10)
                {
                    DateTime timeCreated = entry.TimeGenerated;
                    OutputString += "关机时间：" + timeCreated + "\n";
                    j++;
                }
            }
            eventLog.Close();
            frm.TextBox_01.Text = OutputString;
        }
    }
}
