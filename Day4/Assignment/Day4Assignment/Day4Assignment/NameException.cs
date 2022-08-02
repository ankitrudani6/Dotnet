using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Day4Assignment
{
    class NameException : Exception
    {
        
        public NameException(string message) : base(message)
        {
        }
    }

    public class NameValidate
    {
        public static void validate(string Name)
        {
            foreach (Char ch in Name)
            {
                if (!Char.IsLetter(ch))
                    throw new NameException("Name should contain only character");
            }
        }
    }
}
