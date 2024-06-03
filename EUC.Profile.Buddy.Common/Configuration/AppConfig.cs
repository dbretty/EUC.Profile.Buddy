// <copyright file="AppConfig.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Configuration
{
    using EUC.Profile.Buddy.Common.ApiClient;
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User;
    using Microsoft.Win32;

    /// <summary>
    /// App Configuration Class.
    /// </summary>
    public class AppConfig : IAppConfig
    {
        /// <summary>
        /// Private ILogger interface.
        /// </summary>
        private const string ApplicationRegistryKey = "Software\\EUCProfileBuddy";

        /// <summary>
        /// Private LogLevel Info.
        /// </summary>
        private const string LoggingLevelInfo = "Info";

        /// <summary>
        /// Private LogLevel Info.
        /// </summary>
        private const string LoggingLevelDebug = "Debug";

        /// <summary>
        /// Private Clear Temp at Start.
        /// </summary>
        private const string ClearTemp = "No";

        /// <summary>
        /// Private Clear Temp at Start.
        /// </summary>
        private const string LogServer = "No";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfig"/> class.
        /// </summary>
        public AppConfig()
        {
            this.Logger = new Logger();
            this.Registry = new WindowsRegistry(this.Logger);
            this.FilesAndFolders = new FilesAndFolders(this.Logger);
            this.UserProfile = new UserProfile(this.Logger, this.FilesAndFolders);
            this.UserDetail = new UserDetail(this.Logger, this.Registry, this.FilesAndFolders);
            this.TaskInformationClient = new TaskInformationClient();
            this.UserProfileSummaryClient = new UserProfileSummaryClient();
            this.AppRegistryKey = ApplicationRegistryKey;
            this.LogLevel = LoggingLevelInfo;
            this.ClearTempAtStart = ClearTemp;
            this.LogToServer = LogServer;
            this.EUCProfileBuddyStartup();
        }

        /// <inheritdoc/>
        public ILogger Logger { get; set; }

        /// <inheritdoc/>
        public IWindowsRegistry Registry { get; set; }

        /// <inheritdoc/>
        public IFilesAndFolders FilesAndFolders { get; set; }

        /// <inheritdoc/>
        public IUserProfile UserProfile { get; set; }

        /// <inheritdoc/>
        public IUserDetail UserDetail { get; set; }

        /// <inheritdoc/>
        public TaskInformationClient TaskInformationClient { get; set; }

        /// <inheritdoc/>
        public UserProfileSummaryClient UserProfileSummaryClient { get; set; }

        /// <inheritdoc/>
        public string AppRegistryKey { get; set; }

        /// <inheritdoc/>
        public string LogLevel { get; set; }

        /// <inheritdoc/>
        public string ClearTempAtStart { get; set; }

        /// <inheritdoc/>
        public string LogToServer { get; set; }

        /// <summary>
        /// Startup module to cater for start actions.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private void EUCProfileBuddyStartup()
        {
            this.Logger.LogAsync($"Checking for EUC Profile Buddy registry key: {this.AppRegistryKey}");
            var keyExists = this.Registry.GetRegistryKey(this.AppRegistryKey, RegistryHive.CurrentUser);
            if (keyExists)
            {
                this.Logger.LogAsync($"Key exists, reading in application settings");
                var tempFolders = this.Registry.GetRegistryValue("TempDataLocations", this.AppRegistryKey, RegistryHive.CurrentUser);
                if (tempFolders is not null)
                {
                    this.Logger.LogAsync($"Temp folders: {tempFolders}");
                    this.UserProfile.TempFolders = (string[])tempFolders;
                }
                else
                {
                    this.Logger.LogAsync($"Error reading: TempDataLocations", Logging.Model.LogLevel.ERROR);
                    throw new InvalidOperationException();
                }

                var logLevel = this.Registry.GetRegistryValue("LogLevel", this.AppRegistryKey, RegistryHive.CurrentUser);
                if (logLevel is not null)
                {
                    switch ((string)logLevel)
                    {
                        case LoggingLevelInfo:
                            this.Logger.LogAsync($"Log level: {LoggingLevelInfo}");
                            this.LogLevel = LoggingLevelInfo;
                            break;
                        case LoggingLevelDebug:
                            this.Logger.LogAsync($"Log level: {LoggingLevelDebug}");
                            this.LogLevel = LoggingLevelDebug;
                            break;
                        default:
                            this.Logger.LogAsync($"Log level: {LoggingLevelInfo}");
                            this.LogLevel = LoggingLevelInfo;
                            break;
                    }
                }
                else
                {
                    this.Logger.LogAsync($"Error reading: LogLevel", Logging.Model.LogLevel.ERROR);
                    throw new InvalidOperationException();
                }

                var clearTemp = this.Registry.GetRegistryValue("ClearTempAtStart", this.AppRegistryKey, RegistryHive.CurrentUser);
                if (clearTemp is not null)
                {
                    this.Logger.LogAsync($"Clear Temp At Start: {clearTemp}");
                    this.ClearTempAtStart = (string)clearTemp;
                }
                else
                {
                    this.Logger.LogAsync($"Error reading: ClearTempAtStart", Logging.Model.LogLevel.ERROR);
                    throw new InvalidOperationException();
                }

                var logToServerRegistry = this.Registry.GetRegistryValue("LogToServer", this.AppRegistryKey, RegistryHive.CurrentUser);
                if (logToServerRegistry is not null)
                {
                    this.Logger.LogAsync($"Log To Server: {logToServerRegistry}");
                    this.LogToServer = (string)logToServerRegistry;
                }
                else
                {
                    this.Logger.LogAsync($"Error reading: LogToServer", Logging.Model.LogLevel.ERROR);
                    throw new InvalidOperationException();
                }
            }
            else
            {
                this.Logger.LogAsync($"Key does not exist, creating: {this.AppRegistryKey}");
                if (this.Registry.CreateRegistryKey(this.AppRegistryKey, RegistryHive.CurrentUser))
                {
                    this.Registry.SetRegistryValue("TempDataLocations", this.AppRegistryKey, this.UserProfile.TempFolders, RegistryHive.CurrentUser);
                    this.Logger.LogAsync($"Creating TempDataLocations: {this.UserProfile.TempFolders}");

                    this.Registry.SetRegistryValue("LogLevel", this.AppRegistryKey, this.LogLevel, RegistryHive.CurrentUser);
                    this.Logger.LogAsync($"Creating LogLevel: {this.LogLevel}");

                    this.Registry.SetRegistryValue("ClearTempAtStart", this.AppRegistryKey, this.ClearTempAtStart, RegistryHive.CurrentUser);
                    this.Logger.LogAsync($"Creating ClearTempAtStart: {this.ClearTempAtStart}");

                    this.Registry.SetRegistryValue("LogToServer", this.AppRegistryKey, this.ClearTempAtStart, RegistryHive.CurrentUser);
                    this.Logger.LogAsync($"Creating LogToServer: {this.LogToServer}");
                }
                else
                {
                    this.Logger.LogAsync($"Error creating: {this.AppRegistryKey}", Logging.Model.LogLevel.ERROR);
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
