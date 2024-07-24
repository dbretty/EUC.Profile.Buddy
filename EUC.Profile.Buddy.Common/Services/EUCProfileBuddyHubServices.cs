// <copyright file="EUCProfileBuddyHubServices.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Services
{
    using System;
    using EUC.Profile.Buddy.Common.ApiClient;
    using EUC.Profile.Buddy.Common.Configuration;
    using EUC.Profile.Buddy.Common.Profile.Model;

    /// <summary>
    /// Class to execute profile buddy hub actions.
    /// </summary>
    public class EUCProfileBuddyHubServices : IEUCProfileBuddyHubServices
    {
        /// <inheritdoc/>
        public async void ProcessAction(string user, string action, string profileDirectory, IAppConfig eUCProfileBuddy)
        {
            if (action == "ClearTempFiles")
            {
                Guid taskID = Guid.NewGuid();
                TaskInformationPostDto taskInformationPostDto = new TaskInformationPostDto();

                if (string.Equals(eUCProfileBuddy.LogToServer, "Yes", StringComparison.OrdinalIgnoreCase))
                {
                    taskInformationPostDto.TaskName = $"Server Delegated Action: Clear Temp Files";
                    taskInformationPostDto.UserName = user;
                    taskInformationPostDto.TaskState = EUCTaskState.Running;

                    var result = await eUCProfileBuddy.TaskInformationClient.AddTaskInformationAsync(taskInformationPostDto);
                    taskID = result.Id;
                }

                if (eUCProfileBuddy.UserDetail.ProfileDirectory is not null)
                {
                    eUCProfileBuddy.UserProfile.ExecuteAction(ProfileActionDefinition.ClearTempFiles, eUCProfileBuddy.UserDetail.ProfileDirectory, eUCProfileBuddy.UserProfile);
                }

                if (string.Equals(eUCProfileBuddy.LogToServer, "Yes", StringComparison.OrdinalIgnoreCase))
                {
                    taskInformationPostDto.TaskState = EUCTaskState.Completed;
                    await eUCProfileBuddy.TaskInformationClient.UpdateTaskInformationAsync(taskID, taskInformationPostDto);
                }
            }
        }
    }
}
