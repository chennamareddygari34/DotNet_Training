namespace EmployeeLoginApplication.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "There is no doctor with the spec you have specified";
        }
    }
}
