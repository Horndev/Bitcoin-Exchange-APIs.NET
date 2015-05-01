using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken
{
    public abstract class KrakenResponse : RestResponse
    {
        public string error { get; set; }
    }
}
