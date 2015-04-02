using BitExAPI.Money;
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
        public DateTime TimeUTC {get; set;}
        public decimal Price {get; set;}
        public decimal Volume {get; set;}
        public string TradeType {get; set;}    // b = buy/bid, s = sell/ask
        public string OrderType {get; set;}    // m = market l = limit

        public override string ToString()
        {
            return TimeUTC.ToLongTimeString() + ": " + Convert.ToString(Volume) + " @ " + Convert.ToString(Price);
        }
    }
}
