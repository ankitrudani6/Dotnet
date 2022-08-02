using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryOperators
{
    class Program
    {
		static void Main(string[] args)
		{
			IList<Student> studentList = new List<Student>() {
				new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
				new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
				new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
				new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
			};

			IList<Standard> standardList = new List<Standard>() {
				new Standard(){ StandardID = 1, StandardName="Standard 1"},
				new Standard(){ StandardID = 2, StandardName="Standard 2"},
				new Standard(){ StandardID = 3, StandardName="Standard 3"}
			};

			/* 
			 *	Filtering Operator  - Where, OfType

				Where Operator
				--------------
				- The Where operator (Linq extension method) filters the collection based on a given criteria expression and returns a new collection.
				- The criteria can be specified as lambda expression or Func delegate type.
				  
				OfType
				-------
				- The OfType operator filters the collection based on the ability to cast an element in a collection to a specified type.
			*/

			Console.WriteLine("Filtering Operator  - Where");

			//where operator - lambda Expression
			var whereResult = from s in studentList
							  where s.Age > 12 && s.Age < 20
							  select s;

			//where operator - use a Func type delegate with an anonymous method to pass as a predicate function
			Func<Student, bool> isTeenAge = delegate (Student s)
			{
				return s.Age > 12 && s.Age < 20;
			};

			whereResult = from s in studentList
						  where isTeenAge(s)
						  select s;

			// LINQ Query Method to find out teenager students
			whereResult = studentList.Where(s => s.Age > 12 && s.Age < 20);

			PrintResult("Where Operator Output", whereResult);

			//where operator -  extension method
			whereResult = studentList.Where((s, i) =>
			{
				if (i % 2 == 0)
					return true;
				return false;
			});
			PrintResult("Where Operator - Extension Method", whereResult);

			//where operator - Multiple where clause
			whereResult = from s in studentList
						  where s.Age > 12
						  where s.Age < 20
						  select s;
			whereResult = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);


			Console.WriteLine("Filtering Operator  - OfType");

			//OfType - Student type
			var OfTypeResult = from s in studentList.OfType<Student>()
							   select s;

			//OfType - extension method
			OfTypeResult = studentList.OfType<Student>();
			PrintResult("Oftype Output - Student type", OfTypeResult);

			/*
			 *  Sorting Operators: OrderBy & OrderByDescending
				
				OrderBy
				-------
				- OrderBy sorts the values of a collection in ascending or descending order. 
				- It sorts the collection in ascending order by default because ascending keyword is optional here. 
				- Use descending keyword to sort collection in descending order.
				
				OrderByDescending
				-----------------
				- Sorts the collection based on specified fields in descending order. Only valid in method syntax.
			  
			*/

			Console.WriteLine("Sorting Operators - OrderBy");

			//OrderBy Ascending Query
			var orderByResult = from s in studentList
								orderby s.StudentName //Sorts the studentList collection in ascending order
								select s;
			//OrderBy Ascending Method
			orderByResult = studentList.OrderBy(s => s.StudentName);
			PrintResult("OrderBy Ascending", orderByResult);

			//OrderBy Descending
			var orderByDescendingResult = from s in studentList //Sorts the studentList collection in descending order
										  orderby s.StudentName descending
										  select s;
			PrintResult("OrderBy Descending", orderByDescendingResult);

			//Multiple Shorting
			var multiSortingResult = from s in studentList
									 orderby s.StudentName, s.Age
									 select s;

			Console.WriteLine("Multiple Shorting");
			Console.WriteLine(new string('-', 30));
			foreach (var std in multiSortingResult)
				Console.WriteLine("Name: {0}, Age {1}", std.StudentName, std.Age);
			Console.WriteLine(new string('-', 30) + "\n");

			Console.WriteLine("Sorting Operators - OrderByDescending");
			var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);
			PrintResult("OrderByDescending", studentsInDescOrder);


			/*
			 *	Sorting Operators: ThenBy & ThenByDescending
				- ThenBy() method after OrderBy to sort the collection on another field in ascending order. 
				- Linq will first sort the collection based on primary field which is specified by OrderBy method and then sort the resulted collection in ascending order again based on secondary field specified by ThenBy method.
				
				ThenBy
				-------
				- Only valid in method syntax. Used for second level sorting in ascending order.
				
				ThenByDescending
				----------------
				- Only valid in method syntax. Used for second level sorting in descending order.
			
			*/
			Console.WriteLine("Sorting Operators: ThenBy & ThenByDescending");
			//ThenBy Method
			var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);
			//ThenByDescending Method
			var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);

			Console.WriteLine("ThenBy:");
			foreach (var std in thenByResult)
				Console.WriteLine("Name: {0}, Age:{1}", std.StudentName, std.Age);

			Console.WriteLine("ThenByDescending:");
			foreach (var std in thenByDescResult)
				Console.WriteLine("Name: {0}, Age:{1}", std.StudentName, std.Age);

			/*
			 *	Grouping Operators: GroupBy & ToLookup
			 	- The grouping operators do the same thing as the GroupBy clause of SQL query. 
				- The grouping operators create a group of elements based on the given key. 
				- This group is contained in a special type of collection that implements an IGrouping<TKey,TSource> interface where TKey is a key value, on which the group has been formed and TSource is the collection of elements that matches with the grouping key value.

				GroupBy
				--------
				- The GroupBy operator returns groups of elements based on some key value. Each group is represented by IGrouping<TKey, TElement> object.

				ToLookup
				---------
				- ToLookup is the same as GroupBy; the only difference is the execution of GroupBy is deferred whereas ToLookup execution is immediate.
				- Also, ToLookup is only applicable in Method syntax.
				
			*/

			//GroupBy Query
			Console.WriteLine();
			var groupByResult = from s in studentList
								group s by s.Age;

			//GroupBy Method
			groupByResult = studentList.GroupBy(s => s.Age);

			Console.WriteLine("GroupBy Output");
			Console.WriteLine(new string('-', 30));
			foreach (var ageGroup in groupByResult)
			{
				Console.WriteLine($"AgeGroup : {ageGroup.Key}");
				foreach (var std in ageGroup)
				{
					Console.WriteLine("Name : {0}, Age : {1}", std.StudentName, std.Age);
				}
				Console.WriteLine();
			}


			//ToLookup Method
			var lookupResult = studentList.ToLookup(s => s.Age);

			Console.WriteLine("ToLookup Method Output");
			Console.WriteLine(new string('-', 30));
			foreach (var ageGroup in lookupResult)
			{
				Console.WriteLine($"AgeGroup : {ageGroup.Key}");
				foreach (var std in ageGroup)
				{
					Console.WriteLine("Name : {0}, Age : {1}", std.StudentName, std.Age);
				}
				Console.WriteLine();
			}

			/*
			 *	Joining Operator: Join
				- The joining operators joins the two sequences (collections) and produce a result.
				- The Join operator operates on two collections, inner collection & outer collection. 
				- It returns a new collection that contains elements from both the collections which satisfies specified expression. It is the same as inner join of SQL.

				Join
				------
				- The Join operator joins two sequences (collections) based on a key and returns a resulted sequence.
				
				GroupJoin
				----------
				-The GroupJoin operator joins two sequences based on keys and returns groups of sequences. It is like Left Outer Join of SQL.
			*/

			Console.WriteLine("Joining Operator");

			// Join in Query
			var innerJoin = from s in studentList
							join st in standardList
							on s.StandardID equals st.StandardID
							select new
							{
								StudentName = s.StudentName,
								StandardName = st.StandardName
							};

			// Join in Method
			innerJoin = studentList.Join(
				standardList,
				student => student.StandardID,
				standard => standard.StandardID,
				(student, standard) => new
				{
					StudentName = student.StudentName,
					StandardName = standard.StandardName
				});

			Console.WriteLine("Join Output");
			Console.WriteLine(new string('-', 30));
			foreach (var obj in innerJoin)
			{
				Console.WriteLine("Name : {0}, Standard : {1}", obj.StudentName, obj.StandardName);
			}


			//GroupJoin in Query
			var groupJoin = from std in standardList
							join s in studentList
							on std.StandardID equals s.StandardID
							into studentGroup
							select new
							{
								Students = studentGroup,
								StandardName = std.StandardName
							};

			//GroupJoin in Method
			groupJoin = standardList.GroupJoin(studentList, standard => standard.StandardID, student => student.StandardID, (standard, studentsGroup) => new
			{
				Students = studentsGroup,
				StandardName = standard.StandardName
			});

			Console.WriteLine("GroupJoin Output");
			Console.WriteLine(new string('-', 30));
			foreach (var item in groupJoin)
			{
				Console.WriteLine(item.StandardName);
				foreach (var stud in item.Students)
				{
					Console.WriteLine(stud.StudentName);
				}
			}

			/*
			 *	Projection Operators: Select, SelectMany
				- There are two projection operators available in LINQ. 1) Select 2) SelectMany

				Select
				--------
				- The Select operator always returns an IEnumerable collection which contains elements based on a transformation function. 
				- It is similar to the Select clause of SQL that produces a flat result set.

				SelectMany
				-----------
				- The SelectMany operator projects sequences of values that are based on a transform function and then flattens them into one sequence.
 
			*/

			// Select in Query
			var selectResult = from s in studentList
							   select new { Name = s.StudentName, Age = s.Age };
			// Select in Method
			selectResult = studentList.Select(s => new { Name = s.StudentName, Age = s.Age });

			Console.WriteLine("Select Output");
			Console.WriteLine(new string('-', 30));
			foreach (var std in selectResult)
			{
				Console.WriteLine("Name : {0}, Age : {1}", std.Name, std.Age);
			}

			//Select Many
			var selectManyresult = from s in studentList
								   from name in s.StudentName
								   select name;

			/*
			 *	Quantifier Operators : All, Any, Contains
				- The quantifier operators evaluate elements of the sequence on some condition and return a boolean value to indicate that some or all elements satisfy the condition.
				
				All
				-----
				- The All operator evalutes each elements in the given collection on a specified condition and returns True if all the elements satisfy a condition.

				Any
				-----
				- Checks if any of the elements in a sequence satisfies the specified condition.

				Contains	
				---------
				- Checks if the sequence contains a specific element
			*/

			//All - checks whether all the students are teenagers 
			bool allStudentAreTeenage = studentList.All(s => s.Age > 12 && s.Age < 20);
            Console.WriteLine($"All Student Are Teenager? : {allStudentAreTeenage}");

			bool AnyStudentTeenage = studentList.Any(s => s.Age > 12 && s.Age < 20);
			Console.WriteLine($"Any one or more Student Teenager? : {AnyStudentTeenage}");

			/*
			 *	Aggregation Operators: Aggregate
				- The aggregation operators perform mathematical operations like Average, Aggregate, Count, Max, Min and Sum, on the numeric property of the elements in the collection.
				
				Aggregate
				-----------
				- Performs a custom aggregation operation on the values in the collection.

				Average
				-----------
				- calculates the average of the numeric items in the collection.

				Count
				-----------
				- Counts the elements in a collection.

				LongCount
				-----------
				- Counts the elements in a collection.

				Max
				-----------
				- Finds the largest value in the collection.

				Min
				-----------
				- Finds the smallest value in the collection.

				Sum
				-----------
				- Calculates sum of the values in the collection.
			
			*/

			//Aggregate
			string studentNames = studentList.Aggregate<Student, string>("Student List : ",(str, s) => str += s.StudentName + ", ");
            Console.WriteLine(studentNames);

			string commaSeparatedStudentNames = studentList.Aggregate<Student, string, string>(
											"Student List : ", // seed value
											(str, s) => str += s.StudentName + ", ", // returns result using seed value, String.Empty goes to lambda expression as str
											str => str.Substring(0, str.Length - 2));
			Console.WriteLine(commaSeparatedStudentNames);


			//Average
			var studentAgeAvg = studentList.Average(s => s.Age);
            Console.WriteLine($"Average of Student Age : {studentAgeAvg}");

			//Count
			var totalStudents = studentList.Count();
			Console.WriteLine("Total Students: {0}", totalStudents);

			var adultStudents = studentList.Count(s => s.Age >= 18);
			Console.WriteLine("Number of Adult Students: {0}", adultStudents);

			//Max
			var oldest = studentList.Max(s => s.Age);
			Console.WriteLine("Oldest Student Age: {0}", oldest);


			//Sum
			var sumOfAge = studentList.Sum(s => s.Age);
			Console.WriteLine("Sum of all student's age: {0}", sumOfAge);

			var numOfAdults = studentList.Sum(s => {
				if (s.Age >= 18)
					return 1;
				else
					return 0;
			});
			Console.WriteLine("Total Adult Students: {0}", numOfAdults);

            /*
			 *	Element Operators:
				- Element operators return a particular element from a sequence (collection).

				ElementAt
				----------------
				- Returns the element at a specified index in a collection

				ElementAtOrDefault
				----------------
				- Returns the element at a specified index in a collection or a default value if the index is out of range.

				First
				----------------
				- Returns the first element of a collection, or the first element that satisfies a condition.

				FirstOrDefault
				----------------
				- Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if index is out of range.

				Last
				----------------
				- Returns the last element of a collection, or the last element that satisfies a condition

				LastOrDefault
				----------------
				- Returns the last element of a collection, or the last element that satisfies a condition. Returns a default value if no such element exists.

				Single
				----------------
				- Returns the only element of a collection, or the only element that satisfies a condition.

				SingleOrDefault
				----------------
				- Returns the only element of a collection, or the only element that satisfies a condition. Returns a default value if no such element exists or the collection does not contain exactly one element.
			*/

            Console.WriteLine("1st Student Name in studentList : {0}",studentList.ElementAt(0).StudentName);
			//Console.WriteLine("1st Student Name in studentList : {0} ",studentList.ElementAt(5).StudentName); 
			// Its throw System.ArgumentOutOfRangeException exception

			Console.WriteLine("1st Student Name in studentList : {0} ",studentList.ElementAtOrDefault(0).StudentName); 


			Console.WriteLine("1st Student Name in studentList : {0} ", studentList.First().StudentName); 
			Console.WriteLine("1st Student Name which age more than 20 in studentList : {0} ", studentList.First(s=>s.Age>20).StudentName);

			List<int> list = new List<int>();
            Console.WriteLine(list.FirstOrDefault());

			Console.WriteLine("Last Student Name in studentList : {0} ", studentList.Last().StudentName);
			Console.WriteLine("Last Student Name which age more than 20 in studentList : {0} ", studentList.Last(s => s.Age > 20).StudentName);

			List<int> myList = new List<int>();
			Console.WriteLine(myList.LastOrDefault());


		}
		static void PrintResult(string title, IEnumerable<Student> resultList)
        {
			Console.WriteLine(title);
			Console.WriteLine(new string('-', 30));
			foreach (Student student in resultList)
				Console.WriteLine(student.StudentName);
			Console.WriteLine(new string('-', 30) + "\n");
		}
    }
}
