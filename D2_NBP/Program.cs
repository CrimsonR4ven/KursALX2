using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace D2_NBP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient wb = new WebClient();
            string s = wb.DownloadString("https://api.nbp.pl/api/exchangerates/tables/A/?format=json");
            JArray ja = JArray.Parse(s);
            IList<JToken> results = ja[0]["rates"].Children().ToList();
            List<Rates> rates = new List<Rates>();
            foreach (JToken token in results)
            {
                rates.Add(token.ToObject<Rates>());
            }
            foreach(var rate in rates) 
            {
                if(rate.CurrencyCode != "NOK")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine($"Nazwa:{rate.CurrencyName}\nKod:{rate.CurrencyCode}\nŚrednia cena: {rate.AvgRate}\n");
            }
            Console.ReadKey();
        }
    }
}
