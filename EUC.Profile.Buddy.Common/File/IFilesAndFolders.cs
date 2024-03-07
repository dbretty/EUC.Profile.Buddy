
namespace EUC.Profile.Buddy.Common.File
{
    public interface IFilesAndFolders
    {
        long DirectorySize(DirectoryInfo directory);
        string FormatFileSize(long bytes);
    }
}