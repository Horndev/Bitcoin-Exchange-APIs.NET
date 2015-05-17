
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    /// <summary>
    /// Create Requests from the exchange
    /// </summary>
    public static class KrakenRequestFactory
    {
        public static KrakenRequest Trades(PairsBase pair, long since)
        {
            return new RequestTrades(pair, since);
        }

        public static KrakenRequest Trades(PairsBase pair, string since)
        {
            return new RequestTrades(pair, since);
        }

        public static KrakenRequest WalletBalance()
        {
            return new RequestWalletBalance();
        }

        public static KrakenRequest OpenOrders()
        {
            return new RequestOpenOrders();
        }

        public static KrakenRequest Ticker()
        {
            throw new NotImplementedException();
        }
    }
}
