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

        private string sinceLastTrade = "";     // Epoch time *10^9 of last received data
        private string sinceLastSpread = "";    // Epoch time of last received data (rounded to the second)

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

        /// <summary>
        /// Helper function for REST requests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope"></param>
        /// <param name="op"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private T makeRequest<T>(string scope, string op, Dictionary<string, string> parameters) where T : new()
        {
            var request = new RestRequest("{scope}/{op}", Method.POST);
            request.AddUrlSegment("scope", scope);
            request.AddUrlSegment("op", op);

            foreach(var param in parameters)
            {
                request.AddParameter(param.Key,param.Value);
            }
            IRestResponse<T> response = client.Execute<T>(request);

            return response.Data;
        }

        public MarketData RequestTrades()
        {
            string pair = "XXBTZEUR";
            //request parameters
            var p = new Dictionary<string, string>();
            p.Add("pair",pair);
            if (sinceLastTrade != "")
            {
                string sinceStr = Convert.ToString(sinceLastTrade);
                p.Add("since", sinceStr);
            }

            TradesResponse newTrades = makeRequest<TradesResponse>(
                scope: "public",
                op: "Trades",
                parameters: p);//response2.Data;

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
            string pair = "XXBTZEUR";
            //request parameters
            var p = new Dictionary<string, string>();
            p.Add("pair",pair);
            SpreadResponse r = makeRequest<SpreadResponse>("public", "spread", p);

            return r.ToMarketData();
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

        public void Stop()
        {
            getTradesThread.Abort();
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