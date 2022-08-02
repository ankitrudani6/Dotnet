using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Day4Assignment
{
    class AgeException:Exception
    {
        
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
                throw new AgeException("Age is not less than 0");
            }
        }
    }
}
