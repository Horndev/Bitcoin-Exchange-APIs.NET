using BitExAPI.Money;
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
    public class KrakenPairs : PairsBase
    {
        public override string FormatPair(Currency bid, Currency asked)
        {
            throw new NotImplementedException();
        }

        public override string FormatPair(string bid, string asked)
        {
            string res = "XX";

            if (bid == "BTC")
                res += "BTZ";
            if (asked == "EUR")
                res += "EUR";
            return res;
        }
    }
}
