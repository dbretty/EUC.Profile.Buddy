// <copyright file="ProfileTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.Profile
{
    using EUC.Profile.Buddy.Common.Profile.Model;
    using NUnit.Framework;

    /// <summary>
    /// Class to do Profile unit tests.
    /// </summary>
    [TestFixture]
    public class ProfileTests
    {
        /// <summary>
        /// Checks that ProfileAction returns string value.
        /// </summary>
        [Test]
        public void ProfileAction_WithValidAction_ShouldReturnString()
        {
            // Arrange
            var profileAction = new ProfileAction[]
            {
                new ProfileAction
                {
                    ActionLabel = "Clean Temporary Data",
                    ActionDefinition = ProfileActionDefinition.ClearTempFiles,
                },
            };

            // Act
            var response = profileAction[0].ToString();

            // Assert
            Assert.That(response, Is.EqualTo("Clean Temporary Data"));
        }
    }
}
