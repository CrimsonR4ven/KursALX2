using System;
using System.Threading;

namespace ThreadConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => LongOperation());
            Thread thread2 = new Thread(() => LongOperation());
            Thread thread3 = new Thread(() => LongOperationWithParams(15));
            Thread thread4 = new Thread(new ParameterizedThreadStart(LongOperationWithParams));
            Thread thread5 = new Thread(() => LongOperationWithParams(15,100));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start(4);
            //thread5.Start();

            Console.WriteLine("Koniec pracy");
            Console.ReadKey();
        }

        static void LongOperation()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{threadId} counter = {i}\n");
            }
        }
        static void LongOperationWithParams(object counter)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < (int)counter; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{threadId} counter = {i}\n");
            }
        }
        static void LongOperationWithParams(int counter, int delay)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < counter; i++)
            {
                Thread.Sleep(delay);
                Console.WriteLine($"{threadId} counter = {i}\n");
            }
        }
    }
}
