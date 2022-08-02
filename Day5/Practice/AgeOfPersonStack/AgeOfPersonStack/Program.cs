using System;
using System.Collections.Generic;

namespace AgeOfPersonStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> Age = new Stack<int>();
            Age.Push(23);
            Age.Push(54);
            Age.Push(14);
            Age.Push(64);
            Age.Push(4);

            foreach (var no in Age)
            {
                Console.Write(no+" ");
            }

        }
    }
}
