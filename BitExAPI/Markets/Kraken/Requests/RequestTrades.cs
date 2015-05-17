
using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class RequestTrades : KrakenRequest
    {
        private PairsBase Pair;
        private Int64 SinceTimeUTC_Epoch_e9;

        public RequestTrades(PairsBase pair)
        {
            this.RestResource = "/0/{scope}/{op}";
            this.RestResourceSegments = new Dictionary<string, string>() { { "scope", "public" }, { "op", "Trades" } };
            this.RestParameters = new Dictionary<string, string>();
            this.Pair = pair;
            this.SinceTimeUTC_Epoch_e9 = 0;
        }

        public RequestTrades(PairsBase pair, Int64 since)
            : this(pair)
        {
            this.SinceTimeUTC_Epoch_e9 = since;
        }

        public RequestTrades(PairsBase pair, string since)
            : this(pair)
        {
            if (since != "")
                this.SinceTimeUTC_Epoch_e9 = Convert.ToInt64(since);
        }

        public override IMarketData Execute(IRestConnection connection)
        {
            this._connection = connection;
            string pair = Pair.ToString();

            RestParameters.Add("pair", pair);
            if (SinceTimeUTC_Epoch_e9 != 0)
                RestParameters.Add("since", Convert.ToString(SinceTimeUTC_Epoch_e9));

            TradesResponse tr = restRequest<TradesResponse>();

            return tr.ToMarketData();
        }
    }
}
