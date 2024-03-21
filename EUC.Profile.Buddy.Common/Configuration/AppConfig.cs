// <copyright file="AppConfig.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Configuration
{
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
        /// Initializes a new instance of the <see cref="AppConfig"/> class.
        /// </summary>
        public AppConfig()
        {
            this.Logger = new Logger();
            this.Registry = new WindowsRegistry(this.Logger);
            this.FilesAndFolders = new FilesAndFolders(this.Logger);
            this.UserProfile = new UserProfile(this.Logger, this.FilesAndFolders);
            this.UserDetail = new UserDetail(this.Logger, this.Registry, this.FilesAndFolders);
            this.AppRegistryKey = ApplicationRegistryKey;
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
        public string AppRegistryKey { get; set; }

        private void EUCProfileBuddyStartup()
        {
            var keyExists = this.Registry.GetRegistryKey(this.AppRegistryKey, RegistryHive.CurrentUser);
            if (keyExists)
            {
                var tempFolders = this.Registry.GetRegistryValue("TempDataLocations", this.AppRegistryKey, RegistryHive.CurrentUser);
                if (tempFolders is not null)
                {
                    this.UserProfile.TempFolders = (string[])tempFolders;
                }
            }
            else
            {
                if (this.Registry.CreateRegistryKey(this.AppRegistryKey, RegistryHive.CurrentUser))
                {
                    this.Registry.SetRegistryValue("TempDataLocations", this.AppRegistryKey, this.UserProfile.TempFolders, RegistryHive.CurrentUser);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
