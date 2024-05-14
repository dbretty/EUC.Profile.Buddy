﻿// <copyright file="ProfileType.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories.Model
{
	/// <summary>
	/// Enum to hold the profile type.
	/// </summary>
	public enum ProfileType
	{
		/// <summary>
		/// Unknown profile type.
		/// </summary>
		Unknown,

		/// <summary>
		/// Citrix Profile Manager.
		/// </summary>
		CitrixProfileManager,

		/// <summary>
		/// Microsoft FSLogix.
		/// </summary>
		FSLogix,

		/// <summary>
		/// Local.
		/// </summary>
		Local,
	}
}
