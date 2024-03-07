//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="bretty.me.uk">
//     Copyright bretty.me.uk. All rights reserved.
// </copyright>
// <author>Dave Brett</author>
//-----------------------------------------------------------------------


namespace EUC.Profile.Buddy.CLI
{
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Logging.Model;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using System.Transactions;
    using Microsoft.Win32;

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
            /*
            var logger = new Logger();

            await logger.LogAsync("testing");

            await logger.LogAsync("testing1", LogLevel.WARNING);

            await logger.LogAsync("testing2", LogLevel.FATAL, LogType.FILE);
            */

            /*
            var regvalue = new WindowsRegistry();
            var dave = regvalue.GetRegistryValue("APPDATA", "Volatile Environment", RegistryHive.CurrentUser);
            if(dave.registryError == RegistryError.NONE)
            {
                await Console.Out.WriteLineAsync("found");
            }
            */
            /*if (OperatingSystem.IsWindows())
            {
                var regValue = new WindowsRegistry();

                var dave = regValue.SetRegistryValue("String", "Software\\Test", "Testing", RegistryHive.CurrentUser);
                var dave1 = regValue.SetRegistryValue("DWord", "Software\\Test", 1, RegistryHive.CurrentUser);
                var dave2 = regValue.SetRegistryValue("Multiline", "Software\\Test", new string[] { "string 1", "string 2", "string 3" }, RegistryHive.CurrentUser);

                var dave3 = regValue.SetRegistryValue("Multiline", "Software\\DoesntExist", new string[] { "string 1", "string 2", "string 3" }, RegistryHive.LocalMachine);
                var dave4 = regValue.SetRegistryValue("Multiline", "Software\\Test", new string[] { "string 1", "string 2", "string 3" }, RegistryHive.LocalMachine);

                var dave5 = regValue.CreateRegistryKey("Software\\Test1", RegistryHive.CurrentUser);

                var dave6 = regValue.CreateRegistryKey("Software\\Test1", RegistryHive.CurrentUser);
                var dave7 = regValue.CreateRegistryKey("Software\\Test1", RegistryHive.LocalMachine);

                var andrew1 = regValue.GetRegistryValue(string.Empty, string.Empty, RegistryHive.CurrentUser);
            */
            var ServiceProvider = new ServiceCollction();

            }
        }
    }