using System;

namespace FindVowel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Store your name in one string and find out how many vowel characters are there in your name.");
            string name = "Ankit Rudani";
            var count = 0;
            foreach (var ch in name)
            {
                if (char.ToLower(ch) == 'a' || char.ToLower(ch) == 'e' || char.ToLower(ch) == 'i' || char.ToLower(ch) == 'o' || char.ToLower(ch) == 'u')
                    count++;
            }

            Console.WriteLine($"There is {count} Vowel in '{name}'");
        }
    }
}
