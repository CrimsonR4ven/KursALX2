using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwnThings
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    Nonstop();
                });
            }
            Console.ReadKey();
        }
        static void Nonstop()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            while (true)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"#{threadId}: Urządzenie Pracuje");
                if(random.Next(1,10) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"#{threadId}: Urządzenie Zrobiło postęp");
                }
            }
        }
    }
}
