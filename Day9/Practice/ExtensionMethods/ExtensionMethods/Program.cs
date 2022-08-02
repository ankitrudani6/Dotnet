using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    public static class MyExtensinos
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int VowelCount(this string str)
        {
            int count = 0;

            foreach (var ch in str.ToLower())
            {
                if (ch.Equals('a') || ch.Equals('e') || ch.Equals('i') || ch.Equals('o') || ch.Equals('u'))
                    count++;
            }
            return count;
        }

        public static string ChangeCase(this string str)
        {
            string s = null;
            foreach (var ch in str)
            {
                s +=(Char.IsUpper(ch)) ? Char.ToLower(ch) : Char.ToUpper(ch);
            }
            return s;
        }

        public static List<int> PrimeList(this List<int> ls)
        {
            bool isPrime = true;
            List<int> primeNos = new List<int>();
            ls.ForEach(n =>
            {
                isPrime = true;
                if (n <= 1) isPrime = false;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                    if (n % i == 0) isPrime = false;
                if (isPrime) primeNos.Add(n);
            });
            return primeNos;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World";
            Console.WriteLine($"No of Word : {s.WordCount()}");
            Console.WriteLine($"No of Vowel : {s.VowelCount()}");
            Console.WriteLine($"Change Case :{s.ChangeCase()}");


            List<int> numbers = new List<int>();

            Console.WriteLine("Enter range to find prime number : ");
            int l = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= l; i++)
            {
                numbers.Add(i);
            }

            numbers.ForEach(n => Console.Write(n+" "));
            Console.WriteLine();
            numbers.PrimeList().ForEach(n => Console.Write(n+" "));


        }
    }
}
