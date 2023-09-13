using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDALLibrary
{
    public class DoctorsNotAvailableException : Exception
    {
        string message;
        public DoctorsNotAvailableException()
        {
            message = "No Doctors are  available at this moment. Sorry";
        }
        public override string Message => message;
    }
}