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
            //List<OHLCPoint> res = new List<OHLCPoint>();
            var ticks = trades.OrderBy(t => t.datetime);
            var periodTicks = period.Ticks;
            var firsttick = trades.Min(t => t.TimeUTC.Ticks);
            var res = trades.GroupBy(t => (t.TimeUTC.Ticks - firsttick) / periodTicks, t => t)
                .Select(g => new OHLCPoint()
                {
                    TimePeriod = period,
                    Open = g.First().Price,
                    High = g.Max(p => p.Price),
                    Low = g.Min(p => p.Price),
                    Close = g.Last().Price,
                    TimeUTC = new DateTime(g.Key * periodTicks + firsttick, DateTimeKind.Utc)
                });
            

            //DateTime time = ticks.First().TimeUTC;
            //decimal open = ticks.First().Price;
            //decimal high = ticks.First().Price;
            //decimal low = ticks.First().Price;
            //decimal close = ticks.First().Price;
            
            //foreach (TradePoint tp in ticks.Skip(1))
            //{
            //    if ((tp.TimeUTC - time) >= period)
            //    {
            //        res.Add (new OHLCPoint()
            //        {
            //            TimePeriod = period,
            //            Open = open,
            //            High = high,
            //            Low = low,
            //            Close = tp.Price,
            //            TimeUTC = time
            //        });
            //        time = tp.TimeUTC;
            //        open = tp.Price;
            //        high = tp.Price;
            //        low = tp.Price;
            //    }
            //    if (tp.Price > high) high = tp.Price;
            //    if (tp.Price < low) low = tp.Price;
            //}
            return res.ToList();
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
