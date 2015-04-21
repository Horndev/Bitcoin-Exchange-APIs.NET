using BitExAPI.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Data
{
    public class Ticker : MarketData
    {
        public Currency BuyCurrency;        //This balance increases with bid
        public Currency SellCurrency;       //This balance increases with ask

        public decimal Open;
        public decimal High;
        public decimal Low;
        public decimal Bid;
        public decimal Ask;
        public decimal Volume;
        public decimal VWAP;
        public decimal TradeCount;
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