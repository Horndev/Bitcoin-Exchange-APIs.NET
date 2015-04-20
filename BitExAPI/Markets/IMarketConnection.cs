using BitExAPI.Events;
using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    //public delegate void TradesUpdatedEvent(TradesResponse trades, string APIName);

    public interface IMarketConnection
    {
        event EventHandler<TradesEventArgs> OnTrades;   //Recieved new trades message
        event EventHandler<SpreadEventArgs> OnSpread;   //Spread info updated

        /// <summary>
        /// Start a thread to begin receiving data from the exchange.
        ///     As data is recieved, the market events will be triggered.
        /// </summary>
        void Start();
        void Stop();

        bool IsRunning { get; }

        //---------------------------------------------------------------------
        // Manual Commands
        //---------------------------------------------------------------------

        MarketData RequestTrades();
        MarketData RequestSpreads();
        MarketData RequestTicker();

    }
}
