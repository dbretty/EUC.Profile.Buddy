﻿// <copyright file="InvalidRootKeyException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    /// <summary>
    /// Class for InvalidRootKeyException.
    /// </summary>
    public class InvalidRootKeyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRootKeyException"/> class.
        /// </summary>
        public InvalidRootKeyException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRootKeyException"/> class.
        /// </summary>
        /// <param name="message">The message to send to the exception.</param>
        public InvalidRootKeyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRootKeyException"/> class.
        /// </summary>
        /// <param name="message">The message to send to the exception.</param>
        /// <param name="innerException">The innerException to send to the exception.</param>
        public InvalidRootKeyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
