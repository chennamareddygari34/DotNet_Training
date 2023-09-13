using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public class InvalidDoctorException : Exception
    {
        string message;
        public InvalidDoctorException()
        {
            message = "No such type of Doctor ";
        }
        public override string Message => message;
    }
}

