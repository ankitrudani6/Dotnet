using System;
using System.Collections.Generic;

namespace StudentList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a list which will store 5 student names and then display it search it index number
            List<string> students = new List<string> { "Ankit", "Rohan", "Jeet", "Rahul", "Dhairya"};

            //Display
            foreach (var student in students)
            {
                Console.Write(student+" ");
            }
            Console.WriteLine();
            Console.Write("Enter Index Number to Search : ");
            int i = Convert.ToInt32(Console.ReadLine());

            if (i < students.Count)
            {
                Console.WriteLine(students[i]);
            }
            else
                Console.WriteLine("Index is out of Bound");
        }
    }
}
