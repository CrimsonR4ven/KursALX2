using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LockPerformance lockPerformance = new LockPerformance();
            Console.WriteLine($"lock = {lockPerformance.ClassicLock()}");
            Console.WriteLine($"semaphore = {lockPerformance.Semaphore()}");
            Console.WriteLine($"monitor = {lockPerformance.MonitorLock()}");
            Console.ReadKey();
        }
    }
}
