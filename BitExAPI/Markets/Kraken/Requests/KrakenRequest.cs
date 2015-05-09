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

        public virtual IMarketData Execute(IRestConnection connection)
        {
            return null;
        }

        protected T restRequest<T>(IRestConnection connection, string resource, Dictionary<string, string> segments, Dictionary<string, string> parameters)
            where T : RestResponse, new()
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

            IRestResponse<T> response = connection.client.Execute<T>(request);

            return response.Data;
        }
    }
}
