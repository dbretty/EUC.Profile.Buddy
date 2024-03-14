// <copyright file="IProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace EUC.Profile.Buddy.Common.Profile
{
    using EUC.Profile.Buddy.Common.Registry.Model;

    /// <summary>
    /// Public Interface for the Profile Class.
    /// </summary>
    public interface IProfile
    {
        /// <summary>
        /// Gets the folder redirection details from the registry.
        /// </summary>
        /// <returns>A <see cref="List"/>.</returns>
        List<RegistryPathValue> GetFolderRedirectionDetails();

        /// <summary>
        /// Gets the profile details from the registry.
        /// </summary>
        /// <param name="profileType">The type of user profile.</param>
        /// <returns>A <see cref="List"/>.</returns>
        List<RegistryPathValue> GetProfileDetails(string profileType);
    }
}