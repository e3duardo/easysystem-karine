using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Library.Classes
{
    public class Logger
    {

        private Logger()
        {
        }

        static public void Error(Exception ex)
        {
            Stream fs = null;
            Stream fs1 = null;
            try
            {
                if (!(System.IO.Directory.Exists(Application.StartupPath + "\\logs\\")))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\logs\\");
                }

                fs = new FileStream(Application.StartupPath + "\\logs\\errorlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using (StreamWriter s = new StreamWriter(fs))
                {
                    fs = null;
                }


                fs1 = new FileStream(Application.StartupPath + "\\logs\\errorlog.txt", FileMode.Append, FileAccess.Write);
                using (StreamWriter s1 = new StreamWriter(fs1))
                {
                    fs1 = null;
                    s1.Write("Title: " + ex.TargetSite + "\r\n");
                    s1.Write("Message: " + ex.Message + "\r\n");
                    s1.Write("StackTrace: " + ex.StackTrace + "\r\n");
                    s1.Write("Date/Time: " + DateTime.Now.ToString() + "\r\n");
                    s1.Write("===========================================================================================\r\n\r\n");//+ vbCrLf);

                }

                Console.WriteLine(ex);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (fs1 != null)
                    fs1.Close();
            }
        }

        public bool WriteToEventLog(string entry, string appName, EventLogEntryType eventType, string LogName)
        {
            EventLog objEventLog = new EventLog();
            try
            {
                if (!(EventLog.SourceExists(appName)))
                {
                    EventLog.CreateEventSource(appName, LogName);
                }
                objEventLog.Source = appName;
                objEventLog.WriteEntry(entry, eventType);
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                return false;
            }
            finally
            {
                objEventLog.Close();
            }
        }
    }
}
