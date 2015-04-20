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
    public class TickerResponse : Response
    {
        public override MarketData ToMarketData()
        {
            throw new NotImplementedException();
        }

        public Resp result { get; set; }

        public class Resp
        {
            public CurrencyTick XXBTZEUR { get; set; }
        }

        public class CurrencyTick
        {
            public List<decimal> a { get; set; }
        }
    }
}

//{"error":[],"result":{"XXBTZEUR":{"a":["210.73129","7"],"b":["210.13000","1"],"c":["210.73129","0.01000000"],"v":["442.99912380","1008.09592889"],"p":["209.71012","208.09449"],"t":[535,1011],"l":["207.00000","205.85990"],"h":["211.25000","211.25000"],"o":"207.22589"}}}