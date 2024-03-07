namespace EUC.Profile.Buddy.Common.Registry.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException() : base() { }
        public InvalidValueException(string message) : base(message) { }
        public InvalidValueException(string message, Exception innerException) : base(message, innerException) { }
    }
}
