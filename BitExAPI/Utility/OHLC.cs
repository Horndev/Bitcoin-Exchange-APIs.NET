using BitExAPI.Markets.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExAPI.Utility
{
    /// <summary>
    /// Representation of trade data as OHLC points
    /// </summary>
    public static class OHLC
    {
        public static List<OHLCPoint> Convert(List<TradePoint> trades, TimeSpan period)
        {
            List<OHLCPoint> res = new List<OHLCPoint>();
            var tradeList = trades.OrderBy(t => t.datetime);
            DateTime time = tradeList.First().TimeUTC;
            decimal open = tradeList.First().Price;
            decimal high = tradeList.First().Price;
            decimal low = tradeList.First().Price;
            decimal close = tradeList.First().Price;
            
            foreach (TradePoint tp in tradeList.Skip(1))
            {
                if ((tp.TimeUTC - time) >= period)
                {
                    res.Add (new OHLCPoint()
                    {
                        TimePeriod = period,
                        Open = open,
                        High = high,
                        Low = low,
                        Close = tp.Price,
                        TimeUTC = time
                    });
                    time = tp.TimeUTC;
                    open = tp.Price;
                    high = tp.Price;
                    low = tp.Price;
                }
                if (tp.Price > high) high = tp.Price;
                if (tp.Price < low) low = tp.Price;
            }
            return res;
        }
    }


    public class OHLCPoint
    {
        [JsonIgnore]
        public DateTime TimeUTC { get; set; }

        [JsonIgnore]
        public TimeSpan TimePeriod { get; set; }

        [JsonProperty("t")]
        public long datetime
        {
            get
            {
                return TimeUTC.ToBinary();
            }
            set
            {
                TimeUTC = DateTime.FromBinary(value);
            }
        }

        [JsonProperty("p")]
        public long period
        {
            get
            {
                return TimePeriod.Ticks;
            }
            set
            {
                TimePeriod = TimeSpan.FromTicks(value);
            }
        }

        [JsonProperty("o")]
        public decimal Open { get; set; }

        [JsonProperty("h")]
        public decimal High { get; set; }

        [JsonProperty("l")]
        public decimal Low { get; set; }

        [JsonProperty("c")]
        public decimal Close { get; set; }
    }
}
