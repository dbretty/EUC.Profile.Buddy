// <copyright file="TaskInformationDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// Task Information DTO Class.
    /// </summary>
    public class TaskInformationDto
    {
        /// <summary>
		/// Gets or sets the Id.
		/// </summary>
        [Required]
        public Guid TaskID { get; set; }

        /// <summary>
		/// Gets or sets the users name.
		/// </summary>
        [Required]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
		/// Gets or sets the Task Name.
		/// </summary>
        [Required]
        public string? TaskName { get; set; }

        /// <summary>
		/// Gets or sets the task executed date and time.
		/// </summary>
        [Required]
        public DateTime TaskExecutedTime { get; set; }

        /// <summary>
		/// Gets or sets the task state.
		/// </summary>
        [Required]
        public TaskState TaskCurrentState { get; set; }
    }
}
