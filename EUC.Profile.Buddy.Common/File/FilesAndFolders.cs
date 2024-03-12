//-----------------------------------------------------------------------
// <copyright file="FilesAndFolders.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Dave Brett</author>
//-----------------------------------------------------------------------

namespace EUC.Profile.Buddy.Common.File
{
    using System;
    using System.IO;
    using System.Linq;
    using EUC.Profile.Buddy.Common.File.Model;
    using EUC.Profile.Buddy.Common.Logging;

    /// <summary>
    /// Files and Folders Class.
    /// </summary>
    public class FilesAndFolders : IFilesAndFolders
    {
        private readonly List<string> folderFilter = new List<string>() { "AppData", "Cookies", "Desktop", "Favorites", "Local AppData", "Personal", "Recent", "Start Menu", "Templates" };
        private readonly List<string> fileFilter = new List<string>() { "ntuser", "desktop.ini" };

        private ILogger privateLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilesAndFolders"/> class.
        /// </summary>
        /// <param name="logger">The Logger interface.</param>
        public FilesAndFolders(ILogger logger)
        {
            this.privateLogger = logger;
        }

        /// <summary>
        /// Gets a directory size based on a path.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to size.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public long DirectorySize(DirectoryInfo directory)
        {
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

        /// <summary>
        /// Formats the folder size from byte to a readable number.
        /// </summary>
        /// <param name="bytes">The Folder Size in Bytes.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public string FormatFileSize(long bytes)
        {
            var unit = 1024;
            if (bytes < unit)
            {
                return $"{bytes} B";
            }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));

            return $"{bytes / Math.Pow(unit, exp):F2} {"KMGTPE"[exp - 1]}B";
        }

        /// <summary>
        /// Builds a directory tree size list.
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public List<TreeSize> BuildTreeSizeFolders(string rootFolder, bool sorted = true)
        {
            var treeView = new List<TreeSize>();

            this.privateLogger.LogAsync($"Building Folder Treeview for {rootFolder}");

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
                    this.privateLogger.LogAsync($"Adding Treeview directory item {directoryItem.FolderName} [{directoryItem.Size}]");
                }
            }

            if (sorted is true)
            {
                var treeViewReturn = new List<TreeSize>();
                treeViewReturn = treeView.OrderByDescending(x => x.RawSize).ToList();
                return treeViewReturn;
            }
            else
            {
                return treeView;
            }
        }

        /// <summary>
        /// Builds a directory tree size list.
        /// </summary>
        /// <param name="rootFolder">The root folder to build the tree from.</param>
        /// <param name="sorted">Boolean value to sort results.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public List<TreeSize> BuildTreeSizeFiles(string rootFolder, bool sorted = true)
        {
            var treeView = new List<TreeSize>();

            this.privateLogger.LogAsync($"Building File Treeview for {rootFolder}");

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
                    this.privateLogger.LogAsync($"Adding Treeview file item {directoryItem.FolderName} [{directoryItem.Size}]");
                }
            }

            if (sorted is true)
            {
                var treeViewReturn = new List<TreeSize>();
                treeViewReturn = treeView.OrderByDescending(x => x.RawSize).ToList();
                return treeViewReturn;
            }
            else
            {
                return treeView;
            }
        }

        /// <summary>
        /// Checks if a folder is in the include filter.
        /// </summary>
        /// <param name="folderName">The root folder to build the tree from.</param>
        /// <param name="folders">Boolean value to sort results.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        private bool CheckFolderFilter(string folderName, List<string> folders)
        {
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
        private bool CheckFileFilter(string folderName, List<string> files)
        {
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