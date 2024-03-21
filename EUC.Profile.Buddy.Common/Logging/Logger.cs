// <copyright file="Logger.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Logging
{
    using EUC.Profile.Buddy.Common.Logging.Model;

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

        /// <inheritdoc/>
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
