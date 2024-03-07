namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    public class InvalidOperatingSystemException : Exception
    {
        public InvalidOperatingSystemException() : base() { }
        public InvalidOperatingSystemException(string message) : base(message) { }
        public InvalidOperatingSystemException(string message, Exception innerException) : base(message, innerException) { }

    }
}
