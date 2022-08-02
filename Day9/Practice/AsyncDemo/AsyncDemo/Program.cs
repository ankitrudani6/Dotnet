using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Method1();
            Thread th = Thread.CurrentThread;
            th.Name = "MainThread";
            Console.WriteLine("This is {0} : {1}", th.Name, th.IsAlive);
            await Method2();
        }
        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method 1 : " + DateTime.Now.Millisecond);
                }
            });
        }
        public static async Task Method2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Method 2 : " + DateTime.Now.Millisecond);
                }
            });
        }
    }
}

