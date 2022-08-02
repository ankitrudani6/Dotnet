using System;
using System.Collections.Generic;
using System.Text;

namespace AgeExceptionAssignment
{
    class AgeException : Exception
    {
        public AgeException()
        {
        }

        public AgeException(string message) : base(message)
        {

        }
    }

    public class AgeValidation
    {
        public static void validate(int age)
        {
            if (age < 0)
            {
                throw new AgeException("Age is not Nagetive");
            }
        }
    }
}
