using EUC.Profile.Buddy.Common.Registry;
using EUC.Profile.Buddy.Common.File;
using Microsoft.Win32;

namespace EUC.Profile.Buddy.Common.User
{
    /// <summary>
    /// Class look after the User object.
    /// </summary>
    public class User : IUser
    {
        public string? UserName { get; set; }
        public string? Domain { get; set; }
        public string? ProfileDirectory { get; set; }
        public string? AppDataLocal { get; set; }
        public string? AppDataRoaming { get; set; }
        public string? ProfileSize { get; set; }

        private const string volatileEnvironment = "Volatile Environment";
        private const string userName = "USERNAME";
        private const string userDomain = "USERDOMAIN";
        private const string userProfileDirectory = "USERPROFILE";
        private const string userLocalAppData = "LOCALAPPDATA";
        private const string userRoamingAppData = "APPDATA";

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            if (OperatingSystem.IsWindows())
            {
                IWindowsRegistry userRegistry = new WindowsRegistry();
                IFilesAndFolders filesAndFolders = new FilesAndFolders();
                this.UserName = (string?)userRegistry.GetRegistryValue(userName, volatileEnvironment, RegistryHive.CurrentUser);
                this.Domain = (string?)userRegistry.GetRegistryValue(userDomain, volatileEnvironment, RegistryHive.CurrentUser);
                this.ProfileDirectory = (string?)userRegistry.GetRegistryValue(userProfileDirectory, volatileEnvironment, RegistryHive.CurrentUser);
                this.AppDataLocal = (string?)userRegistry.GetRegistryValue(userLocalAppData, volatileEnvironment, RegistryHive.CurrentUser);
                this.AppDataRoaming = (string?)userRegistry.GetRegistryValue(userRoamingAppData, volatileEnvironment, RegistryHive.CurrentUser);
                UpdateProfileSize(this.ProfileDirectory);
            }
        }

        /// <summary>
        /// Update the profile size for the user.
        /// </summary>
        public string UpdateProfileSize(string profileDirectory)
        {
            IFilesAndFolders filesAndFolders = new FilesAndFolders();
            var profileSize = filesAndFolders.FormatFileSize(
                (long)filesAndFolders.DirectorySize(new DirectoryInfo(this.ProfileDirectory))
            );
            this.ProfileSize = profileSize; 
            return profileSize;
        }
    }
}
