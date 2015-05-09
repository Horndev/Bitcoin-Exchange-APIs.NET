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
