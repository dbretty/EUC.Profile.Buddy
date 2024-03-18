// <copyright file="UserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Profile
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Profile.Model;

    /// <summary>
    /// Class to get user profile information.
    /// </summary>
    public class UserProfile : IUserProfile
    {
        /// <summary>
        /// Temporary Files Location.
        /// </summary>
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

        /// <summary>
        /// Shell Folders Location.
        /// </summary>
        private readonly string[] shellFolders =
        {
            "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders",
        };

        /// <summary>
        /// Citrix Profile Management Keys.
        /// </summary>
        private readonly string[] citrixRootKey =
        {
            "Software\\Policies\\Citrix\\UserProfileManager",
        };

        /// <summary>
        /// FSLogix Management Keys.
        /// </summary>
        private readonly string[] fslogixRootKey =
        {
            "Software\\FSLogix\\Profiles",
        };

        /// <summary>
        /// Local Profile Management Keys.
        /// </summary>
        private readonly string[] localRootKey =
        {
            "Volatile Environment",
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            this.ShellFolders = this.shellFolders;
            this.CitrixRootKey = this.citrixRootKey;
            this.FSLogixRootKey = this.fslogixRootKey;
            this.LocalRootKey = this.localRootKey;
        }

        /// <summary>
        /// Gets or sets the Actions.
        /// </summary>
        public ProfileAction[] ProfileActions { get; set; } =
            {
                new ProfileAction
                {
                    ActionLabel = "Clean Temporary Data",
                    ActionDefinition = ProfileActionDefinition.ClearTempFiles,
                },
                new ProfileAction
                {
                    ActionLabel = "run Custom Scripts",
                    ActionDefinition = ProfileActionDefinition.RunCustomScripts,
                },
            };

        /// <inheritdoc/>
        public string[] ShellFolders { get; set; }

        /// <inheritdoc/>
        public string[] CitrixRootKey { get; set; }

        /// <inheritdoc/>
        public string[] FSLogixRootKey { get; set; }

        /// <inheritdoc/>
        public string[] LocalRootKey { get; set; }

        /// <inheritdoc/>
        public async void ExecuteAction(ProfileActionDefinition actionDefinition, string profileDirectory)
        {
            switch (actionDefinition)
            {
                case ProfileActionDefinition.ClearTempFiles:
                    FilesAndFolders filesAndFolders = new FilesAndFolders();
                    foreach (var subFolder in this.tempFolders)
                    {
                        await filesAndFolders.DeleteFolderAsync(Path.Join(profileDirectory, subFolder));
                    }

                    break;
                case ProfileActionDefinition.RunCustomScripts:
                    break;
                default:
                    // todo: log error;
                    break;
            }
        }
    }
}
