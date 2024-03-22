using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Striletska.Errors
{
    internal class InvalidLastNameException:Exception
    {
        public InvalidLastNameException() { }   
        public InvalidLastNameException(string message) : base(message) { } 

    }
}
