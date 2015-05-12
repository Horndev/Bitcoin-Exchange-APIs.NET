using BitExAPI.Events;
using BitExAPI.Markets.Data;
using BitExAPI.Markets.Kraken;
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
        void StartBackgroundThread();
        void StopBackgroundThread();

        bool IsRunning { get; }
        uint TradeCount { get; } //Number of Trades Received

        void SetAPIKey(string key);
        void SetPrivateKey(string key);

        //---------------------------------------------------------------------
        // Manual Commands
        //---------------------------------------------------------------------

        Trades RequestTrades();
        IMarketData RequestSpreads();
        Ticker RequestTicker();
        DateTime RequestTime();
        AssetsResponse GetAssets();

        void GetBalances();
    }
}
