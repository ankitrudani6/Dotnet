using System;

namespace StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = "This is a string created by assignment.";
            Console.WriteLine(string1);
            string string2a = "The path is C:\\PublicDocuments\\Report1.doc";
            Console.WriteLine(string2a);
            string string2b = @"The path is C:\PublicDocuments\Report1.doc";
            Console.WriteLine(string2b);

            char[] chars = { 'w', 'o', 'r', 'd' };
            sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

            // Create a string from a character array.
            string string3 = new string(chars);
            Console.WriteLine(string3);

            // Create a string that consists of a character repeated 20 times.
            string string4 = new string('c', 20);
            Console.WriteLine(string4);

            string string5 = "Today is " + DateTime.Now.ToString("D") + ".";
            Console.WriteLine(string5);

            string string6 = "This is one sentence. " + "This is a second. ";
            string6 += "This is a third sentence.";
            Console.WriteLine(string6);
            // The example displays output like the following:
            //    Today is Tuesday, July 06, 2011.
            //    This is one sentence. This is a second. This is a third sentence.

            Console.WriteLine("------------------------------------");
            string sentence = "This sentence has five words.";
            // Extract the second word.
            int startPosition = sentence.IndexOf(" ") + 1;
            string word2 = sentence.Substring(startPosition,
                                              sentence.IndexOf(" ", startPosition) - startPosition);
            Console.WriteLine("Sentence : "+sentence);
            Console.WriteLine("Second word: " + word2);
            // The example displays the following output:
            //       Second word: sentence
        }
    }
}
