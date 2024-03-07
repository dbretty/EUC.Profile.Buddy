// <copyright file="InvalidKeyException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException()
            : base()
        {
        }

        public InvalidKeyException(string message)
            : base(message)
        {
        }

        public InvalidKeyException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
