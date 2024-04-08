// <copyright file="RegistryTests.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Tests.Registry
{
    using EUC.Profile.Buddy.Common.Logging;
    using EUC.Profile.Buddy.Common.Registry;
    using EUC.Profile.Buddy.Common.Registry.Exceptions;
    using EUC.Profile.Buddy.Common.Registry.Model;
    using Microsoft.Win32;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class to do Registry unit tests.
    /// </summary>
    [TestFixture]
    public class RegistryTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryTests"/> class.
        /// </summary>
        public RegistryTests()
        {
            this.RegistryKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
            this.RegistryValue = "CurrentBuild";
        }

        /// <summary>
        /// Gets or Sets the RegistryKey.
        /// </summary>
        public string RegistryKey { get; set; }

        /// <summary>
        /// Gets or Sets the RegistryValue.
        /// </summary>
        public string RegistryValue { get; set; }

        /// <summary>
        /// Test method to ensure GetRegistryValue completes.
        /// </summary>
        [Test]
        public void GetRegistryValue_WithValidValue_ShouldSucceed()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act
            var response = mockRegistry.GetRegistryValue(this.RegistryValue, this.RegistryKey, RegistryHive.LocalMachine);

            // Assert
            Assert.That(response, Is.TypeOf<string>());
        }

        /// <summary>
        /// Test method to ensure GetRegistryValueAsync completes.
        /// </summary>
        [Test]
        public void GetRegistryValueAsync_WithValidValue_ShouldSucceed()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act
            var response = mockRegistry.GetRegistryValueAsync(this.RegistryValue, this.RegistryKey, RegistryHive.LocalMachine).Result;

            // Assert
            Assert.That(response, Is.TypeOf<string>());
        }

        /// <summary>
        /// Test method to ensure GetRegistryKey completes.
        /// </summary>
        [Test]
        public void GetRegistryKey_WithValidValue_ShouldSucceed()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act
            var response = mockRegistry.GetRegistryKey(this.RegistryKey, RegistryHive.LocalMachine);

            // Assert
            Assert.That(response, Is.TypeOf<bool>());
        }

        /// <summary>
        /// Test method to ensure GetRegistryKey completes.
        /// </summary>
        [Test]
        public void RegistryPathValue_WithValidPath_ShouldSucceed()
        {
            // Arrange + Act
            var rpv = new RegistryPathValue() { Path = "path" };

            // Assert
            Assert.That(rpv.Path, Is.EqualTo("path"));
        }

        /// <summary>
        /// Test method to ensure GetRegistryKey completes.
        /// </summary>
        [Test]
        public void RegistryPathValue_WithValidKey_ShouldSucceed()
        {
            // Arrange + Act
            var rpv = new RegistryPathValue() { Key = "key" };

            // Assert
            Assert.That(rpv.Key, Is.EqualTo("key"));
        }

        /// <summary>
        /// Test method to ensure GetRegistryKey completes.
        /// </summary>
        [Test]
        public void RegistryPathValue_WithValidValue_ShouldSucceed()
        {
            // Arrange + Act
            var rpv = new RegistryPathValue() { Value = "value" };

            // Assert
            Assert.That(rpv.Value, Is.EqualTo("value"));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValue Fails with Null Key Values.
        /// </summary>
        /// <param name="value">The registry value.</param>
        /// <param name="key">The registry key.</param>
        /// <param name="hive">The registry hive.</param>
        [Test]
        [TestCase("value", "", RegistryHive.LocalMachine)]
        [TestCase("value", " ", RegistryHive.LocalMachine)]
        [TestCase("value", null, RegistryHive.LocalMachine)]
        public void GetRegistryValue_WithInValidKey_ThrowArgumentNullOrEmpty(string value, string key, RegistryHive hive)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => mockRegistry.GetRegistryValue(value, key, hive));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValueAsync Fails with Null Key Values.
        /// </summary>
        /// <param name="value">The registry value.</param>
        /// <param name="key">The registry key.</param>
        /// <param name="hive">The registry hive.</param>
        [Test]
        [TestCase("value", "", RegistryHive.LocalMachine)]
        [TestCase("value", " ", RegistryHive.LocalMachine)]
        [TestCase("value", null, RegistryHive.LocalMachine)]
        public void GetRegistryValueAsync_WithInValidKey_ThrowArgumentNullOrEmpty(string value, string key, RegistryHive hive)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mockRegistry.GetRegistryValueAsync(value, key, hive));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValue Fails with Null Values.
        /// </summary>
        /// <param name="value">The registry value.</param>
        /// <param name="key">The registry key.</param>
        /// <param name="hive">The registry hive.</param>
        [Test]
        [TestCase("", "key", RegistryHive.LocalMachine)]
        [TestCase(" ", "key", RegistryHive.LocalMachine)]
        [TestCase(null, "key", RegistryHive.LocalMachine)]
        public void GetRegistryValue_WithInValidValue_ThrowArgumentNullOrEmpty(string value, string key, RegistryHive hive)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => mockRegistry.GetRegistryValue(value, key, hive));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValueAsync Fails with Null Values.
        /// </summary>
        /// <param name="value">The registry value.</param>
        /// <param name="key">The registry key.</param>
        /// <param name="hive">The registry hive.</param>
        [Test]
        [TestCase("", "key", RegistryHive.LocalMachine)]
        [TestCase(" ", "key", RegistryHive.LocalMachine)]
        [TestCase(null, "key", RegistryHive.LocalMachine)]
        public void GetRegistryValueAsync_WithInValidValue_ThrowArgumentNullOrEmpty(string value, string key, RegistryHive hive)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await mockRegistry.GetRegistryValueAsync(value, key, hive));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValue Fails with an invalid key path.
        /// </summary>
        [Test]
        public void GetRegistryValue_WithInValidKeyPath_ThrowInvalidKeyException()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.Throws<InvalidKeyException>(() => mockRegistry.GetRegistryValue(this.RegistryValue, "dummy key", RegistryHive.LocalMachine));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValueAsync Fails with an invalid key path.
        /// </summary>
        [Test]
        public void GetRegistryValueAsync_WithInValidKeyPath_ThrowInvalidKeyException()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.ThrowsAsync<InvalidKeyException>(async () => await mockRegistry.GetRegistryValueAsync(this.RegistryValue, "dummy key", RegistryHive.LocalMachine));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValue Fails with an invalid value path.
        /// </summary>
        [Test]
        public void GetRegistryValue_WithInValidValuePath_ThrowInvalidValueException()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.Throws<InvalidValueException>(() => mockRegistry.GetRegistryValue("dummy value", this.RegistryKey, RegistryHive.LocalMachine));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValueAsync Fails with an invalid value path.
        /// </summary>
        [Test]
        public void GetRegistryValueAsync_WithInValidValuePath_ThrowInvalidValueException()
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.ThrowsAsync<InvalidValueException>(async () => await mockRegistry.GetRegistryValueAsync("dummy value", this.RegistryKey, RegistryHive.LocalMachine));
        }

        /// <summary>
        /// Test method to ensure GetRegistryValue Throws correctly.
        /// </summary>
        /// <param name="value">The registry value.</param>
        /// <param name="key">The registry key.</param>
        /// <param name="hive">The registry hive.</param>
        [Test]
        [TestCase("value", "key", 7)]
        public void GetRegistryValue_WithInvalidRootKey_InvalidRootKeyException(string value, string key, RegistryHive hive)
        {
            // Arrange
            var mockILogger = new Mock<ILogger>();
            var mockRegistry = new WindowsRegistry(mockILogger.Object);

            // Act + Assert
            Assert.Throws<InvalidRootKeyException>(() => mockRegistry.GetRegistryValue(value, key, hive));
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidRootKeyException_WithMessage_Throws()
        {
            // Arrange + Act
            var ex = new InvalidRootKeyException("test message");

            // Assert
            if (ex.Message is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
            }
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidRootKeyException_WithMessageAndInnerException_Throws()
        {
            // Arrange + Act
            var innerException = new Exception("inner");
            var ex = new InvalidRootKeyException("test message", innerException);

            // Assert
            if (ex.Message is not null && ex.InnerException is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
                Assert.That(ex.InnerException.Message, Is.EqualTo("inner"));
            }
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidKeyException_WithMessage_Throws()
        {
            // Arrange + Act
            var ex = new InvalidKeyException("test message");

            // Assert
            if (ex.Message is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
            }
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidKeyException_WithMessageAndInnerException_Throws()
        {
            // Arrange + Act
            var innerException = new Exception("inner");
            var ex = new InvalidKeyException("test message", innerException);

            // Assert
            if (ex.Message is not null && ex.InnerException is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
                Assert.That(ex.InnerException.Message, Is.EqualTo("inner"));
            }
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidValueException_WithMessage_Throws()
        {
            // Arrange + Act
            var ex = new InvalidValueException("test message");

            // Assert
            if (ex.Message is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
            }
        }

        /// <summary>
        /// Test method to ensure InvalidRootKeyException Throws correctly.
        /// </summary>
        [Test]
        public void InvalidValueException_WithMessageAndInnerException_Throws()
        {
            // Arrange + Act
            var innerException = new Exception("inner");
            var ex = new InvalidValueException("test message", innerException);

            // Assert
            if (ex.Message is not null && ex.InnerException is not null)
            {
                Assert.That(ex.Message, Is.EqualTo("test message"));
                Assert.That(ex.InnerException.Message, Is.EqualTo("inner"));
            }
        }
    }
}
