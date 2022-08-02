using System;

namespace WeekDayEnum
{
    enum Days
    {
        Sunday=1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a weekday enum and accept week day number and display week day.");
            Console.Write("Enter Week Day Number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            if(number > 0 && number <=7)
                Console.WriteLine((Days) number);
            else
                Console.WriteLine("Enter Weekday number Between 1 and 7");
        }
    }
}
