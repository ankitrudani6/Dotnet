using System;
using System.Collections;
using System.Collections.Generic;

namespace ListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            while (true)
            {
                Console.WriteLine(new string('-',25));
                Console.WriteLine("1. Add Number");
                Console.WriteLine("2. Display Numbers");
                Console.WriteLine("3. Update Number");
                Console.WriteLine("4. Sorted List");
                Console.WriteLine("5. Display Total Number");
                Console.WriteLine("6. Search Number");
                Console.WriteLine("7. Remove Number");
                Console.WriteLine(new string('-', 25));

                Console.Write("Enter Your Choice : ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            Console.Write("Enter Number : ");
                            int no = Convert.ToInt32(Console.ReadLine());
                            numbers.Add(no);
                            stack(numbers);
                            break;
                        }
                    case 2:
                        {
                            stack(numbers);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter Position to Update : ");
                            int p = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Updated Value : ");
                            int no = Convert.ToInt32(Console.ReadLine());

                            if(numbers.Count >= p)
                            {
                                numbers[p-1] = no;
                                stack(numbers);
                            }
                            else
                                Console.WriteLine("Index is out of Bound");
                            break;
                        }
                    case 4:
                        {
                            numbers.Sort();
                            stack(numbers);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Total No in List is : {numbers.Count}");
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Enter No For Search : ");
                            int no = Convert.ToInt32(Console.ReadLine());

                            if (numbers.Contains(no))
                            {
                                stack(numbers);
                                Console.WriteLine("{0} Found at {1} Position",no,numbers.IndexOf(no)+1);
                            }
                            else
                                Console.WriteLine("Number Not Found");
                            break;
                        }
                    case 7:
                        {
                            Console.Write("Enter Position to delete number : ");
                            int p = Convert.ToInt32(Console.ReadLine());
                            if(numbers.Count >= p)
                            {
                                numbers.RemoveAt(p - 1);
                                stack(numbers);
                            }
                            else
                                Console.WriteLine("Position is out of range");
                            break;
                        }
                }
            }
        }
        public static void Display(List<int> numbers)
        {
            if (numbers.Count == 0)
                Console.WriteLine("List is Empty");
            else
            {

                foreach (var no in numbers)
                {
                    Console.Write(no + " ");
                }
                Console.WriteLine();
            }
        }

        public static void stack(List<int> numbers)
        {
            Console.Clear();
            
            Console.WriteLine(new string('-',7*numbers.Count));
            foreach (var no in numbers)
            {
                
                if(numbers.IndexOf(no)+1 == numbers.Count)
                    Console.Write($"| {no,3} |");
                else
                    Console.Write($"| {no,3}  ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 7 * numbers.Count));
            Console.WriteLine($"Total Elements in List : {numbers.Count}");
        }

    }
}
