namespace BloggingPlatformApplication.Utilities
{
    public class NoBlogPostsAvailableException : Exception
    {
        string message;
        public NoBlogPostsAvailableException()
        {
            message = "No Blogs are available here..";
        }
        public override string Message => message;
    }
}
