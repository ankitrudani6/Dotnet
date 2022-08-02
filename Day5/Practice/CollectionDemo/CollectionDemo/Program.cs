using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList()
            // adding elements using ArrayList.Add() method
            var arlist1 = new ArrayList();
            arlist1.Add(1);
            arlist1.Add("Bill");
            arlist1.Add(" ");
            arlist1.Add(true);
            arlist1.Add(4.5);
            arlist1.Add(null);

            // adding elements using object initializer syntax
            var arlist2 = new ArrayList()
            {
                2, "Steve", " ", true, 4.5, null
            };


            foreach (var item in arlist1)
                Console.Write(item + ", ");
            Console.WriteLine();
            foreach (var item in arlist2)
                Console.Write(item + ", ");

            //List()

            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(1); // adding elements using add() method
            primeNumbers.Add(3);
            primeNumbers.Add(5);
            primeNumbers.Add(7);

            //adding elements using collection-initializer syntax
            var bigCities = new List<string>()
                {
                    "New York",
                    "London",
                    "Mumbai",
                    "Chicago"
                };
            Console.WriteLine();
            //ShortedList()
            SortedList<int, string> numberNames = new SortedList<int, string>()
                                {
                                    {3, "Three"},
                                    {5, "Five"},
                                    {1, "One"}
                                };

            Console.WriteLine("---Initial key-values--");

            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            numberNames.Add(6, "Six");
            numberNames.Add(2, "Two");
            numberNames.Add(4, "Four");

            Console.WriteLine("---After adding new key-values--");

            foreach (var kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine();
            IDictionary<int, string> numdict = new Dictionary<int, string>();
            numdict.Add(1, "One"); //adding a key/value using the Add() method
            numdict.Add(2, "Two");
            numdict.Add(3, "Three");

            //The following throws run-time exception: key already added.
            //numberNames.Add(3, "Three"); 

            foreach (KeyValuePair<int, string> kvp in numdict)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

            //creating a dictionary using collection-initializer syntax
            var cities = new Dictionary<string, string>(){
            {"UK", "London, Manchester, Birmingham"},
            {"USA", "Chicago, New York, Washington"},
            {"India", "Mumbai, New Delhi, Pune"}
            };

            foreach (var kvp in cities)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        }
    }
}
