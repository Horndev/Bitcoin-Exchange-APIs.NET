using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    public interface IRestConnection
    {
        string RestEndpoint { get; set; }

        R RestRequest<T, R>(string resource, Dictionary<string, string> segments, Dictionary<string, string> parameters)
            where T : RestResponse, new()
            where R : IMarketData;
    }
}
