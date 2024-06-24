﻿// <auto-generated/>
using EUC.Profile.Buddy.Common.ApiClient;
using EUC.Profile.Buddy.Common.Configuration;
using EUC.Profile.Buddy.Common.Profile.Model;
using EUC.Profile.Buddy.GUI.Classes;
using Microsoft.Win32;

namespace EUC.Profile.Buddy.GUI.Forms
{
    public partial class FormSettings : Form
    {
        private Form FormMain;
        private bool firstLoad = true;

        GUIElements guiElements = new GUIElements();
        IAppConfig EUCProfileBuddy = new AppConfig();

        public FormSettings(Form formMain)
        {
            InitializeComponent();
            this.FormMain = formMain;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            EUCProfileBuddy.Logger.LogAsync($"Closing settings screen");
            this.Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) - (this.FormMain.Height + 3));

            EUCProfileBuddy.Logger.LogAsync($"Loading settings screen");
            switch (EUCProfileBuddy.ClearTempAtStart)
            {
                case "Yes":
                    this.chkClearTempAtStart.Checked = true;
                    break;
                case "No":
                    this.chkClearTempAtStart.Checked = false;
                    break;
                default:
                    this.chkClearTempAtStart.Checked = false;
                    break;
            }
            firstLoad = false;
        }

        private async void Clicked(object sender, EventArgs e)
        {
            if (!firstLoad)
            {
                if (chkClearTempAtStart.Checked == true)
                {
                    if (EUCProfileBuddy.LogToServer == "Yes")
                    {
                        TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();
                        taskInformationPostDto.TaskName = "Set Clear Temp Files at Startup to Yes";
                        taskInformationPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                        taskInformationPostDto.TaskState = EUCTaskState.Completed;
                        await EUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                    }
                    EUCProfileBuddy.Registry.SetRegistryValue("ClearTempAtStart", EUCProfileBuddy.AppRegistryKey, "Yes", RegistryHive.CurrentUser);
                    EUCProfileBuddy.Logger.LogAsync($"Updated ClearTempAtStart: Yes");
                    this.lblStatus.Text = "Saved setting, ClearTempAtStart: Yes";

                }
                else
                {
                    if (EUCProfileBuddy.LogToServer == "Yes")
                    {
                        TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();
                        taskInformationPostDto.TaskName = "Set Clear Temp Files at Startup to No";
                        taskInformationPostDto.UserName = EUCProfileBuddy.UserDetail.UserName;
                        taskInformationPostDto.TaskState = EUCTaskState.Completed;
                        await EUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                    }
                    EUCProfileBuddy.Registry.SetRegistryValue("ClearTempAtStart", EUCProfileBuddy.AppRegistryKey, "No", RegistryHive.CurrentUser);
                    EUCProfileBuddy.Logger.LogAsync($"Updated ClearTempAtStart: No");
                    this.lblStatus.Text = "Saved setting, ClearTempAtStart: No";
                }
            }  
        }
    }
}
