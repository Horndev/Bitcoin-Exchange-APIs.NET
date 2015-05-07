using BitExAPI.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class TradesRequest : KrakenRequest
    {
        public PairsBase Pair;
        public Int64 SinceTimeUTC_Epoch_e9;

        public TradesRequest()
        {
            this.RestResource = "{scope}/{op}";
            this.RestResourceSegments = new Dictionary<string, string>() { { "scope", "public" }, { "op", "Time" } };
        }
    }
}
