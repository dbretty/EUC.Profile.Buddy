// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Logging
{
    using EUC.Profile.Buddy.Common.Logging.Model;
    using EUC.Profile.Buddy.Common.User.Model;

    /// <summary>
    /// Class to do logging.
    /// </summary>
    public class Logger : ILogger
    {
        private const string FileName = "EUC.Profile.Buddy.Log.txt";
        private string fullLogFile = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.fullLogFile = Path.Combine(
                Path.GetTempPath(),
                string.Format($"{DateTime.Now:yyyyMMdd}_{FileName}"));
        }

        /// <summary>
        /// Adds an entry to the log.
        /// </summary>
        /// <param name="logMessage">The message to send to the log.</param>
        /// <param name="logLevel">The level of the log message (INFO, WARNING, ERROR, FATAL, DEBUG).</param>
        /// <param name="logType">The type of Log entry to create (FILE).</param>
        /// <returns>The Task.</returns>
        public async Task LogAsync(string logMessage, LogLevel logLevel = LogLevel.INFO, LogType logType = LogType.FILE)
        {
            ArgumentException.ThrowIfNullOrEmpty(logMessage, nameof(logMessage));

            using (StreamWriter streamWriter = new (this.fullLogFile, true))
            {
                await streamWriter.WriteLineAsync($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}[{logLevel}] {logMessage}");
                streamWriter.Close();
            }
        }
    }
}
