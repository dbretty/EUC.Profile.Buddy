﻿// <copyright file="UserDetailTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.User
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User;
    using EUC.Profile.Buddy.Common.User.Model;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class to do user detail unit tests.
    /// </summary>
    [TestFixture]
    public class UserDetailTests
    {
        /// <summary>
        /// Checks that UpdateProfileSize with valid data succeeds.
        /// </summary>
        [Test]
        public void UpdateProfileSize_WithValidData_ShouldSucceed()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new Mock<IWindowsRegistry>();
            var mockFilesAndFolders = new Mock<IFilesAndFolders>(MockBehavior.Strict);

            var mockSize = 1_000_000L;
            var mockSizeString = "1 GB";

            mockFilesAndFolders.Setup(x => x.DirectorySizeAsync(It.IsAny<DirectoryInfo>())).ReturnsAsync(mockSize);
            mockFilesAndFolders.Setup(x => x.FormatFileSize(It.IsAny<long>())).Returns(mockSizeString);
            var mockUserDetail = new UserDetail(mockILogger.Object, mockRegistry.Object, mockFilesAndFolders.Object);

            // Act
            var response = mockUserDetail.UpdateProfileSize("C:\\Users");

            // Assert
            Assert.That(response, Is.EqualTo(mockSizeString));
            Mock.VerifyAll(mockFilesAndFolders);
        }

        /// <summary>
        /// Checks that ProfileModel works.
        /// </summary>
        [Test]
        public void ProfileType_WithValidData_ShouldReturnString()
        {
            // Arrange
            var profileType = new ProfileType[]
            {
                new ProfileType
                {
                    ProfileTypeLabel = "Local",
                    ProfileTypeDefinition = ProfileTypeDefinition.Local,
                },
            };

            // Act
            var response = profileType[0].ToString();

            // Assert
            Assert.That(response, Is.EqualTo("Local"));
        }

        /// <summary>
        /// Checks that UpdateProfileSize with valid data succeeds.
        /// </summary>
        [Test]
        public void UpdateProfileSizeAsync_WithValidData_ShouldSucceed()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new Mock<IWindowsRegistry>();
            var mockFilesAndFolders = new Mock<IFilesAndFolders>(MockBehavior.Strict);

            var mockSize = 1_000_000L;
            var mockSizeString = "1 GB";

            mockFilesAndFolders.Setup(x => x.DirectorySizeAsync(It.IsAny<DirectoryInfo>())).ReturnsAsync(mockSize);
            mockFilesAndFolders.Setup(x => x.FormatFileSize(It.IsAny<long>())).Returns(mockSizeString);
            var mockUserDetail = new UserDetail(mockILogger.Object, mockRegistry.Object, mockFilesAndFolders.Object);

            // Act
            var response = mockUserDetail.UpdateProfileSizeAsync("C:\\Users").Result;

            // Assert
            Assert.That(response, Is.EqualTo(mockSizeString));
            Mock.VerifyAll(mockFilesAndFolders);
        }

        /// <summary>
        /// Checks that UpdateProfileSize with invalid data errors.
        /// </summary>
        /// <param name="profileDirectory">The profile directory to check.</param>
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void UpdateProfileSize_WithInvalidProfileDirectory_ThrowArgumentNullOrWhiteSpace(string profileDirectory)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new Mock<IWindowsRegistry>();
            var mockFilesAndFolders = new Mock<IFilesAndFolders>();
            var mockUserDetail = new UserDetail(mockILogger.Object, mockRegistry.Object, mockFilesAndFolders.Object);

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => mockUserDetail.UpdateProfileSize(profileDirectory));
        }

        /// <summary>
        /// Checks that UpdateProfileSizeAsync with invalid data errors.
        /// </summary>
        /// <param name="profileDirectory">The profile directory to check.</param>
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void UpdateProfileSizeAsync_WithInvalidProfileDirectory_ThrowArgumentNullOrWhiteSpace(string profileDirectory)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new Mock<IWindowsRegistry>();
            var mockFilesAndFolders = new Mock<IFilesAndFolders>();
            var mockUserDetail = new UserDetail(mockILogger.Object, mockRegistry.Object, mockFilesAndFolders.Object);

            // Act + Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mockUserDetail.UpdateProfileSizeAsync(profileDirectory));
        }
    }
}
