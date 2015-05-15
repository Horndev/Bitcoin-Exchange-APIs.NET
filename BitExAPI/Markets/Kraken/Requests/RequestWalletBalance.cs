using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{

    /// <summary>
    /// https://api.kraken.com/0/private/Balance
    /// </summary>
    public class RequestWalletBalance : KrakenRequest
    {
        public RequestWalletBalance()
        {
            // Ensure there is an API key loaded
            if (KrakenConnection.Crypto == null)
            {
                throw new Exception("Unable to execute Private Kraken API request: Wallet Balance.  No API key configured.");
            }

            this.RestResource = "/0/{scope}/{op}";
            this.RestResourceSegments = new Dictionary<string, string>() { { "scope", "private" }, { "op", "Balance" } };
        }

        public override Data.IMarketData Execute(IRestConnection connection)
        {
            this._connection = connection;
            //Add headers for private request

            //RequestHeaders.Add( )

            
            return base.Execute(connection);
        }
    }
}
