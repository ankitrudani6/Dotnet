using System;

namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple Array
            int[] no = { 1, 2, 3, 4 };
            string[] name = new string[5];
            name[0] = "Ankit";
            name[1] = "Dhairya";

            int[] mark = new int[3] { 45, 56,65};

            Console.WriteLine("{0} : {1}",no,no.Length);
            Console.WriteLine("{0} : {1}",name, name.Length);
            Console.WriteLine("{0} : {1}",mark, mark.Length);

            Console.WriteLine($"Arry name : Name\nSize : {name.Length}\n----------------------------");
            foreach (string item in name)
            {
                Console.WriteLine(item+": isNull? "+String.IsNullOrEmpty(item));
            }
            Array.ForEach(no, Console.WriteLine);

            // Declare a single-dimensional array of 5 integers.
            int[] array1 = new int[5];

            // Declare and set array element values.
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };

            // Alternative syntax.
            int[] array3 = { 1, 2, 3, 4, 5, 6 };

            // Declare a two dimensional array.
            int[,] multiDimensionalArray1 = new int[2, 3];

            // Declare and set array element values.
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
        }
    }
}
