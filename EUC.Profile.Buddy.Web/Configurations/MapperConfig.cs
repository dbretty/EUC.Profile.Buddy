// <copyright file="MapperConfig.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Configurations
{
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories.Entities;
    using static MudBlazor.CategoryTypes;

    /// <summary>
    /// Mapper Config Class.
    /// </summary>
    public class MapperConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperConfig"/> class.
        /// </summary>
        public MapperConfig()
        {
            this.CreateMap<TaskInformation, TaskInformationDto>()
                .ForMember(
                    dest => dest.TaskID,
                    act => act.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.UserName,
                    act => act.MapFrom(src => src.UserName))
                .ForMember(
                    dest => dest.TaskName,
                    act => act.MapFrom(src => src.TaskName))
                .ForMember(
                    dest => dest.TaskExecutedTime,
                    act => act.MapFrom(src => src.TaskExecuted))
                .ForMember(
                    dest => dest.TaskCurrentState,
                    act => act.MapFrom(src => src.TaskState))
                .ReverseMap();

            this.CreateMap<UserProfileSummary, UserProfileSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    act => act.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.UserName,
                    act => act.MapFrom(src => src.UserName))
                .ForMember(
                    dest => dest.ProfileSize,
                    act => act.MapFrom(src => src.ProfileSize))
                .ForMember(
                    dest => dest.ProfileType,
                    act => act.MapFrom(src => src.ProfileType))
                .ForMember(
                    dest => dest.LastUpdated,
                    act => act.MapFrom(src => src.LastUpdated))
                .ReverseMap();
        }
    }
}
