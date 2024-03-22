// <copyright file="LoggingTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.Logging
{
    using EUC.Profile.Buddy.Common.Logging;
    using Moq;

    /// <summary>
    /// Class to do logging unit tests.
    /// </summary>
    [TestClass]
    public class LoggingTests
    {
        /// <summary>
        /// Test method to ensure WriteLogAsync completes.
        /// </summary>
        [TestMethod]
        public void Logger_WriteLogAsync_ShouldRunToCompletion()
        {
            ILogger mockLogger = Mock.Of<ILogger>();
            TaskStatus expected = TaskStatus.RanToCompletion;
            var logging = mockLogger.LogAsync("Testing the logging");
            Assert.AreEqual(logging.Status, expected);
        }

        /// <summary>
        /// Test method to ensure ILogger is not null.
        /// </summary>
        [TestMethod]
        public void Logger_Initalize_ShouldNotBeNull()
        {
            ILogger mockLogger = Mock.Of<ILogger>();
            Assert.IsNotNull(mockLogger);
        }
    }
}
