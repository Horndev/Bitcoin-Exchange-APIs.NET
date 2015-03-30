using BitExAPI.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Data
{
    public class Spread : MarketData
    {
        public Currency BuyCurrency;        //This balance increases with bid
        public Currency SellCurrency;       //This balance increases with ask
        public List<SpreadPoint> SpreadPoints;
    }

    public class SpreadPoint
    {
        public DateTime TimeUTC;
        public decimal BestBid;
        public decimal BestAsk;
    }
    
}
