// <auto-generated/>
namespace EUC.Profile.Buddy.GUI
{
    using EUC.Profile.Buddy.GUI.Classes;
    using System.Windows.Forms;
    using EUC.Profile.Buddy.GUI.Forms;
    using System.IO;
    using EUC.Profile.Buddy.Common.Profile.Model;
    using EUC.Profile.Buddy.Common.Configuration;
    using EUC.Profile.Buddy.Common.Logging.Model;
    using EUC.Profile.Buddy.Common.ApiClient;
    using System.IO.Pipes;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.User.Model;
    using System.Threading.Tasks;
    using Microsoft.Win32;

    public partial class FormMain : Form
    {
        GUIElements guiElements = new GUIElements();
        IAppConfig EUCProfileBuddy = new AppConfig();

        public FormMain()
        {
            this.InitializeComponent();

        }

        private async void FormMain_Load(object sender, EventArgs e)
        {

            EUCProfileBuddy.Logger.LogAsync("Starting Application");

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            GUIElements.MinimizeApplication(this, this.NotifyMain, EUCProfileBuddy.UserDetail.UserName, EUCProfileBuddy.UserDetail.ProfileDirectory);
            EnableUi(false, "Getting user data");

            EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info for: {EUCProfileBuddy.UserDetail.UserName}");
            guiElements.ClearDataGrid(this.dgUserProfileFolders);
            var treeSizeFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateDataGrid(treeSizeFolders, this.dgUserProfileFolders);
            var treeSizeFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateDataGrid(treeSizeFiles, this.dgUserProfileFolders);

            EUCProfileBuddy.Logger.LogAsync($"Updating profile labels for: {EUCProfileBuddy.UserDetail.UserName}");
            guiElements.UpdateLabel(lblUserName, EUCProfileBuddy.UserDetail.UserName);
            guiElements.UpdateLabel(lblProfileDirectory, EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateLabel(lblProfileSize, EUCProfileBuddy.UserDetail.ProfileSize);
            guiElements.UpdateLabel(lblCurrentDirectory, EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateLabel(lblAppDataLocal, EUCProfileBuddy.UserDetail.AppDataLocal);
            guiElements.UpdateLabel(lblAppDataRoaming, EUCProfileBuddy.UserDetail.AppDataRoaming);
            guiElements.UpdateLabel(lblProfileType, EUCProfileBuddy.UserDetail.UserProfileType.ToString());
            guiElements.SizeDataGrid(this.dgUserProfileFolders);
            guiElements.LoadActions(this.cmbActions, EUCProfileBuddy.UserProfile);

            if (EUCProfileBuddy.ClearTempAtStart == "Yes")
            {

                Guid taskID = new Guid();
                TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();

                if (EUCProfileBuddy.LogToServer == "Yes")
                {
                    taskInformationPostDto.TaskName = "Clearing Temp Files at Startup";
                    taskInformationPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                    taskInformationPostDto.TaskState = EUCTaskState.Running;

                    var Result = await EUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                    taskID = Result.Id;
                }

                ProfileAction desiredAction = (ProfileAction)EUCProfileBuddy.UserProfile.ProfileActions[0];
                EUCProfileBuddy.Logger.LogAsync($"Running startup action: Clear Temp At Start");
                EUCProfileBuddy.UserProfile.ExecuteAction(desiredAction.ActionDefinition, this.lblProfileDirectory.Text, EUCProfileBuddy.UserProfile);

                if (EUCProfileBuddy.LogToServer == "Yes")
                {
                    taskInformationPostDto.TaskState = EUCTaskState.Completed;
                    await EUCProfileBuddy.TaskInformationClient.UpdateTaskInformationAsync(taskID, taskInformationPostDto);
                }
            }

            EnableUi(true);
            guiElements.UpdateLabel(lblProfileSize, await EUCProfileBuddy.UserDetail.UpdateProfileSizeAsync(this.lblProfileDirectory.Text));

            if (EUCProfileBuddy.LogToServer == "Yes")
            {
                Guid taskUserID = new Guid();
                UserProfileSummaryPostDto userProfileSummaryPostDto = new UserProfileSummaryPostDto();
                userProfileSummaryPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                switch (EUCProfileBuddy.UserDetail.ProfileDefinition)
                {
                    case ProfileTypeDefinition.Local:
                        userProfileSummaryPostDto.ProfileType = EUCProfileType.Local;
                        break;
                    case ProfileTypeDefinition.Citrix:
                        userProfileSummaryPostDto.ProfileType = EUCProfileType.CitrixProfileManager;
                        break;
                    case ProfileTypeDefinition.FSLogix:
                        userProfileSummaryPostDto.ProfileType = EUCProfileType.FSLogix;
                        break;
                }
                userProfileSummaryPostDto.ProfileSize = (long)EUCProfileBuddy.UserDetail.ProfileSizeRaw;

                long tempSize = 0;
                foreach (var folder in EUCProfileBuddy.UserProfile.TempFolders)
                {
                    var tempFolder = Path.Join(EUCProfileBuddy.UserDetail.ProfileDirectory, folder);
                    if (Directory.Exists(tempFolder))
                    {
                        var tempHoldingLocation = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(tempFolder);
                        foreach (var x in tempHoldingLocation)
                        {
                            tempSize = (long)(tempSize + x.RawSize);
                        }
                    }
                }
                userProfileSummaryPostDto.TempSize = tempSize;

                if (EUCProfileBuddy.UserProfileGuid == Guid.Empty)
                {
                    var Result = await EUCProfileBuddy.UserProfileSummaryClient.AddUserProfileAsync(userProfileSummaryPostDto);
                    taskUserID = Result.Id;

                    EUCProfileBuddy.Registry.SetRegistryValue("UserProfileGuid", EUCProfileBuddy.AppRegistryKey, taskUserID, RegistryHive.CurrentUser);
                }
                else
                {
                    var Result = await EUCProfileBuddy.UserProfileSummaryClient.UpdateUserProfileAsync(EUCProfileBuddy.UserProfileGuid, userProfileSummaryPostDto);
                    taskUserID = Result.Id;
                }

            }
        }

        private void NotifyMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GUIElements.RestoreApplication(this, this.NotifyMain);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            GUIElements.MinimizeApplication(this, this.NotifyMain, this.lblUserName.Text, this.lblProfileDirectory.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = GUIElements.DisplayYesNoMessage("Are you sure you want to quit?");
            if (dialogResult == DialogResult.Yes)
            {
                EUCProfileBuddy.Logger.LogAsync($"Stopping Application");
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = GUIElements.DisplayYesNoMessage("Are you sure you want to quit?");
            if (dialogResult == DialogResult.Yes)
            {
                EUCProfileBuddy.Logger.LogAsync($"Stopping Application");
                Application.Exit();
            }
        }

        private void showDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIElements.RestoreApplication(this, this.NotifyMain);
        }

        private async void btnHome_Click(object sender, EventArgs e)
        {
            EnableUi(false, "Navigating to home directory");

            EUCProfileBuddy.Logger.LogAsync($"Navigating to home directory");

            guiElements.ClearDataGrid(this.dgUserProfileFolders);
            guiElements.UpdateLabel(lblCurrentDirectory, this.lblProfileDirectory.Text);

            EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({EUCProfileBuddy.UserDetail.ProfileDirectory}) for: {EUCProfileBuddy.UserDetail.UserName}");
            var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
            var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(EUCProfileBuddy.UserDetail.ProfileDirectory);
            guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

            EnableUi(true);
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            var lastFolder = this.lblCurrentDirectory.Text;
            if (lastFolder != this.lblProfileDirectory.Text)
            {
                EnableUi(false, "Navigating back a directory");
                var trimmedFolder = lastFolder.Substring(0, lastFolder.LastIndexOf("\\"));

                EUCProfileBuddy.Logger.LogAsync($"Navigating back a directory");

                guiElements.ClearDataGrid(this.dgUserProfileFolders);
                guiElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);

                EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({trimmedFolder}) for: {EUCProfileBuddy.UserDetail.UserName}");
                var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

                EnableUi(true);
            }
            else
            {
                EUCProfileBuddy.Logger.LogAsync($"User tried to navigate outside of the root profile folder directory.", LogLevel.WARNING);
                GUIElements.DisplayCriticalMessage($"You cannot roam above the root User Profile directory of {this.lblProfileDirectory.Text}");
            }
        }

        private async void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lastFolder = this.lblCurrentDirectory.Text;
            if (lastFolder != this.lblProfileDirectory.Text)
            {
                EnableUi(false, "Navigating back a directory");
                var trimmedFolder = lastFolder.Substring(0, lastFolder.LastIndexOf("\\"));

                EUCProfileBuddy.Logger.LogAsync($"Navigating back a directory");

                guiElements.ClearDataGrid(this.dgUserProfileFolders);
                guiElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);

                EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({trimmedFolder}) for: {EUCProfileBuddy.UserDetail.UserName}");
                var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

                EnableUi(true);
            }
            else
            {
                EUCProfileBuddy.Logger.LogAsync($"User tried to navigate outside of the root profile folder directory.", LogLevel.WARNING);
                GUIElements.DisplayCriticalMessage($"You cannot roam above the root User Profile directory of {this.lblProfileDirectory.Text}");
            }
        }

