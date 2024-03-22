// <copyright file="Logger.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Logging
{
    using System.IO;
    using System.Security;
    using EUC.Profile.Buddy.Common.Logging.Model;

    /// <summary>
    /// Class to do logging.
    /// </summary>
    public class Logger : ILogger
    {
        private const string FileName = "EUC.Profile.Buddy.Log.txt";
        private const string LogPath = "EUCProfileBuddy";
        private string fullLogFile = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            string directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                LogPath);

            this.fullLogFile = Path.Combine(
                directory,
                string.Format($"{DateTime.Now:yyyyMMdd}_{FileName}"));

            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch
                {
                    throw new SecurityException();
                }
            }
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
