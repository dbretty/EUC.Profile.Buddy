using EUC.Profile.Buddy.Common.Logging.Model;

namespace EUC.Profile.Buddy.Common.Logging
{
    /// <summary>
    /// Class to do logging.
    /// </summary>
    public class Logger : ILogger
    {
        private const string fileName = "EUC.Profile.Buddy.Log.txt";
        private string fullLogFile = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.fullLogFile = Path.Combine(
                Path.GetTempPath(),
                string.Format($"{DateTime.Now:yyyyMMdd}_{fileName}"));
        }

        /// <summary>
        /// Adds an entry to the log.
        /// </summary>
        /// <param name="logMessage">The message to send to the log.</param>
        /// <param name="logLevel">The level of the log message (INFO, WARNING, ERROR, FATAL, DEBUG).</param>
        /// <param name="logType">The type of Log entry to create (FILE).</param>
        public async Task LogAsync(string logMessage, LogLevel logLevel = LogLevel.INFO, LogType logType = LogType.FILE)
        {
            using (StreamWriter streamWriter = new(this.fullLogFile, true))
            {
                await streamWriter.WriteLineAsync($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}[{logLevel}] {logMessage}");
                streamWriter.Close();
            }
        }
    }
}
