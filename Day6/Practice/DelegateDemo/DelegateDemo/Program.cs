using System;

namespace DelegateDemo
{
    class Program
    {
        public delegate int dg_test(int a,int b);

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }
        static void Main(string[] args)
        {
            dg_test d = Add;
            d += Sub;

            int result = 0;
            if (d != null)
                result = d(10,5);
            Console.WriteLine(result);
        }
    }
    
}
