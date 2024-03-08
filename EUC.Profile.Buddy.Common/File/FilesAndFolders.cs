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
    using EUC.Profile.Buddy.Common.User;

    /// <summary>
    /// Files and Folders Class.
    /// </summary>
    public class FilesAndFolders : IFilesAndFolders
    {
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
        public List<(string folderName, string size, long rawSize)> BuildTreeSize(string rootFolder, bool sorted = true)
        {
            long size = 0;
            var treeView = new List<(string folderName, string size, long rawSize)>();
            var treeViewReturn = new List<(string folderName, string size, long rawSize)>();

            DirectoryInfo root = new DirectoryInfo(rootFolder);
            DirectoryInfo[] directories = root.GetDirectories();
            foreach (DirectoryInfo subdirectory in directories)
            {
                size = this.DirectorySize(subdirectory);
                treeView.Add((
                    folderName: subdirectory.Name,
                    size: this.FormatFileSize(size),
                    rawSize: size));
            }

            if (sorted is true)
            {
                treeViewReturn = treeView.OrderByDescending(x => x.rawSize).ToList();
            }
            else
            {
                treeViewReturn = treeView;
            }

            return treeViewReturn;
        }
    }
}