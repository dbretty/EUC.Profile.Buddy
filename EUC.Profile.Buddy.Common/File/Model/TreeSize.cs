// <copyright file="TreeSize.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.File.Model
{
    /// <summary>
    /// Files and Folders Tree SizeClass.
    /// </summary>
    public class TreeSize
    {
        /// <summary>
        /// Gets or sets the FolderName value.
        /// </summary>
        public string? FolderName { get; set; }

        /// <summary>
        /// Gets or sets the FolderName value.
        /// </summary>
        public string? Size { get; set; }

        /// <summary>
        /// Gets or sets the FolderName value.
        /// </summary>
        public long? RawSize { get; set; }
    }
}
