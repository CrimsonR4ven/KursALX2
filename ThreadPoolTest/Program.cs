using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolTest
{
    internal class Program
    {
        static int totalURLs;
        static void Main(string[] args)
        {

            List<string> URLs = new List<string>()
            {
                "https://onet.pl",
                "https://gry.pl",
                "https://xkom.pl",
                "https://alx.pl"
            };
            ThreadPool.SetMinThreads(5, 5);
            ThreadPool.SetMaxThreads(15, 15);
            totalURLs = URLs.Count;
            foreach (var url in URLs)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DownloadData),url);
            }
            /*for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(CustomMethod));
            }*/
            Console.ReadKey();
        }
        static void DownloadData(object urlObject)
        {
            string url = (string)urlObject;
            Console.WriteLine($"pobieram dane z {url}");
            WebClient client = new WebClient();
            string data = client.DownloadString(url);
            Interlocked.Decrement(ref totalURLs);
            Console.WriteLine($"\nZakończono pobieranie {url}, \nLiczba danych: {data.Length} \nDo pobrania zostały {totalURLs} strony");
        }
        static void CustomMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine($"ThreadID: #{thread.ManagedThreadId}");
            Thread.Sleep(10000);
        }
    }
}
