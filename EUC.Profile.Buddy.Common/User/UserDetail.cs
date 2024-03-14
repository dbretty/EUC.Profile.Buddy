// <copyright file="UserDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetail"/> class.
        /// </summary>
        public UserDetail()
        {
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
        /// Updates the profile size for the user.
        /// </summary>
        /// <param name="profileDirectory">The Profile Directory to get the size for.</param>
        /// <returns>A <see cref="string"/> with the profile size.</returns>
        public string UpdateProfileSize(string profileDirectory)
        {
            ArgumentException.ThrowIfNullOrEmpty(profileDirectory, nameof(profileDirectory));

            IFilesAndFolders filesAndFolders = new FilesAndFolders();

            var profileSize = filesAndFolders.FormatFileSize((long)filesAndFolders.DirectorySize(new DirectoryInfo(profileDirectory)));
            this.ProfileSize = profileSize;

            return profileSize;
        }

        /// <summary>
        /// Gets the User Profile Data.
        /// </summary>
        private void GetUserData()
        {
            if (OperatingSystem.IsWindows())
            {
                IWindowsRegistry windowsRegistry = new WindowsRegistry();

                this.UserName = (string?)windowsRegistry.GetRegistryValue(UserNameValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.Domain = (string?)windowsRegistry.GetRegistryValue(UserDomainValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.ProfileDirectory = (string?)windowsRegistry.GetRegistryValue(UserProfileDirectoryValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataLocal = (string?)windowsRegistry.GetRegistryValue(UserLocalAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
                this.AppDataRoaming = (string?)windowsRegistry.GetRegistryValue(UserRoamingAppDataValue, VolatileEnvironmentValue, RegistryHive.CurrentUser);
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
                            this.UserProfileType = ProfileType.FSLogix;
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
                            this.UserProfileType = ProfileType.Citrix;
                            profileTypeFound = true;
                            break;
                    }
                }
            }

            if (!profileTypeFound)
            {
                this.UserProfileType = ProfileType.Local;
            }
        }
    }
}
