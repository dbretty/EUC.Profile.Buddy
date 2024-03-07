namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    public class InvalidRootKeyException : Exception
    {
        public InvalidRootKeyException() : base() { }
        public InvalidRootKeyException(string message) : base(message) { }
        public InvalidRootKeyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
