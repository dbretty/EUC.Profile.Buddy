// <copyright file="IUserDetail.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.User
{
    using EUC.Profile.Buddy.Common.User.Model;

    /// <summary>
    /// Public Interface for the UserDetail Class.
    /// </summary>
    public interface IUserDetail
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
        /// Gets or sets the Profile Size.
        /// </summary>
        public string? ProfileSize { get; set; }

        /// <summary>
        /// Gets the Profile Type.
        /// </summary>
        public string? UserProfileType { get; }

        /// <summary>
        /// Gets the Profile Definition.
        /// </summary>
        public ProfileTypeDefinition ProfileDefinition { get; }

        /// <summary>
        /// Update the profile size for the user.
        /// </summary>
        /// <param name="profileDirectory">The Profile Directory to get the size for.</param>
        /// <returns>A <see cref="string"/> with the profile size.</returns>
        public string UpdateProfileSize(string profileDirectory);

        /// <summary>
        /// Update the profile size for the user (async).
        /// </summary>
        /// <param name="profileDirectory">The Profile Directory to get the size for.</param>
        /// <returns>A <see cref="Task"/> with the profile size.</returns>
        public Task<string> UpdateProfileSizeAsync(string profileDirectory);
    }
}