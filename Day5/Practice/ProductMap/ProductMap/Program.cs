using System;
using System.Collections.Generic;

namespace ProductMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Products = new Dictionary<string, int>();
            Products.Add("Laptop", 45000);
            Products.Add("PC", 25000);
            Products.Add("Keyboard", 700);
            Products.Add("Mouse", 250);

            foreach (var item in Products.Keys)
            {
                Console.WriteLine("Name : {0,-10} , Price : {1}",item,Products[item]);
            }

            Console.Write("Enter Name to Search Product : ");
            string name = Console.ReadLine();

            if (Products.ContainsKey(name))
                Console.WriteLine("Name : {0,-10} Price : {1}",name,Products[name]);
            else
                Console.WriteLine("Product Not Found");
        }
    }
}
