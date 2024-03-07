namespace EUC.Profile.Buddy.Common.User
{
    public interface IUser
    {
        public string? UserName { get; set; }
        public string? Domain { get; set; }
        public string? ProfileDirectory { get; set; }
        public string? AppDataLocal { get; set; }
        public string? AppDataRoaming { get; set; }
        public string? ProfileSize { get; set; }
    }
}