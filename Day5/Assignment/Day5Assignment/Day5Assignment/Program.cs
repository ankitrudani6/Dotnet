using System;
using System.Collections.Generic;

namespace Day5Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mobike> RentalList = new List<Mobike>();
            while (true)
            {
                Console.WriteLine("1. Add Customer with Bike Details");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Edit Rental Details");
                Console.WriteLine("4. Search Recored by Bike Number");
                Console.WriteLine("5. Search Record by Customer Name");
                Console.WriteLine("6. Delete Record");

                Console.Write("Enter Your Choice : ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            Mobike mb = new Mobike();
                            mb.Input();
                            RentalList.Add(mb);
                            break;
                        }
                    case 2:
                        {
                            if(RentalList.Count == 0)
                                Console.WriteLine("No Recored Found");
                            else
                            {
                                foreach (var item in RentalList)
                                {
                                    item.Display();
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Bike No to Edit : ");
                            string bno = Console.ReadLine();


                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Bike No to Search : ");
                            string bno = Console.ReadLine();

                            Search(RentalList,bno);
                            break;
                        }
                }
            }

        }

        public static void Search(List<Mobike> mb, string bno)
        {
            foreach (var item in mb)
            {
                if (item.BikeNumber == bno)
                    item.Display();
            }
        }
    }
}
