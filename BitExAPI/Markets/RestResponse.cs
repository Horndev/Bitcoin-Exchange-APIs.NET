using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets
{
    /// <summary>
    /// All Exchange response objects inherit from this.  The ToMarketData method must be defined to normalize from the exchange formats to the standard BitEx format.
    /// </summary>
    public abstract class RestResponse
    {
        /// <summary>
        /// Convert each response to a standard BitExAPI data object
        /// </summary>
        /// <returns></returns>
        public abstract IMarketData ToMarketData();
    }
}
