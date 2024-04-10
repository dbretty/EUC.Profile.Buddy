// <copyright file="FilesAndFoldersTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.File
{
    using EUC.Profile.Buddy.Common.File.Model;
    using NUnit.Framework;

    /// <summary>
    /// Class to do Files and Folders unit tests.
    /// </summary>
    [TestFixture]
    public class FilesAndFoldersTests
    {
        /// <summary>
        /// Test method to ensure TreeSize with valid data succeeds.
        /// </summary>
        [Test]
        public void TreeSize_WithValidPropertyValues_ShouldSucceed()
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
