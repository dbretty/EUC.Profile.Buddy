//-----------------------------------------------------------------------
// <copyright file="FilesAndFolders.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Dave Brett</author>
//-----------------------------------------------------------------------
namespace EUC.Profile.Buddy.Common.File
{
    /// <summary>
    /// Files and Folders Class.
    /// </summary>
    public class FilesAndFolders : IFilesAndFolders
    {
        /// <summary>
        /// Gets a directory size based on a path.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to size.</param>
        /// <returns>The Size of the Directory in Bytes.</returns>
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
    }
}
