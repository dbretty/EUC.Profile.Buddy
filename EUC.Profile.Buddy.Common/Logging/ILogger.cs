﻿// <copyright file="ILogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Logging
{
    using EUC.Profile.Buddy.Common.Logging.Model;

    /// <summary>
    /// Public Interface for the Logger Class.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Adds an entry to the log.
        /// </summary>
        /// <param name="logMessage">The message to send to the log.</param>
        /// <param name="logLevel">The level of the log message (INFO, WARNING, ERROR, FATAL, DEBUG).</param>
        /// <param name="logType">The type of Log entry to create (FILE).</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task LogAsync(string logMessage, LogLevel logLevel = LogLevel.INFO, LogType logType = LogType.FILE);
    }
}
