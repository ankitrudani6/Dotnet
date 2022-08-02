using System;

namespace EmployeePayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new PartTimeEmployee();
            employee.Get();
            employee.Display();

            employee = new FullTimeEmployee();
            employee.Get();
            employee.Display();

        }
    }
}
