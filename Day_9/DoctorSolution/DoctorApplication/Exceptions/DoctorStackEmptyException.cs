namespace DoctorApplication.Exceptions
{
    public class DoctorStackEmptyException : Exception
    {
        string message;
        public DoctorStackEmptyException()
        {
            message = "No Doctors available at this moment. Sorry";
        }
        public override string Message => message;
    }
}
