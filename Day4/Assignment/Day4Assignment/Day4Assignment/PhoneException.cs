using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4Assignment
{
    class PhoneException : ApplicationException
    {
        public PhoneException(string message) : base(message)
        {
        }
    }

    public class PhoneValidate
    {
        public static void validate(long number)
        {
            string rgx = "^[6-9][0-9]{9}$";
            if (!Regex.IsMatch(number.ToString(), rgx))
                throw new PhoneException("Enter Valid Phone Number");
        }
    }
}
