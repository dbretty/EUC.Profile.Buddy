// <copyright file="UserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Profile
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Profile.Model;
    using EUC.Profile.Buddy.Common.Registry;

    /// <summary>
    /// Class to get user profile information.
    /// </summary>
    public class UserProfile : IUserProfile
    {
        /// <summary>
        /// Private ILogger interface.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Private ILogger interface.
        /// </summary>
        private readonly IFilesAndFolders filesAndFolders;

        /// <summary>
        /// Custom Scripts Location.
        /// </summary>
        private readonly string[] customScriptsLocation =
        {
            "AppData\\Local\\EUCProfileBuddy",
        };

        /// <summary>
        /// Local Profile Management Keys.
        /// </summary>
        private readonly string customScriptExecutable = "powershell.exe";

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
        /// <param name="logger">The logging interface.</param>
        /// <param name="filesAndFolders">The Files and Folders interface.</param>
        public UserProfile(ILogger logger, IFilesAndFolders filesAndFolders)
        {
            this.logger = logger;
            this.filesAndFolders = filesAndFolders;
            this.ShellFolders = this.shellFolders;
            this.CitrixRootKey = this.citrixRootKey;
            this.FSLogixRootKey = this.fslogixRootKey;
            this.LocalRootKey = this.localRootKey;
            this.CustomScriptsLocation = this.customScriptsLocation;
            this.CustomScriptExecutable = this.customScriptExecutable;
            this.TempFolders = this.tempFolders;
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
                    ActionLabel = "Run Custom Scripts",
                    ActionDefinition = ProfileActionDefinition.RunCustomScripts,
                },
                new ProfileAction
                {
                    ActionLabel = "Reset Microsoft Edge",
                    ActionDefinition = ProfileActionDefinition.ResetEdge,
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
        public string[] CustomScriptsLocation { get; set; }

        /// <inheritdoc/>
        public string CustomScriptExecutable { get; set; }

        /// <inheritdoc/>
        public string[] TempFolders { get; set; }

        /// <inheritdoc/>
        public async void ExecuteAction(ProfileActionDefinition actionDefinition, string profileDirectory, IUserProfile userProfile)
        {
            switch (actionDefinition)
            {
                case ProfileActionDefinition.ClearTempFiles:
                    foreach (var subFolder in userProfile.TempFolders)
                    {
                        await this.filesAndFolders.DeleteFolderAsync(Path.Join(profileDirectory, subFolder));
                    }

                    break;
                case ProfileActionDefinition.RunCustomScripts:
                    foreach (var customDirectory in this.CustomScriptsLocation)
                    {
                        if (this.filesAndFolders.CheckDirectory(Path.Join(profileDirectory, customDirectory)))
                        {
                            // await this.ExecuteCustomScriptAsync(customDirectory, profileDirectory);
                        }
                    }

                    break;
                default:
                    // todo: log error;
                    break;
            }
        }

        /// <summary>
        /// Executes Custom Scripts.
        /// </summary>
        /// <param name="customScriptsLocation">The Custom Scripts Directory.</param>
        /// <param name="userProfileDirectory">The User Profile Directorys.</param>
        // private async Task ExecuteCustomScriptAsync(string customScriptsLocation, string userProfileDirectory)
        // {
        // }
    }
}
