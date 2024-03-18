// <auto-generated/>
namespace EUC.Profile.Buddy.GUI
{
    using EUC.Profile.Buddy.GUI.Classes;
    using EUC.Profile.Buddy.Common.User;
    using EUC.Profile.Buddy.Common.File;
    using System.Windows.Forms;
    using EUC.Profile.Buddy.GUI.Forms;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.User.Model;

    public partial class FormMain : Form
    {
        
        IUserProfile profile = new UserProfile();
        IFilesAndFolders filesAndFolders = new FilesAndFolders();
        IUserDetail user = new UserDetail();
        GUIElements guiElements = new GUIElements();

        public FormMain()
        {
            this.InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            //GUIElements.MinimizeApplication(this, this.NotifyMain, user.UserName, user.ProfileDirectory);

            EnableUi(false, "Getting user data");

            guiElements.ClearDataGrid(this.dgUserProfileFolders);
            var treeSizeFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(user.ProfileDirectory);
            guiElements.UpdateDataGrid(treeSizeFolders, this.dgUserProfileFolders);
            var treeSizeFiles = await filesAndFolders.BuildTreeSizeFilesAsync(user.ProfileDirectory);
            guiElements.UpdateDataGrid(treeSizeFiles, this.dgUserProfileFolders);

            guiElements.UpdateLabel(lblUserName, user.UserName);
            guiElements.UpdateLabel(lblProfileDirectory, user.ProfileDirectory);
            guiElements.UpdateLabel(lblProfileSize, user.ProfileSize);
            guiElements.UpdateLabel(lblCurrentDirectory, user.ProfileDirectory);
            guiElements.UpdateLabel(lblAppDataLocal, user.AppDataLocal);
            guiElements.UpdateLabel(lblAppDataRoaming, user.AppDataRoaming);
            guiElements.UpdateLabel(lblProfileType, user.UserProfileType.ToString());
            guiElements.SizeDataGrid(this.dgUserProfileFolders);
            guiElements.LoadActions(this.cmbActions, profile);

            EnableUi(true);

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
                Application.Exit();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = GUIElements.DisplayYesNoMessage("Are you sure you want to quit?");
            if (dialogResult == DialogResult.Yes)
            {
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

            guiElements.ClearDataGrid(this.dgUserProfileFolders);
            guiElements.UpdateLabel(lblCurrentDirectory, this.lblProfileDirectory.Text);

            var newFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(user.ProfileDirectory);
            guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
            var newFiles = await filesAndFolders.BuildTreeSizeFilesAsync(user.ProfileDirectory);
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

                guiElements.ClearDataGrid(this.dgUserProfileFolders);
                guiElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);

                var newFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                var newFiles = await filesAndFolders.BuildTreeSizeFilesAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);
                
                EnableUi(true);
            }
            else
            {
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

                guiElements.ClearDataGrid(this.dgUserProfileFolders);
                guiElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);

                var newFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                var newFiles = await filesAndFolders.BuildTreeSizeFilesAsync(trimmedFolder);
                guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);
                
                EnableUi(true);
            }
            else
            {
                GUIElements.DisplayCriticalMessage($"You cannot roam above the root User Profile directory of {this.lblProfileDirectory.Text}");
            }
        }

        private async void drilldownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgUserProfileFolders.CurrentCell.ColumnIndex == 0)
            {
                var currentValue = dgUserProfileFolders.CurrentCell.Value.ToString();
                EnableUi(false, "Drilldown to folder");

                guiElements.ClearDataGrid(this.dgUserProfileFolders);
                guiElements.UpdateLabel(lblCurrentDirectory, currentValue);

                var newFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(currentValue);
                guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                var newFiles = await filesAndFolders.BuildTreeSizeFilesAsync(currentValue);
                guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);
                
                EnableUi(true);
            }
        }

        private void btnProfileDetail_Click(object sender, EventArgs e)
        {
            FormDetail formDetail = new FormDetail(user.UserProfileType, user.ProfileDefinition, this.lblUserName.Text, this.lblProfileDirectory.Text);

          formDetail.ShowDialog();
        }

        
        private void btnGo_Click(object sender, EventArgs e)
        {
            EnableUi(false, "Executing selected action");

            guiElements.ExecuteAction(this.cmbActions, this.lblProfileDirectory.Text);
            user.UpdateProfileSize(user.ProfileDirectory);
            guiElements.UpdateLabel(lblProfileSize, user.ProfileSize);
            GUIElements.DisplayInformationMessage($"Action {this.cmbActions.Text} Completed");
            guiElements.LoadActions(this.cmbActions, profile);

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
                    EnableUi(false, "Deleting folder");

                    IFilesAndFolders filesAndFolders = new FilesAndFolders();
                    filesAndFolders.DeleteFolderAsync((string)folderToDelete);

                    user.UpdateProfileSizeAsync(user.ProfileDirectory);
                    guiElements.UpdateLabel(lblProfileSize, user.ProfileSize);

                    guiElements.ClearDataGrid(this.dgUserProfileFolders);

                    var newFolders = await filesAndFolders.BuildTreeSizeFoldersAsync(this.lblCurrentDirectory.Text);
                    guiElements.UpdateDataGrid(newFolders, this.dgUserProfileFolders);
                    var newFiles = await filesAndFolders.BuildTreeSizeFilesAsync(this.lblCurrentDirectory.Text);
                    guiElements.UpdateDataGrid(newFiles, this.dgUserProfileFolders);

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
    }
}
