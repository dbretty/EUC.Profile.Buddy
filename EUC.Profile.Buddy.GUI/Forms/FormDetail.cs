﻿// <auto-generated/>
using EUC.Profile.Buddy.Common.Configuration;
using EUC.Profile.Buddy.Common.Profile;
using EUC.Profile.Buddy.Common.Registry;
using EUC.Profile.Buddy.Common.User.Model;
using EUC.Profile.Buddy.GUI.Classes;
using Microsoft.Win32;

namespace EUC.Profile.Buddy.GUI.Forms
{
    public partial class FormDetail : Form
    {
        private string userProfileType;
        private string userName;
        private string profileDirectory;
        private ProfileTypeDefinition profileTypeDefinition;

        GUIElements guiElements = new GUIElements();
        IAppConfig EUCProfileBuddy = new AppConfig();

        public FormDetail(string userProfileType, ProfileTypeDefinition profileTypeDefinition, string userName, string profileDirectory)
        {
            EUCProfileBuddy.Logger.LogAsync($"Loading profile information for: {EUCProfileBuddy.UserDetail.UserName}");
            InitializeComponent();
            this.userProfileType = userProfileType;
            this.userName = userName;
            this.profileDirectory = profileDirectory;
            this.profileTypeDefinition = profileTypeDefinition;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            EUCProfileBuddy.Logger.LogAsync($"Closing profile information screen");
            this.Close();
        }

        private async void FormDetail_Load(object sender, EventArgs e)
        {
            this.Location = new Point(((Screen.PrimaryScreen.WorkingArea.Width - this.Width) - FormMain.ActiveForm.Width) - 3, (Screen.PrimaryScreen.WorkingArea.Height - this.Height));
            guiElements.UpdateLabel(this.lblProfileDetail, $"Profile Detail for {this.userName} ({this.profileDirectory})");

            EnableUi(false, "Loading profile detail");

            guiElements.ClearDataGrid(this.dgProfileDetails);
            guiElements.ClearDataGrid(this.dgFolderRedirection);

            switch (profileTypeDefinition)
            {
                case ProfileTypeDefinition.Local:
                    EUCProfileBuddy.Logger.LogAsync($"Loading profile information: Local");
                    var profileDetails = await EUCProfileBuddy.Registry.GetRegistryPathValueAsync(EUCProfileBuddy.UserProfile.LocalRootKey, RegistryHive.CurrentUser);
                    guiElements.UpdateDataGridPathValue(profileDetails, this.dgProfileDetails);
                    break;
                case ProfileTypeDefinition.Citrix:
                    EUCProfileBuddy.Logger.LogAsync($"Loading profile information: Citrix Profile Management");
                    var citrixProfileDetails = await EUCProfileBuddy.Registry.GetRegistryPathValueAsync(EUCProfileBuddy.UserProfile.CitrixRootKey, RegistryHive.LocalMachine);
                    guiElements.UpdateDataGridPathValue(citrixProfileDetails, this.dgProfileDetails);
                    break;
                case ProfileTypeDefinition.FSLogix:
                    EUCProfileBuddy.Logger.LogAsync($"Loading profile information: Microsoft FSLogix");
                    var fslogixProfileDetails = await EUCProfileBuddy.Registry.GetRegistryPathValueAsync(EUCProfileBuddy.UserProfile.FSLogixRootKey, RegistryHive.LocalMachine);
                    guiElements.UpdateDataGridPathValue(fslogixProfileDetails, this.dgProfileDetails);
                    break;
                default:
                    break;
            }

            EUCProfileBuddy.Logger.LogAsync($"Loading profile folder redirection information");
            var folderRefirectionDetails = await EUCProfileBuddy.Registry.GetRegistryPathValueAsync(EUCProfileBuddy.UserProfile.ShellFolders, RegistryHive.CurrentUser);
            guiElements.UpdateDataGridPathValue(folderRefirectionDetails, this.dgFolderRedirection);

            guiElements.SizeDataGrid(this.dgProfileDetails);
            guiElements.SizeDataGrid(this.dgFolderRedirection);

            EnableUi(true);
        }

        private void btnProfileDetailsSort_Click(object sender, EventArgs e)
        {
            EUCProfileBuddy.Logger.LogAsync($"Sorting profile information data grid");
            guiElements.SortDataGrid(this.dgProfileDetails, this.btnProfileDetailsSort);
        }

        private void btnFolderRedirectionSort_Click(object sender, EventArgs e)
        {
            EUCProfileBuddy.Logger.LogAsync($"Sorting folder redirection information data grid");
            guiElements.SortDataGrid(this.dgFolderRedirection, this.btnFolderRedirectionSort);
        }

        private void EnableUi(bool enabled, string labelText = "Ready")
        {
            if (enabled)
            {
                this.pbMain.MarqueeAnimationSpeed = 0;
                this.pbMain.Refresh();
            }
            else
            {
                this.pbMain.MarqueeAnimationSpeed = 100;
                this.pbMain.Refresh();
            }

            this.btnExit.Enabled = enabled;
            this.lblStatus.Text = labelText;
        }
    }
}
