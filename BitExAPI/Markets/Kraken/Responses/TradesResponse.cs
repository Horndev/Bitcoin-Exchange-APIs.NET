using BitExAPI.Markets.Data;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitExAPI.Markets.Kraken
{
    public class TradesResponse : KrakenResponse
    {
        public override IMarketData ToMarketData()
        {
            Trades t = new Trades();
            var kvp = result.First();
            string tradesKrakenPair = kvp.Key;
            KrakenPair pair = new KrakenPair(tradesKrakenPair);
            t.BuyCurrency = pair.Bid;
            t.SellCurrency = pair.Ask;
            var tradepoints = kvp.Value;
            var last = Convert.ToString(result.Last().Value[0][0]);
            t.TradePoints = tradepoints.Select(x =>
                new TradePoint()
                {
                    OrderType = x.IsMarket ? "m" : "l",
                    Price = x.price,
                    TimeUTC = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(Convert.ToDouble(x.time)),
                    TradeType = x.TradeType,
                    Volume = x.volume
                }
                ).ToList();
            t.last = last;
            return t;
        }

        public Dictionary<string, List<X>> result { get; set; }

        public class X : List<object>
        {
            public decimal price
            {
                get
                {
                    return Convert.ToDecimal(this[0]);
                }
            }
            public decimal volume
            {
                get
                {
                    return Convert.ToDecimal(this[1]);
                }
            }
            public decimal time
            {
                get
                {
                    return Convert.ToDecimal(this[2]);
                }
            }
            public string TradeType
            {
                get
                {
                    return Convert.ToString(this[3]);
                }
            }
            public bool IsMarket
            {
                get
                {
                    return Convert.ToString(this[4]) == "m";
                }
            }
        }
    }
}