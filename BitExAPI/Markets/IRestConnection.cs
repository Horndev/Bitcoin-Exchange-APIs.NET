using BitExAPI.Markets.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    /// <summary>
    /// Each Market API with a rest conection will implment this interface
    /// </summary>
    public interface IRestConnection
    {
        string RestEndpoint { get; set; }

        RestClient client { get; }

        R RestRequest<T, R>(string resource, Dictionary<string, string> segments, Dictionary<string, string> parameters)
            where T : RestResponse, new()
            where R : IMarketData;
    }
}
