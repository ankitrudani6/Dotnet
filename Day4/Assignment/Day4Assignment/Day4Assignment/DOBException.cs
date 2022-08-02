using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Day4Assignment
{
    class DOBException : Exception
    {
        
        public DOBException(string message) : base(message)
        {
        }
        
    }
    public class DOBValidate
    {
        public static void validate(DateTime dob)
        {
            if (DateTime.Compare(dob, DateTime.Now) > 0)
                
                throw new DOBException("Date of Birth is not greater than Current Date");
        }
    }
}
