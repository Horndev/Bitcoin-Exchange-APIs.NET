
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public static class KrakenRequestFactory
    {
        public static KrakenRequest CreateTradesRequest(PairsBase pair)
        {
            return new TradesRequest(pair);
        }
    }
}
