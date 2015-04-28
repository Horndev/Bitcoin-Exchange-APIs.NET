using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    public abstract class RestResponse
    {
        /// <summary>
        /// Convert each response to a standard BitExAPI data object
        /// </summary>
        /// <returns></returns>
        public abstract MarketData ToMarketData();
    }
}
