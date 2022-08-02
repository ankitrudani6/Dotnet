using System;

namespace CheckAge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Accept Age from user, if age is more than 18 eligible for vote otherwise it should be displayed as not eligible. Do it with ternary operator
            Console.Write("Enter Your Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine((age >= 18)? "You Are Eligible" : "You Are Not Eligible");
        }
    }
}
