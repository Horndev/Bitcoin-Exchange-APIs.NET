using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// response from https://api.kraken.com/0/public/Time
    /// </summary>
    public class TimeResponse : Response
    {
        public Resp result { get; set; }

        public class Resp
        {
            public long unixtime { get; set; }
            public string rfc1123 { get; set; }
        }

        public override MarketData ToMarketData()
        {
            throw new NotImplementedException();
        }
    }
}

//{"error":[],"result":{"unixtime":1429311294,"rfc1123":"Fri, 17 Apr 15 22:54:54 +0000"}}