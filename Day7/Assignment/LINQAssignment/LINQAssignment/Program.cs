using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>() {
               new Employee() { ID = 1, FirstName ="John", LastName ="Abraham", Salary = 1000000, JoiningDate = new DateTime(2013, 1, 1), Deparment ="Banking"},
               new Employee() { ID = 2, FirstName ="Michael", LastName ="Clarke", Salary = 800000, JoiningDate = new DateTime(), Deparment ="Insurance" },
               new Employee() { ID = 3, FirstName ="oy", LastName ="Thomas", Salary = 700000, JoiningDate = new DateTime(), Deparment ="Insurance"},
               new Employee() { ID = 4, FirstName ="Tom", LastName ="Jose", Salary = 600000, JoiningDate = new DateTime(), Deparment ="Banking"},
               new Employee() { ID = 4, FirstName ="TestName2", LastName ="Lname %", Salary = 600000, JoiningDate = new DateTime(2013, 1, 1), Deparment ="Services"}
            };
            List<Incentive> incentives = new List<Incentive>() {
               new Incentive() { ID = 1, IncentiveAmount = 5000, IncentiveDate = new DateTime(2013, 02, 02) },
               new Incentive() { ID = 2, IncentiveAmount = 10000, IncentiveDate = new DateTime(2013, 02, 4) },
               new Incentive() { ID = 1, IncentiveAmount = 6000, IncentiveDate = new DateTime(2012, 01, 5) },
               new Incentive() { ID = 2, IncentiveAmount = 3000, IncentiveDate = new DateTime(2012, 01, 5) }
            };


            Console.WriteLine("Query 1 - Get employee details from employees object whose employee name is “John”");
            Console.WriteLine(new string('-',100));
            var empDetails = employees.Where(e => e.FirstName == "John").Single();
            Console.WriteLine($"Employee ID : {empDetails.ID}\nFirstName : {empDetails.FirstName}\nLastName : {empDetails.LastName}\nSalary : {empDetails.Salary}\nDepartment : {empDetails.Deparment}");

            Console.WriteLine("\nQuery 2 - Get FIRSTNAME,LASTNAMe from employees object(note project operator)");
            Console.WriteLine(new string('-', 100));
            var allEmp = employees.Select(e => new { e.FirstName, e.LastName });
            foreach (var emp in allEmp)
            {
                Console.WriteLine("FirstName : {0},\t LastName : {1}",emp.FirstName,emp.LastName);
            }

            Console.WriteLine("\nQuery 3 - Select FirstName, IncentiveAmount from employees and incentives object for those employees who have incentives.(join operator)");
            Console.WriteLine(new string('-', 100));
            var incentivesEmp = from e in employees
                                join i in incentives
                                on e.ID equals i.ID
                                select new
                                {
                                    FirstName = e.FirstName,
                                    Incentive = i.IncentiveAmount
                                };
            foreach (var emp in incentivesEmp)
            {
                Console.WriteLine("FirstName : {0}, Incentive Amount : {1}",emp.FirstName,emp.Incentive);
            }


            Console.WriteLine("\nQuery 4 - Get department wise maximum salary from employee table order by salary ascending (note group by)");
            Console.WriteLine(new string('-', 100));

            var deptMaxSal = employees.GroupBy(e => e.Deparment).Select(grp => new { Deparment = grp.Key, MaxSalary = grp.Max(e => e.Salary) }).OrderBy(a => a.MaxSalary);
            foreach (var emp in deptMaxSal)
            {
                Console.WriteLine("Department : {0}, MaxSalary : {1}",emp.Deparment,emp.MaxSalary);
            }


            Console.WriteLine("\nQuery 5 - Select department, total salary with respect to a department from employees object where total salary greater than 800000 order by TotalSalary descending(group by having)");
            Console.WriteLine(new string('-', 100));
            var totalSalDept = employees.GroupBy(e => e.Deparment).Select(grp => new { Department = grp.Key, TotalSalary = grp.Sum(s=>s.Salary)}).Where(ts=>ts.TotalSalary>800000).OrderByDescending(ts=>ts.TotalSalary);

            var exp = from e in employees
                      group e by e.Deparment
                      into newgrp
                      select new { Department = newgrp.Key, TotalSalary = newgrp.Sum(t => t.Salary) } into result
                      where result.TotalSalary > 800000
                      select result;
                   


            foreach (var item in exp)
            {
                Console.WriteLine("Department : {0}, Total Salary : {1}", item, item.TotalSalary);
            }
        }
    }
}
