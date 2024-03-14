// <copyright file="Profile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Profile
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using EUC.Profile.Buddy.Common.User;
    using Microsoft.Win32;

    /// <summary>
    /// Class to get user profile information.
    /// </summary>
    public class Profile : IProfile
    {
        private readonly string[] tempFolders =
        {
            "AppData\\Local\\Temp",
            "AppData\\Roaming\\Temp",
            "AppData\\Local\\Microsoft\\Windows\\GameExplorer",
            "AppData\\Local\\Microsoft\\Windows\\WER",
            "AppData\\Local\\Microsoft\\Windows\\CrashReports",
            "AppData\\Local\\Microsoft\\MSOIdentityCRL\\Tracing",
            "AppData\\Local\\CrashDumps",
            "AppData\\Local\\Package Cache",
            "AppData\\Local\\D3DSCache",
            "AppData\\Local\\Microsoft\\Windows\\WebCache.old",
        };

        private string[] shellFolders = { "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders" };
        private string[] citrixRootKey = { "Software\\Policies\\Citrix\\UserProfileManager" };
        private string[] fslogixRootKey = { "Software\\FSLogix\\Profiles" };
        private string[] localRootKey = { "Volatile Environment" };

        /// <summary>
        /// Gets or sets the Actions.
        /// </summary>
        public string[] Actions { get; set; } = { "Clear Temporary Data", "Run Custom Scripts" };

        /// <summary>
        /// Gets the profile details from the registry.
        /// </summary>
        /// <param name="profileType">The type of user profile.</param>
        /// <returns>A <see cref="List"/>.</returns>
        public List<RegistryPathValue> GetProfileDetails(string profileType)
        {
            ArgumentException.ThrowIfNullOrEmpty(profileType, nameof(profileType));

            IWindowsRegistry registry = new WindowsRegistry();

            var profileDetail = new List<RegistryPathValue>();

            switch (profileType)
            {
                case "Local":
                    profileDetail = registry.GetRegistryPathValue(this.localRootKey, RegistryHive.CurrentUser);
                    break;
                case "Citrix":
                    profileDetail = registry.GetRegistryPathValue(this.citrixRootKey, RegistryHive.LocalMachine);
                    break;
                case "FSLogix":
                    profileDetail = registry.GetRegistryPathValue(this.fslogixRootKey, RegistryHive.LocalMachine);
                    break;
            }

            return profileDetail;
        }

        /// <summary>
        /// Gets the folder redirection details from the registry.
        /// </summary>
        /// <returns>A <see cref="List"/>.</returns>
        public List<RegistryPathValue> GetFolderRedirectionDetails()
        {
            IWindowsRegistry registry = new WindowsRegistry();

            var folderRedirectionDetails = new List<RegistryPathValue>();

            folderRedirectionDetails = registry.GetRegistryPathValue(this.shellFolders, RegistryHive.LocalMachine);

            return folderRedirectionDetails;
        }

        /// <summary>
        /// Execute a profile action.
        /// </summary>
        /// <param name="actionDescription">The Action Description.</param>
        /// <param name="profileDirectory">The Profile Directory.</param>
        public void ExecuteAction(string actionDescription, string profileDirectory)
        {
            switch (actionDescription)
            {
                case "Clear Temporary Data":
                    IFilesAndFolders filesAndFolders = new FilesAndFolders();
                    foreach (var subFolder in tempFolders)
                    {
                        filesAndFolders.DeleteFolder(Path.Join(profileDirectory, subFolder));
                    }

                    break;
                case "Run Custom Scripts":
                    break;
            }
        }
    }
}
