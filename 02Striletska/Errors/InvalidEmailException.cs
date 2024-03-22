using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _02Striletska.Errors
{
    class InvalidEmailException: Exception
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message,  Exception innerException) : base(message, innerException) { } 
     

    }
}
