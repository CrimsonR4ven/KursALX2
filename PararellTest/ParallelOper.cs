using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PararellTest
{
    internal class ParallelOper
    {
        Random random = new Random();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public void LoopParallelCancel()
        {
            new Thread(() =>
            {
                Thread.Sleep(3000);
                cancellationTokenSource.Cancel();
            }).Start();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 10;
            options.CancellationToken = cancellationTokenSource.Token;
            try
            {
                Parallel.For(0, 10, options, i =>
                {
                    long total = LongOperation();
                    Console.WriteLine($"{i} - {total}");
                    Thread.Sleep(1000);
                    if ( i > 5 ) 
                    {
                        
                    }
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();
            Console.WriteLine($"LoopWithPararell - {sw.Elapsed.TotalMilliseconds}\n");
        }
        public void LoopNoParallel()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10; i++)
            {
                long total = LongOperation();
                Console.WriteLine($"{i} - {total}");
            }
            sw.Stop();
            Console.WriteLine($"LoopNoPararell - {sw.Elapsed.TotalMilliseconds}\n");
        }
        public void LoopWithParallel()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 10;
            Parallel.For(0, 10, options,i =>
            {
                long total = LongOperation();
                Console.WriteLine($"{i} - {total}");
            });
            sw.Stop();
            Console.WriteLine($"LoopWithPararell - {sw.Elapsed.TotalMilliseconds}\n");
        }
        public void LoopWithParallelBreakStop()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 10;
            Parallel.For(0, 10, options, (i,loopState) =>
            {
                long total = LongOperation();
                if (i == 5)
                {
                    loopState.Stop();
                }
                Console.WriteLine($"{i} - {total}");
            });
            sw.Stop();
            Console.WriteLine($"LoopWithPararellBreakStop - {sw.Elapsed.TotalMilliseconds}\n");
        }
        public void LoopWithParallelForeach()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 10;
            List<int> intigersList = Enumerable.Range(0, 10).ToList();
            Parallel.ForEach( intigersList, options, (i) =>
            {
                long total = LongOperation();
                Console.WriteLine($"{i} - {total}");
            });
            sw.Stop();
            Console.WriteLine($"LoopWithPararellForEach - {sw.Elapsed.TotalMilliseconds}\n");
        }
        public void ParallelInvoke()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 4;
            Parallel.Invoke(options, () => TestTask(1), () => TestTask(2), () => TestTask(3), () => TestTask(4));
            Console.WriteLine("Koniec");
        }
        private long LongOperation()
        {
            long total = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                total += i;
            }
            return total;
        }
        private void TestTask(int nr)
        {
            Console.WriteLine($"Start zadania [{nr}]");
            Thread.Sleep(random.Next(100,10000));
            Console.WriteLine($"Koniec zadania [{nr}]");
        }
    }
}
