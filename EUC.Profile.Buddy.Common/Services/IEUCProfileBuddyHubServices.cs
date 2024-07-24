// <copyright file="IEUCProfileBuddyHubServices.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Services
{
    using EUC.Profile.Buddy.Common.Configuration;

    /// <summary>
    /// Interface to execute profile buddy hub actions.
    /// </summary>
    public interface IEUCProfileBuddyHubServices
    {
        /// <summary>
        /// Executes Process Action.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="action">The action.</param>
        /// <param name="profileDirectory">The profile directory.</param>
        /// <param name="eUCProfileBuddy">The euc profile buddy object.</param>
        void ProcessAction(string user, string action, string profileDirectory, IAppConfig eUCProfileBuddy);
    }
}