// <copyright file="LoggerTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.Logging
{
    using EUC.Profile.Buddy.Common.Logging;
    using NUnit.Framework;

    /// <summary>
    /// Class to do logging unit tests.
    /// </summary>
    [TestFixture]
    public class LoggerTests
    {
        /// <summary>
        /// Test method to ensure WriteLogAsync completes successfully.
        /// </summary>
        /// <param name="logMessage">The log message to pass in.</param>
        [Test]
        public void LogAsync_WithValidMessage_ShouldSucceed()
        {
            ILogger logger = new Logger();

            Assert.DoesNotThrowAsync(async () => await logger.LogAsync("unit test message"));
        }

        /// <summary>
        /// Test method to ensure WriteLogAsync errors correctly.
        /// </summary>
        /// <param name="logMessage">The log message to pass in.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void LogAsync_WithInvalidMessage_ThrowArgumentNullOrWhiteSpace(string logMessage)
        {
            ILogger logger = new Logger();

            Assert.ThrowsAsync<ArgumentNullException>(async () => await logger.LogAsync(logMessage));
        }
    }
}
