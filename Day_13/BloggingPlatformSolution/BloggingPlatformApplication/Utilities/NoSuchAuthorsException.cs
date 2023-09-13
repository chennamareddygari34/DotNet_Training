namespace BloggingPlatformApplication.Utilities
{
    public class NoSuchAuthorsException : Exception
    {
        string message;
        public NoSuchAuthorsException()
        {
            message = "There is no such author..";
        }
        public override string Message => message;
    }
}
