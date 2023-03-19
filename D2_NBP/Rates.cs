using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_NBP
{
    internal class Rates
    {
        [JsonProperty("currency")]
        public string CurrencyName { get; set; }
        [JsonProperty("code")]
        public string CurrencyCode { get; set; }
        [JsonProperty("mid")]
        public double AvgRate { get; set; }
    }
}
