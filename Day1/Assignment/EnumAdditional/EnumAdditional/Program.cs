using System;

namespace EnumAdditional
{
    enum Days
    {
        Sunday = 1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    class Program
    {
        static void Main(string[] args)
        {
            Days output;
            Console.Write("Enter Weekday : ");
            string day = Console.ReadLine();

            //Console.WriteLine((int)Enum.Parse(typeof(Days), day));

            if(Enum.TryParse(day, true,out output))
                Console.WriteLine((int)output);
            else
                Console.WriteLine("Value is not available in 'Days' Enum");
        }
    }
}
