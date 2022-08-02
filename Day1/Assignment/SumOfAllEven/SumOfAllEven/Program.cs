using System;

namespace SumOfAllEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print sum of all the even numbers");
            Console.Write("Enter Ending Point : ");
            var number = Convert.ToInt32(Console.ReadLine());
            var answer = 0;
            for (int i = 0; i <= number; i+=2)
                answer += i;
            Console.WriteLine($"Sum of all even number : {answer}");
        }
    }
}
