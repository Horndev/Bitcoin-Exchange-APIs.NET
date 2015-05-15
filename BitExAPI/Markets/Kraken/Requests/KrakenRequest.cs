using BitExAPI.Crypto;
using BitExAPI.Markets.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class KrakenRequest
    {
        public string RestResource;
        public Dictionary<string, string> RestResourceSegments;
        public Dictionary<string, string> RestParameters;
        public Dictionary<string, string> RequestHeaders = new Dictionary<string,string>();
        protected IRestConnection _connection = null;


        public virtual IMarketData Execute(IRestConnection connection)
        {
            return null;
        }

        protected T restRequest<T>()
            where T : RestResponse, new()
        {
            var request = createRequest();

            IRestResponse<T> response = _connection.client.Execute<T>(request);

            return response.Data;
        }

        protected RestRequest createRequest()
        {
            var request = new RestRequest(RestResource, Method.POST);
            foreach (var kvp in RestResourceSegments)
            {
                request.AddUrlSegment(kvp.Key, kvp.Value);
            }

            if (RestParameters != null)
                foreach (var param in RestParameters)
                {
                    request.AddParameter(param.Key, param.Value);
                }

            foreach (var h in RequestHeaders)
            {
                request.AddHeader(h.Key, h.Value);
            }
            return request;
        }
    }
}
