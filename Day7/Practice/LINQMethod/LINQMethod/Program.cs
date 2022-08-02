using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQMethod
{
	public class Student
	{
		public int StudentID { get; set; }
		public string StudentName { get; set; }
		public int Age { get; set; }
	}
	class Program
    {
        static void Main(string[] args)
        {
			// string collection
			IList<string> stringList = new List<string>() {
				"C# Tutorials",
				"VB.NET Tutorials",
				"Learn C++",
				"MVC Tutorials" ,
				"Java"
			};

			// LINQ Method Syntax
			var result = stringList.Where(s => s.Contains("Tutorials"));

			foreach (var str in result)
			{
				Console.WriteLine(str);
			}

			// Student collection
			IList<Student> studentList = new List<Student>() {
				new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
				new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
				new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
				new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
			};

			// LINQ Query Method to find out teenager students
			var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);

			Console.WriteLine("Teen age Students:");

			foreach (Student std in teenAgerStudent)
			{
				Console.WriteLine(std.StudentName);
			}
		}
    }
}
