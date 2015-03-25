using BitExAPI.Events;
using BitExAPI.Markets.Data;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BitExAPI.Markets.Kraken
{
    /// <summary>
    /// Connection to Kraken Exchange
    /// </summary>
    public class KrakenConnection: IMarketConnection, IRestConnection
    {
        private string endpoint = "https://api.kraken.com/0/";
        private static RateLimiter requestLimiter = new RateLimiter();
        private RestClient client;
        private string sinceLastTrade = "";

        private Thread getTradesThread;

        #region Events
        
        /// <summary>
        /// Triggered when new trades are received
        /// </summary>
        public event EventHandler<TradesEventArgs> OnTrades;
        
        #endregion

        public KrakenConnection(string since = "")
        {
            client = new RestClient(endpoint);
            getTradesThread = new Thread(new ThreadStart(getTradesWorker));
            sinceLastTrade = since;
        }

        #region API commands

        public MarketData RequestTrades()
        {
            var request = new RestRequest("{scope}/{op}", Method.POST);

            request.AddParameter("pair", "XXBTZEUR");
            if (sinceLastTrade != "")
            {
                string sinceStr = Convert.ToString(sinceLastTrade);
                request.AddParameter("since", sinceStr);
            }
            request.AddUrlSegment("scope", "public");
            request.AddUrlSegment("op", "Trades");

            IRestResponse<TradesResponse> response2 = client.Execute<TradesResponse>(request);

            TradesResponse newTrades = response2.Data;
            if (newTrades != null)
            {
                if (newTrades.error == "[\"EAPI:Rate limit exceeded\"]")
                {
                    throw new Exception("Rate Limit Exceeded");
                }
                var t = newTrades.result.XXBTZEUR;
                sinceLastTrade = newTrades.result.last;

                if (OnTrades != null && t.Count > 0)
                    OnTrades(null, new Events.TradesEventArgs()
                    {
                        data = (Trades)newTrades.ToMarketData(),
                        APIName = "kraken",
                        LastTimeUTC_Epoch_e9 = Convert.ToInt64(sinceLastTrade)
                    });

                
            }

            return newTrades.ToMarketData();
        }

        public MarketData RequestSpreads()
        {
            throw new NotImplementedException();
        }

        #endregion

        public string RestEndpoint
        {
            get
            {
                return endpoint;
            }
            set
            {
                endpoint = value;
            }
        }

        #region MarketConnection Methods

        public void Start()
        {
            if (!getTradesThread.IsAlive)
                getTradesThread.Start();
        }

        #endregion

        #region thread workers

        private void getTradesWorker()
        {
            while (true)
            {
                requestLimiter.EnqueRequest(
                    () => RequestTrades(),      //note that only the events will be triggered
                    priority: 0);
            }
        }

        #endregion
    }
}