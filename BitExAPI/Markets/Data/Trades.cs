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
        public DateTime TimeUTC;
        public decimal Price;
        public decimal Volume;
        public string TradeType;    // b = buy/bid, s = sell/ask
        public string OrderType;    // m = market l = limit
    }
}
