// <copyright file="UserDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.User
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Logging.Model;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User.Model;
    using Microsoft.Win32;

    /// <summary>
    /// Class look after the UserDetail object.
    /// </summary>
    public class UserDetail : IUserDetail
    {
        private const string VolatileEnvironmentValue = "Volatile Environment";
        private const string UserNameValue = "USERNAME";
        private const string UserDomainValue = "USERDOMAIN";
        private const string UserProfileDirectoryValue = "USERPROFILE";
        private const string UserLocalAppDataValue = "LOCALAPPDATA";
        private const string UserRoamingAppDataValue = "APPDATA";
        private const int FSLogixValue = 1;
        private const string FSLogixKey = "Enabled";
        private const string FSLogixRoot = "Software\\FSLogix\\Profiles";
        private const int CPMValue = 1;
        private const string CPMKey = "ServiceActive";
        private const string CPMRoot = "Software\\Policies\\Citrix\\UserProfileManager";


        private ILogger privateLogger;
        private IWindowsRegistry privateRegistry;
        private IFilesAndFolders privateFilesAndFolders;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetail"/> class.
        /// </summary>
        /// <param name="logger">The Logger interface.</param>
        /// <param name="registry">The Registry interface.</param>
        /// <param name="filesAndFolders">The Files and Folders interface.</param>
        public UserDetail(ILogger logger, IWindowsRegistry registry, IFilesAndFolders filesAndFolders)
        {
            this.privateLogger = logger;
            this.privateRegistry = registry;
            this.privateFilesAndFolders = filesAndFolders;
            this.GetUserData();
        }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the Domain.
        /// </summary>
        public string? Domain { get; set; }

        /// <summary>
        /// Gets or sets the Profile Directory.
        /// </summary>
        public string? ProfileDirectory { get; set; }

        /// <summary>
        /// Gets or sets the AppData Local.
        /// </summary>
        public string? AppDataLocal { get; set; }

        /// <summary>
        /// Gets or sets the AppData Roaming.
        /// </summary>
        public string? AppDataRoaming { get; set; }

        /// <summary>
        /// Gets or sets the Profile Size.
        /// </summary>
        public string? ProfileSize { get; set; }

        /// <summary>
        /// Gets or sets the User Profile Type.
        /// </summary>
        public ProfileType? UserProfileType { get; set; }

        /// <summary>
        /// Update the profile size for the user.
        /// </summary>
        /// <param name="profileDirectory">The Profile Directory to get the size for.</param>
        /// <returns>A <see cref="string"/> with the profile size.</returns>
        public string UpdateProfileSize(string profileDirectory)
        {
            ArgumentException.ThrowIfNullOrEmpty(profileDirectory, nameof(profileDirectory));

            this.privateLogger.LogAsync($"Getting Profile Size: {this.ProfileDirectory}");

            var profileSize = this.privateFilesAndFolders.FormatFileSize((long)this.privateFilesAndFolders.DirectorySize(new DirectoryInfo(profileDirectory)));
            this.ProfileSize = profileSize;

            this.privateLogger.LogAsync($"Profile Size Calculated To: {this.ProfileSize}");

            return profileSize;
        }

        /// <summary>
        /// Gets the User Profile Data.
        /// </summary>
        public void GetUserData()
        {
            if (OperatingSystem.IsWindows())
            {
                this.UserName = (string?)this.privateRegistry.GetRegistryValue(UserNameValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.Domain = (string?)this.privateRegistry.GetRegistryValue(UserDomainValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.ProfileDirectory = (string?)this.privateRegistry.GetRegistryValue(UserProfileDirectoryValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataLocal = (string?)this.privateRegistry.GetRegistryValue(UserLocalAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataRoaming = (string?)this.privateRegistry.GetRegistryValue(UserRoamingAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                if (this.ProfileDirectory is not null)
                {
                    this.ProfileSize = this.UpdateProfileSize(this.ProfileDirectory);
                }
                else
                {
                    this.ProfileSize = "0 GB";
                }

                this.GetProfileType();
            }
            else
            {
                this.privateLogger.LogAsync("Not a Windows Operating System", LogLevel.ERROR);
                this.privateLogger.LogAsync("Setting User Parameters to INVALID");
                this.UserName = "INVALID";
                this.Domain = "INVALID";
                this.ProfileDirectory = "INVALID";
                this.AppDataLocal = "INVALID";
                this.AppDataRoaming = "INVALID";
                this.ProfileSize = "0 GB";
                this.UserProfileType = ProfileType.Local;
            }
        }

        private void GetProfileType()
        {
            var profileTypeFound = false;

            if (this.privateRegistry.GetRegistryKey(FSLogixRoot, RegistryHive.LocalMachine))
            {
                var fslValue = this.privateRegistry.GetRegistryValue(FSLogixKey, FSLogixRoot, RegistryHive.LocalMachine);
                if (fslValue is not null)
                {
                    switch (fslValue)
                    {
                        case FSLogixValue:
                            this.UserProfileType = ProfileType.FSLogix;
                            this.privateLogger.LogAsync($"Profile Type: {ProfileType.FSLogix.ToString()}");
                            profileTypeFound = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (this.privateRegistry.GetRegistryKey(CPMRoot, RegistryHive.LocalMachine))
            {
                var cpmValue = this.privateRegistry.GetRegistryValue(CPMKey, CPMRoot, RegistryHive.LocalMachine);
                if (cpmValue is not null)
                {
                    switch (cpmValue)
                    {
                        case CPMValue:
                            this.UserProfileType = ProfileType.Citrix;
                            this.privateLogger.LogAsync($"Profile Type: {ProfileType.Citrix.ToString()}");
                            profileTypeFound = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!profileTypeFound)
            {
                this.privateLogger.LogAsync($"Profile Type: {ProfileType.Local.ToString()}");
                this.UserProfileType = ProfileType.Local;
            }
        }
    }
}
