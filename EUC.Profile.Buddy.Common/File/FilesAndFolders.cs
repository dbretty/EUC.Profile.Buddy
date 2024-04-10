//-----------------------------------------------------------------------
// <copyright file="FilesAndFolders.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>
// <author>Dave Brett</author>
//-----------------------------------------------------------------------

namespace EUC.Profile.Buddy.Common.File
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Security;
    using EUC.Profile.Buddy.Common.File.Model;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Logging.Model;

    /// <summary>
    /// Files and Folders Class.
    /// </summary>
    public class FilesAndFolders : IFilesAndFolders
    {
        /// <summary>
        /// Private ILogger interface.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Private folderFilterList.
        /// </summary>
        private readonly List<string> folderFilter = new List<string>() { "AppData", "Cookies", "Desktop", "Favorites", "Local AppData", "Personal", "Recent", "Start Menu", "Templates" };

        /// <summary>
        /// Private File Filter List.
        /// </summary>
        private readonly List<string> fileFilter = new List<string>() { "ntuser", "desktop.ini" };

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesAndFolders"/> class.
        /// </summary>
        /// <param name="logger">The logger to pass in.</param>
        public FilesAndFolders(ILogger logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task DeleteFileAsync(string fileName, int maxRetries = 5, int millisecondsDelay = 10)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileName, nameof(fileName));

            this.logger.LogAsync($"Deleting file: {fileName}");
            await Task.Run(() =>
            {
                if (fileName == null)
                {
                    this.logger.LogAsync($"File not found - {fileName}", LogLevel.ERROR);
                    throw new ArgumentNullException(nameof(fileName));
                }

                if (maxRetries < 1)
                {
                    this.logger.LogAsync($"Max Retries needs to be greater than 1", LogLevel.ERROR);
                    throw new ArgumentOutOfRangeException(nameof(maxRetries));
                }

                if (millisecondsDelay < 1)
                {
                    this.logger.LogAsync($"Milisecond delay needs to be greater than 1", LogLevel.ERROR);
                    throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));
                }

                for (int i = 0; i < maxRetries; ++i)
                {
                    try
                    {
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        this.logger.LogAsync($"File deleted: {fileName}");
                        return true;
                    }
                    catch (IOException)
                    {
                        Task.Delay(millisecondsDelay);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Task.Delay(millisecondsDelay);
                    }
                }

                this.logger.LogAsync($"File not deleted: {fileName}", LogLevel.WARNING);
                return false;
            });
        }

        /// <inheritdoc/>
        public async Task DeleteFolderAsync(string folderName, int maxRetries = 5, int millisecondsDelay = 10)
        {
            ArgumentException.ThrowIfNullOrEmpty(folderName, nameof(folderName));

            await Task.Run(() =>
            {
                if (folderName == null)
                {
                    this.logger.LogAsync($"Folder not found - {folderName}", LogLevel.ERROR);
                    throw new ArgumentNullException(nameof(folderName));
                }

                if (maxRetries < 1)
                {
                    this.logger.LogAsync($"Max Retries needs to be greater than 1", LogLevel.ERROR);
                    throw new ArgumentOutOfRangeException(nameof(maxRetries));
                }

                if (millisecondsDelay < 1)
                {
                    this.logger.LogAsync($"Milisecond delay needs to be greater than 1", LogLevel.ERROR);
                    throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));
                }

                for (int i = 0; i < maxRetries; ++i)
                {
                    try
                    {
                        if (Directory.Exists(folderName))
                        {
                            Directory.Delete(folderName, true);
                        }

                        this.logger.LogAsync($"Folder deleted: {folderName}");
                        return true;
                    }
                    catch (IOException)
                    {
                        Task.Delay(millisecondsDelay);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Task.Delay(millisecondsDelay);
                    }
                }

                this.logger.LogAsync($"Folder not deleted: {folderName}", LogLevel.WARNING);
                return false;
            });
        }

        /// <inheritdoc/>
        public long DirectorySize(DirectoryInfo directory)
        {
            ArgumentNullException.ThrowIfNull(directory, nameof(directory));

            try
            {
                long size = 0;
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }

                DirectoryInfo[] directories = directory.GetDirectories();
                foreach (DirectoryInfo subdirectory in directories)
                {
                    size += this.DirectorySize(subdirectory);
                }

                return size;
            }
            catch
            {
                return 0;
            }
        }

        /// <inheritdoc/>
        public async Task<long> DirectorySizeAsync(DirectoryInfo directory)
        {
            ArgumentNullException.ThrowIfNull(directory, nameof(directory));

            return await Task.Run(() => this.DirectorySize(directory));
        }

        /// <inheritdoc/>
        public string FormatFileSize(long bytes)
        {
            ArgumentNullException.ThrowIfNull(bytes, nameof(bytes));

            var unit = 1024;
            if (bytes < unit)
            {
                return $"{bytes} B";
            }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));

            return $"{bytes / Math.Pow(unit, exp):F2} {"KMGTPE"[exp - 1]}B";
        }

        /// <inheritdoc/>
        public List<TreeSize> BuildTreeSizeFolders(string rootFolder, bool sorted = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(rootFolder, nameof(rootFolder));

            this.logger.LogAsync($"Building folder tree size for: {rootFolder}");

            var treeView = new List<TreeSize>();

            DirectoryInfo root = new DirectoryInfo(rootFolder);
            DirectoryInfo[] directories = root.GetDirectories();
            foreach (DirectoryInfo subdirectory in directories)
            {
                if (this.CheckFolderFilter(subdirectory.FullName, this.folderFilter))
                {
                    TreeSize directoryItem = new TreeSize();
                    directoryItem.FolderName = subdirectory.FullName;
                    directoryItem.RawSize = this.DirectorySize(subdirectory);
                    directoryItem.Size = this.FormatFileSize(this.DirectorySize(subdirectory));
                    treeView.Add(directoryItem);
                }
            }

            if (sorted is true)
            {
                this.logger.LogAsync($"Sorting folder treesize (descending) for: {rootFolder}");
                var treeViewReturn = new List<TreeSize>();
                treeViewReturn = treeView.OrderByDescending(x => x.RawSize).ToList();
                return treeViewReturn;
            }
            else
            {
                return treeView;
            }
        }

        /// <inheritdoc/>
        public async Task<List<TreeSize>> BuildTreeSizeFoldersAsync(string rootFolder, bool sorted = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(rootFolder, nameof(rootFolder));
            return await Task.Run(() => this.BuildTreeSizeFolders(rootFolder, sorted = true));
        }

        /// <inheritdoc/>
        public List<TreeSize> BuildTreeSizeFiles(string rootFolder, bool sorted = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(rootFolder, nameof(rootFolder));

            this.logger.LogAsync($"Building file tree size for: {rootFolder}");

            var treeView = new List<TreeSize>();

            DirectoryInfo root = new DirectoryInfo(rootFolder);
            FileInfo[] files = root.GetFiles();

            foreach (FileInfo subFile in files)
            {
                if (!this.CheckFolderFilter(subFile.FullName, this.fileFilter))
                {
                    TreeSize directoryItem = new TreeSize();
                    directoryItem.FolderName = subFile.Name;
                    directoryItem.RawSize = subFile.Length;
                    directoryItem.Size = this.FormatFileSize((long)directoryItem.RawSize);
                    treeView.Add(directoryItem);
                }
            }

            if (sorted is true)
            {
                this.logger.LogAsync($"Sorting file treesize (descending) for: {rootFolder}");
                var treeViewReturn = new List<TreeSize>();
                treeViewReturn = treeView.OrderByDescending(x => x.RawSize).ToList();
                return treeViewReturn;
            }
            else
            {
                return treeView;
            }
        }

        /// <inheritdoc/>
        public bool CheckDirectory(string path)
        {
            ArgumentException.ThrowIfNullOrEmpty(path, nameof(path));

            FileAttributes attributes = File.GetAttributes(path);
            if (attributes.HasFlag(FileAttributes.Directory))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<List<TreeSize>> BuildTreeSizeFilesAsync(string rootFolder, bool sorted = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(rootFolder, nameof(rootFolder));
            return await Task.Run(() => this.BuildTreeSizeFiles(rootFolder, sorted = true));
        }

        /// <inheritdoc/>
        public void CreateDirectory(string folder)
        {
            ArgumentException.ThrowIfNullOrEmpty(folder, nameof(folder));

            if (!Directory.Exists(folder))
            {
                try
                {
                    Directory.CreateDirectory(folder);
                }
                catch
                {
                    throw new SecurityException();
                }
            }
        }

        /// <summary>
        /// Checks if a folder is in the include filter.
        /// </summary>
        /// <param name="folderName">The root folder to build the tree from.</param>
        /// <param name="folders">Boolean value to sort results.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private bool CheckFolderFilter(string folderName, List<string> folders)
        {
            ArgumentException.ThrowIfNullOrEmpty(folderName, nameof(folderName));
            ArgumentNullException.ThrowIfNull(folders, nameof(folders));

            var found = false;

            foreach (string folder in folders)
            {
                if (folderName.ToLower().Contains(folder.ToLower()))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        /// <summary>
        /// Checks if a file is in the include filter.
        /// </summary>
        /// <param name="folderName">The root folder to build the tree from.</param>
        /// <param name="files">Boolean value to sort results.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private bool CheckFileFilter(string folderName, List<string> files)
        {
            ArgumentException.ThrowIfNullOrEmpty(folderName, nameof(folderName));
            ArgumentNullException.ThrowIfNull(files, nameof(files));

            var found = false;

            foreach (string file in files)
            {
                if (folderName.ToLower().Contains(file.ToLower()))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}