﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PizzaStoreApp.Exceptions
{
   
        public class InvalidPizzaTypeException : Exception
        {
            string message;
            public InvalidPizzaTypeException()
            {
                message = "YNo such type of pizza ";
            }
            public override string Message => message;
        }
    
}
