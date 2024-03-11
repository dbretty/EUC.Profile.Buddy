// <copyright file="UserDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.User
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Logging.Model;
    using EUC.Profile.Buddy.Common.Registry;
    using Microsoft.Win32;

    /// <summary>
    /// Class look after the User object.
    /// </summary>
    public class UserDetail : IUserDetail
    {
        private const string VolatileEnvironmentValue = "Volatile Environment";
        private const string UserNameValue = "USERNAME";
        private const string UserDomainValue = "USERDOMAIN";
        private const string UserProfileDirectoryValue = "USERPROFILE";
        private const string UserLocalAppDataValue = "LOCALAPPDATA";
        private const string UserRoamingAppDataValue = "APPDATA";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetail"/> class.
        /// </summary>
        public UserDetail()
        {
            if (OperatingSystem.IsWindows())
            {
                IWindowsRegistry userRegistry = new WindowsRegistry();
                IFilesAndFolders filesAndFolders = new FilesAndFolders();
                ILogger logger = new Logger();

                this.ProfileDirectory = string.Empty;

                this.UserName = (string?)userRegistry.GetRegistryValue(UserNameValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                logger.LogAsync($"Retrieved User Name: {this.UserName}");

                this.Domain = (string?)userRegistry.GetRegistryValue(UserDomainValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                logger.LogAsync($"Retrieved Domain: {this.Domain}");

                this.ProfileDirectory = (string?)userRegistry.GetRegistryValue(UserProfileDirectoryValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                logger.LogAsync($"Retrieved Profile Directory: {this.ProfileDirectory}");

                this.AppDataLocal = (string?)userRegistry.GetRegistryValue(UserLocalAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                logger.LogAsync($"Retrieved Local App Data: {this.AppDataLocal}");

                this.AppDataRoaming = (string?)userRegistry.GetRegistryValue(UserRoamingAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                logger.LogAsync($"Retrieved Roaming App Data: {this.AppDataRoaming}");

                if (this.ProfileDirectory is not null)
                {
                    this.ProfileSize = this.UpdateProfileSize(this.ProfileDirectory);
                    logger.LogAsync($"Retrieved Profile Size: {this.ProfileSize}");
                }
                else
                {
                    this.ProfileSize = "0 GB";
                    logger.LogAsync($"Error Getting Profile Size, Setting To: {this.ProfileSize}", LogLevel.ERROR);
                }
            }
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
        /// Update the profile size for the user.
        /// </summary>
        /// <param name="profileDirectory">The base root key to action (HKLM, HKCU, HKCR). <see cref="profileDirectory"/>.</param>
        /// <returns>A <see cref="string"/> or a null value.</returns>
        public string UpdateProfileSize(string profileDirectory)
        {
            IFilesAndFolders filesAndFolders = new FilesAndFolders();
            ILogger logger = new Logger();
            logger.LogAsync($"Getting Profile Size for: {profileDirectory}");
            var profileSize = filesAndFolders.FormatFileSize((long)filesAndFolders.DirectorySize(new DirectoryInfo(profileDirectory)));
            this.ProfileSize = profileSize;
            return profileSize;
        }
    }
}
