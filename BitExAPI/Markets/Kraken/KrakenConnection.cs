using BitExAPI.Events;
using BitExAPI.Markets.Data;
using BitExAPI.Markets.Kraken.Requests;
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
        //Kraken default endpoint
        private string endpoint = "https://api.kraken.com/0/";
        private static RateLimiter requestLimiter = new RateLimiter();
        private RestClient client; // RestSharp client

        private string sinceLastTrade = "";     // Epoch time *10^9 of last received data
        private string sinceLastSpread = "";    // Epoch time of last received data (rounded to the second)
        private uint tradeCount = 0;            // Number of trades received to date

        private Thread getTradesThread; // polling thread
        private Thread getSpreadsThread; // polling thread

        #region Events
        
        /// <summary>
        /// Triggered when new trades are received
        /// </summary>
        public event EventHandler<TradesEventArgs> OnTrades;
        public event EventHandler<SpreadEventArgs> OnSpread;
        
        #endregion

        public KrakenConnection(string SinceTrade = "", string SinceSpread = "")
        {
            client = new RestClient(endpoint);
            getTradesThread = new Thread(new ThreadStart(getTradesWorker));
            getSpreadsThread = new Thread(new ThreadStart(getSpreadsWorker));
            sinceLastTrade = SinceTrade;
            sinceLastSpread = SinceSpread;
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

        public R RestRequest<T, R>(string resource, Dictionary<string, string> segments, Dictionary<string, string> parameters)
            where T : RestResponse, new()
            where R : IMarketData
        {
            var request = new RestRequest(resource, Method.POST);
            foreach (var kvp in segments)
            {
                request.AddUrlSegment(kvp.Key, kvp.Value);
            }

            if (parameters != null)
                foreach (var param in parameters)
                {
                    request.AddParameter(param.Key, param.Value);
                }

            IRestResponse<T> response = client.Execute<T>(request);

            return (R)response.Data.ToMarketData();
        }

        public Trades RequestTrades()
        {
            KrakenRequest req = KrakenRequestFactory.CreateTradesRequest(
                pair: new KrakenPair(Money.Currencies["BTC"], Money.Currencies["EUR"]),
                since: sinceLastTrade);

            return req.Execute(connection: this) as Trades;

            
            ////request parameters

            //TradesResponse newTrades = makeRequest<TradesResponse>(
            //    scope: "public",
            //    op: "Trades",
            //    parameters: p);//response2.Data;

            //if (newTrades != null)
            //{
            //    if (newTrades.error == "[\"EAPI:Rate limit exceeded\"]")
            //    {
            //        throw new Exception("Rate Limit Exceeded");
            //    }
            //    var t = newTrades.result.XXBTZEUR;
            //    sinceLastTrade = newTrades.result.last;
            //    tradeCount += Convert.ToUInt32(t.Count);  //Performance counter

            //    if (OnTrades != null && t.Count > 0)
            //    {
            //        OnTrades(null, new Events.TradesEventArgs()
            //        {
            //            data = (Trades)newTrades.ToMarketData(),
            //            APIName = "kraken",
            //            LastTimeUTC_Epoch_e9 = Convert.ToInt64(sinceLastTrade)
            //        });
            //    }
            //}

            //return newTrades.ToMarketData() as Trades;
        }

        public IMarketData RequestSpreads()
        {
            string pair = "XXBTZEUR";
            //request parameters
            var p = new Dictionary<string, string>();
            p.Add("pair",pair);

            if (sinceLastSpread != "")
            {
                string sinceStr = Convert.ToString(sinceLastSpread);
                p.Add("since", sinceStr);
            }

            //https://api.kraken.com/0/public/Spread
            SpreadResponse r = makeRequest<SpreadResponse>("public", "Spread", p);

            sinceLastSpread = r.result.last;

            //Trigger event
            if (OnSpread != null)
            {
                OnSpread(this, new SpreadEventArgs()
                    {
                        Data = (Spread)r.ToMarketData(),
                        LastTimeUTC_epoch = Convert.ToInt64(sinceLastSpread),
                        APIName = "kraken"
                    });
            }

            return r.ToMarketData();
        }

        public Ticker RequestTicker()
        {
            string pair = new KrakenPair(Money.Currencies["BTC"], Money.Currencies["EUR"]).ToString();
            var p = new Dictionary<string, string>();
            p.Add("pair", pair);

            return RestRequest<TickerResponse, Ticker>(
                resource: "{scope}/{op}",
                segments: new Dictionary<string, string>() { { "scope", "public" }, { "op", "Ticker" } },
                parameters: p);
        }

        public DateTime RequestTime()
        {
            var D = RestRequest<TimeResponse, Date>(
                resource: "{scope}/{op}",
                segments: new Dictionary<string, string>() { { "scope", "public" }, { "op", "Time" } },
                parameters: null);

            return D.T;
        }

        public AssetsResponse GetAssets()
        {
            var D = RestRequest<AssetsResponse, AssetsResponse>(
                resource: "{scope}/{op}",
                segments: new Dictionary<string, string>() { { "scope", "public" }, { "op", "Assets" } },
                parameters: null);
            return D;
        }

        #endregion //API commands

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

        public void StartBackgroundThread()
        {
            if (!getTradesThread.IsAlive)
                getTradesThread.Start();
            if (!getSpreadsThread.IsAlive)
                getSpreadsThread.Start();
        }

        public void StopBackgroundThread()
        {
            getTradesThread.Abort();
            getSpreadsThread.Abort();
        }

        public bool IsRunning
        {
            get 
            {
                if (getTradesThread.IsAlive && getSpreadsThread.IsAlive)
                    return true;
                return false;
            }
        }

        public uint TradeCount
        {
            get { return tradeCount; }
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

        private void getSpreadsWorker()
        {
            while (true)
            {
                requestLimiter.EnqueRequest(
                    () => RequestSpreads(),      //note that only the events will be triggered
                    priority: 0);
            }
        }

        #endregion

        RestClient IRestConnection.client
        {
            get { return client; }
        }
    }
}