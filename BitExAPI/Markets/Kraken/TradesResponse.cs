using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitExAPI.Markets.Kraken
{
    public class TradesResponse
    {
        public string error {get;set;}
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