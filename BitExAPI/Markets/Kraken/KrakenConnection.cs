using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace BitExAPI.Markets.Kraken
{
    

    public class KrakenConnection: IMarketConnection, IRestConnection
    {
        private string endpoint = "https://api.kraken.com/0/";
        private static RateLimiter requestLimiter = new RateLimiter();
        private RestClient client;
        private string sinceLastTrade = "";

        private Thread getTradesThread;

        public event EventHandler<Events.TradesEventArgs> OnTradesUpdated;

        public KrakenConnection(string since = "")
        {
            client = new RestClient(endpoint);
            getTradesThread = new Thread(new ThreadStart(TriggerTradeUpdate));
            sinceLastTrade = since;
        }

        public void UpdateTrades(TradesResponse newTrades)
        {
            if (newTrades != null)
            {
                if (newTrades.error == "[\"EAPI:Rate limit exceeded\"]")
                {
                    throw new Exception("Rate Limit Exceeded");
                }
                var t = newTrades.result.XXBTZEUR;
                if (OnTradesUpdated != null && t.Count > 0)
                    OnTradesUpdated(null, new Events.TradesEventArgs() {
                        data = newTrades, 
                        APIName = "kraken"
                        });

                sinceLastTrade = newTrades.result.last;
            }
        }

        public void TriggerTradeUpdate()
        {
            while (true)
            {
                requestLimiter.EnqueRequest(
                    RequestTrades, 
                    priority: 0);
            }
        }

        public void RequestTrades()
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
            UpdateTrades(response2.Data);

        }

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

        public void Start()
        {
            if (!getTradesThread.IsAlive)
                getTradesThread.Start();
        }




    }
}