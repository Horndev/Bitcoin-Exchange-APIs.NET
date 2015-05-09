
using BitExAPI.Markets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Markets.Kraken.Requests
{
    public class TradesRequest : KrakenRequest
    {
        private PairsBase Pair;
        private Int64 SinceTimeUTC_Epoch_e9;

        public TradesRequest(PairsBase pair)
        {
            this.RestResource = "{scope}/{op}";
            this.RestResourceSegments = new Dictionary<string, string>() { { "scope", "public" }, { "op", "Trades" } };
            this.Pair = pair;
            this.SinceTimeUTC_Epoch_e9 = 0;
        }

        public TradesRequest(PairsBase pair, Int64 since)
            : this(pair)
        {
            this.SinceTimeUTC_Epoch_e9 = since;
        }

        public TradesRequest(PairsBase pair, string since)
            : this(pair)
        {
            if (since != "")
                this.SinceTimeUTC_Epoch_e9 = Convert.ToInt64(since);
        }

        public override IMarketData Execute(IRestConnection connection)
        {
            string pair = Pair.ToString();
            var p = new Dictionary<string, string>();

            p.Add("pair", pair);
            if (SinceTimeUTC_Epoch_e9 != 0)
                p.Add("since", Convert.ToString(SinceTimeUTC_Epoch_e9));

            TradesResponse tr = restRequest<TradesResponse>(connection, RestResource, RestResourceSegments, p);

            return tr.ToMarketData();
        }
    }
}
