// <copyright file="GUIElements.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.GUI.Classes
{
    using System.ComponentModel;
    using System.Drawing.Text;
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.File.Model;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using Microsoft.Win32;

    /// <summary>
    /// Class to manage GUI Operations specific to Windows Forms.
    /// </summary>
    public class GUIElements
    {
        private const string ApplicationTitle = "EUC Profile Buddy";
        private const int BaloonTipTimeout = 1000;

        /// <summary>
        /// Display a Message Message.
        /// </summary>
        /// <param name="messageText">The message to display to the user.</param>
        public static void DisplayInformationMessage(string messageText)
        {
            MessageBox.Show(messageText, ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Display a Critical Message.
        /// </summary>
        /// <param name="messageText">The message to display to the user.</param>
        public static void DisplayCriticalMessage(string messageText)
        {
            MessageBox.Show(messageText, ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Display a Yes No Question Message.
        /// </summary>
        /// <param name="messageText">The message to display to the user.</param>
        /// <returns>A <see cref="DialogResult"/>.</returns>
        public static DialogResult DisplayYesNoMessage(string messageText)
        {
            DialogResult dialogResult = MessageBox.Show(messageText, ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult;
        }

        /// <summary>
        /// Minimize the application.
        /// </summary>
        /// <param name="form">The form to minimize.</param>
        /// <param name="notifyIcon">The Notification Icon.</param>
        /// <param name="userName">The username.</param>
        /// <param name="profileDirectory">The Profile Directory.</param>
        public static void MinimizeApplication(Form form, NotifyIcon notifyIcon, string userName, string profileDirectory)
        {
            var baloonTip = $"EUC Profile Buddy has been minimized to the system tray. Double click the icon to see profile details";
            var baloonTitle = $"{userName} - {profileDirectory}";
            notifyIcon.Visible = true;
            notifyIcon.Text = baloonTitle;
            notifyIcon.BalloonTipTitle = baloonTitle;
            notifyIcon.BalloonTipText = baloonTip;
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Minimized;
            form.Hide();
            notifyIcon.ShowBalloonTip(BaloonTipTimeout);
        }

        /// <summary>
        /// Restore the application.
        /// </summary>
        /// <param name="form">The form to restore.</param>
        /// <param name="notifyIcon">The Notification Icon.</param>
        public static void RestoreApplication(Form form, NotifyIcon notifyIcon)
        {
            notifyIcon.Visible = false;
            form.ShowInTaskbar = true;
            form.WindowState = FormWindowState.Normal;
            form.Show();
        }

        /// <summary>
        /// Update a label text property.
        /// </summary>
        /// <param name="label">The Label to Update.</param>
        /// <param name="text">The Text for the Label.</param>
        public static void UpdateLabel(Label label, string text)
        {
            label.Text = text;
        }

        /// <summary>
        /// Update Folder Size DataGrid.
        /// </summary>
        /// <param name="folder">The root folder.</param>
        /// <param name="dataGridView">The data grid view.</param>
        public static void UpdateFolderDataGrid(string folder, DataGridView dataGridView)
        {
            IFilesAndFolders filesAndFolders = new FilesAndFolders();

            dataGridView.Rows.Clear();

            List<TreeSize> profileFolders = filesAndFolders.BuildTreeSizeFolders(folder);
            foreach (var localFolder in profileFolders)
            {
                dataGridView.Rows.Add(localFolder.FolderName, localFolder.Size);
            }

            List<TreeSize> profileFiles = filesAndFolders.BuildTreeSizeFiles(folder);
            foreach (var localFile in profileFiles)
            {
                dataGridView.Rows.Add(localFile.FolderName, localFile.Size);
            }
        }

        /// <summary>
        /// Sets the mouse cursor to busy.
        /// </summary>
        public static void SetMouseBusy()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        /// <summary>
        /// Sets the mouse cursor to normal.
        /// </summary>
        public static void SetMouseNotBusy()
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Update Profile Detail DataGrid.
        /// </summary>
        /// <param name="profileType">The Profile Type.</param>
        /// <param name="dataGridView">The Datagrid to update.</param>
        public static void UpdateProfileDetailDataGrid(string profileType, DataGridView dataGridView)
        {
            IProfile profile = new Profile();

            dataGridView.Rows.Clear();

            var profileDetail = new List<RegistryPathValue>();

            switch (profileType)
            {
                case "Local":
                    profileDetail = profile.GetProfileDetails("Local");
                    break;
                case "Citrix":
                    profileDetail = profile.GetProfileDetails("Citrix");
                    break;
                case "FSLogix":
                    profileDetail = profile.GetProfileDetails("FSLogix");
                    break;
            }

            foreach (var localValue in profileDetail)
            {
                dataGridView.Rows.Add(localValue.Key, localValue.Value);
            }
        }

        /// <summary>
        /// Update Folder Redirection Detail DataGrid.
        /// </summary>
        /// <param name="dataGridView">The datagrid view.</param>
        public static void UpdateFolderRedirectionDataGrid(DataGridView dataGridView)
        {
            IProfile profile = new Profile();

            dataGridView.Rows.Clear();

            var folderRedirectionDetail = new List<RegistryPathValue>();
            folderRedirectionDetail = profile.GetFolderRedirectionDetails();

            dataGridView.Rows.Clear();

            foreach (var localValue in folderRedirectionDetail)
            {
                dataGridView.Rows.Add(localValue.Key, localValue.Value);
            }
        }

        /// <summary>
        /// Sort a datagrid view.
        /// </summary>
        /// <param name="dataGridView">The datagrid view.</param>
        /// <param name="clickedButton">The button clicked to sort.</param>
        public static void SortDataGrid(DataGridView dataGridView, Button clickedButton)
        {
            switch (clickedButton.Text)
            {
                case "Asc":
                    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
                    clickedButton.Text = "Desc";
                    break;
                case "Desc":
                    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Descending);
                    clickedButton.Text = "Asc";
                    break;
            }
        }

        /// <summary>
        /// Size a datagrid view.
        /// </summary>
        /// <param name="dataGridView">The datagrid view.</param>
        public static void SizeDataGrid(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (i == (dataGridView.Columns.Count - 1))
                {
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
        }

        /// <summary>
        /// Loads the Actions.
        /// </summary>
        /// <param name="comboBox">The datagrid view.</param>
        /// <param name="profile">The profile.</param>
        public static void LoadActions(ComboBox comboBox, IProfile profile)
        {
            comboBox.Items.Clear();

            if (profile != null)
            {
                foreach (var action in profile.Actions)
                {
                    comboBox.Items.Add(action);
                }
            }

            comboBox.Text = "Select Action";
        }

        /// <summary>
        /// Execute the Actions.
        /// </summary>
        /// <param name="comboBox">The datagrid view.</param>
        /// /// <param name="profileDirectory">The profile directory.</param>
        public static void ExecuteAction(ComboBox comboBox, string profileDirectory)
        {
            IProfile profile = new Profile();
            profile.ExecuteAction(comboBox.Text, profileDirectory);
        }
    }
}
