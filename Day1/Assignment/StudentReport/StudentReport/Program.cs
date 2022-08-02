using System;

namespace StudentReport
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student;
            Console.Write("How Many Stuent you want to add? : ");
            int n = Convert.ToInt32(Console.ReadLine());

            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter Student {i+1} Details :");
                Console.WriteLine("---------------------------------");

                student = new Student();

                Console.Write("Enter Name : ");
                student.Name = Console.ReadLine();

                Console.Write("Enter Address : ");
                student.Address = Console.ReadLine();

                Console.Write("Enter Hindi Mark : ");
                student.Hindi =Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter English Mark : ");
                student.English = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Maths Mark : ");
                student.Maths = Convert.ToInt32(Console.ReadLine());

                students[i] = student;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"",2}{"Name",-15}|{"",1}{"Address",-15}|{"Hindi",7}{"",1}|{"English",10}{"",1}|{"Maths",7}{"",1}|{"Total",7}{"",1}|{"Percent",10}{"",1}|{"Grade",7}{"",2}|");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            foreach (var stud in students)
            {
                Console.WriteLine($"|{"",2}{stud.Name,-15}|{"",1}{stud.Address,-15}|{stud.Hindi,7}{"",1}|{stud.English,10}{"",1}|{stud.Maths,7}{"",1}|{stud.Total,7}{"",1}|{string.Format("{0:0.00} %",stud.Percentage),10}{"",1}|{stud.Compute(),7}{"",2}|");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
        }
    }
}
