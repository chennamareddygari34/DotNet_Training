namespace EmployeeLoginApplication.Exceptions
{
    public class NoEmployeesAreAvailable : Exception
    {
        string message;
        public NoEmployeesAreAvailable()
        {
            message = "No employees available at this moment";
        }
        public override string Message => message;
    }
}
