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
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => Nonstop());
            thread1.Start();
        }
        static void Nonstop()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine($"#{threadId}: Urządzenie Pracuje");
            }
        }
        static void Nons()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{threadId} counter = {i}\n");
                if (i == 5 && threadId == 4)
                {
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}
