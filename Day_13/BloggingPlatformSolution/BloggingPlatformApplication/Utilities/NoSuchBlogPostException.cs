namespace BloggingPlatformApplication.Utilities
{
    public class NoSuchBlogPostException : Exception
    {
        string message;
        public NoSuchBlogPostException()
        {
            message = "There is no such blog post..";
        }
        public override string Message => message;
    }
}
