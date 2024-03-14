// <auto-generated/>
namespace EUC.Profile.Buddy.GUI
{
    using EUC.Profile.Buddy.GUI.Classes;
    using EUC.Profile.Buddy.Common.User;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Registry;
    using System.Windows.Forms;
    using EUC.Profile.Buddy.GUI.Forms;

    public partial class FormMain : Form
    {
        public FormMain()
        {
            this.InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            IUserDetail user = new UserDetail();
            GUIElements.SetMouseBusy();
            GUIElements.MinimizeApplication(this, this.NotifyMain, user.UserName, user.ProfileDirectory);
            GUIElements.UpdateLabel(lblUserName, user.UserName);
            GUIElements.UpdateLabel(lblProfileDirectory, user.ProfileDirectory);
            GUIElements.UpdateLabel(lblProfileSize, user.ProfileSize);
            GUIElements.UpdateLabel(lblCurrentDirectory, user.ProfileDirectory);
            GUIElements.UpdateLabel(lblAppDataLocal, user.AppDataLocal);
            GUIElements.UpdateLabel(lblAppDataRoaming, user.AppDataRoaming);
            GUIElements.UpdateLabel(lblProfileType, user.UserProfileType.ToString());
            GUIElements.UpdateFolderDataGrid(user.ProfileDirectory, this.dgUserProfileFolders);
            GUIElements.SizeDataGrid(this.dgUserProfileFolders);
            GUIElements.SetMouseNotBusy();

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            GUIElements.SetMouseBusy();
            GUIElements.UpdateFolderDataGrid(this.lblProfileDirectory.Text, this.dgUserProfileFolders);
            GUIElements.UpdateLabel(lblCurrentDirectory, this.lblProfileDirectory.Text);
            GUIElements.SetMouseNotBusy();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var lastFolder = this.lblCurrentDirectory.Text;
            if (lastFolder != this.lblProfileDirectory.Text)
            {
                GUIElements.SetMouseBusy();
                var trimmedFolder = lastFolder.Substring(0, lastFolder.LastIndexOf("\\"));
                GUIElements.UpdateFolderDataGrid(trimmedFolder, this.dgUserProfileFolders);
                GUIElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);
                GUIElements.SetMouseNotBusy();
            }
            else
            {
                GUIElements.DisplayCriticalMessage($"You cannot roam above the root User Profile directory of {this.lblProfileDirectory.Text}");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lastFolder = this.lblCurrentDirectory.Text;
            if (lastFolder != this.lblProfileDirectory.Text)
            {
                GUIElements.SetMouseBusy();
                var trimmedFolder = lastFolder.Substring(0, lastFolder.LastIndexOf("\\"));
                GUIElements.UpdateFolderDataGrid(trimmedFolder, this.dgUserProfileFolders);
                GUIElements.UpdateLabel(lblCurrentDirectory, trimmedFolder);
                GUIElements.SetMouseNotBusy();
            }
            else
            {
                GUIElements.DisplayCriticalMessage($"You cannot roam above the root User Profile directory of {this.lblProfileDirectory.Text}");
            }
        }

        private void drilldownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgUserProfileFolders.CurrentCell.ColumnIndex == 0)
            {
                var currentValue = dgUserProfileFolders.CurrentCell.Value.ToString();
                GUIElements.SetMouseBusy();
                GUIElements.UpdateFolderDataGrid(currentValue, this.dgUserProfileFolders);
                GUIElements.UpdateLabel(lblCurrentDirectory, currentValue);
                GUIElements.SetMouseNotBusy();
            }
        }

        private void pctHome_Click(object sender, EventArgs e)
        {
            GUIElements.SetMouseBusy();
            GUIElements.UpdateFolderDataGrid(this.lblProfileDirectory.Text, this.dgUserProfileFolders);
            GUIElements.UpdateLabel(lblCurrentDirectory, this.lblProfileDirectory.Text);
            GUIElements.SetMouseNotBusy();
        }

        private void btnProfileDetail_Click(object sender, EventArgs e)
        {
            FormDetail formDetail = new FormDetail(this.lblProfileType.Text, this.lblUserName.Text, this.lblProfileDirectory.Text);
            formDetail.ShowDialog();
        }
    }
}
