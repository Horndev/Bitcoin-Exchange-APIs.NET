using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// Class to format the pair labels from BitExAPI standard Money objects
    /// </summary>
    public class KrakenPair : PairsBase
    {
        public KrakenPair(Currency bid, Currency asked)
            : base(bid, asked)
        { }

        public KrakenPair(string krakenstring)
            : base(null, null)
        {
            if (krakenstring.Substring(0,2) == "XX")
            {
                string bid = krakenstring.Substring(2, 3);
                string ask = krakenstring.Substring(5, 3);
                if (bid == "BTZ")
                    bid = "BTC";
                _bid = Money.Currencies[bid];
                _asked = Money.Currencies[ask];
            }
            else
            {
                throw new Exception("Invalid string for Kraken pair");
            }
        }

        public override string ToString()
        {
            string res = "XX";
            if (_bid.ThreeLetter == "BTC")
                res += "BTZ";
            if (_asked.ThreeLetter == "EUR")
                res += "EUR";
            return res;
        }
    }
}
