// <copyright file="UserDetail.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.User
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User.Model;
    using Microsoft.Win32;

    /// <summary>
    /// Class look after the UserDetail object.
    /// </summary>
    public class UserDetail : IUserDetail
    {
        /// <summary>
        /// Volatile environment registry location.
        /// </summary>
        private const string VolatileEnvironmentValue = "Volatile Environment";

        /// <summary>
        /// Volatile environment Username location.
        /// </summary>
        private const string UserNameValue = "USERNAME";

        /// <summary>
        /// Volatile environment Domain location.
        /// </summary>
        private const string UserDomainValue = "USERDOMAIN";

        /// <summary>
        /// Volatile environment User Profile location.
        /// </summary>
        private const string UserProfileDirectoryValue = "USERPROFILE";

        /// <summary>
        /// Volatile environment Local AppData location.
        /// </summary>
        private const string UserLocalAppDataValue = "LOCALAPPDATA";

        /// <summary>
        /// Volatile environment Roaming AppData location.
        /// </summary>
        private const string UserRoamingAppDataValue = "APPDATA";

        /// <summary>
        /// FSLogix Enabled Value.
        /// </summary>
        private const int FSLogixValue = 1;

        /// <summary>
        /// FSLogix Key Value.
        /// </summary>
        private const string FSLogixKey = "Enabled";

        /// <summary>
        /// FSLogix Registry Location.
        /// </summary>
        private const string FSLogixRoot = "Software\\FSLogix\\Profiles";

        /// <summary>
        /// CPM Enabled Value.
        /// </summary>
        private const int CPMValue = 1;

        /// <summary>
        /// CPM Key Value.
        /// </summary>
        private const string CPMKey = "ServiceActive";

        /// <summary>
        /// CPM Registry Location.
        /// </summary>
        private const string CPMRoot = "Software\\Policies\\Citrix\\UserProfileManager";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetail"/> class.
        /// </summary>
        public UserDetail()
        {
            this.GetUserData();
        }

        /// <summary>
        /// Gets or sets the ProfileTypes.
        /// </summary>
        public ProfileType[] ProfileType { get; set; } =
            {
                new ProfileType
                {
                    ProfileTypeLabel = "Local",
                    ProfileTypeDefinition = ProfileTypeDefinition.Local,
                },
                new ProfileType
                {
                    ProfileTypeLabel = "Citrix",
                    ProfileTypeDefinition = ProfileTypeDefinition.Citrix,
                },
                new ProfileType
                {
                    ProfileTypeLabel = "FSLogix",
                    ProfileTypeDefinition = ProfileTypeDefinition.FSLogix,
                },
            };

        /// <inheritdoc/>
        public string? UserName { get; set; }

        /// <inheritdoc/>
        public string? Domain { get; set; }

        /// <inheritdoc/>
        public string? ProfileDirectory { get; set; }

        /// <inheritdoc/>
        public string? AppDataLocal { get; set; }

        /// <inheritdoc/>
        public string? AppDataRoaming { get; set; }

        /// <inheritdoc/>
        public string? ProfileSize { get; set; }

        /// <inheritdoc/>
        public string? UserProfileType { get; set; }

        /// <inheritdoc/>
        public ProfileTypeDefinition ProfileDefinition { get; set; }

        /// <inheritdoc/>
        public string UpdateProfileSize(string profileDirectory)
        {
            ArgumentException.ThrowIfNullOrEmpty(profileDirectory, nameof(profileDirectory));

            IFilesAndFolders filesAndFolders = new FilesAndFolders();

            var profileSizeRaw = filesAndFolders.DirectorySizeAsync(new DirectoryInfo(profileDirectory));
            long profileSizeLong = profileSizeRaw.GetAwaiter().GetResult();
            var profileSize = filesAndFolders.FormatFileSize(profileSizeLong);

            this.ProfileSize = profileSize;

            return profileSize;
        }

        /// <inheritdoc/>
        public async Task<string> UpdateProfileSizeAsync(string profileDirectory)
        {
            ArgumentException.ThrowIfNullOrEmpty(profileDirectory, nameof(profileDirectory));

            return await Task.Run(() => this.UpdateProfileSize(profileDirectory));
        }

        /// <summary>
        /// Gets the User Profile Data.
        /// </summary>
        private async void GetUserData()
        {
            if (OperatingSystem.IsWindows())
            {
                IWindowsRegistry windowsRegistry = new WindowsRegistry();

                var userNameTask = await windowsRegistry.GetRegistryValueAsync(UserNameValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.UserName = (string?)userNameTask;

                var domainTask = await windowsRegistry.GetRegistryValueAsync(UserDomainValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.Domain = (string?)domainTask;

                var profileDirectoryTask = await windowsRegistry.GetRegistryValueAsync(UserProfileDirectoryValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.ProfileDirectory = (string?)profileDirectoryTask;

                var localAppDataTask = await windowsRegistry.GetRegistryValueAsync(UserLocalAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataLocal = (string?)localAppDataTask;

                var roamingAppDataTask = await windowsRegistry.GetRegistryValueAsync(UserRoamingAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataRoaming = (string?)roamingAppDataTask;

                if (this.ProfileDirectory is not null)
                {
                    this.ProfileSize = await this.UpdateProfileSizeAsync(this.ProfileDirectory);
                }
                else
                {
                    this.ProfileSize = "0 GB";
                }

                this.GetProfileType();
            }
        }

        /// <summary>
        /// Gets the User Profile Type.
        /// </summary>
        private void GetProfileType()
        {
            IWindowsRegistry windowsRegistry = new WindowsRegistry();
            var profileTypeFound = false;

            if (windowsRegistry.GetRegistryKey(FSLogixRoot, RegistryHive.LocalMachine))
            {
                var fslValue = windowsRegistry.GetRegistryValue(FSLogixKey, FSLogixRoot, RegistryHive.LocalMachine);
                if (fslValue is not null)
                {
                    switch (fslValue)
                    {
                        case FSLogixValue:
                            this.UserProfileType = ProfileTypeDefinition.FSLogix.ToString();
                            this.ProfileDefinition = ProfileTypeDefinition.FSLogix;
                            profileTypeFound = true;
                            break;
                    }
                }
            }

            if (windowsRegistry.GetRegistryKey(CPMRoot, RegistryHive.LocalMachine))
            {
                var cpmValue = windowsRegistry.GetRegistryValue(CPMKey, CPMRoot, RegistryHive.LocalMachine);
                if (cpmValue is not null)
                {
                    switch (cpmValue)
                    {
                        case CPMValue:
                            this.UserProfileType = ProfileTypeDefinition.Citrix.ToString();
                            this.ProfileDefinition = ProfileTypeDefinition.Citrix;
                            profileTypeFound = true;
                            break;
                    }
                }
            }

            if (!profileTypeFound)
            {
                this.UserProfileType = ProfileTypeDefinition.Local.ToString();
                this.ProfileDefinition = ProfileTypeDefinition.Local;
            }
        }
    }
}
