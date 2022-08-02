using System;
using System.Collections.Generic;
using System.Text;

namespace Day4Assignment
{
    class Student
    {
        static int ID = 0;
        int Age;
        long Phone;
        string Name, City, Email;
        DateTime DOB;

        public void Get()
        {
            ID += 1;

            while (true)
            {

                try
                {
                    Console.Write("Enter Student Name : ");
                    Name = Console.ReadLine();
                    NameValidate.validate(Name);
                    break;
                }
                catch(NameException NE)
                {
                    Console.WriteLine(NE.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.Write("Please Re-");
            }

            while (true)
            {


                try
                {
                    Console.Write("Enter Date Of Birth : ");
                    DOB = Convert.ToDateTime(Console.ReadLine());
                    DOBValidate.validate(DOB);
                    break;
                }
                catch (DOBException DE)
                {
                    Console.WriteLine(DE.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.Write("Please Re-");
            }

            

            DOBValidate.validate(DOB);

            while (true)
            {
                try
                {
                    Console.Write("Enter Age : ");
                    Age = Convert.ToInt32(Console.ReadLine());

                    AgeValidation.validate(Age);
                    break;
                }
                catch (AgeException AE)
                {
                    Console.WriteLine(AE.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.Write("Please Re-");
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter Phone Number : ");
                    Phone = Convert.ToInt64(Console.ReadLine());
                    PhoneValidate.validate(Phone);
                    break;
                }
                catch(PhoneException PE)
                {
                    Console.WriteLine(PE.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Please Re-");
            }

            Console.Write("Enter Email Address : ");
            Email = Console.ReadLine();

            Console.Write("Enter City : ");
            City = Console.ReadLine();

        }

        public void Display()
        {
            Console.WriteLine($"Student ID : {ID}\nName : {Name}\nDAte of Birth : {DOB.ToShortDateString()}\nAge : {Age}\nPhone Number : {Phone}\nEmail Address : {Email}\nCity : {City}");
        }
    }
}
