﻿// <copyright file="ProfileDataReposirotyBuilder.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories
{
    using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Design;
    using static EUC.Profile.Buddy.Web.Repositories.ProfileDataRepository;

	/// <summary>
	/// EUC Profile Buddy Data Repository Builder Class.
	/// </summary>
	public class ProfileDataRepositoryBuilder : IDesignTimeDbContextFactory<ProfileDataRepository>
	{
		/// <summary>
		/// Builds the ProfileDataRepository.
		/// </summary>
		/// <param name="args">The Builder Arguments.</param>
		/// <returns>EUCProfileBuddyDataRepository.</returns>
		public ProfileDataRepository CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ProfileDataRepository>();
			optionsBuilder.UseSqlite(
				"Data Source=Profile.Data.Repository.db");

			return new ProfileDataRepository(optionsBuilder.Options);
		}
	}
}
