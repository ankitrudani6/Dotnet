using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolData data = new SchoolData();
            List<Person> people = data.GetPeople();
            foreach (var item in people)
            {
                Console.WriteLine("Id : {0}, Name : {1} {2}, HireDate : {3}, Discriminator : {4}", item.PersonId, item.FirstName, item.LastName, item.HireDate, item.Discriminator);
            }

            List<Course> courses = data.GetCourse();

            foreach (var item in courses)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}",item.CourseId, item.Title, item.Credits, item.DepartmentId);
            }

            foreach (var item in courses)
            {
                Console.WriteLine(typeof(Course).GetProperties()[3]);
            }
        }
    }
}
