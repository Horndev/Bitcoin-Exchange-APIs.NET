
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public static class KrakenRequestFactory
    {
        public static KrakenRequest CreateTradesRequest(PairsBase pair, long since)
        {
            return new TradesRequest(pair, since);
        }

        public static KrakenRequest CreateTradesRequest(PairsBase pair, string since)
        {
            return new TradesRequest(pair, since);
        }
    }
}
