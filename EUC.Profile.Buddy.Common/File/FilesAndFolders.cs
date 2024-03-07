namespace EUC.Profile.Buddy.Common.File
{
    public class FilesAndFolders : IFilesAndFolders
    {
        public long DirectorySize(DirectoryInfo directory)
        {
            try
            {
                long size = 0;
                FileInfo[] fis = directory.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = directory.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirectorySize(di);
                }
                return size;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Formats the folder size from byten for a readable number.
        /// </summary>
        /// <param name="bytes">The root folder for the profile.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public string FormatFileSize(long bytes)
        {
            var unit = 1024;
            if (bytes < unit) { return $"{bytes} B"; }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));
            return $"{bytes / Math.Pow(unit, exp):F2} {("KMGTPE")[exp - 1]}B";
        }
    }
}
