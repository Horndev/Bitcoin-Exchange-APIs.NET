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
