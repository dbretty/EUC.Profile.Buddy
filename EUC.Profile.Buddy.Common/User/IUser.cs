// <copyright file="IUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.User
{
    /// <summary>
    /// Public Interface for the WindowsRegistry Class.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets The UserName.
        /// </summary>
        public string? UserName { get; }

        /// <summary>
        /// Gets The Domain.
        /// </summary>
        public string? Domain { get; }

        /// <summary>
        /// Gets The Profile Directory.
        /// </summary>
        public string? ProfileDirectory { get; }

        /// <summary>
        /// Gets The AppData Local.
        /// </summary>
        public string? AppDataLocal { get; }

        /// <summary>
        /// Gets The AppData Roaming.
        /// </summary>
        public string? AppDataRoaming { get; }

        /// <summary>
        /// Gets The Profile Size.
        /// </summary>
        public string? ProfileSize { get; }

        /// <summary>
        /// Updates the Profile Size.
        /// </summary>
        /// <param name="profileDirectory">The profile directory.</param>
        /// <returns>A string.</returns>
        public string UpdateProfileSize(string profileDirectory);
    }
}