using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Striletska.Errors
{
    class InvalidAgeTooOldException : Exception
    {
        public InvalidAgeTooOldException() { }
        public InvalidAgeTooOldException(string message) : base(message) { }
        public InvalidAgeTooOldException(string message, Exception innerException) : base(message, innerException) { }    


    }
}
