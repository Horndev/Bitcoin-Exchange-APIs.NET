using BitExAPI.Money;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Data
{
    public class Spread : IMarketData
    {
        public Currency BuyCurrency;        //This balance increases with bid
        public Currency SellCurrency;       //This balance increases with ask
        public List<SpreadPoint> SpreadPoints;
    }

    public class SpreadPoint
    {
        [JsonIgnore]
        public DateTime TimeUTC { get; set; }

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

        [JsonProperty("b")]
        public decimal BestBid { get; set; }

        [JsonProperty("a")]
        public decimal BestAsk { get; set; }

        public override string ToString()
        {
            return TimeUTC.ToLongTimeString() + " : " + Convert.ToString(BestAsk) + "-" + Convert.ToString(BestBid);
        }
    }
    
}
