// <copyright file="UserProfileSummaryDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// User Profile Summary DTO Class.
    /// </summary>
    public class UserProfileSummaryDto
    {
        /// <summary>
		/// Gets or sets the Id.
		/// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the users name.
        /// </summary>
        [Required]
        required public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the size of the profile.
        /// </summary>
        [Required]
        public long ProfileSize { get; set; }

        /// <summary>
        /// Gets or sets the profile type.
        /// </summary>
        [Required]
        public ProfileType ProfileType { get; set; }

        /// <summary>
        /// Gets or sets the last updated time of this entity.
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
