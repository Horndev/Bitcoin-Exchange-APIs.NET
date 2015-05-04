using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Data
{
    public class Assets : List<BitExAPI.Markets.Data.Assets.Asset>, IMarketData
    {
        public string name;

        public class Asset
        {
            public string aclass { get; set; }
            public string altname { get; set; }
            public int decimals { get; set; }
            public int display_decimals { get; set; }
        }
    }
}
