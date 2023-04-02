using D4_StockWatcher.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4_StockWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var observableStock = new Observable<Stock>();

            // obserwator dla IBM
            TeslaAndIBMStockObserver teslaAndIBMStockObserver = new TeslaAndIBMStockObserver();
            observableStock.Subscribe(teslaAndIBMStockObserver);

            // i dla apple
            AppleStockObserver appleStockObserver = new AppleStockObserver();
            observableStock.Subscribe(appleStockObserver);

            StockDummySimulator simulator = new StockDummySimulator();
            foreach(var item in simulator)
            {
                Console.WriteLine($"Generator danych: {item.Name}-{item.Price}");
                observableStock.Subject = item;
            }
            Console.ReadKey();
        }
    }
}
