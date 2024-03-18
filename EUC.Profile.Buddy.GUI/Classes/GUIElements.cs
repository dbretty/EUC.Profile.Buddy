// <copyright file="GUIElements.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.GUI.Classes
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using EUC.Profile.Buddy.Common.File.Model;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.Profile.Model;
    using EUC.Profile.Buddy.Common.Registry.Model;

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
        public void UpdateLabel(Label label, string text)
        {
            label.Text = text;
            label.Refresh();
        }

        /// <summary>
        /// Clear the DataGrid.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        public void ClearDataGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        /// <summary>
        /// Update DataGrid.
        /// </summary>
        /// <param name="registryPathValue">The DataGrid Object.</param>
        /// <param name="dataGridView">The data grid view.</param>
        public void UpdateDataGridPathValue(List<RegistryPathValue> registryPathValue, DataGridView dataGridView)
        {
            foreach (var item in registryPathValue)
            {
               dataGridView.Rows.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Update DataGrid PV Pair.
        /// </summary>
        /// <param name="treeSize">The DataGrid Object.</param>
        /// <param name="dataGridView">The data grid view.</param>
        public void UpdateDataGrid(List<TreeSize> treeSize, DataGridView dataGridView)
        {
            foreach (var item in treeSize)
            {
                dataGridView.Rows.Add(item.FolderName, item.Size);
            }
        }

        /// <summary>
        /// Size a datagrid view.
        /// </summary>
        /// <param name="dataGridView">The datagrid view.</param>
        public void SizeDataGrid(DataGridView dataGridView)
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
        /// Sort a datagrid view.
        /// </summary>
        /// <param name="dataGridView">The datagrid view.</param>
        /// <param name="clickedButton">The button clicked to sort.</param>
        public void SortDataGrid(DataGridView dataGridView, Button clickedButton)
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
        /// Loads the Actions.
        /// </summary>
        /// <param name="comboBox">The datagrid view.</param>
        /// <param name="profile">The profile.</param>
        public void LoadActions(ComboBox comboBox, IUserProfile profile)
        {
            comboBox.Items.Clear();

            if (profile != null)
            {
                foreach (var action in profile.ProfileActions)
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
        public void ExecuteAction(ComboBox comboBox, string profileDirectory)
        {
            if (comboBox.SelectedItem is not null)
            {
                ProfileAction desiredAction = (ProfileAction)comboBox.SelectedItem;
                UserProfile profile = new UserProfile();
                profile.ExecuteAction(desiredAction.ActionDefinition, profileDirectory);
            }
        }
    }
}
