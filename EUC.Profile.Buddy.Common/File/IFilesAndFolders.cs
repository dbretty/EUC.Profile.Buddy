// <copyright file="IFilesAndFolders.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
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
        /// Gets a directory size based on a path (Async).
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to size.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task<long> DirectorySizeAsync(DirectoryInfo directory);

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

        /// <summary>
        /// Builds a directory tree size list (Async).
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task<List<TreeSize>> BuildTreeSizeFoldersAsync(string rootFolder, bool sorted = true);

        /// <summary>
        /// Builds a file tree size list.
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public List<TreeSize> BuildTreeSizeFiles(string rootFolder, bool sorted = true);

        /// <summary>
        /// Builds a file tree size list.
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task<List<TreeSize>> BuildTreeSizeFilesAsync(string rootFolder, bool sorted = true);

        /// <summary>
        /// Deletes a folder.
        /// </summary>
        /// <param name="folderName">The root folder to build the tree from.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public Task DeleteFolderAsync(string folderName);
    }
}