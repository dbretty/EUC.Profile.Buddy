
namespace EUC.Profile.Buddy.Common.File
{
    public interface IFilesAndFolders
    {
        public long DirectorySize(DirectoryInfo directory);
        public string FormatFileSize(long bytes);
    }
}