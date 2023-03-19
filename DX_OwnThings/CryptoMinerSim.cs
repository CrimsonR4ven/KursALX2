using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwnThings
{
    internal class CryptoMinerSim
    {
        static Random random = new Random();
        static void Nonstop()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            while (true)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"#{threadId}: Urządzenie Pracuje");
                if (random.Next(1, 10) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"#{threadId}: Urządzenie Zrobiło postęp");
                }
            }
        }
    }
}
