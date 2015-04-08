using BitExAPI.Money;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Data
{
    public class Trades : MarketData
    {
        public Currency BuyCurrency;        //This balance increases with bid
        public Currency SellCurrency;       //This balance increases with ask
        public List<TradePoint> TradePoints;
    }

    public class TradePoint
    {
        [JsonIgnore]
        public DateTime TimeUTC {get; set;}

        [JsonProperty("t")]
        public long datetime
        {
            get
            {
                return TimeUTC.ToBinary();
            }
            set
            {
                TimeUTC = DateTime.FromBinary(value);
            }
        }

        [JsonProperty("p")]
        public decimal Price {get; set;}

        [JsonProperty("v")]
        public decimal Volume {get; set;}

        [JsonProperty("y")]
        public string TradeType {get; set;}    // b = buy/bid, s = sell/ask

        [JsonProperty("o")]
        public string OrderType {get; set;}    // m = market l = limit

        public override string ToString()
        {
            return TimeUTC.ToLongTimeString() + ": " + Convert.ToString(Volume) + " @ " + Convert.ToString(Price);
        }
    }
}
