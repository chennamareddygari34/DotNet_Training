using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDALLibrary
{

        public class IvalidDoctorTypeException : Exception
        {
            string message;
        public IvalidDoctorTypeException()
        {
            message = "No Doctors available at this moment. Sorry";
        }

        public override string Message => message;
        }
}
