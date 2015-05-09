using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// https://api.kraken.com/0/public/Ticker
    /// </summary>
    public class TickerResponse : KrakenResponse
    {
        public override IMarketData ToMarketData()
        {
            Ticker t = new Ticker()
            {
                Ask = result.XXBTZEUR.a[0],
                Bid = result.XXBTZEUR.b[0],
                High = result.XXBTZEUR.h[0],
                Low = result.XXBTZEUR.l[0],
                Open = result.XXBTZEUR.o[0],
                TradeCount = result.XXBTZEUR.t[0],
                Volume = result.XXBTZEUR.v[0],
                VWAP = result.XXBTZEUR.p[0],
                BuyCurrency = Money.Currencies["BTC"],
                SellCurrency = Money.Currencies["EUR"]
            };
            return t;
        }

        public Resp result { get; set; }

        public class Resp
        {
            public CurrencyTick XXBTZEUR { get; set; }
        }

        public class CurrencyTick
        {
            public List<decimal> a { get; set; }
            public List<decimal> b { get; set; }
            public List<decimal> c { get; set; }
            public List<decimal> v { get; set; }
            public List<decimal> p { get; set; }
            public List<decimal> t { get; set; }
            public List<decimal> l { get; set; }
            public List<decimal> h { get; set; }
            public List<decimal> o { get; set; }
        }
    }
}

/*
<pair_name> = pair name
    a = ask array(<price>, <lot volume>),
    b = bid array(<price>, <lot volume>),
    c = last trade closed array(<price>, <lot volume>),
    v = volume array(<today>, <last 24 hours>),
    p = volume weighted average price array(<today>, <last 24 hours>),
    t = number of trades array(<today>, <last 24 hours>),
    l = low array(<today>, <last 24 hours>),
    h = high array(<today>, <last 24 hours>),
    o = today's opening price
*/

//{"error":[],"result":{"XXBTZEUR":{"a":["210.73129","7"],"b":["210.13000","1"],"c":["210.73129","0.01000000"],"v":["442.99912380","1008.09592889"],
//"p":["209.71012","208.09449"],"t":[535,1011],"l":["207.00000","205.85990"],"h":["211.25000","211.25000"],"o":"207.22589"}}}