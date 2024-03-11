// <copyright file="IFilesAndFolders.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.File
{
    using EUC.Profile.Buddy.Common.File.Model;

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

        /// <summary>
        /// Builds a directory tree size list.
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public List<TreeSize> BuildTreeSizeFolders(string rootFolder, bool sorted = true);
        public List<TreeSize> BuildTreeSizeFiles(string rootFolder, bool sorted = true);
    }
}