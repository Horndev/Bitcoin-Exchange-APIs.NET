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
    }
}
