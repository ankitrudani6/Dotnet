using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Assignment
{
    public class Mobike
    {
         public string BikeNumber;
         long PhoneNumber;
         string CustomerName;
         int Days;
         int Charge;

        public void Input() 
        {
            Console.Write("Enter Customer Name :");
            CustomerName = Console.ReadLine();

            Console.Write("Enter Phone Number : ");
            PhoneNumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Bike Number : ");
            BikeNumber = Console.ReadLine();

            Console.Write("Enter No of Days : ");
            Days = Convert.ToInt32(Console.ReadLine());

            Compute();
        }

        public void Compute()
        {
            if (Days <= 5)
                Charge = Days * 500;
            else if (Days <= 10)
                Charge = (5 * 500) + ((Days - 5) * 400);
            else
                Charge = (5 * 500) + (5 * 400) + ((Days-10)*200);
        }

        public void Display()
        {
            Console.WriteLine($"Bike No. : {BikeNumber}, No. Of Days : {Days}, Charge : {Charge}");
        }
    }
}
