using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Striletska.Errors
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException() { }   
        public InvalidNameException(string message) : base(message) { }
        public InvalidNameException(string message, Exception innerException) : base(message, innerException) { }   
    }
}
