// <copyright file="UserProfileSummaryController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Controllers
{
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories;
	using EUC.Profile.Buddy.Web.Repositories.Entities;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.WebUtilities;
	using Microsoft.EntityFrameworkCore;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Net;

    /// <summary>
    /// User Profile Summary Controller Class.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileSummaryController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly ProfileDataRepository _profileDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileSummaryController"/> class.
        /// </summary>
        /// <param name="mapper">The automapper.</param>
        /// <param name="profileDataRepository">The Datasource.</param>
        public UserProfileSummaryController(IMapper mapper, ProfileDataRepository profileDataRepository)
        {
            this._mapper = mapper;
            this._profileDataRepository = profileDataRepository;
        }

        /// <summary>
        /// Adds a new User Profile Summary record.
        /// </summary>
        /// <param name="userProfileSummaryDto"> the request for the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /UserProfileSummary
        ///     {
        ///         TaskId: Guid
        ///         UserName: "Dave Brett"
        ///         TaskName: "Task 1"
        ///         TaskExecutedTime: "12:00:30"
        ///         TaskState: 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="400">If the item already exists.</response>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddUserProfileSummary([FromBody] UserProfileSummaryDto userProfileSummaryDto)
		{
			var existingUser = await this._profileDataRepository.UserProfileSummary
				.Where(x => x.Id == userProfileSummaryDto.Id)
				.FirstOrDefaultAsync();


			if (existingUser is null)
			{
                var userProfileSummaryData = this._mapper.Map<UserProfileSummary>(userProfileSummaryDto);
                this._profileDataRepository.UserProfileSummary.Add(userProfileSummaryData);
                await this._profileDataRepository.SaveChangesAsync();
				return this.Ok(userProfileSummaryDto);
			}
            else
            {
                return this.BadRequest($"Unable to add User Profile Summary with ID: {userProfileSummaryDto.Id} because it already exists");
            }
		}
	}
}
