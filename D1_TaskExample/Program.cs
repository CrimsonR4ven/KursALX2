using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Task task1 = new Task(TestTask);
            task1.Start();
            Task task2 = Task.Factory.StartNew(TestTask);
            Task task3 = Task.Run(() =>
            {
                TestTask(12);
            });
                Task.WaitAll(new Task[] { task1, task2, task3 });
                Task.WaitAny(new Task[] {task1,task2,task3});
            Task<int> task4 = Task.Run(() => Add(10, 20));
            task4.ContinueWith(t1 =>
            {
                Task<float> task5 = Task.Run(() => Average(task4.Result, 2));
                task5.ContinueWith(t2 =>
                {
                    Console.WriteLine($"Wynik = {task5.Result}");
                });
            });
            Task.WaitAll(new Task[] { task4});
            Console.WriteLine($"ok {task4.Result}");*/

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            cts.CancelAfter(1000);
            Task taskCancel = Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(250);
                        Console.WriteLine($"Task iteracja [{i}]");
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine("Canceling");
                }
            }, ct);

            Console.WriteLine("Trwa wykonywanie zadania #1");
            Console.ReadKey();
        }
        static void TestTask()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] count value = {i}");
                Thread.Sleep(1000);
            }
        }
        static void TestTask(int nr)
        {
            Console.WriteLine($"Start zadania [{nr}]");
            Thread.Sleep(new Random().Next(100, 10000));
            Console.WriteLine($"Koniec zadania [{nr}]");
        }
        static int Add(int a, int b)
        {
            Console.WriteLine($"liczenie sumy dla {a} , {b}");
            Thread.Sleep(1000);
            return a + b;
        }
        static float Average(int sum, int n)
        {
            Console.WriteLine($"liczenie średniej dla sumy {sum} , {n} liczb");
            Thread.Sleep(1000);
            return sum / n;
        }
    }
}
