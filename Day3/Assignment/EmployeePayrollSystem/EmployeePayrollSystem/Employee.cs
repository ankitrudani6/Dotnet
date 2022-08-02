using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollSystem
{
    interface IEmp
    {
        void Get();
        void Display();
        int Salary();
    }

    abstract class Employee : IEmp
    {
        private static int ID = 0;
        private string Name, Address, PanNumber;


        public virtual void Get()
        {
            Employee.ID += 1;
            Console.Write("Enter Employee Name : ");
            Name = Console.ReadLine();

            Console.Write("Enter Employee Address : ");
            Address = Console.ReadLine();

            Console.Write("Enter Employee PanNumber : ");
            PanNumber = Console.ReadLine();
        }

        public virtual void Display()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Employee ID : {ID}\nName : {Name}\nAddress : {Address}\nPanNumber : {PanNumber}");
        }

        public abstract int Salary();
    }

    class PartTimeEmployee : Employee
    {
        private int NoOfHour, SalPerHour;

        public override void Get()
        {
            Console.WriteLine("Enter PartTime Employee's Details :");
            base.Get();

            Console.Write("Enter No. of Hour Employee Worked : ");
            NoOfHour = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Salary Per Hour : ");
            SalPerHour = Convert.ToInt32(Console.ReadLine());
        }

        public override int Salary()
        {
            return NoOfHour * SalPerHour;
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Salary : {Salary()}");
            Console.WriteLine("---------------------------------------");
        }

    }

    class FullTimeEmployee : Employee
    {
        private int Basic, HRA, TA, DA;

        public override void Get()
        {
            Console.WriteLine("Enter FullTime Employee's Details :");

            base.Get();

            Console.Write("Enter Employee's Basic Salary : ");
            Basic = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee's HRA Amount : ");
            HRA = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee's TA Amount : ");
            TA = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee's DA Amount : ");
            DA = Convert.ToInt32(Console.ReadLine());
        }

        public override int Salary()
        {
            return Basic + HRA + TA + DA;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Salary : {Salary()}");
            Console.WriteLine("---------------------------------------");
        }
    }
}
