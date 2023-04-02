using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4_StockWatcher.Classes
{
    public class AppleStockObserver : IObserver<Stock>
    {
        public void Update(Stock data)
        {
            if (data.Name.Equals("APL") && data.Price>=30)
            {
                Console.WriteLine("Akcje apple powyżej 30!");
            }
        }
    }
    public class TeslaAndIBMStockObserver : IObserver<Stock>
    {
        public void Update(Stock data)
        {
            if ((data.Name.Equals("TSLA") || data.Name.Equals("IBM")) && data.Price >= 20)
            {
                Console.WriteLine($"Akcje {data.Name} powyżej 20");
            }
        }
    }
}
