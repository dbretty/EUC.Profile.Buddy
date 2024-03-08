// <copyright file="GUIElements.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.GUI.Classes
{
    using EUC.Profile.Buddy.Common.User;

    /// <summary>
    /// Class to manage GUI Operations specific to Windows Forms.
    /// </summary>
    public class GUIElements
    {
        private const string ApplicationTitle = "EUC Profile Buddy";
        private const string BaloonTip = "Application has been minimized to the system tray, double click the icon to view profile details";
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
        public static void MinimizeApplication(Form form, NotifyIcon notifyIcon)
        {
            notifyIcon.Visible = true;
            notifyIcon.Text = ApplicationTitle;
            notifyIcon.BalloonTipTitle = ApplicationTitle;
            notifyIcon.BalloonTipText = BaloonTip;
            form.ShowInTaskbar = false;
            form.WindowState = FormWindowState.Minimized;
            form.Hide();
            notifyIcon.ShowBalloonTip(BaloonTipTimeout);
        }

        /// <summary>
        /// Minimize the application.
        /// </summary>
        /// <param name="form">The form to minimize.</param>
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
    }
}
