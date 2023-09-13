namespace DoctorApplication.Exceptions
{
    public class InvalidUserException : Exception
    {
        string message;
        public InvalidUserException()
        {
            message = "Ivalid User";
        }
        public override string Message => message;
    }
}
