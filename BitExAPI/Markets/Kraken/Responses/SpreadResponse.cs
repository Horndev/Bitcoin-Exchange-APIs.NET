using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    public class SpreadResponse: KrakenResponse
    {
        //{"error":[],"result":{"XXBTZEUR":[[1427249283,"228.71756","229.18923"],[1427249283,"228.71756","229.17923"],[1427249286,"22

        public override Data.IMarketData ToMarketData()
        {
            return new Spread()
            {
                BuyCurrency = Money.Currencies["BTC"],
                SellCurrency = Money.Currencies["EUR"],
                SpreadPoints = result.XXBTZEUR.Select(x => new SpreadPoint()
                {
                    TimeUTC = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(Convert.ToDouble(x.time)),
                    BestBid = x.bestBid,
                    BestAsk = x.bestAsk
                }).ToList()
            };

        }

        public Resp result { get; set; }

        public class Resp
        {
            public List<X> XXBTZEUR { get; set; }
            public string last { get; set; }
        }

        public class X : List<object>
        {
            public decimal time
            {
                get
                {
                    return Convert.ToDecimal(this[0]);
                }
            }
            public decimal bestBid
            {
                get
                {
                    return Convert.ToDecimal(this[1]);
                }
            }
            public decimal bestAsk
            {
                get
                {
                    return Convert.ToDecimal(this[2]);
                }
            }
        }
    }
}
