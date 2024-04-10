// <copyright file="FilesAndFoldersTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.File
{
    using EUC.Profile.Buddy.Common.File;
    using EUC.Profile.Buddy.Common.File.Model;
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Profile;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.User;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class to do Files and Folders unit tests.
    /// </summary>
    [TestFixture]
    public class FilesAndFoldersTests
    {
        /// <summary>
        /// Test method to ensure AppConfigTests completes.
        /// </summary>
        [Test]
        public void TreeSize_WithValidData_ShouldSucceed()
        {
            // Arrange + Act
            var ts = new TreeSize()
            {
                FolderName = "folder",
                Size = "size",
                RawSize = 1_000_000L,
            };

            // Assert
            Assert.That(ts.FolderName, Is.EqualTo("folder"));
            Assert.That(ts.Size, Is.EqualTo("size"));
            Assert.That(ts.RawSize, Is.EqualTo(1_000_000L));
        }
    }
}
