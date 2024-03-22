// <copyright file="IAppConfig.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Configuration
{
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
    }
}