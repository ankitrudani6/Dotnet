using System;
using System.Collections.Generic;
using System.Text;

namespace AgeExceptionAssignment
{
    class Student
    {
        static int ID = 0;
        int Age, Phone;
        string Name, City, Email;
        DateTime DOB;

        public void Get()
        {
            ID += 1;

            Console.Write("Enter Student Name : ");
            Name = Console.ReadLine();

            Console.Write("Enter Date Of Birth : ");
            DOB = Convert.ToDateTime(Console.ReadLine());

            while (true)
            {
                Console.Write("Enter Age : ");
                Age = Convert.ToInt32(Console.ReadLine());

                try
                {
                    AgeValidation.validate(Age);
                    break;
                }
                catch (AgeException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.Write("Enter Phone Number : ");
            Phone = (int)Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Email Address : ");
            Email = Console.ReadLine();

            Console.Write("Enter City : ");
            City = Console.ReadLine();

        }

        public void Display()
        {
            Console.WriteLine($"Student ID : {ID}\nName : {Name}\nDAte of Birth : {DOB}\nAge : {Age}\nPhone Number : {Phone}\nEmail Address : {Email}\nCity : {City}");
        }
    }
}
