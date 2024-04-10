// <copyright file="AppConfigTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.AppConfig
{
    using EUC.Profile.Buddy.Common.Configuration;
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class to do logging unit tests.
    /// </summary>
    [TestFixture]
    public class AppConfigTests
    {
        /// <summary>
        /// Test method to ensure AppConfigTests completes.
        /// </summary>
        [Test]
        public void AppConfig_WithValidData_ShouldSucceed()
        {
            // Arrange + Act
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new Mock<IWindowsRegistry>();
            var mockFilesAndFolders = new Mock<IFilesAndFolders>();
            var mockUserProfile = new Mock<IUserProfile>();
            var mockUserDetail = new Mock<IUserDetail>();

            var ac = new AppConfig()
            {
                Logger = mockILogger.Object,
                Registry = mockRegistry.Object,
                FilesAndFolders = mockFilesAndFolders.Object,
                UserProfile = mockUserProfile.Object,
                UserDetail = mockUserDetail.Object,
            };

            // Assert
            Assert.That(ac.AppRegistryKey, Is.EqualTo("Software\\EUCProfileBuddy"));
            Assert.That(ac.LogLevel, Is.EqualTo("Info"));
            Assert.That(ac.ClearTempAtStart, Is.EqualTo("No"));
        }
    }
}
