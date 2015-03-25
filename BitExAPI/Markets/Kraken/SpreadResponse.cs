using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    public class SpreadResponse: Response
    {
        //{"error":[],"result":{"XXBTZEUR":[[1427249283,"228.71756","229.18923"],[1427249283,"228.71756","229.17923"],[1427249286,"22

        public override Data.MarketData ToMarketData()
        {
            return new Spread();
        }

        public Resp result { get; set; }

        public class Resp
        {
            //<price>, <volume>, <time>, <buy/sell>, <market/limit>, <miscellaneous>
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
