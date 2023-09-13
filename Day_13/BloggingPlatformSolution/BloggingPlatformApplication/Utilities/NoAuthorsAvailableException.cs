namespace BloggingPlatformApplication.Utilities
{
    public class NoAuthorsAvailableException : Exception
    {
        string message;
        public NoAuthorsAvailableException()
        {
            message = "No Authors are Found";
        }
        public override string Message => message;
    }
}
