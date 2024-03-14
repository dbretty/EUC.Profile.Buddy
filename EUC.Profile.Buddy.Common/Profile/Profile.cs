// <copyright file="Profile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Profile
{
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using Microsoft.Win32;

    /// <summary>
    /// Class to get user profile information.
    /// </summary>
    public class Profile : IProfile
    {
        private string[] shellFolders = { "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders" };
        private string[] citrixRootKey = { "Software\\Policies\\Citrix\\UserProfileManager" };
        private string[] fslogixRootKey = { "Software\\FSLogix\\Profiles" };
        private string[] localRootKey = { "Volatile Environment" };

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
    }
}
