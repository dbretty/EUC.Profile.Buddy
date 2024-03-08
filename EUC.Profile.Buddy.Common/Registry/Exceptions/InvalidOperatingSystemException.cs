// <copyright file="InvalidOperatingSystemException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    /// <summary>
    /// Class for InvalidOperatingSystemException.
    /// </summary>
    public class InvalidOperatingSystemException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperatingSystemException"/> class.
        /// </summary>
        public InvalidOperatingSystemException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperatingSystemException"/> class.
        /// </summary>
        /// <param name="message">The message to send to the exception.</param>
        public InvalidOperatingSystemException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperatingSystemException"/> class.
        /// </summary>
        /// <param name="message">The message to send to the exception.</param>
        /// <param name="innerException">The innerException to send to the exception.</param>
        public InvalidOperatingSystemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}