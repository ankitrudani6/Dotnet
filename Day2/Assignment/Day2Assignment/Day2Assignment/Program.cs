using ConsoleTable;
using System;

namespace Day2Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(200);
            table.AddInRow("Ankit", "Rudani");
            table.AddInRow("Ankur", "Rudani");
            table.AddInRow("Dhairya", "Sanghrajka");
            table.display();


            Console.Write("Enter How Many Person you want to Add? : ");
            int n = Convert.ToInt32(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter First Name : ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name : ");
                string lastName = Console.ReadLine();

                Console.Write("Enter Email Address : ");
                string emailAddress = Console.ReadLine();

                Console.Write("Enter Date of Birth : ");
                string dateOfBirth = Console.ReadLine();

                people[i] =  new Person(firstName, lastName, emailAddress, dateOfBirth);
            }

            
            table.PrintLine();
            table.PrintRow("First Name", "Last Name","Email Address", "Date of Birth","Is Adult?","Sun Sign", "Chinese Sign","BirthDay?", "Screen Name");
            table.PrintLine();
            foreach (var p in people)
            {
                table.PrintRow(p.FirstName, p.LastName,p.EmailAddress, p.DateOfBirth.ToShortDateString(), p.IsAdult.ToString(), p.SunSign, p.ChineseSign, p.Birthday.ToString(), p.ScreenName);   
            }
            table.PrintLine();

        }
    }
}
