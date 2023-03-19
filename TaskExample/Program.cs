﻿using System;
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
            Task task1 = new Task(TestTask);
            task1.Start();
            Task task2 = Task.Factory.StartNew(TestTask);
            Task task3 = Task.Run(() =>
            {
                TestTask(12);
            });
            Task.WaitAny(new Task[] {task1,task2,task3});
            Console.WriteLine("Trwa wykonywanie zadania #1");
            Task.WaitAll(new Task[] { task1, task2, task3 });
            Console.WriteLine("ok");
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
    }
}