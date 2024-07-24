// <copyright file="IAppConfig.cs" company="bretty.me.uk">
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

    /// <summary>
    /// Interface for the AppConfig Class.
    /// </summary>
    public interface IAppConfig
    {
        /// <summary>
        /// Gets The FilesAndFolders.
        /// </summary>
        IFilesAndFolders FilesAndFolders { get; }

        /// <summary>
        /// Gets The Logger.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets The Registry.
        /// </summary>
        IWindowsRegistry Registry { get;  }

        /// <summary>
        /// Gets The UserDetail.
        /// </summary>
        IUserDetail UserDetail { get;  }

        /// <summary>
        /// Gets The UserProfile.
        /// </summary>
        IUserProfile UserProfile { get; }

        /// <summary>
        /// Gets The Task Information Client.
        /// </summary>
        TaskInformationClient TaskInformationClient { get; }

        /// <summary>
        /// Gets The Task Information Client.
        /// </summary>
        UserProfileSummaryClient UserProfileSummaryClient { get; }

        /// <summary>
        /// Gets The Application Registry Key.
        /// </summary>
        string AppRegistryKey { get; }

        /// <summary>
        /// Gets or Sets The Application Registry Key.
        /// </summary>
        string LogLevel { get; set; }

        /// <summary>
        /// Gets or Sets Clear Temp At Start.
        /// </summary>
        string ClearTempAtStart { get; set; }

        /// <summary>
        /// Gets or Sets Log To Server.
        /// </summary>
        string LogToServer { get; set; }

        /// <summary>
        /// Gets or Sets Logging Server Uri.
        /// </summary>
        string LoggingServerUri { get; set; }

        /// <summary>
        /// Gets or Sets User Profile Guid.
        /// </summary>
        Guid UserProfileGuid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Hub Connection.
        /// </summary>
        bool HubConnection { get; set; }
    }
}