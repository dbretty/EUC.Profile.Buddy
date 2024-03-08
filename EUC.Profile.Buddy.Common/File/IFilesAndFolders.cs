// <copyright file="IFilesAndFolders.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.File
{
    /// <summary>
    /// Interface for the FilesAndFolders Class.
    /// </summary>
    public interface IFilesAndFolders
    {
        /// <summary>
        /// Gets a directory size based on a path.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to size.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public long DirectorySize(DirectoryInfo directory);

        /// <summary>
        /// Formats the folder size from byte to a readable number.
        /// </summary>
        /// <param name="bytes">The Folder Size in Bytes.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public string FormatFileSize(long bytes);
    }
}