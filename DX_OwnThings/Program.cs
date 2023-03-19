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
            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    Nonstop();
                });
            }
            Console.ReadKey();
        }
        
    }
}