        private async void drilldownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgUserProfileFolders.CurrentCell.ColumnIndex == 0)
            {
                var currentValue = dgUserProfileFolders.CurrentCell.Value.ToString();
                if (currentValue.IndexOf('\\') > 0)
                {
                    EnableUi(false, "Drilldown to folder");

                    EUCProfileBuddy.Logger.LogAsync($"Drilldown to folder");

                    guiElements.ClearDataGrid(this.dgUserProfileFolders);
                    guiElements.UpdateLabel(lblCurrentDirectory, currentValue);

                    EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({currentValue}) for: {EUCProfileBuddy.UserDetail.UserName}");
                    var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(currentValue);
                    guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                    var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(currentValue);
                    guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

                    EnableUi(true);
                }
                else
                {
                    EUCProfileBuddy.Logger.LogAsync($"User tried to drilldown into a file ({currentValue}).", LogLevel.WARNING);
                    GUIElements.DisplayCriticalMessage("Cannot drilldown into a file");
                }
            }
        }

        private void btnProfileDetail_Click(object sender, EventArgs e)
        {
            FormDetail formDetail = new FormDetail(EUCProfileBuddy.UserDetail.UserProfileType, EUCProfileBuddy.UserDetail.ProfileDefinition, this.lblUserName.Text, this.lblProfileDirectory.Text);
            EUCProfileBuddy.Logger.LogAsync($"Showing profile details form for: {EUCProfileBuddy.UserDetail.UserName}");
            formDetail.ShowDialog();
        }


        private async void btnGo_Click(object sender, EventArgs e)
        {
            EnableUi(false, "Executing selected action");

            Guid taskID = new Guid();
            TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();

            if (EUCProfileBuddy.LogToServer == "Yes")
            {
                taskInformationPostDto.TaskName = $"Running action: {this.cmbActions.Text}";
                taskInformationPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                taskInformationPostDto.TaskState = EUCTaskState.Running;

                var Result = await EUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                taskID = Result.Id;
            }

            ProfileAction desiredAction = (ProfileAction)this.cmbActions.SelectedItem;

            EUCProfileBuddy.Logger.LogAsync($"Running action: {this.cmbActions.Text}");
            EUCProfileBuddy.UserProfile.ExecuteAction(desiredAction.ActionDefinition, this.lblProfileDirectory.Text, EUCProfileBuddy.UserProfile);

            GUIElements.DisplayInformationMessage($"Action: {this.cmbActions.Text} Completed");

            guiElements.LoadActions(this.cmbActions, EUCProfileBuddy.UserProfile);

            if (EUCProfileBuddy.LogToServer == "Yes")
            {
                taskInformationPostDto.TaskState = EUCTaskState.Completed;
                await EUCProfileBuddy.TaskInformationClient.UpdateTaskInformationAsync(taskID, taskInformationPostDto);
            }

            EnableUi(true);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgUserProfileFolders.CurrentCell.ColumnIndex == 0)
            {
                var folderToDelete = this.dgUserProfileFolders.CurrentCell.Value;
                DialogResult dialogResult = GUIElements.DisplayYesNoMessage($"Are you sure you want to delete {folderToDelete}?");
                if (dialogResult == DialogResult.Yes)
                {
                    EnableUi(false, "Deleting file or folder");

                    Guid taskID = new Guid();
                    TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();

                    if (EUCProfileBuddy.LogToServer == "Yes")
                    {
                        taskInformationPostDto.TaskName = $"Deleting folder: {(string)folderToDelete}";
                        taskInformationPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                        taskInformationPostDto.TaskState = EUCTaskState.Running;

                        var Result = await EUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                        taskID = Result.Id;
                    }

                    string selectedItem = (string)folderToDelete;
                    if (selectedItem.IndexOf('\\') > 0)
                    {
                        EUCProfileBuddy.Logger.LogAsync($"Deleting folder: {(string)folderToDelete}");
                        EUCProfileBuddy.FilesAndFolders.DeleteFolderAsync((string)folderToDelete);
                    }
                    else
                    {
                        var fileToDelete = Path.Combine(
                            this.lblCurrentDirectory.Text,
                            selectedItem);
                        EUCProfileBuddy.Logger.LogAsync($"Deleting file: {fileToDelete}");
                        EUCProfileBuddy.FilesAndFolders.DeleteFileAsync(fileToDelete);
                    }

                    EUCProfileBuddy.UserDetail.UpdateProfileSizeAsync(EUCProfileBuddy.UserDetail.ProfileDirectory);
                    guiElements.UpdateLabel(lblProfileSize, EUCProfileBuddy.UserDetail.ProfileSize);

                    guiElements.ClearDataGrid(this.dgUserProfileFolders);

                    EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({this.lblCurrentDirectory.Text}) for: {EUCProfileBuddy.UserDetail.UserName}");
                    var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(this.lblCurrentDirectory.Text);
                    guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                    var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(this.lblCurrentDirectory.Text);
                    guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

                    if (EUCProfileBuddy.LogToServer == "Yes")
                    {
                        taskInformationPostDto.TaskState = EUCTaskState.Completed;
                        await EUCProfileBuddy.TaskInformationClient.UpdateTaskInformationAsync(taskID, taskInformationPostDto);
                    }

                    EnableUi(true);
                }
            }
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
            this.btnMinimize.Enabled = enabled;
            this.btnBack.Enabled = enabled;
            this.btnHome.Enabled = enabled;
            this.btnProfileDetail.Enabled = enabled;
            this.btnGo.Enabled = enabled;
            this.cmbActions.Enabled = enabled;
            this.lblStatus.Text = labelText;
        }

        private async void dgFoldersDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUserProfileFolders.CurrentCell.ColumnIndex == 0)
            {
                var currentValue = dgUserProfileFolders.CurrentCell.Value.ToString();
                if (currentValue.IndexOf('\\') > 0)
                {
                    EnableUi(false, "Drilldown to folder");

                    EUCProfileBuddy.Logger.LogAsync($"Drilldown to folder");

                    guiElements.ClearDataGrid(this.dgUserProfileFolders);
                    guiElements.UpdateLabel(lblCurrentDirectory, currentValue);

                    EUCProfileBuddy.Logger.LogAsync($"Loading profile file and folder info ({currentValue}) for: {EUCProfileBuddy.UserDetail.UserName}");
                    var newFolders = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFoldersAsync(currentValue);
                    guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                    var newFiles = await EUCProfileBuddy.FilesAndFolders.BuildTreeSizeFilesAsync(currentValue);
                    guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

                    EnableUi(true);
                }
                else
                {
                    EUCProfileBuddy.Logger.LogAsync($"User tried to drilldown into a file ({currentValue}).", LogLevel.WARNING);
                    GUIElements.DisplayCriticalMessage("Cannot drilldown into a file");
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            EUCProfileBuddy.Logger.LogAsync($"Showing application settings screen");
            formSettings.ShowDialog();
        }
    }
}
