namespace EUC.Profile.Buddy.CLI
{
    using EUC.Profile.Buddy.Common.User;
    using EUC.Profile.Buddy.Common.Logging;

    /// <summary>
    /// Class to do execute the CLI Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the CLI Program <see cref="Main"/> class.
        /// </summary>
        /// <param name="args">The command line arguments send into the CLI.</param>
        public static async Task Main(string[] args)
        {
            ILogger logger = new Logger();
            IUserDetail user = new UserDetail();

            await Console.Out.WriteLineAsync($"UserName: {user.UserName}");
            await Console.Out.WriteLineAsync($"Domain: {user.Domain}");
            await Console.Out.WriteLineAsync($"Profile Directory: {user.ProfileDirectory}");
            await Console.Out.WriteLineAsync($"Local AppData: {user.AppDataLocal}");
            await Console.Out.WriteLineAsync($"Roaming AppData: {user.AppDataRoaming}");
            await Console.Out.WriteLineAsync($"Profile Size: {user.ProfileSize}");
            var newSize = user.UpdateProfileSize(user.ProfileDirectory);
        }
    }
}