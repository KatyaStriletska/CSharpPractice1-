using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Striletska.Errors
{
    class InvalidAgeInFutureException : Exception
    {
        public int Age { get; set; }
        public InvalidAgeInFutureException() { }
        public InvalidAgeInFutureException(string message) : base(message) { }   
        public InvalidAgeInFutureException(string message, Exception inner): base (message, inner) { }   
        public InvalidAgeInFutureException(int age)
        {
            Age = age;
            base.Data.Add("Age", Age);
        }

    }
}
