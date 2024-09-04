using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMeApp
{
    using System;
    using System.IO;

    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "infos.log");

        // Method to ensure the log file exists; if not, create it
        private static void EnsureLogFileExists()
        {
            if (!File.Exists(logFilePath))
            {
                using (FileStream fs = File.Create(logFilePath))
                {
                    // Optionally, write some initial text or header to the log file
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine($"Log file created on {DateTime.Now}");
                    }
                }
            }
        }

        // Method to write a log entry
        public static void WriteLog(string message)
        {
            EnsureLogFileExists();

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                writer.WriteLine(logEntry);
            }
        }
    }

}
