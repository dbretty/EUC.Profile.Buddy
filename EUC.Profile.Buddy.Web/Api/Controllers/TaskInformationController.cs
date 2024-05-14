// <copyright file="TaskInformationController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories;
    using EUC.Profile.Buddy.Web.Repositories.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Task Information Controller Class.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskInformationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProfileDataRepository _profileDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInformationController"/> class.
        /// </summary>
        /// <param name="mapper">The automapper.</param>
        /// <param name="profileDataRepository">The Datasource.</param>
        public TaskInformationController(IMapper mapper, ProfileDataRepository profileDataRepository)
        {
            this._mapper = mapper;
            this._profileDataRepository = profileDataRepository;
        }

        /// <summary>
        /// Gets all the Task Information records.
        /// </summary>
        /// <returns>A list of all the Task Information items.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TaskInformation
        ///     {}
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="400">If the item is null.</response>
        [HttpGet]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TaskInformationDto>>> GetAllTaskInformation()
        {
            var taskInformation = await this._profileDataRepository.TaskInformation.OrderByDescending(
                x => x.TaskExecuted).ToListAsync();

            if (taskInformation is null)
            {
                return this.BadRequest("No tasks available");
            }
            else
            {
                var returnData = this._mapper.Map<List<TaskInformationDto>>(taskInformation);
                return this.Ok(returnData);
            }
        }

        /// <summary>
        /// Gets a specific Task information Record.
        /// </summary>
        /// <param name="id">The Task Information ID.</param>
        /// <returns>A <see cref="Task{TaskInformationDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TaskInformation{id}
        ///     {
        ///         id: Guid
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpGet("{id}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK)]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TaskInformationDto>>> GetTaskInformationByID(Guid id)
        {
            var existingTask = await this._profileDataRepository.TaskInformation
                .Where(x => x.Id == id)
                .ToListAsync();

            if (existingTask is null)
            {
                return this.NotFound($"Task ID {id} not found");
            }
            else
            {
                var returnData = this._mapper.Map<List<TaskInformationDto>>(existingTask);
                return this.Ok(returnData);
            }
        }

        /// <summary>
        /// Adds a new Task information record.
        /// </summary>
        /// <param name="taskInformationDto"> the request for the operation.</param>
        /// <returns>A <see cref="Task{TaskInformationDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /TaskInformation
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
        public async Task<IActionResult> AddTaskInformation([FromBody] TaskInformationDto taskInformationDto)
        {
            var existingTask = await this._profileDataRepository.TaskInformation
                .Where(x => x.Id == taskInformationDto.TaskID)
                .FirstOrDefaultAsync();

            if (existingTask is null)
            {
                var taskInformationData = this._mapper.Map<TaskInformation>(taskInformationDto);
                this._profileDataRepository.TaskInformation.Add(taskInformationData);
                await this._profileDataRepository.SaveChangesAsync();
                return this.Ok(taskInformationDto);
            }
            else
            {
                return this.BadRequest($"Unable to add task with TaskID: {taskInformationDto.TaskID} because it already exists");
            }
        }
    }
}
