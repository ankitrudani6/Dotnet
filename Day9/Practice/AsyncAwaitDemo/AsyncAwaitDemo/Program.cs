using System;
using System.Threading.Tasks;
//a class called check is defined
class AsyncAwaitDemo
{
    static void Main()
    {
        while (true)
        {
            //the asynchronous method is called.
            keeptrying();
            string res = Console.ReadLine();
            Console.WriteLine("The input given by the user while the computation is going on by the asynchronous method is: " + res);
        }
    }
    static async void keeptrying()
    {
        //the caller function is asked to await
        int t = await Task.Run(() => compute());
        Console.WriteLine("The total digits count in the string is: " + t);
    }
    static int compute()
    {
        int counter = 0;
        for (int a = 0; a < 10; a++)
        {
            for (int b = 0; b < 1000; b++)
            {
                string value = b.ToString();
                counter += value.Length;
            }
        }
        return counter;
    }
}