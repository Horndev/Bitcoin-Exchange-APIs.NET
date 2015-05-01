using BitExAPI.Markets.Data;
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
            t.BuyCurrency = Money.Money.Currencies["BTC"];
            t.SellCurrency = Money.Money.Currencies["EUR"];
            t.TradePoints = result.XXBTZEUR.Select(x =>
                new TradePoint() { 
                    OrderType = x.IsMarket ? "m" : "l",
                    Price = x.price,
                    TimeUTC =  new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(Convert.ToDouble(x.time)),
                    TradeType = x.TradeType,
                    Volume = x.volume
                }
                ).ToList();
            return t;
        }

        public Resp result {get;set;}
        
        public class Resp
        {
            //<price>, <volume>, <time>, <buy/sell>, <market/limit>, <miscellaneous>
            public List<X> XXBTZEUR {get;set;}
            public string last { get; set; }
        }

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